/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄███████▄                                                                 ▄▄▄▄███▄▄▄▄
      █     ███    ███                                                               ▄██▀▀▀███▀▀▀██▄
      █     ███    ███   ▄█████   ▄██████    █  █▄     ▄█████     ▄████▄     ▄█████  ███   ███   ███   ▄█████  ██▄▄▄▄    ▄█████     ▄████▄     ▄█████    █████
      █     ███    ███   ██   ██ ██    ██   ██ ▄██▀    ██   ██   ██    ▀    ██   █   ███   ███   ███   ██   ██ ██▀▀▀█▄   ██   ██   ██    ▀    ██   █    ██  ██
      █   ▀█████████▀    ██   ██ ██    ▀    ██▐█▀      ██   ██  ▄██        ▄██▄▄     ███   ███   ███   ██   ██ ██   ██   ██   ██  ▄██        ▄██▄▄     ▄██▄▄█▀
      █     ███        ▀████████ ██    ▄  ▀▀████     ▀████████ ▀▀██ ███▄  ▀▀██▀▀     ███   ███   ███ ▀████████ ██   ██ ▀████████ ▀▀██ ███▄  ▀▀██▀▀    ▀███████
      █     ███          ██   ██ ██    ██   ██ ▀██▄    ██   ██   ██    ██   ██   █   ███   ███   ███   ██   ██ ██   ██   ██   ██   ██    ██   ██   █    ██  ██
      █    ▄████▀        ██   █▀ ██████▀    ▀█   ▀█▀   ██   █▀   ██████▀    ███████   ▀█   ███   █▀    ██   █▀  █   █    ██   █▀   ██████▀    ███████   ██  ██
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  The Package Manager manages the installation and uninstallation of software packages used to extend the functionality of the application.
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
using NLog.xLogger;
using OpenIIoT.SDK;
using OpenIIoT.SDK.Common;
using OpenIIoT.SDK.Common.Exceptions;
using OpenIIoT.SDK.Platform;
using Utility.OperationResult;
using OpenIIoT.SDK.Package;
using OpenIIoT.SDK.Configuration;

namespace OpenIIoT.Core.Package
{
    /// <summary>
    ///     The Package Manager manages the installation and uninstallation of software packages used to extend the functionality
    ///     of the application.
    /// </summary>
    public sealed class PackageManager : Manager, IPackageManager, IConfigurable<PackageManagerConfiguration>
    {
        #region Private Fields

        /// <summary>
        ///     The Singleton instance of PackageManager.
        /// </summary>
        private static IPackageManager instance;

        /// <summary>
        ///     The Logger for this class.
        /// </summary>
        private static new xLogger logger = xLogManager.GetCurrentClassxLogger();

        #endregion Private Fields

        #region Private Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PackageManager"/> class.
        /// </summary>
        /// <remarks>
        ///     This constructor is marked private and is intended to be called from the
        ///     <see cref="Instantiate(IApplicationManager, IPlatformManager, IConfigurationManager)"/> method exclusively in order
        ///     to implement the Singleton design pattern.
        /// </remarks>
        /// <param name="manager">The <see cref="IApplicationManager"/> instance for the application.</param>
        /// <param name="platformManager">The <see cref="IPlatformManager"/> instance for the application.</param>
        /// <param name="configurationManager">The <see cref="IConfigurationManager"/> instance for the application.</param>
        private PackageManager(IApplicationManager manager, IPlatformManager platformManager, IConfigurationManager configurationManager)
        {
            base.logger = logger;
            logger.EnterMethod();

            ManagerName = "Package Manager";

            // register dependencies
            RegisterDependency<IApplicationManager>(manager);
            RegisterDependency<IPlatformManager>(platformManager);
            RegisterDependency<IConfigurationManager>(configurationManager);

            ChangeState(State.Initialized);

            logger.ExitMethod();
        }

        #endregion Private Constructors

        #region Public Properties

        public PackageManagerConfiguration Configuration { get; private set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///     Returns the <see cref="IConfigurationDefinition"/> for the <see cref="IManager"/>.
        /// </summary>
        /// <returns>The <see cref="IConfigurationDefinition"/> for the <see cref="IManager"/>.</returns>
        public static IConfigurationDefinition GetConfigurationDefinition()
        {
            ConfigurationDefinition retVal = new ConfigurationDefinition();
            retVal.Form = "[\"name\",\"email\",{\"key\":\"comment\",\"type\":\"textarea\",\"placeholder\":\"Make a comment\"},{\"type\":\"submit\",\"style\":\"btn-info\",\"title\":\"OK\"}]";
            retVal.Schema = "{\"type\":\"object\",\"title\":\"Comment\",\"properties\":{\"name\":{\"title\":\"Name\",\"type\":\"string\"},\"email\":{\"title\":\"Email\",\"type\":\"string\",\"pattern\":\"^\\\\S+@\\\\S+$\",\"description\":\"Email will be used for evil.\"},\"comment\":{\"title\":\"Comment\",\"type\":\"string\",\"maxLength\":20,\"validationMessage\":\"Don\'t be greedy!\"}},\"required\":[\"name\",\"email\",\"comment\"]}";
            retVal.Model = typeof(PackageManagerConfiguration);

            PackageManagerConfiguration config = new PackageManagerConfiguration();
            config.Number = 1;

            retVal.DefaultConfiguration = config;

            return retVal;
        }

        /// <summary>
        ///     Instantiates and/or returns the <see cref="IPackageManager"/> instance.
        /// </summary>
        /// <remarks>
        ///     Invoked via reflection from the <see cref="IApplicationManager"/> . The parameters are used to build an array of
        ///     <see cref="IManager"/> parameters which are then passed to this method. To specify additional dependencies simply
        ///     insert them into the parameter list for the method and they will be injected when the method is invoked.
        /// </remarks>
        /// <param name="manager">The <see cref="IApplicationManager"/> instance for the application.</param>
        /// <param name="platformManager">The <see cref="IPlatformManager"/> instance for the application.</param>
        /// <param name="configurationManager">The <see cref="IConfigurationManager"/> instance for the application.</param>
        /// <returns>The Singleton instance of the <see cref="IManager"/>.</returns>
        public static IPackageManager Instantiate(IApplicationManager manager, IPlatformManager platformManager, IConfigurationManager configurationManager)
        {
            if (instance == null)
            {
                instance = new PackageManager(manager, platformManager, configurationManager);
            }

            return instance;
        }

        /// <summary>
        ///     Terminates Singleton instance of the <see cref="IManager"/>.
        /// </summary>
        public static void Terminate()
        {
            instance = null;
        }

        /// <summary>
        ///     Configures this <see cref="IManager"/> using the configuration stored in the <see cref="IConfigurationManager"/>,
        ///     or, failing that, using the default configuration from the
        ///     <see cref="ConfigurationDefinition.DefaultConfiguration"/> property of the <see cref="ConfigurationDefinition"/>
        ///     retrieved from the <see cref="GetConfigurationDefinition"/> method.
        /// </summary>
        /// <returns>An <see cref="IResult"/> containing the result of the operation.</returns>
        public IResult Configure()
        {
            logger.EnterMethod();

            logger.Debug("Attempting to Configure with the configuration from the Configuration Manager...");
            Result retVal = new Result();

            IResult<PackageManagerConfiguration> fetchResult = Dependency<IConfigurationManager>().Configuration.GetInstance<PackageManagerConfiguration>(this.GetType());

            // if the fetch succeeded, configure this instance with the result.
            if (fetchResult.ResultCode != ResultCode.Failure)
            {
                logger.Debug("Successfully fetched the configuration from the Configuration Manager.");
                Configure(fetchResult.ReturnValue);
            }
            // if the fetch failed, add a new default instance to the configuration and try again.
            else
            {
                logger.Debug("Unable to fetch the configuration.  Adding the default configuration to the Configuration Manager...");
                IResult<PackageManagerConfiguration> createResult = Dependency<IConfigurationManager>().Configuration.AddInstance<PackageManagerConfiguration>(this.GetType(), GetConfigurationDefinition().DefaultConfiguration);
                if (createResult.ResultCode != ResultCode.Failure)
                {
                    logger.Debug("Successfully added the configuration.  Configuring...");
                    Configure(createResult.ReturnValue);
                }
                else
                {
                    retVal.Incorporate(createResult);
                }
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Configures this <see cref="IManager"/> using the supplied configuration, then saves the configuration to the
        ///     <see cref="IConfigurationManager"/> .
        /// </summary>
        /// <param name="configuration">
        ///     The <see cref="PackageManagerConfiguration"/> with which this <see cref="IManager"/> is to be configured.
        /// </param>
        /// <returns>An <see cref="IResult"/> containing the result of the operation.</returns>
        public IResult Configure(PackageManagerConfiguration configuration)
        {
            logger.EnterMethod(xLogger.Params(configuration));
            Result retVal = new Result();

            // update the configuration
            Configuration = configuration;
            logger.Debug("Successfully configured the Manager.");

            // save it
            logger.Debug("Saving the new configuration...");
            retVal.Incorporate(SaveConfiguration());

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Saves the <see cref="Configuration"/> to the <see cref="IConfigurationManager"/> .
        /// </summary>
        /// <returns>An <see cref="IResult"/> containing the result of the operation.</returns>
        public IResult SaveConfiguration()
        {
            logger.EnterMethod();
            Result retVal = new Result();

            retVal.Incorporate(Dependency<IConfigurationManager>().Configuration.UpdateInstance(this.GetType(), Configuration));

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal);
            return retVal;
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

            retVal.Incorporate(Configure());

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