using System;

namespace OpenIIoT.SDK.Package.Packager
{
    public static class PackageVerifier
    {
        #region Public Events

        public static event EventHandler<PackagerUpdateEventArgs> Updated;

        #endregion Public Events

        public static void VerifyPackage(string packageFile)
        {
            OnUpdated("Not yet implemented.");
        }

        private static void OnUpdated(string message)
        {
            if (Updated != null)
            {
                Updated(null, new PackagerUpdateEventArgs(PackagerOperation.Verify, message));
            }
        }
    }
}