/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄███████▄
      █     ███    ███
      █     ███    ███  █         ▄█████      ██       ▄█████  ██████     █████    ▄▄██▄▄▄
      █     ███    ███ ██         ██   ██ ▀███████▄   ██   ▀█ ██    ██   ██  ██  ▄█▀▀██▀▀█▄
      █   ▀█████████▀  ██         ██   ██     ██  ▀  ▄██▄▄    ██    ██  ▄██▄▄█▀  ██  ██  ██
      █     ███        ██       ▀████████     ██    ▀▀██▀▀    ██    ██ ▀███████  ██  ██  ██
      █     ███        ██▌    ▄   ██   ██     ██      ██      ██    ██   ██  ██  ██  ██  ██
      █    ▄████▀      ████▄▄██   ██   █▀    ▄██▀     ██       ██████    ██  ██   █  ██  █
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  The abstract base class from which all Platforms inherit.
      █
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀ ▀ ▀▀▀     ▀▀               ▀
      █  The GNU Affero General Public License (GNU AGPL)
      █
      █  Copyright (C) 2016 JP Dillingham (jp@dillingham.ws)
      █
      █  This program is free software: you can redistribute it and/or modify
      █  it under the terms of the GNU Affero General Public License as published by
      █  the Free Software Foundation, either version 3 of the License, or
      █  (at your option) any later version.
      █
      █  This program is distributed in the hope that it will be useful,
      █  but WITHOUT ANY WARRANTY; without even the implied warranty of
      █  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
      █  GNU Affero General Public License for more details.
      █
      █  You should have received a copy of the GNU Affero General Public License
      █  along with this program.  If not, see <http://www.gnu.org/licenses/>.
      █
      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██
                                                                                                   ██
                                                                                               ▀█▄ ██ ▄█▀
                                                                                                 ▀████▀
                                                                                                   ▀▀                            */

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using NLog;
using NLog.xLogger;
using Symbiote.SDK;
using Symbiote.SDK.Platform;
using Utility.OperationResult;

namespace Symbiote.Core.Platform
{
    /// <summary>
    ///     The abstract base class from which all Platforms inherit.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Derivations of the Platform class are designed to abstract OS-specific file system I/O differences from the rest of
    ///         the application. When first introduced it was unclear how well Mono handled abstractions in UNIX environments, and
    ///         it is now known that file system differences are a non-issue.
    ///     </para>
    ///     <para>
    ///         The need for platform-specific code remains outside of file system I/O, most notably in the startup of the
    ///         application in Windows environments when running as a service, in addition to OS/platform metrics.
    ///     </para>
    ///     <para>
    ///         Each Platform instance contains the <see cref="PlatformType"/> and <see cref="Version"/> properties, which return
    ///         the platform type; <see cref="PlatformType.Windows"/> or <see cref="PlatformType.UNIX"/>, and the OS-specific
    ///         version, respectively. The PlatformType property is reference during application startup to determine the run mode
    ///         while Version is informational.
    ///     </para>
    ///     <para>
    ///         The Platform instance also contains the <see cref="Metrics"/> property which contains a reference to the Item
    ///         Provider class which accompanies the Platform. This <see cref="IItemProvider"/> provides <see cref="Item"/> objects
    ///         used to report statistics and metrics about the underlying Platform.
    ///     </para>
    ///     <para>
    ///         The methods provided by the Platform class encompass typical file system operations; reading and writing files,
    ///         creating and deleting directories, and listing files and directories. Additionally, several methods used to
    ///         manipulate compressed Zip files are included to facilitate the management and deployment of Plugins.
    ///     </para>
    ///     <para>This class is expected to continually expand as the needs of the application increase.</para>
    /// </remarks>
    [Discoverable]
    public abstract class Platform : IPlatform
    {
        #region Private Fields

        /// <summary>
        ///     The Logger for this class.
        /// </summary>
        private static xLogger logger = (xLogger)LogManager.GetCurrentClassLogger(typeof(xLogger));

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Platform"/> class.
        /// </summary>
        public Platform()
        {
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        ///     Gets or sets the accompanying Item Provider for the Platform.
        /// </summary>
        [Discoverable]
        public IItemProvider ItemProvider { get; protected set; }

        /// <summary>
        ///     Gets or sets the Platform Type.
        /// </summary>
        public PlatformType PlatformType { get; protected set; }

        /// <summary>
        ///     Gets or sets the Version of the Platform OS.
        /// </summary>
        public string Version { get; protected set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///     Deletes all files and subdirectories within the specified directory.
        /// </summary>
        /// <param name="directory">The directory to clear.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public virtual Result ClearDirectory(string directory)
        {
            logger.EnterMethod(xLogger.Params(directory));
            logger.Debug("Attempting to clear the contents of directory '" + directory + "'...");
            Result retVal = new Result();

            try
            {
                DirectoryInfo di = new DirectoryInfo(directory);

                // delete all files
                foreach (FileInfo file in di.GetFiles())
                {
                    DeleteFile(file.FullName);
                }

                // delete all folders recursively
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    DeleteDirectory(dir.FullName, true);
                }
            }
            catch (Exception ex)
            {
                retVal.AddError("Exception thrown while clearing directory '" + directory + "': " + ex);
                logger.Exception(LogLevel.Debug, ex);
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Computes the SHA256 checksum of the specified file.
        /// </summary>
        /// <param name="file">The file for which the checksum is to be computed.</param>
        /// <returns>A Result containing the result of the operation and the computed checksum.</returns>
        public virtual Result<string> ComputeFileChecksum(string file)
        {
            logger.EnterMethod(xLogger.Params(file));
            Result<string> retVal = new Result<string>();

            try
            {
                byte[] binFile = File.ReadAllBytes(file);
                byte[] checksum = SHA256.Create().ComputeHash(binFile);

                StringBuilder builtString = new StringBuilder();
                foreach (byte b in checksum)
                {
                    builtString.Append(b.ToString("x2"));
                }

                retVal.ReturnValue = builtString.ToString();
            }
            catch (Exception ex)
            {
                retVal.AddError("Exception thrown calculating checksum: " + ex.Message);
                logger.Exception(LogLevel.Debug, ex);
            }

            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Creates the specified directory.
        /// </summary>
        /// <param name="directory">The directory to create.</param>
        /// <returns>A Result containing the result of the operation and the fully qualified path to the created directory.</returns>
        public virtual Result<string> CreateDirectory(string directory)
        {
            logger.EnterMethod(xLogger.Params(directory));
            logger.Debug("Creating directory '" + directory + "'...");
            Result<string> retVal = new Result<string>();

            try
            {
                retVal.ReturnValue = Directory.CreateDirectory(directory).FullName;
            }
            catch (Exception ex)
            {
                retVal.AddError("Exception thrown while creating directory '" + directory + "': " + ex);
                logger.Exception(LogLevel.Debug, ex);
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Creates the specified zip file from the specified directory.
        /// </summary>
        /// <param name="zipFile">The zip file to which the directory is to be compressed.</param>
        /// <param name="source">The directory from which the zip file is to be created.</param>
        /// <returns>
        ///     A Result containing the result of the operation and the fully qualified filename of the created zip file.
        /// </returns>
        public virtual Result<string> CreateZip(string zipFile, string source)
        {
            logger.EnterMethod(xLogger.Params(zipFile, source));
            logger.Trace("Creating zip file '" + zipFile + "' from directory '" + source + "'...");

            Result<string> retVal = new Result<string>();

            try
            {
                ZipFile.CreateFromDirectory(source, zipFile);
            }
            catch (Exception ex)
            {
                retVal.AddError("Error creating zip file '" + zipFile + "' from directory '" + source + "': " + ex);
                logger.Exception(LogLevel.Debug, ex);
            }

            retVal.LogResult(logger.Trace);
            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Deletes the specified directory.
        /// </summary>
        /// <param name="directory">The directory to delete.</param>
        /// <param name="recursive">
        ///     A value indicating whether to recursively delete subdirectories and files contained within the directory.
        /// </param>
        /// <returns>A Result containing the result of the operation.</returns>
        public virtual Result DeleteDirectory(string directory, bool recursive = true)
        {
            logger.EnterMethod(xLogger.Params(directory));
            logger.Debug("Attempting to delete directory '" + directory + "'...");
            Result retVal = new Result();

            try
            {
                DirectoryInfo di = new DirectoryInfo(directory);
                di.Delete(recursive);
            }
            catch (Exception ex)
            {
                retVal.AddError("Exception thrown while deleting the directory '" + directory + "': " + ex);
                logger.Exception(LogLevel.Debug, ex);
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Deletes the specified file.
        /// </summary>
        /// <param name="file">The file to delete.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public virtual Result DeleteFile(string file)
        {
            logger.EnterMethod(xLogger.Params(file));
            logger.Debug("Deleting file '" + file + "'...");
            Result retVal = new Result();

            try
            {
                File.Delete(file);
            }
            catch (Exception ex)
            {
                retVal.AddError("Exception thrown while attempting to delete file '" + file + "': " + ex);
                logger.Exception(LogLevel.Debug, ex);
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Returns true if the specified directory exists, false otherwise.
        /// </summary>
        /// <param name="directory">The directory to check.</param>
        /// <returns>A value indicating whether the specified directory exists.</returns>
        public virtual bool DirectoryExists(string directory)
        {
            return Directory.Exists(directory);
        }

        /// <summary>
        ///     Extracts the contents of the specified zip file to the specified destination, clearing the destination first if
        ///     clearDestination is true.
        /// </summary>
        /// <param name="zipFile">The zip file to extract.</param>
        /// <param name="destination">The destination directory.</param>
        /// <param name="clearDestination">
        ///     True if the destination directory should be cleared prior to extraction, false otherwise.
        /// </param>
        /// <returns>A Result containing the result of the operation and the fully qualified path to the extracted files.</returns>
        public virtual Result<string> ExtractZip(string zipFile, string destination, bool clearDestination = true)
        {
            logger.EnterMethod(xLogger.Params(zipFile, destination, clearDestination));
            logger.Trace("Extracting zip file '" + zipFile + "' to destination '" + destination + "'...");

            Result<string> retVal = new Result<string>();

            try
            {
                if (!DirectoryExists(destination))
                {
                    CreateDirectory(destination);
                }

                if (clearDestination)
                {
                    logger.Trace("Attempting to clear destination directory '" + destination + "'...");
                    Result clearResult = ClearDirectory(destination);
                    if (clearResult.ResultCode != ResultCode.Success)
                    {
                        throw new Exception("Error clearing destination directory: " + clearResult.GetLastError());
                    }
                }

                logger.Trace("Extracting file...");
                ZipFile.ExtractToDirectory(zipFile, destination);
            }
            catch (Exception ex)
            {
                retVal.AddError("Error extracting zip file '" + zipFile + "' to destination '" + destination + "': " + ex);
                logger.Exception(LogLevel.Debug, ex);
            }

            retVal.LogResult(logger.Trace);
            logger.ExitMethod(retVal.ResultCode);
            return retVal;
        }

        /// <summary>
        ///     Extracts the specified file from the specified zip file to the specified destination, overwriting the file if
        ///     overwrite is true.
        /// </summary>
        /// <param name="zipFile">The zip file from which to extract the file.</param>
        /// <param name="file">The file to extract from the zip file.</param>
        /// <param name="destination">The destination directory.</param>
        /// <param name="overwrite">True if an existing file should be overwritten, false otherwise.</param>
        /// <returns>
        ///     A Result containing the result of the operation and the fully qualified filename of the extracted file.
        /// </returns>
        public virtual Result<string> ExtractZipFile(string zipFile, string file, string destination, bool overwrite = true)
        {
            logger.EnterMethod(xLogger.Params(zipFile, file, destination, overwrite));
            logger.Trace("Extracting file '" + file + "' from zip file '" + zipFile + "' into directory '" + destination + "'...");

            Result<string> retVal = new Result<string>();

            try
            {
                logger.Trace("Opening zip file '" + zipFile + "'...");
                using (ZipArchive archive = ZipFile.Open(zipFile, ZipArchiveMode.Update))
                {
                    ZipArchiveEntry entry = archive.GetEntry(file);

                    string extractedFile = Path.Combine(destination, entry.Name);

                    logger.Trace("Extracting file '" + file + "'...");
                    entry.ExtractToFile(extractedFile, overwrite);
                    retVal.ReturnValue = extractedFile;
                }
            }
            catch (Exception ex)
            {
                retVal.AddError("Error extracting file '" + file + "' from zip file '" + zipFile + "': " + ex);
                logger.Exception(LogLevel.Debug, ex);
            }

            retVal.LogResult(logger.Trace);
            logger.ExitMethod(retVal.ResultCode);
            return retVal;
        }

        /// <summary>
        ///     Returns true if the specified file exists, false otherwise.
        /// </summary>
        /// <param name="file">The file to check.</param>
        /// <returns>A value indicating whether the specified file exists.</returns>
        public virtual bool FileExists(string file)
        {
            return File.Exists(file);
        }

        /// <summary>
        ///     Returns a list of subdirectories within the specified directory.
        /// </summary>
        /// <param name="parentDirectory">The parent directory to search.</param>
        /// <param name="searchPattern">The search pattern to which directory names are compared.</param>
        /// <returns>
        ///     A Result containing the result of the operation and list containing the fully qualified path of each directory found.
        /// </returns>
        public virtual Result<List<string>> ListDirectories(string parentDirectory, string searchPattern = "*")
        {
            logger.EnterMethod(xLogger.Params(parentDirectory, searchPattern));
            Result<List<string>> retVal = new Result<List<string>>();
            retVal.ReturnValue = new List<string>();

            try
            {
                retVal.ReturnValue = Directory.EnumerateDirectories(parentDirectory, searchPattern, SearchOption.AllDirectories).ToList<string>();
            }
            catch (IOException ex)
            {
                retVal.AddError("Error listing subdirectories for root path '" + parentDirectory + "' using search pattern '" + searchPattern + "': " + ex.Message);
                logger.Exception(LogLevel.Debug, ex);
            }

            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Returns a list of files within the specified directory matching the supplied searchPattern.
        /// </summary>
        /// <param name="parentDirectory">The directory to search.</param>
        /// <param name="searchPattern">The search pattern to which file names are compared.</param>
        /// <returns>
        ///     A Result containing the result of the operation and a list containing the fully qualified filename of each file found.
        /// </returns>
        public virtual Result<List<string>> ListFiles(string parentDirectory, string searchPattern = "*")
        {
            logger.EnterMethod(xLogger.Params(parentDirectory, searchPattern));
            Result<List<string>> retVal = new Result<List<string>>();
            retVal.ReturnValue = new List<string>();

            try
            {
                retVal.ReturnValue = Directory.EnumerateFiles(parentDirectory, searchPattern, SearchOption.AllDirectories).ToList<string>();
            }
            catch (IOException ex)
            {
                retVal.AddError("Error listing files for directory '" + parentDirectory + "' using search pattern '" + searchPattern + "': " + ex);
                logger.Exception(LogLevel.Debug, ex);
            }

            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Returns a list of files contained within the specified zip file matching the supplied searchPattern.
        /// </summary>
        /// <param name="zipFile">The zip file to search.</param>
        /// <param name="searchPattern">The search pattern to match files against.</param>
        /// <returns>
        ///     A Result containing the result of the operation and a list containing the fully qualified filename of each file found.
        /// </returns>
        public virtual Result<List<string>> ListZipFiles(string zipFile, string searchPattern = "*")
        {
            logger.EnterMethod(xLogger.Params(zipFile, searchPattern));
            logger.Trace("Listing files in zip file '" + zipFile + "' matching searchPattern '" + searchPattern + "'...");

            Result<List<string>> retVal = new Result<List<string>>();
            retVal.ReturnValue = new List<string>();

            logger.Trace("Converting pattern '" + searchPattern + "' to RegEx..");
            Regex regex = new Regex(SDK.Utility.WildcardToRegex(searchPattern), RegexOptions.IgnoreCase);
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
                        {
                            retVal.ReturnValue.Add(entry.FullName);
                        }
                    }

                    logger.Trace(retVal.ReturnValue.Count + " matches for '" + regex + "' found.");
                }
            }
            catch (Exception ex)
            {
                retVal.AddError("Error listing files in zip file '" + zipFile + "': " + ex);
                logger.Exception(LogLevel.Debug, ex);
            }

            retVal.LogResult(logger.Trace);
            logger.ExitMethod(retVal.ResultCode);
            return retVal;
        }

        /// <summary>
        ///     Reads the contents of the specified file into a single string.
        /// </summary>
        /// <param name="file">The file to read.</param>
        /// <returns>
        ///     A Result containing the result of the operation and a string containing the entire contents of the file.
        /// </returns>
        public virtual Result<string> ReadFile(string file)
        {
            logger.EnterMethod(xLogger.Params(file));
            logger.Trace("Reading contents of file '" + file + "'...");

            Result<string> retVal = new Result<string>();

            try
            {
                retVal.ReturnValue = File.ReadAllText(file);
            }
            catch (Exception ex)
            {
                retVal.AddError("Error reading file '" + file + "': " + ex);
                logger.Exception(LogLevel.Debug, ex);
            }

            retVal.LogResult(logger.Trace);
            logger.ExitMethod(retVal.ResultCode);
            return retVal;
        }

        /// <summary>
        ///     Reads the contents of the specified file into a string array.
        /// </summary>
        /// <param name="file">The file to read.</param>
        /// <returns>
        ///     A Result containing the result of the operation and a string array containing all of the lines from the file.
        /// </returns>
        public virtual Result<string[]> ReadFileLines(string file)
        {
            logger.EnterMethod(xLogger.Params(file));
            logger.Trace("Reading lines from file '" + file + "'...");

            Result<string[]> retVal = new Result<string[]>();

            try
            {
                retVal.ReturnValue = File.ReadAllLines(file);
            }
            catch (Exception ex)
            {
                retVal.AddError("Error reading lines from file '" + file + "': " + ex);
                logger.Exception(LogLevel.Debug, ex);
            }

            retVal.LogResult(logger.Trace);
            logger.ExitMethod(retVal.ResultCode);
            return retVal;
        }

        /// <summary>
        ///     Writes the contents of the supplied string into the specified file. If the destination file already exists it is overwritten.
        /// </summary>
        /// <param name="file">The file to which the specified contents are written.</param>
        /// <param name="contents">The string containing the content to write.</param>
        /// <returns>The fully qualified name of the written file.</returns>
        public virtual Result<string> WriteFile(string file, string contents)
        {
            logger.EnterMethod(xLogger.Params(file, contents));
            logger.Trace("Writing to file '" + file + "'...");

            Result<string> retVal = new Result<string>();

            try
            {
                File.WriteAllText(file, contents);
                retVal.ReturnValue = file;
            }
            catch (Exception ex)
            {
                retVal.AddError("Error writing to file '" + file + "': " + ex);
                logger.Exception(LogLevel.Debug, ex);
            }

            retVal.LogResult(logger.Trace);
            logger.ExitMethod(retVal.ResultCode);
            return retVal;
        }

        /// <summary>
        ///     Writes the contents of the specified string array into the specified file. If the destination file already exists
        ///     it is overwritten.
        /// </summary>
        /// <param name="file">The file to which the specified contents are written.</param>
        /// <param name="contents">The string array containing the content to write.</param>
        /// <returns>The fully qualified name of the written file.</returns>
        public virtual Result<string> WriteFileLines(string file, string[] contents)
        {
            logger.EnterMethod(xLogger.Params(file, contents));
            logger.Trace("Writing to file '" + file + "'...");

            Result<string> retVal = new Result<string>();

            try
            {
                File.WriteAllLines(file, contents);
                retVal.ReturnValue = file;
            }
            catch (Exception ex)
            {
                retVal.AddError("Error writing to file '" + file + "': " + ex);
                logger.Exception(LogLevel.Debug, ex);
            }

            retVal.LogResult(logger.Trace);
            logger.ExitMethod(retVal.ResultCode);
            return retVal;
        }

        #endregion Public Methods
    }
}