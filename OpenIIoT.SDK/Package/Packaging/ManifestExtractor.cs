using Newtonsoft.Json;
using OpenIIoT.SDK.Common;
using OpenIIoT.SDK.Package.Manifest;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace OpenIIoT.SDK.Package.Packaging
{
    public static class ManifestExtractor
    {
        #region Public Events

        public static event EventHandler<PackagingUpdateEventArgs> Updated;

        #endregion Public Events

        #region Public Methods

        public static PackageManifest ExtractManifest(string packageFile, string manifestFile)
        {
            ValidatePackageFileArgument(packageFile);

            PackageManifest manifest = new PackageManifest();

            OnUpdated($"Extracting manifest '{Package.Constants.ManifestFilename}' from package '{packageFile}'...");

            try
            {
                OnUpdated($"Locating manifest...");

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

        private static void OnUpdated(string message)
        {
            if (Updated != null)
            {
                Updated(null, new PackagingUpdateEventArgs(PackagingOperation.ManifestExtraction, message));
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