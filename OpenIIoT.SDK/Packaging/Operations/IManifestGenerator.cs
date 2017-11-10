/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █    ▄█     ▄▄▄▄███▄▄▄▄                                                                   ▄██████▄
      █   ███   ▄██▀▀▀███▀▀▀██▄                                                                ███    ███
      █   ███▌  ███   ███   ███   ▄█████  ██▄▄▄▄   █     ▄█████    ▄█████   ▄█████     ██      ███    █▀     ▄█████ ██▄▄▄▄     ▄█████    █████   ▄█████      ██     ██████     █████
      █   ███▌  ███   ███   ███   ██   ██ ██▀▀▀█▄ ██    ██   ▀█   ██   █    ██  ▀  ▀███████▄  ▄███          ██   █  ██▀▀▀█▄   ██   █    ██  ██   ██   ██ ▀███████▄ ██    ██   ██  ██
      █   ███▌  ███   ███   ███   ██   ██ ██   ██ ██▌  ▄██▄▄     ▄██▄▄      ██         ██  ▀ ▀▀███ ████▄   ▄██▄▄    ██   ██  ▄██▄▄     ▄██▄▄█▀   ██   ██     ██  ▀ ██    ██  ▄██▄▄█▀
      █   ███   ███   ███   ███ ▀████████ ██   ██ ██  ▀▀██▀▀    ▀▀██▀▀    ▀███████     ██      ███    ███ ▀▀██▀▀    ██   ██ ▀▀██▀▀    ▀███████ ▀████████     ██    ██    ██ ▀███████
      █   ███   ███   ███   ███   ██   ██ ██   ██ ██    ██        ██   █     ▄  ██     ██      ███    ███   ██   █  ██   ██   ██   █    ██  ██   ██   ██     ██    ██    ██   ██  ██
      █   █▀     ▀█   ███   █▀    ██   █▀  █   █  █     ██        ███████  ▄████▀     ▄██▀     ████████▀    ███████  █   █    ███████   ██  ██   ██   █▀    ▄██▀    ██████    ██  ██
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Generates and populates PackageManifest objects.
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
    using OpenIIoT.SDK.Packaging.Manifest;

    /// <summary>
    ///     Generates and populates <see cref="IPackageManifest"/> objects.
    /// </summary>
    public interface IManifestGenerator : IPackagingOperation
    {
        #region Public Methods

        /// <summary>
        ///     Generates and populates <see cref="IPackageManifest"/> objects from the specified directory, including resource
        ///     files and hashing file entries if those options are specified.
        /// </summary>
        /// <param name="inputDirectory">The directory from which to generate a list of files.</param>
        /// <param name="hashFiles">A value indicating whether files added to the manifest are to include a SHA512 hash.</param>
        /// <param name="manifestFile">The filename of the file to which the manifest is to be saved.</param>
        /// <returns>The generated manifest.</returns>
        IPackageManifest GenerateManifest(string inputDirectory, bool hashFiles = false, string manifestFile = "");

        #endregion Public Methods
    }
}