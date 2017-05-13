using OpenIIoT.SDK.Common;
using OpenIIoT.SDK.Package.Manifest;
using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using Utility.PGPSignatureTools;

namespace OpenIIoT.SDK.Package.Packaging
{
    public static class PackageTruster
    {
        #region Public Events

        public static event EventHandler<PackagingUpdateEventArgs> Updated;

        #endregion Public Events

        #region Public Methods

        public static void TrustPackage(string packageFile, string privateKeyFile, string passphrase)
        {
            PackageManifest manifest = ManifestExtractor.ExtractManifest(packageFile);

            byte[] digestBytes = Encoding.ASCII.GetBytes(manifest.Signature.Digest);
            string privateKey = File.ReadAllText(privateKeyFile);

            byte[] trustBytes = PGPSignature.Sign(digestBytes, privateKey, passphrase);
            string trust = Encoding.ASCII.GetString(trustBytes);

            manifest.Signature.Trust = trust;

            UpdatePackageManifest(packageFile, manifest);
            OnUpdated(" √ Manifest updated successfully.");
        }

        #endregion Public Methods

        #region Private Methods

        private static void UpdatePackageManifest(string packageFile, PackageManifest manifest)
        {
            // looks like: temp\OpenIIoT.SDK\<Guid>\
            string tempDirectory = Path.Combine(Path.GetTempPath(), System.Reflection.Assembly.GetEntryAssembly().GetName().Name, Guid.NewGuid().ToString());
            string tempFile = Path.Combine(tempDirectory, Package.Constants.ManifestFilename);

            OnUpdated($"Updating Manifest in Package '{Path.GetFileName(packageFile)}'...");

            try
            {
                OnUpdated($"Writing Manifest to temp file '{tempFile}'...");
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

        private static void OnUpdated(string message)
        {
            if (Updated != null)
            {
                Updated(null, new PackagingUpdateEventArgs(PackagingOperation.Trust, message));
            }
        }

        #endregion Private Methods
    }
}