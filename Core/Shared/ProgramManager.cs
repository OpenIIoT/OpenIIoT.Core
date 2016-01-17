using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symbiote.Core.Platform;
using Symbiote.Core.Plugin;
using Symbiote.Core.Model;
using Symbiote.Core.Configuration;
using NLog;

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
        /// The PlatformManager for the application.
        /// </summary>
        public PlatformManager PlatformManager { get; private set; }

        /// <summary>
        /// The Platform for the application.
        /// </summary>
        public IPlatform Platform { get; private set; }

        /// <summary>
        /// The ConfigurationManager for the application.
        /// </summary>
        public ConfigurationManager ConfigurationManager { get; private set; }
        /// <summary>
        /// The Configuration for the application.
        /// </summary>
        public Configuration.Configuration Configuration { get; private set; }

        public PluginManager PluginManager { get; private set; }
        public List<IPluginAssembly> PluginAssemblies { get; private set; }
        public List<IPluginInstance> PluginInstances { get; private set; }

        public ModelManager ModelManager { get; private set; }
        public ModelItem Model { get; private set; }

        private ProgramManager()
        {
            logger.Trace("Instantiating ProgramManager member instances...");

            // Platform Manager
            //-----------------------------------------------------------------------------------
            logger.Trace("Instantiating the PlatformManager...");
            PlatformManager = PlatformManager.Instance(this);
            if (PlatformManager == null)
                throw new Exception("PlatformManager.Instance() returned a null instance");

            logger.Trace("PlatformManager instantiated.  Resolving the Platform...");
            Platform = PlatformManager.Platform;
            if (Platform == null)
                throw new Exception("PlatformManager.Platform returned a null instance of IPlatform");
            
            logger.Trace("Platform Manager instantiated and Platform resolved.");

            // Configuration Manager
            //-----------------------------------------------------------------------------------
            logger.Trace("Instantiating the Configuration Manager...");
            ConfigurationManager = ConfigurationManager.Instance(this);
            if (ConfigurationManager == null)
                throw new Exception("ConfigurationManager.Instance() returned a null instance.");

            logger.Trace("ConfigurationManager instantiated.  Resolving the Configuration...");
            Configuration = ConfigurationManager.Configuration;
            if (Configuration == null)
                throw new Exception("ConfigurationManager.Configuration returned a null instance of Configuration.");

            logger.Trace("Configuration Manager instantiated and Configuration resolved.");

            // Plugin Manager
            //-----------------------------------------------------------------------------------
            logger.Trace("Instantiating the Plugin Manager...");
            PluginManager = PluginManager.Instance(this);
            if (PluginManager == null)
                throw new Exception("PluginManager.Instance() returned a null instance.");

            logger.Trace("Resolving the list of Plugin Assemblies...");
            PluginAssemblies = PluginManager.PluginAssemblies;
            if (PluginAssemblies == null)
                throw new Exception("Failed to resolve the list of Plugin Assemblies.");

            logger.Trace("Plugin Manager instantiated and list of Plugins resolved.");

            // Model Manager
            //-----------------------------------------------------------------------------------
            logger.Trace("Instantiating the Model Manager...");
            ModelManager = ModelManager.Instance(this);
            if (ModelManager == null)
                throw new Exception("ModelManager.Instance() returned a null instance.");

            //logger.Trace("Resolving the Model...");
            //Model = ModelManager.Model;
            //if (Model == null)
            //    throw new Exception("Failed to resolve the Model.");

            logger.Trace("Model manager instantiated and Model resolved.");
            logger.Trace("Program Manager member instances instantiated.");
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
