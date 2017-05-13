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

            ZipArchive package = ZipFile.Open(packageFile, ZipArchiveMode.Update);

            package.GetEntry(Package.Constants.ManifestFilename).Delete();

            File.WriteAllText(@"c:\pkg\manifest.json", manifest.ToJson());
            package.CreateEntryFromFile(@"c:\pkg\manifest.json", Package.Constants.ManifestFilename);
            package.Dispose();
        }

        #endregion Public Methods

        #region Private Methods

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