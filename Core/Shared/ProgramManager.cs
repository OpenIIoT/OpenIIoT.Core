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
        /// The name of the product
        /// </summary>
        public string ProductName { get; private set; }

        /// <summary>
        /// The PlatformManager for the application.
        /// </summary>
        public PlatformManager PlatformManager { get; private set; }

        /// <summary>
        /// The ConfigurationManager for the application.
        /// </summary>
        public ConfigurationManager ConfigurationManager { get; private set; }

        public PluginManager PluginManager { get; private set; }

        public ModelManager ModelManager { get; private set; }

        private ProgramManager()
        {
            logger.Trace("Instantiating ProgramManager member instances...");

            // Platform Manager
            //-----------------------------------------------------------------------------------
            logger.Trace("Instantiating the PlatformManager...");
            PlatformManager = PlatformManager.Instance(this);
            if (PlatformManager == null)
                throw new Exception("PlatformManager.Instance() returned a null instance");

            // Configuration Manager
            //-----------------------------------------------------------------------------------
            logger.Trace("Instantiating the Configuration Manager...");
            ConfigurationManager = ConfigurationManager.Instance(this);
            if (ConfigurationManager == null)
                throw new Exception("ConfigurationManager.Instance() returned a null instance.");

            // Plugin Manager
            //-----------------------------------------------------------------------------------
            logger.Trace("Instantiating the Plugin Manager...");
            PluginManager = PluginManager.Instance(this);
            if (PluginManager == null)
                throw new Exception("PluginManager.Instance() returned a null instance.");

            // Model Manager
            //-----------------------------------------------------------------------------------
            logger.Trace("Instantiating the Model Manager...");
            ModelManager = ModelManager.Instance(this);
            if (ModelManager == null)
                throw new Exception("ModelManager.Instance() returned a null instance.");
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

        /// <summary>
        /// Sets the ProductName property to the given value.
        /// </summary>
        /// <param name="name">The name of the product.</param>
        internal void SetProductName(string name)
        {
            ProductName = name;
        }
    }
}
