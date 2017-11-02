/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █    ▄█     ▄███████▄                                                               ▄█    █▄
      █   ███    ███    ███                                                              ███    ███
      █   ███▌   ███    ███   ▄█████   ▄██████    █  █▄     ▄█████     ▄████▄     ▄█████ ███    ███    ▄█████    █████  █     ▄█████  █     ▄█████    █████
      █   ███▌   ███    ███   ██   ██ ██    ██   ██ ▄██▀    ██   ██   ██    ▀    ██   █  ███    ███   ██   █    ██  ██ ██    ██   ▀█ ██    ██   █    ██  ██
      █   ███▌ ▀█████████▀    ██   ██ ██    ▀    ██▐█▀      ██   ██  ▄██        ▄██▄▄    ███    ███  ▄██▄▄     ▄██▄▄█▀ ██▌  ▄██▄▄    ██▌  ▄██▄▄     ▄██▄▄█▀
      █   ███    ███        ▀████████ ██    ▄  ▀▀████     ▀████████ ▀▀██ ███▄  ▀▀██▀▀    ███    ███ ▀▀██▀▀    ▀███████ ██  ▀▀██▀▀    ██  ▀▀██▀▀    ▀███████
      █   ███    ███          ██   ██ ██    ██   ██ ▀██▄    ██   ██   ██    ██   ██   █   ██▄  ▄██    ██   █    ██  ██ ██    ██      ██    ██   █    ██  ██
      █   █▀    ▄████▀        ██   █▀ ██████▀    ▀█   ▀█▀   ██   █▀   ██████▀    ███████   ▀████▀     ███████   ██  ██ █     ██      █     ███████   ██  ██
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Verifies the Trust, Digest and payload checksum of Packages.
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
    using System.Net;

    /// <summary>
    ///     Verifies Packages.
    /// </summary>
    public interface IPackageVerifier : IPackagingOperation
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the PGP Public Key to use when verifying a Package Trust.
        /// </summary>
        /// <remarks>Defaults to the embedded PGP Public Key.</remarks>
        string TrustPGPPublicKey { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///     Fetches the PGP public key for the specified keybase.io username from the keybase.io API.
        /// </summary>
        /// <param name="username">The keybase.io username of the user for which the PGP public key is to be fetched..</param>
        /// <returns>The fetched PGP public key.</returns>
        /// <exception cref="WebException">Thrown when an error occurs fetching the key.</exception>
        string FetchPublicKeyForUser(string username);

        /// <summary>
        ///     Verifies the specified Package.
        /// </summary>
        /// <param name="packageFile">The Package to verify.</param>
        /// <param name="publicKey">The ASCII armored PGP private key.</param>
        /// <returns>A value indicating whether the specified Package was verified successfully.</returns>
        bool VerifyPackage(string packageFile, string publicKey = "");

        #endregion Public Methods
    }
}