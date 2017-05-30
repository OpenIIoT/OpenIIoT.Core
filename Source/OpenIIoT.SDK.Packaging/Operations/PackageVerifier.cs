/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄███████▄                                                               ▄█    █▄
      █     ███    ███                                                              ███    ███
      █     ███    ███   ▄█████   ▄██████    █  █▄     ▄█████     ▄████▄     ▄█████ ███    ███    ▄█████    █████  █     ▄█████  █     ▄█████    █████
      █     ███    ███   ██   ██ ██    ██   ██ ▄██▀    ██   ██   ██    ▀    ██   █  ███    ███   ██   █    ██  ██ ██    ██   ▀█ ██    ██   █    ██  ██
      █   ▀█████████▀    ██   ██ ██    ▀    ██▐█▀      ██   ██  ▄██        ▄██▄▄    ███    ███  ▄██▄▄     ▄██▄▄█▀ ██▌  ▄██▄▄    ██▌  ▄██▄▄     ▄██▄▄█▀
      █     ███        ▀████████ ██    ▄  ▀▀████     ▀████████ ▀▀██ ███▄  ▀▀██▀▀    ███    ███ ▀▀██▀▀    ▀███████ ██  ▀▀██▀▀    ██  ▀▀██▀▀    ▀███████
      █     ███          ██   ██ ██    ██   ██ ▀██▄    ██   ██   ██    ██   ██   █   ██▄  ▄██    ██   █    ██  ██ ██    ██      ██    ██   █    ██  ██
      █    ▄████▀        ██   █▀ ██████▀    ▀█   ▀█▀   ██   █▀   ██████▀    ███████   ▀████▀     ███████   ██  ██ █     ██      █     ███████   ██  ██
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

using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenIIoT.SDK.Common;
using OpenIIoT.SDK.Packaging.Manifest;
using OpenIIoT.SDK.Packaging.Properties;
using Utility.PGPSignatureTools;

namespace OpenIIoT.SDK.Packaging.Operations
{
    /// <summary>
    ///     Verifies Packages.
    /// </summary>
    public class PackageVerifier : PackagingOperation
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PackageVerifier"/> class.
        /// </summary>
        public PackageVerifier()
            : base(PackagingOperationType.Verify)
        {
            TrustPGPPublicKey = Resources.PGPPublicKey;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        ///     Gets or sets the PGP Public Key to use when verifying a Package Trust.
        /// </summary>
        /// <remarks>Defaults to the embedded PGP Public Key.</remarks>
        public string TrustPGPPublicKey { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///     Verifies the specified Package.
        /// </summary>
        /// <param name="packageFile">The Package to verify.</param>
        /// <param name="publicKeyFile">The filename of the file containing the ASCII armored PGP private key.</param>
        /// <returns>A value indicating whether the specified Package was verified successfully.</returns>
        public bool VerifyPackage(string packageFile, string publicKeyFile = "")
        {
            ArgumentValidator.ValidatePackageFileArgumentForReading(packageFile);

            if (!string.IsNullOrEmpty(publicKeyFile))
            {
                ArgumentValidator.ValidatePublicKeyArgument(publicKeyFile);
            }

            Info($"Verifying Package '{Path.GetFileName(packageFile)}'...");

            Exception deferredException = default(Exception);

            string tempDirectory = Path.Combine(Path.GetTempPath(), GetType().Namespace.Split('.')[0], Guid.NewGuid().ToString());

            try
            {
                Verbose($"Extracting package '{Path.GetFileName(packageFile)}' to temp directory '{tempDirectory}'");
                ZipFile.ExtractToDirectory(packageFile, tempDirectory);
                Verbose("Package extracted successfully.");

                Verbose("Checking extracted files...");
                string manifestFilename = Path.Combine(tempDirectory, PackagingConstants.ManifestFilename);

                if (!File.Exists(manifestFilename))
                {
                    throw new FileNotFoundException("it does not contain a manifest.");
                }

                string payloadFilename = Path.Combine(tempDirectory, PackagingConstants.PayloadArchiveName);

                if (!File.Exists(payloadFilename))
                {
                    throw new FileNotFoundException("it does not contain a payload archive.");
                }

                Verbose("Manifest and Payload Archive extracted successfully.");

                Verbose($"Fetching manifest from '{manifestFilename}'...");
                PackageManifest manifest = ReadManifest(manifestFilename);
                Verbose("Manifest fetched successfully.");

                string verifiedTrust = string.Empty;

                if (manifest.Signature != default(PackageManifestSignature))
                {
                    Verbose("Verifying the Manifest Signature...");

                    if (manifest.Signature.Trust != default(string))
                    {
                        VerifyTrust(manifest);
                    }

                    string publicKey = string.Empty;

                    if (!string.IsNullOrEmpty(publicKeyFile))
                    {
                        Verbose("Reading Public Key file...");
                        publicKey = File.ReadAllText(publicKeyFile);
                    }
                    else
                    {
                        Verbose($"Fetching Public Key for {manifest.Signature.Subject}...");
                        publicKey = FetchPublicKeyForUser(manifest.Signature.Subject);
                    }

                    VerifyDigest(manifest, publicKey);

                    Verbose("Manifest Signature verified successfully.");
                }

                Verbose("Verifying Manifest and Payload checksums...");
                Verbose($"Computing SHA512 checksum for the payload file {payloadFilename}...");
                string checksum = Common.Utility.ComputeFileSHA512Hash(payloadFilename);
                Verbose("Checksum computed successfully.");

                if (manifest.Checksum != checksum)
                {
                    throw new InvalidDataException($"the Manifest checksum, {manifest.Checksum}, does not match the computed checksum of the payload file, {checksum}.");
                }

                Verbose("Checksums verified successfully.");

                Verbose("Extracting Payload Archive...");
                string payloadDirectory = Path.Combine(tempDirectory, PackagingConstants.PayloadDirectoryName);
                ZipFile.ExtractToDirectory(payloadFilename, payloadDirectory);
                Verbose("Payload Archive extracted successfully.");

                VerifyPayloadFiles(manifest, payloadDirectory);

                Success("Package verified successfully.");
            }
            catch (Exception ex)
            {
                deferredException = new Exception($"Package '{packageFile}' is invalid: {ex.Message}", ex);
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

            return true;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        ///     Fetches the PGP public key for the specified keybase.io username from the keybase.io API.
        /// </summary>
        /// <param name="username">The keybase.io username of the user for which the PGP public key is to be fetched..</param>
        /// <returns>The fetched PGP public key.</returns>
        /// <exception cref="WebException">Thrown when an error occurs fetching the key.</exception>
        public string FetchPublicKeyForUser(string username)
        {
            string url = PackagingConstants.KeyUrlBase.Replace(PackagingConstants.KeyUrlPlaceholder, username);

            Verbose($"Fetching PGP key information from {url}...");

            try
            {
                using (WebClient client = new WebClient())
                {
                    string content = client.DownloadString(url);

                    Verbose($"Key information fetched.  Parsing primary public key...");

                    JObject key = JObject.Parse(content);
                    string publicKey = key["them"]["public_keys"]["primary"]["bundle"].ToString();

                    Verbose($"Public key fetched successfully.");

                    return publicKey;
                }
            }
            catch (Exception ex)
            {
                throw new WebException($"Failed to retrieve the PGP Public Key for the package: '{url}': {ex.Message}");
            }
        }

        /// <summary>
        ///     Reads and deserializes the <see cref="PackageManifest"/> contains within the specified file.
        /// </summary>
        /// <param name="manifestFilename">the file from which to read and deserialize the Manifest.</param>
        /// <returns>The deserialized Manifest.</returns>
        private PackageManifest ReadManifest(string manifestFilename)
        {
            try
            {
                return JsonConvert.DeserializeObject<PackageManifest>(File.ReadAllText(manifestFilename));
            }
            catch (Exception ex)
            {
                throw new InvalidDataException($"The contents of manifest file '{manifestFilename}' could not be read and deserialized: {ex.Message}");
            }
        }

        /// <summary>
        ///     Verifies the Digest contained in the specified Manifest using the specified PGP Public Key.
        /// </summary>
        /// <param name="manifest">The Manifest for which the Digest is to be verified.</param>
        /// <param name="publicKey">The PGP Public Key with which to verify the Digest.</param>
        /// <exception cref="InvalidDataException">
        ///     Thrown when an error is encountered verifying the Digest, or when the Manifest contents do not match the verified Digest.
        /// </exception>
        private void VerifyDigest(PackageManifest manifest, string publicKey)
        {
            string verifiedDigest = string.Empty;

            if (!string.IsNullOrEmpty(manifest.Signature.Digest))
            {
                Verbose("Verifying the Manifest Digest...");

                byte[] digestBytes = Encoding.ASCII.GetBytes(manifest.Signature.Digest);
                byte[] verifiedDigestBytes;

                try
                {
                    verifiedDigestBytes = PGPSignature.Verify(digestBytes, publicKey);
                }
                catch (Exception ex)
                {
                    throw new InvalidDataException($"an Exception was thrown while verifying the Digest: {ex.GetType().Name}: {ex.Message}", ex);
                }

                verifiedDigest = Encoding.ASCII.GetString(verifiedDigestBytes);

                // deserialize the verified manifest to work around text formatting differences on various platforms
                PackageManifest verifiedManifest = JsonConvert.DeserializeObject<PackageManifest>(verifiedDigest);

                // remove the digest and trust from the manifest, then serialize it and compare it to the verified digest.
                manifest.Signature.Digest = default(string);
                manifest.Signature.Trust = default(string);

                // if the scrubbed manifest and verified digest don't match, something was tampered with.
                if (manifest.ToJson() != verifiedManifest.ToJson())
                {
                    throw new InvalidDataException("the Manifest Digest is not valid; the verified Digest does not match the Manifest.");
                }

                Verbose("Digest verified successfully.");
            }
            else
            {
                throw new InvalidDataException("the Manifest Digest is null or empty.");
            }
        }

        /// <summary>
        ///     Verifies the extracted Package payload against the list of files in the Manifest.
        /// </summary>
        /// <param name="manifest">The Manifest against which the extracted files are verified.</param>
        /// <param name="payloadDirectory">The directory containing the extracted payload files.</param>
        /// <exception cref="FileNotFoundException">
        ///     Thrown when the payload directory is empty, or when a file listed in the Manifest is not found in the payload directory.
        /// </exception>
        /// <exception cref="InvalidDataException">
        ///     Thrown when the SHA512 checksum of an extracted payload file does not match the checksum from the specified Manifest.
        /// </exception>
        private void VerifyPayloadFiles(PackageManifest manifest, string payloadDirectory)
        {
            Verbose("Checking extracted files...");

            foreach (PackageManifestFileType type in manifest.Files.Keys)
            {
                foreach (PackageManifestFile file in manifest.Files[type])
                {
                    Verbose($"Verifying file {file.Source}...");

                    // determine the absolute path for the file we need to examine
                    string fileToCheck = Path.Combine(payloadDirectory, file.Source);

                    if (!File.Exists(fileToCheck))
                    {
                        throw new FileNotFoundException($"The file '{file.Source}' is listed in the manifest but is not found on disk.");
                    }

                    string checksum = Common.Utility.ComputeFileSHA512Hash(fileToCheck);

                    if (file.Checksum != default(string) && file.Checksum != checksum)
                    {
                        throw new InvalidDataException($"The file '{file.Source}' is invalid; the computed checksum, {checksum}, does not match the checksum in the Manifest, {file.Checksum}.");
                    }
                }
            }

            Verbose("Extracted files validated successfully.");
        }

        /// <summary>
        ///     Verifies the Trust contained within the specified Manifest.
        /// </summary>
        /// <param name="manifest">The Manifest for which the Trust is to be verified.</param>
        /// <exception cref="InvalidDataException">
        ///     Thrown when the Manifest is Trusted but does not contain a Digest, when an error is encountered while verifying the
        ///     Trust, or when the verified Trust does not match the Manifest's Digest.
        /// </exception>
        private void VerifyTrust(PackageManifest manifest)
        {
            string verifiedTrust = string.Empty;

            if (manifest.Signature.Trust != string.Empty)
            {
                Verbose("Verifying the Manifest Trust...");

                if (string.IsNullOrEmpty(manifest.Signature.Digest))
                {
                    throw new InvalidDataException("the Manifest is Trusted but it contains no Digest to trust.");
                }

                byte[] trustBytes = Encoding.ASCII.GetBytes(manifest.Signature.Trust);
                byte[] verifiedTrustBytes;

                try
                {
                    verifiedTrustBytes = PGPSignature.Verify(trustBytes, TrustPGPPublicKey);
                }
                catch (Exception ex)
                {
                    throw new InvalidDataException($"an Exception was thrown while verifying the Trust: {ex.GetType().Name}: {ex.Message}");
                }

                verifiedTrust = Encoding.ASCII.GetString(verifiedTrustBytes);

                if (manifest.Signature.Digest != verifiedTrust)
                {
                    throw new InvalidDataException("the Manifest Trust is not valid; the Trusted Digest does not match the Digest in the Manifest.");
                }

                Verbose("Trust verified successfully.");
            }
            else
            {
                throw new InvalidDataException("the Manifest Trust is empty.");
            }
        }

        #endregion Private Methods
    }
}