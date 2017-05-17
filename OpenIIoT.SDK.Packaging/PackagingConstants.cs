/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄███████▄                                                                           ▄████████
      █     ███    ███                                                                           ███    ███
      █     ███    ███   ▄█████   ▄██████    █  █▄     ▄█████     ▄████▄   █  ██▄▄▄▄     ▄████▄  ███    █▀   ██████  ██▄▄▄▄    ▄█████     ██      ▄█████  ██▄▄▄▄      ██      ▄█████
      █     ███    ███   ██   ██ ██    ██   ██ ▄██▀    ██   ██   ██    ▀  ██  ██▀▀▀█▄   ██    ▀  ███        ██    ██ ██▀▀▀█▄   ██  ▀  ▀███████▄   ██   ██ ██▀▀▀█▄ ▀███████▄   ██  ▀
      █   ▀█████████▀    ██   ██ ██    ▀    ██▐█▀      ██   ██  ▄██       ██▌ ██   ██  ▄██       ███        ██    ██ ██   ██   ██         ██  ▀   ██   ██ ██   ██     ██  ▀   ██
      █     ███        ▀████████ ██    ▄  ▀▀████     ▀████████ ▀▀██ ███▄  ██  ██   ██ ▀▀██ ███▄  ███    █▄  ██    ██ ██   ██ ▀███████     ██    ▀████████ ██   ██     ██    ▀███████
      █     ███          ██   ██ ██    ██   ██ ▀██▄    ██   ██   ██    ██ ██  ██   ██   ██    ██ ███    ███ ██    ██ ██   ██    ▄  ██     ██      ██   ██ ██   ██     ██       ▄  ██
      █    ▄████▀        ██   █▀ ██████▀    ▀█   ▀█▀   ██   █▀   ██████▀  █    █   █    ██████▀  ████████▀   ██████   █   █   ▄████▀     ▄██▀     ██   █▀  █   █     ▄██▀    ▄████▀
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Constants for the Packager application.
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

namespace OpenIIoT.SDK.Packaging
{
    /// <summary>
    ///     Constants for the Packager application.
    /// </summary>
    public static class PackagingConstants
    {
        #region Public Fields

        /// <summary>
        ///     The issuer or originator of the PGP keys used to generate the Package digest.
        /// </summary>
        public const string KeyIssuer = "Keybase.io";

        /// <summary>
        ///     The minimum length for any valid PGP public key retrieved from the keybase.io API.
        /// </summary>
        /// <remarks>
        ///     This value is based on a few arbitrary examples rather than hard logic. Header information varies from key to key,
        ///     and the encryption scheme used to create the key may also vary.
        /// </remarks>
        public const int KeyMinimumLength = 4000;

        /// <summary>
        ///     The base url for retrieval of PGP public key information.
        /// </summary>
        public const string KeyUrlBase = "https://keybase.io/_/api/1.0/user/lookup.json?username=$";

        /// <summary>
        ///     The username placeholder token for <see cref="KeyUrlBase"/>.
        /// </summary>
        public const string KeyUrlPlaceholder = "$";

        /// <summary>
        ///     The standard name of Package manifest files.
        /// </summary>
        public const string ManifestFilename = "manifest.json";

        /// <summary>
        ///     The standard name of compressed Package payloads.
        /// </summary>
        public const string PayloadArchiveName = "files.zip";

        /// <summary>
        ///     The standard name of Package payload directories.
        /// </summary>
        public const string PayloadDirectoryName = "files";

        #endregion Public Fields
    }
}