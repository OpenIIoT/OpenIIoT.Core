/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █    ▄█     ▄███████▄                                                                 ▄████████
      █   ███    ███    ███                                                                ███    ███
      █   ███▌   ███    ███   ▄█████   ▄██████    █  █▄     ▄█████     ▄████▄     ▄█████   ███    █▀  ▀███  ▐██▀     ██       █████   ▄█████   ▄██████     ██     ██████     █████
      █   ███▌   ███    ███   ██   ██ ██    ██   ██ ▄██▀    ██   ██   ██    ▀    ██   █   ▄███▄▄▄       ██  ██   ▀███████▄   ██  ██   ██   ██ ██    ██ ▀███████▄ ██    ██   ██  ██
      █   ███▌ ▀█████████▀    ██   ██ ██    ▀    ██▐█▀      ██   ██  ▄██        ▄██▄▄    ▀▀███▀▀▀        ████▀       ██  ▀  ▄██▄▄█▀   ██   ██ ██    ▀      ██  ▀ ██    ██  ▄██▄▄█▀
      █   ███    ███        ▀████████ ██    ▄  ▀▀████     ▀████████ ▀▀██ ███▄  ▀▀██▀▀      ███    █▄     ████        ██    ▀███████ ▀████████ ██    ▄      ██    ██    ██ ▀███████
      █   ███    ███          ██   ██ ██    ██   ██ ▀██▄    ██   ██   ██    ██   ██   █    ███    ███  ▄██ ▀██       ██      ██  ██   ██   ██ ██    ██     ██    ██    ██   ██  ██
      █   █▀    ▄████▀        ██   █▀ ██████▀    ▀█   ▀█▀   ██   █▀   ██████▀    ███████   ██████████ ███    ██▄    ▄██▀     ██  ██   ██   █▀ ██████▀     ▄██▀    ██████    ██  ██
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Extracts Package files.
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

namespace OpenIIoT.SDK.Packaging.Operations
{
    /// <summary>
    ///     Extracts Package files.
    /// </summary>
    public interface IPackageExtractor : IPackagingOperation
    {
        #region Public Methods

        /// <summary>
        ///     Extracts the specified Package file to the specified output directory after first verifying the package.
        /// </summary>
        /// <param name="packageFile">The Package to be extracted.</param>
        /// <param name="outputDirectory">The directory into which the Package payload is to be extracted.</param>
        void ExtractPackage(string packageFile, string outputDirectory);

        /// <summary>
        ///     Extracts the specified Package file to the specified output directory after first verifying the package, unless the
        ///     skipVerification parameter is specified.
        /// </summary>
        /// <param name="packageFile">The Package to be extracted.</param>
        /// <param name="outputDirectory">The directory into which the Package payload is to be extracted.</param>
        /// <param name="overwrite">
        ///     An optional value indicating whether the output directory should be overwritten if it exists.
        /// </param>
        /// <param name="skipVerification">
        ///     An optional value indicating whether the verification prior to extraction is to be skipped.
        /// </param>
        void ExtractPackage(string packageFile, string outputDirectory, bool overwrite = false, bool skipVerification = false);

        /// <summary>
        ///     Extracts the specified Package file to the specified output directory after first verifying the package, unless the
        ///     skipVerification parameter is specified.
        /// </summary>
        /// <param name="packageFile">The Package to be extracted.</param>
        /// <param name="outputDirectory">The directory into which the Package payload is to be extracted.</param>
        /// <param name="publicKey">The optional PGP Public Key to use when verifying the Package.</param>
        /// <param name="overwrite">
        ///     An optional value indicating whether the output directory should be overwritten if it exists.
        /// </param>
        /// <param name="skipVerification">
        ///     An optional value indicating whether the verification prior to extraction is to be skipped.
        /// </param>
        void ExtractPackage(string packageFile, string outputDirectory, string publicKey = "", bool overwrite = false, bool skipVerification = false);

        #endregion Public Methods
    }
}