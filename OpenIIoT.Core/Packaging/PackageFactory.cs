/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄███████▄                                                                 ▄████████
      █     ███    ███                                                                ███    ███
      █     ███    ███   ▄█████   ▄██████    █  █▄     ▄█████     ▄████▄     ▄█████   ███    █▀    ▄█████   ▄██████     ██     ██████     █████ ▄█   ▄
      █     ███    ███   ██   ██ ██    ██   ██ ▄██▀    ██   ██   ██    ▀    ██   █   ▄███▄▄▄       ██   ██ ██    ██ ▀███████▄ ██    ██   ██  ██ ██   █▄
      █   ▀█████████▀    ██   ██ ██    ▀    ██▐█▀      ██   ██  ▄██        ▄██▄▄    ▀▀███▀▀▀       ██   ██ ██    ▀      ██  ▀ ██    ██  ▄██▄▄█▀ ▀▀▀▀▀██
      █     ███        ▀████████ ██    ▄  ▀▀████     ▀████████ ▀▀██ ███▄  ▀▀██▀▀      ███        ▀████████ ██    ▄      ██    ██    ██ ▀███████ ▄█   ██
      █     ███          ██   ██ ██    ██   ██ ▀██▄    ██   ██   ██    ██   ██   █    ███          ██   ██ ██    ██     ██    ██    ██   ██  ██ ██   ██
      █    ▄████▀        ██   █▀ ██████▀    ▀█   ▀█▀   ██   █▀   ██████▀    ███████   ███          ██   █▀ ██████▀     ▄██▀    ██████    ██  ██  █████
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Creates instances of IPackage and IPackageArchive from disk.
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
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using Newtonsoft.Json;
    using NLog.xLogger;
    using OpenIIoT.SDK.Common.OperationResult;
    using OpenIIoT.SDK.Packaging;
    using OpenIIoT.SDK.Packaging.Manifest;
    using OpenIIoT.SDK.Packaging.Operations;
    using OpenIIoT.SDK.Platform;

    /// <summary>
    ///     Creates instances of <see cref="IPackage"/> and <see cref="IPackageFactory"/> from disk.
    /// </summary>
    public class PackageFactory : IPackageFactory
    {
        #region Private Fields

        /// <summary>
        ///     The Logger for this class.
        /// </summary>
        private static xLogger logger = xLogManager.GetCurrentClassxLogger();

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PackageFactory"/> class.
        /// </summary>
        [ExcludeFromCodeCoverage]
        public PackageFactory()
            : this(ApplicationManager.GetInstance().GetManager<IPlatformManager>(), new ManifestExtractor())
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PackageFactory"/> class with the specified <paramref name="platformManager"/>.
        /// </summary>
        /// <param name="platformManager">The <see cref="IPlatformManager"/> instance for the application.</param>
        public PackageFactory(IPlatformManager platformManager)
            : this(platformManager, new ManifestExtractor())
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PackageFactory"/> class with the specified
        ///     <paramref name="platformManager"/> and <paramref name="manifestExtractor"/>.
        /// </summary>
        /// <param name="platformManager">The <see cref="IPlatformManager"/> instance for the application.</param>
        /// <param name="manifestExtractor">
        ///     The <see cref="IManifestExtractor"/> with which to create <see cref="IPackageArchive"/> instances.
        /// </param>
        public PackageFactory(IPlatformManager platformManager, IManifestExtractor manifestExtractor)
        {
            PlatformManager = platformManager;
            ManifestExtractor = manifestExtractor;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        ///     Gets the current <see cref="IPlatform"/> instance.
        /// </summary>
        private IPlatform Platform => PlatformManager.Platform;

        /// <summary>
        ///     Gets or sets the <see cref="IManifestExtractor"/> instance with which to create <see cref="IPackageArchive"/> instances.
        /// </summary>
        private IManifestExtractor ManifestExtractor { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="IPlatformManager"/> for the application.
        /// </summary>
        private IPlatformManager PlatformManager { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///     Retrieves a <see cref="IPackage"/> instance from the specified <paramref name="directoryName"/>, if the directory
        ///     contains a valid Package.
        /// </summary>
        /// <param name="directoryName">the directory from which to retrieve the <see cref="IPackage"/>.</param>
        /// <returns>A Result containing the result of the operation and the retrieved <see cref="IPackage"/>.</returns>
        public IResult<IPackage> GetPackage(string directoryName)
        {
            Guid guid = logger.EnterMethod(xLogger.Params(directoryName), true);
            logger.Debug($"Attempting to get Package from '{directoryName}'...");

            IResult<IPackage> retVal = new Result<IPackage>();
            string manifestFileName = Path.Combine(directoryName, "." + PackagingConstants.ManifestFilename);

            logger.Debug($"Attempting to read Package Manifest from '{manifestFileName}'...");
            IResult<string> manifestReadResult = Platform.ReadFileText(manifestFileName);
            retVal.Incorporate(manifestReadResult);

            if (retVal.ResultCode != ResultCode.Failure)
            {
                try
                {
                    logger.Debug($"Read Package Manifest successfully.  Deserializing...");
                    PackageManifest manifest = JsonConvert.DeserializeObject<PackageManifest>(manifestReadResult.ReturnValue);

                    retVal.ReturnValue = new Package(new DirectoryInfo(directoryName), manifest);
                }
                catch (Exception ex)
                {
                    logger.Checkpoint("PackageManifest", xLogger.Vars(manifestReadResult), xLogger.Names("manifestReadResult"));
                    retVal.AddError($"Error deserializing Package Manifest '{manifestFileName}': {ex.Message}.");
                    retVal.AddError($"Unable to find Package in '{directoryName}'");
                }
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(guid);
            return retVal;
        }

        /// <summary>
        ///     Retrieves a <see cref="IPackageArchive"/> instance from the specified <paramref name="fileName"/>, if the file is a
        ///     valid Package Archive.
        /// </summary>
        /// <param name="fileName">The file from which to retrieve the <see cref="IPackageArchive"/>.</param>
        /// <returns>A Result containing the result of the operation and the retrieved <see cref="IPackageArchive"/>.</returns>
        public IResult<IPackageArchive> GetPackageArchive(string fileName)
        {
            Guid guid = logger.EnterMethod(xLogger.Params(fileName), true);

            logger.Debug($"Attempting to get Package Archive from '{Path.GetFileName(fileName)}'...");

            IResult<IPackageArchive> retVal = new Result<IPackageArchive>();

            ManifestExtractor.Updated += ManifestExtractorUpdated;

            PackageManifest manifest;
            FileInfo fileInfo;

            try
            {
                manifest = ManifestExtractor.ExtractManifest(fileName);
                fileInfo = new FileInfo(fileName);

                retVal.ReturnValue = new PackageArchive(fileInfo, manifest);

                retVal.AddInfo($"Found Package Archive '{manifest.Namespace + "." + manifest.Title}' in '{Path.GetFileName(fileName)}'.");
            }
            catch (Exception ex)
            {
                retVal.AddError(ex.Message);
                retVal.AddError($"Unable to find Package Archive in '{Path.GetFileName(fileName)}'.");
            }
            finally
            {
                ManifestExtractor.Updated -= ManifestExtractorUpdated;
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(guid);
            return retVal;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        ///     Event handler for <see cref="ManifestExtractor"/> updates.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void ManifestExtractorUpdated(object sender, PackagingUpdateEventArgs e)
        {
            logger.Debug("    ManifestExtractor: " + e.Message);
        }

        #endregion Private Methods
    }
}