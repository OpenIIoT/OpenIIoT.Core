/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄███████▄                                                              ▄████████
      █     ███    ███                                                              ███    ███
      █     ███    ███   ▄█████   ▄██████    █  █▄     ▄█████     ▄████▄     ▄█████ ███    █▀     █████    ▄█████   ▄█████      ██     ██████     █████
      █     ███    ███   ██   ██ ██    ██   ██ ▄██▀    ██   ██   ██    ▀    ██   █  ███          ██  ██   ██   █    ██   ██ ▀███████▄ ██    ██   ██  ██
      █   ▀█████████▀    ██   ██ ██    ▀    ██▐█▀      ██   ██  ▄██        ▄██▄▄    ███         ▄██▄▄█▀  ▄██▄▄      ██   ██     ██  ▀ ██    ██  ▄██▄▄█▀
      █     ███        ▀████████ ██    ▄  ▀▀████     ▀████████ ▀▀██ ███▄  ▀▀██▀▀    ███    █▄  ▀███████ ▀▀██▀▀    ▀████████     ██    ██    ██ ▀███████
      █     ███          ██   ██ ██    ██   ██ ▀██▄    ██   ██   ██    ██   ██   █  ███    ███   ██  ██   ██   █    ██   ██     ██    ██    ██   ██  ██
      █    ▄████▀        ██   █▀ ██████▀    ▀█   ▀█▀   ██   █▀   ██████▀    ███████ ████████▀    ██  ██   ███████   ██   █▀    ▄██▀    ██████    ██  ██
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Creates Package files.
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
using OpenIIoT.SDK.Platform;
using Utility.OperationResult;

namespace OpenIIoT.Core.Package
{
    /// <summary>
    ///     Creates <see cref="Package"/> files.
    /// </summary>
    public class PackageCreator
    {
        #region Private Fields

        /// <summary>
        ///     The Logger for this class.
        /// </summary>
        private static xLogger logger = (xLogger)LogManager.GetCurrentClassLogger(typeof(xLogger));

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PackageCreator"/> class.
        /// </summary>
        /// <param name="platform">The IPlatform instance with which to carry out the creation.</param>
        public PackageCreator(IPlatform platform)
        {
            Platform = platform;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        ///     Gets or sets the IPlatform instance with which to carry out the creation.
        /// </summary>
        private IPlatform Platform { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///     Creates a Package file from the specified binary data.
        /// </summary>
        /// <param name="data">The binary data containing the Package.</param>
        /// <returns>A Result containing the result of the operation and the created Package.</returns>
        public IResult<IPackage> CreatePackage(byte[] data)
        {
            logger.EnterMethod();
            IResult<IPackage> retVal = new Result<IPackage>();

            string tempFile = Path.Combine(Platform.Directories.Temp, Guid.NewGuid().ToString());

            logger.Debug($"Saving new Package to '{tempFile}'...");

            retVal.Incorporate(Platform.WriteFileBytes(tempFile, data));

            if (retVal.ResultCode != ResultCode.Failure)
            {
                PackageReader reader = new PackageReader();
                IResult<IPackage> readResult = reader.Read(tempFile);

                retVal.Incorporate(readResult);

                if (retVal.ResultCode != ResultCode.Failure)
                {
                    string destinationFilename = GetPackageFilename(readResult.ReturnValue);

                    retVal.Incorporate(Platform.CopyFile(tempFile, destinationFilename, true));
                    retVal.ReturnValue = readResult.ReturnValue;
                    retVal.ReturnValue.Filename = destinationFilename;
                }
            }

            retVal.LogResult(logger);
            logger.ExitMethod();
            return retVal;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        ///     Creates and returns a valid filename for the specified <see cref="IPackage"/>.
        /// </summary>
        /// <param name="package">The Package for which the filename is to be created.</param>
        /// <returns>The created filename.</returns>
        private string GetPackageFilename(IPackage package)
        {
            string filename = package.FQN + "." + package.Version + PackageConstants.PackageFilenameExtension;

            foreach (char c in Path.GetInvalidFileNameChars())
            {
                filename = filename.Replace(c, PackageConstants.PackageFilenameInvalidCharacterSubstitution);
            }

            return Path.Combine(Platform.Directories.Packages, filename);
        }

        #endregion Private Methods
    }
}