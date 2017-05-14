/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄███████▄                                                              ▄████████
      █     ███    ███                                                              ███    ███
      █     ███    ███   ▄█████   ▄██████    █  █▄     ▄█████     ▄████▄     ▄█████ ███    █▀     █████    ▄█████   ▄█████      ██     ██████     █████
      █     ███    ███   ██   ██ ██    ██   ██ ▄██▀    ██   ██   ██    ▀    ██   █  ███          ██  ██   ██   █    ██   ██ ▀███████▄ ██    ██   ██  ██
      █   ▀█████████▀    ██   ██ ██    ▀    ██▐█▀      ██   ██  ▄██        ▄██▄▄    ███         ▄██▄▄█▀  ▄██▄▄      ██   ██     ██  ▀ ██    ██  ▄██▄▄█▀
      █     ███        ▀████████ ██    ▄  ▀▀████     ▀████████ ▀▀██ ███▄  ▀▀██▀▀    ███    █▄  ▀███████ ▀▀██▀▀    ▀████████     ██    ██    ██ ▀███████
      █     ███          ██   ██ ██    ██   ██ ▀██▄    ██   ██   ██    ██   ██   █  ███    ███   ██  ██   ██   █    ██   ██     ██    ██    ██   ██  ██
      █    ▄████▀        ██   █▀ ██████▀    ▀█   ▀█▀   ██   █▀   ██████▀    ███████ ████████▀    ██  ██   ███████   ██   █▀    ▄██▀    ██████    ██  ██
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

using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using Newtonsoft.Json;
using OpenIIoT.SDK.Common;
using OpenIIoT.SDK.Package.Manifest;
using Utility.PGPSignatureTools;

namespace OpenIIoT.SDK.Package.Packaging.Operations
{
    /// <summary>
    ///     Creates Package files.
    /// </summary>
    public static class PackageCreator
    {
        #region Public Events

        /// <summary>
        ///     Raised when a new status message is generated.
        /// </summary>
        public static event EventHandler<PackagingUpdateEventArgs> Updated;

        #endregion Public Events

        #region Public Methods

        /// <summary>
        ///     Creates a Package file with the specified filename from the specified input directory using the specified manifest.
        /// </summary>
        /// <param name="inputDirectory">The directory containing the Package contents.</param>
        /// <param name="manifestFile">The PackageManifest file for the Package.</param>
        /// <param name="packageFile">The filename to which the Package file will be saved.</param>
        public static void CreatePackage(string inputDirectory, string manifestFile, string packageFile)
        {
            CreatePackage(inputDirectory, manifestFile, packageFile, false, string.Empty, string.Empty, string.Empty);
        }

        /// <summary>
        ///     Creates a Package file with the specified filename from the specified input directory using the specified manifest,
        ///     then signs the package using the information provided in the privateKeyFile, passphrase and keybaseUsername parameters.
        /// </summary>
        /// <param name="inputDirectory">The directory containing the Package contents.</param>
        /// <param name="manifestFile">The PackageManifest file for the Package.</param>
        /// <param name="packageFile">The filename to which the Package file will be saved.</param>
        /// <param name="signPackage">Indicates whether the package should be signed.</param>
        /// <param name="privateKeyFile">The file containing the ASCII-armored PGP private key.</param>
        /// <param name="passphrase">The passphrase for the private key.</param>
        /// <param name="keybaseUsername">
        ///     The Keybase.io username of the account hosting the PGP public key used for digest verification.
        /// </param>
        public static void CreatePackage(string inputDirectory, string manifestFile, string packageFile, bool signPackage, string privateKeyFile, string passphrase, string keybaseUsername)
        {
            ArgumentValidator.ValidateInputDirectoryArgument(inputDirectory);
            ArgumentValidator.ValidatePackageFileArgumentForWriting(packageFile);

            if (signPackage)
            {
                ArgumentValidator.ValidatePrivateKeyArguments(privateKeyFile, passphrase);

                if (string.IsNullOrEmpty(keybaseUsername))
                {
                    throw new ArgumentException($"The required argument 'keybase username' was not supplied.");
                }
            }

            PackageManifest manifest = ValidateManifestFileArgumentAndRetrieveManifest(manifestFile);

            OnUpdated($"Creating package '{Path.GetFileName(packageFile)}' from directory '{inputDirectory}' using manifest file '{Path.GetFileName(manifestFile)}'...");

            if (signPackage)
            {
                OnUpdated($"Package will be signed using PGP private key file '{Path.GetFileName(privateKeyFile)}' as keybase.io user '{keybaseUsername}'.");
            }

            // looks like: temp\OpenIIoT.SDK\<Guid>\
            string tempDirectory = Path.Combine(Path.GetTempPath(), System.Reflection.Assembly.GetEntryAssembly().GetName().Name, Guid.NewGuid().ToString());
            string payloadDirectory = Path.Combine(tempDirectory, Package.Constants.PayloadDirectoryName);
            string payloadArchiveName = Path.Combine(tempDirectory, Package.Constants.PayloadArchiveName);
            string tempPackageFileName = Path.Combine(tempDirectory, Path.GetFileName(packageFile));

            try
            {
                OnUpdated($"Creating temporary directory '{tempDirectory}'...");
                Directory.CreateDirectory(tempDirectory);
                OnUpdated(" √ Directory created.");

                OnUpdated($"Copying input directory '{inputDirectory}' to '{payloadDirectory}'...");
                Microsoft.VisualBasic.FileIO.FileSystem.CopyDirectory(inputDirectory, payloadDirectory);
                OnUpdated(" √ Directory copied successfully.");

                OnUpdated($"Validating manifest '{manifestFile}' and generating SHA512 hashes...");
                ValidateManifestAndGenerateHashes(manifest, payloadDirectory);
                OnUpdated(" √ Manifest validated and hashes written.");

                OnUpdated($"Compressing payload into '{payloadArchiveName}'...");
                ZipFile.CreateFromDirectory(payloadDirectory, payloadArchiveName);
                OnUpdated(" √ Successfully compressed payload.");

                OnUpdated($"Deleting temporary payload directory '{payloadDirectory}...");
                Directory.Delete(payloadDirectory, true);
                OnUpdated(" √ Successfully deleted temporary payload directory.");

                OnUpdated("Updating manifest with SHA512 hash of payload archive...");
                manifest.Checksum = Common.Utility.ComputeFileSHA512Hash(payloadArchiveName);
                OnUpdated($" √ Hash computed successfully: {manifest.Checksum}.");

                if (signPackage)
                {
                    try
                    {
                        manifest = SignManifest(manifest, privateKeyFile, passphrase, keybaseUsername);
                    }
                    catch (Exception ex)
                    {
                        OnUpdated($"Error signing Package: {ex.GetType().Name}: {ex.Message}");
                        throw;
                    }
                }

                OnUpdated($"Writing manifest to 'manifest.json' in '{tempDirectory}'...");
                WriteManifest(manifest, tempDirectory);
                OnUpdated(" √ Manifest written successfully.");

                OnUpdated($"Packaging manifest and payload into '{packageFile}'...");
                ZipFile.CreateFromDirectory(tempDirectory, packageFile);
                OnUpdated(" √ Package created successfully!");
            }
            catch (Exception ex)
            {
                OnUpdated($"Error creating Package: {ex.Message}");
            }
            finally
            {
                OnUpdated("Deleting temporary files...");
                Directory.Delete(tempDirectory, true);
                OnUpdated(" √ Temporary files deleted successfully.");
            }
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        ///     Compares the specified manifest to the contents of the specified directory and hashes any files that had been
        ///     deferred for hashing in the manifest.
        /// </summary>
        /// <param name="manifest">The manifest for which validation and hash generation is to be performed.</param>
        /// <param name="directory">The directory containing payload files.</param>
        internal static void ValidateManifestAndGenerateHashes(PackageManifest manifest, string directory)
        {
            foreach (PackageManifestFileType type in manifest.Files.Keys)
            {
                foreach (PackageManifestFile file in manifest.Files[type])
                {
                    // determine the absolute path for the file we need to examine
                    string fileToCheck = Path.Combine(directory, file.Source);

                    if (!File.Exists(fileToCheck))
                    {
                        throw new FileNotFoundException($"The file '{file.Source}' is listed in the manifest but is not found on disk.");
                    }

                    if (file.Checksum != default(string))
                    {
                        file.Checksum = Common.Utility.ComputeFileSHA512Hash(fileToCheck);
                    }
                }
            }
        }

        /// <summary>
        ///     Validates the manifestFile argument for
        ///     <see cref="CreatePackage(string, string, string, bool, string, string, string)"/> and, if valid, retrieves the
        ///     <see cref="PackageManifest"/> from the file and returns it.
        /// </summary>
        /// <param name="manifestFile">The value specified for the manifestFile argument.</param>
        /// <returns>The PackageManifest file retrieved from the file specified in the manifestFile argument.</returns>
        /// <exception cref="ArgumentException">Thrown when the manifest file is a default or null string.</exception>
        /// <exception cref="FileNotFoundException">
        ///     Thrown when the manifest file can not be found on the local file system.
        /// </exception>
        /// <exception cref="InvalidDataException">Thrown when the manifest file is empty.</exception>
        /// <exception cref="FileLoadException">Thrown when the manifest file fails to be loaded or deserialized.</exception>
        internal static PackageManifest ValidateManifestFileArgumentAndRetrieveManifest(string manifestFile)
        {
            if (manifestFile == default(string) || manifestFile == string.Empty)
            {
                throw new ArgumentException("The required argument 'manifest' was not supplied.");
            }

            if (!File.Exists(manifestFile))
            {
                throw new FileNotFoundException($"The specified manifest file '{manifestFile}' could not be found.");
            }

            string manifestContents = File.ReadAllText(manifestFile);

            if (manifestContents.Length == 0)
            {
                throw new InvalidDataException($"The specified manifest file '{manifestFile}' is empty.");
            }

            // fetch and deserialize the PackageManifest from the specified file
            PackageManifest manifest;

            try
            {
                manifest = JsonConvert.DeserializeObject<PackageManifest>(manifestContents);
            }
            catch (Exception ex)
            {
                throw new FileLoadException($"The specified manifest file '{manifestFile}' could not be opened: {ex.Message}");
            }

            return manifest;
        }

        /// <summary>
        ///     Raises the <see cref="Updated"/> event with the specified message.
        /// </summary>
        /// <param name="message">The message to send.</param>
        private static void OnUpdated(string message)
        {
            if (Updated != null)
            {
                Updated(null, new PackagingUpdateEventArgs(PackagingOperation.Package, message));
            }
        }

        /// <summary>
        ///     Digitally signs the specified manifest, adds the signature to the manifest, and returns it.
        /// </summary>
        /// <param name="manifest">The manifest to sign.</param>
        /// <param name="privateKeyFile">The file containing the PGP private key with which to sign the file.</param>
        /// <param name="passphrase">The passphrase for the PGP private key.</param>
        /// <param name="keybaseUsername">
        ///     The Keybase.io username of the account hosting the PGP public key used for digest verification.
        /// </param>
        /// <returns>The signed manifest.</returns>
        private static PackageManifest SignManifest(PackageManifest manifest, string privateKeyFile, string passphrase, string keybaseUsername)
        {
            OnUpdated("Digitally signing manifest...");

            // insert a signature into the manifest. the signer must be included in the hash to prevent tampering.
            PackageManifestSignature signature = new PackageManifestSignature();
            signature.Issuer = Constants.KeyIssuer;
            signature.Subject = keybaseUsername;
            manifest.Signature = signature;

            OnUpdated("Creating SHA512 hash of serialized manifest...");
            string manifestHash = Common.Utility.ComputeSHA512Hash(manifest.ToJson());
            OnUpdated($" √ Hash computed successfully: {manifestHash}.");

            OnUpdated("Reading keys from disk...");
            string privateKey = File.ReadAllText(privateKeyFile);
            OnUpdated(" √ Keys read successfully.");

            byte[] manifestBytes = Encoding.ASCII.GetBytes(manifest.ToJson());
            OnUpdated("Creating digest...");
            byte[] digestBytes = PGPSignature.Sign(manifestBytes, privateKey, passphrase);
            OnUpdated(" √ Digest created successfully.");

            OnUpdated("Adding signature to manifest...");
            manifest.Signature.Digest = Encoding.ASCII.GetString(digestBytes);
            OnUpdated(" √ Manifest signed successfully.");

            return manifest;
        }

        /// <summary>
        ///     Serializes the specified manifest to JSON and writes it to a 'manifest.json' file in the specified directory.
        /// </summary>
        /// <param name="manifest">The manifest to serialize and write.</param>
        /// <param name="directory">The directory into which the generated file will be written.</param>
        private static void WriteManifest(PackageManifest manifest, string directory)
        {
            string destinationFile = Path.Combine(directory, Package.Constants.ManifestFilename);
            string contents = manifest.ToJson();

            File.WriteAllText(destinationFile, contents);
        }

        #endregion Private Methods
    }
}