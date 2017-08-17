/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄████████                                                              ▄▄▄▄███▄▄▄▄
      █     ███    ███                                                            ▄██▀▀▀███▀▀▀██▄
      █     ███    █▀     ▄█████  ▄██████ ██   █     █████  █      ██    ▄█   ▄   ███   ███   ███   ▄█████  ██▄▄▄▄    ▄█████     ▄████▄     ▄█████    █████
      █     ███          ██   █  ██    ██ ██   ██   ██  ██ ██  ▀███████▄ ██   █▄  ███   ███   ███   ██   ██ ██▀▀▀█▄   ██   ██   ██    ▀    ██   █    ██  ██
      █   ▀███████████  ▄██▄▄    ██    ▀  ██   ██  ▄██▄▄█▀ ██▌     ██  ▀ ▀▀▀▀▀██  ███   ███   ███   ██   ██ ██   ██   ██   ██  ▄██        ▄██▄▄     ▄██▄▄█▀
      █            ███ ▀▀██▀▀    ██    ▄  ██   ██ ▀███████ ██      ██    ▄█   ██  ███   ███   ███ ▀████████ ██   ██ ▀████████ ▀▀██ ███▄  ▀▀██▀▀    ▀███████
      █      ▄█    ███   ██   █  ██    ██ ██   ██   ██  ██ ██      ██    ██   ██  ███   ███   ███   ██   ██ ██   ██   ██   ██   ██    ██   ██   █    ██  ██
      █    ▄████████▀    ███████ ██████▀  ██████    ██  ██ █      ▄██▀    █████    ▀█   ███   █▀    ██   █▀  █   █    ██   █▀   ██████▀    ███████   ██  ██
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █
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
using Newtonsoft.Json;
using NLog;
using NLog.xLogger;
using OpenIIoT.SDK;
using OpenIIoT.SDK.Common;
using OpenIIoT.SDK.Common.Discovery;
using OpenIIoT.SDK.Common.Exceptions;
using OpenIIoT.SDK.Platform;
using Utility.OperationResult;
using OpenIIoT.Core.Common;
using OpenIIoT.SDK.Configuration;
using OpenIIoT.SDK.Security;
using System.Security.Claims;

namespace OpenIIoT.Core.Security
{
    [Discoverable]
    public class SecurityManager : Manager, ISecurityManager, IConfigurable<SecurityManagerConfiguration>
    {
        #region Private Fields

        /// <summary>
        ///     The Singleton instance of PlatformManager.
        /// </summary>
        private static ISecurityManager instance;

        /// <summary>
        ///     The Logger for this class.
        /// </summary>
        private static new xLogger logger = (xLogger)LogManager.GetCurrentClassLogger(typeof(xLogger));

        #endregion Private Fields

        #region Private Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="SecurityManager"/> class.
        /// </summary>
        /// <param name="manager">The ApplicationManager instance for the application.</param>
        /// <param name="configurationManager">The ConfigurationManager instance for the application.</param>
        private SecurityManager(IApplicationManager manager, IConfigurationManager configurationManager)
        {
            base.logger = logger;
            Guid guid = logger.EnterMethod();

            ManagerName = "Security Manager";
            EventProviderName = GetType().Name;

            RegisterDependency<IApplicationManager>(manager);
            RegisterDependency<IConfigurationManager>(configurationManager);

            ChangeState(State.Initialized);

            logger.ExitMethod(guid);
        }

        #endregion Private Constructors

        #region Public Properties

        /// <summary>
        ///     Gets the Configuration for the Manager.
        /// </summary>
        public SecurityManagerConfiguration Configuration { get; private set; }

        /// <summary>
        ///     Gets the ConfigurationDefinition for the Manager.
        /// </summary>
        public IConfigurationDefinition ConfigurationDefinition => GetConfigurationDefinition();

        public IReadOnlyList<ClaimsPrincipal> Sessions => ((List<ClaimsPrincipal>)SessionList).AsReadOnly();

        private IList<ClaimsPrincipal> SessionList { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///     Returns the ConfigurationDefinition for the Model Manager.
        /// </summary>
        /// <returns>The ConfigurationDefinition for the Model Manager.</returns>
        public static IConfigurationDefinition GetConfigurationDefinition()
        {
            ConfigurationDefinition retVal = new ConfigurationDefinition();
            retVal.Form = "[\"name\",\"email\",{\"key\":\"comment\",\"type\":\"textarea\",\"placeholder\":\"Make a comment\"},{\"type\":\"submit\",\"style\":\"btn-info\",\"title\":\"OK\"}]";
            retVal.Schema = "{\"type\":\"object\",\"title\":\"Comment\",\"properties\":{\"name\":{\"title\":\"Name\",\"type\":\"string\"},\"email\":{\"title\":\"Email\",\"type\":\"string\",\"pattern\":\"^\\\\S+@\\\\S+$\",\"description\":\"Email will be used for evil.\"},\"comment\":{\"title\":\"Comment\",\"type\":\"string\",\"maxLength\":20,\"validationMessage\":\"Don\'t be greedy!\"}},\"required\":[\"name\",\"email\",\"comment\"]}";
            retVal.Model = typeof(SecurityManagerConfiguration);

            SecurityManagerConfiguration config = new SecurityManagerConfiguration();
            retVal.DefaultConfiguration = config;

            return retVal;
        }

        /// <summary>
        ///     Instantiates and/or returns the SecurityManager instance.
        /// </summary>
        /// <remarks>
        ///     Invoked via reflection from ApplicationManager. The parameters are used to build an array of IManager parameters
        ///     which are then passed to this method. To specify additional dependencies simply insert them into the parameter list
        ///     for the method and they will be injected when the method is invoked.
        /// </remarks>
        /// <param name="manager">The ApplicationManager instance for the application.</param>
        /// <returns>The Singleton instance of PlatformManager.</returns>
        public static ISecurityManager Instantiate(IApplicationManager manager, IConfigurationManager configurationManager)
        {
            if (instance == null)
            {
                instance = new SecurityManager(manager, configurationManager);
            }

            return instance;
        }

        /// <summary>
        ///     Terminates Singleton instance of PlatformManager.
        /// </summary>
        public static void Terminate()
        {
            instance = null;
        }

        public IResult AddSession(ClaimsPrincipal principal)
        {
            SessionList.Add(principal);
            return new Result();
        }

        /// <summary>
        ///     Configures the Model Manager using the configuration stored in the Configuration Manager, or, failing that, using
        ///     the default configuration.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        public IResult Configure()
        {
            logger.EnterMethod();

            logger.Debug("Attempting to Configure with the configuration from the Configuration Manager...");
            Result retVal = new Result();

            IResult<SecurityManagerConfiguration> fetchResult = Dependency<IConfigurationManager>().Configuration.GetInstance<SecurityManagerConfiguration>(this.GetType());

            // if the fetch succeeded, configure this instance with the result.
            if (fetchResult.ResultCode != ResultCode.Failure)
            {
                logger.Debug("Successfully fetched the configuration from the Configuration Manager.");
                Configure(fetchResult.ReturnValue);
            }
            else
            {
                // if the fetch failed, add a new default instance to the configuration and try again.
                logger.Debug("Unable to fetch the configuration.  Adding the default configuration to the Configuration Manager...");
                IResult<SecurityManagerConfiguration> createResult = Dependency<IConfigurationManager>().Configuration.AddInstance<SecurityManagerConfiguration>(this.GetType(), GetConfigurationDefinition().DefaultConfiguration);
                if (createResult.ResultCode != ResultCode.Failure)
                {
                    createResult.ReturnValue.Users.Add(SecurityConstants.DefaultUser);
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
        ///     Configures the Manager using the supplied configuration, then saves the configuration to the Model Manager.
        /// </summary>
        /// <param name="configuration">The configuration with which the Manager should be configured.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public IResult Configure(SecurityManagerConfiguration configuration)
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
        ///     Saves the configuration to the Configuration Manager.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
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
        ///     Implements the post-instantiation procedure for the <see cref="PlatformManager"/> class.
        /// </summary>
        /// <remarks>This method is invoked by the ApplicationManager following the instantiation of all program Managers.</remarks>
        /// <exception cref="ManagerSetupException">Thrown when an error is encountered during setup.</exception>
        protected override void Setup()
        {
        }

        /// <summary>
        ///     Implements the shutdown procedure for the <see cref="PlatformManager"/> class.
        /// </summary>
        /// <param name="stopType">The <see cref="StopType"/> enumeration corresponding to the nature of the stoppage.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        protected override IResult Shutdown(StopType stopType = StopType.Stop)
        {
            Guid guid = logger.EnterMethod(true);
            logger.Debug("Performing Shutdown for '" + GetType().Name + "'...");
            IResult retVal = new Result();

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        /// <summary>
        ///     Implements the startup procedure for the <see cref="PlatformManager"/> class.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        /// <exception cref="DirectoryException">Thrown when one or more application directories can not be verified.</exception>
        protected override IResult Startup()
        {
            Guid guid = logger.EnterMethod(true);
            logger.Debug("Performing Startup for '" + GetType().Name + "'...");

            IResult retVal = Configure();

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        #endregion Protected Methods
    }
}