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

namespace OpenIIoT.Core.Packaging
{
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
    using OpenIIoT.SDK.Common.Discovery;
    using OpenIIoT.SDK.Common.OperationResult;
    using OpenIIoT.SDK.Common.Provider.EventProvider;
    using OpenIIoT.SDK.Packaging;
    using OpenIIoT.SDK.Packaging.Manifest;
    using OpenIIoT.SDK.Packaging.Operations;
    using OpenIIoT.SDK.Platform;

    /// <summary>
    ///     Handles the installation and file management of the Packages used to extend the functionality of the application.
    /// </summary>
    [Discoverable]
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
            Guid guid = logger.EnterMethod();

            ManagerName = "Package Manager";

            RegisterDependency<IApplicationManager>(manager);
            RegisterDependency<IPlatformManager>(platformManager);

            PackageList = new List<IPackage>();
            PackageArchiveList = new List<IPackageArchive>();

            PackageFactory = new PackageFactory(PlatformManager);
            PackageScanner = new PackageScanner(PlatformManager, PackageFactory);

            ChangeState(State.Initialized);

            logger.ExitMethod(guid);
        }

        #endregion Private Constructors

        #region Public Events

        /// <summary>
        ///     Occurs when a <see cref="IPackageArchive"/> is added.
        /// </summary>
        [Event(Description = "Occurs when a Package Archive is added.")]
        public event EventHandler<PackageArchiveEventArgs> PackageArchiveAdded;

        /// <summary>
        ///     Occurs when a <see cref="IPackageArchive"/> is deleted.
        /// </summary>
        [Event(Description = "Occurs when a Package Archive is deleted.")]
        public event EventHandler<PackageArchiveEventArgs> PackageArchiveDeleted;

        /// <summary>
        ///     Occurs when a <see cref="IPackage"/> is installed.
        /// </summary>
        [Event(Description = "Occurs when a Package is installed.")]
        public event EventHandler<PackageInstallEventArgs> PackageInstalled;

        /// <summary>
        ///     Occurs when a <see cref="IPackage"/> is uninstalled.
        /// </summary>
        [Event(Description = "Occurs when a Package is uninstalled.")]
        public event EventHandler<PackageInstallEventArgs> PackageUninstalled;

        #endregion Public Events

        #region Public Properties

        /// <summary>
        ///     Gets the list of <see cref="IPackageArchive"/> files available for installation.
        /// </summary>
        public IReadOnlyList<IPackageArchive> PackageArchives => ((List<IPackageArchive>)PackageArchiveList).AsReadOnly();

        /// <summary>
        ///     Gets the list of installed <see cref="IPackage"/> s.
        /// </summary>
        public IReadOnlyList<IPackage> Packages => ((List<IPackage>)PackageList).AsReadOnly();

        #endregion Public Properties

        #region Private Properties

        /// <summary>
        ///     Gets the Platform instance with which file operations are carried out.
        /// </summary>
        private IPlatform Platform => PlatformManager.Platform;

        /// <summary>
        ///     Gets or sets the list of <see cref="IPackageArchive"/> s available for installation.
        /// </summary>
        private IList<IPackageArchive> PackageArchiveList { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="IPackageFactory"/> used to facilitate scanning of <see cref="IPackage"/> and
        ///     <see cref="IPackageArchive"/> instances.
        /// </summary>
        private IPackageFactory PackageFactory { get; set; }

        /// <summary>
        ///     Gets or sets the list of installed <see cref="IPackage"/> s.
        /// </summary>
        private IList<IPackage> PackageList { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="IPackageScanner"/> used to scan for <see cref="IPackage"/> and
        ///     <see cref="IPackageArchive"/> instances.
        /// </summary>
        private IPackageScanner PackageScanner { get; set; }

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
        ///     Adds a <see cref="IPackageArchive"/> from the specified binary <paramref name="data"/>.
        /// </summary>
        /// <remarks>
        ///     The resulting Package archive file is saved to the Packages directory with a filename composed of the Fully
        ///     Qualified Name and Version of the Package.
        /// </remarks>
        /// <param name="data">The binary data to save.</param>
        /// <returns>A Result containing the result of the operation and the created <see cref="IPackageArchive"/> instance.</returns>
        public IResult<IPackageArchive> AddPackageArchive(byte[] data)
        {
            Guid guid = logger.EnterMethod();
            logger.Info("Creating new Package...");

            IResult<IPackageArchive> retVal = new Result<IPackageArchive>();
            string tempFile = Path.Combine(PlatformManager.Directories.Temp, Guid.NewGuid().ToString());
            string destinationFilename = default(string);

            if (data.Length == 0)
            {
                retVal.AddError($"The specified binary payload is empty.");
            }
            else
            {
                logger.Debug($"Saving new Package to '{tempFile}'...");
                retVal.Incorporate(Platform.WriteFileBytes(tempFile, data));

                if (retVal.ResultCode != ResultCode.Failure)
                {
                    IResult<IPackageArchive> readResult = PackageFactory.GetPackageArchive(tempFile);

                    retVal.Incorporate(readResult);

                    if (retVal.ResultCode != ResultCode.Failure)
                    {
                        IPackageArchive package = readResult.ReturnValue;

                        destinationFilename = package.FQN + "." + package.Manifest.Version + PackagingConstants.PackageFilenameExtension;
                        destinationFilename = ReplaceInvalidCharacters(destinationFilename);
                        destinationFilename = Path.Combine(PlatformManager.Directories.PackageArchives, destinationFilename);

                        logger.Debug($"Copying temporary Package '{tempFile}' to final destination '{destinationFilename}'...");
                        retVal.Incorporate(Platform.CopyFile(tempFile, destinationFilename, true));

                        if (retVal.ResultCode != ResultCode.Failure)
                        {
                            ScanPackageArchives();
                            retVal.ReturnValue = FindPackageArchive(readResult.ReturnValue.FQN);
                        }
                    }
                }
            }

            if (retVal.ResultCode != ResultCode.Failure)
            {
                logger.Debug($"Package Archive successfully saved to {destinationFilename}. Sending PackageArchiveAdded Event...");
                Task.Run(() => PackageArchiveAdded?.Invoke(this, new PackageArchiveEventArgs(retVal.ReturnValue)));
            }

            retVal.LogResult(logger);
            logger.ExitMethod(guid);
            return retVal;
        }

        /// <summary>
        ///     Asynchronously adds a <see cref="IPackageArchive"/> from the specified binary <paramref name="data"/>.
        /// </summary>
        /// <remarks>
        ///     The resulting Package archive file is saved to the Packages directory with a filename composed of the Fully
        ///     Qualified Name and Version of the Package.
        /// </remarks>
        /// <param name="data">The binary data to save.</param>
        /// <returns>A Result containing the result of the operation and the created <see cref="IPackageArchive"/> instance.</returns>
        public Task<IResult<IPackageArchive>> AddPackageArchiveAsync(byte[] data)
        {
            return Task.Run(() => AddPackageArchive(data));
        }

        /// <summary>
        ///     Deletes the specified <see cref="IPackageArchive"/> from disk.
        /// </summary>
        /// <param name="packageArchive">The <see cref="IPackageArchive"/> to delete.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public IResult DeletePackageArchive(IPackageArchive packageArchive)
        {
            Guid guid = logger.EnterMethod(xLogger.Params(packageArchive));
            logger.Info($"Deleting Package {packageArchive?.FQN}...");

            IResult retVal = new Result();

            if (packageArchive == default(IPackageArchive))
            {
                retVal.AddError($"The specified Package Archive is null.");
            }
            else if (string.IsNullOrEmpty(packageArchive.FileName))
            {
                retVal.AddError($"The specified Package Archive contains an null or empty Filename.");
            }
            else if (!Platform.FileExists(packageArchive.FileName))
            {
                retVal.AddError($"The specified Package Archive file '{packageArchive.FileName}' can not be found.");
            }
            else
            {
                logger.Debug($"Deleting Package file '{packageArchive.FileName}'...");
                retVal = Platform.DeleteFile(packageArchive.FileName);
            }

            if (retVal.ResultCode != ResultCode.Failure)
            {
                logger.Debug($"Package {packageArchive.FileName} deleted successfully.  Sending PackageArchiveDeleted Event...");
                Task.Run(() => PackageArchiveDeleted?.Invoke(this, new PackageArchiveEventArgs(packageArchive)));
            }

            retVal.LogResult(logger);
            logger.ExitMethod(guid);
            return retVal;
        }

        /// <summary>
        ///     Asynchronously deletes the specified <see cref="IPackageArchive"/> from disk.
        /// </summary>
        /// <param name="packageArchive">The <see cref="IPackageArchive"/> to delete.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public Task<IResult> DeletePackageArchiveAsync(IPackageArchive packageArchive)
        {
            return Task.Run(() => DeletePackageArchive(packageArchive));
        }

        /// <summary>
        ///     Fetches the specified <paramref name="packageArchive"/> and returns the binary data.
        /// </summary>
        /// <param name="packageArchive">The <see cref="IPackageArchive"/> to fetch.</param>
        /// <returns>
        ///     A Result containing the result of the operation and the <see cref="byte"/> array containing the fetched data.
        /// </returns>
        public IResult<byte[]> FetchPackageArchive(IPackageArchive packageArchive)
        {
            Guid guid = logger.EnterMethod(xLogger.Params(packageArchive));
            logger.Info($"Fetching Package Archive '{packageArchive?.FQN}'...");

            IResult<byte[]> retVal = new Result<byte[]>();

            if (packageArchive == default(IPackageArchive))
            {
                retVal.AddError($"The specified Package Archive is null.");
            }
            else if (string.IsNullOrEmpty(packageArchive.FileName))
            {
                retVal.AddError($"The specified Package Archive contains an null or empty Filename.");
            }
            else if (!Platform.FileExists(packageArchive.FileName))
            {
                retVal.AddError($"The specified Package Archive file '{packageArchive.FileName}' can not be found.");
            }
            else
            {
                logger.Debug($"Package Archive '{packageArchive.FQN}' found in '{packageArchive.FileName}'; reading from disk...");
                retVal = Platform.ReadFileBytes(packageArchive.FileName);
            }

            retVal.LogResult(logger);
            logger.ExitMethod(guid);
            return retVal;
        }

        /// <summary>
        ///     Asynchronously fetches the specified <paramref name="packageArchive"/> and returns the binary data.
        /// </summary>
        /// <param name="packageArchive">The <see cref="IPackageArchive"/> to fetch.</param>
        /// <returns>
        ///     A Result containing the result of the operation and the <see cref="byte"/> array containing the fetched data.
        /// </returns>
        public Task<IResult<byte[]>> FetchPackageArchiveAsync(IPackageArchive packageArchive)
        {
            return Task.Run(() => FetchPackageArchive(packageArchive));
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
        public IPackage FindPackage(string fqn)
        {
            return FindPackage(fqn, true);
        }

        /// <summary>
        ///     <para>
        ///         Searches the <see cref="PackageArchives"/> list for a <see cref="IPackageArchive"/> matching the specified
        ///         <paramref name="fqn"/> and, if found, returns the found instance.
        ///     </para>
        ///     <para>
        ///         If a matching Package archive is not found, the <see cref="ScanPackageArchives()"/> method is invoked to
        ///         refresh the <see cref="PackageArchives"/> list from disk.
        ///     </para>
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the <see cref="IPackageArchive"/> to find.</param>
        /// <returns>The found <see cref="IPackageArchive"/>.</returns>
        public IPackageArchive FindPackageArchive(string fqn)
        {
            return FindPackageArchive(fqn, true);
        }

        /// <summary>
        ///     <para>
        ///         Asynchronously searches the <see cref="PackageArchives"/> list for a <see cref="IPackageArchive"/> matching the
        ///         specified <paramref name="fqn"/> and, if found, returns the found instance.
        ///     </para>
        ///     <para>
        ///         If a matching Package archive is not found, the <see cref="ScanPackageArchives()"/> method is invoked to
        ///         refresh the <see cref="PackageArchives"/> list from disk.
        ///     </para>
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the <see cref="IPackageArchive"/> to find.</param>
        /// <returns>The found <see cref="IPackageArchive"/>.</returns>
        public Task<IPackageArchive> FindPackageArchiveAsync(string fqn)
        {
            return Task.Run(() => FindPackageArchive(fqn));
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
        public Task<IPackage> FindPackageAsync(string fqn)
        {
            return Task.Run(() => FindPackage(fqn));
        }

        /// <summary>
        ///     Installs the specified <paramref name="packageArchive"/>.
        /// </summary>
        /// <param name="packageArchive">The <see cref="IPackageArchive"/> to install.</param>
        /// <returns>A Result containing the result of the operation and the installed <see cref="IPackage"/>.</returns>
        public IResult<IPackage> InstallPackage(IPackageArchive packageArchive)
        {
            return InstallPackage(packageArchive, new PackageInstallationOptions());
        }

        /// <summary>
        ///     Installs the specified <paramref name="packageArchive"/> with the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="packageArchive">The <see cref="IPackageArchive"/> to install.</param>
        /// <param name="options">The <see cref="PackageInstallationOptions"/> for the installation.</param>
        /// <returns>A Result containing the result of the operation and the installed <see cref="IPackage"/>.</returns>
        public IResult<IPackage> InstallPackage(IPackageArchive packageArchive, PackageInstallationOptions options)
        {
            Guid guid = logger.EnterMethod(xLogger.Params(packageArchive, options), true);
            logger.Info($"Installing Package '{packageArchive?.FQN}' from '{packageArchive?.FileName}'...");

            IResult<IPackage> retVal = new Result<IPackage>();
            string destination = default(string);

            if (packageArchive == default(IPackageArchive))
            {
                retVal.AddError($"The specified Package Archive is null.");
            }
            else if (string.IsNullOrEmpty(packageArchive.FileName))
            {
                retVal.AddError($"The specified Package Archive contains a null or empty FileName.");
            }
            else if (!Platform.FileExists(packageArchive.FileName))
            {
                retVal.AddError($"The specified Package Archive file '{packageArchive.FileName}' can not be found.");
            }
            else if (options == default(PackageInstallationOptions))
            {
                retVal.AddError($"Installation options were specified but are null.");
            }
            else if (options?.PublicKey != default(string) && options.PublicKey == string.Empty)
            {
                retVal.AddError($"The PGP installation key is specified but is empty.");
            }
            else
            {
                PackageExtractor extractor = new PackageExtractor();
                extractor.Updated += (sender, e) => logger.Debug($"    PackageExtractor: {e.Message}");

                // determine the installation directory; should look like \path\to\Plugins\FQN\
                destination = ReplaceInvalidCharacters(packageArchive.FQN);
                destination = Path.Combine(PlatformManager.Directories.Packages, destination);

                logger.Debug($"Install directory: '{destination}'; overwrite={options.Overwrite}, skipVerification={options.SkipVerification}");

                try
                {
                    extractor.ExtractPackage(packageArchive.FileName, destination, options?.PublicKey, options.Overwrite, options.SkipVerification);
                }
                catch (Exception ex)
                {
                    logger.Exception(LogLevel.Debug, ex);
                    retVal.AddError(ex.Message);
                }

                ScanPackages();

                retVal.ReturnValue = FindPackage(packageArchive.FQN);
            }

            if (retVal.ResultCode != ResultCode.Failure)
            {
                logger.Debug($"Package {retVal.ReturnValue.FQN} installed successfully. Sending PackageInstalled Event...");
                Task.Run(() => PackageInstalled?.Invoke(this, new PackageInstallEventArgs(retVal.ReturnValue, destination)));
            }

            retVal.LogResult(logger);
            logger.ExitMethod(guid);
            return retVal;
        }

        /// <summary>
        ///     Asynchronously installs the specified <paramref name="packageArchive"/>.
        /// </summary>
        /// <param name="packageArchive">The <see cref="IPackageArchive"/> to install.</param>
        /// <returns>A Result containing the result of the operation and the installed <see cref="IPackage"/>.</returns>
        public async Task<IResult<IPackage>> InstallPackageAsync(IPackageArchive packageArchive)
        {
            return await Task.Run(() => InstallPackage(packageArchive, new PackageInstallationOptions()));
        }

        /// <summary>
        ///     Asynchronously installs the specified <paramref name="packageArchive"/> with the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="packageArchive">The <see cref="IPackageArchive"/> to install.</param>
        /// <param name="options">The <see cref="PackageInstallationOptions"/> for the installation.</param>
        /// <returns>A Result containing the result of the operation and the installed <see cref="IPackage"/>.</returns>
        public async Task<IResult<IPackage>> InstallPackageAsync(IPackageArchive packageArchive, PackageInstallationOptions options)
        {
            return await Task.Run(() => InstallPackage(packageArchive, options));
        }

        /// <summary>
        ///     Scans for and returns a list of available <see cref="IPackageArchive"/> instances in the configured PackageArchives directory.
        /// </summary>
        /// <returns>
        ///     A Result containing the result of the operation and the list of found <see cref="IPackageArchive"/> s
        /// </returns>
        public IResult<IList<IPackageArchive>> ScanPackageArchives()
        {
            Guid guid = logger.EnterMethod(true);

            IResult<IList<IPackageArchive>> retVal = new Result<IList<IPackageArchive>>();
            retVal.ReturnValue = PackageArchiveList;

            IResult<IList<IPackageArchive>> scanResult = PackageScanner.ScanPackageArchives();
            retVal.Incorporate(scanResult);

            if (scanResult.ResultCode != ResultCode.Failure)
            {
                retVal.ReturnValue = scanResult.ReturnValue;
                PackageArchiveList = retVal.ReturnValue;
            }

            retVal.LogResult(logger);
            logger.ExitMethod(guid);
            return retVal;
        }

        /// <summary>
        ///     Asynchronously scans for and returns a list of all <see cref="IPackageArchive"/> instances in the configured
        ///     PackageArchives directory.
        /// </summary>
        /// <returns>
        ///     A Result containing the result of the operation and the list of found <see cref="IPackageArchive"/> s.
        /// </returns>
        public Task<IResult<IList<IPackageArchive>>> ScanPackageArchivesAsync()
        {
            return Task.Run(() => ScanPackageArchives());
        }

        /// <summary>
        ///     Scans for and returns a list of installed <see cref="IPackage"/> instances in the configured Packages directory.
        /// </summary>
        /// <returns>A Result containing the result of the operation and the list of found <see cref="IPackage"/> s.</returns>
        public IResult<IList<IPackage>> ScanPackages()
        {
            Guid guid = logger.EnterMethod(true);

            IResult<IList<IPackage>> retVal = new Result<IList<IPackage>>();
            retVal.ReturnValue = PackageList;

            IResult<IList<IPackage>> scanResult = PackageScanner.ScanPackages();
            retVal.Incorporate(scanResult);

            if (retVal.ResultCode != ResultCode.Failure)
            {
                retVal.ReturnValue = scanResult.ReturnValue;
                PackageList = retVal.ReturnValue;
            }

            retVal.LogResult(logger);
            logger.ExitMethod(guid);
            return retVal;
        }

        /// <summary>
        ///     Asynchronously scans for and returns a list of installed <see cref="IPackage"/> instances in the configured
        ///     Packages directory.
        /// </summary>
        /// <returns>A Result containing the result of the operation and the list of found <see cref="IPackage"/> s.</returns>
        public Task<IResult<IList<IPackage>>> ScanPackagesAsync()
        {
            return Task.Run(() => ScanPackages());
        }

        /// <summary>
        ///     Uninstalls the specified <paramref name="package"/>.
        /// </summary>
        /// <param name="package">The <see cref="IPackage"/> to uninstall.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public IResult UninstallPackage(IPackage package)
        {
            Guid guid = logger.EnterMethod(xLogger.Params(package), true);
            logger.Info($"Uninstalling Package '{package?.FQN}' from '{package?.DirectoryName}'...");

            IResult retVal = new Result();

            if (package == default(IPackage))
            {
                retVal.AddError($"The specified Package is null.");
            }
            else if (string.IsNullOrEmpty(package.DirectoryName))
            {
                retVal.AddError($"The specified Package contains a null or empty DirectoryName.");
            }
            else if (!Platform.DirectoryExists(package.DirectoryName))
            {
                retVal.AddError($"The specified Package directory '{package.DirectoryName}' can not be found.");
            }
            else
            {
                retVal.Incorporate(Platform.DeleteDirectory(package.DirectoryName, true));
            }

            if (retVal.ResultCode != ResultCode.Failure)
            {
                logger.Debug($"Package {package.FQN} uninstalled successfully.  Sending PackageUninstalled Event...");
                Task.Run(() => PackageUninstalled?.Invoke(this, new PackageInstallEventArgs(package, package.DirectoryName)));
            }

            retVal.LogResult(logger);
            logger.ExitMethod(guid);
            return retVal;
        }

        /// <summary>
        ///     Asynchronously uninstalls the specified <paramref name="package"/>.
        /// </summary>
        /// <param name="package">The <see cref="IPackage"/> to uninstall.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public Task<IResult> UninstallPackageAsync(IPackage package)
        {
            return Task.Run(() => UninstallPackage(package));
        }

        /// <summary>
        ///     Verifies the specified <paramref name="packageArchive"/>.
        /// </summary>
        /// <param name="packageArchive">The <see cref="IPackageArchive"/> to verify.</param>
        /// <returns>
        ///     A Result containing the result of the operation and a value indicating whether the <see cref="IPackageArchive"/> is valid.
        /// </returns>
        public IResult<bool> VerifyPackageArchive(IPackageArchive packageArchive)
        {
            return VerifyPackageArchive(packageArchive, string.Empty);
        }

        /// <summary>
        ///     Verifies the specified <paramref name="packageArchive"/> using the specified <paramref name="publicKey"/>.
        /// </summary>
        /// <param name="packageArchive">The <see cref="IPackageArchive"/> to verify.</param>
        /// <param name="publicKey">The PGP Public Key with which to verify the package.</param>
        /// <returns>
        ///     A Result containing the result of the operation and a value indicating whether the <see cref="IPackageArchive"/> is valid.
        /// </returns>
        public IResult<bool> VerifyPackageArchive(IPackageArchive packageArchive, string publicKey)
        {
            Guid guid = logger.EnterMethod(xLogger.Params(packageArchive, publicKey), true);
            logger.Info($"Verifying Package '{packageArchive?.FQN}'...");

            IResult<bool> retVal = new Result<bool>();

            if (packageArchive == default(IPackageArchive))
            {
                retVal.AddError($"The specified Package Archive is null.");
            }
            else if (string.IsNullOrEmpty(packageArchive.FileName))
            {
                retVal.AddError($"The specified Package Archive contains a null or empty FileName.");
            }
            else if (!Platform.FileExists(packageArchive.FileName))
            {
                retVal.AddError($"The specified Package Archive file '{packageArchive.FileName}' can not be found.");
            }
            else
            {
                PackageVerifier verifier = new PackageVerifier();
                verifier.Updated += (sender, e) =>
                {
                    logger.Debug($"     PackageVerifier: {e.Message}");
                    retVal.AddInfo(e.Message);
                };

                try
                {
                    retVal.ReturnValue = verifier.VerifyPackage(packageArchive.FileName, publicKey);
                }
                catch (Exception ex)
                {
                    logger.Exception(LogLevel.Debug, ex);
                    retVal.AddError(ex.Message);
                }
            }

            retVal.LogResult(logger);
            logger.ExitMethod(guid);
            return retVal;
        }

        /// <summary>
        ///     Asynchronously verifies the specified <paramref name="packageArchive"/> using the specified <paramref name="publicKey"/>.
        /// </summary>
        /// <param name="packageArchive">The <see cref="IPackageArchive"/> to verify.</param>
        /// <param name="publicKey">The PGP Public Key with which to verify the package.</param>
        /// <returns>
        ///     A Result containing the result of the operation and a value indicating whether the <see cref="IPackageArchive"/> is valid.
        /// </returns>
        public Task<IResult<bool>> VerifyPackageArchiveAsync(IPackageArchive packageArchive, string publicKey)
        {
            return Task.Run(() => VerifyPackageArchive(packageArchive, publicKey));
        }

        /// <summary>
        ///     Asynchronously verifies the specified <paramref name="packageArchive"/>.
        /// </summary>
        /// <param name="packageArchive">The <see cref="IPackageArchive"/> to verify.</param>
        /// <returns>
        ///     A Result containing the result of the operation and a value indicating whether the <see cref="IPackageArchive"/> is valid.
        /// </returns>
        public Task<IResult<bool>> VerifyPackageArchiveAsync(IPackageArchive packageArchive)
        {
            return Task.Run(() => VerifyPackageArchive(packageArchive));
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

            PackageList = default(IList<IPackage>);

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

            IResult<IList<IPackage>> packageScanResult = PackageScanner.ScanPackages();
            retVal.Incorporate(packageScanResult);
            PackageList = packageScanResult.ReturnValue;

            IResult<IList<IPackageArchive>> packageArchiveScanResult = PackageScanner.ScanPackageArchives();
            retVal.Incorporate(packageArchiveScanResult);
            PackageArchiveList = packageArchiveScanResult.ReturnValue;

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        ///     <para>
        ///         Searches the <see cref="PackageList"/> for a <see cref="IPackage"/> matching the specified
        ///         <paramref name="fqn"/> and, if found, returns the found instance.
        ///     </para>
        ///     <para>
        ///         If a matching Package is not found, the <see cref="ScanPackages()"/> method is invoked to refresh the
        ///         <see cref="PackageList"/> from disk.
        ///     </para>
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the <see cref="IPackage"/> to find.</param>
        /// <param name="rescanOnNotFound">
        ///     A value indicating whether the <see cref="ScanPackages()"/> method is to be invoked on a failure to find the
        ///     specified Package.
        /// </param>
        /// <returns>The found <see cref="IPackage"/>.</returns>
        private IPackage FindPackage(string fqn, bool rescanOnNotFound)
        {
            logger.EnterMethod(xLogger.Params(fqn, rescanOnNotFound));
            IPackage retVal;

            retVal = PackageList.Where(p => p.FQN == fqn).FirstOrDefault();

            if (retVal == default(IPackage))
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
        ///     <para>
        ///         Searches the <see cref="PackageArchiveList"/> for a <see cref="IPackageArchive"/> matching the specified
        ///         <paramref name="fqn"/> and, if found, returns the found instance.
        ///     </para>
        ///     <para>
        ///         If a matching Package Archive is not found, the <see cref="ScanPackageArchives()"/> method is invoked to
        ///         refresh the <see cref="PackageArchiveList"/> from disk.
        ///     </para>
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the <see cref="IPackageArchive"/> to find.</param>
        /// <param name="rescanOnNotFound">
        ///     A value indicating whether the <see cref="ScanPackageArchives()"/> method is to be invoked on a failure to find the
        ///     specified Package Archive.
        /// </param>
        /// <returns>The found <see cref="IPackageArchive"/>.</returns>
        private IPackageArchive FindPackageArchive(string fqn, bool rescanOnNotFound)
        {
            logger.EnterMethod(xLogger.Params(fqn, rescanOnNotFound));
            IPackageArchive retVal;

            retVal = PackageArchiveList.Where(p => p.FQN == fqn).FirstOrDefault();

            if (retVal == default(IPackageArchive))
            {
                if (rescanOnNotFound)
                {
                    ScanPackageArchives();
                    return FindPackageArchive(fqn, false);
                }
            }

            logger.ExitMethod();
            return retVal;
        }

        /// <summary>
        ///     Replaces invalid characters in the specified <paramref name="path"/> with the character specified in <see cref="PackagingConstants.PackageFilenameInvalidCharacterSubstitution"/>.
        /// </summary>
        /// <param name="path">The path in which to replace invalid characters.</param>
        /// <returns>The specified path with invalid characters replaced.</returns>
        private string ReplaceInvalidCharacters(string path)
        {
            string retVal = path;

            foreach (char c in Path.GetInvalidFileNameChars())
            {
                retVal = retVal.Replace(c, PackagingConstants.PackageFilenameInvalidCharacterSubstitution);
            }

            return retVal;
        }

        #endregion Private Methods
    }
}