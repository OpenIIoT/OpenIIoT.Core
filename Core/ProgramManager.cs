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
    internal class ProgramManager
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static ProgramManager instance;

        internal PlatformManager PlatformManager { get; private set; }
        internal IPlatform Platform { get; private set; }

        internal ConfigurationManager ConfigurationManager { get; private set; }
        internal Configuration.Configuration Configuration { get; private set; }

        internal PluginManager PluginManager { get; private set; }
        internal List<IPluginAssembly> Plugins { get; private set; }

        internal ModelManager ModelManager { get; private set; }
        internal Model.Model Model { get; private set; }

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

            logger.Trace("Resolving the list of Plugins...");
            Plugins = PluginManager.Plugins;
            if (Plugins == null)
                throw new Exception("Failed to resolve the list of Plugins.");

            logger.Trace("Plugin Manager instantiated and list of Plugins resolved.");

            // Model Manager
            //-----------------------------------------------------------------------------------
            logger.Trace("Instantiating the Model Manager...");
            ModelManager = ModelManager.Instance(this);
            if (ModelManager == null)
                throw new Exception("ModelManager.Instance() returned a null instance.");

            logger.Trace("Resolving the Model...");
            Model = ModelManager.Model;
            if (Model == null)
                throw new Exception("Failed to resolve the Model.");

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
