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
        /// 
        private static PlatformManager instance;

        #endregion

        #region Properties

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

        /// <summary>
        /// Starts the Platform manager.
        /// </summary>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        public OperationResult Start()
        {
            //-------- --
            // determine the platform and instantiate it
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
            //------------------- - -     -

            
            //-------- - - - -- - - 
            // Populate the ProgramDirectories list
            logger.Debug("Loading application directories...");

            // fetch the directory list from .exe.config
            string directoryList = Utility.GetSetting("Directories");
            if (directoryList == "")
                throw new Exception("The directory list couldn't be loaded from the .exe.config file.");

            //  replace the pipe character placeholder with the platform specific directory separator
            directoryList = directoryList.Replace('|', System.IO.Path.DirectorySeparatorChar);
            
            OperationResult<PlatformDirectories> loadDirectoryResult = PlatformDirectories.LoadDirectories(directoryList);

            if (loadDirectoryResult.ResultCode == OperationResultCode.Failure)
                throw new Exception("Failed to load application directory list: " + loadDirectoryResult.GetLastError());

            Directories = loadDirectoryResult.Result;
            loadDirectoryResult.LogResultDebug(logger, "LoadDirectories");

            retVal.Incorporate(loadDirectoryResult);
            //------------------------------------ - - 


            //-------------------------- - - -               -  
            // Check to ensure all directories exist.  If not, create them.
            logger.Debug("Checking directories...");
            OperationResult checkResult = Directories.CheckDirectories();
            if (checkResult.ResultCode == OperationResultCode.Failure)
                throw new Exception("Failed to verify and/or create one or more required program directory: " + checkResult.GetLastError());

            checkResult.LogResultDebug(logger, "CheckDirectories");

            retVal.Incorporate(checkResult);
            //------------- - - -


            retVal.LogResult(logger);
            return new OperationResult();
        }

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

        #endregion
    }
}
