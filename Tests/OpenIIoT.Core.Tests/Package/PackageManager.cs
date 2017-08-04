using Moq;
using OpenIIoT.SDK;
using OpenIIoT.SDK.Package;
using OpenIIoT.SDK.Platform;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utility.OperationResult;
using Xunit;

namespace OpenIIoT.Core.Tests.Package
{
    public class PackageManager : IDisposable
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PackageManager"/> class.
        /// </summary>
        public PackageManager()
        {
            Temp = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

            Directory.CreateDirectory(Temp);

            Uri codeBaseUri = new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            string codeBasePath = Uri.UnescapeDataString(codeBaseUri.AbsolutePath);
            string dirPath = Path.GetDirectoryName(codeBasePath);

            DataRoot = Path.Combine(dirPath, "Package", "Data");
            Data = Path.Combine(DataRoot, "Package");
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///     Disposes of this instance.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion Public Methods

        /// <summary>
        ///     Tests the <see cref="Core.Package.PackageUtility.Scan(string)"/> method with a bad directory.
        /// </summary>
        [Fact]
        public void ScanBadDirectory()
        {
            Mock<IApplicationManager> managerMock = new Mock<IApplicationManager>();
            Mock<IPlatformManager> platformManagerMock = new Mock<IPlatformManager>();
            Mock<IDirectories> dirMock = new Mock<IDirectories>();
            Mock<IPlatform> platformMock = new Mock<IPlatform>();

            IResult<IList<string>> dirResult = new Result<IList<string>>(ResultCode.Failure);

            dirMock.Setup(d => d.Packages).Returns(Data);

            platformMock.Setup(p => p.ListFiles(It.IsAny<string>())).Returns(dirResult);
            platformMock.Setup(p => p.Directories).Returns(dirMock.Object);

            platformManagerMock.Setup(p => p.Platform).Returns(platformMock.Object);

            IPackageManager test = Core.Package.PackageManager.Instantiate(managerMock.Object, platformManagerMock.Object);

            IResult<IList<IPackage>> list = test.ScanPackages();

            Assert.Equal(ResultCode.Failure, list.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Package.PackageUtility.Scan(string)"/> method with an empty directory.
        /// </summary>
        [Fact]
        public void ScanEmptyDirectory()
        {
            Mock<IApplicationManager> managerMock = new Mock<IApplicationManager>();
            Mock<IPlatformManager> platformManagerMock = new Mock<IPlatformManager>();
            Mock<IDirectories> dirMock = new Mock<IDirectories>();
            Mock<IPlatform> platformMock = new Mock<IPlatform>();

            IResult<IList<string>> dirResult = new Result<IList<string>>();
            dirResult.ReturnValue = new List<string>();

            dirMock.Setup(d => d.Packages).Returns(Data);

            platformMock.Setup(p => p.ListFiles(It.IsAny<string>())).Returns(dirResult);
            platformMock.Setup(p => p.Directories).Returns(dirMock.Object);

            platformManagerMock.Setup(p => p.Platform).Returns(platformMock.Object);

            IPackageManager test = Core.Package.PackageManager.Instantiate(managerMock.Object, platformManagerMock.Object);

            IResult<IList<IPackage>> list = test.ScanPackages();

            Assert.Equal(ResultCode.Success, list.ResultCode);

            Assert.NotNull(list.ReturnValue);
            Assert.Equal(0, list.ReturnValue.Count);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Package.PackageScanner.Scan(string)"/> method with a directory containing files but no Packages.
        /// </summary>
        [Fact]
        public void ScanNoPackages()
        {
            Mock<IApplicationManager> managerMock = new Mock<IApplicationManager>();
            Mock<IPlatformManager> platformManagerMock = new Mock<IPlatformManager>();
            Mock<IDirectories> dirMock = new Mock<IDirectories>();
            Mock<IPlatform> platformMock = new Mock<IPlatform>();

            File.WriteAllText(Path.Combine(Temp, "package.zip"), "hello world!");

            IResult<IList<string>> dirResult = new Result<IList<string>>();
            dirResult.ReturnValue = Directory.GetFiles(Temp).ToList();

            dirMock.Setup(d => d.Packages).Returns(Temp);

            platformMock.Setup(p => p.ListFiles(It.IsAny<string>())).Returns(dirResult);
            platformMock.Setup(p => p.Directories).Returns(dirMock.Object);

            platformManagerMock.Setup(p => p.Platform).Returns(platformMock.Object);

            IPackageManager test = Core.Package.PackageManager.Instantiate(managerMock.Object, platformManagerMock.Object);

            IResult<IList<IPackage>> list = test.ScanPackages();

            Assert.Equal(ResultCode.Warning, list.ResultCode);
            Assert.Equal(0, list.ReturnValue.Count);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Package.PackageScanner.Scan(string)"/> method with a directory containing Package files.
        /// </summary>
        [Fact]
        public void ScanPackages()
        {
            Mock<IApplicationManager> managerMock = new Mock<IApplicationManager>();
            Mock<IPlatformManager> platformManagerMock = new Mock<IPlatformManager>();
            Mock<IDirectories> dirMock = new Mock<IDirectories>();
            Mock<IPlatform> platformMock = new Mock<IPlatform>();

            IResult<IList<string>> dirResult = new Result<IList<string>>();
            dirResult.ReturnValue = Directory.GetFiles(Data).ToList();

            dirMock.Setup(d => d.Packages).Returns(Temp);

            platformMock.Setup(p => p.ListFiles(It.IsAny<string>())).Returns(dirResult);
            platformMock.Setup(p => p.Directories).Returns(dirMock.Object);

            platformManagerMock.Setup(p => p.Platform).Returns(platformMock.Object);

            IPackageManager test = Core.Package.PackageManager.Instantiate(managerMock.Object, platformManagerMock.Object);

            IResult<IList<IPackage>> list = test.ScanPackages();

            Assert.Equal(ResultCode.Success, list.ResultCode);
            Assert.Equal(3, list.ReturnValue.Count);

            // spot check a few Manifest fields to see if the manifest was fetched properly
            Assert.NotNull(list.ReturnValue[0].FQN);
            Assert.NotEqual(0, list.ReturnValue[0].FQN.Length);
        }

        #region Protected Methods

        /// <summary>
        ///     Disposes of this instance.
        /// </summary>
        /// <param name="disposing">A value indicating whether this method has been called directly or indirectly from code.</param>
        protected virtual void Dispose(bool disposing)
        {
            Directory.Delete(Temp, true);

            Core.Package.PackageManager.Terminate();
        }

        #endregion Protected Methods

        #region Private Properties

        /// <summary>
        ///     Gets or sets the package test data directory.
        /// </summary>
        private string Data { get; set; }

        /// <summary>
        ///     Gets or sets the root test data directory.
        /// </summary>
        private string DataRoot { get; set; }

        /// <summary>
        ///     Gets or sets the temporary data directory.
        /// </summary>
        private string Temp { get; set; }

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        ///     Tests the <see cref="Core.Package.PackageUtility.Create(byte[])"/> method with a known good package payload.
        /// </summary>
        [Fact]
        public void CreatePackage()
        {
            byte[] data = File.ReadAllBytes(Path.Combine(Data, "package.zip"));

            Mock<IApplicationManager> managerMock = new Mock<IApplicationManager>();
            Mock<IPlatformManager> platformManagerMock = new Mock<IPlatformManager>();

            Mock<IDirectories> dirMock = new Mock<IDirectories>();
            dirMock.Setup(d => d.Packages).Returns(Temp);
            dirMock.Setup(d => d.Temp).Returns(Temp);

            IResult<string> successResult = new Result<string>();

            Mock<IPlatform> platformMock = new Mock<IPlatform>();
            platformMock.Setup(p => p.Directories).Returns(dirMock.Object);

            platformMock.Setup(p => p.WriteFileBytes(It.IsAny<string>(), It.IsAny<byte[]>()))
                .Returns(successResult)
                    .Callback<string, byte[]>((f, b) => File.WriteAllBytes(f, b));

            platformMock.Setup(p => p.CopyFile(It.IsAny<string>(), It.IsAny<string>(), true))
                .Returns(successResult)
                    .Callback<string, string, bool>((s, d, o) => File.Copy(s, d, o));

            platformManagerMock.Setup(p => p.Platform).Returns(platformMock.Object);

            IPackageManager test = Core.Package.PackageManager.Instantiate(managerMock.Object, platformManagerMock.Object);

            IResult<IPackage> package = test.CreatePackage(data);

            Assert.Equal(ResultCode.Success, package.ResultCode);
            Assert.True(File.Exists(Path.Combine(Temp, "OpenIIoT.Plugin.DefaultPlugin.1.0.0.zip")));
        }

        /// <summary>
        ///     Tests the <see cref="Core.Package.PackageUtility.Create(byte[])"/> method with a known bad package payload.
        /// </summary>
        [Fact]
        public void CreatePackageBadData()
        {
            byte[] data = File.ReadAllBytes(Path.Combine(DataRoot, "notapackage.zip"));

            Mock<IApplicationManager> managerMock = new Mock<IApplicationManager>();
            Mock<IPlatformManager> platformManagerMock = new Mock<IPlatformManager>();

            Mock<IDirectories> dirMock = new Mock<IDirectories>();
            dirMock.Setup(d => d.Packages).Returns(Temp);
            dirMock.Setup(d => d.Temp).Returns(Temp);

            IResult<string> successResult = new Result<string>();

            Mock<IPlatform> platformMock = new Mock<IPlatform>();
            platformMock.Setup(p => p.Directories).Returns(dirMock.Object);

            platformMock.Setup(p => p.WriteFileBytes(It.IsAny<string>(), It.IsAny<byte[]>()))
                .Returns(successResult)
                    .Callback<string, byte[]>((f, b) => File.WriteAllBytes(f, b));

            platformMock.Setup(p => p.CopyFile(It.IsAny<string>(), It.IsAny<string>(), true))
                .Returns(successResult)
                    .Callback<string, string, bool>((s, d, o) => File.Copy(s, d, o));

            platformManagerMock.Setup(p => p.Platform).Returns(platformMock.Object);

            IPackageManager test = Core.Package.PackageManager.Instantiate(managerMock.Object, platformManagerMock.Object);

            IResult<IPackage> package = test.CreatePackage(data);

            Assert.Equal(ResultCode.Failure, package.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Package.PackageUtility.Create(byte[])"/> method with a mocked platform simulating a
        ///     failed file copy.
        /// </summary>
        [Fact]
        public void CreatePackageCopyFailed()
        {
            byte[] data = File.ReadAllBytes(Path.Combine(Data, "package.zip"));

            Mock<IApplicationManager> managerMock = new Mock<IApplicationManager>();
            Mock<IPlatformManager> platformManagerMock = new Mock<IPlatformManager>();

            Mock<IDirectories> dirMock = new Mock<IDirectories>();
            dirMock.Setup(d => d.Packages).Returns(Temp);
            dirMock.Setup(d => d.Temp).Returns(Temp);

            IResult<string> successResult = new Result<string>();
            IResult<string> failResult = new Result<string>(ResultCode.Failure);

            Mock<IPlatform> platformMock = new Mock<IPlatform>();
            platformMock.Setup(p => p.Directories).Returns(dirMock.Object);

            platformMock.Setup(p => p.WriteFileBytes(It.IsAny<string>(), It.IsAny<byte[]>()))
                .Returns(successResult)
                    .Callback<string, byte[]>((f, b) => File.WriteAllBytes(f, b));

            platformMock.Setup(p => p.CopyFile(It.IsAny<string>(), It.IsAny<string>(), true))
                .Returns(failResult);

            platformManagerMock.Setup(p => p.Platform).Returns(platformMock.Object);

            IPackageManager test = Core.Package.PackageManager.Instantiate(managerMock.Object, platformManagerMock.Object);
            IResult<IPackage> package = test.CreatePackage(data);

            Assert.Equal(ResultCode.Failure, package.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Package.PackageUtility.Create(byte[])"/> method with a mocked platform simulating a
        ///     failed file write.
        /// </summary>
        [Fact]
        public void CreatePackageWriteFailed()
        {
            byte[] data = new byte[] { };

            Mock<IApplicationManager> managerMock = new Mock<IApplicationManager>();
            Mock<IPlatformManager> platformManagerMock = new Mock<IPlatformManager>();

            Mock<IDirectories> dirMock = new Mock<IDirectories>();
            dirMock.Setup(d => d.Packages).Returns(Temp);
            dirMock.Setup(d => d.Temp).Returns(Temp);

            IResult<string> failResult = new Result<string>(ResultCode.Failure);

            Mock<IPlatform> platformMock = new Mock<IPlatform>();
            platformMock.Setup(p => p.Directories).Returns(dirMock.Object);

            platformMock.Setup(p => p.WriteFileBytes(It.IsAny<string>(), It.IsAny<byte[]>()))
                .Returns(failResult)
                    .Callback<string, byte[]>((f, b) => File.WriteAllBytes(f, b));

            platformManagerMock.Setup(p => p.Platform).Returns(platformMock.Object);

            IPackageManager test = Core.Package.PackageManager.Instantiate(managerMock.Object, platformManagerMock.Object);

            IResult<IPackage> package = test.CreatePackage(data);

            Assert.Equal(ResultCode.Failure, package.ResultCode);
        }

        #endregion Public Methods
    }
}