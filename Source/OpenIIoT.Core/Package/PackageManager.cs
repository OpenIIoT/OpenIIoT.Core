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
using System.Collections.Generic;
using System.Threading.Tasks;
using NLog.xLogger;
using OpenIIoT.SDK;
using OpenIIoT.SDK.Common;
using OpenIIoT.SDK.Common.Exceptions;
using OpenIIoT.SDK.Package;
using OpenIIoT.SDK.Platform;
using Utility.OperationResult;
using System.Linq;

namespace OpenIIoT.Core.Package
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
        /// <param name="manager">The <see cref="IApplicationManager"/> instance for the application.</param>
        /// <param name="platformManager">The <see cref="IPlatformManager"/> instance for the application.</param>
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

        #region Public Properties

        /// <summary>
        ///     Gets the list of Packages available for installation.
        /// </summary>
        public IList<IPackage> Packages { get; private set; }

        #endregion Public Properties

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
        /// <returns>The Singleton instance of the <see cref="IManager"/>.</returns>
        public static IPackageManager Instantiate(IApplicationManager manager, IPlatformManager platformManager)
        {
            if (instance == null)
            {
                instance = new PackageManager(manager, platformManager);
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

        public IResult DeletePackage(string fqn)
        {
            logger.EnterMethod(xLogger.Params(fqn));
            IResult retVal = new Result();

            logger.Info($"Deleting Package {fqn}...");
            logger.Debug($"Locating Package '{fqn}'...");

            IResult<IPackage> findResult = FindPackage(fqn);
            retVal.Incorporate(findResult);

            if (retVal.ResultCode != ResultCode.Failure)
            {
                string fileName = findResult.ReturnValue.FileName;

                IResult deleteResult = Dependency<IPlatformManager>().Platform.DeleteFile(fileName);
                retVal.Incorporate(deleteResult);
            }
            else
            {
                retVal.AddError("The Package could not be found.");
            }

            if (retVal.ResultCode == ResultCode.Failure)
            {
                logger.Info($"Failed to delete Package '{fqn}': {retVal.GetLastError()}.");
            }

            retVal.LogResult(logger);
            logger.ExitMethod();
            return retVal;
        }

        public async Task<IResult> DeletePackageAsync(string fqn)
        {
            return await Task.Run(() => DeletePackage(fqn));
        }

        public IResult<IPackage> FindPackage(string fqn)
        {
            return FindPackage(fqn, false);
        }

        public async Task<IResult<IPackage>> FindPackageAsync(string fqn)
        {
            return await Task.Run(() => FindPackage(fqn));
        }

        public IResult InstallPackage(string fqn, string publicKey = "")
        {
            return new Result();
        }

        public IResult InstallPackage(string fqn, PackageInstallOptions options = PackageInstallOptions.None, string publicKey = "")
        {
            return new Result();
        }

        public async Task<IResult> InstallPackageAsync(string fqn, string publicKey = "")
        {
            return await Task.Run(() => InstallPackageAsync(fqn, publicKey));
        }

        public async Task<IResult> InstallPackageAsync(string fqn, PackageInstallOptions options = PackageInstallOptions.None, string publicKey = "")
        {
            return await Task.Run(() => InstallPackage(fqn, options, publicKey));
        }

        public IResult<IPackage> SavePackage(string fileName, byte[] data)
        {
            return new Result<IPackage>();
        }

        public async Task<IResult<IPackage>> SavePackageAsync(string fileName, byte[] data)
        {
            return await Task.Run(() => SavePackage(fileName, data));
        }

        public IResult<IList<IPackage>> ScanPackages()
        {
            Guid guid = logger.EnterMethod();

            IResult<IList<IPackage>> retVal = new Result<IList<IPackage>>(ResultCode.Failure);

            IPlatform platform = Dependency<IPlatformManager>().Platform;
            IResult<IList<string>> files = platform.ListFiles(platform.Directories.Packages);

            if (files.ResultCode != ResultCode.Failure)
            {
                retVal = new PackageScanner(files.ReturnValue).Scan();
            }

            Packages = retVal.ReturnValue;

            retVal.LogResult(logger);
            logger.ExitMethod(guid);
            return retVal;
        }

        public async Task<IResult<IList<IPackage>>> ScanPackagesAsync()
        {
            return await Task.Run(() => ScanPackages());
        }

        public IResult<bool> VerifyPackage(string fqn, string publicKey = "")
        {
            return new Result<bool>();
        }

        public async Task<IResult<bool>> VerifyPackageAsync(string fqn, string publicKey = "")
        {
            return await Task.Run(() => VerifyPackage(fqn, publicKey));
        }

        private IResult<IPackage> FindPackage(string fqn, bool rescanOnNotFound)
        {
            logger.EnterMethod(xLogger.Params(fqn));
            IResult<IPackage> retVal = new Result<IPackage>();

            retVal.ReturnValue = Packages.Where(p => p.FQN == fqn).FirstOrDefault();

            if (retVal.ReturnValue == default(IPackage))
            {
                if (rescanOnNotFound)
                {
                    ScanPackages();
                    return FindPackage(fqn, false);
                }

                retVal.AddError($"Unable to locate Package with FQN '{fqn}'.");
            }

            retVal.LogResult(logger);
            logger.ExitMethod();
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
                Packages = default(IList<IPackage>);
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

            retVal.Incorporate(ScanPackages());

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        #endregion Protected Methods
    }
}