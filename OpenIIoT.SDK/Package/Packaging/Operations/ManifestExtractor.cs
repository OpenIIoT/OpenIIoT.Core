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

namespace OpenIIoT.SDK.Package.Packaging.Operations
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
            ArgumentValidator.ValidatePackageFileArgumentForReading(packageFile);

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

        #endregion Private Methods
    }
}