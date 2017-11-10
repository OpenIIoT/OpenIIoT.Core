/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █    ▄█     ▄███████▄                                                              ▄████████
      █   ███    ███    ███                                                              ███    ███
      █   ███▌   ███    ███   ▄█████   ▄██████    █  █▄     ▄█████     ▄████▄     ▄█████ ███    █▀     █████    ▄█████   ▄█████      ██     ██████     █████
      █   ███▌   ███    ███   ██   ██ ██    ██   ██ ▄██▀    ██   ██   ██    ▀    ██   █  ███          ██  ██   ██   █    ██   ██ ▀███████▄ ██    ██   ██  ██
      █   ███▌ ▀█████████▀    ██   ██ ██    ▀    ██▐█▀      ██   ██  ▄██        ▄██▄▄    ███         ▄██▄▄█▀  ▄██▄▄      ██   ██     ██  ▀ ██    ██  ▄██▄▄█▀
      █   ███    ███        ▀████████ ██    ▄  ▀▀████     ▀████████ ▀▀██ ███▄  ▀▀██▀▀    ███    █▄  ▀███████ ▀▀██▀▀    ▀████████     ██    ██    ██ ▀███████
      █   ███    ███          ██   ██ ██    ██   ██ ▀██▄    ██   ██   ██    ██   ██   █  ███    ███   ██  ██   ██   █    ██   ██     ██    ██    ██   ██  ██
      █   █▀    ▄████▀        ██   █▀ ██████▀    ▀█   ▀█▀   ██   █▀   ██████▀    ███████ ████████▀    ██  ██   ███████   ██   █▀    ▄██▀    ██████    ██  ██
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

namespace OpenIIoT.SDK.Packaging.Operations
{
    /// <summary>
    ///     Creates Package files.
    /// </summary>
    public interface IPackageCreator : IPackagingOperation
    {
        #region Public Methods

        /// <summary>
        ///     Creates a Package file with the specified filename from the specified input directory using the specified manifest.
        /// </summary>
        /// <param name="inputDirectory">The directory containing the Package contents.</param>
        /// <param name="manifestFile">The PackageManifest file for the Package.</param>
        /// <param name="packageFile">The filename to which the Package file will be saved.</param>
        /// <param name="overwrite">A value indicating whether the Package file will be overwritten if it exists.</param>
        void CreatePackage(string inputDirectory, string manifestFile, string packageFile, bool overwrite = false);

        /// <summary>
        ///     Creates a Package file with the specified filename from the specified input directory using the specified manifest,
        ///     then signs the package using the information provided in the privateKeyFile, passphrase and keybaseUsername parameters.
        /// </summary>
        /// <param name="inputDirectory">The directory containing the Package contents.</param>
        /// <param name="manifestFile">The PackageManifest file for the Package.</param>
        /// <param name="packageFile">The filename to which the Package file will be saved.</param>
        /// <param name="signPackage">Indicates whether the package should be signed.</param>
        /// <param name="privateKey">The ASCII-armored PGP private key.</param>
        /// <param name="passphrase">The passphrase for the private key.</param>
        /// <param name="keybaseUsername">
        ///     The Keybase.io username of the account hosting the PGP public key used for digest verification.
        /// </param>
        /// <param name="overwrite">A value indicating whether the Package file will be overwritten if it exists.</param>
        void CreatePackage(string inputDirectory, string manifestFile, string packageFile, bool signPackage, string privateKey, string passphrase, string keybaseUsername, bool overwrite = false);

        #endregion Public Methods
    }
}