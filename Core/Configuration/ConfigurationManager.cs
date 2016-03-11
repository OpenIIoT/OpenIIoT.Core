using System;
using System.Collections.Generic;
using NLog;
using Newtonsoft.Json;
using Symbiote.Core.Plugin;
using Symbiote.Core.Model;
using Symbiote.Core.Configuration.Model;
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
    public class ConfigurationManager : IManager
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
        public List<string> ItemSerializationProperties { get { return new List<string>(new string[] { "FQN", "SourceAddress", "IsReadable", "IsWriteable" }); } }

        /// <summary>
        /// The current configuration.
        /// </summary>
        public ApplicationConfiguration Configuration { get; private set; }

        /// <summary>
        /// The filename of the configuration file.
        /// </summary>
        public string ConfigurationFileName { get { return GetConfigurationFileName(); } }

        /// <summary>
        /// The list of registered Types
        /// </summary>
        public Dictionary<Type, ConfigurationDefinition> ConfigurableTypes { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Private constructor, only called by Instance()
        /// </summary>
        /// <param name="manager">The ProgramManager instance for the application</param>
        private ConfigurationManager(ProgramManager manager)
        {
            this.manager = manager;
            ConfigurableTypes = new Dictionary<Type, ConfigurationDefinition>();
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
        /// Starts the Configuration Manager.
        /// </summary>
        /// <returns></returns>
        public OperationResult Start()
        {
            logger.Info("Starting the Configuration Manager...");
            OperationResult retVal = new OperationResult();

            retVal.LogResult(logger);
            return retVal;
        }

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
            return retVal;
        }

        /// <summary>
        /// Reads the given file and attempts to deserialize it to an instance of Configuration
        /// </summary>
        /// <param name="fileName">The file to read and deserialize.</param>
        /// <returns>An OperationResult containing the Configuration instance created from the file.</returns>
        private OperationResult<ApplicationConfiguration> LoadConfiguration(string fileName)
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
                validationResult.LogResult(logger, "Debug", "Warn", "Error", "ValidateConfiguration");
                if (validationResult.ResultCode == OperationResultCode.Failure)
                {
                    retVal.AddError("The configuration is not valid. ");
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
            OperationResult retVal = SaveConfiguration(Configuration, GetConfigurationFileName());
            retVal.LogResult(logger);
            return retVal;
        }

        /// <summary>
        /// Saves the given configuration to the specified file.
        /// </summary>
        /// <param name="configuration">The Configuration object to serialize and write to disk.</param>
        /// <param name="fileName">The file in which to save the configuration.</param>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        private OperationResult SaveConfiguration(ApplicationConfiguration configuration, string fileName)
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

            retVal.Result.Model = new ConfigurationModelSection();
            retVal.Result.Model.Items = new List<ConfigurationModelItem>();
            retVal.Result.Model.Items.Add(new ConfigurationModelItem() { FQN = "Symbiote", Definition = new Item("Symbiote", typeof(string)).ToJson(new ContractResolver(ItemSerializationProperties)) });

            return retVal;
        }



        /// <summary>
        /// Evaluates the provided type regarding whether it can be configured and returns the result.
        /// To be configurable, the type must implement IConfigurable and must have static methods GetConfigurationDefinition and 
        /// GetDefaultConfiguration.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public OperationResult<bool> IsConfigurable(Type type)
        {
            logger.Trace("Determining whether type '" + type.Name + "' is configurable...");
            OperationResult<bool> retVal = new OperationResult<bool>();

            if (!type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IConfigurable<>)))
                retVal.AddError("The provided type '" + type.Name + "' does not implement IConfigurable and can not be registered.");
            else if (type.GetMethod("GetConfigurationDefinition") == default(MethodInfo))
                retVal.AddError("The provided type '" + type.Name + "' is missing the static method 'GetConfigurationDefinition' and can not be registered.");
            else if (type.GetMethod("GetDefaultConfiguration") == default(MethodInfo))
                retVal.AddError("The provided type '" + type.Name + "' is missing the static method 'GetDefaultConfiguration' and can not be registered.");

            retVal.Result = (retVal.ResultCode == OperationResultCode.Success);
            if (retVal.ResultCode != OperationResultCode.Success) retVal.LogResult(logger, "Debug", "Warn", "Error");
            return retVal;
        }

        public OperationResult RegisterType(Type type, bool throwExceptionOnFailure = false)
        {
            logger.Debug("Registering type '" + type.Name + "'...");
            OperationResult retVal = new OperationResult();

            if (!IsConfigurable(type).Result)
                retVal.AddError("The requested type '" + type.Name + "' is not configurable.");
            else
            {
                try
                {
                    ConfigurationDefinition typedef = (ConfigurationDefinition)type.GetMethod("GetConfigurationDefinition").Invoke(null, null);
                    if (typedef == default(ConfigurationDefinition))
                        retVal.AddError("The ConfigurationDefinition retrieved from the supplied type is invalid.");
                    else
                        retVal = RegisterType(type, typedef);
                }
                catch (Exception ex)
                {
                    retVal.AddError("Exception thrown while registering the type: " + ex);
                }
            }

            retVal.LogResult(logger, "Debug");

            if (throwExceptionOnFailure)
                throw new Exception("Failed to register the type '" + type.Name + "' for configuration.");

            return retVal;
        }

        private OperationResult RegisterType(Type type, ConfigurationDefinition definition)
        {
            logger.Trace("Registering type '" + type.Name + "' with ConfigurationDefinition: ");
            logger.Trace("\tForm: " + definition.Form);
            logger.Trace("\tSchema: " + definition.Schema);
            logger.Trace("\tModel: " + definition.Model);

            OperationResult retVal = new OperationResult();

            if (!IsConfigurable(type).Result)
                retVal.AddError("The requested type '" + type.Name + "' is not configurable.");
            else if (!ConfigurableTypes.ContainsKey(type))
            {
                try
                {
                    ConfigurableTypes.Add(type, definition);
                    logger.Trace("Registered type '" + type.Name + "' for configuration.");
                }
                catch (Exception ex)
                {
                    retVal.AddError("Exception thrown while registering the type: " + ex);
                }

            }

            return new OperationResult();
        }

        public OperationResult<T> GetConfiguration<T>(Type type, string instanceName = "")
        {
            logger.Trace("Retrieving configuration for type '" + type.Name + "', instance '" + instanceName + "'...");
            OperationResult<T> retVal = new OperationResult<T>();

            if (!IsConfigurable(type).Result)
                retVal.AddError("The requested type '" + type.Name + "' is not configurable.");
            else
            {
                try
                {
                    // json.net needs to know the type when it deserializes; we can't cast or convert after the fact.
                    // the solution is to grab our object, serialize it again, then deserialize it into the required type.
                    var rawObject = Configuration.UglyConfiguration[type][instanceName];
                    var reSerializedObject = JsonConvert.SerializeObject(rawObject);
                    var reDeSerializedObject = JsonConvert.DeserializeObject<T>(reSerializedObject);
                    retVal.Result = reDeSerializedObject;
                }
                catch (KeyNotFoundException)
                {
                    // this exception will be thrown if the dictionary lookup for the type and/or instance name
                    // fails.  if this happens the configuration for the requested type/instance wasn't loaded
                    // from the config file, therefore we want to return the default config.
                    retVal.Result = (T)type.GetMethod("GetDefaultConfiguration").Invoke(null, null);

                    // if the configuration doesn't contain a section for the type, add it
                    if (!Configuration.UglyConfiguration.ContainsKey(type))
                        Configuration.UglyConfiguration.Add(type, new Dictionary<string, object>());

                    // add the default configuration for the requested type/instance to the configuration.
                    Configuration.UglyConfiguration[type].Add(instanceName, retVal.Result);
                }
                catch (Exception ex)
                {
                    retVal.AddError("Error retrieving and re-serializing the data from the configuration for type '" + type.Name + "', instance '" + instanceName + "': " + ex);
                }
            }


            return retVal;
        }

        public OperationResult SaveConfiguration(Type type, object configuration, string instanceName = "")
        {
            logger.Trace("Saving configuration for type '" + type.Name + "', instance '" + instanceName + "'...");
            OperationResult retVal = new OperationResult();

            if (!IsConfigurable(type).Result)
                retVal.AddError("The specified type '" + type.Name + "' is not configurable.");
            else
            {
                try
                {
                    Configuration.UglyConfiguration[type][instanceName] = configuration;
                }
                catch (Exception ex)
                {
                    retVal.AddError("Error saving configuration: " + ex);
                }
            }
            return retVal;
        }
        #endregion

        #region Static Methods

        /// <summary>
        /// Returns the fully qualified path to the configuration file incluidng file name and extension.
        /// </summary>
        /// <returns>The fully qualified path, filename and extension of the configuration file.</returns>
        public static string GetConfigurationFileName()
        {
            string retVal = Utility.GetSetting("ConfigurationFileName");

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
        public static string GetConfigurationFileDrive()
        {
            return System.IO.Path.GetPathRoot(GetConfigurationFileName());
        }

        /// <summary>
        /// Sets or updates the configuration file location setting in app.config
        /// </summary>
        /// <param name="fileName">The fully qualified path to the configuration file.</param>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        public static OperationResult SetConfigurationFileName(string fileName)
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
        public static OperationResult MoveConfigurationFile(string newFileName)
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

        #endregion
    }
}
