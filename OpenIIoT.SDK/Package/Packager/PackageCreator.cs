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
using Newtonsoft.Json.Linq;
using System.Net;

namespace OpenIIoT.SDK.Package.Packager
{
    /// <summary>
    ///     Creates Package files.
    /// </summary>
    public static class PackageCreator
    {
        public static event EventHandler<PackagerUpdateEventArgs> Updated;

        #region Public Methods

        private static void OnUpdated(string message)
        {
            if (Updated != null)
            {
                Updated(null, new PackagerUpdateEventArgs(PackagerOperation.Package, message));
            }
        }

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
            ValidateInputDirectoryArgument(inputDirectory);
            ValidatePackageFileArgument(packageFile);
            ValidateSignatureArguments(signPackage, privateKeyFile, passphrase, keybaseUsername);

            PackageManifest manifest = ValidateManifestFileArgumentAndRetrieveManifest(manifestFile);

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
            signature.PublicKeyUrl = FetchPublicKeyForUser(keybaseUsername);
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

            File.WriteAllBytes(@"c:\pkg\digest.txt", digestBytes);

            OnUpdated("Adding signature to manifest...");
            manifest.Signature.Digest = Encoding.ASCII.GetString(digestBytes);
            OnUpdated(" √ Manifest signed successfully.");

            return manifest;
        }

        /// <summary>
        ///     Validates the inputDirectory argument for <see cref="CreatePackage(string, string, string, bool, string, string, string)"/>.
        /// </summary>
        /// <param name="inputDirectory">The value specified for the inputDirectory argument.</param>
        /// <exception cref="ArgumentException">Thrown when the directory is a default or null string.</exception>
        /// <exception cref="DirectoryNotFoundException">
        ///     Thrown when the directory can not be found on the local file system.
        /// </exception>
        /// <exception cref="FileNotFoundException">Thrown when the directory contains no files.</exception>
        private static void ValidateInputDirectoryArgument(string inputDirectory)
        {
            if (inputDirectory == default(string) || inputDirectory == string.Empty)
            {
                throw new ArgumentException($"The required argument 'directory' (-d) was not supplied.");
            }

            if (!Directory.Exists(inputDirectory))
            {
                throw new DirectoryNotFoundException($"The specified directory '{inputDirectory}' could not be found.");
            }

            if (Directory.GetFiles(inputDirectory, "*", SearchOption.AllDirectories).Length == 0)
            {
                throw new FileNotFoundException($"The specified directory '{inputDirectory}' is empty; Packages must contain at least one file.");
            }
        }

        /// <summary>
        ///     Compares the specified manifest to the contents of the specified directory and hashes any files that had been
        ///     deferred for hashing in the manifest.
        /// </summary>
        /// <param name="manifest">The manifest for which validation and hash generation is to be performed.</param>
        /// <param name="directory">The directory containing payload files.</param>
        private static void ValidateManifestAndGenerateHashes(PackageManifest manifest, string directory)
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
        private static PackageManifest ValidateManifestFileArgumentAndRetrieveManifest(string manifestFile)
        {
            if (manifestFile == default(string) || manifestFile == string.Empty)
            {
                throw new ArgumentException("The required argument 'manifest' (-m) was not supplied.");
            }

            if (!File.Exists(manifestFile))
            {
                throw new FileNotFoundException($"The specified manifest file '{manifestFile}' could not be found.");
            }

            string manifestContents = File.ReadAllText(manifestFile);

            if (manifestContents.Length == 0)
            {
                throw new InvalidDataException($"The specified manifests file '{manifestFile}' is empty.");
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
        ///     Validates the packageFile argument for <see cref="CreatePackage(string, string, string, bool, string, string, string)"/>.
        /// </summary>
        /// <param name="packageFile">The value specified for the packageFile argument.</param>
        /// <exception cref="ArgumentException">Thrown when the package file is a default or null string.</exception>
        /// <exception cref="Exception">Thrown when the package file can not be written.</exception>
        private static void ValidatePackageFileArgument(string packageFile)
        {
            if (packageFile == default(string) || packageFile == string.Empty)
            {
                throw new ArgumentException($"The required argument 'package' (-p|--package) was not supplied.");
            }

            try
            {
                File.WriteAllText(packageFile, "Hello World!");
                File.Delete(packageFile);
            }
            catch (Exception ex)
            {
                throw new Exception($"The specified package file '{packageFile}' could not be written: {ex.Message}");
            }
        }

        /// <summary>
        ///     Validates the signPackage, privateKeyFile and publicKeyFile arguments for
        ///     <see cref="CreatePackage(string, string, string, bool, string, string, string)"/> and returns a value indicating
        ///     whether the package should be signed.
        /// </summary>
        /// <param name="signPackage">The value specified for the signPackage argument.</param>
        /// <param name="privateKeyFile">The value specified for the privateKeyFile argument.</param>
        /// <param name="password">the value specified for the privateKeyPassword argument.</param>
        /// <param name="keybaseUsername">
        ///     The Keybase.io username of the account hosting the PGP public key used for digest verification.
        /// </param>
        /// <exception cref="ArgumentException">
        ///     Thrown when the privateKeyFile, privateKeyPassword, or publicKeyFile arguments are a default or null string.
        /// </exception>
        /// <exception cref="FileNotFoundException">
        ///     Thrown when the private or public key files can not be found on the local file system.
        /// </exception>
        /// <exception cref="InvalidDataException">Thrown when the private or public key files are empty.</exception>
        private static void ValidateSignatureArguments(bool signPackage, string privateKeyFile, string password, string keybaseUsername)
        {
            if (signPackage)
            {
                if (privateKeyFile == default(string) || privateKeyFile == string.Empty)
                {
                    throw new ArgumentException($"The required argument 'private-key' (-r) was not supplied.");
                }

                if (!File.Exists(privateKeyFile))
                {
                    throw new FileNotFoundException($"The specified private key file '{privateKeyFile}' could not be found.");
                }

                if (File.ReadAllText(privateKeyFile).Length == 0)
                {
                    throw new InvalidDataException($"The specified private key file '{privateKeyFile}' is empty.");
                }

                if (password == default(string) || password == string.Empty)
                {
                    throw new ArgumentException($"The required argument 'private-key-password' (-r) was not supplied.");
                }

                if (keybaseUsername == default(string) || keybaseUsername == string.Empty)
                {
                    throw new ArgumentException($"The required argument 'keybase-username' (-u) was not supplied.");
                }
            }
        }

        /// <summary>
        ///     Serializes the specified manifest to JSON and writes it to a 'manifest.json' file in the specified directory.
        /// </summary>
        /// <param name="manifest">The manifest to serialize and write.</param>
        /// <param name="directory">The directory into which the generated file will be written.</param>
        private static void WriteManifest(PackageManifest manifest, string directory)
        {
            string destinationFile = Path.Combine(directory, "manifest.json");
            string contents = manifest.ToJson();

            File.WriteAllText(destinationFile, contents);
        }

        /// <summary>
        ///     Fetches the PGP public key for the specified keybase.io username from the keybase.io API.
        /// </summary>
        /// <param name="username">The keybase.io username of the user for which the PGP public key is to be fetched..</param>
        /// <returns>The fetched PGP public key.</returns>
        /// <exception cref="WebException">Thrown when an error occurs fetching the key.</exception>
        public static string FetchPublicKeyForUser(string username)
        {
            string url = Constants.KeyUrlBase.Replace(Constants.KeyUrlPlaceholder, username);

            OnUpdated($"Fetching PGP key information from {url}...");

            try
            {
                using (WebClient client = new WebClient())
                {
                    string content = client.DownloadString(url);

                    OnUpdated($"Key information fetched.  Parsing primary public key...");

                    JObject key = JObject.Parse(content);
                    string publicKey = key["them"]["public_keys"]["primary"]["bundle"].ToString();

                    if (publicKey.Length < Constants.KeyMinimumLength)
                    {
                        throw new InvalidDataException($"The length of the retrieved key was not long enough (expected: >= {Constants.KeyMinimumLength}, actual: {publicKey.Length}) to be a valid PGP public key.");
                    }

                    OnUpdated($"Public key fetched successfully.");

                    return publicKey;
                }
            }
            catch (Exception ex)
            {
                throw new WebException($"Failed to fetch the object from '{url}': {ex.Message}");
            }
        }

        #endregion Private Methods
    }
}