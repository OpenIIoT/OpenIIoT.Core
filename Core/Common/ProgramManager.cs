using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symbiote.Core.Platform;
using Symbiote.Core.Plugin;
using Symbiote.Core.Model;
using Symbiote.Core.Configuration;
using Symbiote.Core.Services.Web;
using NLog;
using Symbiote.Core.App;

namespace Symbiote.Core
{
    /// <summary>
    /// The ProgramManager acts as a Service Locator for the application and contains references to both 
    /// the Manager for each service as well as references to the key resources contained within each namespace.
    /// </summary>
    public class ProgramManager
    {
        /// <summary>
        /// The logger for this class.
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();
        
        /// <summary>
        /// The Singleton instance of ProgramManager.
        /// </summary>
        private static ProgramManager instance;

        /// <summary>
        /// Encapsulates various internal application settings.
        /// </summary>
        public InternalSettings InternalSettings { get; private set; }

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
        /// The WebManager for the application.
        /// </summary>
        public WebManager WebManager { get; private set; }

        /// <summary>
        /// The AppManager for the application.
        /// </summary>
        public AppManager AppManager { get; private set; }

        private ProgramManager()
        {
            logger.Trace("Instantiating ProgramManager member instances...");

            //--- - - 
            // Internal Settings
            //--------- - -
            InternalSettings = new InternalSettings();

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
            // Web Manager
            //------------------- - - ---- -        -
            logger.Trace("Instantiating the Web Manager...");
            WebManager = WebManager.Instance(this);
            if (WebManager == null)
                throw new Exception("WebManager.Instance() returned a null instance.");
            else logger.Trace("Successfully instantiated the Web Manager.");

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
            logger.Trace("Returning ProgramManager instance...");
            if (instance == null)
            {
                logger.Trace("ProgramManager instance is null; instantiating...");
                instance = new ProgramManager();
                logger.Trace("Instantiated ProgramManager instance.");
            }

            logger.Trace("Returning ProgramManager instance...");
            return instance;
        }
    }
}
