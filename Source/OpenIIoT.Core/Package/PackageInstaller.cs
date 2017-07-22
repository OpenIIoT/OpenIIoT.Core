/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄███████▄                                                               ▄█
      █     ███    ███                                                              ███
      █     ███    ███   ▄█████   ▄██████    █  █▄     ▄█████     ▄████▄     ▄█████ ███▌ ██▄▄▄▄    ▄█████     ██      ▄█████   █        █          ▄█████    █████
      █     ███    ███   ██   ██ ██    ██   ██ ▄██▀    ██   ██   ██    ▀    ██   █  ███▌ ██▀▀▀█▄   ██  ▀  ▀███████▄   ██   ██ ██       ██         ██   █    ██  ██
      █   ▀█████████▀    ██   ██ ██    ▀    ██▐█▀      ██   ██  ▄██        ▄██▄▄    ███▌ ██   ██   ██         ██  ▀   ██   ██ ██       ██        ▄██▄▄     ▄██▄▄█▀
      █     ███        ▀████████ ██    ▄  ▀▀████     ▀████████ ▀▀██ ███▄  ▀▀██▀▀    ███  ██   ██ ▀███████     ██    ▀████████ ██       ██       ▀▀██▀▀    ▀███████
      █     ███          ██   ██ ██    ██   ██ ▀██▄    ██   ██   ██    ██   ██   █  ███  ██   ██    ▄  ██     ██      ██   ██ ██▌    ▄ ██▌    ▄   ██   █    ██  ██
      █    ▄████▀        ██   █▀ ██████▀    ▀█   ▀█▀   ██   █▀   ██████▀    ███████ █▀    █   █   ▄████▀     ▄██▀     ██   █▀ ████▄▄██ ████▄▄██   ███████   ██  ██
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Installs Package files.
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
using System.IO;
using NLog;
using NLog.xLogger;
using OpenIIoT.SDK.Package;
using OpenIIoT.SDK.Packaging.Operations;
using OpenIIoT.SDK.Platform;
using Utility.OperationResult;

namespace OpenIIoT.Core.Package
{
    /// <summary>
    ///     Installs <see cref="Package"/> files.
    /// </summary>
    public class PackageInstaller
    {
        #region Private Fields

        /// <summary>
        ///     The Logger for this class.
        /// </summary>
        private static xLogger logger = (xLogger)LogManager.GetCurrentClassLogger(typeof(xLogger));

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PackageInstaller"/> class.
        /// </summary>
        /// <param name="platform">The IPlatform instance with which to carry out the installation.</param>
        public PackageInstaller(IPlatform platform)
        {
            Platform = platform;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        ///     Gets or sets the IPlatform instance with which to carry out the installation.
        /// </summary>
        private IPlatform Platform { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///     Installs the specified <see cref="IPackage"/> with the specified <see cref="PackageInstallOptions"/>.
        /// </summary>
        /// <param name="package">The Package to install.</param>
        /// <param name="options">The installation options with which the Package is to be installed.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public IResult InstallPackage(IPackage package, PackageInstallOptions options)
        {
            return InstallPackage(package, options, string.Empty);
        }

        /// <summary>
        ///     Installs the specified <see cref="IPackage"/> with the specified <see cref="PackageInstallOptions"/>.
        /// </summary>
        /// <param name="package">The Package to install.</param>
        /// <param name="options">The installation options with which the Package is to be installed.</param>
        /// <param name="publicKey">The PGP Public Key to use when verifying the Package prior to installation.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public IResult InstallPackage(IPackage package, PackageInstallOptions options, string publicKey)
        {
            logger.EnterMethod(xLogger.Params(package, options, publicKey));
            IResult retVal = new Result();

            logger.Debug($"Installing Package '{package.FQN}'...");

            PackageExtractor extractor = new PackageExtractor();
            extractor.Updated += (sender, e) => logger.Debug(e.Message);

            // determine the installation directory; should look like \path\to\Plugins\FQN\
            string destination = Platform.Directories.Plugins;
            destination = Path.Combine(destination, package.FQN);

            bool overwrite = options.HasFlag(PackageInstallOptions.Overwrite);
            bool skipVerification = options.HasFlag(PackageInstallOptions.SkipVerification);

            logger.Debug($"Install directory: '{destination}'; overwrite={overwrite}, skipVerification={skipVerification}");

            try
            {
                extractor.ExtractPackage(package.FileName, destination, overwrite, skipVerification);
            }
            catch (Exception ex)
            {
                logger.Exception(LogLevel.Debug, ex);
                retVal.AddError($"Error installing Package '{package.FQN}': {ex.Message}");
            }

            retVal.LogResult(logger);
            logger.ExitMethod();
            return retVal;
        }

        #endregion Public Methods
    }
}