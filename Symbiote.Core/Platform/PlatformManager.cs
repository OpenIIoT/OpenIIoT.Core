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
using NLog;

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
    public class PlatformManager : IStateful, IManager, IPlatformManager
    {
        #region Variables

        /// <summary>
        /// The logger for this class.
        /// </summary>
        private static xLogger logger = (xLogger)LogManager.GetCurrentClassLogger(typeof(xLogger));

        /// <summary>
        /// The ProgramManager for the application.
        /// </summary>
        private IProgramManager manager;

        /// <summary>
        /// The Singleton instance of PlatformManager.
        /// </summary>
        private static PlatformManager instance;

        #endregion

        #region Properties

        #region IStateful Properties

        /// <summary>
        /// The state of the Manager.
        /// </summary>
        public State State { get; private set; }

        #endregion

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

        #region Events

        #region IStateful Events

        /// <summary>
        /// Occurs when the State property changes.
        /// </summary>
        public event EventHandler<StateChangedEventArgs> StateChanged;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Private constructor, only called by Instance()
        /// </summary>
        /// <param name="manager">The ProgramManager instance for the application.</param>
        private PlatformManager(IProgramManager manager)
        {
            this.manager = manager;

            ChangeState(State.Initialized);
        }

        /// <summary>
        /// Instantiates and/or returns the PlatformManager instance.
        /// </summary>
        /// <remarks>
        /// Invoked via reflection from ProgramManager.  The parameters are used to build an array of IManager parameters which are then passed
        /// to this method.  To specify additional dependencies simply insert them into the parameter list for the method and they will be 
        /// injected when the method is invoked.
        /// </remarks>
        /// <param name="manager">The ProgramManager instance for the application.</param>
        /// <returns>The Singleton instance of PlatformManager.</returns>
        private static PlatformManager Instantiate(IProgramManager manager)
        {
            if (instance == null)
                instance = new PlatformManager(manager);
           
            return instance;
        }

        #endregion

        #region Instance Methods

        #region IStateful Implementation

        /// <summary>
        /// Starts the Platform manager.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result Start()
        {
            Guid guid = logger.EnterMethod(true);
            Result retVal = new Result();

            logger.Info("Starting the Platform Manager...");

            ChangeState(State.Starting);

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
                throw new Exception("Failed to load application directory list: " + loadDirectoryResult.LastErrorMessage());

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
                throw new Exception("Failed to verify and/or create one or more required program directory: " + checkResult.LastErrorMessage());

            checkResult.LogResult(logger.Debug, "CheckDirectories");

            retVal.Incorporate(checkResult);

            logger.Checkpoint("Directories validated", guid);
            //------------- - - -

            #endregion

            if (retVal.ResultCode != ResultCode.Failure)
                ChangeState(State.Running);
            else
                ChangeState(State.Faulted, retVal.LastErrorMessage());

            retVal.LogResult(logger);

            logger.Info("The Platform Manager is now in the " + State + " state.");
            logger.Info("Platform: " + Platform.PlatformType.ToString() + " (" + Platform.Version + ")");

            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        /// <summary>
        /// Restarts the Platform manager.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result Restart(StopType stopType = StopType.Normal)
        {
            Guid guid = logger.EnterMethod(true);

            logger.Info("Restarting the Platform Manager...");
            Result retVal = new Result();

            retVal.Incorporate(Stop(stopType));
            retVal.Incorporate(Start());

            retVal.LogResult(logger);

            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        /// <summary>
        /// Stops the Platform manager.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result Stop(StopType stopType = StopType.Normal)
        {
            logger.EnterMethod();

            logger.Info("Stopping the Platform Manager...");
            Result retVal = new Result();

            ChangeState(State.Stopping);

            if (retVal.ResultCode != ResultCode.Failure)
                ChangeState(State.Stopped);
            else
                ChangeState(State.Faulted, retVal.LastErrorMessage());

            retVal.LogResult(logger);

            logger.Info("The Platform Manager is now " + State + ".");

            logger.ExitMethod(retVal);
            return retVal;
        }

        #endregion

        /// <summary>
        /// Changes the <see cref="State"/> of the Manager to the specified state and fires the StateChanged event.
        /// </summary>
        /// <param name="state">The State to which the State property should be changed.</param>
        /// <param name="message">The optional message describing the nature or reason for the change.</param>
        private void ChangeState(State state, string message = "")
        {
            State previousState = State;

            State = state;

            if (StateChanged != null)
                StateChanged(this, new StateChangedEventArgs(State, previousState, message));
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
