using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core
{
    /// <summary>
    /// Encapsulates various internal applications settings.
    /// </summary>
    public class InternalSettings
    {
        /// <summary>
        /// The name of the product.
        /// </summary>
        public string ProductName { get; private set; }

        /// <summary>
        /// The root directory for the application.
        /// </summary>
        public string RootDirectory { get; private set; }

        /// <summary>
        /// The directory (relative to the application root) where data is stored.
        /// </summary>
        public string DataDirectory { get; private set; }

        /// <summary>
        /// The directory (relative to the data root) where app archives are stored.
        /// </summary>
        public string AppDirectory { get; private set; }

        /// <summary>
        /// The directory (relative to the data root) where plugin archvies are stored.
        /// </summary>
        public string PluginDirectory { get; private set; }

        /// <summary>
        /// The directory (relative to the data root) where temporary data is stored.
        /// </summary>
        public string TempDirectory { get; private set; }

        /// <summary>
        /// The directory (relative to the application root) where static web content is stored.
        /// </summary>
        public string WebDirectory { get; private set; }

        /// <summary>
        /// The directory (relative to the application root) where logs are stored.
        /// </summary>
        public string LogDirectory { get; private set; }

        /// <summary>
        /// The file extension for apps archives.
        /// </summary>
        public string AppExtension { get; private set; }

        /// <summary>
        /// The name of the app configuration file stored within app archives.
        /// </summary>
        public string AppConfigurationFileName { get; private set; }

        /// <summary>
        /// The file extension for plugin archives.
        /// </summary>
        public string PluginExtension { get; private set; }

        /// <summary>
        /// Sets the ProductName property to the supplied value.
        /// </summary>
        /// <param name="name">The name of the product.</param>
        internal void SetProductName(string name)
        {
            ProductName = name;
        }

        /// <summary>
        /// Sets the RootDirectory property to the supplied value.
        /// </summary>
        /// <param name="directory">The root directory for the application.</param>
        internal void SetRootDirectory(string directory)
        {
            RootDirectory = directory;
        }

        /// <summary>
        /// Sets the DataDirectory property to the supplied value.
        /// </summary>
        /// <param name="directory">The directory (relative to the application root) where data is stored.</param>
        internal void SetDataDirectory(string directory)
        {
            DataDirectory = System.IO.Path.Combine(RootDirectory, directory);
        }

        /// <summary>
        /// Sets the AppDirectory property to the supplied value.
        /// </summary>
        /// <param name="directory">The directory (relative to the data root) where app archives are stored.</param>
        internal void SetAppDirectory(string directory)
        {
            AppDirectory = System.IO.Path.Combine(DataDirectory, directory);
        }

        /// <summary>
        /// Sets the PluginDirectory property to the supplied value.
        /// </summary>
        /// <param name="directory">The directory (relative to the data root) where plugin archives are stored.</param>
        internal void SetPluginDirectory(string directory)
        {
            PluginDirectory = System.IO.Path.Combine(DataDirectory, directory);
        }

        /// <summary>
        /// Sets the TempDirectory property to the supplied value.
        /// </summary>
        /// <param name="directory">The directory (relative to the data root) where temporary data is stored.</param>
        internal void SetTempDirectory(string directory)
        {
            TempDirectory = System.IO.Path.Combine(DataDirectory, directory);
        }

        /// <summary>
        /// Sets the WebDirectory property to the supplied value.
        /// </summary>
        /// <param name="directory">The directory (relative to the application root) where static web content is stored.</param>
        internal void SetWebDirectory(string directory)
        {
            WebDirectory = System.IO.Path.Combine(RootDirectory, directory);
        }

        /// <summary>
        /// Sets the LogDirectory property to the supplied value.
        /// </summary>
        /// <param name="directory">The directory (relative to the application root) where log files are stored.</param>
        internal void SetLogDirectory(string directory)
        {
            LogDirectory = System.IO.Path.Combine(RootDirectory, directory);
        }

        /// <summary>
        /// Sets the AppExtension property to the supplied value.
        /// </summary>
        /// <param name="extension">The desired extension for app archives.</param>
        internal void SetAppExtension(string extension)
        {
            AppExtension = extension;
        }

        /// <summary>
        /// Sets the AppConfigurationFileName property to the supplied value.
        /// </summary>
        /// <param name="fileName">The desired file name for app configuration files.</param>
        internal void SetAppConfigurationFileName(string fileName)
        {
            AppConfigurationFileName = fileName;
        }

        /// <summary>
        /// Sets the PluginExtension property to the supplied value.
        /// </summary>
        /// <param name="extension">The desired extension for plugin archives.</param>
        internal void SetPluginExtension(string extension)
        {
            PluginExtension = extension;
        }
    }
}
