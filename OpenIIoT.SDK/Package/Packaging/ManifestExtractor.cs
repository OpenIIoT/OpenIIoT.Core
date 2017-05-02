using OpenIIoT.SDK.Common;
using OpenIIoT.SDK.Package.Manifest;
using System;
using System.IO;

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

            // TODO: implement this

            OnUpdated(" √ Manifest extracted.");

            if (manifestFile != default(string))
            {
                try
                {
                    OnUpdated($"Saving output to file '{manifestFile}'...");
                    File.WriteAllText(manifestFile, manifest.ToJson());
                    OnUpdated(" √ File saved successfully.");
                }
                catch (Exception ex)
                {
                    OnUpdated($"Unable to write to output file '{manifestFile}': {ex.Message}");
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