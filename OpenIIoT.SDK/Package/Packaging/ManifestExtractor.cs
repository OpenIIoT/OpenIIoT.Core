/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄▄▄▄███▄▄▄▄                                                                   ▄████████
      █    ▄██▀▀▀███▀▀▀██▄                                                                ███    ███
      █    ███   ███   ███   ▄█████  ██▄▄▄▄   █     ▄█████    ▄█████   ▄█████     ██      ███    █▀  ▀███  ▐██▀     ██       █████   ▄█████   ▄██████     ██     ██████     █████
      █    ███   ███   ███   ██   ██ ██▀▀▀█▄ ██    ██   ▀█   ██   █    ██  ▀  ▀███████▄  ▄███▄▄▄       ██  ██   ▀███████▄   ██  ██   ██   ██ ██    ██ ▀███████▄ ██    ██   ██  ██
      █    ███   ███   ███   ██   ██ ██   ██ ██▌  ▄██▄▄     ▄██▄▄      ██         ██  ▀ ▀▀███▀▀▀        ████▀       ██  ▀  ▄██▄▄█▀   ██   ██ ██    ▀      ██  ▀ ██    ██  ▄██▄▄█▀
      █    ███   ███   ███ ▀████████ ██   ██ ██  ▀▀██▀▀    ▀▀██▀▀    ▀███████     ██      ███    █▄     ████        ██    ▀███████ ▀████████ ██    ▄      ██    ██    ██ ▀███████
      █    ███   ███   ███   ██   ██ ██   ██ ██    ██        ██   █     ▄  ██     ██      ███    ███  ▄██ ▀██       ██      ██  ██   ██   ██ ██    ██     ██    ██    ██   ██  ██
      █     ▀█   ███   █▀    ██   █▀  █   █  █     ██        ███████  ▄████▀     ▄██▀     ██████████ ███    ██▄    ▄██▀     ██  ██   ██   █▀ ██████▀     ▄██▀    ██████    ██  ██
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Extracts PackageManifest objects from Packages.
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
using System.IO.Compression;
using System.Linq;
using Newtonsoft.Json;
using OpenIIoT.SDK.Common;
using OpenIIoT.SDK.Package.Manifest;

namespace OpenIIoT.SDK.Package.Packaging
{
    /// <summary>
    ///     Extracts <see cref="PackageManifest"/> objects from Packages.
    /// </summary>
    public static class ManifestExtractor
    {
        #region Public Events

        /// <summary>
        ///     Raised when a new status message is generated.
        /// </summary>
        public static event EventHandler<PackagingUpdateEventArgs> Updated;

        #endregion Public Events

        #region Public Methods

        /// <summary>
        ///     Extracts the <see cref="PackageManifest"/> object from the specified Package file.
        /// </summary>
        /// <param name="packageFile">The Package from which the manifest is to be extracted.</param>
        /// <param name="manifestFile">The filename of the file to which the manifest is to be saved.</param>
        /// <returns>The extracted manifest object.</returns>
        public static PackageManifest ExtractManifest(string packageFile, string manifestFile = "")
        {
            ValidatePackageFileArgument(packageFile);

            PackageManifest manifest = new PackageManifest();

            OnUpdated($"Extracting manifest '{Package.Constants.ManifestFilename}' from package '{packageFile}'...");

            try
            {
                OnUpdated($"Locating manifest inside of package...");

                ZipArchiveEntry zippedManifestFile = ZipFile.OpenRead(packageFile).Entries.Where(e => e.Name == Package.Constants.ManifestFilename).FirstOrDefault();
                string manifestString;

                if (zippedManifestFile != default(ZipArchiveEntry))
                {
                    OnUpdated(" √ Manifest located successfully.");

                    OnUpdated("Reading manifest from package...");
                    manifestString = new StreamReader(zippedManifestFile.Open()).ReadToEnd();
                    OnUpdated(" √ Manifest read successfully.");
                }
                else
                {
                    throw new FileNotFoundException($"The package '{Path.GetFileName(packageFile)}' does not contain a manifest.");
                }

                OnUpdated("Deserializing manifest...");
                manifest = JsonConvert.DeserializeObject<PackageManifest>(manifestString);
                OnUpdated(" √ Manifest deserialized successfully.");
            }
            catch (JsonException ex)
            {
                throw new InvalidDataException($"The manifest within package '{Path.GetFileName(packageFile)}' is malformed: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new InvalidDataException($"Error extracting manifest from package '{Path.GetFileName(packageFile)}': {ex.Message}");
            }

            OnUpdated(" √ Manifest extracted.");

            if (manifestFile != default(string))
            {
                try
                {
                    OnUpdated($"Saving extracted manifest to file '{manifestFile}'...");
                    File.WriteAllText(manifestFile, manifest.ToJson());
                    OnUpdated(" √ File saved successfully.");
                }
                catch (Exception ex)
                {
                    OnUpdated($"Unable to write to manifest file '{manifestFile}': {ex.Message}");
                }
            }

            return manifest;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        ///     Raises the <see cref="Updated"/> event with the specified message.
        /// </summary>
        /// <param name="message">The message to send.</param>
        private static void OnUpdated(string message)
        {
            if (Updated != null)
            {
                Updated(null, new PackagingUpdateEventArgs(PackagingOperation.ManifestExtraction, message));
            }
        }

        /// <summary>
        ///     Validates the packageFile argument for <see cref="ExtractManifest(string, string)"/>.
        /// </summary>
        /// <param name="packageFile">The value specified for the packageFile argument.</param>
        /// <exception cref="ArgumentException">Thrown when the package is an empty or null string.</exception>
        /// <exception cref="FileNotFoundException">Thrown when the package can not be found on the local file system.</exception>
        /// <exception cref="InvalidDataException">Thrown when the package contains no files.</exception>
        /// <exception cref="IOException">Thrown when the package can not be read.</exception>
        private static void ValidatePackageFileArgument(string packageFile)
        {
            if (string.IsNullOrEmpty(packageFile))
            {
                throw new ArgumentException($"The required argument 'package' was not supplied.");
            }

            if (!File.Exists(packageFile))
            {
                throw new FileNotFoundException($"The specified package file '{packageFile}' could not be found.");
            }

            if (new FileInfo(packageFile).Length == 0)
            {
                throw new InvalidDataException($"The specified package file '{packageFile}' is empty.");
            }

            if (!File.OpenRead(packageFile).CanRead)
            {
                throw new IOException($"The specified package file '{packageFile}' could not be opened for reading.  It may be open in another process, or you may have insufficient rights.");
            }
        }

        #endregion Private Methods
    }
}