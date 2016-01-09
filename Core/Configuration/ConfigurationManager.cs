using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Symbiote.Core.Configuration
{
    public class ConfigurationManager
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private ProgramManager manager;
        private static ConfigurationManager instance;
        private string configurationFile;

        public Configuration Configuration { get; private set; }

        private ConfigurationManager(ProgramManager manager)
        {
            this.manager = manager;

            logger.Trace("Retrieving configuration file location from app.config");
            configurationFile = GetConfigurationFileLocation();
            logger.Trace("Attempting to load configuration from '" + configurationFile + "'...");

            try
            {
                Configuration = Configuration.Load(configurationFile, manager.Platform);
            }
            catch (Exception ex)
            {
                logger.Warn("Failed to load configuration from '" + configurationFile + "'.  Building from scratch...");
                Configuration = Configuration.BuildNew();
                logger.Trace("Built configuration: " + Configuration.GetJson());
                Configuration.Save(configurationFile, manager.Platform);
                logger.Info("Created new configuration file in '" + configurationFile + ".");
            }
            
        }

        internal static ConfigurationManager Instance(ProgramManager manager)
        {
            if (instance == null)
                instance = new ConfigurationManager(manager);

            return instance;
        }

        public Configuration Load()
        {
            return Configuration.Load(GetConfigurationFileLocation(), manager.Platform);
        }

        private string GetConfigurationFileLocation()
        {
            return System.Configuration.ConfigurationManager.AppSettings["ConfigurationLocation"];
        }
    }
}
