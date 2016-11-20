/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀ 
      █   
      █      ▄███████▄                                                                         ▄▄▄▄███▄▄▄▄                                                             
      █     ███    ███                                                                       ▄██▀▀▀███▀▀▀██▄                                                           
      █     ███    ███  █         ▄█████      ██       ▄█████  ██████     █████    ▄▄██▄▄▄   ███   ███   ███   ▄█████  ██▄▄▄▄    ▄█████     ▄████▄     ▄█████    █████ 
      █     ███    ███ ██         ██   ██ ▀███████▄   ██   ▀█ ██    ██   ██  ██  ▄█▀▀██▀▀█▄  ███   ███   ███   ██   ██ ██▀▀▀█▄   ██   ██   ██    ▀    ██   █    ██  ██ 
      █   ▀█████████▀  ██         ██   ██     ██  ▀  ▄██▄▄    ██    ██  ▄██▄▄█▀  ██  ██  ██  ███   ███   ███   ██   ██ ██   ██   ██   ██  ▄██        ▄██▄▄     ▄██▄▄█▀ 
      █     ███        ██       ▀████████     ██    ▀▀██▀▀    ██    ██ ▀███████  ██  ██  ██  ███   ███   ███ ▀████████ ██   ██ ▀████████ ▀▀██ ███▄  ▀▀██▀▀    ▀███████ 
      █     ███        ██▌    ▄   ██   ██     ██      ██      ██    ██   ██  ██  ██  ██  ██  ███   ███   ███   ██   ██ ██   ██   ██   ██   ██    ██   ██   █    ██  ██ 
      █    ▄████▀      ████▄▄██   ██   █▀    ▄██▀     ██       ██████    ██  ██   █  ██  █    ▀█   ███   █▀    ██   █▀  █   █    ██   █▀   ██████▀    ███████   ██  ██ 
      █   
 ▄ ▄▄ █ ▄▄▄▄▄▄▄▄▄  ▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄ 
 █ ██ █ █████████  ████ ██████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █ 
      █  
      █  The Platform namespace abstracts the platform on which the app runs.
      █  
      █  The PlatformManager class manages the application platform, specifically, the platform-dependent elements of the system.
      █  
      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██ 
                                                                                                   ██ 
                                                                                               ▀█▄ ██ ▄█▀ 
                                                                                                 ▀████▀   
                                                                                                   ▀▀                            */
using System;
using System.Collections.Generic;
using NLog;
using NLog.xLogger;
using Utility.OperationResult;
using Symbiote.Core.SDK;

namespace Symbiote.Core.Platform
{
    /// <summary>
    /// The Platform namespace abstracts the platform on which the app runs.
    /// </summary>
    /// <remarks>
    /// <para>
    ///     The primary purposes are to assist the application in determining the current platform (e.g. Windows or UNIX) and to
    ///     allow for platform dependent code such as file IO to be substituted at run time. This allows for a single project that can 
    ///     be compiled and run on both Windows and UNIX systems with no programatic changes.
    /// </para>
    /// <para>
    ///     Each Platform type gets a folder (e.g. UNIX, Windows) and within that folder a derivation of Platform named as "PlatformPlatform"
    ///     where the first "Platform" is the name.  Each Platform type is required to provide an implementation of IConnector for the platform which
    ///     returns statistical information about the hardware and OS hosting the application.  Of primary concern is CPU, Memory and Hard Disk usage.
    /// </para>
    /// <para>
    ///     Finally, the Platform Manager and PlatformDirectories class work together to ensure that the necessary directories are present in the 
    ///     configured locations.  If any directories are missing they are recreated at startup.  The app.exe.config file contains the definition
    ///     for these directories.  If the configuration file is missing any or all of the programatically defined directories an exception will be
    ///     thrown by the constructor of PlatformDirectories, causing the initialization of the application to fail.
    /// </para>
    /// </remarks>
    [System.Runtime.CompilerServices.CompilerGenerated]
    class NamespaceDoc { }

    /// <summary>
    /// The PlatformManager class manages the application platform, specifically, the platform-dependent elements of the system.
    /// </summary>
    public class PlatformManager : Manager, IStateful, IManager, IPlatformManager
    {
        #region Variables

        /// <summary>
        /// The Logger for this class.
        /// </summary>
        new private static xLogger logger = (xLogger)LogManager.GetCurrentClassLogger(typeof(xLogger));

        /// <summary>
        /// The Singleton instance of PlatformManager.
        /// </summary>
        private static PlatformManager instance;

        #endregion

        #region Properties

        #region IPlatformManager Properties

        /// <summary>
        /// The current platform.
        /// </summary>
        public IPlatform Platform { get; private set; }

        /// <summary>
        /// A Dictionary containing all of the application directories, loaded from the App.config.
        /// </summary>
        public PlatformDirectories Directories { get; private set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Private constructor, only called by Instance()
        /// </summary>
        /// <param name="manager">The ApplicationManager instance for the application.</param>
        private PlatformManager(IApplicationManager manager)
        {
            base.logger = logger;
            Guid guid = logger.EnterMethod();

            ManagerName = "Platform Manager";

            // register dependencies
            RegisterDependency<IApplicationManager>(manager);

            ChangeState(State.Initialized);

            logger.ExitMethod();
        }

        /// <summary>
        /// Instantiates and/or returns the PlatformManager instance.
        /// </summary>
        /// <remarks>
        /// Invoked via reflection from ApplicationManager.  The parameters are used to build an array of IManager parameters which are then passed
        /// to this method.  To specify additional dependencies simply insert them into the parameter list for the method and they will be 
        /// injected when the method is invoked.
        /// </remarks>
        /// <param name="manager">The ApplicationManager instance for the application.</param>
        /// <returns>The Singleton instance of PlatformManager.</returns>
        private static PlatformManager Instantiate(IApplicationManager manager)
        {
            if (instance == null)
                instance = new PlatformManager(manager);
           
            return instance;
        }

        #endregion

        #region Instance Methods

        protected override Result Startup()
        {
            Guid guid = logger.EnterMethod(true);
            logger.Debug("Performing Startup for '" + GetType().Name + "'...");
            Result retVal = new Result();

            #region Platform Instantiation

            //-------- --
            // determine the platform and instantiate it
            switch (GetPlatformType())
            {
                case PlatformType.Windows:
                    Platform = new Windows.WindowsPlatform();
                    break;
                case PlatformType.UNIX:
                    Platform = new UNIX.UNIXPlatform();
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

            Result<PlatformDirectories> loadDirectoryResult = PlatformDirectories.LoadDirectories(directoryList);

            if (loadDirectoryResult.ResultCode == ResultCode.Failure)
                throw new Exception("Failed to load application directory list: " + loadDirectoryResult.GetLastError());

            Directories = loadDirectoryResult.ReturnValue;
            loadDirectoryResult.LogResult(logger.Debug, "LoadDirectories");

            retVal.Incorporate(loadDirectoryResult);

            logger.Checkpoint("Directory configuration loaded", guid);
            //------------------------------------ - - 

            #endregion

            #region Directory Validation

            //-------------------------- - - -               -  
            // Check to ensure all directories exist.  If not, create them.
            logger.Debug("Checking directories...");
            Result checkResult = Directories.CheckDirectories();
            if (checkResult.ResultCode == ResultCode.Failure)
                throw new Exception("Failed to verify and/or create one or more required program directory: " + checkResult.GetLastError());

            checkResult.LogResult(logger.Debug, "CheckDirectories");

            retVal.Incorporate(checkResult);

            logger.Checkpoint("Directories validated", guid);
            //------------- - - -

            #endregion

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        protected override Result Shutdown(StopType stopType = StopType.Stop)
        {
            Guid guid = logger.EnterMethod(true);
            logger.Debug("Performing Shutdown for '" + GetType().Name + "'...");
            Result retVal = new Result();

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        #endregion

        #region Static Methods

        /// <summary>
        /// Evaluates Environment.OSVersion.Platform to determine the current platform.
        /// </summary>
        /// <returns>A PlatformType enumeration corresponding to the current platform.</returns>
        public static PlatformType GetPlatformType()
        {
            int p = (int)Environment.OSVersion.Platform;
            return ((p == 4) || (p == 6) || (p == 128) ? PlatformType.UNIX : PlatformType.Windows);
        }

        /// <summary>
        /// Retrieves the "Directories" setting from the app.config file, or the default value if the retrieval fails.
        /// </summary>
        /// <returns>The list of program directories.</returns>
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
