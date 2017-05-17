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

namespace OpenIIoT.SDK.Packaging.Operations
{
    /// <summary>
    ///     Adds a Trust to the <see cref="PackageManifest"/> of Packages.
    /// </summary>
    public class PackageTruster : PackagingOperation
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PackageTruster"/> class.
        /// </summary>
        public PackageTruster()
            : base(PackagingOperationType.Trust)
        {
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///     Adds a Trust to the <see cref="PackageManifest"/> within the specified package using the PGP private key in the
        ///     specified file and the specified passphrase.
        /// </summary>
        /// <param name="packageFile">The Package for which the Trust is to be added.</param>
        /// <param name="privateKeyFile">The filename of the file containing the ASCII armored PGP private key.</param>
        /// <param name="passphrase">The passphrase for the specified PGP private key.</param>
        public void TrustPackage(string packageFile, string privateKeyFile, string passphrase)
        {
            ArgumentValidator.ValidatePackageFileArgumentForWriting(packageFile, true);
            ArgumentValidator.ValidatePrivateKeyArguments(privateKeyFile, passphrase);

            Info($"Adding Trust to Package '{Path.GetFileName(packageFile)}'...");

            PackageManifest manifest = new ManifestExtractor().ExtractManifest(packageFile);

            Verbose("Checking (but not validating) Digest...");

            if (string.IsNullOrEmpty(manifest.Signature.Digest))
            {
                throw new InvalidOperationException("The Package is not signed and can not be trusted.");
            }

            Verbose("Digest OK.");

            Verbose("Signing Digest to create the Trust...");
            string privateKey = File.ReadAllText(privateKeyFile);
            byte[] digestBytes = Encoding.ASCII.GetBytes(manifest.Signature.Digest);
            byte[] trustBytes = PGPSignature.Sign(digestBytes, privateKey, passphrase);
            string trust = Encoding.ASCII.GetString(trustBytes);
            Verbose("Trust created successfully.");

            manifest.Signature.Trust = trust;

            UpdatePackageManifest(packageFile, manifest);
            Success($"Trust added to Package '{Path.GetFileName(packageFile)}' successfully.");
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        ///     Updates the specified Package, replacing the existing Manifest with the specified Manifest.
        /// </summary>
        /// <param name="packageFile">The filename of the Package file to update.</param>
        /// <param name="manifest">The Manifest with which the Package file will be updated.</param>
        private void UpdatePackageManifest(string packageFile, PackageManifest manifest)
        {
            Verbose($"Updating Manifest in Package '{Path.GetFileName(packageFile)}'...");

            // looks like: temp\OpenIIoT.SDK\<Guid>\
            string tempDirectory = Path.Combine(Path.GetTempPath(), System.Reflection.Assembly.GetEntryAssembly().GetName().Name, Guid.NewGuid().ToString());
            string tempFile = Path.Combine(tempDirectory, PackagingConstants.ManifestFilename);

            Exception deferredException = default(Exception);

            try
            {
                Verbose($"Writing Manifest to temp file '{tempFile}'...");
                Directory.CreateDirectory(tempDirectory);
                File.WriteAllText(tempFile, manifest.ToJson());
                Verbose("Manifest file written successfully.");

                Verbose($"Opening Package file '{Path.GetFileName(packageFile)}'...");
                ZipArchive package = ZipFile.Open(packageFile, ZipArchiveMode.Update);
                Verbose("Package file opened successfully.");

                Verbose("Deleting existing Manifest file...");
                package.GetEntry(PackagingConstants.ManifestFilename).Delete();
                Verbose("Deleted existing Manifest file successfully.");

                Verbose("Adding updated Manfiest file...");
                package.CreateEntryFromFile(tempFile, PackagingConstants.ManifestFilename);
                Verbose("Manifest updated successfully.");

                Verbose("Saving Package...");
                package.Dispose();
                Verbose("Package saved successfully.");
            }
            catch (Exception ex)
            {
                deferredException = new Exception($"Error updating Manifest in Package '{Path.GetFileName(packageFile)}: {ex.Message}'");
            }
            finally
            {
                Verbose("Deleting temporary files...");
                Directory.Delete(tempDirectory, true);
                Verbose("Temporary files deleted successfully.");

                if (deferredException != default(Exception))
                {
                    throw deferredException;
                }
            }
        }

        #endregion Private Methods
    }
}