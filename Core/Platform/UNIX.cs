using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Linq;
using NLog;
using Symbiote.Core.Plugin;
using System.Text;

namespace Symbiote.Core.Platform
{
    public class UNIX : IPlatform
    {
        private static Logger logger;

        public Platform.PlatformType PlatformType { get; private set; }
        public string Version { get; private set; }
        public IConnector Connector { get; private set; }

        public UNIX()
        {
            PlatformType = Platform.PlatformType.UNIX;
            Version = Environment.OSVersion.VersionString;
        }

        public List<string> GetDirectoryList(string root)
        {
            List<string> list = new List<string>();
            try
            {
                foreach (string s in Directory.GetDirectories(root))
                {
                    list.Add(s);
                }
            }
            catch (IOException ex)
            {
                //logger.Error(ex, "Error listing directories for root path '" + root + "'");
            }

            return list;
        }

        public List<string> GetFileList(string root, string searchPattern)
        {
            List<string> list = new List<string>();
            try
            {
                foreach (string s in Directory.GetFiles(root, searchPattern))
                {
                    list.Add(s);
                }
            }
            catch (IOException ex)
            {
                //logger.Error(ex, "Error listing files for directory '" + root + "' using search pattern '" + searchPattern);
            }

            return list;
        }

        public string ReadFile(string fileName)
        {
            try
            {
                return File.ReadAllText(fileName);
            }
            catch (IOException ex)
            {
                logger.Error(ex, "Error reading contents of file '" + fileName + "'.");
                return "";
            }
        }

        public void WriteFile(string fileName, string contents)
        {
            try
            {
                File.WriteAllText(fileName, contents);
            }
            catch (IOException ex)
            {
                logger.Error(ex, "Error writing to file '" + fileName + "'.");
            }
        }

        public string ComputeFileChecksum(string fileName)
        {
            FileStream fileStream = File.OpenRead(fileName);
            MD5 hash = MD5.Create();
            byte[] checksum = hash.ComputeHash(fileStream);
            return Encoding.Default.GetString(checksum);
        }
    }
}