namespace OpenIIoT.Core.Packaging
{
    using System;
    using System.Collections.Generic;
    using NLog.xLogger;
    using OpenIIoT.SDK.Common.OperationResult;
    using OpenIIoT.SDK.Packaging;
    using OpenIIoT.SDK.Packaging.Operations;
    using OpenIIoT.SDK.Platform;
    using System.IO;

    public class PackageScanner : IPackageScanner
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

            string searchDirectory = Path.Combine(PlatformManager.Directories.Packages, "Archive");

            logger.Debug($"Scanning directory '{searchDirectory}'...");

            IResult<IList<string>> fileListResult = Platform.ListFiles(searchDirectory);
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

        public IResult<IList<IPackage>> ScanPackages()
        {
            Guid guid = logger.EnterMethod(true);
            logger.Info("Scanning for Packages...");

            IResult<IList<IPackage>> retVal = new Result<IList<IPackage>>();
            retVal.ReturnValue = new List<IPackage>();

            string searchDirectory = PlatformManager.Directories.Packages;

            logger.Debug($"Scanning directory '{searchDirectory}'...");

            IResult<IList<string>> dirListResult = Platform.ListDirectories(searchDirectory, "*.*");
            retVal.Incorporate(dirListResult);

            if (retVal.ResultCode != ResultCode.Failure)
            {
                foreach (string directory in dirListResult.ReturnValue)
                {
                    IResult<IPackage> readResult = PackageFactory.GetPackage(directory);

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