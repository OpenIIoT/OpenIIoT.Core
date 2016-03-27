using System;
using System.Collections.Generic;
using Symbiote.Core.Platform;
using Symbiote.Core.Plugin;
using Symbiote.Core.Model;
using Symbiote.Core.Configuration;
using NLog;
using Symbiote.Core.App;
using Symbiote.Core.Service;

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
        /// Indicates whether the program is in Safe Mode.  Safe Mode is a sort of fault tolerant mode designed
        /// to allow the application to run under conditions that would otherwise raise fatal errors.
        /// </summary>
        public bool SafeMode { get; private set; }

        /// <summary>
        /// The state of the Manager.
        /// </summary>
        public bool Running { get; private set; }

        /// <summary>
        /// True while the application is starting, false afterwards.
        /// </summary>
        public bool Starting { get; set; }

        /// <summary>
        /// The name of the product, retrieved from AssemblyInfo.cs.
        /// </summary>
        public string ProductName { get { return typeof(Program).Assembly.GetAssemblyAttribute<System.Reflection.AssemblyProductAttribute>().Product; } }

        /// <summary>
        /// The name of the application instance.
        /// </summary>
        public string InstanceName { get { return Utility.GetSetting("InstanceName");  } }


        //------------------------------------------- - - ------------ - -
        // Properties related to the PlatformManager.
        /// <summary>
        /// The PlatformManager for the application.
        /// </summary>
        public PlatformManager PlatformManager { get; private set; }
        /// <summary>
        /// The Platform for the application.
        /// </summary>
        public IPlatform Platform { get { return PlatformManager.Platform; } }
        /// <summary>
        /// The directories used by the application.
        /// </summary>
        public PlatformDirectories Directories { get { return PlatformManager.Directories; } }
        //---------------------------------- - -         --------- - --------------  -


        //-------------------- - - ---------------- - -  -             --------- - 
        // Properties related to the ConfigurationManager
        /// <summary>
        /// The ConfigurationManager for the application.
        /// </summary>
        public ConfigurationManager ConfigurationManager { get; private set; }
        /// <summary>
        /// The configuration for the application.
        /// </summary>
        public ApplicationConfiguration Configuration { get { return ConfigurationManager.Configuration; } }
        /// <summary>
        /// The filename of the configuration file.
        /// </summary>
        public string ConfigurationFileName { get { return ConfigurationManager.ConfigurationFileName; } }
        /// <summary>
        /// A dictionary containing the types and ConfigurationDefinitions for the configurable types within the application.
        /// </summary>
        public Dictionary<Type, ConfigurationDefinition> RegisteredTypes { get { return ConfigurationManager.RegisteredTypes; } }
        //---------------------------------- -   ----------------- - -------------------------------------------------  ---------- 


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
        public Plugin.Endpoint.EndpointManager EndpointManager { get; private set; }

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
        private ProgramManager(bool safeMode = false)
        {
            SafeMode = safeMode;

            if (safeMode)
                logger.Info("Safe Mode enabled.  The program is now running in a limited fault tolerant mode.");

            logger.Debug("Instantiating Managers...");
            Running = false;

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
            ConfigurationManager.RegisterType(typeof(PluginManager));
            logger.Debug("Successfully instantiated the Plugin Manager.");
            //----------------------------- ------ -- --


            //-------- -------------- -    -
            // Model Manager
            logger.Debug("Instantiating the Model Manager...");
            ModelManager = ModelManager.Instance(this);
            ConfigurationManager.RegisterType(typeof(ModelManager));
            logger.Debug("Successfully instantiated the Model Manager.");
            //---- - -----------  -----


            //-------------------- - - -
            // Service Manager
            logger.Debug("Instantiating the Service Manager...");
            ServiceManager = ServiceManager.Instance(this);
            logger.Debug("Successfully instantiated the Service Manager.");
            //------------------- - - ---- -        -


            //------------ -  
            // Endpoint Manager
            //----------------------- - - ------------- - 
            logger.Debug("Instantiating the Endpoint Manager...");
            EndpointManager = Plugin.Endpoint.EndpointManager.Instance(this);
            ConfigurationManager.RegisterType(typeof(Plugin.Endpoint.EndpointManager));
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
        internal static ProgramManager Instance(bool safeMode = false)
        {
            if (instance == null)
                instance = new ProgramManager(safeMode);

            return instance;
        }

        #endregion

        #region Instance Methods

        #region IManager Implementation

        /// <summary>
        /// Starts the Program Manager.
        /// </summary>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        public OperationResult Start()
        {
            logger.Info("Starting the Program Manager...");
            OperationResult retVal = new OperationResult();

            Running = (retVal.ResultCode != OperationResultCode.Failure);

            retVal.LogResult(logger);
            return retVal;
        }

        /// <summary>
        /// Restarts the Program Manager.
        /// </summary>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        public OperationResult Restart()
        {
            logger.Info("Restarting the Program Manager...");
            OperationResult retVal = new OperationResult();

            retVal.Incorporate(Stop());
            retVal.Incorporate(Start());

            retVal.LogResult(logger);
            return retVal;
        }

        /// <summary>
        /// Stops the Program Manager.
        /// </summary>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        public OperationResult Stop()
        {
            logger.Info("Stopping the Program Manager...");
            OperationResult retVal = new OperationResult();

            Running = false;

            retVal.LogResult(logger);
            return new OperationResult();
        }

        #endregion

        internal OperationResult RenameInstance(string instanceName)
        {
            Utility.UpdateSetting("InstanceName", instanceName);
            Restart();

            return new OperationResult();
        }


        internal OperationResult<IManager> StartManager(IManager manager)
        {
            logger.Info("Starting " + manager.GetType().Name + "...");
            OperationResult<IManager> retVal = new OperationResult<IManager>();

            OperationResult startResult = manager.Start();

            if (startResult.ResultCode == OperationResultCode.Failure)
                throw new Exception("Failed to start " + manager.GetType().Name + "." + startResult.GetLastError());

            retVal.Result = manager;
            retVal.Incorporate(startResult);

            retVal.LogResult(logger);
            return retVal;
        }

        #endregion

        #region Static Methods

        public static string GetInstanceName()
        {
            return Utility.GetSetting("InstanceName", "Symbiote");
        }

        public static string GetHashSalt()
        {
            return "needs more salt";
        }

        #endregion
    }
}
