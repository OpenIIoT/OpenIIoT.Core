using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Linq;
using NLog;
using Symbiote.Core.Plugin;
using Symbiote.Core.Plugin.Connector;
using System.Text;
using System.Text.RegularExpressions;
using System.IO.Compression;

namespace Symbiote.Core.Platform.UNIX
{
    /// <summary>
    /// The Windows class implements the platform interfaces necessary to run the application on the Windows platform.
    /// </summary>
    /// <remarks>
    /// Some wierdness in the C# compiler won't allow implicitly defined interface properties if the property is less
    /// accessible than public.  For whatever reason the properties can be public but the class can be internal.
    /// The effective accessibility for these classes and all of their members is internal.
    /// </remarks>
    [System.Runtime.CompilerServices.CompilerGenerated]
    public class NamespaceDoc { }

    internal class UNIXPlatform : IPlatform
    {
        #region Variables

        /// <summary>
        /// The Logger for this class.
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        #endregion

        public Core.Platform.PlatformType PlatformType { get; private set; }
        public string Version { get; private set; }
        public IConnector Connector { get; private set; }

        public UNIXPlatform()
        {
            PlatformType = Core.Platform.PlatformType.UNIX;
            Version = Environment.OSVersion.VersionString;
        }

        public IConnector InstantiateConnector(string rootPath)
        {
            Connector = new PlatformConnector(rootPath);
            return Connector;
        }

        /// <summary>
        /// Returns a list of subdirectories within the supplied path.
        /// </summary>
        /// <param name="root">The parent directory to search.</param>
        /// <returns>A list containing the fully qualified path of each directory found.</returns>
        public OperationResult<List<string>> GetDirectoryList(string root)
        {
            OperationResult<List<string>> retVal = new OperationResult<List<string>>();
            retVal.Result = new List<string>();
            try
            {
                retVal.Result = Directory.EnumerateDirectories(root).ToList<string>();
            }
            catch (IOException ex)
            {
                retVal.AddError("Error listing directories for rooth path '" + root + "': " + ex.Message);
            }
            return retVal;
        }

        /// <summary>
        /// Returns a list of files within the supplied directory matching the supplied searchPattern.
        /// </summary>
        /// <param name="directory">The directory to search.</param>
        /// <param name="searchPattern">The search pattern to match files against.</param>
        /// <returns>A list containing the fully qualified filename of each file found.</returns>
        public OperationResult<List<string>> GetFileList(string directory, string searchPattern)
        {
            OperationResult<List<string>> retVal = new OperationResult<List<string>>();
            retVal.Result = new List<string>();
            try
            {
                retVal.Result = Directory.EnumerateFiles(directory, searchPattern, SearchOption.AllDirectories).ToList<string>();
            }
            catch (IOException ex)
            {
                logger.Error(ex, "Error listing files for directory '" + directory + "' using search pattern '" + searchPattern);
                retVal.AddError("Error listing files for directory '" + directory + "' using search pattern '" + searchPattern + " : " + ex.Message);
            }
            return retVal;
        }

        public List<string> GetZipFileList(string zipFile, string searchPattern)
        {
            List<string> retVal = new List<string>();
            Regex regex = new Regex(Utility.WildcardToRegex(searchPattern), RegexOptions.IgnoreCase);

            using (ZipArchive archive = ZipFile.OpenRead(zipFile))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (regex.IsMatch(entry.Name))
                        retVal.Add(entry.Name);
                }
            }
            return retVal;
        }

        public bool ExtractZip(string zipFile, string destination, bool clearDestination = true)
        {
            if (clearDestination)
            {
                if (!ClearDirectory(destination))
                    return false;
            }

            ZipFile.ExtractToDirectory(zipFile, destination);
            return true;
        }

        public string ExtractFileFromZip(string zipFile, string file, string destination, bool overwrite = true)
        {

            using (ZipArchive archive = ZipFile.Open(zipFile, ZipArchiveMode.Update))
            {
                ZipArchiveEntry entry = archive.GetEntry(file);

                string extractedFile = Path.Combine(destination, entry.Name);

                entry.ExtractToFile(extractedFile, overwrite);
                return extractedFile;
            }
        }

        public bool DeleteDirectory(string directory)
        {
            DirectoryInfo di = new DirectoryInfo(directory);
            di.Delete(true);
            return true;
        }
        public bool ClearDirectory(string directory)
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
            return true;
        }

        public string CreateDirectory(string directory)
        {
            return Directory.CreateDirectory(directory).FullName;
        }

        public bool DirectoryExists(string directory)
        {
            return Directory.Exists(directory);
        }


        public string ReadFile(string fileName)
        {
            return File.ReadAllText(fileName);
        }

        public string[] ReadAllLinesFromFile(string fileName)
        {
            return File.ReadAllLines(fileName);
        }

        public void WriteFile(string fileName, string contents)
        {
            File.WriteAllText(fileName, contents);
        }

        public string GetApplicationDirectory()
        {
            return Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }

        public string GetLogFile(string logDirectory)
        {
            return new DirectoryInfo(logDirectory).GetFiles().OrderByDescending(f => f.LastWriteTime).First().ToString();
        }

        public string ComputeFileChecksum(string fileName)
        {
            byte[] file = File.ReadAllBytes(fileName);
            byte[] checksum = MD5.Create().ComputeHash(file);

            StringBuilder retVal = new StringBuilder();
            foreach (byte b in checksum)
            {
                retVal.Append(b.ToString("x2"));
            }

            return retVal.ToString();
        }
    }
}
