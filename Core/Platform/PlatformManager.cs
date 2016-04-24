using System;
using NLog;

namespace Symbiote.Core.Platform
{
    /// <summary>
    /// The Platform namespace abstracts the platform on which the app runs.
    /// 
    /// The primary purposes are to assist the application in determining the current platform (e.g. Windows or UNIX) and to
    /// allow for platform dependent code such as file IO to be substituted at run time. This allows for a single project that can 
    /// be compiled and run on both Windows and UNIX systems with no programatic changes.
    /// 
    /// Each Platform type gets a folder (e.g. UNIX, Windows) and within that folder an implementation of IPlatform named as "PlatformPlatform"
    /// where the first "Platform" is the name.  Each Platform type is required to provide an implementation of IConnector for the platform which
    /// returns statistical information about the hardware and OS hosting the application.  Of primary concern is CPU, Memory and Hard Disk usage.
    /// 
    /// Finally, the Platform Manager and PlatformDirectories class work together to ensure that the necessary directories are present in the 
    /// configured locations.  If any directories are missing they are recreated at startup.  The app.exe.config file contains the definition
    /// for these directories.  If the configuration file is missing any or all of the programatically defined directories an exception will be
    /// thrown by the constructor of PlatformDirectories, causing the initialization of the application to fail.
    /// </summary>
    [System.Runtime.CompilerServices.CompilerGenerated]
    class NamespaceDoc { }

    /// <summary>
    /// The PlatformManager class manages the application platform, specifically, the platform-dependent elements of the system.
    /// </summary>
    public class PlatformManager : IManager
    {
        #region Variables

        /// <summary>
        /// The logger for this class.
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The ProgramManager for the application.
        /// </summary>
        private ProgramManager manager;

        /// <summary>
        /// The Singleton instance of PlatformManager.
        /// </summary>
        private static PlatformManager instance;

        #endregion

        #region Properties

        /// <summary>
        /// The state of the Manager.
        /// </summary>
        public bool Running { get; private set; }

        /// <summary>
        /// The current platform.
        /// </summary>
        public IPlatform Platform { get; private set; }

        /// <summary>
        /// A Dictionary containing all of the application directories, loaded from the App.config.
        /// </summary>
        public PlatformDirectories Directories { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Private constructor, only called by Instance()
        /// </summary>
        /// <param name="manager">The ProgramManager instance for the application.</param>
        private PlatformManager(ProgramManager manager)
        {
            this.manager = manager;
            Running = false;
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

        #endregion

        #region Instance Methods

        #region IManager Implementation

        /// <summary>
        /// Starts the Platform manager.
        /// </summary>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        public OperationResult Start()
        {
            Guid guid = MethodLogger.Enter(logger, true);
            OperationResult retVal = new OperationResult();

            logger.Info("Starting the Platform Manager...");

            #region Platform Instantiation

            //-------- --
            // determine the platform and instantiate it
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
            //------------------- - -     -

            #endregion

            #region Directory Configuration Loading

            //-------- - - - -- - - 
            // Populate the ProgramDirectories list
            logger.Debug("Loading application directories...");

            // fetch the directory list from .exe.config
            string directoryList = GetDirectories();

            //  replace the pipe character placeholder with the platform specific directory separator
            directoryList = directoryList.Replace('|', System.IO.Path.DirectorySeparatorChar);
            
            OperationResult<PlatformDirectories> loadDirectoryResult = PlatformDirectories.LoadDirectories(directoryList);

            if (loadDirectoryResult.ResultCode == OperationResultCode.Failure)
                throw new Exception("Failed to load application directory list: " + loadDirectoryResult.GetLastError());

            Directories = loadDirectoryResult.Result;
            loadDirectoryResult.LogResultDebug(logger, "LoadDirectories");

            retVal.Incorporate(loadDirectoryResult);
            //------------------------------------ - - 

            #endregion

            #region Directory Validation

            //-------------------------- - - -               -  
            // Check to ensure all directories exist.  If not, create them.
            logger.Debug("Checking directories...");
            OperationResult checkResult = Directories.CheckDirectories();
            if (checkResult.ResultCode == OperationResultCode.Failure)
                throw new Exception("Failed to verify and/or create one or more required program directory: " + checkResult.GetLastError());

            checkResult.LogResultDebug(logger, "CheckDirectories");

            retVal.Incorporate(checkResult);
            //------------- - - -

            #endregion

            Running = (retVal.ResultCode != OperationResultCode.Failure);

            retVal.LogResult(logger);
            MethodLogger.Exit(logger, guid);
            return retVal;
        }

        /// <summary>
        /// Restarts the Platform manager.
        /// </summary>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        public OperationResult Restart()
        {
            Guid guid = MethodLogger.Enter(logger, true);

            logger.Info("Restarting the Platform Manager...");
            OperationResult retVal = new OperationResult();

            retVal.Incorporate(Stop());
            retVal.Incorporate(Start());

            retVal.LogResult(logger);
            MethodLogger.Exit(logger, guid);
            return retVal;
        }

        /// <summary>
        /// Stops the Platform manager.
        /// </summary>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        public OperationResult Stop()
        {
            MethodLogger.Enter(logger);

            logger.Info("Stopping the Platform Manager...");
            OperationResult retVal = new OperationResult();

            Running = false;

            retVal.LogResult(logger);
            MethodLogger.Exit(logger);
            return retVal;
        }

        #endregion

        #endregion

        #region Static Methods

        /// <summary>
        /// Evaluates Environment.OSVersion.Platform to determine the current platform.
        /// </summary>
        /// <returns>A PlatformType enumeration corresponding to the current platform.</returns>
        private static PlatformType GetPlatformType()
        {
            int p = (int)Environment.OSVersion.Platform;
            return ((p == 4) || (p == 6) || (p == 128) ? PlatformType.UNIX : PlatformType.Windows);
        }

        private static string GetDirectories()
        {
            return Utility.GetSetting(
                "Directories",
                @"{
                      &quot;Data&quot;:&quot;Data&quot;,
                      &quot;Archives&quot;:&quot;Data\|Archives&quot;,
                      &quot;Plugins&quot;:&quot;Plugins&quot;,
                      &quot;Temp&quot;:&quot;Data\|Temp&quot;,
		              &quot;Persistence&quot;:&quot;Data\|Persistence&quot;,
                      &quot;Web&quot;:&quot;Web&quot;,
                      &quot;Logs&quot;:&quot;Logs&quot;
                 }"
            );
        }

        #endregion
    }
}
