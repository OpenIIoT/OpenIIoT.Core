using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenIIoT.SDK.Package.Packaging
{
    public static class PackageExtractor
    {
        #region Public Events

        public static event EventHandler<PackagingUpdateEventArgs> Updated;

        #endregion Public Events

        #region Public Methods

        public static void ExtractPackage(string packageFile, string directory)
        {
            ValidatePackageFileArgument(packageFile);

            OnUpdated("Not yet implemented.");
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