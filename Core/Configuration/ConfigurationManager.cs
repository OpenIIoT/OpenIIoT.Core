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

        /// <summary>
        /// Instantiates and/or returns the ConfigurationManager instance.
        /// </summary>
        /// <param name="manager">The ProgramManager instance for the application.</param>
        /// <returns>The Singleton instance of the ConfigurationManager</returns>
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


            try
            {
                config = LoadConfiguration(configurationFile);
            }
            catch (Exception ex)
            {
                logger.Warn("Failed to load configuration from '" + configurationFile + "'.  Building from scratch...");
                config = BuildNewConfiguration();
                SaveConfigurationAs(config, configurationFile);
                logger.Info("Created new configuration file in '" + configurationFile + ".");
            }

            if ((config == default(Configuration)) || (config == null))
                throw new ApplicationException("Failed to instantiate a configuration from both a configuration file and by building from scratch.");
            else
                return config;
        }

        /// <summary>
        /// Saves the current configuration to the file specified in app.config.
        /// </summary>
        public void SaveConfiguration()
        {
            SaveConfigurationAs(GetConfigurationFileName());
        }

        /// <summary>
        /// Saves the current configuration to the specified file.
        /// </summary>
        /// <param name="fileName">The file in which to save the configuration.</param>
        public void SaveConfigurationAs(string fileName)
        {
            SaveConfigurationAs(Configuration, fileName);
        }

        /// <summary>
        /// Saves the given configuration to the specified file.
        /// </summary>
        /// <param name="configuration">The Configuration object to serialize and write to disk.</param>
        /// <param name="fileName">The file in which to save the configuration.</param>
        public void SaveConfigurationAs(Configuration configuration, string fileName)
        {
            logger.Trace("Flushing configuration to disk at '" + fileName + "'.");
            manager.Platform.WriteFile(fileName, JsonConvert.SerializeObject(configuration));
        }

        /// <summary>
        /// Reads the given file and attempts to deserialize it to an instance of Configuration
        /// </summary>
        /// <param name="fileName">The file to read and deserialize.</param>
        /// <returns>The Configuration instance created from the file.</returns>
        public Configuration LoadConfiguration(string fileName)
        {
            logger.Trace("Attempting to load configuration from '" + fileName + "'...");
            string configFile = manager.Platform.ReadFile(fileName);
            logger.Trace("Configuration file loaded from '" + fileName + "'.  Attempting to deserialize...");
            Configuration retVal = JsonConvert.DeserializeObject<Configuration>(configFile);
            logger.Trace("Successfully deserialized the contents of '" + fileName + "' to a Configuration object.");
            return retVal;
        }

        /// <summary>
        /// Manually builds an instance of Configuration with default values.
        /// </summary>
        /// <returns>The default instance of a Configuration.</returns>
        public Configuration BuildNewConfiguration()
        {
            Configuration retVal = new Configuration();

            retVal.Symbiote = "0.1.0";
            retVal.Plugins = new PluginSection();
            retVal.Plugins.AuthorizeNewPlugins = false;
            retVal.Plugins.Assemblies = new List<PluginSectionList>();
            retVal.Plugins.Assemblies.Add(
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

            return retVal;
        }

        /// <summary>
        /// Returns the fully qualified path to the configuration file incluidng file name and extension.
        /// </summary>
        /// <returns>The fully qualified path, filename and extension of the configuration file.</returns>
        public string GetConfigurationFileName()
        {
            string retVal = System.Configuration.ConfigurationManager.AppSettings["ConfigurationFileName"];

            if (retVal == "")
            {
                logger.Warn("Error retrieving the configuration filename from Sybmiote.exe.config... assuming Symbiote.config");
                retVal = "Sybmiote.config";
            }

            return retVal;
        }

        /// <summary>
        /// Returns the drive on which the configuration file resides
        /// </summary>
        /// <returns>A string representing the drive containing the configuration file</returns>
        public string GetConfigurationFileDrive()
        {
            return System.IO.Path.GetPathRoot(GetConfigurationFileName());
        }

        /// <summary>
        /// Sets or updates the configuration file location setting in app.config
        /// </summary>
        /// <param name="fileName">The fully qualified path to the configuration file.</param>
        public void SetConfigurationFileName(string fileName)
        {
            System.Configuration.ConfigurationManager.AppSettings["ConfigurationFileName"] = fileName;
            logger.Info("Set application configuration file to '" + fileName + "'.");
        }

        /// <summary>
        /// Moves the configuration file to a new location and updates the setting in app.config.
        /// </summary>
        /// <param name="newFileName">The fully qualified path to the new file.</param>
        public void MoveConfigurationFile(string newFileName)
        {
            string oldFileName = GetConfigurationFileName();

            // physically move the file but not if source and destination are the same.
            if (oldFileName != newFileName)
            {
                System.IO.File.Move(oldFileName, newFileName);
                logger.Trace("Moved configuration file from '" + oldFileName + "' to '" + newFileName + "'.");
            }
            
            SetConfigurationFileName(newFileName);
        }
    }
}
