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

            string tempFileName = Guid.NewGuid().ToString();

            logger.Info($"Saving new Package to '{tempFileName}'...");

            string tempFile = Path.Combine(Platform.Directories.Temp, tempFileName);

            retVal.Incorporate(Platform.WriteFileBytes(tempFile, data));

            if (retVal.ResultCode != ResultCode.Failure)
            {
                PackageReader reader = new PackageReader();
                IResult<IPackage> readResult = reader.Read(tempFile);

                retVal.Incorporate(readResult);

                if (retVal.ResultCode != ResultCode.Failure)
                {
                    string finalFileName = readResult.ReturnValue.FQN + "." + readResult.ReturnValue.Version + ".zip";
                    string destinationFile = Path.Combine(Platform.Directories.Packages, finalFileName);

                    retVal.Incorporate(Platform.CopyFile(tempFile, destinationFile, true));
                    retVal.ReturnValue = readResult.ReturnValue;
                }
                else
                {
                    retVal.AddError($"The specified data does not contain a valid Package.");
                }
            }

            retVal.LogResult(logger);
            logger.ExitMethod();
            return retVal;
        }

        #endregion Public Methods

        #region Private Methods

        private string GetPackageFileName(IPackage package)
        {
            string fileName = package.FQN + "." + package.Version + ".zip";
            return fileName;
        }

        #endregion Private Methods
    }
}