using System;
using System.Collections.Generic;
using Symbiote.Core.Platform;
using Symbiote.Core.Plugin;
using Symbiote.Core.Model;
using Symbiote.Core.Configuration;
using Symbiote.Core.Communication.Services;
using NLog;
using Symbiote.Core.App;
using Newtonsoft.Json;
using Symbiote.Core.Communication.Endpoints;

namespace Symbiote.Core
{
    /// <summary>
    /// The ProgramManager acts as a Service Locator for the application and contains references to both 
    /// the Manager for each service as well as references to the key resources contained within each namespace.
    /// </summary>
    public class ProgramManager : IManager
    {
        #region Variables

        /// <summary>
        /// The logger for this class.
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The Singleton instance of ProgramManager.
        /// </summary>
        private static ProgramManager instance;

        #endregion

        #region Properties

        /// <summary>
        /// The name of the product, retrieved from AssemblyInfo.cs.
        /// </summary>
        public string ProductName { get { return typeof(Program).Assembly.GetAssemblyAttribute<System.Reflection.AssemblyProductAttribute>().Product; } }

        /// <summary>
        /// A Dictionary containing all of the application directories, loaded from the App.config.
        /// </summary>
        public ProgramDirectories Directories { get; private set; }

        /// <summary>
        /// The PlatformManager for the application.
        /// </summary>
        public PlatformManager PlatformManager { get; private set; }

        /// <summary>
        /// The ConfigurationManager for the application.
        /// </summary>
        public ConfigurationManager ConfigurationManager { get; private set; }

        /// <summary>
        /// The PluginManager for the application.
        /// </summary>
        public PluginManager PluginManager { get; private set; }

        /// <summary>
        /// The ModelManager for the application.
        /// </summary>
        public ModelManager ModelManager { get; private set; }

        /// <summary>
        /// The ServiceManager for the application.
        /// </summary>
        public ServiceManager ServiceManager { get; private set; }

        /// <summary>
        /// The EndpointManager for the application.
        /// </summary>
        public EndpointManager EndpointManager { get; private set; }

        /// <summary>
        /// The AppManager for the application.
        /// </summary>
        public AppManager AppManager { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// The default constructor.
        /// </summary>
        /// <remarks>
        /// If you've forgotten, you made this code dynamic so that you coud iterate over IManagers and it was 
        /// a mess.  Even more verbose than the way it is now, plus debugging it was a nightmare.  Don't try it again.
        /// </remarks>
        private ProgramManager()
        {
            logger.Debug("Instantiating Managers...");


            //------- - ------- -         --
            // Platform Manager
            logger.Debug("Instantiating the PlatformManager...");
            PlatformManager = PlatformManager.Instance(this);
            logger.Debug("Successfully instantiated the Platform Manager.");
            //----------------------- -- -------------   - -- ------------


            //------------ -        -- -   -
            // Configuration Manager
            logger.Debug("Instantiating the Configuration Manager...");
            ConfigurationManager = ConfigurationManager.Instance(this);
            logger.Debug("Successfully instantiated the Configuration Manager.");
            //--------------- --- ---       -


            //------- - - ------------------ - - ------------
            // Plugin Manager
            logger.Debug("Instantiating the Plugin Manager...");
            PluginManager = PluginManager.Instance(this);
            logger.Debug("Successfully instantiated the Plugin Manager.");
            //----------------------------- ------ -- --


            //-------- -------------- -    -
            // Model Manager
            logger.Debug("Instantiating the Model Manager...");
            ModelManager = ModelManager.Instance(this);
            logger.Debug("Successfully instantiated the Model Manager.");
            //---- - -----------  -----


            //-------------------- - - -
            // Service Manager
            logger.Debug("Instantiating the Service Manager...");
            ServiceManager = ServiceManager.Instance(this);
            ConfigurationManager.RegisterType(typeof(ServiceManager));
            logger.Debug("Successfully instantiated the Service Manager.");
            //------------------- - - ---- -        -


            //------------ -  
            // Endpoint Manager
            //----------------------- - - ------------- - 
            logger.Debug("Instantiating the Endpoint Manager...");
            EndpointManager = EndpointManager.Instance(this);
            ConfigurationManager.RegisterType(typeof(EndpointManager));
            logger.Debug("Successfully instantiated the Endpoint Manager.");
           

            //--------- - ---------------------------
            // App Manager
            //- -- -   ------------- - - --  - -  --------------   -  
            logger.Debug("Instantiating the App Manager...");
            AppManager = AppManager.Instance(this);
            logger.Debug("Successfully instantiated the App Manager.");
        }

        /// <summary>
        /// Returns the singleton instance of the ProgramManager.  Creates an instance if null.
        /// </summary>
        /// <returns>The singleton instance of the ProgramManager</returns>
        internal static ProgramManager Instance()
        {
            if (instance == null)
                instance = new ProgramManager();

            return instance;
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Starts the Program Manager.
        /// </summary>
        /// <seealso cref="IManager">Implementation of IManager</seealso>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        public OperationResult Start()
        {
            logger.Info("Starting the Program Manager...");
            OperationResult retVal = new OperationResult();


            //-------- - - - -- - - 
            // Populate the ProgramDirectories list
            logger.Debug("Loading application directories...");
            OperationResult<ProgramDirectories> loadDirectoryResult = LoadDirectories();
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
            return retVal;
        }

        /// <summary>
        /// Loads the list of directories from the configuration.exe file
        /// </summary>
        /// <returns>An OperationResult containing the result of the operation along with a ProgramDirectories instance containing the directories.</returns>
        internal OperationResult<ProgramDirectories> LoadDirectories()
        {
            logger.Trace("Loading directory list from the configuration file...");
            OperationResult<ProgramDirectories> retVal;
            string configDirectories = Utility.GetSetting("Directories");

            if (configDirectories != "")
            {
                retVal = LoadDirectories(configDirectories);
                if (retVal.ResultCode != OperationResultCode.Failure)
                    Directories = retVal.Result;
            }
            else
                retVal = new OperationResult<ProgramDirectories>().AddError("The list of directories is missing from the configuration file.");

            retVal.LogResult(logger, "Trace");
            return retVal;
        }

        /// <summary>
        /// Deserializes the provided string to a dictionary containing the program directory names and paths, then creates
        /// an instance of ProgramDirectories with it.
        /// </summary>
        /// <param name="directories">A serialized dictionary containing the program directories and their paths.</param>
        /// <returns>An OperationResult containing the result of the operation along with a ProgramDirectories instance containing the directories.</returns>
        private OperationResult<ProgramDirectories> LoadDirectories(string directories)
        {
            OperationResult<ProgramDirectories> retVal = new OperationResult<ProgramDirectories>();

            try
            {
                // hapazardly try to set all of the directories from the deserialized config json.  if anything goes wrong
                // an exception will be thrown and we'll handle it.
                retVal.Result = new ProgramDirectories(JsonConvert.DeserializeObject<Dictionary<string, string>>(directories));
            }
            catch (Exception ex)
            {
                retVal.AddError("Exception thrown while deserializing the list of directories from the configuration file:" + ex.Message);
            }
        
            return retVal;
        }

        #endregion
    }
}
