namespace OpenIIoT.Core.Packaging
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenIIoT.SDK.Common.OperationResult;
    using OpenIIoT.SDK.Packaging;
    using OpenIIoT.SDK.Packaging.Operations;
    using NLog.xLogger;
    using OpenIIoT.SDK.Platform;
    using OpenIIoT.SDK.Packaging.Manifest;
    using System.IO;

    public class PackageScanner
    {
        #region Private Fields

        /// <summary>
        ///     The Logger for this class.
        /// </summary>
        private static new xLogger logger = xLogManager.GetCurrentClassxLogger();

        #endregion Private Fields

        #region Public Constructors

        public PackageScanner()
            : this(ApplicationManager.GetInstance().GetManager<IPlatformManager>(), new PackageFactory())
        {
        }

        public PackageScanner(IPackageFactory packageFactory)
            : this(ApplicationManager.GetInstance().GetManager<IPlatformManager>(), new PackageFactory())
        {
        }

        public PackageScanner(IPlatformManager platformManager, IPackageFactory packageFactory)
        {
            PlatformManager = platformManager;
            PackageFactory = packageFactory;
        }

        #endregion Public Constructors

        #region Private Properties

        private IPlatform Platform => PlatformManager.Platform;

        private IPackageFactory PackageFactory { get; set; }

        /// <summary>
        ///     Gets the <see cref="IPlatformManager"/> with which Platform operations are carried out.
        /// </summary>
        private IPlatformManager PlatformManager { get; set; }

        #endregion Private Properties

        #region Public Methods

        public IResult<IList<IPackageArchive>> ScanPackageArchives()
        {
            Guid guid = logger.EnterMethod(true);
            logger.Info("Scanning for Package Archives...");

            IResult<IList<IPackageArchive>> retVal = new Result<IList<IPackageArchive>>();
            retVal.ReturnValue = new List<IPackageArchive>();

            string directory = PlatformManager.Directories.Packages;

            logger.Debug($"Scanning directory '{directory}'...");

            ManifestExtractor.Updated += (sender, e) => logger.Debug(e.Message);

            IResult<IList<string>> fileListResult = Platform.ListFiles(directory);
            retVal.Incorporate(fileListResult);

            if (retVal.ResultCode != ResultCode.Failure)
            {
                foreach (string file in fileListResult.ReturnValue)
                {
                    IResult<IPackageArchive> readResult = PackageFactory.GetPackageArchive(file);

                    if (readResult.ResultCode != ResultCode.Failure)
                    {
                        retVal.ReturnValue.Add(readResult.ReturnValue);
                    }
                    else
                    {
                        retVal.AddWarning(readResult.GetLastError());
                    }
                }
            }

            retVal.LogResult(logger);
            logger.ExitMethod(guid);

            return retVal;
        }

        #endregion Public Methods
    }
}