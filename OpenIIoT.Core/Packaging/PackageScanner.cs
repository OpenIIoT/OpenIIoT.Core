/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄███████▄                                                                 ▄████████
      █     ███    ███                                                                ███    ███
      █     ███    ███   ▄█████   ▄██████    █  █▄     ▄█████     ▄████▄     ▄█████   ███    █▀   ▄██████   ▄█████  ██▄▄▄▄  ██▄▄▄▄     ▄█████    █████
      █     ███    ███   ██   ██ ██    ██   ██ ▄██▀    ██   ██   ██    ▀    ██   █    ███        ██    ██   ██   ██ ██▀▀▀█▄ ██▀▀▀█▄   ██   █    ██  ██
      █   ▀█████████▀    ██   ██ ██    ▀    ██▐█▀      ██   ██  ▄██        ▄██▄▄    ▀███████████ ██    ▀    ██   ██ ██   ██ ██   ██  ▄██▄▄     ▄██▄▄█▀
      █     ███        ▀████████ ██    ▄  ▀▀████     ▀████████ ▀▀██ ███▄  ▀▀██▀▀             ███ ██    ▄  ▀████████ ██   ██ ██   ██ ▀▀██▀▀    ▀███████
      █     ███          ██   ██ ██    ██   ██ ▀██▄    ██   ██   ██    ██   ██   █     ▄█    ███ ██    ██   ██   ██ ██   ██ ██   ██   ██   █    ██  ██
      █    ▄████▀        ██   █▀ ██████▀    ▀█   ▀█▀   ██   █▀   ██████▀    ███████  ▄████████▀  ██████▀    ██   █▀  █   █   █   █    ███████   ██  ██
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Scans a given directory for IPackage and IPackageArchive instances.
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
    using System.Diagnostics.CodeAnalysis;
    using NLog.xLogger;
    using OpenIIoT.SDK.Common.OperationResult;
    using OpenIIoT.SDK.Packaging;
    using OpenIIoT.SDK.Platform;

    /// <summary>
    ///     Scans a given directory for <see cref="IPackage"/> and <see cref="IPackageArchive"/> instances.
    /// </summary>
    public class PackageScanner : IPackageScanner
    {
        #region Private Fields

        /// <summary>
        ///     The Logger for this class.
        /// </summary>
        private static xLogger logger = xLogManager.GetCurrentClassxLogger();

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PackageScanner"/> class with the specified <paramref name="platformManager"/>.
        /// </summary>
        /// <param name="platformManager">The <see cref="IPlatformManager"/> instance for the application.</param>
        [ExcludeFromCodeCoverage]
        public PackageScanner(IPlatformManager platformManager)
            : this(platformManager, new PackageFactory(platformManager))
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PackageScanner"/> class with the specified
        ///     <paramref name="platformManager"/> and <paramref name="packageFactory"/>.
        /// </summary>
        /// <param name="platformManager">The <see cref="IPlatformManager"/> instance for the application.</param>
        /// <param name="packageFactory">
        ///     The <see cref="IPackageFactory"/> used to create <see cref="IPackage"/> and <see cref="IPackageArchive"/> instances
        ///     from files and directories found by the scanner.
        /// </param>
        public PackageScanner(IPlatformManager platformManager, IPackageFactory packageFactory)
        {
            PlatformManager = platformManager;
            PackageFactory = packageFactory;
        }

        #endregion Public Constructors

        #region Private Properties

        /// <summary>
        ///     Gets the current <see cref="IPlatform"/> instance.
        /// </summary>
        private IPlatform Platform => PlatformManager.Platform;

        /// <summary>
        ///     Gets or sets the <see cref="IPackageFactory"/> used to create <see cref="IPackage"/> and
        ///     <see cref="IPackageArchive"/> instances from files and directories found by the scanner.
        /// </summary>
        private IPackageFactory PackageFactory { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="IPlatformManager"/> with which Platform operations are carried out.
        /// </summary>
        private IPlatformManager PlatformManager { get; set; }

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        ///     Scans the directory specified in <see cref="Platform.Directories.PackageArchives"/> for
        ///     <see cref="IPackageArchive"/> s.
        /// </summary>
        /// <returns>
        ///     A Result containing the result of the operation and a <see cref="List{T}"/> of found <see cref="IPackageArchive"/> s.
        /// </returns>
        public IResult<IList<IPackageArchive>> ScanPackageArchives()
        {
            Guid guid = logger.EnterMethod(true);
            logger.Info("Scanning for Package Archives...");

            IResult<IList<IPackageArchive>> retVal = new Result<IList<IPackageArchive>>();
            retVal.ReturnValue = new List<IPackageArchive>();

            string searchDirectory = PlatformManager.Directories.PackageArchives;

            logger.Debug($"Scanning directory '{searchDirectory}'...");

            IResult<IList<string>> fileListResult = Platform.ListFiles(searchDirectory);
            retVal.Incorporate(fileListResult);

            if (retVal.ResultCode != ResultCode.Failure)
            {
                foreach (string file in fileListResult.ReturnValue)
                {
                    IResult<IPackageArchive> readResult = PackageFactory.GetPackageArchive(file);

                    if (readResult.ResultCode != ResultCode.Failure)
                    {
                        retVal.Incorporate(readResult);
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
        ///     Scans the directory specified in <see cref="Platform.Directories.Packages"/> for <see cref="IPackage"/> s.
        /// </summary>
        /// <returns>
        ///     A Result containing the result of the operation and a <see cref="List{T}"/> of found <see cref="IPackage"/> s.
        /// </returns>
        public IResult<IList<IPackage>> ScanPackages()
        {
            Guid guid = logger.EnterMethod(true);
            logger.Info("Scanning for Packages...");

            IResult<IList<IPackage>> retVal = new Result<IList<IPackage>>();
            retVal.ReturnValue = new List<IPackage>();

            string searchDirectory = PlatformManager.Directories.Packages;

            logger.Debug($"Scanning directory '{searchDirectory}'...");

            IResult<IList<string>> dirListResult = Platform.ListDirectories(searchDirectory, "*.*");
            retVal.Incorporate(dirListResult);

            if (retVal.ResultCode != ResultCode.Failure)
            {
                foreach (string directory in dirListResult.ReturnValue)
                {
                    if (directory == PlatformManager.Directories.PackageArchives)
                    {
                        continue;
                    }

                    IResult<IPackage> readResult = PackageFactory.GetPackage(directory);

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

        #endregion Public Methods
    }
}