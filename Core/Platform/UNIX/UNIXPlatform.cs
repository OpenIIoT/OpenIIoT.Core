using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Linq;
using NLog;
using Symbiote.Core.Plugin;
using System.Text;


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

        public string ReadFile(string fileName)
        {
            return File.ReadAllText(fileName);
        }

        public void WriteFile(string fileName, string contents)
        {
            File.WriteAllText(fileName, contents);
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
