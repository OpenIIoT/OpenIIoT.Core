using System;
using NLog;

namespace Symbiote.Core.Platform
{
    /// <summary>
    /// The PlatformManager class manages the application platform, specifically, the platform-dependent elements of the system.
    /// </summary>
    /// <remarks>
    /// This class is implemented using the Singleton and Factory design patterns.
    /// </remarks>
    internal class PlatformManager
    {
        private ProgramManager manager;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static PlatformManager instance;

        /// <summary>
        /// The current platform.
        /// </summary>
        internal IPlatform Platform { get; private set; }

        /// <summary>
        /// Private constructor, only called by Instance()
        /// </summary>
        private PlatformManager(ProgramManager manager)
        {
            this.manager = manager;
            Platform = InstantiatePlatform();
        }

        /// <summary>
        /// Instantiates and/or returns the PlatformManager instance.
        /// </summary>
        /// <returns></returns>
        internal static PlatformManager Instance(ProgramManager manager)
        {
            if (instance == null)
                instance = new PlatformManager(manager);
           
            return instance;
        }

        /// <summary>
        /// Creates and returns the instance of IPlatform to be used by the application.
        /// </summary>
        /// <returns>An IPlatform corresponding to the current platform.</returns>
        private IPlatform InstantiatePlatform()
        {
            switch (GetPlatformType())
            {
                case PlatformType.Windows:
                    return new Platform.Windows();
                case PlatformType.UNIX:
                    return new Platform.UNIX();
                default:
                    throw new Exception("Unable to determine platform.  Environment.OSVersion.Platform: " + Environment.OSVersion.Platform.ToString());
            }
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
}
