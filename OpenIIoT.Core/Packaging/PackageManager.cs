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
      █  Handles the installation and file management of the Packages used to extend the functionality of the application.
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
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NLog;
using NLog.xLogger;
using OpenIIoT.Core.Common;
using OpenIIoT.SDK;
using OpenIIoT.SDK.Common;
using OpenIIoT.SDK.Packaging;
using OpenIIoT.SDK.Packaging.Manifest;
using OpenIIoT.SDK.Packaging.Operations;
using OpenIIoT.SDK.Platform;
using Utility.OperationResult;

namespace OpenIIoT.Core.Packaging
{
    /// <summary>
    ///     Handles the installation and file management of the Packages used to extend the functionality of the application.
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

            PackageList = new List<Package>();

            logger.ExitMethod();
        }

        #endregion Private Constructors

        #region Public Properties

        /// <summary>
        ///     Gets the list of Packages available for installation.
        /// </summary>
        public IReadOnlyList<Package> Packages => ((List<Package>)PackageList).AsReadOnly();

        #endregion Public Properties

        #region Private Properties

        /// <summary>
        ///     Gets the Platform instance with which file operations are carried out.
        /// </summary>
        private IPlatform Platform => PlatformManager.Platform;

        /// <summary>
        ///     Gets or sets the list of Packages available for installation.
        /// </summary>
        private IList<Package> PackageList { get; set; }

        /// <summary>
        ///     Gets the <see cref="IPlatformManager"/> with which Platform operations are carried out.
        /// </summary>
        private IPlatformManager PlatformManager => Dependency<IPlatformManager>();

        #endregion Private Properties

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

        /// <summary>
        ///     Creates a <see cref="Package"/> file with the specified data.
        /// </summary>
        /// <remarks>
        ///     The resulting Package file is saved to the Packages directory with a filename composed of the Fully Qualified Name
        ///     and Version of the Package.
        /// </remarks>
        /// <param name="data">The data to save.</param>
        /// <returns>A Result containing the result of the operation and the created IPackage instance.</returns>
        public IResult<Package> CreatePackage(byte[] data)
        {
            logger.EnterMethod();
            logger.Info($"Creating new Package...");

            IResult<Package> retVal = new Result<Package>();

            string tempFile = Path.Combine(PlatformManager.Directories.Temp, Guid.NewGuid().ToString());

            logger.Debug($"Saving new Package to '{tempFile}'...");

            retVal.Incorporate(Platform.WriteFileBytes(tempFile, data));

            if (retVal.ResultCode != ResultCode.Failure)
            {
                IResult<Package> readResult = Read(tempFile);

                retVal.Incorporate(readResult);

                if (retVal.ResultCode != ResultCode.Failure)
                {
                    string destinationFilename = GetPackageFilename(readResult.ReturnValue);

                    retVal.Incorporate(Platform.CopyFile(tempFile, destinationFilename, true));

                    if (retVal.ResultCode != ResultCode.Failure)
                    {
                        PackageList.Add(readResult.ReturnValue);

                        retVal.ReturnValue = readResult.ReturnValue;
                        retVal.ReturnValue.Filename = destinationFilename;
                    }
                }
            }

            if (retVal.ResultCode == ResultCode.Failure)
            {
                retVal.AddError("Failed to create a Package from the supplied data.");
            }

            retVal.LogResult(logger);
            logger.ExitMethod();
            return retVal;
        }

        /// <summary>
        ///     Asynchronously creates a <see cref="Package"/> file with the specified data.
        /// </summary>
        /// <remarks>
        ///     The resulting Package file is saved to the Packages directory with a filename composed of the Fully Qualified Name
        ///     and Version of the Package.
        /// </remarks>
        /// <param name="data">The data to save.</param>
        /// <returns>A Result containing the result of the operation and the created IPackage instance.</returns>
        public async Task<IResult<Package>> CreatePackageAsync(byte[] data)
        {
            return await Task.Run(() => CreatePackage(data));
        }

        /// <summary>
        ///     Deletes the <see cref="Package"/> matching the specified Fully Qualified Name from disk.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the <see cref="Package"/> to delete.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public IResult DeletePackage(string fqn)
        {
            logger.EnterMethod(xLogger.Params(fqn));
            logger.Info($"Deleting Package {fqn}...");

            IResult retVal = new Result();
            Package findResult = FindPackage(fqn);

            if (findResult != default(Package))
            {
                string fileName = findResult.Filename;

                IResult deleteResult = Dependency<IPlatformManager>().Platform.DeleteFile(fileName);
                retVal.Incorporate(deleteResult);
            }
            else
            {
                retVal.AddError($"Failed to find Package '{fqn}'.");
            }

            if (retVal.ResultCode == ResultCode.Failure)
            {
                retVal.AddError($"Failed to delete Package '{fqn}'.");
            }

            retVal.LogResult(logger);
            logger.ExitMethod();
            return retVal;
        }

        /// <summary>
        ///     Asynchronously deletes the <see cref="Package"/> matching the specified Fully Qualified Name from disk.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the <see cref="Package"/> to delete.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public async Task<IResult> DeletePackageAsync(string fqn)
        {
            return await Task.Run(() => DeletePackage(fqn));
        }

        /// <summary>
        ///     Fetches the <see cref="Package"/> file matching the specified Fully Qualified Name and returns the binary data.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the <see cref="Package"/> to fetch.</param>
        /// <returns>A Result containing the result of the operation and the read binary data.</returns>
        public IResult<byte[]> FetchPackage(string fqn)
        {
            logger.EnterMethod(xLogger.Params(fqn));
            logger.Info($"Fetching Package '{fqn}'...");

            IResult<byte[]> retVal = new Result<byte[]>();
            Package findResult = FindPackage(fqn);

            if (findResult != default(Package))
            {
                IPlatform platform = Dependency<IPlatformManager>().Platform;

                IResult<byte[]> readResult = platform.ReadFileBytes(findResult.Filename);
                retVal.Incorporate(readResult);
                retVal.ReturnValue = readResult.ReturnValue;
            }
            else
            {
                retVal.AddError($"Failed to find Package '{fqn}'.");
            }

            if (retVal.ResultCode == ResultCode.Failure)
            {
                retVal.AddError($"Failed to fetch Package '{fqn}'");
            }

            retVal.LogResult(logger);
            logger.ExitMethod();
            return retVal;
        }

        /// <summary>
        ///     Asynchronously fetches the <see cref="Package"/> file matching the specified Fully Qualified Name and returns the
        ///     binary data.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the <see cref="Package"/> to fetch.</param>
        /// <returns>A Result containing the result of the operation and the read binary data.</returns>
        public async Task<IResult<byte[]>> FetchPackageAsync(string fqn)
        {
            return await Task.Run(() => FetchPackage(fqn));
        }

        /// <summary>
        ///     <para>
        ///         Scans the <see cref="Packages"/> list for a Package matching the specified Fully Qualified Name and, if found,
        ///         returns the found Package.
        ///     </para>
        ///     <para>
        ///         If a matching Package is not found, the <see cref="ScanPackages()"/> method is invoked to refresh the
        ///         <see cref="Packages"/> list from disk.
        ///     </para>
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Package to find.</param>
        /// <returns>The result of the operation and the found Package, if applicable.</returns>
        public Package FindPackage(string fqn)
        {
            return FindPackage(fqn, true);
        }

        /// <summary>
        ///     <para>
        ///         Asynchronously scans the <see cref="Packages"/> list for a Package matching the specified Fully Qualified Name
        ///         and, if found, returns the found Package.
        ///     </para>
        ///     <para>
        ///         If a matching Package is not found, the <see cref="ScanPackages()"/> method is invoked to refresh the
        ///         <see cref="Packages"/> list from disk.
        ///     </para>
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Package to find.</param>
        /// <returns>The result of the operation and the found Package, if applicable.</returns>
        public async Task<Package> FindPackageAsync(string fqn)
        {
            return await Task.Run(() => FindPackage(fqn));
        }

        /// <summary>
        ///     Installs the specified <see cref="Package"/> (extracts it to disk).
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Package to install.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public IResult InstallPackage(string fqn)
        {
            return InstallPackage(fqn, new PackageInstallationOptions(), string.Empty);
        }

        /// <summary>
        ///     Installs the specified <see cref="Package"/> (extracts it to disk) using the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Package to install.</param>
        /// <param name="options">The installation options for the operation.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public IResult InstallPackage(string fqn, PackageInstallationOptions options)
        {
            return InstallPackage(fqn, options, string.Empty);
        }

        /// <summary>
        ///     Installs the specified <see cref="Package"/> (extracts it to disk) using the specified <paramref name="options"/>
        ///     and PGP <paramref name="publicKey"/>.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Package to install.</param>
        /// <param name="options">The installation options for the operation.</param>
        /// <param name="publicKey">The PGP public key with which to install the Package.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public IResult InstallPackage(string fqn, PackageInstallationOptions options, string publicKey)
        {
            logger.EnterMethod(xLogger.Params(fqn, options, publicKey));
            logger.Info($"Installing Package '{fqn}'...");

            IResult retVal = new Result();
            Package findResult = FindPackage(fqn);

            if (findResult != default(Package))
            {
                PackageExtractor extractor = new PackageExtractor();

                extractor.Updated += (sender, e) => logger.Debug(e.Message);

                // determine the installation directory; should look like \path\to\Plugins\FQN\
                string destination = PlatformManager.Directories.Plugins;
                destination = Path.Combine(destination, findResult.FQN);

                bool overwrite = options?.Overwrite ?? false;
                bool skipVerification = options?.SkipVerification ?? false;

                logger.Debug($"Install directory: '{destination}'; overwrite={overwrite}, skipVerification={skipVerification}");

                try
                {
                    extractor.ExtractPackage(findResult.Filename, destination, overwrite, skipVerification);
                }
                catch (Exception ex)
                {
                    logger.Exception(LogLevel.Debug, ex);
                    retVal.AddError(ex.Message);
                }
            }
            else
            {
                retVal.AddError($"Failed to find Package '{fqn}'.");
            }

            if (retVal.ResultCode == ResultCode.Failure)
            {
                retVal.AddError($"Failed to install Package '{fqn}'.");
            }

            retVal.LogResult(logger);
            logger.ExitMethod();
            return retVal;
        }

        /// <summary>
        ///     Asynchronously installs the specified <see cref="Package"/> (extracts it to disk).
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Package to install.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public async Task<IResult> InstallPackageAsync(string fqn)
        {
            return await Task.Run(() => InstallPackage(fqn, new PackageInstallationOptions(), string.Empty));
        }

        /// <summary>
        ///     Installs the specified <see cref="Package"/> (extracts it to disk) using the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Package to install.</param>
        /// <param name="options">The installation options for the operation.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public async Task<IResult> InstallPackageAsync(string fqn, PackageInstallationOptions options)
        {
            return await Task.Run(() => InstallPackage(fqn, options, string.Empty));
        }

        /// <summary>
        ///     Asynchronously installs the specified <see cref="Package"/> (extracts it to disk) using the specified
        ///     <paramref name="options"/> and PGP <paramref name="publicKey"/>.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Package to install.</param>
        /// <param name="options">The installation options for the operation.</param>
        /// <param name="publicKey">The PGP public key with which to install the Package.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public async Task<IResult> InstallPackageAsync(string fqn, PackageInstallationOptions options, string publicKey)
        {
            return await Task.Run(() => InstallPackage(fqn, options, publicKey));
        }

        /// <summary>
        ///     Scans for and returns a list of all Package files in the configured Packages directory.
        /// </summary>
        /// <returns>A Result containing the result of the operation and the list of found Packages.</returns>
        public IResult<IList<Package>> ScanPackages()
        {
            Guid guid = logger.EnterMethod(true);
            logger.Info("Scanning for Packages...");

            IResult<IList<Package>> retVal = new Result<IList<Package>>();
            retVal.ReturnValue = new List<Package>();

            string directory = PlatformManager.Directories.Packages;

            logger.Debug($"Scanning directory '{directory}'...");

            ManifestExtractor extractor = new ManifestExtractor();
            extractor.Updated += (sender, e) => logger.Debug(e.Message);

            IResult<IList<string>> fileListResult = Platform.ListFiles(directory);
            retVal.Incorporate(fileListResult);

            if (retVal.ResultCode != ResultCode.Failure)
            {
                foreach (string file in fileListResult.ReturnValue)
                {
                    IResult<Package> readResult = Read(file);

                    if (readResult.ResultCode != ResultCode.Failure)
                    {
                        retVal.ReturnValue.Add(readResult.ReturnValue);
                    }
                    else
                    {
                        retVal.AddWarning(readResult.GetLastError());
                    }
                }
            }

            retVal.LogResult(logger);
            logger.ExitMethod(guid);

            return retVal;
        }

        /// <summary>
        ///     Asynchronously scans for and returns a list of all Package files in the configured Package directory.
        /// </summary>
        /// <returns>A Result containing the result of the operation and the list of found Packages.</returns>
        public async Task<IResult<IList<Package>>> ScanPackagesAsync()
        {
            return await Task.Run(() => ScanPackages());
        }

        /// <summary>
        ///     Verifies the specified <see cref="Package"/>.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Package to verify.</param>
        /// <returns>A Result containing the result of the operation and a value indicating whether the Package is valid.</returns>
        public IResult<bool> VerifyPackage(string fqn)
        {
            return VerifyPackage(fqn, string.Empty);
        }

        /// <summary>
        ///     Verifies the specified <see cref="Package"/> using the optionally specified PGP Public Key.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Package to verify.</param>
        /// <param name="publicKey">The optional PGP Public Key with which to verify the package.</param>
        /// <returns>A Result containing the result of the operation and a value indicating whether the Package is valid.</returns>
        public IResult<bool> VerifyPackage(string fqn, string publicKey)
        {
            Guid guid = logger.EnterMethod(xLogger.Params(fqn, publicKey), true);
            logger.Info($"Verifying Package '{fqn}'...");

            IResult<bool> retVal = new Result<bool>();
            Package findResult = FindPackage(fqn);

            if (findResult != default(Package))
            {
                PackageVerifier verifier = new PackageVerifier();
                verifier.Updated += (sender, e) => logger.Debug(e.Message);

                try
                {
                    retVal.ReturnValue = verifier.VerifyPackage(findResult.Filename, publicKey);
                }
                catch (Exception ex)
                {
                    logger.Exception(LogLevel.Debug, ex);
                    retVal.AddError(ex.Message);
                }
            }
            else
            {
                retVal.AddError($"Failed to find Package '{fqn}'.");
            }

            if (retVal.ResultCode == ResultCode.Failure)
            {
                retVal.AddError($"The Package '{fqn}' is invalid.");
            }

            retVal.LogResult(logger);
            logger.ExitMethod(guid);
            return retVal;
        }

        /// <summary>
        ///     Asynchronously verifies the specified <see cref="Package"/> using the optionally specified PGP Public Key.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Package to verify.</param>
        /// <param name="publicKey">The optional PGP Public Key with which to verify the package.</param>
        /// <returns>A Result containing the result of the operation and a value indicating whether the Package is valid.</returns>
        public async Task<IResult<bool>> VerifyPackageAsync(string fqn, string publicKey)
        {
            return await Task.Run(() => VerifyPackage(fqn, publicKey));
        }

        /// <summary>
        ///     Asynchronously verifies the specified <see cref="Package"/>.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Package to verify.</param>
        /// <returns>A Result containing the result of the operation and a value indicating whether the Package is valid.</returns>
        public async Task<IResult<bool>> VerifyPackageAsync(string fqn)
        {
            return await Task.Run(() => VerifyPackage(fqn, string.Empty));
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        ///     <para>Executed upon shutdown of the Manager.</para>
        ///     <para>
        ///         If the specified <see cref="StopType"/> is not <see cref="StopType.Exception"/>, saves the configuration to disk.
        ///     </para>
        /// </summary>
        /// <param name="stopType">The nature of the stoppage.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        protected override IResult Shutdown(StopType stopType = StopType.Stop)
        {
            Guid guid = logger.EnterMethod(true);
            logger.Debug("Performing Shutdown for '" + GetType().Name + "'...");

            IResult retVal = new Result();

            PackageList = default(IList<Package>);

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
        protected override IResult Startup()
        {
            Guid guid = logger.EnterMethod(true);
            logger.Debug("Performing Startup for '" + GetType().Name + "'...");

            IResult retVal = new Result();

            retVal.Incorporate(ScanPackages());

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        ///     <para>
        ///         Scans the <see cref="Packages"/> list for a Package matching the specified Fully Qualified Name and, if found,
        ///         returns the found Package.
        ///     </para>
        ///     <para>
        ///         If a matching Package is not found, the <see cref="ScanPackages()"/> method is invoked to refresh the
        ///         <see cref="Packages"/> list from disk.
        ///     </para>
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Package to find.</param>
        /// <param name="rescanOnNotFound">
        ///     A value indicating whether the <see cref="ScanPackages()"/> method is to be invoked on a failure to find the
        ///     specified Package.
        /// </param>
        /// <returns>The result of the operation and the found Package, if applicable.</returns>
        private Package FindPackage(string fqn, bool rescanOnNotFound)
        {
            logger.EnterMethod(xLogger.Params(fqn, rescanOnNotFound));
            Package retVal;

            retVal = PackageList.Where(p => p.FQN == fqn).FirstOrDefault();

            if (retVal == default(Package))
            {
                if (rescanOnNotFound)
                {
                    ScanPackages();
                    return FindPackage(fqn, false);
                }
            }

            logger.ExitMethod();
            return retVal;
        }

        /// <summary>
        ///     Creates a <see cref="Package"/> instance with file metadata from the given file and the given
        ///     <see cref="PackageManifest"/> .
        /// </summary>
        /// <param name="fileName">The filename from which to retrieve the Package metadata.</param>
        /// <param name="manifest">The Manifest with which to initialize the <see cref="Package"/> instance.</param>
        /// <returns>The created Package.</returns>
        private Package GetPackage(string fileName, PackageManifest manifest)
        {
            FileInfo info = new FileInfo(fileName);

            return new Package(fileName, info.LastWriteTime, manifest);
        }

        /// <summary>
        ///     Creates and returns a valid filename for the specified <see cref="Package"/>.
        /// </summary>
        /// <param name="package">The Package for which the filename is to be created.</param>
        /// <returns>The created filename.</returns>
        private string GetPackageFilename(Package package)
        {
            string filename = package.FQN + "." + package.Version + PackagingConstants.PackageFilenameExtension;

            foreach (char c in Path.GetInvalidFileNameChars())
            {
                filename = filename.Replace(c, SDK.Packaging.PackagingConstants.PackageFilenameInvalidCharacterSubstitution);
            }

            return Path.Combine(PlatformManager.Directories.Packages, filename);
        }

        /// <summary>
        ///     Reads the specified file and, if it is a valid <see cref="Package"/>, returns an <see cref="Package"/> instance
        ///     from the contents.
        /// </summary>
        /// <param name="fileName">The filename of the file to read.</param>
        /// <returns>A Result containing the result of the operation and the created IPackage instance.</returns>
        private IResult<Package> Read(string fileName)
        {
            logger.EnterMethod(true);
            logger.Debug($"Reading Package '{fileName}'...");

            IResult<Package> retVal = new Result<Package>();
            ManifestExtractor extractor = new ManifestExtractor();

            extractor.Updated += (sender, e) => logger.Debug(e.Message);

            PackageManifest manifest;

            try
            {
                manifest = extractor.ExtractManifest(fileName);

                retVal.ReturnValue = GetPackage(fileName, manifest);
            }
            catch (Exception ex)
            {
                retVal.AddError(ex.Message);
                retVal.AddError($"Unable to read Package '{Path.GetFileName(fileName)}'.");
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod();

            return retVal;
        }

        #endregion Private Methods
    }
}