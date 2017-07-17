using System;
using System.Collections.Generic;
using System.IO;
using NLog;
using NLog.xLogger;
using OpenIIoT.SDK.Package;
using OpenIIoT.SDK.Packaging.Manifest;
using OpenIIoT.SDK.Packaging.Operations;
using Utility.OperationResult;
using OpenIIoT.SDK.Platform;

namespace OpenIIoT.Core.Package
{
    public class PackageReader
    {
        #region Private Fields

        /// <summary>
        ///     The Logger for this class.
        /// </summary>
        private static xLogger logger = (xLogger)LogManager.GetCurrentClassLogger(typeof(xLogger));

        #endregion Private Fields

        #region Public Constructors

        public PackageReader()
        {
        }

        #endregion Public Constructors

        #region Public Methods

        public IResult<IPackage> Read(string file)
        {
            logger.EnterMethod(true);
            IResult<IPackage> retVal = new Result<IPackage>();

            ManifestExtractor extractor = new ManifestExtractor();
            extractor.Updated += (sender, e) => logger.Debug(e.Message);

            PackageManifest manifest;

            try
            {
                manifest = extractor.ExtractManifest(file);

                retVal.ReturnValue = GetPackage(file, manifest);
            }
            catch (Exception ex)
            {
                retVal.AddWarning($"The package file '{Path.GetFileName(file)}' is not valid; the Manifest could not be extracted: {ex.Message}");
            }

            retVal.LogResult(logger);
            logger.ExitMethod();

            return retVal;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        ///     Creates a <see cref="Package"/> instance with file metadata from the given file and the given
        ///     <see cref="PackageManifest"/> .
        /// </summary>
        /// <param name="fileName">The filename from which to retrieve the Package metadata.</param>
        /// <param name="manifest">The Manifest with which to initialize the <see cref="Package"/> instance.</param>
        /// <returns>The created Package.</returns>
        private IPackage GetPackage(string fileName, PackageManifest manifest)
        {
            FileInfo info = new FileInfo(fileName);

            return new Package(fileName, info.LastWriteTime, manifest);
        }

        #endregion Private Methods
    }
}