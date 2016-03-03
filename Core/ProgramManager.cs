using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symbiote.Core.Platform;
using Symbiote.Core.Plugin;
using Symbiote.Core.Model;
using Symbiote.Core.Configuration;
using Symbiote.Core.Communication.Services;
using NLog;
using Symbiote.Core.App;
using Newtonsoft.Json;
using Symbiote.Core.Communication.Endpoints;
using System.Reflection;

namespace Symbiote.Core
{
    /// <summary>
    /// The ProgramManager acts as a Service Locator for the application and contains references to both 
    /// the Manager for each service as well as references to the key resources contained within each namespace.
    /// </summary>
    public class ProgramManager
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

        /// <summary>
        /// A list of the required directories for the application.
        /// </summary>
        private List<string> RequiredDirectories = new List<string>(new string[] { "Data", "Apps", "Plugins", "Temp", "Web", "Logs" });

        #endregion

        #region Properties

        /// <summary>
        /// The name of the product, retrieved from AssemblyInfo.cs.
        /// </summary>
        public string ProductName { get { return typeof(Program).Assembly.GetAssemblyAttribute<System.Reflection.AssemblyProductAttribute>().Product; } }

        /// <summary>
        /// A Dictionary containing all of the application directories, loaded from the App.config.
        /// </summary>
        public Dictionary<string, string> Directories { get; private set; }

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

        public EndpointManager EndpointManager { get; private set; }

        /// <summary>
        /// The AppManager for the application.
        /// </summary>
        public AppManager AppManager { get; private set; }

        #endregion

        #region Constructors

        private ProgramManager()
        {
            logger.Trace("Instantiating ProgramManager member instances...");

            //--- - - 
            // Internal Settings
            //--------- - -
            logger.Trace("Loading application directories...");
            OperationResult loadDirectoryResult = LoadDirectories();
            if (loadDirectoryResult.ResultCode == OperationResultCode.Failure)
                throw new Exception("Failed to load application directory list.");
            Directories = LoadDirectories().Result;

            //------- - ------- -         --
            // Platform Manager
            //----------------------- -- -------------   - -- ------------
            logger.Trace("Instantiating the PlatformManager...");
            PlatformManager = PlatformManager.Instance(this);
            if (PlatformManager == null)
                throw new Exception("PlatformManager.Instance() returned a null instance");
            else logger.Trace("Successfully instantiated the Platform Manager.");

            //------------ -        -- -   -
            // Configuration Manager
            //--------------- --- ---       -
            logger.Trace("Instantiating the Configuration Manager...");
            ConfigurationManager = ConfigurationManager.Instance(this);
            if (ConfigurationManager == null)
                throw new Exception("ConfigurationManager.Instance() returned a null instance.");
            else logger.Trace("Successfully instantiated the Configuration Manager.");

            //------- - - ------------------ - - ------------
            // Plugin Manager
            //----------------------------- ------ -- --
            logger.Trace("Instantiating the Plugin Manager...");
            PluginManager = PluginManager.Instance(this);
            if (PluginManager == null)
                throw new Exception("PluginManager.Instance() returned a null instance.");
            else logger.Trace("Successfully instantiated the Plugin Manager.");

            //-------- -------------- -    -
            // Model Manager
            //---- - -----------  -----
            logger.Trace("Instantiating the Model Manager...");
            ModelManager = ModelManager.Instance(this);
            if (ModelManager == null)
                throw new Exception("ModelManager.Instance() returned a null instance.");
            else logger.Trace("Successfully instantiated the Model Manager.");

            //-------------------- - - -
            // Service Manager
            //------------------- - - ---- -        -
            logger.Trace("Instantiating the Service Manager...");
            ServiceManager = ServiceManager.Instance(this);
            if (ServiceManager == null)
                throw new Exception("ServiceManager.Instance() returned a null instance.");
            else logger.Trace("Successfully instantiated the Service Manager.");

            //------------ -  
            // Endpoint Manager
            //----------------------- - - ------------- - 
            logger.Info("Starting the Endpoint Manager...");
            OperationResult<EndpointManager> endpointManagerResult = InstantiateManager<EndpointManager>();
            if (endpointManagerResult.ResultCode != OperationResultCode.Failure)
            {
                EndpointManager = endpointManagerResult.Result;
                endpointManagerResult.LogResult(logger, "Info", "Warn", "Error", "InstantiateManager");
            }
            else
            {
                endpointManagerResult.LogAllMessages(logger, "Error");
                throw new Exception("Failed to instantiate the Endpoint Manager. Last error: " + endpointManagerResult.GetLastError());
            }
           

            //--------- - ---------------------------
            // App Manager
            //- -- -   ------------- - - --  - -  --------------   -  
            logger.Trace("Instantiating the App Manager...");
            AppManager = AppManager.Instance(this);
            if (AppManager == null)
                throw new Exception("AppManager.Instance() returned a null instance.");
            else logger.Trace("Successfully instantiated the App Manager.");
        }

        internal static ProgramManager Instance()
        {
            if (instance == null)
            {
                instance = new ProgramManager();
            }

            return instance;
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Instantiates the supplied manager, registers it with the ConfigurationManager, fetches the configuration from the ConfigurationManager
        /// and configures the manager with the fetched configuration model.
        /// </summary>
        /// <typeparam name="T">The type of manager to instantiate.</typeparam>
        /// <returns>An OperationResult containing the result of the operation and the instance of the manager.</returns>
        internal OperationResult<T> InstantiateManager<T>() where T : IManager
        {
            OperationResult<T> retVal = new OperationResult<T>();
            OperationResult configureResult;
            ConfigurationDefinition configurationDefinition;

            //---------------------------- - --------- ---------------------------------------------------------  --  -         -
            logger.Trace("Instantiating manager of type " + typeof(T).GetType().Name + "...");
            // invoke the static method Instance() on the given type and save the resulting instance of T
            try
            {
                retVal.Result = (T)typeof(T).GetMethod("Instance").Invoke(null, new object[] { this });
            }
            catch (Exception ex)
            {
                retVal.AddError("Exception thrown instantiating the manager: " + ex);
                return retVal;
            }

            //------------------- - - ------------------------------------------------------------------  -
            logger.Trace("Registering the manager with the Configuration Manager...");
            // grab the result of GetConfigurationDefinition() from the instance of T and register the type and configuration
            // with the configuration manager
            try
            {
                configurationDefinition = (ConfigurationDefinition)typeof(T).GetMethod("GetConfigurationDefinition").Invoke(null, null);
                ConfigurationManager.RegisterType(typeof(T), configurationDefinition);
            }
            catch (Exception ex)
            {
                retVal.AddError("Exception thrown while registering the manager with the ConfigurationDefinition." + ex);
                return retVal;
            }

            //---------------------------------------------- - ---------------------- ------------------------------------------- --  -- - - - - - - 
            logger.Trace("Fetching the configuration for the Manager...");
            // grab the configuration for the manager from the configuration manager and configure the instance of T with it
            try
            {
                // start by getting a reference to the GetConfiguration method
                MethodInfo method = typeof(ConfigurationManager).GetMethod("GetConfiguration");
                // turn it into a generic method of type T = the type of model
                MethodInfo genericMethod = method.MakeGenericMethod(configurationDefinition.Model);
                // create an instance of OperationResult<ModelType> to store the result of GetConfiguration
                Type genericOperationResult = typeof(OperationResult<>);
                Type specificOperationResult = genericOperationResult.MakeGenericType(configurationDefinition.Model);
                ConstructorInfo constructor = specificOperationResult.GetConstructor(Type.EmptyTypes);
                object getConfigurationOperationResult = constructor.Invoke(new object[] { });
                // call the GetConfiguration method and store the result in the new variable we created (no cast needed!)
                getConfigurationOperationResult = genericMethod.Invoke(ConfigurationManager, new object[] { typeof(T), "" });

                //-------------------------------- - ----------- - - - -
                // we have the config now.  send it to the manager.
                logger.Trace("Fetched the configuration from ConfigurationManager.  Calling Configure() on the manager..");
                try
                {
                    // invoke the Configure() method on the manager
                    configureResult = (OperationResult)typeof(T).GetMethod("Configure").Invoke(retVal.Result, new object[] { getConfigurationOperationResult.GetType().GetProperty("Result").GetValue(getConfigurationOperationResult) });
                }
                catch (Exception ex)
                {
                    retVal.AddError("Exception thrown while configuring the manager." + ex);
                    return retVal;
                }
            }
            catch (Exception ex)
            {
                retVal.AddError("Exception thrown while fetching the configuration for the manager." + ex);
                return retVal;
            }

            // report the success as long as we didn't fail.
            if (configureResult.ResultCode != OperationResultCode.Failure)
                logger.Trace("Successfully instantiated and configured the manager '" + typeof(T).GetType().Name + ".");
            else
                retVal.AddError("Failed to configure the manager with the supplied configuration.");
            return retVal;
        }

        internal OperationResult<Dictionary<string, string>> LoadDirectories()
        {
            logger.Info("Loading directory list from the configuration file...");

            OperationResult<Dictionary<string, string>> retVal;

            string configDirectories = Utility.GetSetting("Directories");

            if (configDirectories != "")
            {
                retVal = LoadDirectories(configDirectories);

                if (retVal.ResultCode != OperationResultCode.Failure)
                {
                    Directories = retVal.Result;
                }
            }
            else
            {
                retVal = new OperationResult<Dictionary<string, string>>().AddError("The list of directories is missing from the configuration file.");
            }

            retVal.LogResult(logger);
            return retVal;
        }

        private OperationResult<Dictionary<string, string>> LoadDirectories(string directories)
        {
            OperationResult<Dictionary<string, string>> retVal = new OperationResult<Dictionary<string, string>>();
            retVal.Result = new Dictionary<string, string>();

            try
            {
                retVal.Result = (Dictionary<string, string>)JsonConvert.DeserializeObject<Dictionary<string, string>>(directories);
                // add the root directory
                retVal.Result.Add("Root", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
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
