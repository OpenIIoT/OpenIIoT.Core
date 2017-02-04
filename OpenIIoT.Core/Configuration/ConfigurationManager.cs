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
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  The Configuration Manager manages the configuration file for the application and all plugins.
      █
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀ ▀ ▀▀▀     ▀▀               ▀
      █  The GNU Affero General Public License (GNU AGPL)
      █
      █  Copyright (C) 2016 JP Dillingham (jp@dillingham.ws)
      █
      █  This program is free software: you can redistribute it and/or modify
      █  it under the terms of the GNU Affero General Public License as published by
      █  the Free Software Foundation, either version 3 of the License, or
      █  (at your option) any later version.
      █
      █  This program is distributed in the hope that it will be useful,
      █  but WITHOUT ANY WARRANTY; without even the implied warranty of
      █  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
      █  GNU Affero General Public License for more details.
      █
      █  You should have received a copy of the GNU Affero General Public License
      █  along with this program.  If not, see <http://www.gnu.org/licenses/>.
      █
      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██
                                                                                                   ██
                                                                                               ▀█▄ ██ ▄█▀
                                                                                                 ▀████▀
                                                                                                   ▀▀                            */

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using NLog;
using NLog.xLogger;
using OpenIIoT.SDK;
using OpenIIoT.SDK.Common;
using OpenIIoT.SDK.Configuration;
using OpenIIoT.SDK.Platform;
using Utility.OperationResult;

namespace OpenIIoT.Core.Configuration
{
    /// <summary>
    ///     The Configuration Manager manages the configuration file for the application and all plugins.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         The Configuration namespace encapsulates the Configuration Manager and the classes and interfaces used by various
    ///         application components to allow the configuration of application level objects.
    ///     </para>
    ///     <para>
    ///         The Configuration file is generated from the json serialization of the Configuration model. The Configuration model
    ///         consists of a single instance of type Dictionary(Type, Dictionary(string, object)). This instance creates a nested
    ///         dictionary keyed on type first, then by name. The resulting key value pair contains the Configuration object for
    ///         the specified Type and named instance.
    ///     </para>
    ///     <para>
    ///         There are two main types of configuration supported by this scheme; configuration for static objects like the
    ///         various application Managers and Services, and for dynamic objects encompassed by Plugins; namely Endpoints and
    ///         Connectors. The key difference is the number of instances of each; static objects will have only one instance while
    ///         the Plugin objects may have any number. Static objects do not supply an instance name when using the Configuration
    ///         Manager, and their configuration is saved within the model with an empty string. Dynamic objects must supply an
    ///         instance name.
    ///     </para>
    ///     <para>
    ///         The Configuration file maintained by the Configuration Manager is capable of being rebuilt from scratch. If
    ///         missing, the Manager automatically adds a default, nameless instance of each registered type to the configuration
    ///         model and flushes it to disk before loading it. This ensures the application can start normally in the event of a deletion.
    ///     </para>
    ///     <para>
    ///         The method IsConfigurable uses reflection to examine the given Type to ensure that:
    ///         1. it implements IConfigurable
    ///         2. it contains the static method GetConfigurationDefinition
    ///         <para></para>
    ///         If both predicates are true, the Type can be registered with the Configuration Manager and instances of that type
    ///         can load and save configuration data.
    ///         <para></para>
    ///         Before any Type can use the Configuration Manager, the method RegisterType() must be called and passed the Type of
    ///         that class. This method checks IsConfigurable and if passing, fetches the ConfigurationDefinition for the Type from
    ///         the static method GetConfigurationDefinition and stores the Type and the ConfigurationDefinition in the
    ///         RegisteredTypes dictionary.
    ///     </para>
    ///     <para>
    ///         The GetInstanceConfiguration(T) method is called by configurable instances to retrieve the saved configuration for
    ///         the calling class and instance. By default, if the configuration is not found the default configuration is
    ///         retrieved from the calling class and returned to the caller.
    ///     </para>
    /// </remarks>
    public sealed class ConfigurationManager : Manager, IStateful, IManager, IConfigurationManager
    {
        #region Private Fields

        /// <summary>
        ///     The Singleton instance of ConfigurationManager.
        /// </summary>
        private static ConfigurationManager instance;

        /// <summary>
        ///     The Logger for this class.
        /// </summary>
        private static new xLogger logger = (xLogger)LogManager.GetCurrentClassLogger(typeof(xLogger));

        /// <summary>
        ///     Lock for the State property.
        /// </summary>
        private object stateLock = new object();

        #endregion Private Fields

        #region Private Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ConfigurationManager"/> class.
        /// </summary>
        /// <remarks>
        ///     This constructor is marked private and is intended to be called from the
        ///     <see cref="Instantiate(IApplicationManager, IPlatformManager)"/> method exclusively in order to implement the
        ///     Singleton design pattern.
        /// </remarks>
        /// <param name="manager">The ApplicationManager instance for the application.</param>
        /// <param name="platformManager">The PlatformManager instance for the application.</param>
        private ConfigurationManager(IApplicationManager manager, IPlatformManager platformManager)
        {
            base.logger = logger;
            logger.EnterMethod();

            ManagerName = "Configuration Manager";

            // register dependencies
            RegisterDependency<IApplicationManager>(manager);
            RegisterDependency<IPlatformManager>(platformManager);

            ConfigurableTypeRegistry = new ConfigurableTypeRegistry();

            ConfigurationFileName = GetConfigurationFileName();

            ChangeState(State.Initialized);

            logger.ExitMethod();
        }

        #endregion Private Constructors

        #region Public Properties

        /// <summary>
        ///     Gets the current configuration.
        /// </summary>
        public Dictionary<string, Dictionary<string, object>> Configuration { get; private set; }

        /// <summary>
        ///     Gets the filename of the configuration file.
        /// </summary>
        public string ConfigurationFileName { get; private set; }

        /// <summary>
        ///     Gets the registry of configurable Types.
        /// </summary>
        public ConfigurableTypeRegistry ConfigurableTypeRegistry { get; private set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///     Returns the fully qualified path to the configuration file including file name and extension.
        /// </summary>
        /// <returns>The fully qualified path, filename and extension of the configuration file.</returns>
        private static string GetConfigurationFileName()
        {
            return Utility.GetSetting("ConfigurationFileName", "OpenIIoT.json").Replace('|', System.IO.Path.DirectorySeparatorChar);
        }

        /// <summary>
        ///     Instantiates and/or returns the ConfigurationManager instance.
        /// </summary>
        /// <remarks>
        ///     Invoked via reflection from ApplicationManager. The parameters are used to build an array of IManager parameters
        ///     which are then passed to this method. To specify additional dependencies simply insert them into the parameter list
        ///     for the method and they will be injected when the method is invoked.
        /// </remarks>
        /// <param name="manager">The ApplicationManager instance for the application.</param>
        /// <param name="platformManager">The PlatformManager instance for the application.</param>
        /// <returns>The Singleton instance of the ConfigurationManager.</returns>
        public static ConfigurationManager Instantiate(IApplicationManager manager, IPlatformManager platformManager)
        {
            if (instance == null)
            {
                instance = new ConfigurationManager(manager, platformManager);
            }

            return instance;
        }

        /// <summary>
        ///     Moves the configuration file to a new location and updates the setting in app.config.
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

        /// <summary>
        ///     Sets or updates the configuration file location setting in app.config
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
        ///     Adds the specified configuration to the specified instance of the specified type.
        /// </summary>
        /// <typeparam name="T">The configuration Type.</typeparam>
        /// <param name="type">The Type of the instance to be configured.</param>
        /// <param name="instanceConfiguration">The Configuration instance of the configuration model of the calling class.</param>
        /// <param name="instanceName">The name of the instance to configure.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result<T> AddInstanceConfiguration<T>(Type type, object instanceConfiguration, string instanceName = "")
        {
            return AddInstanceConfiguration<T>(type, instanceConfiguration, Configuration, instanceName);
        }

        /// <summary>
        ///     Retrieves the configuration for the instance matching instanceName of the supplied Type. If the configuration can't
        ///     be found, returns the default configuration for the Type.
        /// </summary>
        /// <typeparam name="T">The Type matching the Configuration model for the calling class.</typeparam>
        /// <param name="type">The Type of the calling class.</param>
        /// <param name="instanceName">The name of the instance for which to retrieve the configuration.</param>
        /// <returns>
        ///     A Result containing the result of the operation and an instance of the Configuration model for the calling class
        ///     containing the retrieved configuration.
        /// </returns>
        public Result<T> GetInstanceConfiguration<T>(Type type, string instanceName = "")
        {
            return GetInstanceConfiguration<T>(type, Configuration, instanceName);
        }

        /// <summary>
        ///     Determines whether the specified instance of the specified type is configured.
        /// </summary>
        /// <param name="type">The Type of the instance to check.</param>
        /// <param name="instanceName">The name of the instance to check.</param>
        /// <returns>A Result containing the result of the operation and a boolean containing the outcome of the lookup.</returns>
        public Result<bool> IsConfigured(Type type, string instanceName = "")
        {
            return IsConfigured(type, Configuration, instanceName);
        }

        /// <summary>
        ///     Removes the specified instance of the specified type from the configuration.
        /// </summary>
        /// <param name="type">The Type of instance to remove.</param>
        /// <param name="instanceName">The name of the instance to remove from the Type.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result RemoveInstanceConfiguration(Type type, string instanceName = "")
        {
            return RemoveInstanceConfiguration(type, Configuration, instanceName);
        }

        /// <summary>
        ///     Saves the current configuration to the file specified in app.exe.config.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result SaveConfiguration()
        {
            return SaveConfiguration(Configuration, ConfigurationFileName);
        }

        /// <summary>
        ///     Saves the specified Configuration model to the Configuration for the specified instance and Type.
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
        ///     Validates the current configuration.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result ValidateConfiguration()
        {
            return ValidateConfiguration(Configuration);
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        ///     <para>Executed upon instantiation of all program Managers.</para>
        ///     <para>Registers all IManagers in the specified list implementing IConfigurable.</para>
        /// </summary>
        /// <exception cref="Exception">Thrown when an error is encountered during setup.</exception>
        protected override void Setup()
        {
            logger.EnterMethod();
            logger.Debug("Performing Setup for '" + GetType().Name + "'...");

            IReadOnlyList<IManager> managerInstances = Dependency<IApplicationManager>().Managers;
            List<Type> managerTypes = managerInstances.Select(m => m.GetType()).ToList();

            logger.Info("Registering Managers with the Configuration Manager...");
            Result registerResult = ConfigurableTypeRegistry.RegisterTypes(managerTypes);

            if (registerResult.ResultCode == ResultCode.Failure)
            {
                throw new Exception("Error registering Manager Types: " + registerResult.GetLastError());
            }

            logger.ExitMethod();
        }

        /// <summary>
        ///     <para>Executed upon shutdown of the Manager.</para>
        ///     <para>
        ///         If the specified <see cref="StopType"/> is not <see cref="StopType.Exception"/>, saves the configuration to disk.
        ///     </para>
        /// </summary>
        /// <param name="stopType">The nature of the stoppage.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        protected override Result Shutdown(StopType stopType = StopType.Stop)
        {
            Guid guid = logger.EnterMethod(true);
            logger.Debug("Performing Shutdown for '" + GetType().Name + "'...");
            Result retVal = new Result();

            if (!stopType.HasFlag(StopType.Exception))
            {
                SaveConfiguration();
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        /// <summary>
        ///     <para>Executed upon startup of the Manager.</para>
        ///     <para>
        ///         Verifies the existence of the configuration file and if missing, builds it using all default options. Loads the
        ///         configuration, validates it, and, if valid, attaches it to the <see cref="Configuration"/> property.
        ///     </para>
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        protected override Result Startup()
        {
            Guid guid = logger.EnterMethod(true);
            logger.Debug("Performing Startup for '" + GetType().Name + "'...");
            Result retVal = new Result();

            // check whether the configuration file exists and if it doesn't, build it from scratch.
            if (!Dependency<IPlatformManager>().Platform.FileExists(ConfigurationFileName))
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
                        // the file saved properly. print the result and a final confirmation.
                        saveResult.LogResult(logger, "SaveConfiguration");
                        logger.Info("Saved the new configuration to '" + ConfigurationFileName + "'.");
                    }
                    else
                    {
                        throw new Exception("Failed to save the new configuration: " + saveResult.GetLastError());
                    }
                }
                else
                {
                    throw new Exception("The configuration file was missing and the application failed to build a replacement: " + buildResult.GetLastError());
                }
            }

            logger.Checkpoint("Configuration file validated/generated", guid);

            // load the configuration.
            Result<Dictionary<string, Dictionary<string, object>>> loadResult = LoadConfiguration();

            if (loadResult.ResultCode == ResultCode.Failure)
            {
                throw new Exception("Failed to load the configuration: " + loadResult.GetLastError());
            }

            retVal.Incorporate(loadResult);

            logger.Checkpoint("Configuration loaded for validation", guid);

            // validate the configuration.
            Result validationResult = ValidateConfiguration(Configuration);

            if (validationResult.ResultCode == ResultCode.Failure)
            {
                throw new Exception("The loaded configuration is invalid: " + validationResult.GetLastError());
            }

            retVal.Incorporate(validationResult);

            logger.Checkpoint("Configuration validated", guid);

            // attach the configuration
            if (retVal.ResultCode != ResultCode.Failure)
            {
                Configuration = loadResult.ReturnValue;
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        ///     Adds the specified configuration to the specified instance of the specified type.
        /// </summary>
        /// <typeparam name="T">The configuration Type.</typeparam>
        /// <param name="type">The Type of the instance to be configured.</param>
        /// <param name="instanceConfiguration">The ApplicationConfiguration instance to which to add the new configuration.</param>
        /// <param name="configuration">The Configuration instance of the configuration model of the calling class.</param>
        /// <param name="instanceName">The name of the instance to configure.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        private Result<T> AddInstanceConfiguration<T>(Type type, object instanceConfiguration, Dictionary<string, Dictionary<string, object>> configuration, string instanceName = "")
        {
            logger.EnterMethod(xLogger.Params(type, instanceConfiguration, new xLogger.ExcludedParam(), instanceName));

            Result<T> retVal = new Result<T>();

            if (!ConfigurableTypeRegistry.IsRegistered(type))
            {
                retVal.AddError("The type '" + type.Name + "' is configurable but has not been registered.");
            }
            else if (!IsConfigured(type, instanceName).ReturnValue)
            {
                // ensure the configuration doesn't already exist
                logger.Trace("Inserting configuration into the Configuration dictionary...");

                // if the configuration doesn't contain a section for the type, add it
                if (!configuration.ContainsKey(type.FullName))
                {
                    configuration.Add(type.FullName, new Dictionary<string, object>());
                }

                // add the default configuration for the requested type/instance to the configuration.
                configuration[type.FullName].Add(instanceName, instanceConfiguration);

                retVal.ReturnValue = (T)instanceConfiguration;

                logger.Trace("The configuration was inserted successfully.");
            }
            else
            {
                retVal.AddError("The configuration for instance '" + instanceName + "' of type '" + type.Name + "' already exists.");
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Manually builds an instance of Configuration with default values.
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

        /// <summary>
        ///     Retrieves the configuration for the instance matching instanceName of the supplied Type. If the configuration can't
        ///     be found, returns the default configuration for the Type.
        /// </summary>
        /// <typeparam name="T">The Type matching the Configuration model for the calling class.</typeparam>
        /// <param name="type">The Type of the calling class.</param>
        /// <param name="configuration">The ApplicationConfiguration from which to retrieve the configuration.</param>
        /// <param name="instanceName">The name of the instance for which to retrieve the configuration.</param>
        /// <returns>
        ///     A Result containing the result of the operation and an instance of the Configuration model for the calling class
        ///     containing the retrieved configuration.
        /// </returns>
        private Result<T> GetInstanceConfiguration<T>(Type type, Dictionary<string, Dictionary<string, object>> configuration, string instanceName = "")
        {
            logger.EnterMethod(xLogger.Params(type, new xLogger.ExcludedParam(), instanceName));

            Result<T> retVal = new Result<T>();

            // ensure the specified type and instance is configured
            if (IsConfigured(type, instanceName).ReturnValue)
            {
                try
                {
                    // json.net needs to know the type when it deserializes; we can't cast or convert after the fact. the solution
                    // is to grab our object, serialize it again, then deserialize it into the required type.
                    var rawObject = configuration[type.FullName][instanceName];
                    var newSerializedObject = JsonConvert.SerializeObject(rawObject);
                    var newDeSerializedObject = JsonConvert.DeserializeObject<T>(newSerializedObject);
                    retVal.ReturnValue = newDeSerializedObject;
                }
                catch (Exception ex)
                {
                    retVal.AddError("Error retrieving and re-serializing the data from the configuration for type '" + type.Name + "', instance '" + instanceName + "': " + ex);
                }
            }
            else
            {
                retVal.AddError("The specified type '" + type.Name + "' is not configured.");
            }

            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Determines whether the specified instance of the specified type is configured.
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
                {
                    retVal.AddError("The specified instance name '" + instanceName + "' wasn't found in the configuration for type '" + type.Name + "'.");
                }
            }
            else
            {
                retVal.AddError("The specified type '" + type.Name + "' was not found in the configuration.");
            }

            // if any messages were generated the configuration wasn't found, so return false.
            retVal.ReturnValue = retVal.ResultCode != ResultCode.Failure;

            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Loads the configuration from the file specified in the ConfigurationFileName property.
        /// </summary>
        /// <returns>
        ///     A Result containing the result of the operation and the instance of Configuration containing the loaded configuration.
        /// </returns>
        private Result<Dictionary<string, Dictionary<string, object>>> LoadConfiguration()
        {
            return LoadConfiguration(ConfigurationFileName);
        }

        /// <summary>
        ///     Reads the given file and attempts to deserialize it to an instance of Configuration.
        /// </summary>
        /// <param name="fileName">The file to read and deserialize.</param>
        /// <returns>A Result containing the result of the operation and the Configuration instance created from the file.</returns>
        private Result<Dictionary<string, Dictionary<string, object>>> LoadConfiguration(string fileName)
        {
            Guid guid = logger.EnterMethod(xLogger.Params(fileName), true);

            logger.Info("Loading configuration from '" + fileName + "'...");
            Result<Dictionary<string, Dictionary<string, object>>> retVal = new Result<Dictionary<string, Dictionary<string, object>>>();

            string configFile = string.Empty;

            try
            {
                // read the entirety of the configuration file into configFile
                configFile = Dependency<IPlatformManager>().Platform.ReadFile(fileName).ReturnValue;
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
        ///     Removes the specified instance of the specified type from the configuration.
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
            {
                configuration[type.FullName].Remove(instanceName);
            }
            else
            {
                retVal.AddError("The specified instance '" + instanceName + "' of type '" + type.Name + "' was not found in the configuration.");
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Saves the provided configuration to the file specified in app.exe.config.
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
        ///     Saves the given configuration to the specified file.
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
                Dependency<IPlatformManager>().Platform.WriteFile(fileName, JsonConvert.SerializeObject(configuration, Formatting.Indented, new Newtonsoft.Json.Converters.StringEnumConverter()));
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
        ///     Saves the specified Configuration model to the Configuration for the specified instance and Type.
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
            {
                configuration[type.FullName][instanceName] = instanceConfiguration;
            }
            else
            {
                retVal.AddError("The specified instance '" + instanceName + "' of type '" + type.Name + "' was not found in the configuration.");
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Examines the supplied Configuration for errors and returns the result. If returning a Warning or Invalid result
        ///     code, includes the validation message in the Message member of the return type.
        /// </summary>
        /// <param name="configuration">The Configuration to validate.</param>
        /// <returns>A Result containing the result of the validation.</returns>
        private Result ValidateConfiguration(Dictionary<string, Dictionary<string, object>> configuration)
        {
            logger.EnterMethod();

            logger.Info("Validating configuration...");
            Result retVal = new Result();

            //// TODO: implement this

            retVal.LogResult(logger);
            logger.ExitMethod(retVal);
            return retVal;
        }

        #endregion Private Methods
    }
}