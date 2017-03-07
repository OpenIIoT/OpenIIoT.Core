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
using NLog.xLogger;
using OpenIIoT.SDK;
using OpenIIoT.SDK.Common;
using OpenIIoT.SDK.Common.Exceptions;
using OpenIIoT.SDK.Platform;
using Utility.OperationResult;
using OpenIIoT.SDK.Extensibility.Package;

namespace OpenIIoT.Core.Extensibility.Package
{
    /// <summary>
    ///     The Package Manager manages the installation and uninstallation of software packages used to extend the functionality
    ///     of the application.
    /// </summary>
    public sealed class PackageManager : Manager, IPackageManager
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
        ///     <see cref="Instantiate(IApplicationManager, IPlatformManager)"/> method exclusively in order to implement the
        ///     Singleton design pattern.
        /// </remarks>
        /// <param name="manager">The ApplicationManager instance for the application.</param>
        /// <param name="platformManager">The PlatformManager instance for the application.</param>
        private PackageManager(IApplicationManager manager, IPlatformManager platformManager)
        {
            base.logger = logger;
            logger.EnterMethod();

            ManagerName = "Package Manager";

            // register dependencies
            RegisterDependency<IApplicationManager>(manager);
            RegisterDependency<IPlatformManager>(platformManager);

            ChangeState(State.Initialized);

            logger.ExitMethod();
        }

        #endregion Private Constructors

        #region Public Methods

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
        /// <returns>The Singleton instance of the ConfigurationManager.</returns>
        public static IPackageManager Instantiate(IApplicationManager manager, IPlatformManager platformManager)
        {
            if (instance == null)
            {
                instance = new PackageManager(manager, platformManager);
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