using System;
using System.Collections.Generic;
using NLog;
using Newtonsoft.Json;
using Symbiote.Core.Plugin;
using Symbiote.Core.Model;
using Symbiote.Core.Configuration.Model;
using Symbiote.Core.Configuration.Plugin;
using System.Linq;
using System.Reflection;

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
        #region Variables

        /// <summary>
        /// The ProgramManager for the application.
        /// </summary>
        private ProgramManager manager;

        /// <summary>
        /// The Logger for this class.
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The Singleton instance of ConfigurationManager.
        /// </summary>
        private static ConfigurationManager instance;

        #endregion

        #region Properties

        /// <summary>
        /// The list of properties to be used when serializing/deserializing configuration items.
        /// </summary>
        public List<string> ItemSerializationProperties { get { return new List<string>(new string[] { "FQN", "SourceAddress", "Type", "IsReadable", "IsWriteable" }); } }

        /// <summary>
        /// The current configuration.
        /// </summary>
        public ApplicationConfiguration Configuration { get; private set; }

        /// <summary>
        /// The list of registered Types
        /// </summary>
        public Dictionary<Type, ConfigurationDefinition> RegisteredTypes { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Private constructor, only called by Instance()
        /// </summary>
        /// <param name="manager">The ProgramManager instance for the application</param>
        private ConfigurationManager(ProgramManager manager)
        {
            this.manager = manager;

            RegisteredTypes = new Dictionary<Type, ConfigurationDefinition>();
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

        #endregion

        #region Instance Methods

        /// <summary>
        /// Attempts to load and return the application configuration file from the location specified in app.config.
        /// Failing that, builds a new (default) configuration file from scratch, saves it to the location specified in app.config and returns it.
        /// </summary>
        /// <returns>An instance of Configuration containing the loaded or newly generated configuration.</returns>
        public OperationResult<ApplicationConfiguration> LoadConfiguration()
        {
            logger.Info("Loading Configuration...");

            string configurationFile = GetConfigurationFileName();

            OperationResult<ApplicationConfiguration> retVal = LoadConfiguration(configurationFile);

            if (retVal.ResultCode == OperationResultCode.Failure)
            {
                retVal.LogAllMessages(logger, "Warn", "Failed to load the Configuration from '" + configurationFile + "'.  The following messages were generated during the load:");

                logger.Info("Building a new Configuration from scratch...");
                retVal = BuildNewConfiguration();

                // log any issues we encounter during the build
                if (retVal.ResultCode != OperationResultCode.Success)
                {
                    if (retVal.ResultCode == OperationResultCode.Warning)
                        retVal.LogAllMessages(logger, "Warn", "Successfully built the Configuration from scratch, however the following messages were generated during the build:");
                    else
                        retVal.AddError("Failed to load the Configuration from the configuration file and also failed to build it from scratch.");
                }
                else
                {
                    logger.Info("The new Configuration was built successfully.");
                    logger.Info("Saving the new Configuration...");

                    OperationResult saveResult = SaveConfiguration(retVal.Result, configurationFile);
                    if (saveResult.ResultCode != OperationResultCode.Success)
                    {
                        if (saveResult.ResultCode == OperationResultCode.Warning)
                            saveResult.LogAllMessages(logger, "Warn", "Successfully saved the Configuration, however the following messages were generated during the save:");
                        else
                            retVal.AddError("Failed to save the Configuration.");
                    }
                    else
                        logger.Info("Successfully saved the new Configuration to '" + configurationFile + "'.");
                }
            }

            retVal.LogResult(logger);
            Configuration = retVal.Result;
            logger.Info("Loaded Configuration from '" + configurationFile + "'.");
            return retVal;
        }

        /// <summary>
        /// Reads the given file and attempts to deserialize it to an instance of Configuration
        /// </summary>
        /// <param name="fileName">The file to read and deserialize.</param>
        /// <returns>An OperationResult containing the Configuration instance created from the file.</returns>
        public OperationResult<ApplicationConfiguration> LoadConfiguration(string fileName)
        {
            OperationResult<ApplicationConfiguration> retVal = new OperationResult<ApplicationConfiguration>();

            try
            {
                logger.Trace("Attempting to load configuration from '" + fileName + "'...");
                string configFile = manager.PlatformManager.Platform.ReadFile(fileName);
                logger.Trace("Configuration file loaded from '" + fileName + "'.  Attempting to deserialize...");

                retVal.Result = JsonConvert.DeserializeObject<ApplicationConfiguration>(configFile);
                logger.Trace("Successfully deserialized the contents of '" + fileName + "' to a Configuration object.");

                logger.Trace("Validating configuration...");
                OperationResult validationResult = ValidateConfiguration(retVal.Result);

                // if the validation didn't complete "cleanly", add appropriate messages to the OperationResult
                if (validationResult.ResultCode != OperationResultCode.Success)
                {
                    // if it failed, add the failure as a warning message
                    if (validationResult.ResultCode == OperationResultCode.Failure)
                    {
                        retVal.AddError("The configuration validation failed with the following messages:");
                        foreach (OperationResultMessage message in validationResult.Messages)
                            retVal.AddWarning(message.Message);
                    }
                    // if it succeeded with warnings, add the warnings
                    else
                    {
                        retVal.AddWarning("The configuration validation succeeded, however the following messages were generated:");
                        foreach (OperationResultMessage message in validationResult.Messages)
                            retVal.AddWarning(message.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                retVal.AddError("Exception thrown while loading Configuration from '" + fileName + "': " + ex.Message);
            }
            return retVal;
        }

        /// <summary>
        /// Saves the current configuration to the file specified in app.config.
        /// </summary>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        public OperationResult SaveConfiguration()
        {
            return SaveConfiguration(GetConfigurationFileName());
        }

        /// <summary>
        /// Saves the current configuration to the specified file.
        /// </summary>
        /// <param name="fileName">The file in which to save the configuration.</param>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        public OperationResult SaveConfiguration(string fileName)
        {
            OperationResult retVal = SaveConfiguration(Configuration, fileName);
            retVal.LogResult(logger);
            return retVal;
        }

        /// <summary>
        /// Saves the given configuration to the specified file.
        /// </summary>
        /// <param name="configuration">The Configuration object to serialize and write to disk.</param>
        /// <param name="fileName">The file in which to save the configuration.</param>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        public OperationResult SaveConfiguration(ApplicationConfiguration configuration, string fileName)
        {
            OperationResult retVal = new OperationResult();

            try
            {
                logger.Trace("Flushing configuration to disk at '" + fileName + "'.");
                manager.PlatformManager.Platform.WriteFile(fileName, JsonConvert.SerializeObject(configuration, Formatting.Indented));
            }
            catch (Exception ex)
            {
                retVal.AddError("Exception thrown when attempting to save the Configuration to '" + fileName + "': " + ex.Message);
            }

            return retVal;
        }

        /// <summary>
        /// Examines the supplied Configuration for errors and returns the result.  If returning a Warning or Invalid result code,
        /// includes the validation message in the Message member of the return type.
        /// </summary>
        /// <param name="configuration">The Configuration to validate.</param>
        /// <returns>An OperationResult containing the result of the validation.</returns>
        public OperationResult ValidateConfiguration(ApplicationConfiguration configuration)
        {
            // TODO: validate configuration; check for duplicates, etc.
            // issue #1
            return new OperationResult();
        }

        /// <summary>
        /// Manually builds an instance of Configuration with default values.
        /// </summary>
        /// <returns>An OperationResult containing the default instance of a Configuration.</returns>
        public OperationResult<ApplicationConfiguration> BuildNewConfiguration()
        {
            OperationResult<ApplicationConfiguration> retVal = new OperationResult<ApplicationConfiguration>();
            retVal.Result = new ApplicationConfiguration();

            retVal.Result.Symbiote = "0.1.0";

            retVal.Result.Web.Port = 80;
            retVal.Result.Web.Root = "";

            retVal.Result.Model = new ConfigurationModelSection();
            retVal.Result.Model.Items = new List<ConfigurationModelItem>();
            retVal.Result.Model.Items.Add(new ConfigurationModelItem() { FQN = "Symbiote", Definition = new Item("Symbiote", typeof(string)).ToJson(new ContractResolver(ItemSerializationProperties)) });

            retVal.Result.Plugins = new ConfigurationPluginSection();
            retVal.Result.Plugins.AuthorizeNewPlugins = true;
            retVal.Result.Plugins.Assemblies.Add(
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

            retVal.Result.Plugins.Instances.Add(
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
        /// <returns>An OperationResult containing the result of the operation.</returns>
        public OperationResult SetConfigurationFileName(string fileName)
        {
            logger.Info("Setting Configuration filename to '" + fileName + "'...");

            OperationResult retVal = new OperationResult();

            try
            {
                System.Configuration.ConfigurationManager.AppSettings["ConfigurationFileName"] = fileName;
            }
            catch (Exception ex)
            {
                retVal.AddError("Exception thrown attempting to set the Configuration filename: " + ex);
            }

            retVal.LogResult(logger);
            return retVal;
        }

        /// <summary>
        /// Moves the configuration file to a new location and updates the setting in app.config.
        /// </summary>
        /// <param name="newFileName">The fully qualified path to the new file.</param>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        public OperationResult MoveConfigurationFile(string newFileName)
        {
            logger.Info("Moving Configuration file to '" + newFileName + "'...");

            OperationResult retVal = new OperationResult();

            try
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
            catch (Exception ex)
            {
                retVal.AddError("Exception thrown attempting to move the Configuration file: " + ex);
            }

            retVal.LogResult(logger);
            return retVal;
        }

        public OperationResult RegisterType(Type type)
        {
            logger.Debug("Registering type '" + type.Name + "'...");
            OperationResult retVal = new OperationResult();
            try
            {
                // fetch the type's configuration definition using reflection
                ConfigurationDefinition typedef = (ConfigurationDefinition)type.GetMethod("GetConfigurationDefinition").Invoke(null, null);
                retVal = RegisterType(type, typedef);
            }
            catch (NullReferenceException ex)
            {
                retVal.AddError("The retrieved configuration definition was null.");
            }
            catch (Exception ex)
            {
                retVal.AddError("Exception thrown while registering the type: " + ex);
            }

            retVal.LogResult(logger, "Debug");
            return retVal;
        }
        private OperationResult RegisterType(Type type, ConfigurationDefinition definition)
        {
            logger.Trace("Registering type '" + type.Name + "' with definition: " + definition);
            OperationResult retVal = new OperationResult();

            if (!type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IConfigurable<>)))
                retVal.AddError("The provided type '" + type.Name + "' does not implement IConfigurable and can not be registered.");
            else if (type.GetMethod("GetConfigurationDefinition") == default(MethodInfo))
                retVal.AddError("The provided type '" + type.Name + "' is missing the static method 'GetConfigurationDefinition' and can not be registered.");
            else if (type.GetMethod("GetDefaultConfiguration") == default(MethodInfo))
                retVal.AddError("The provided type '" + type.Name + "' is missing the static method 'GetDefaultConfiguration' and can not be registered.");
            else if (!RegisteredTypes.ContainsKey(type))
            {
                try
                {
                    RegisteredTypes.Add(type, definition);
                    logger.Debug("Registered type '" + type.Name + "' for configuration.");
                }
                catch (Exception ex)
                {
                    retVal.AddError("Exception thrown while registering the type: " + ex);
                }

            }

            retVal.LogResult(logger, "Trace");
            return new OperationResult();
        }

        public OperationResult<T> GetConfiguration<T>(Type type, string instanceName = "")
        {
            OperationResult<T> retVal = new OperationResult<T>();

            try
            {
                var rawObject = Configuration.UglyConfiguration[type][instanceName];
                var reSerializedObject = JsonConvert.SerializeObject(rawObject);
                var reDeSerializedObject = JsonConvert.DeserializeObject<T>(reSerializedObject);
                retVal.Result = reDeSerializedObject;
            }
            catch (KeyNotFoundException ex)
            {
                retVal.Result = (T)type.GetMethod("GetDefaultConfiguration").Invoke(null, null);

                if (!Configuration.UglyConfiguration.ContainsKey(type))
                {
                    Configuration.UglyConfiguration.Add(type, new Dictionary<string, object>());
                }
                Configuration.UglyConfiguration[type].Add(instanceName, retVal.Result);
            }
            catch (Exception ex)
            {
                retVal.AddError("Error retrieving and re-serializing the data from the configuration for type '" + type.Name + "', instance '" + instanceName + "'.");
            }
            
            return retVal;
        }



        #endregion
    }
}
