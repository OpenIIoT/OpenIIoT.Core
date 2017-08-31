using OpenIIoT.Core.Common;

namespace OpenIIoT.Core.Configuration
{
    public class ConfigurationSettings : Settings
    {
        #region Public Properties

        /// <summary>
        ///     Gets the value of the 'Configuration.Filename' key from the application's XML configuration file.
        /// </summary>
        public virtual string ConfigurationFilename => GetSetting<string>("Configuration.Filename", "OpenIIoT.json");

        #endregion Public Properties
    }
}