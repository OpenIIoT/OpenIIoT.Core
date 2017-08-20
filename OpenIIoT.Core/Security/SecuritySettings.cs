namespace OpenIIoT.Core.Security
{
    public static class SecuritySettings
    {
        #region Public Properties

        /// <summary>
        ///     Gets the value of the 'DefaultUser' key from the application's XML configuration file.
        /// </summary>
        public static string DefaultUser => Utility.GetSetting<string>("DefaultUser", "admin");

        /// <summary>
        ///     Gets the value of the 'DefaultUserPasswordHash' key from the application's XML configuration file.
        /// </summary>
        public static string DefaultUserPasswordHash => Utility.GetSetting<string>("DefaultUserPasswordHash", "C7AD44CBAD762A5DA0A452F9E854FDC1E0E7A52A38015F23F3EAB1D80B931DD472634DFAC71CD34EBC35D16AB7FB8A90C81F975113D6C7538DC69DD8DE9077EC");

        /// <summary>
        ///     Gets the value of the 'SessionLength' key from the application's XML configuration file.
        /// </summary>
        public static int SessionLength => Utility.GetSetting<int>("SessionLength", "30");

        /// <summary>
        ///     Gets the value of the 'SessionPurgeInterval' key from the application's XML configuration file.
        /// </summary>
        public static int SessionPurgeInterval => Utility.GetSetting<int>("SessionPurgeInterval", "900000");

        /// <summary>
        ///     Gets a value indicating whether sliding sessions should be used from the application's XML configuration file.
        /// </summary>
        public static bool SlidingSessions => Utility.GetSetting<bool>("SlidingSessions", "true");

        #endregion Public Properties
    }
}