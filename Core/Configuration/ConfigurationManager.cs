using System;
using System.Collections.Generic;
using NLog;
using Newtonsoft.Json;
using System.Linq;
using System.Reflection;

namespace Symbiote.Core.Configuration
{
    /// <summary>
    /// The Configuration namespace encapsulates the Configuration Manager and the classes and interfaces used by various application
    /// components to allow the configuration of application level objects.
    /// 
    /// The Configuration file is generated from the json serialization of the Configuration model.  The Configuration model consists of
    /// a single instance of type Dictionary(Type, Dictionary(string, object)).  This instance creates a nested dictionary keyed on type
    /// first, then by name.  The resulting key value pair contains the Configuration object for the specified Type and named instance.
    /// 
    /// There are two main types of configuration supported by this scheme; configuration for static objects like the various application
    /// Managers and Services, and for dynamic objects encompassed by Plugins; namely Endpoints and Connectors.  The key difference is the 
    /// number of instances of each; static objects will have only one instance while the Plugin objects may have any number.  Static objects 
    /// do not supply an instance name when using the Configuration Manager, and their configuration is saved within the model with an empty
    /// string.  Dynamic objects must supply an instance name.
    /// 
    /// The Configuration file maintained by the Configuration Manager is capable of being rebuilt from scratch.  If missing, the Manager
    /// automatically adds a default, nameless instance of each registered type to the configuration model and flushes it to disk before
    /// loading it.  This ensures the application can start normally in the event of a deletion.
    /// 
    /// The method IsConfigurable uses reflection to examine the given Type to ensure that:
    ///     1. it implements IConfigurable
    ///     2. it contains the static method GetConfigurationDefinition
    ///     3. it contains the static method GetDefaultConfiguration
    ///     
    /// If all three predicates are true, the Type can be registered with the Configuration Manager and instances of that type can load 
    /// and save configuration data.
    /// 
    /// Before any Type can use the Configuration Manager, the method RegisterType() must be called and passed the Type of that class.
    /// This method checks IsConfigurable and if passing, fetches the ConfigurationDefinition for the Type from the static method
    /// GetConfigurationDefinition and stores the Type and the ConfigurationDefinition in the RegisteredTypes dictionary.
    /// 
    /// The GetInstanceConfiguration(T) method is called by configurable instances to retrieve the saved configuration for the calling
    /// class and instance.  By default, if the configuration is not found the default configuration is retrieved from the calling class
    /// and returned to the caller.  
    /// </summary>
    [System.Runtime.CompilerServices.CompilerGenerated]
    class NamespaceDoc { }

    /// <summary>
    /// The Configuration Manager class manages the configuration file for the application.
    /// </summary>
    public class ConfigurationManager : IManager
    {
        #region Variables

        /// <summary>
        /// The Logger for this class.
        /// </summary>
        private static xLogger logger = (xLogger)LogManager.GetCurrentClassLogger(typeof(xLogger));

        /// <summary>
        /// The ProgramManager for the application.
        /// </summary>
        private ProgramManager manager;
        
        /// <summary>
        /// The Singleton instance of ConfigurationManager.
        /// </summary>
        private static ConfigurationManager instance;

        #endregion

        #region Properties

        #region IManager Implementation

        /// <summary>
        /// The state of the Manager.
        /// </summary>
        public ManagerState State { get; private set; }

        #endregion

        /// <summary>
        /// The current configuration.
        /// </summary>
        public Dictionary<Type, Dictionary<string, object>> Configuration { get; private set; }

        /// <summary>
        /// The filename of the configuration file.
        /// </summary>
        public string ConfigurationFileName { get; private set; }

        /// <summary>
        /// A dictionary containing all registered configuratble types and their ConfigurationDefinitions.
        /// </summary>
        public Dictionary<Type, ConfigurationDefinition> RegisteredTypes { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Private constructor, only called by Instance()
        /// </summary>
        /// <param name="manager">The ProgramManager instance for the application.</param>
        private ConfigurationManager(ProgramManager manager)
        {
            this.manager = manager;
            RegisteredTypes = new Dictionary<Type, ConfigurationDefinition>();
            ConfigurationFileName = GetConfigurationFileName();
        }

        /// <summary>
        /// Instantiates and/or returns the ConfigurationManager instance.
        /// </summary>
        /// <param name="manager">The ProgramManager instance for the application.</param>
        /// <returns>The Singleton instance of the ConfigurationManager.</returns>
        internal static ConfigurationManager Instance(ProgramManager manager)
        {
            if (instance == null)
                instance = new ConfigurationManager(manager);

            return instance;
        }

        #endregion

        #region Instance Methods

        #region IManager Implementation

        /// <summary>
        /// Starts the Configuration Manager.
        /// </summary>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        public OperationResult Start()
        {
            Guid guid = logger.EnterMethod(true);

            logger.Info("Starting the Configuration Manager...");
            OperationResult retVal = new OperationResult();

            State = ManagerState.Starting;

            #region Configuration File Validation/Generation

            //------------------------------ - -           ---
            // check whether the configuration file exists and if it doesn't, build it from scratch.
            if (!manager.Platform.FileExists(ConfigurationFileName))
            {
                logger.Info("The configuration file '" + ConfigurationFileName + "' could not be found.  Rebuilding...");
                OperationResult<Dictionary<Type, Dictionary<string, object>>> buildResult = BuildNewConfiguration();

                if (buildResult.ResultCode != OperationResultCode.Failure)
                {
                    // the replacement configuration was built successfully; print the result.
                    buildResult.LogResult(logger, "BuildNewConfiguration");

                    // try to save the new configuration to file
                    logger.Info("Saving the new configuration to '" + ConfigurationFileName + "'...");
                    OperationResult saveResult = SaveConfiguration(buildResult.Result);

                    if (saveResult.ResultCode != OperationResultCode.Failure)
                    {
                        // the file saved properly.  print the result and a final confirmation.
                        saveResult.LogResult(logger, "SaveConfiguration");
                        logger.Info("Saved the new configuration to '" + ConfigurationFileName + "'.");
                    }
                    else
                        throw new Exception("Failed to save the new configuration: " + saveResult.LastErrorMessage());
                }
                else
                    throw new Exception("The configuration file was missing and the application failed to build a replacement: " + buildResult.LastErrorMessage());
            }

            logger.Checkpoint("Configuration file validated/generated", guid);
            //--------- - ----------- - - -------------------------------------------------- - - 

            #endregion

            #region Configuration Loading for Validation

            //----------------------- - --
            // load the configuration.
            OperationResult<Dictionary<Type, Dictionary<string, object>>> loadResult = LoadConfiguration();

            if (loadResult.ResultCode == OperationResultCode.Failure)
                throw new Exception("Failed to load the configuration: " + loadResult.LastErrorMessage());

            retVal.Incorporate(loadResult);

            logger.Checkpoint("Configuration loaded for validation", guid);
            //------------------------------------ - -

            #endregion

            #region Configuration Validation

            //-------------------- - ------- - - - - -- 
            // validate the configuration.
            OperationResult validationResult = ValidateConfiguration(Configuration);

            if (validationResult.ResultCode == OperationResultCode.Failure)
                throw new Exception("The loaded configuration is invalid: " + validationResult.LastErrorMessage());

            retVal.Incorporate(validationResult);

            logger.Checkpoint("Configuration validated", guid);
            //--------- - - - - -    - - -   ----------- - - -

            #endregion

            // attach the configuration
            if (retVal.ResultCode != OperationResultCode.Failure)
            {
                Configuration = loadResult.Result;
                State = ManagerState.Running;
            }
            else
                State = ManagerState.Faulted;

            retVal.LogResult(logger);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        /// <summary>
        /// Restarts the Configuration manager.
        /// </summary>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        public OperationResult Restart()
        {
            Guid guid = logger.EnterMethod(true);

            logger.Info("Restarting the Configuration Manager...");
            OperationResult retVal = new OperationResult();

            retVal.Incorporate(Stop());
            retVal.Incorporate(Start());

            retVal.LogResult(logger);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        /// <summary>
        /// Stops the Configuration manager.
        /// </summary>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        public OperationResult Stop()
        {
            logger.EnterMethod();

            logger.Info("Stopping the Configuration Manager...");
            OperationResult retVal = new OperationResult();

            State = ManagerState.Stopping;

            if (retVal.ResultCode != OperationResultCode.Failure)
                State = ManagerState.Stopped;
            else
                State = ManagerState.Faulted;

            retVal.LogResult(logger);
            logger.ExitMethod(retVal);
            return retVal;
        }

        #endregion

        #region Configuration Management

        /// <summary>
        /// Loads the configuration from the file specified in the ConfigurationFileName property.
        /// </summary>
        /// <returns>An OperationResult containing the result of the operation and the instance of Configuration containing the loaded configuration.</returns>
        private OperationResult<Dictionary<Type, Dictionary<string, object>>> LoadConfiguration()
        {
            return LoadConfiguration(ConfigurationFileName);
        }

        /// <summary>
        /// Reads the given file and attempts to deserialize it to an instance of Configuration.
        /// </summary>
        /// <param name="fileName">The file to read and deserialize.</param>
        /// <returns>An OperationResult containing the result of the operation and the Configuration instance created from the file.</returns>
        private OperationResult<Dictionary<Type, Dictionary<string, object>>> LoadConfiguration(string fileName)
        {
            Guid guid = logger.EnterMethod(xLogger.Params(fileName), true);

            logger.Info("Loading configuration from '" + fileName + "'...");
            OperationResult<Dictionary<Type, Dictionary<string, object>>> retVal = new OperationResult<Dictionary<Type, Dictionary<string, object>>>();

            string configFile = "";

            try
            {
                // read the entirety of the configuration file into configFile
                configFile = manager.PlatformManager.Platform.ReadFile(fileName).Result;
                logger.Trace("Configuration file loaded from '" + fileName + "'.  Attempting to deserialize...");

                // attempt to deserialize the contents of the file to an object of type ApplicationConfiguration
                retVal.Result = JsonConvert.DeserializeObject<Dictionary<Type, Dictionary<string, object>>>(configFile);
                logger.Trace("Successfully deserialized the contents of '" + fileName + "' to a Configuration object.");
            }
            catch (Exception ex)
            {
                retVal.AddError("Exception thrown while loading Configuration from '" + fileName + "': " + ex);
                logger.Exception(logger.Error, ex, xLogger.Vars(configFile), xLogger.Names("configFile"), guid);
            }

            retVal.LogResult(logger);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        /// <summary>
        /// Saves the current configuration to the file specified in app.exe.config.
        /// </summary>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        public OperationResult SaveConfiguration()
        {
            logger.Info("Saving configuration...");
            OperationResult retVal = SaveConfiguration(Configuration, ConfigurationFileName);
            retVal.LogResult(logger);
            return retVal;
        }

        /// <summary>
        /// Saves the provided configuration to the file specified in app.exe.config.
        /// </summary>
        /// <param name="configuration">The Configuration instance to save.</param>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        private OperationResult SaveConfiguration(Dictionary<Type, Dictionary<string, object>> configuration)
        {
            logger.Info("Saving specified configuration to '" + ConfigurationFileName + "'...");
            OperationResult retVal = SaveConfiguration(configuration, ConfigurationFileName);
            retVal.LogResult(logger);
            return retVal;
        }

        /// <summary>
        /// Saves the given configuration to the specified file.
        /// </summary>
        /// <param name="configuration">The Configuration object to serialize and write to disk.</param>
        /// <param name="fileName">The file in which to save the configuration.</param>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        private OperationResult SaveConfiguration(Dictionary<Type, Dictionary<string, object>> configuration, string fileName)
        {
            Guid guid = logger.EnterMethod(xLogger.Params(configuration, fileName), true);

            logger.Info("Saving configuration to '" + fileName + "'...");
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

            retVal.LogResult(logger);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        /// <summary>
        /// Validates the current configuration.
        /// </summary>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        public OperationResult ValidateConfiguration()
        {
            return ValidateConfiguration(Configuration);
        }

        /// <summary>
        /// Examines the supplied Configuration for errors and returns the result.  If returning a Warning or Invalid result code,
        /// includes the validation message in the Message member of the return type.
        /// </summary>
        /// <param name="configuration">The Configuration to validate.</param>
        /// <returns>An OperationResult containing the result of the validation.</returns>
        private OperationResult ValidateConfiguration(Dictionary<Type, Dictionary<string, object>> configuration)
        {
            logger.EnterMethod();

            logger.Info("Validating configuration...");
            OperationResult retVal = new OperationResult();

            //TODO: implement this

            retVal.LogResult(logger);
            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        /// Manually builds an instance of Configuration with default values.
        /// </summary>
        /// <returns>An OperationResult containing the default instance of a Configuration.</returns>
        private OperationResult<Dictionary<Type, Dictionary<string, object>>> BuildNewConfiguration()
        {
            logger.EnterMethod();

            OperationResult<Dictionary<Type, Dictionary<string, object>>> retVal = new OperationResult<Dictionary<Type, Dictionary<string, object>>>();
            retVal.Result = new Dictionary<Type, Dictionary<string, object>>();

            logger.ExitMethod();
            return retVal;
        }

        #endregion

        #region Instance Registration

        /// <summary>
        /// Evaluates the provided type regarding whether it can be configured and returns the result.
        /// To be configurable, the type must implement IConfigurable and must have static methods GetConfigurationDefinition and 
        /// GetDefaultConfiguration.
        /// </summary>
        /// <param name="type">The Type to evaluate.</param>
        /// <returns>An OperationResult</returns>
        public OperationResult<bool> IsConfigurable(Type type)
        {
            logger.EnterMethod(xLogger.Params(type));
        
            OperationResult<bool> retVal = new OperationResult<bool>();
            retVal.Result = true;

            if (!type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IConfigurable<>)))
                retVal.AddError("The provided type '" + type.Name + "' does not implement IConfigurable.");

            if (type.GetMethod("GetConfigurationDefinition") == default(MethodInfo))
                retVal.AddError("The provided type '" + type.Name + "' is missing the static method 'GetConfigurationDefinition'");

            if (type.GetMethod("GetDefaultConfiguration") == default(MethodInfo))
                retVal.AddError("The provided type '" + type.Name + "' is missing the static method 'GetDefaultConfiguration'");

            if (retVal.ResultCode == OperationResultCode.Failure)
            {
                retVal.AddError("The type '" + type.Name + "' can not be registered.");
                retVal.Result = false;
            }

            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        /// Checks to see if the supplied Type is in the RegisteredTypes dictionary.
        /// </summary>
        /// <param name="type">The Type to check.</param>
        /// <returns>An OperationResult containing the result of the operation and a boolean indicating whether the specified Type was found in the dictionary.</returns>
        public OperationResult<bool> IsRegistered(Type type)
        {
            logger.EnterMethod(xLogger.Params(type));
            OperationResult<bool> retVal = new OperationResult<bool>();

            // the type is registered if it exists within the RegisteredTypes dictionary
            retVal.Result = RegisteredTypes.ContainsKey(type);

            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        /// Registers the supplied Type with the Configuration Manager.
        /// </summary>
        /// <remarks>When called during application startup, throwExceptionOnFailure should be set to true.</remarks>
        /// <param name="type">The Type to register.</param>
        /// <param name="throwExceptionOnFailure">If true, throws an exception on failure.</param>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        public OperationResult RegisterType(Type type, bool throwExceptionOnFailure = false)
        {
            logger.EnterMethod(xLogger.Params(type, throwExceptionOnFailure));

            logger.Debug("Registering type '" + type.Name + "'...");
            OperationResult retVal = new OperationResult();

            // ensure the provided Type is configurable
            OperationResult<bool> checkResult = IsConfigurable(type);

            if (!checkResult.Result)
                retVal.Incorporate(checkResult);
            else
            {
                // the type is configurable; try to get the configuration definition
                try
                {
                    ConfigurationDefinition typedef = (ConfigurationDefinition)type.GetMethod("GetConfigurationDefinition").Invoke(null, null);
                    if (typedef == default(ConfigurationDefinition))
                        retVal.AddError("The ConfigurationDefinition retrieved from the supplied type is invalid.");
                    else
                        retVal = RegisterType(type, typedef, RegisteredTypes);
                }
                catch (Exception ex)
                {
                    retVal.AddError("Exception thrown while registering the type: " + ex);
                }
            }

            if (retVal.ResultCode == OperationResultCode.Failure)
                retVal.LogResult(logger);
            else
                retVal.LogResult(logger.Debug);

            if (throwExceptionOnFailure)
                throw new Exception("Failed to register the type '" + type.Name + "' for configuration.");

            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        /// Registers the supplied Type with the Configuration Manager using the supplied ConfigurationDefiniton.
        /// </summary>
        /// <param name="type">The Type to register.</param>
        /// <param name="definition">The ConfigurationDefintion with which to register the Type.</param>
        /// <param name="registeredTypes">The Dictionary of registered types.</param>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        private OperationResult RegisterType(Type type, ConfigurationDefinition definition, Dictionary<Type, ConfigurationDefinition> registeredTypes)
        {
            logger.EnterMethod();
            logger.Trace("Registering type '" + type.Name + "'...");

            OperationResult retVal = new OperationResult();

            // check to ensure that the type hasn't already been registered
            if (!registeredTypes.ContainsKey(type))
            {
                try
                {
                    registeredTypes.Add(type, definition);
                    logger.Debug("Registered type '" + type.Name + "' for configuration.");
                }
                catch (Exception ex)
                {
                    retVal.AddError("Exception thrown while registering the type: " + ex);
                }
            }
            else
                retVal.AddWarning("The Type '" + type.Name + "' has already been registered.  Ignoring.");

            logger.ExitMethod(retVal);
            return retVal;
        }

        #endregion

        #region Instance Configuration Management

        /// <summary>
        /// Determines whether the specified instance of the specified type is configured.
        /// </summary>
        /// <param name="type">The Type of the instance to check.</param>
        /// <param name="instanceName">The name of the instance to check.</param>
        /// <returns>An OperationResult containing the result of the operation and a boolean containing the outcome of the lookup.</returns>
        public OperationResult<bool> IsConfigured(Type type, string instanceName = "")
        {
            return IsConfigured(type, Configuration, instanceName);
        }

        /// <summary>
        /// Determines whether the specified instance of the specified type is configured.
        /// </summary>
        /// <param name="type">The Type of the instance to check.</param>
        /// <param name="configuration">The ApplicationConfiguration to examine.</param>
        /// <param name="instanceName">The name of the instance to check.</param>
        /// <returns>An OperationResult containing the result of the operation and a boolean containing the outcome of the lookup.</returns>
        private OperationResult<bool> IsConfigured(Type type, Dictionary<Type, Dictionary<string, object>> configuration, string instanceName = "")
        {
            logger.EnterMethod(xLogger.Params(type, new xLogger.ExcludedParam(), instanceName));

            OperationResult<bool> retVal = new OperationResult<bool>();

            // check to see if the type is in the comfiguration
            if (configuration.ContainsKey(type))
            {
                // check to see if the specified instance is in the type configuration
                if (!configuration[type].ContainsKey(instanceName))
                    retVal.AddError("The specified instance name '" + instanceName + "' wasn't found in the configuration for type '" + type.Name + "'.");
            }
            else
                retVal.AddError("The specified type '" + type.Name + "' was not found in the configuration.");

            // if any messages were generated the configuration wasn't found, so return false.
            retVal.Result = (retVal.ResultCode != OperationResultCode.Failure);

            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        /// Adds the specified configuration to the specified instance of the specified type.
        /// </summary>
        /// <param name="type">The Type of the instance to be configured.</param>
        /// <param name="instanceConfiguration">The Configuration instance of the configuration model of the calling class.</param>
        /// <param name="instanceName">The name of the instance to configure.</param>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        public OperationResult<T> AddInstanceConfiguration<T>(Type type, object instanceConfiguration, string instanceName = "")
        {
            return AddInstanceConfiguration<T>(type, instanceConfiguration, Configuration, instanceName);
        }

        /// <summary>
        /// Adds the specified configuration to the specified instance of the specified type.
        /// </summary>
        /// <param name="type">The Type of the instance to be configured.</param>
        /// <param name="configuration">The Configuration instance of the configuration model of the calling class.</param>
        /// <param name="instanceConfiguration">The ApplicationConfiguration instance to which to add the new configuration.</param>
        /// <param name="instanceName">The name of the instance to configure.</param>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        private OperationResult<T> AddInstanceConfiguration<T>(Type type, object instanceConfiguration, Dictionary<Type, Dictionary<string, object>> configuration, string instanceName = "")
        {
            logger.EnterMethod(xLogger.Params(type, new xLogger.ExcludedParam(), instanceName));

            OperationResult<T> retVal = new OperationResult<T>();

            if (!IsConfigurable(type).Result)
                retVal.AddError("The type '" + type.Name + "' is not configurable.");
            else if (!IsRegistered(type).Result)
                retVal.AddError("The type '" + type.Name + "' is configurable but has not been registered.");
            // ensure the configuration doesn't already exist
            else if (!IsConfigured(type, instanceName).Result)
            {
                logger.Trace("Inserting configuration into the Configuration dictionary...");
                // if the configuration doesn't contain a section for the type, add it
                if (!configuration.ContainsKey(type))
                    configuration.Add(type, new Dictionary<string, object>());

                // add the default configuration for the requested type/instance to the configuration.
                configuration[type].Add(instanceName, instanceConfiguration);

                retVal.Result = (T)instanceConfiguration;

                logger.Trace("The configuration was inserted successfully.");
            }
            else
                retVal.AddError("The configuration for instance '" + instanceName + "' of type '" + type.Name + "' already exists.");

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        /// Retrieves the configuration for the instance matching instanceName of the supplied Type.
        /// If the configuration can't be found, returns the default configuration for the Type.
        /// </summary>
        /// <typeparam name="T">The Type matching the Configuration model for the calling class.</typeparam>
        /// <param name="type">The Type of the calling class.</param>
        /// <param name="instanceName">The name of the instance for which to retrieve the configuration.</param>
        /// <returns>An OperationResult containing the result of the operation and an instance of the Configuration model 
        /// for the calling class containing the retrieved configuration.</returns>
        public OperationResult<T> GetInstanceConfiguration<T>(Type type, string instanceName = "")
        {
            return GetInstanceConfiguration<T>(type, Configuration, instanceName);
        }

        /// <summary>
        /// Retrieves the configuration for the instance matching instanceName of the supplied Type.
        /// If the configuration can't be found, returns the default configuration for the Type.
        /// </summary>
        /// <typeparam name="T">The Type matching the Configuration model for the calling class.</typeparam>
        /// <param name="type">The Type of the calling class.</param>
        /// <param name="configuration">The ApplicationConfiguration from which to retrieve the configuration.</param>
        /// <param name="instanceName">The name of the instance for which to retrieve the configuration.</param>
        /// <returns>An OperationResult containing the result of the operation and an instance of the Configuration model 
        /// for the calling class containing the retrieved configuration.</returns>
        private OperationResult<T> GetInstanceConfiguration<T>(Type type, Dictionary<Type, Dictionary<string, object>> configuration, string instanceName = "")
        {
            logger.EnterMethod(xLogger.Params(type, new xLogger.ExcludedParam(), instanceName));

            OperationResult<T> retVal = new OperationResult<T>();

            // ensure the specified type and instance is configured
            if (IsConfigured(type, instanceName).Result)
            {
                try
                {
                    // json.net needs to know the type when it deserializes; we can't cast or convert after the fact.
                    // the solution is to grab our object, serialize it again, then deserialize it into the required type.
                    var rawObject = configuration[type][instanceName];
                    var reSerializedObject = JsonConvert.SerializeObject(rawObject);
                    var reDeSerializedObject = JsonConvert.DeserializeObject<T>(reSerializedObject);
                    retVal.Result = reDeSerializedObject;
                }
                catch (Exception ex)
                {
                    retVal.AddError("Error retrieving and re-serializing the data from the configuration for type '" + type.Name + "', instance '" + instanceName + "': " + ex);
                }
            }
            else
                retVal.AddError("The specified type '" + type.Name + "' is not configured.");

            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        /// Saves the specified Configuration model to the Configuration for the specified instance and Type.
        /// </summary>
        /// <param name="type">The Type of the calling class.</param>
        /// <param name="instanceConfiguration">The Configuration model to save.</param>
        /// <param name="instanceName">The instance of the calling class for which to save the configuration.</param>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        public OperationResult UpdateInstanceConfiguration(Type type, object instanceConfiguration, string instanceName = "")
        {
            return UpdateInstanceConfiguration(type, instanceConfiguration, Configuration, instanceName);
        }

        /// <summary>
        /// Saves the specified Configuration model to the Configuration for the specified instance and Type.
        /// </summary>
        /// <param name="type">The Type of the calling class.</param>
        /// <param name="instanceConfiguration">The Configuration model to save.</param>
        /// <param name="configuration">The ApplicationConfiguration to update.</param>
        /// <param name="instanceName">The instance of the calling class for which to save the configuration.</param>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        private OperationResult UpdateInstanceConfiguration(Type type, object instanceConfiguration, Dictionary<Type, Dictionary<string, object>> configuration, string instanceName = "")
        {
            logger.EnterMethod(xLogger.Params(type, instanceConfiguration, new xLogger.ExcludedParam(), instanceName));

            logger.Debug("Updating configuration for instance '" + instanceName + "' of type '" + type.Name + "'...");
            OperationResult retVal = new OperationResult();

            if (IsConfigured(type, instanceName).Result)
                configuration[type][instanceName] = instanceConfiguration;
            else
                retVal.AddError("The specified instance '" + instanceName + "' of type '" + type.Name + "' was not found in the configuration.");

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        /// Removes the specified instance of the specified type from the configuration.
        /// </summary>
        /// <param name="type">The Type of instance to remove.</param>
        /// <param name="instanceName">The name of the instance to remove from the Type.</param>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        public OperationResult RemoveInstanceConfiguration(Type type, string instanceName = "")
        {
            return RemoveInstanceConfiguration(type, Configuration, instanceName);
        }

        /// <summary>
        /// Removes the specified instance of the specified type from the configuration.
        /// </summary>
        /// <param name="type">The Type of instance to remove.</param>
        /// <param name="configuration">The ApplicationConfiguration from which to remove the configuration.</param>
        /// <param name="instanceName">The name of the instance to remove from the Type.</param>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        private OperationResult RemoveInstanceConfiguration(Type type, Dictionary<Type, Dictionary<string, object>> configuration, string instanceName = "")
        {
            logger.EnterMethod(xLogger.Params(type, configuration, instanceName));

            logger.Debug("Removing configuration for instance '" + instanceName + "' of type '" + type.Name + "'...");
            OperationResult retVal = new OperationResult();

            if (IsConfigured(type, instanceName).Result)
                configuration[type].Remove(instanceName);
            else
                retVal.AddError("The specified instance '" + instanceName + "' of type '" + type.Name + "' was not found in the configuration.");

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal);
            return retVal;
        }

        #endregion

        #endregion

        #region Static Methods

        /// <summary>
        /// Returns the fully qualified path to the configuration file incluidng file name and extension.
        /// </summary>
        /// <returns>The fully qualified path, filename and extension of the configuration file.</returns>
        public static string GetConfigurationFileName()
        {
            return Utility.GetSetting("ConfigurationFileName", "Symbiote.json").Replace('|', System.IO.Path.DirectorySeparatorChar);
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
