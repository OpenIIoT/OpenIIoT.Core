/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄███████▄                                                                  ███
      █     ███    ███                                                              ▀█████████▄
      █     ███    ███   ▄█████   ▄██████    █  █▄     ▄█████     ▄████▄     ▄█████    ▀███▀▀██    █████ ██   █    ▄█████     ██       ▄█████    █████
      █     ███    ███   ██   ██ ██    ██   ██ ▄██▀    ██   ██   ██    ▀    ██   █      ███   ▀   ██  ██ ██   ██   ██  ▀  ▀███████▄   ██   █    ██  ██
      █   ▀█████████▀    ██   ██ ██    ▀    ██▐█▀      ██   ██  ▄██        ▄██▄▄        ███      ▄██▄▄█▀ ██   ██   ██         ██  ▀  ▄██▄▄     ▄██▄▄█▀
      █     ███        ▀████████ ██    ▄  ▀▀████     ▀████████ ▀▀██ ███▄  ▀▀██▀▀        ███     ▀███████ ██   ██ ▀███████     ██    ▀▀██▀▀    ▀███████
      █     ███          ██   ██ ██    ██   ██ ▀██▄    ██   ██   ██    ██   ██   █      ███       ██  ██ ██   ██    ▄  ██     ██      ██   █    ██  ██
      █    ▄████▀        ██   █▀ ██████▀    ▀█   ▀█▀   ██   █▀   ██████▀    ███████    ▄████▀     ██  ██ ██████   ▄████▀     ▄██▀     ███████   ██  ██
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Adds a Trust to the PackageManifest of Packages.
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
using System.Text;
using OpenIIoT.SDK.Common;
using OpenIIoT.SDK.Package.Manifest;
using Utility.PGPSignatureTools;

namespace OpenIIoT.SDK.Package.Packaging.Operations
{
    /// <summary>
    ///     Adds a Trust to the <see cref="PackageManifest"/> of Packages.
    /// </summary>
    public static class PackageTruster
    {
        #region Public Events

        /// <summary>
        ///     Raised when a new status message is generated.
        /// </summary>
        public static event EventHandler<PackagingUpdateEventArgs> Updated;

        #endregion Public Events

        #region Public Methods

        /// <summary>
        ///     Adds a Trust to the <see cref="PackageManifest"/> within the specified package using the PGP private key in the
        ///     specified file and the specified passphrase.
        /// </summary>
        /// <param name="packageFile">The Package for which the Trust is to be added.</param>
        /// <param name="privateKeyFile">The filename of the file containing the ASCII armored PGP private key.</param>
        /// <param name="passphrase">The passphrase for the specified PGP private key.</param>
        public static void TrustPackage(string packageFile, string privateKeyFile, string passphrase)
        {
            ArgumentValidator.ValidatePackageFileArgumentForWriting(packageFile, true);
            ArgumentValidator.ValidatePrivateKeyArguments(privateKeyFile, passphrase);

            OnUpdated($"Adding Trust to Package '{Path.GetFileName(packageFile)}'...");

            PackageManifest manifest = ManifestExtractor.ExtractManifest(packageFile);

            OnUpdated("Checking Digest...");

            if (string.IsNullOrEmpty(manifest.Signature.Digest))
            {
                throw new InvalidOperationException("The Package is not signed and can not be trusted.");
            }

            OnUpdated(" √ Digest OK.");

            OnUpdated("Signing Digest to create the Trust...");
            string privateKey = File.ReadAllText(privateKeyFile);
            byte[] digestBytes = Encoding.ASCII.GetBytes(manifest.Signature.Digest);
            byte[] trustBytes = PGPSignature.Sign(digestBytes, privateKey, passphrase);
            string trust = Encoding.ASCII.GetString(trustBytes);
            OnUpdated(" √ Trust created successfully.");

            manifest.Signature.Trust = trust;

            UpdatePackageManifest(packageFile, manifest);
            OnUpdated($" √ Trust added to Package '{Path.GetFileName(packageFile)}' successfully.");
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
                Updated(null, new PackagingUpdateEventArgs(PackagingOperation.Trust, message));
            }
        }

        /// <summary>
        ///     Updates the specified Package, replacing the existing Manifest with the specified Manifest.
        /// </summary>
        /// <param name="packageFile">The filename of the Package file to update.</param>
        /// <param name="manifest">The Manifest with which the Package file will be updated.</param>
        private static void UpdatePackageManifest(string packageFile, PackageManifest manifest)
        {
            // looks like: temp\OpenIIoT.SDK\<Guid>\
            string tempDirectory = Path.Combine(Path.GetTempPath(), System.Reflection.Assembly.GetEntryAssembly().GetName().Name, Guid.NewGuid().ToString());
            string tempFile = Path.Combine(tempDirectory, Package.Constants.ManifestFilename);

            OnUpdated($"Updating Manifest in Package '{Path.GetFileName(packageFile)}'...");

            try
            {
                OnUpdated($"Writing Manifest to temp file '{tempFile}'...");
                Directory.CreateDirectory(tempDirectory);
                File.WriteAllText(tempFile, manifest.ToJson());
                OnUpdated(" √ Manifest file written successfully.");

                OnUpdated($"Opening Package file '{Path.GetFileName(packageFile)}'...");
                ZipArchive package = ZipFile.Open(packageFile, ZipArchiveMode.Update);
                OnUpdated(" √ Package file opened successfully.");

                OnUpdated("Deleting existing Manifest file...");
                package.GetEntry(Package.Constants.ManifestFilename).Delete();
                OnUpdated(" √ Deleted existing Manifest file successfully.");

                OnUpdated("Adding updated Manfiest file...");
                package.CreateEntryFromFile(tempFile, Package.Constants.ManifestFilename);
                OnUpdated(" √ Manifest updated successfully.");

                OnUpdated("Saving Package...");
                package.Dispose();
                OnUpdated(" √ Package saved successfully.");
            }
            catch (Exception ex)
            {
                OnUpdated($"Error updating Manifest in Package '{Path.GetFileName(packageFile)}: {ex.Message}'");
            }
            finally
            {
                OnUpdated("Deleting temporary files...");
                Directory.Delete(tempDirectory, true);
                OnUpdated(" √ Temporary files deleted successfully.");
            }
        }

        #endregion Private Methods
    }
}