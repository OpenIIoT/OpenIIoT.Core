using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Linq;
using NLog;
using Symbiote.Core.Plugin;
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
        private static Logger logger;

        public Core.Platform.PlatformType PlatformType { get; private set; }
        public string Version { get; private set; }
        public IConnector Connector { get; private set; }

        public UNIXPlatform()
        {
            logger = LogManager.GetCurrentClassLogger();

            PlatformType = Core.Platform.PlatformType.UNIX;
            Version = Environment.OSVersion.VersionString;
        }

        public IConnector InstantiateConnector(string rootPath)
        {
            Connector = new PlatformConnector(rootPath);
            return Connector;
        }

        public List<string> GetDirectoryList(string root)
        {
            List<string> list = new List<string>();
            try
            {
                list = Directory.EnumerateDirectories(root).ToList<string>();
            }
            catch (IOException ex)
            {
                logger.Error(ex, "Error listing directories for root path '" + root + "'");
            }
            return list;
        }

        public List<string> GetFileList(string root, string searchPattern)
        {
            List<string> list = new List<string>();
            try
            {
                list = Directory.EnumerateFiles(root, searchPattern).ToList<string>();
            }
            catch (IOException ex)
            {
                logger.Error(ex, "Error listing files for directory '" + root + "' using search pattern '" + searchPattern);
            }
            return list;
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

        public string ReadFile(string fileName)
        {
            return File.ReadAllText(fileName);
        }

        public void WriteFile(string fileName, string contents)
        {
            File.WriteAllText(fileName, contents);
        }

        public string GetApplicationDirectory()
        {
            return Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
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
