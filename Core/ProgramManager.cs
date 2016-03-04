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

        /// <summary>
        /// The default constructor.
        /// </summary>
        /// <remarks>
        /// If you've forgotten, you made this code dynamic so that you coud iterate over IManagers and it was 
        /// a mess.  Even more verbose than the way it is now, plus debugging it was a nightmare.  Don't try it again.
        /// </remarks>
        private ProgramManager()
        {
            //--- - - 
            // Internal Settings
            //--------- - -
            logger.Debug("Loading application directories...");
            OperationResult<Dictionary<string, string>> loadDirectoryResult = LoadDirectories();
            if (loadDirectoryResult.ResultCode == OperationResultCode.Failure)
                throw new Exception("Failed to load application directory list.");
            Directories = loadDirectoryResult.Result;

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

        public OperationResult Start()
        {
            OperationResult retVal = new OperationResult();
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
