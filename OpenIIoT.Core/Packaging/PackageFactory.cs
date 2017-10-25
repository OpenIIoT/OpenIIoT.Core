namespace OpenIIoT.Core.Packaging
{
    using System;
    using System.IO;
    using Newtonsoft.Json;
    using NLog.xLogger;
    using OpenIIoT.SDK.Common.OperationResult;
    using OpenIIoT.SDK.Packaging;
    using OpenIIoT.SDK.Packaging.Manifest;
    using OpenIIoT.SDK.Packaging.Operations;
    using OpenIIoT.SDK.Platform;

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

        public PackageFactory(IPlatformManager platformManager, IManifestExtractor manifestExtractor)
        {
            PlatformManager = platformManager;
            ManifestExtractor = manifestExtractor;
        }

        #endregion Public Constructors

        #region Private Properties$"Error deserializing Manifest in directory '{directory}': {ex.Message}."

        private IPlatform Platform => PlatformManager.Platform;
        private IManifestExtractor ManifestExtractor { get; set; }
        private IPlatformManager PlatformManager { get; set; }

        #endregion Private Properties$"Error deserializing Manifest in directory '{directory}': {ex.Message}."

        #region Public Methods

        public IResult<IPackage> GetPackage(string directory)
        {
            Guid guid = logger.EnterMethod(xLogger.Params(directory), true);

            IResult<IPackage> retVal = new Result<IPackage>();

            string manifestFileName = Path.Combine(directory, ".manifest.json");

            IResult<string> manifestReadResult = Platform.ReadFileText(manifestFileName);
            retVal.Incorporate(manifestReadResult);

            if (manifestReadResult.ResultCode != ResultCode.Failure)
            {
                try
                {
                    PackageManifest manifest = JsonConvert.DeserializeObject<PackageManifest>(manifestReadResult.ReturnValue);

                    retVal.ReturnValue = new Package(new DirectoryInfo(directory), manifest);
                }
                catch (Exception ex)
                {
                    retVal.AddError($"Error deserializing Manifest in directory '{directory}': {ex.Message}.");
                }
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(guid);
            return retVal;
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