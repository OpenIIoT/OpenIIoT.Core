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

namespace OpenIIoT.Core.Platform
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

        #region Public Methods

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
        public static IPlatformManager Instantiate(IApplicationManager manager, IConfigurationManager configurationManager)
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
            IResult retVal = new Result();

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        #endregion Protected Methods
    }
}