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
using OpenIIoT.SDK.Packaging.Manifest;
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
        /// <param name="privateKey">The ASCII armored PGP private key.</param>
        /// <param name="passphrase">The passphrase for the specified PGP private key.</param>
        public void TrustPackage(string packageFile, string privateKey, string passphrase)
        {
            ArgumentValidator.ValidatePackageFileArgumentForWriting(packageFile, true);
            ArgumentValidator.ValidatePrivateKeyArguments(privateKey, passphrase);

            Info($"Adding Trust to Package '{Path.GetFileName(packageFile)}'...");

            Exception deferredException = default(Exception);

            string tempDirectory = Path.Combine(Path.GetTempPath(), GetType().Namespace.Split('.')[0], Guid.NewGuid().ToString());

            try
            {
                PackageManifest manifest = new ManifestExtractor().ExtractManifest(packageFile);

                Verbose("Checking (but not validating) Digest...");

                if (manifest.Signature == default(PackageManifestSignature) || string.IsNullOrEmpty(manifest.Signature.Digest))
                {
                    throw new InvalidOperationException("The Package is not signed and can not be trusted.");
                }

                Verbose("Digest OK.");

                Verbose("Signing Digest to create the Trust...");
                byte[] digestBytes = Encoding.ASCII.GetBytes(manifest.Signature.Digest);
                byte[] trustBytes = PGPSignature.Sign(digestBytes, privateKey, passphrase);
                string trust = Encoding.ASCII.GetString(trustBytes);
                Verbose("Trust created successfully.");

                manifest.Signature.Trust = trust;

                UpdatePackageManifest(packageFile, manifest, tempDirectory);
            }
            catch (Exception ex)
            {
                deferredException = ex;
            }
            finally
            {
                Verbose("Deleting temporary files...");

                if (Directory.Exists(tempDirectory))
                {
                    Directory.Delete(tempDirectory, true);
                }

                Verbose("Temporary files deleted successfully.");

                if (deferredException != default(Exception))
                {
                    throw deferredException;
                }
            }

            Success($"Trust added to Package '{Path.GetFileName(packageFile)}' successfully.");
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        ///     Updates the specified Package, replacing the existing Manifest with the specified Manifest.
        /// </summary>
        /// <param name="packageFile">The filename of the Package file to update.</param>
        /// <param name="manifest">The Manifest with which the Package file will be updated.</param>
        /// <param name="tempDirectory">The path to the temporary directory to use for file operations.</param>
        private void UpdatePackageManifest(string packageFile, PackageManifest manifest, string tempDirectory)
        {
            Verbose($"Updating Manifest in Package '{Path.GetFileName(packageFile)}'...");

            string tempPackageDirectory = Path.Combine(tempDirectory, "package");
            string tempManifest = Path.Combine(tempPackageDirectory, PackagingConstants.ManifestFilename);
            string tempPackage = Path.Combine(tempDirectory, Path.GetFileName(packageFile));

            Verbose($"Extracting Package to '{tempPackageDirectory}'...");
            ZipFile.ExtractToDirectory(packageFile, tempPackageDirectory);
            Verbose("Package extracted successfully.");

            Verbose($"Replacing Manifest file...");
            File.Delete(tempManifest);
            File.WriteAllText(tempManifest, manifest.ToJson());
            Verbose("Manifest file replaced successfully.");

            Verbose($"Compressing Package...");
            ZipFile.CreateFromDirectory(tempPackageDirectory, tempPackage);
            Verbose("Package compressed successfully.");

            Verbose($"Overwriting original Package...");
            File.Copy(tempPackage, packageFile, true);
            Verbose("Package overwritten successfully.");
        }

        #endregion Private Methods
    }
}