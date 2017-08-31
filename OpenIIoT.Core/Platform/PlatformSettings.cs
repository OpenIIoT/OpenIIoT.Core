using OpenIIoT.Core.Common;

namespace OpenIIoT.Core.Platform
{
    public class PlatformSettings : Settings
    {
        #region Public Properties

        /// <summary>
        ///     Gets the value of the 'Directory.Data' key from the application's XML configuration file.
        /// </summary>
        public virtual string DirectoryData => GetSetting<string>("Directory.Data", "Data");

        /// <summary>
        ///     Gets the value of the 'Directory.Log' key from the application's XML configuration file.
        /// </summary>
        public virtual string DirectoryLogs => GetSetting<string>("Directory.Logs", @"Data\Logs");

        /// <summary>
        ///     Gets the value of the 'Directory.Packages' key from the application's XML configuration file.
        /// </summary>
        public virtual string DirectoryPackages => GetSetting<string>("Directory.Packages", @"Data\Packages");

        /// <summary>
        ///     Gets the value of the 'Directory.Persistence' key from the application's XML configuration file.
        /// </summary>
        public virtual string DirectoryPersistence => GetSetting<string>("Directory.Persistence", @"Data\Persistence");

        /// <summary>
        ///     Gets the value of the 'Directory.Plugins' key from the application's XML configuration file.
        /// </summary>
        public virtual string DirectoryPlugins => GetSetting<string>("Directory.Plugins", "Plugins");

        /// <summary>
        ///     Gets the value of the 'Directory.Temp' key from the application's XML configuration file.
        /// </summary>
        public virtual string DirectoryTemp => GetSetting<string>("Directory.Temp", @"Data\Temp");

        /// <summary>
        ///     Gets the value of the 'Directory.Web' key from the application's XML configuration file.
        /// </summary>
        public virtual string DirectoryWeb => GetSetting<string>("Directory.Web", "Web");

        #endregion Public Properties
    }
}