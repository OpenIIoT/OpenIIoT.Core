using System;
using NLog;
using Newtonsoft.Json;
using System.Collections.Generic;

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

            //-------- - - - -- - - 
            // Populate the ProgramDirectories list
            logger.Debug("Loading application directories...");
            OperationResult<PlatformDirectories> loadDirectoryResult = LoadDirectories();
            if (loadDirectoryResult.ResultCode == OperationResultCode.Failure)
                throw new Exception("Failed to load application directory list." + retVal.GetLastError());
            Directories = loadDirectoryResult.Result;
            loadDirectoryResult.LogResult(logger, "Debug", "Warn", "Error", "LoadDirectories");

            // copy any warnings to the overall return value
            foreach (OperationResultMessage message in loadDirectoryResult.Messages)
            {
                if (message.Type == OperationResultMessageType.Warning)
                    retVal.AddWarning(message.Message);
            }
            //------------------------------------ - - 


            //-------------------------- - - -               -  
            // Check to ensure all directories exist.  If not, create them.
            logger.Debug("Checking directories...");
            OperationResult checkResult = Directories.CheckDirectories();
            if (checkResult.ResultCode == OperationResultCode.Failure)
                throw new Exception("Failed to verify and/or create one or more required program directory: " + retVal.GetLastError());
            checkResult.LogResult(logger, "Debug", "Warn", "Error", "CheckDirectories");

            // copy any warnings to the overall return value
            foreach (OperationResultMessage message in loadDirectoryResult.Messages)
            {
                if (message.Type == OperationResultMessageType.Warning)
                    retVal.AddWarning(message.Message);
            }
            //------------- - - -


            retVal.LogResult(logger);
            return new OperationResult();
        }

        #region Instance Methods

        /// <summary>
        /// Loads the list of directories from the configuration.exe file
        /// </summary>
        /// <returns>An OperationResult containing the result of the operation along with a ProgramDirectories instance containing the directories.</returns>
        private OperationResult<PlatformDirectories> LoadDirectories()
        {
            logger.Trace("Loading directory list from the configuration file...");
            OperationResult<PlatformDirectories> retVal;
            string configDirectories = Utility.GetSetting("Directories");

            if (configDirectories != "")
            {
                retVal = LoadDirectories(configDirectories);
                if (retVal.ResultCode != OperationResultCode.Failure)
                    Directories = retVal.Result;
            }
            else
                retVal = new OperationResult<PlatformDirectories>().AddError("The list of directories is missing from the configuration file.");

            retVal.LogResult(logger, "Trace");
            return retVal;
        }

        /// <summary>
        /// Deserializes the provided string to a dictionary containing the program directory names and paths, then creates
        /// an instance of ProgramDirectories with it.
        /// </summary>
        /// <param name="directories">A serialized dictionary containing the program directories and their paths.</param>
        /// <returns>An OperationResult containing the result of the operation along with a ProgramDirectories instance containing the directories.</returns>
        private OperationResult<PlatformDirectories> LoadDirectories(string directories)
        {
            OperationResult<PlatformDirectories> retVal = new OperationResult<PlatformDirectories>();

            try
            {
                // hapazardly try to set all of the directories from the deserialized config json.  if anything goes wrong
                // an exception will be thrown and we'll handle it.
                retVal.Result = new PlatformDirectories(JsonConvert.DeserializeObject<Dictionary<string, string>>(directories));
            }
            catch (Exception ex)
            {
                retVal.AddError("Exception thrown while deserializing the list of directories from the configuration file:" + ex.Message);
            }

            return retVal;
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
