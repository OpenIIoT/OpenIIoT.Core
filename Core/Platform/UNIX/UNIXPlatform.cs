using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Linq;
using NLog;
using Symbiote.Core.Plugin.Connector;
using System.Text;
using System.Text.RegularExpressions;
using System.IO.Compression;

namespace Symbiote.Core.Platform.UNIX
{
    /// <summary>
    /// The Windows class implements the platform interfaces necessary to run the application on the UNIX platform.
    /// </summary>
    /// <remarks>
    /// Some wierdness in the C# compiler won't allow implicitly defined interface properties if the property is less
    /// accessible than public.  For whatever reason the properties can be public but the class can be internal.
    /// The effective accessibility for these classes and all of their members is internal.
    /// </remarks>
    [System.Runtime.CompilerServices.CompilerGenerated]
    class NamespaceDoc { }

    internal class UNIXPlatform : IPlatform
    {
        #region Variables

        /// <summary>
        /// The Logger for this class.
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Properties

        /// <summary>
        /// The Platform Type.
        /// </summary>
        public PlatformType PlatformType { get; private set; }

        /// <summary>
        /// The Version of the Platform OS.
        /// </summary>
        public string Version { get; private set; }

        /// <summary>
        /// The accompanying Connector Plugin for the Platform.
        /// </summary>
        public IConnector Connector { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// The default constructor.
        /// </summary>
        public UNIXPlatform()
        {
            PlatformType = PlatformType.UNIX;
            Version = Environment.OSVersion.VersionString;
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Instantiates the accompanying Connector Plugin with the supplied root path.
        /// </summary>
        /// <param name="instanceName"></param>
        /// <returns>The instantiated Connector Plugin.</returns>
        public IConnector InstantiateConnector(string instanceName)
        {
            Connector = new PlatformConnector(instanceName);
            return Connector;
        }

        #region Directory Methods

        /// <summary>
        /// Returns true if the specified directory exists, false otherwise.
        /// </summary>
        /// <param name="directory">The directory to check.</param>
        /// <returns>True if the specified directory exists, false otherwise.</returns>
        public bool DirectoryExists(string directory)
        {
            return Directory.Exists(directory);
        }

        /// <summary>
        /// Returns a list of subdirectories within the supplied path.
        /// </summary>
        /// <param name="parentDirectory">The parent directory to search.</param>
        /// <returns>An OperationResult containing the result of the operation and list containing the fully qualified path of each directory found.</returns>
        public OperationResult<List<string>> ListDirectories(string parentDirectory)
        {
            logger.Trace("Listing subdirectories of '" + parentDirectory + "'...");
            OperationResult<List<string>> retVal = new OperationResult<List<string>>();
            retVal.Result = new List<string>();

            try
            {
                retVal.Result = Directory.EnumerateDirectories(parentDirectory).ToList<string>();
            }
            catch (IOException ex)
            {
                retVal.AddError("Error listing subdirectories for root path '" + parentDirectory + "': " + ex.Message);
            }

            retVal.LogResult(logger.Trace);
            return retVal;
        }

        /// <summary>
        /// Deletes the supplied directory.
        /// </summary>
        /// <param name="directory">The directory to delete.</param>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        public OperationResult DeleteDirectory(string directory)
        {
            logger.Trace("Attempting to delete directory '" + directory + "'...");
            OperationResult retVal = new OperationResult();

            try
            {
                DirectoryInfo di = new DirectoryInfo(directory);
                di.Delete(true);
            }
            catch (Exception ex)
            {
                retVal.AddError("Exception thrown while deleting the directory '" + directory + "': " + ex);
            }

            retVal.LogResult(logger.Trace);
            return retVal;
        }

        /// <summary>
        /// Deletes all files and subdirectories within the supplied directory.
        /// </summary>
        /// <param name="directory">The directory to clear.</param>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        public OperationResult ClearDirectory(string directory)
        {
            logger.Trace("Attempting to clear the contents of directory '" + directory + "'...");
            OperationResult retVal = new OperationResult();

            try
            {
                DirectoryInfo di = new DirectoryInfo(directory);

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }
            }
            catch (Exception ex)
            {
                retVal.AddError("Exception thrown while clearing directory '" + directory + "': " + ex);
            }

            retVal.LogResult(logger.Trace);
            return retVal;
        }

        /// <summary>
        /// Creates the supplied directory.
        /// </summary>
        /// <param name="directory">The directory to create.</param>
        /// <returns>An OperationResult containing the result of the operation and the fully qualified path to the directory.</returns>
        public OperationResult<string> CreateDirectory(string directory)
        {
            logger.Trace("Creating directory '" + directory + "'...");
            OperationResult<string> retVal = new OperationResult<string>();

            try
            {
                retVal.Result = Directory.CreateDirectory(directory).FullName;
            }
            catch (Exception ex)
            {
                retVal.AddError("Exception thrown while creating directory '" + directory + "': " + ex);
            }

            retVal.LogResult(logger.Trace);
            return retVal;
        }

        #endregion

        #region File Methods

        /// <summary>
        /// Returns true if the specified file exists, false otherwise.
        /// </summary>
        /// <param name="file">The file to check.</param>
        /// <returns>True if the specified file exists, false otherwise.</returns>
        public bool FileExists(string file)
        {
            return File.Exists(file);
        }

        /// <summary>
        /// Returns a list of files within the supplied directory matching the supplied searchPattern.
        /// </summary>
        /// <param name="parentDirectory">The directory to search.</param>
        /// <param name="searchPattern">The search pattern to match files against.</param>
        /// <returns>An OperationResult containing the result of the operation and a list containing the fully qualified filename of each file found.</returns>
        public OperationResult<List<string>> ListFiles(string parentDirectory, string searchPattern)
        {
            logger.Trace("Listing files in directory '" + parentDirectory + "' matching searchPattern '" + searchPattern + "'...");
            OperationResult<List<string>> retVal = new OperationResult<List<string>>();
            retVal.Result = new List<string>();

            try
            {
                retVal.Result = Directory.EnumerateFiles(parentDirectory, searchPattern, SearchOption.AllDirectories).ToList<string>();
            }
            catch (IOException ex)
            {
                retVal.AddError("Error listing files for directory '" + parentDirectory + "' using search pattern '" + searchPattern + " : " + ex);
            }

            retVal.LogResult(logger.Trace);
            return retVal;
        }

        /// <summary>
        /// Deletes the specified file.
        /// </summary>
        /// <param name="file">The file to delete.</param>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        public OperationResult DeleteFile(string file)
        {
            logger.Trace("Deleting file '" + file + "'...");
            OperationResult retVal = new OperationResult();

            try
            {
                File.Delete(file);
            }
            catch (Exception ex)
            {
                retVal.AddError("Exception thrown while attempting to delete file '" + file + "': " + ex);
            }

            retVal.LogResult(logger.Trace);
            return retVal;
        }

        /// <summary>
        /// Reads the contents of the specified file into a single string.
        /// </summary>
        /// <param name="file">The file to read.</param>
        /// <returns>An OperationResult containing the result of the operation and a string containing the entire contents of the file.</returns>
        public OperationResult<string> ReadFile(string file)
        {
            logger.Trace("Reading contents of file '" + file + "'...");
            OperationResult<string> retVal = new OperationResult<string>();

            try
            {
                retVal.Result = File.ReadAllText(file);
            }
            catch (Exception ex)
            {
                retVal.AddError("Error reading file '" + file + "': " + ex);
            }

            retVal.LogResult(logger.Trace);
            return retVal;
        }

        /// <summary>
        /// Reads the contents of the specified file into a string array.
        /// </summary>
        /// <param name="file">The file to read.</param>
        /// <returns>An OperationResult containing the result of the operation and a string array containing all of the lines from the file.</returns>
        public OperationResult<string[]> ReadFileLines(string file)
        {
            logger.Trace("Reading lines from file '" + file + "'...");
            OperationResult<string[]> retVal = new OperationResult<string[]>();

            try
            {
                retVal.Result = File.ReadAllLines(file);
            }
            catch (Exception ex)
            {
                retVal.AddError("Error reading lines from file '" + file + "': " + ex);
            }

            retVal.LogResult(logger.Trace);
            return retVal;
        }

        /// <summary>
        /// Writes the contents of the supplied string into the specified file.  If the destination file already exists it is overwritten.
        /// </summary>
        /// <param name="file">The file to write.</param>
        /// <param name="contents">The text to write to the file.</param>
        /// <returns>The fully qualified name of the written file.</returns>
        public OperationResult<string> WriteFile(string file, string contents)
        {
            logger.Trace("Writing to file '" + file + "'...");
            OperationResult<string> retVal = new OperationResult<string>();

            try
            {
                File.WriteAllText(file, contents);
                retVal.Result = file;
            }
            catch (Exception ex)
            {
                retVal.AddError("Error writing to file '" + file + "': " + ex);
            }

            retVal.LogResult(logger.Trace);
            return retVal;
        }

        #endregion

        #region Zip File Methods

        /// <summary>
        /// Returns a list of files contained within the specified zip file matching the supplied searchPattern.
        /// </summary>
        /// <param name="zipFile">The zip file to search.</param>
        /// <param name="searchPattern">The search pattern to match files against.</param>
        /// <returns>An OperationResult containing the result of the operation and a list containing the fully qualified filename of each file found.</returns>
        public OperationResult<List<string>> ListZipFiles(string zipFile, string searchPattern)
        {
            logger.Trace("Listing files in zip file '" + zipFile + "' matching searchPattern '" + searchPattern + "'...");
            OperationResult<List<string>> retVal = new OperationResult<List<string>>();
            retVal.Result = new List<string>();

            logger.Trace("Converting pattern '" + searchPattern + "' to RegEx..");
            Regex regex = new Regex(Utility.WildcardToRegex(searchPattern), RegexOptions.IgnoreCase);
            logger.Trace("Converted pattern to RegEx '" + regex + "'");

            try
            {
                logger.Trace("Opening zip file...");
                using (ZipArchive archive = ZipFile.OpenRead(zipFile))
                {
                    logger.Trace("Iterating over the contents of the file...");
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        if (regex.IsMatch(entry.Name))
                            retVal.Result.Add(entry.FullName);
                    }

                    logger.Trace(retVal.Result.Count + " matches for '" + regex + "' found.");
                }
            }
            catch (Exception ex)
            {
                retVal.AddError("Error listing files in zip file '" + zipFile + "': " + ex);
            }

            retVal.LogResult(logger.Trace);
            return retVal;
        }

        /// <summary>
        /// Extracts the contents of the supplied zip file to the specified destination, 
        /// clearing the destination first if clearDestination is true.
        /// </summary>
        /// <param name="zipFile">The zip file to extract.</param>
        /// <param name="destination">The destination directory.</param>
        /// <param name="clearDestination">True if the destination directory should be cleared prior to extraction, false otherwise.</param>
        /// <returns>An OperationResult containing the result of the operation and the fully qualified path to the extracted files.</returns>
        public OperationResult<string> ExtractZip(string zipFile, string destination, bool clearDestination = true)
        {
            logger.Trace("Extracting zip file '" + zipFile + "' to destination '" + destination + "'...");
            OperationResult<string> retVal = new OperationResult<string>();

            try
            {
                if (clearDestination)
                {
                    logger.Trace("Attempting to clear destination directory '" + destination + "'...");
                    OperationResult clearResult = ClearDirectory(destination);
                    if (clearResult.ResultCode != OperationResultCode.Success)
                        throw new Exception("Error clearing destination directory: " + clearResult.GetLastError());
                }

                logger.Trace("Extracting file...");
                ZipFile.ExtractToDirectory(zipFile, destination);
            }
            catch (Exception ex)
            {
                retVal.AddError("Error extracting zip file '" + zipFile + "' to destination '" + destination + "': " + ex);
            }

            retVal.LogResult(logger.Trace);
            return retVal;
        }

        /// <summary>
        /// Extracts the supplied file from the supplied zip file to the supplied destination, overwriting the file if overwrite is true.
        /// </summary>
        /// <param name="zipFile">The zip file from which to extract the file.</param>
        /// <param name="file">The file to extract from the zip file.</param>
        /// <param name="destination">The destination directory.</param>
        /// <param name="overwrite">True if an existing file should be overwritten, false otherwise.</param>
        /// <returns>An OperationResult containing the result of the operation and the fully qualified filename of the extracted file.</returns>
        public OperationResult<string> ExtractZipFile(string zipFile, string file, string destination, bool overwrite = true)
        {
            logger.Trace("Extracting file '" + file + "' from zip file '" + zipFile + "' into directory '" + destination + "'...");
            OperationResult<string> retVal = new OperationResult<string>();

            try
            {
                logger.Trace("Opening zip file '" + zipFile + "'...");
                using (ZipArchive archive = ZipFile.Open(zipFile, ZipArchiveMode.Update))
                {
                    ZipArchiveEntry entry = archive.GetEntry(file);

                    string extractedFile = Path.Combine(destination, entry.Name);

                    logger.Trace("Extracting file '" + file + "'...");
                    entry.ExtractToFile(extractedFile, overwrite);
                    retVal.Result = extractedFile;
                }
            }
            catch (Exception ex)
            {
                retVal.AddError("Error extracting file '" + file + "' from zip file '" + zipFile + "': " + ex);
            }

            retVal.LogResult(logger.Trace);
            return retVal;
        }

        #endregion

        /// <summary>
        /// Computes the checksum of the specified file.
        /// </summary>
        /// <param name="file">The file for which the checksum is to be computed.</param>
        /// <returns>An OperationResult containing the result of the operation and the computed checksum.</returns>
        public OperationResult<string> ComputeFileChecksum(string file)
        {
            logger.Trace("Computing checksum for file '" + file + "'...");
            OperationResult<string> retVal = new OperationResult<string>();

            byte[] binFile = File.ReadAllBytes(file);
            byte[] checksum = MD5.Create().ComputeHash(binFile);

            StringBuilder builtString = new StringBuilder();
            foreach (byte b in checksum)
            {
                builtString.Append(b.ToString("x2"));
            }

            retVal.Result = builtString.ToString();

            retVal.LogResult(logger.Trace);
            return retVal;
        }

        #endregion
    }
}
