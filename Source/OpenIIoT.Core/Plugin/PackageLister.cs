using NLog;
using NLog.xLogger;
using OpenIIoT.SDK.Packaging.Manifest;
using OpenIIoT.SDK.Packaging.Operations;
using OpenIIoT.SDK.Platform;
using OpenIIoT.SDK.Plugin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.OperationResult;

namespace OpenIIoT.Core.Plugin
{
    public class PackageLister
    {
        #region Private Fields

        /// <summary>
        ///     The Logger for this class.
        /// </summary>
        private static xLogger logger = (xLogger)LogManager.GetCurrentClassLogger(typeof(xLogger));

        #endregion Private Fields

        #region Public Constructors

        public PackageLister(IPlatform platform)
        {
            Platform = platform;
        }

        #endregion Public Constructors

        #region Private Properties

        private IPlatform Platform { get; set; }

        #endregion Private Properties

        #region Public Methods

        public IResult<IList<IPackage>> List()
        {
            Guid guid = logger.EnterMethod(true);

            IResult<IList<IPackage>> retVal = new Result<IList<IPackage>>();
            retVal.ReturnValue = new List<IPackage>();

            IResult<IList<string>> listFiles = Platform.ListFiles(Platform.Directories.Packages);
            retVal.Incorporate(listFiles);

            if (retVal.ResultCode != ResultCode.Failure)
            {
                ManifestExtractor extractor = new ManifestExtractor();

                foreach (string file in listFiles.ReturnValue)
                {
                    PackageManifest manifest;

                    try
                    {
                        manifest = extractor.ExtractManifest(file);

                        retVal.ReturnValue.Add(GetPackage(file, manifest));
                    }
                    catch (Exception ex)
                    {
                        retVal.AddWarning($"The package file '{System.IO.Path.GetFileName(file)}' is not valid; the Manifest could not be extracted: {ex.Message}");
                    }
                }
            }

            retVal.LogResult(logger);
            logger.ExitMethod(guid);

            return retVal;
        }

        private IPackage GetPackage(string fileName, PackageManifest manifest)
        {
            FileInfo info = new FileInfo(fileName);

            return new Package(fileName, info.LastWriteTime, manifest);
        }

        #endregion Public Methods
    }
}