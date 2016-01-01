using System;
using NLog;

namespace Symbiote.Core.Platform
{
    /// <summary>
    /// The PlatformManager class manages the application platform, specifically, the platform-dependent elements of the system.
    /// </summary>
    /// <remarks>
    /// This class is implemented using the Singleton design pattern.
    /// </remarks>
    public class PlatformManager
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static PlatformManager instance;

        /// <summary>
        /// The current platform.
        /// </summary>
        public IPlatform Platform { get; private set; }

        /// <summary>
        /// Private constructor, only called by Instance()
        /// </summary>
        private PlatformManager() { }

        /// <summary>
        /// Creates and returns the instance of IPlatform to be used by the application.
        /// </summary>
        /// <returns>An IPlatform corresponding to the current platform.</returns>
        public IPlatform InstantiatePlatform()
        {
            try
            {
                switch (GetPlatformType())
                {
                    case PlatformType.Windows:
                        Platform = new Platform.Windows();
                        break;
                    case PlatformType.UNIX:
                        Platform = new Platform.UNIX();
                        break;
                    default:
                        throw new Exception("Unable to determine platform.  Environment.OSVersion.Platform: " + Environment.OSVersion.Platform.ToString());
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Platform;
        }

        /// <summary>
        /// Instantiates and/or returns the PlatformManager instance.
        /// </summary>
        /// <returns></returns>
        public static PlatformManager Instance()
        {
            if (instance != null)
                instance = new PlatformManager();
           
            return new PlatformManager();
        }

        /// <summary>
        /// Evaluates Environment.OSVersion.Platform to determine the current platform.
        /// </summary>
        /// <returns>A PlatformType enumeration corresponding to the current platform.</returns>
        private static PlatformType GetPlatformType()
        {
            int p = (int)Environment.OSVersion.Platform;
            return ((p == 4) || (p == 6) || (p == 128) ? PlatformType.UNIX : PlatformType.Windows);
        }
    }

    /// <summary>
    /// Enumeration of the different platform types.
    /// </summary>
    public enum PlatformType { Windows, UNIX }

    /// <summary>
    /// Enumeration of the different types of drive.
    /// </summary>
    public enum DriveType { Fixed, CDROM, Removable }

    /// <summary>
    /// Enumeration of the different types of network adapters.
    /// </summary>
    public enum NetworkAdapterType { Ethernet, Wireless }
}
