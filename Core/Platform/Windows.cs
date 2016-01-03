using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using NLog;
using Symbiote.Core.Plugin;

/// <summary>
/// The Windows class implements the platform interfaces necessary to run the application on the Windows platform.
/// </summary>
/// <remarks>
/// Some wierdness in the C# compiler won't allow implicitly defined interface properties if the property is less
/// accessible than public.  For whatever reason the properties can be public but the class can be internal.
/// The effective accessibility for these classes and all of their members is internal.
/// </remarks>
namespace Symbiote.Core.Platform
{
    internal class Windows : IPlatform
    {
        private static Logger logger;

        public Platform.PlatformType PlatformType { get; private set; }
        public string Version { get; private set; }
        public IConnector Connector { get; private set; }

        internal Windows()
        {
            logger = LogManager.GetCurrentClassLogger();

            PlatformType = Platform.PlatformType.Windows;
            Version = Environment.OSVersion.VersionString;
            Connector = new WindowsConnector("System.Platform");
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
    }
}
