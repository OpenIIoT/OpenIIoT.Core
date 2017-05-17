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
      █  Copyright (C) 2016-2017 JP Dillingham (jp@dillingham.ws)
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
using NLog.xLogger;
using OpenIIoT.SDK;
using OpenIIoT.SDK.Common;
using OpenIIoT.SDK.Common.Exceptions;
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
    ///         The Configuration file is generated from the json serialization of the Configuration model. The Configuration model
    ///         consists of a single instance of <see cref="Configuration"/>. This instance creates a nested dictionary keyed on
    ///         type first, then by name. The resulting key value pair contains the Configuration object for the specified Type and
    ///         named instance.
    ///     </para>
    ///     <para>
    ///         There are two main types of configuration supported by this scheme; configuration for static objects like the
    ///         various application Managers and Services, and for dynamic objects encompassed by Plugins. The key difference is
    ///         the number of instances of each; static objects will have only one instance while Plugin objects may have any
    ///         number. Static objects do not supply an instance name when using the Configuration Manager, and their configuration
    ///         is saved within the model with an empty string. Dynamic objects must supply an instance name.
    ///     </para>
    ///     <para>
    ///         The Configuration file maintained by the Configuration Manager is capable of being rebuilt from scratch. If
    ///         missing, the Manager automatically adds a default, nameless instance of each registered type to the configuration
    ///         model and flushes it to disk before loading it. This ensures the application can start normally in the event of a deletion.
    ///     </para>
    ///     <para>
    ///         A Type is considered to be configurable if:
    ///         <list type="number">
    ///             <item>it implements the <see cref="SDK.Configuration.IConfigurable{T}"/> interface</item>
    ///             <item>It contains the static method GetConfigurationDefinition()</item>
    ///         </list>
    ///         If both predicates are true, the Type can be registered with the Configuration Manager and instances of that type
    ///         can load and save configuration data.
    ///         <para></para>
    ///         Before any Type can use the Configuration Manager, the method
    ///         <see cref="IConfigurableTypeRegistry.RegisterType(Type, bool)"/> method within the
    ///         <see cref="ConfigurableTypeRegistry"/> must be called and passed the Type of that class. This method fetches the
    ///         ConfigurationDefinition for the Type from the static method GetConfigurationDefinition and stores the Type and the
    ///         ConfigurationDefinition in the RegisteredTypes dictionary.
    ///     </para>
    ///     <para>
    ///         Configured objects may retrieve their stored configuration via the
    ///         <see cref="Configuration.GetInstance{T}(Type, string)"/> method, and may save their configuration using <see cref="Configuration.UpdateInstance(Type, object, string)"/>.
    ///     </para>
    ///     <para>
    ///         New instances of configurable Types may be added to the configuration using the
    ///         <see cref="Configuration.AddInstance{T}(Type, object, string)"/> method, and may be removed using
    ///         <see cref="Configuration.RemoveInstance(Type, string)"/>. The
    ///         <see cref="Configuration.IsInstanceConfigured(Type, string)"/> method is used to determine whether a given instance
    ///         is configured.
    ///     </para>
    ///     <para>
    ///         The configuration is loaded from file within the <see cref="Startup"/> method, and saved within
    ///         <see cref="Shutdown(StopType)"/>. The filename of the stored configuration is defined in the application settings
    ///         file with the key "ConfigurationFileName". If the key is missing from the configuration, the default name
    ///         "OpenIIoT.json" is used.
    ///     </para>
    /// </remarks>
    public sealed class ConfigurationManager : Manager, IConfigurationManager
    {
        #region Private Fields

        /// <summary>
        ///     The Singleton instance of ConfigurationManager.
        /// </summary>
        private static IConfigurationManager instance;

        /// <summary>
        ///     The Logger for this class.
        /// </summary>
        private static new xLogger logger = xLogManager.GetCurrentClassxLogger();

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
            Configuration = new Configuration(ConfigurableTypeRegistry);

            ConfigurationFileName = GetConfigurationFileName();
            ConfigurationLoader = new ConfigurationLoader(Dependency<IPlatformManager>().Platform);

            ChangeState(State.Initialized);

            logger.ExitMethod();
        }

        #endregion Private Constructors

        #region Public Properties

        /// <summary>
        ///     Gets the registry of configurable Types.
        /// </summary>
        public IConfigurableTypeRegistry ConfigurableTypeRegistry { get; private set; }

        /// <summary>
        ///     Gets the current configuration.
        /// </summary>
        public IConfiguration Configuration { get; private set; }

        #endregion Public Properties

        #region Private Properties

        /// <summary>
        ///     Gets or sets the filename of the configuration file.
        /// </summary>
        private string ConfigurationFileName { get; set; }

        /// <summary>
        ///     Gets or sets the configuration loader.
        /// </summary>
        private ConfigurationLoader ConfigurationLoader { get; set; }

        #endregion Private Properties

        #region Public Methods

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
        public static IConfigurationManager Instantiate(IApplicationManager manager, IPlatformManager platformManager)
        {
            if (instance == null)
            {
                instance = new ConfigurationManager(manager, platformManager);
            }

            return instance;
        }

        /// <summary>
        ///     Terminates Singleton instance of ConfigurationManager.
        /// </summary>
        public static void Terminate()
        {
            instance = null;
        }

        /// <summary>
        ///     Saves the current configuration to the file specified in app.exe.config.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        public IResult SaveConfiguration()
        {
            return ConfigurationLoader.Save(Configuration.Instances, ConfigurationFileName);
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        ///     <para>Executed upon instantiation of all program Managers.</para>
        ///     <para>Registers all IManagers in the specified list implementing IConfigurable.</para>
        /// </summary>
        /// <exception cref="ConfigurationRegistrationException">Thrown when an error is encountered during setup.</exception>
        protected override void Setup()
        {
            logger.EnterMethod();
            logger.Debug("Performing Setup for '" + GetType().Name + "'...");

            IReadOnlyList<IManager> managerInstances = Dependency<IApplicationManager>().Managers;
            List<Type> managerTypes = managerInstances.Select(m => m.GetType()).ToList();

            logger.Info("Registering Managers with the Configuration Manager...");
            IResult registerResult = ConfigurableTypeRegistry.RegisterTypes(managerTypes);

            if (registerResult.ResultCode == ResultCode.Failure)
            {
                throw new ConfigurationRegistrationException("Error registering Manager Types: " + registerResult.GetLastError());
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

            logger.Info("Loading application configuration from '" + ConfigurationFileName + "'...");
            Result<Dictionary<string, Dictionary<string, object>>> loadResult = ConfigurationLoader.Load(ConfigurationFileName);

            if (loadResult.ResultCode == ResultCode.Failure)
            {
                logger.Info("The configuration file '" + ConfigurationFileName + "' could not be found.  Rebuilding...");

                loadResult = ConfigurationLoader.BuildNew();
                logger.Info("New configuration built.");

                // try to save the new configuration to file
                logger.Info("Saving the new configuration to '" + ConfigurationFileName + "'...");
                Result saveResult = ConfigurationLoader.Save(loadResult.ReturnValue, ConfigurationFileName);

                if (saveResult.ResultCode != ResultCode.Failure)
                {
                    // the file saved properly. print the result and a final confirmation.
                    saveResult.LogResult(logger, "SaveConfiguration");
                    logger.Info("Saved the new configuration to '" + ConfigurationFileName + "'.");
                }
                else
                {
                    throw new ConfigurationLoadException("Failed to save the new configuration: " + saveResult.GetLastError());
                }
            }

            logger.Checkpoint("Configuration file loaded.", guid);

            // attach the configuration
            if (retVal.ResultCode != ResultCode.Failure)
            {
                Configuration.LoadInstancesFrom(loadResult.ReturnValue);
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        ///     Returns the fully qualified path to the configuration file including file name and extension.
        /// </summary>
        /// <returns>The fully qualified path, filename and extension of the configuration file.</returns>
        private static string GetConfigurationFileName()
        {
            return Utility.GetSetting("ConfigurationFileName", "OpenIIoT.json").Replace('|', System.IO.Path.DirectorySeparatorChar);
        }

        #endregion Private Methods
    }
}