using NLog.xLogger;
using OpenIIoT.SDK.Common.OperationResult;
using OpenIIoT.SDK.Packaging;
using OpenIIoT.SDK.Packaging.Manifest;
using OpenIIoT.SDK.Packaging.Operations;
using OpenIIoT.SDK.Platform;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenIIoT.Core.Packaging
{
    public class PackageFactory : IPackageFactory
    {
        #region Private Fields

        /// <summary>
        ///     The Logger for this class.
        /// </summary>
        private static new xLogger logger = xLogManager.GetCurrentClassxLogger();

        #endregion Private Fields

        #region Public Constructors

        public PackageFactory()
            : this(ApplicationManager.GetInstance().GetManager<IPlatformManager>(), new ManifestExtractor())
        {
        }

        public PackageFactory(IPlatformManager platformManager)
            : this(platformManager, new ManifestExtractor())
        {
        }

        public PackageFactory(IPlatformManager platformManager, IManifestExtractor manifestExtractor)
        {
            PlatformManager = platformManager;
            ManifestExtractor = manifestExtractor;
        }

        #endregion Public Constructors

        #region Private Properties

        private IManifestExtractor ManifestExtractor { get; set; }
        private IPlatformManager PlatformManager { get; set; }

        #endregion Private Properties

        #region Public Methods

        public IResult<IPackage> GetPackage(string directory)
        {
            // TODO: read .manifest.json from the directory, deserialize to manifest
            return new Result<IPackage>();
        }

        public IResult<IPackageArchive> GetPackageArchive(string fileName)
        {
            Guid guid = logger.EnterMethod(xLogger.Params(fileName), true);

            logger.Debug($"Reading Package Archive '{fileName}'...");

            IResult<IPackageArchive> retVal = new Result<IPackageArchive>();
            ManifestExtractor extractor = new ManifestExtractor();

            extractor.Updated += (sender, e) => logger.Debug(e.Message);

            PackageManifest manifest;
            FileInfo fileInfo;

            try
            {
                manifest = extractor.ExtractManifest(fileName);
                fileInfo = new FileInfo(fileName);

                retVal.ReturnValue = new PackageArchive(fileInfo, manifest);
            }
            catch (Exception ex)
            {
                retVal.AddError(ex.Message);
                retVal.AddError($"Unable to read Package archive '{Path.GetFileName(fileName)}'.");
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(guid);

            return retVal;
        }

        #endregion Public Methods
    }
}