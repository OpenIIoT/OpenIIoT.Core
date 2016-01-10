using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using Newtonsoft.Json;
using Symbiote.Core.Platform;
using Symbiote.Core.Plugin;

namespace Symbiote.Core.Configuration
{
    /// <summary>
    /// The Configuration Manager class manages the configuration file for the application.
    /// </summary>
    /// <remarks>
    /// This class implements the Singleton and Factory design patterns.
    /// </remarks>
    public class ConfigurationManager
    {
        private ProgramManager manager;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static ConfigurationManager instance;

        /// <summary>
        /// The current configuration.
        /// </summary>
        public Configuration Configuration { get; private set; }

        /// <summary>
        /// Private constructor, only called by Instance()
        /// </summary>
        /// <param name="manager">The ProgramManager instance for the application</param>
        private ConfigurationManager(ProgramManager manager)
        {
            this.manager = manager;

            Configuration = InstantiateConfiguration();
        }

        internal static ConfigurationManager Instance(ProgramManager manager)
        {
            if (instance == null)
                instance = new ConfigurationManager(manager);

            return instance;
        }

        /// <summary>
        /// Attempts to load and return the application configuration file from the location specified in app.config.
        /// Failing that, builds a new (default) configuration file from scratch, saves it to the location specified in app.config and returns it.
        /// </summary>
        /// <returns>An instance of Configuration containing the loaded or newly generated configuration.</returns>
        private Configuration InstantiateConfiguration()
        {
            Configuration config;

            logger.Trace("Retrieving configuration file location from app.config");
            string configurationFile = GetConfigurationFileName();
            logger.Trace("Attempting to load configuration from '" + configurationFile + "'...");

            try
            {
                config = LoadConfiguration(configurationFile);
            }
            catch (Exception ex)
            {
                logger.Warn("Failed to load configuration from '" + configurationFile + "'.  Building from scratch...");
                config = BuildNewConfiguration();
                SaveConfiguration(config, configurationFile);
                logger.Info("Created new configuration file in '" + configurationFile + ".");
            }
            return config;
        }

        public void SaveConfiguration()
        {
            SaveConfiguration(Configuration, GetConfigurationFileName());
        }
        public void SaveConfiguration(Configuration configuration, string fileName)
        {
            logger.Trace("Flushing configuration to disk at '" + fileName);
            manager.Platform.WriteFile(fileName, JsonConvert.SerializeObject(configuration));
        }

        public Configuration LoadConfiguration(string fileName)
        {
            string configFile = manager.Platform.ReadFile(fileName);
            return JsonConvert.DeserializeObject<Configuration>(configFile);
        }

        public Configuration BuildNewConfiguration()
        {
            Configuration config = new Configuration();

            config.Symbiote = "0.1.0";
            config.Plugins = new PluginSection();
            config.Plugins.AuthorizeNewPlugins = false;
            config.Plugins.Assemblies = new List<PluginSectionList>();
            config.Plugins.Assemblies.Add(
                new PluginSectionList()
                {
                    Name = "Symbiote.Plugin.Connector.Simulation",
                    FullName = "Symbiote.Plugin.Connector.Simulator, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null",
                    Version = "0.1.0.0",
                    PluginType = "Connector",
                    FileName = "Symbiote.Plugin.Connector.Simulation.dll",
                    Checksum = "58ee417bc7df51ae70ba6b0f55bc25b3",
                    Authorization = Plugin.PluginAuthorization.Authorized
                });

            return config;
        }

        /// <summary>
        /// Returns the fully qualified path to the configuration file incluidng file name and extension.
        /// </summary>
        /// <returns>The fully qualified path, filename and extension of the configuration file.</returns>
        public static string GetConfigurationFileName()
        {
            return System.Configuration.ConfigurationManager.AppSettings["ConfigurationFileName"];
        }

        /// <summary>
        /// Returns the drive on which the configuration file resides
        /// </summary>
        /// <returns>A string representing the drive containing the configuration file</returns>
        public static string GetConfigurationFileDrive()
        {
            return System.IO.Path.GetPathRoot(GetConfigurationFileName());
        }

        /// <summary>
        /// Moves the configuration file to a new location and updates the setting in app.config
        /// </summary>
        /// <param name="location">The fully qualified path to the new file, including file name and extension.</param>
        public static void SetConfigurationFileName(string fileName)
        {
            string oldLocation = GetConfigurationFileName();
            System.IO.File.Move(oldLocation, fileName);
            System.Configuration.ConfigurationManager.AppSettings["ConfigurationFileName"] = fileName;
        }
    }
}
