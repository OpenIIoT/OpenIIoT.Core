using System;
using NLog;

namespace Symbiote.Core.Platform
{
    /// <summary>
    /// The Platform namespace abstracts the platform on which the app runs.
    /// </summary>
    /// <remarks>
    /// The primary purposes are to assist the application in determining the run mode (e.g. interactive or Windows service) and to
    /// allow for platform dependent code such as file IO to be substituted at run time. This allows for a single project that can 
    /// be compiled and run on both Windows and UNIX systems with no programatic changes.
    /// </remarks>
    [System.Runtime.CompilerServices.CompilerGenerated]
    class NamespaceDoc { }

    /// <summary>
    /// The PlatformManager class manages the application platform, specifically, the platform-dependent elements of the system.
    /// </summary>
    public class PlatformManager : IManager
    {
        /// <summary>
        /// The ProgramManager for the application.
        /// </summary>
        private ProgramManager manager;
        
        /// <summary>
        /// The logger for this class.
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The Singleton instance of PlatformManager.
        /// </summary>
        private static PlatformManager instance;

        /// <summary>
        /// The current platform.
        /// </summary>
        public IPlatform Platform { get; private set; }

        /// <summary>
        /// Private constructor, only called by Instance()
        /// </summary>
        /// <param name="manager">The ProgramManager instance for the application.</param>
        private PlatformManager(ProgramManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Instantiates and/or returns the PlatformManager instance.
        /// </summary>
        /// <param name="manager">The ProgramManager instance for the application.</param>
        /// <returns>The Singleton instance of PlatformManager.</returns>
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
        public OperationResult Start()
        {
            logger.Info("Starting Platform Manager...");
            OperationResult retVal = new OperationResult();

            switch (GetPlatformType())
            {
                case PlatformType.Windows:
                    Platform = new Platform.Windows.WindowsPlatform();
                    break;
                case PlatformType.UNIX:
                    Platform = new Platform.UNIX.UNIXPlatform();
                    break;
                default:
                    throw new Exception("Unable to determine platform.  Environment.OSVersion.Platform: " + Environment.OSVersion.Platform.ToString());
            }
            retVal.LogResult(logger);
            return new OperationResult();
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
