using Newtonsoft.Json;
using OpenIIoT.SDK.Package.Manifest;
using System;
using System.IO;
using System.IO.Compression;

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

                string manifestFilename = Path.Combine(tempDirectory, Package.Constants.ManifestFilename);
                if (!File.Exists(manifestFilename))
                {
                    throw new FileNotFoundException($"it does not contain a manifest.");
                }

                OnUpdated("Checking extracted files...");

                string payloadDirectory = Path.Combine(tempDirectory, Package.Constants.PayloadDirectoryName);
                if (!Directory.Exists(payloadDirectory))
                {
                    throw new DirectoryNotFoundException($"it does not contain a payload directory.");
                }
                else if (Directory.GetFiles(payloadDirectory).Length == 0)
                {
                    throw new FileNotFoundException($"the payload directory does not contain any files.");
                }

                OnUpdated(" √ Extracted files validated successfully.");

                OnUpdated($"Fetching manifest from '{manifestFilename}'...");
                PackageManifest manifest = ReadManifest(manifestFilename);
                OnUpdated(" √ Manifest fetched successfully.");

                if (!string.IsNullOrEmpty(manifest.Signature.Trust))
                {
                    // TODO: validate trust
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