/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀ 
      █   
      █   ▄████████                                                                                                         ▄▄▄▄███▄▄▄▄                                                             
      █   ███    ███                                                                                                      ▄██▀▀▀███▀▀▀██▄                                                           
      █   ███    █▀   ██████  ██▄▄▄▄     ▄█████  █     ▄████▄  ██   █     █████   ▄█████      ██     █   ██████  ██▄▄▄▄   ███   ███   ███   ▄█████  ██▄▄▄▄    ▄█████     ▄████▄     ▄█████    █████ 
      █   ███        ██    ██ ██▀▀▀█▄   ██   ▀█ ██    ██    ▀  ██   ██   ██  ██   ██   ██ ▀███████▄ ██  ██    ██ ██▀▀▀█▄  ███   ███   ███   ██   ██ ██▀▀▀█▄   ██   ██   ██    ▀    ██   █    ██  ██ 
      █   ███        ██    ██ ██   ██  ▄██▄▄    ██▌  ▄██       ██   ██  ▄██▄▄█▀   ██   ██     ██  ▀ ██▌ ██    ██ ██   ██  ███   ███   ███   ██   ██ ██   ██   ██   ██  ▄██        ▄██▄▄     ▄██▄▄█▀ 
      █   ███    █▄  ██    ██ ██   ██ ▀▀██▀▀    ██  ▀▀██ ███▄  ██   ██ ▀███████ ▀████████     ██    ██  ██    ██ ██   ██  ███   ███   ███ ▀████████ ██   ██ ▀████████ ▀▀██ ███▄  ▀▀██▀▀    ▀███████ 
      █   ███    ███ ██    ██ ██   ██   ██      ██    ██    ██ ██   ██   ██  ██   ██   ██     ██    ██  ██    ██ ██   ██  ███   ███   ███   ██   ██ ██   ██   ██   ██   ██    ██   ██   █    ██  ██ 
      █   ████████▀   ██████   █   █    ██      █     ██████▀  ██████    ██  ██   ██   █▀    ▄██▀   █    ██████   █   █    ▀█   ███   █▀    ██   █▀  █   █    ██   █▀   ██████▀    ███████   ██  ██ 
      █   
 ▄ ▄▄ █ ▄▄▄▄▄▄▄▄▄  ▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄ 
 █ ██ █ █████████  ████ ██████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █ 
      █  
      █  
      █  
      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██ 
                                                                                                   ██ 
                                                                                               ▀█▄ ██ ▄█▀ 
                                                                                                 ▀████▀   
                                                                                                   ▀▀                            */

using System;
using System.Collections.Generic;
using NLog;
using Newtonsoft.Json;
using System.Linq;
using System.Reflection;
using Symbiote.Core.Platform;

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
    public class ConfigurationManager : IStateful, IManager, IConfigurationManager
    {
        #region Variables

        /// <summary>
        /// The Logger for this class.
        /// </summary>
        private static xLogger logger = (xLogger)LogManager.GetCurrentClassLogger(typeof(xLogger));

        /// <summary>
        /// The ProgramManager for the application.
        /// </summary>
        private IProgramManager manager;

        /// <summary>
        /// The PlatformManager for the application.
        /// </summary>
        private IPlatformManager platformManager;
        
        /// <summary>
        /// The Singleton instance of ConfigurationManager.
        /// </summary>
        private static ConfigurationManager instance;

        #region Locks

        /// <summary>
        /// Lock for the State property.
        /// </summary>
        private object StateLock = new object();

        #endregion

        #endregion

        #region Properties

        #region IStateful Implementation

        /// <summary>
        /// The state of the Manager.
        /// </summary>
        public State State { get; private set; }

        #endregion

        /// <summary>
        /// The current configuration.
        /// </summary>
        public Dictionary<string, Dictionary<string, object>> Configuration { get; private set; }

        /// <summary>
        /// The filename of the configuration file.
        /// </summary>
        public string ConfigurationFileName { get; private set; }

        /// <summary>
        /// A dictionary containing all registered configuratble types and their ConfigurationDefinitions.
        /// </summary>
        public Dictionary<string, ConfigurationDefinition> RegisteredTypes { get; private set; }

        #endregion

        #region Events

        #region IManager Events

        /// <summary>
        /// Fired when the State property changes.
        /// </summary>
        public event EventHandler<StateChangedEventArgs> StateChanged;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Private constructor, only called by Instance()
        /// </summary>
        /// <param name="manager">The ProgramManager instance for the application.</param>
        /// <param name="platformManager">The PlatformManager instance for the application.</param>
        private ConfigurationManager(IProgramManager manager, IPlatformManager platformManager)
        {
            this.manager = manager;
            this.platformManager = platformManager;

            RegisteredTypes = new Dictionary<string, ConfigurationDefinition>();
            ConfigurationFileName = GetConfigurationFileName();

            ChangeState(State.Initialized);
        }

        /// <summary>
        /// Instantiates and/or returns the ConfigurationManager instance.
        /// </summary>
        /// <remarks>
        /// Invoked via reflection from ProgramManager.  The parameters are used to build an array of IManager parameters which are then passed
        /// to this method.  To specify additional dependencies simply insert them into the parameter list for the method and they will be 
        /// injected when the method is invoked.
        /// </remarks>
        /// <param name="manager">The ProgramManager instance for the application.</param>
        /// <param name="platformManager">The PlatformManager instance for the application.</param>
        /// <returns>The Singleton instance of the ConfigurationManager.</returns>
        private static ConfigurationManager Instantiate(IProgramManager manager, IPlatformManager platformManager)
        {
            if (instance == null)
                instance = new ConfigurationManager(manager, platformManager);

            return instance;
        }

        #endregion

        #region Instance Methods

        #region IStateful Implementation

        /// <summary>
        /// Starts the Configuration Manager.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result Start()
        {
            Guid guid = logger.EnterMethod(true);

            logger.Info("Starting the Configuration Manager...");
            Result retVal = new Result();

            ChangeState(State.Starting);

            #region Configuration File Validation/Generation

            //------------------------------ - -           ---
            // check whether the configuration file exists and if it doesn't, build it from scratch.
            if (!platformManager.Platform.FileExists(ConfigurationFileName))
            {
                logger.Info("The configuration file '" + ConfigurationFileName + "' could not be found.  Rebuilding...");
                Result<Dictionary<string, Dictionary<string, object>>> buildResult = BuildNewConfiguration();

                if (buildResult.ResultCode != ResultCode.Failure)
                {
                    // the replacement configuration was built successfully; print the result.
                    buildResult.LogResult(logger, "BuildNewConfiguration");

                    // try to save the new configuration to file
                    logger.Info("Saving the new configuration to '" + ConfigurationFileName + "'...");
                    Result saveResult = SaveConfiguration(buildResult.ReturnValue);

                    if (saveResult.ResultCode != ResultCode.Failure)
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
            Result<Dictionary<string, Dictionary<string, object>>> loadResult = LoadConfiguration();

            if (loadResult.ResultCode == ResultCode.Failure)
                throw new Exception("Failed to load the configuration: " + loadResult.LastErrorMessage());

            retVal.Incorporate(loadResult);

            logger.Checkpoint("Configuration loaded for validation", guid);
            //------------------------------------ - -

            #endregion

            #region Configuration Validation

            //-------------------- - ------- - - - - -- 
            // validate the configuration.
            Result validationResult = ValidateConfiguration(Configuration);

            if (validationResult.ResultCode == ResultCode.Failure)
                throw new Exception("The loaded configuration is invalid: " + validationResult.LastErrorMessage());

            retVal.Incorporate(validationResult);

            logger.Checkpoint("Configuration validated", guid);
            //--------- - - - - -    - - -   ----------- - - -

            #endregion

            // attach the configuration
            if (retVal.ResultCode != ResultCode.Failure)
            {
                Configuration = loadResult.ReturnValue;
                ChangeState(State.Running);
            }
            else
                ChangeState(State.Faulted, retVal.LastErrorMessage());

            retVal.LogResult(logger);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        /// <summary>
        /// Restarts the Configuration manager.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result Restart(StopType stopType = StopType.Normal)
        {
            Guid guid = logger.EnterMethod(true);

            logger.Info("Restarting the Configuration Manager...");
            Result retVal = new Result();

            retVal.Incorporate(Stop(stopType));
            retVal.Incorporate(Start());

            retVal.LogResult(logger);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        /// <summary>
        /// Stops the Configuration manager.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result Stop(StopType stopType = StopType.Normal)
        {
            logger.EnterMethod();

            logger.Info("Stopping the Configuration Manager...");
            Result retVal = new Result();

            ChangeState(State.Stopping);

            if (stopType == StopType.Normal)
                SaveConfiguration();

            if (retVal.ResultCode != ResultCode.Failure)
                ChangeState(State.Stopped);
            else
                ChangeState(State.Faulted, retVal.LastErrorMessage());

            retVal.LogResult(logger);
            logger.ExitMethod(retVal);
            return retVal;
        }

        #endregion

        #region Configuration Management

        /// <summary>
        /// Loads the configuration from the file specified in the ConfigurationFileName property.
        /// </summary>
        /// <returns>A Result containing the result of the operation and the instance of Configuration containing the loaded configuration.</returns>
        private Result<Dictionary<string, Dictionary<string, object>>> LoadConfiguration()
        {
            return LoadConfiguration(ConfigurationFileName);
        }

        /// <summary>
        /// Reads the given file and attempts to deserialize it to an instance of Configuration.
        /// </summary>
        /// <param name="fileName">The file to read and deserialize.</param>
        /// <returns>A Result containing the result of the operation and the Configuration instance created from the file.</returns>
        private Result<Dictionary<string, Dictionary<string, object>>> LoadConfiguration(string fileName)
        {
            Guid guid = logger.EnterMethod(xLogger.Params(fileName), true);

            logger.Info("Loading configuration from '" + fileName + "'...");
            Result<Dictionary<string, Dictionary<string, object>>> retVal = new Result<Dictionary<string, Dictionary<string, object>>>();

            string configFile = "";

            try
            {
                // read the entirety of the configuration file into configFile
                configFile = platformManager.Platform.ReadFile(fileName).ReturnValue;
                logger.Trace("Configuration file loaded from '" + fileName + "'.  Attempting to deserialize...");

                // attempt to deserialize the contents of the file to an object of type ApplicationConfiguration
                retVal.ReturnValue = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, object>>>(configFile);
                logger.Trace("Successfully deserialized the contents of '" + fileName + "' to a Configuration object.");
            }
            catch (Exception ex)
            {
                retVal.AddError("Exception thrown while loading Configuration from '" + fileName + "': " + ex);
                logger.Exception(LogLevel.Error, ex, xLogger.Vars(configFile), xLogger.Names("configFile"), guid);
            }

            retVal.LogResult(logger);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        /// <summary>
        /// Saves the current configuration to the file specified in app.exe.config.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result SaveConfiguration()
        {
            logger.Info("Saving configuration...");
            Result retVal = SaveConfiguration(Configuration, ConfigurationFileName);
            retVal.LogResult(logger);
            return retVal;
        }

        /// <summary>
        /// Saves the provided configuration to the file specified in app.exe.config.
        /// </summary>
        /// <param name="configuration">The Configuration instance to save.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        private Result SaveConfiguration(Dictionary<string, Dictionary<string, object>> configuration)
        {
            logger.Info("Saving specified configuration to '" + ConfigurationFileName + "'...");
            Result retVal = SaveConfiguration(configuration, ConfigurationFileName);
            retVal.LogResult(logger);
            return retVal;
        }

        /// <summary>
        /// Saves the given configuration to the specified file.
        /// </summary>
        /// <param name="configuration">The Configuration object to serialize and write to disk.</param>
        /// <param name="fileName">The file in which to save the configuration.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        private Result SaveConfiguration(Dictionary<string, Dictionary<string, object>> configuration, string fileName)
        {
            Guid guid = logger.EnterMethod(xLogger.Params(configuration, fileName), true);

            logger.Info("Saving configuration to '" + fileName + "'...");
            Result retVal = new Result();

            try
            {
                logger.Trace("Flushing configuration to disk at '" + fileName + "'.");
                platformManager.Platform.WriteFile(fileName, JsonConvert.SerializeObject(configuration, Formatting.Indented, new Newtonsoft.Json.Converters.StringEnumConverter()));
                //manager.PlatformManager.Platform.WriteFile(fileName, JsonConvert.SerializeObject(configuration, new JsonSerializerSettings() { Formatting = Formatting.Indented, ContractResolver = new DictionaryAsArrayResolver() }));
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
        /// <returns>A Result containing the result of the operation.</returns>
        public Result ValidateConfiguration()
        {
            return ValidateConfiguration(Configuration);
        }

        /// <summary>
        /// Examines the supplied Configuration for errors and returns the result.  If returning a Warning or Invalid result code,
        /// includes the validation message in the Message member of the return type.
        /// </summary>
        /// <param name="configuration">The Configuration to validate.</param>
        /// <returns>A Result containing the result of the validation.</returns>
        private Result ValidateConfiguration(Dictionary<string, Dictionary<string, object>> configuration)
        {
            logger.EnterMethod();

            logger.Info("Validating configuration...");
            Result retVal = new Result();

            //TODO: implement this

            retVal.LogResult(logger);
            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        /// Manually builds an instance of Configuration with default values.
        /// </summary>
        /// <returns>A Result containing the default instance of a Configuration.</returns>
        private Result<Dictionary<string, Dictionary<string, object>>> BuildNewConfiguration()
        {
            logger.EnterMethod();

            Result<Dictionary<string, Dictionary<string, object>>> retVal = new Result<Dictionary<string, Dictionary<string, object>>>();
            retVal.ReturnValue = new Dictionary<string, Dictionary<string, object>>();

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
        /// <returns>A Result containing the result of the operation and the Type of the configuration.</returns>
        public Result<Type> IsConfigurable(Type type)
        {
            logger.EnterMethod(xLogger.Params(type));
        
            Result<Type> retVal = new Result<Type>();

            // check whether the Type implements IConfigurable
            if (!type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IConfigurable<>)))
                retVal.AddError("The provided type '" + type.Name + "' does not implement IConfigurable.");    

            // check whether the Type contains the static method "GetConfigurationDefinition"
            if (type.GetMethod("GetConfigurationDefinition") == default(MethodInfo))
                retVal.AddError("The provided type '" + type.Name + "' is missing the static method 'GetConfigurationDefinition'");

            // check whether the Type contains the static method "GetDefaultConfiguration"
            if (type.GetMethod("GetDefaultConfiguration") == default(MethodInfo))
                retVal.AddError("The provided type '" + type.Name + "' is missing the static method 'GetDefaultConfiguration'");

            // if any of the previous checks failed, the Type is not configurable.
            if (retVal.ResultCode == ResultCode.Failure)
                retVal.AddError("The type '" + type.Name + "' can not be registered.");
            else
            {
                // the Type is configurable.  Determine the generic type parameter used with IConfigurable<T> so that we can return it
                // first get the IConfigurable<T> Type
                Type configurable = type.GetInterfaces().Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IConfigurable<>)).FirstOrDefault();

                // retrieve the first generic argument (there will only be one)
                retVal.ReturnValue = configurable.GetGenericArguments()[0];
            }

            retVal.LogResult(logger.Trace);
            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        /// Checks to see if the supplied Type is in the RegisteredTypes dictionary.
        /// </summary>
        /// <param name="type">The Type to check.</param>
        /// <returns>A Result containing the result of the operation and a boolean indicating whether the specified Type was found in the dictionary.</returns>
        public Result<bool> IsRegistered(Type type)
        {
            logger.EnterMethod(xLogger.Params(type));
            Result<bool> retVal = new Result<bool>();

            // the type is registered if it exists within the RegisteredTypes dictionary
            retVal.ReturnValue = RegisteredTypes.ContainsKey(type.FullName);

            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        /// Registers the supplied Type with the Configuration Manager.
        /// </summary>
        /// <remarks>When called during application startup, throwExceptionOnFailure should be set to true.</remarks>
        /// <param name="type">The Type to register.</param>
        /// <param name="throwExceptionOnFailure">If true, throws an exception on failure.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result RegisterType(Type type, bool throwExceptionOnFailure = false)
        {
            logger.EnterMethod(xLogger.Params(type, throwExceptionOnFailure));

            logger.Debug("Registering type '" + type.Name + "'...");
            Result retVal = new Result();

            // ensure the provided Type is configurable
            Result<Type> checkResult = IsConfigurable(type);

            if (checkResult.ResultCode == ResultCode.Failure)
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

            if (retVal.ResultCode == ResultCode.Failure)
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
        /// <returns>A Result containing the result of the operation.</returns>
        private Result RegisterType(Type type, ConfigurationDefinition definition, Dictionary<string, ConfigurationDefinition> registeredTypes)
        {
            logger.EnterMethod();
            logger.Trace("Registering type '" + type.Name + "'...");

            Result retVal = new Result();

            // check to ensure that the type hasn't already been registered
            if (!registeredTypes.ContainsKey(type.FullName))
            {
                try
                {
                    registeredTypes.Add(type.FullName, definition);
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
        /// <returns>A Result containing the result of the operation and a boolean containing the outcome of the lookup.</returns>
        public Result<bool> IsConfigured(Type type, string instanceName = "")
        {
            return IsConfigured(type, Configuration, instanceName);
        }

        /// <summary>
        /// Determines whether the specified instance of the specified type is configured.
        /// </summary>
        /// <param name="type">The Type of the instance to check.</param>
        /// <param name="configuration">The ApplicationConfiguration to examine.</param>
        /// <param name="instanceName">The name of the instance to check.</param>
        /// <returns>A Result containing the result of the operation and a boolean containing the outcome of the lookup.</returns>
        private Result<bool> IsConfigured(Type type, Dictionary<string, Dictionary<string, object>> configuration, string instanceName = "")
        {
            logger.EnterMethod(xLogger.Params(type, new xLogger.ExcludedParam(), instanceName));

            Result<bool> retVal = new Result<bool>();

            // check to see if the type is in the comfiguration
            if (configuration.ContainsKey(type.FullName))
            {
                // check to see if the specified instance is in the type configuration
                if (!configuration[type.FullName].ContainsKey(instanceName))
                    retVal.AddError("The specified instance name '" + instanceName + "' wasn't found in the configuration for type '" + type.Name + "'.");
            }
            else
                retVal.AddError("The specified type '" + type.Name + "' was not found in the configuration.");

            // if any messages were generated the configuration wasn't found, so return false.
            retVal.ReturnValue = (retVal.ResultCode != ResultCode.Failure);

            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        /// Adds the specified configuration to the specified instance of the specified type.
        /// </summary>
        /// <param name="type">The Type of the instance to be configured.</param>
        /// <param name="instanceConfiguration">The Configuration instance of the configuration model of the calling class.</param>
        /// <param name="instanceName">The name of the instance to configure.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result<T> AddInstanceConfiguration<T>(Type type, object instanceConfiguration, string instanceName = "")
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
        /// <returns>A Result containing the result of the operation.</returns>
        private Result<T> AddInstanceConfiguration<T>(Type type, object instanceConfiguration, Dictionary<string, Dictionary<string, object>> configuration, string instanceName = "")
        {
            logger.EnterMethod(xLogger.Params(type, new xLogger.ExcludedParam(), instanceName));

            Result<T> retVal = new Result<T>();

            if (IsConfigurable(type).ResultCode == ResultCode.Failure)
                retVal.AddError("The type '" + type.Name + "' is not configurable.");
            else if (!IsRegistered(type).ReturnValue)
                retVal.AddError("The type '" + type.Name + "' is configurable but has not been registered.");
            // ensure the configuration doesn't already exist
            else if (!IsConfigured(type, instanceName).ReturnValue)
            {
                logger.Trace("Inserting configuration into the Configuration dictionary...");
                // if the configuration doesn't contain a section for the type, add it
                if (!configuration.ContainsKey(type.FullName))
                    configuration.Add(type.FullName, new Dictionary<string, object>());

                // add the default configuration for the requested type/instance to the configuration.
                configuration[type.FullName].Add(instanceName, instanceConfiguration);

                retVal.ReturnValue = (T)instanceConfiguration;

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
        /// <returns>A Result containing the result of the operation and an instance of the Configuration model 
        /// for the calling class containing the retrieved configuration.</returns>
        public Result<T> GetInstanceConfiguration<T>(Type type, string instanceName = "")
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
        /// <returns>A Result containing the result of the operation and an instance of the Configuration model 
        /// for the calling class containing the retrieved configuration.</returns>
        private Result<T> GetInstanceConfiguration<T>(Type type, Dictionary<string, Dictionary<string, object>> configuration, string instanceName = "")
        {
            logger.EnterMethod(xLogger.Params(type, new xLogger.ExcludedParam(), instanceName));

            Result<T> retVal = new Result<T>();

            // ensure the specified type and instance is configured
            if (IsConfigured(type, instanceName).ReturnValue)
            {
                try
                {
                    // json.net needs to know the type when it deserializes; we can't cast or convert after the fact.
                    // the solution is to grab our object, serialize it again, then deserialize it into the required type.
                    var rawObject = configuration[type.FullName][instanceName];
                    var reSerializedObject = JsonConvert.SerializeObject(rawObject);
                    var reDeSerializedObject = JsonConvert.DeserializeObject<T>(reSerializedObject);
                    retVal.ReturnValue = reDeSerializedObject;
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
        /// <returns>A Result containing the result of the operation.</returns>
        public Result UpdateInstanceConfiguration(Type type, object instanceConfiguration, string instanceName = "")
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
        /// <returns>A Result containing the result of the operation.</returns>
        private Result UpdateInstanceConfiguration(Type type, object instanceConfiguration, Dictionary<string, Dictionary<string, object>> configuration, string instanceName = "")
        {
            logger.EnterMethod(xLogger.Params(type, instanceConfiguration, new xLogger.ExcludedParam(), instanceName));

            logger.Debug("Updating configuration for instance '" + instanceName + "' of type '" + type.Name + "'...");
            Result retVal = new Result();

            if (IsConfigured(type, instanceName).ReturnValue)
                configuration[type.FullName][instanceName] = instanceConfiguration;
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
        /// <returns>A Result containing the result of the operation.</returns>
        public Result RemoveInstanceConfiguration(Type type, string instanceName = "")
        {
            return RemoveInstanceConfiguration(type, Configuration, instanceName);
        }

        /// <summary>
        /// Removes the specified instance of the specified type from the configuration.
        /// </summary>
        /// <param name="type">The Type of instance to remove.</param>
        /// <param name="configuration">The ApplicationConfiguration from which to remove the configuration.</param>
        /// <param name="instanceName">The name of the instance to remove from the Type.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        private Result RemoveInstanceConfiguration(Type type, Dictionary<string, Dictionary<string, object>> configuration, string instanceName = "")
        {
            logger.EnterMethod(xLogger.Params(type, configuration, instanceName));

            logger.Debug("Removing configuration for instance '" + instanceName + "' of type '" + type.Name + "'...");
            Result retVal = new Result();

            if (IsConfigured(type, instanceName).ReturnValue)
                configuration[type.FullName].Remove(instanceName);
            else
                retVal.AddError("The specified instance '" + instanceName + "' of type '" + type.Name + "' was not found in the configuration.");

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal);
            return retVal;
        }

        #endregion

        /// <summary>
        /// Changes the <see cref="State"/> property to the specified state and fires the StateChanged event.
        /// </summary>
        /// <param name="state">The State to which the State property should be changed.</param>
        /// <param name="message">The optional message describing the nature or reason for the change.</param>
        /// <threadsafety instance="true"/>
        private void ChangeState(State state, string message = "")
        {
            State previousState = State;

            // lock the State property
            lock (StateLock)
            {
                State = state;

                if (StateChanged != null)
                    StateChanged(this, new StateChangedEventArgs(State, previousState, message));
            }
        }

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
        /// <returns>A Result containing the result of the operation.</returns>
        public static Result SetConfigurationFileName(string fileName)
        {
            logger.Info("Setting Configuration filename to '" + fileName + "'...");

            Result retVal = new Result();

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
        /// <returns>A Result containing the result of the operation.</returns>
        public static Result MoveConfigurationFile(string newFileName)
        {
            logger.Info("Moving Configuration file to '" + newFileName + "'...");

            Result retVal = new Result();

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
