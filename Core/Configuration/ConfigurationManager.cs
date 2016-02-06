using System;
using System.Collections.Generic;
using NLog;
using Newtonsoft.Json;
using Symbiote.Core.Plugin;
using Symbiote.Core.Model;
using Symbiote.Core.Configuration.Model;
using Symbiote.Core.Configuration.Plugin;

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
        public Configuration InstantiateConfiguration()
        {
            Configuration config;

            logger.Trace("Retrieving configuration file location from app.config");
            string configurationFile = GetConfigurationFileName();

            try
            {
                config = LoadConfiguration(configurationFile);
                logger.Info("Loaded configuration from '" + configurationFile + "'.");
            }
            catch (Exception ex)
            {
                logger.Trace("Error loading configuration from '" + configurationFile + "':" + ex.Message);
                logger.Warn("Failed to load configuration from '" + configurationFile + "'.  Building from scratch...");
                config = BuildNewConfiguration();
                SaveConfigurationAs(config, configurationFile);
                logger.Info("Created new configuration file in '" + configurationFile + ".");
            }

            if ((config == default(Configuration)) || (config == null))
                throw new ConfigurationInstantiationException("Failed to instantiate a configuration from both a configuration file and by building from scratch.");
            else
            {
                Configuration = config;
                return config;
            }
        }

        /// <summary>
        /// Saves the current configuration to the file specified in app.config.
        /// </summary>
        public bool SaveConfiguration()
        {
            return SaveConfigurationAs(GetConfigurationFileName());
        }

        /// <summary>
        /// Saves the current configuration to the specified file.
        /// </summary>
        /// <param name="fileName">The file in which to save the configuration.</param>
        public bool SaveConfigurationAs(string fileName)
        {
            return SaveConfigurationAs(Configuration, fileName);
        }

        /// <summary>
        /// Saves the given configuration to the specified file.
        /// </summary>
        /// <param name="configuration">The Configuration object to serialize and write to disk.</param>
        /// <param name="fileName">The file in which to save the configuration.</param>
        public bool SaveConfigurationAs(Configuration configuration, string fileName)
        {
            logger.Trace("Flushing configuration to disk at '" + fileName + "'.");
            manager.PlatformManager.Platform.WriteFile(fileName, JsonConvert.SerializeObject(configuration, Formatting.Indented));
            return true;
        }

        /// <summary>
        /// Reads the given file and attempts to deserialize it to an instance of Configuration
        /// </summary>
        /// <param name="fileName">The file to read and deserialize.</param>
        /// <returns>The Configuration instance created from the file.</returns>
        public Configuration LoadConfiguration(string fileName)
        {
            logger.Trace("Attempting to load configuration from '" + fileName + "'...");
            string configFile = manager.PlatformManager.Platform.ReadFile(fileName);
            logger.Trace("Configuration file loaded from '" + fileName + "'.  Attempting to deserialize...");

            Configuration retVal;
            try
            {
                retVal = JsonConvert.DeserializeObject<Configuration>(configFile);
                logger.Trace("Successfully deserialized the contents of '" + fileName + "' to a Configuration object.");

                logger.Trace("Validating configuration...");
                ConfigurationValidationResult validationResult = ValidateConfiguration(retVal);
                if (validationResult.Result == ConfigurationValidationResultCode.Valid)
                {
                    logger.Trace("Successfully validated configuration.");
                    return retVal;
                }
                else
                {
                    throw new ApplicationException("Configuration validation returned a " + validationResult.Result.ToString() + "; message: " + validationResult.Message);
                }
            }
            catch (Exception ex)
            {
                logger.Error("Error deserializing conents of configuration file '" + fileName + "': " + ex.Message);
                throw new ApplicationException("Failed to load configuration from file '" + fileName + "'.");
            }
        }

        /// <summary>
        /// Examines the supplied Configuration for errors and returns the result.  If returning a Warning or Invalid result code,
        /// includes the validation message in the Message member of the return type.
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns>A ValidationResult containing the validation result code and, if applicable, message.</returns>
        public ConfigurationValidationResult ValidateConfiguration(Configuration configuration)
        {
            // TODO: validate configuration; check for duplicates, etc.
            // issue #1
            return new ConfigurationValidationResult() { Result = ConfigurationValidationResultCode.Valid, Message = "" };
        }

        /// <summary>
        /// Manually builds an instance of Configuration with default values.
        /// </summary>
        /// <returns>The default instance of a Configuration.</returns>
        public Configuration BuildNewConfiguration()
        {
            Configuration retVal = new Configuration();

            retVal.Symbiote = "0.1.0";
            retVal.Model = new ConfigurationModelSection();
            retVal.Model.Items = new List<ConfigurationModelItem>();
            retVal.Model.Items.Add(new ConfigurationModelItem() { FQN = "Symbiote", Definition = new Item("Symbiote", typeof(string)).ToJson() });

            retVal.Plugins = new ConfigurationPluginSection();
            retVal.Plugins.AuthorizeNewPlugins = true;
            retVal.Plugins.Assemblies.Add(
                new ConfigurationPluginAssembly()
                {
                    Name = "Symbiote.Plugin.Connector.Simulation",
                    FullName = "Symbiote.Plugin.Connector.Simulator, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null",
                    Version = "0.1.0.0",
                    PluginType = "Connector",
                    FileName = "Symbiote.Plugin.Connector.Simulation.dll",
                    Checksum = "455a4de00418691328207208c3404d17",
                    Authorization = PluginAuthorization.Authorized
                });

            retVal.Plugins.Instances.Add(
                new ConfigurationPluginInstance() {
                    InstanceName = "Simulation",
                    AssemblyName = "Symbiote.Plugin.Connector.Simulation",
                    Configuration = "",
                    AutoBuild = new ConfigurationPluginInstanceAutoBuild()
                    {
                        Enabled = true, ParentFQN = "Symbiote"
                    }

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

            if ((retVal == "") || (retVal == null))
            {
                logger.Warn("Error retrieving the configuration filename from Sybmiote.exe.config... assuming Symbiote.config");
                retVal = "Sybmiote.config";
            }
            logger.Trace("Retrieved '" + retVal + "' from the app configuration file.");

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
