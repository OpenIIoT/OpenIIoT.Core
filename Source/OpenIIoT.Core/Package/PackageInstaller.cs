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
    public class PackageInstaller
    {
        #region Private Fields

        /// <summary>
        ///     The Logger for this class.
        /// </summary>
        private static xLogger logger = (xLogger)LogManager.GetCurrentClassLogger(typeof(xLogger));

        #endregion Private Fields

        #region Public Constructors

        public PackageInstaller(IPlatform platform)
        {
            Platform = platform;
        }

        #endregion Public Constructors

        #region Public Properties

        private IPlatform Platform { get; set; }

        #endregion Public Properties

        #region Public Methods

        public IResult InstallPackage(IPackage package, PackageInstallOptions options, string publicKey = "")
        {
            logger.EnterMethod(xLogger.Params(package, options, publicKey));
            IResult retVal = new Result();

            PackageExtractor extractor = new PackageExtractor();
            extractor.Updated += (sender, e) => logger.Debug(e.Message);

            // determine the installation directory; should look like \path\to\Plugins\FQN\
            string destination = Platform.Directories.Plugins;
            destination = Path.Combine(destination, package.FQN);

            bool overwrite = options.HasFlag(PackageInstallOptions.Overwrite);
            bool skipVerification = options.HasFlag(PackageInstallOptions.SkipVerification);

            try
            {
                extractor.ExtractPackage(package.FileName, destination, overwrite, skipVerification);
            }
            catch (Exception ex)
            {
                retVal.AddError($"Error installing Package '{fqn}': {ex.Message}");
            }

            retVal.LogResult(logger);
            logger.ExitMethod();
            return retVal;
        }

        #endregion Public Methods
    }
}