using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenIIoT.SDK.Package.Manifest;
using Utility.PGPSignatureTools;
using System.Text;

namespace OpenIIoT.SDK.Package.Packaging
{
    public static class PackageVerifier
    {
        #region Public Events

        public static event EventHandler<PackagingUpdateEventArgs> Updated;

        #endregion Public Events

        #region Public Methods

        public static void VerifyPackage(string packageFile)
        {
            // looks like: temp\OpenIIoT.SDK\<Guid>\
            string tempDirectory = Path.Combine(Path.GetTempPath(), System.Reflection.Assembly.GetEntryAssembly().GetName().Name, Guid.NewGuid().ToString());

            try
            {
                OnUpdated($"Extracting package '{Path.GetFileName(packageFile)}' to temp directory '{tempDirectory}'");
                ZipFile.ExtractToDirectory(packageFile, tempDirectory);
                OnUpdated(" √ Package extracted successfully.");

                OnUpdated("Checking extracted files...");

                string manifestFilename = Path.Combine(tempDirectory, Package.Constants.ManifestFilename);
                if (!File.Exists(manifestFilename))
                {
                    throw new FileNotFoundException("it does not contain a manifest.");
                }

                string payloadFilename = Path.Combine(tempDirectory, Package.Constants.PayloadArchiveName);
                if (!File.Exists(payloadFilename))
                {
                    throw new FileNotFoundException("it does not contain a payload archive.");
                }

                OnUpdated(" √ Manifest and Payload Archive extracted successfully.");
                OnUpdated("Extracting Payload Archive...");

                ZipFile.ExtractToDirectory(payloadFilename, Path.Combine(tempDirectory, Package.Constants.PayloadDirectoryName));

                OnUpdated(" √ Payload Archive extracted successfully.");
                OnUpdated("Checking extracted files...");

                string payloadDirectory = Path.Combine(tempDirectory, Package.Constants.PayloadDirectoryName);

                if (Directory.GetFiles(payloadDirectory).Length == 0)
                {
                    throw new FileNotFoundException("the payload directory does not contain any files.");
                }

                OnUpdated(" √ Extracted files validated successfully.");

                OnUpdated($"Fetching manifest from '{manifestFilename}'...");
                PackageManifest manifest = ReadManifest(manifestFilename);
                OnUpdated(" √ Manifest fetched successfully.");

                if (!string.IsNullOrEmpty(manifest.Signature.Trust))
                {
                    OnUpdated("Verifying the Manifest Trust...");

                    if (string.IsNullOrEmpty(manifest.Signature.Digest))
                    {
                        throw new InvalidDataException("the manifest is trusted but it contains no digest to trust.");
                    }

                    byte[] trustBytes = Encoding.ASCII.GetBytes(manifest.Signature.Trust);
                    byte[] verifiedDigestBytes;

                    try
                    {
                        verifiedDigestBytes = PGPSignature.Verify(trustBytes, SDK.Constants.PGPPublicKey);
                    }
                    catch (Exception ex)
                    {
                        throw new InvalidDataException($"an Exception was thrown while verifying the Trust: {ex.Message}");
                    }

                    string verifiedDigest = Encoding.ASCII.GetString(verifiedDigestBytes);

                    if (manifest.Signature.Digest != verifiedDigest)
                    {
                        throw new InvalidDataException("the manifest trust is not valid.");
                    }

                    OnUpdated(" √ Trust verified successfully.");
                }

                if (!string.IsNullOrEmpty(manifest.Signature.Digest))
                {
                    // TODO: validate signature
                }
            }
            catch (Exception ex)
            {
                OnUpdated($"Package '{packageFile}' is invalid: {ex.Message}");
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

        private static void OnUpdated(string message)
        {
            if (Updated != null)
            {
                Updated(null, new PackagingUpdateEventArgs(PackagingOperation.Verify, message));
            }
        }

        private static PackageManifest ReadManifest(string manifestFilename)
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

        private static void ValidatePackageFileArgument(string packageFile)
        {
            if (string.IsNullOrEmpty(packageFile))
            {
                throw new ArgumentException($"The required argument 'package' (-p|--package) was not supplied.");
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