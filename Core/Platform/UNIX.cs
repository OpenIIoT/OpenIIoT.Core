using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symbiote.Core.Plugin;

namespace Symbiote.Core.Platform
{
    public class UNIX : IPlatform
    {
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
    }
}