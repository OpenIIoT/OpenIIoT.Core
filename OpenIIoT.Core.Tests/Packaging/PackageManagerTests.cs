/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄███████▄                                                                 ▄▄▄▄███▄▄▄▄
      █     ███    ███                                                               ▄██▀▀▀███▀▀▀██▄
      █     ███    ███   ▄█████   ▄██████    █  █▄     ▄█████     ▄████▄     ▄█████  ███   ███   ███   ▄█████  ██▄▄▄▄    ▄█████     ▄████▄     ▄█████    █████
      █     ███    ███   ██   ██ ██    ██   ██ ▄██▀    ██   ██   ██    ▀    ██   █   ███   ███   ███   ██   ██ ██▀▀▀█▄   ██   ██   ██    ▀    ██   █    ██  ██
      █   ▀█████████▀    ██   ██ ██    ▀    ██▐█▀      ██   ██  ▄██        ▄██▄▄     ███   ███   ███   ██   ██ ██   ██   ██   ██  ▄██        ▄██▄▄     ▄██▄▄█▀
      █     ███        ▀████████ ██    ▄  ▀▀████     ▀████████ ▀▀██ ███▄  ▀▀██▀▀     ███   ███   ███ ▀████████ ██   ██ ▀████████ ▀▀██ ███▄  ▀▀██▀▀    ▀███████
      █     ███          ██   ██ ██    ██   ██ ▀██▄    ██   ██   ██    ██   ██   █   ███   ███   ███   ██   ██ ██   ██   ██   ██   ██    ██   ██   █    ██  ██
      █    ▄████▀        ██   █▀ ██████▀    ▀█   ▀█▀   ██   █▀   ██████▀    ███████   ▀█   ███   █▀    ██   █▀  █   █    ██   █▀   ██████▀    ███████   ██  ██
      █
      █       ███
      █   ▀█████████▄
      █      ▀███▀▀██    ▄█████   ▄█████     ██      ▄█████
      █       ███   ▀   ██   █    ██  ▀  ▀███████▄   ██  ▀
      █       ███      ▄██▄▄      ██         ██  ▀   ██
      █       ███     ▀▀██▀▀    ▀███████     ██    ▀███████
      █       ███       ██   █     ▄  ██     ██       ▄  ██
      █      ▄████▀     ███████  ▄████▀     ▄██▀    ▄████▀
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Unit tests for the PackageManager class.
      █
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀ ▀ ▀▀▀     ▀▀               ▀
      █  The GNU Affero General Public License (GNU AGPL)
      █
      █  Copyright (C) 2016-2017 JP Dillingham (jp@dillingham.ws)
      █
      █  This program is free software: you can redistribute it and/or modify
      █  it under the terms of the GNU Affero General Public License as published by
      █  the Free Software Foundation, either version 3 of the License, or
      █  (at your option) any later version.
      █
      █  This program is distributed in the hope that it will be useful,
      █  but WITHOUT ANY WARRANTY; without even the implied warranty of
      █  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
      █  GNU Affero General Public License for more details.
      █
      █  You should have received a copy of the GNU Affero General Public License
      █  along with this program.  If not, see <http://www.gnu.org/licenses/>.
      █
      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██
                                                                                                   ██
                                                                                               ▀█▄ ██ ▄█▀
                                                                                                 ▀████▀
                                                                                                   ▀▀                            */

namespace OpenIIoT.Core.Tests.Packaging
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using Moq;
    using OpenIIoT.Core.Packaging;
    using OpenIIoT.SDK;
    using OpenIIoT.SDK.Common;
    using OpenIIoT.SDK.Common.OperationResult;
    using OpenIIoT.SDK.Packaging;
    using OpenIIoT.SDK.Platform;
    using Xunit;
    using OpenIIoT.SDK.Packaging.Manifest;

    /// <summary>
    ///     Unit tests for the <see cref="PackageManager"/> class.
    /// </summary>
    public class PackageManagerTests : IDisposable
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PackageManagerTests"/> class.
        /// </summary>
        public PackageManagerTests()
        {
            Temp = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

            Directory.CreateDirectory(Temp);

            Uri codeBaseUri = new Uri(Assembly.GetExecutingAssembly().CodeBase);
            string codeBasePath = Uri.UnescapeDataString(codeBaseUri.AbsolutePath);
            string dirPath = Path.GetDirectoryName(codeBasePath);

            DataRoot = Path.Combine(dirPath, "Data");
            Data = Path.Combine(DataRoot, "Package");

            ManagerMock = new Mock<IApplicationManager>();
            PlatformManagerMock = new Mock<IPlatformManager>();
            DirectoryMock = new Mock<IDirectories>();
            PlatformMock = new Mock<IPlatform>();

            PackageScannerMock = new Mock<IPackageScanner>();
            PackageFactoryMock = new Mock<IPackageFactory>();

            PackageArchiveMock = new Mock<IPackageArchive>();
            PackageMock = new Mock<IPackage>();
            PackageManifestMock = new Mock<IPackageManifest>();

            SetupMocks();
        }

        #endregion Public Constructors

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
        ///     Gets or sets the IDirectories mockup for testing.
        /// </summary>
        private Mock<IDirectories> DirectoryMock { get; set; }

        /// <summary>
        ///     Gets or sets the IApplicationManager mockup for testing.
        /// </summary>
        private Mock<IApplicationManager> ManagerMock { get; set; }

        private Mock<IPackageArchive> PackageArchiveMock { get; set; }
        private Mock<IPackageFactory> PackageFactoryMock { get; set; }
        private Mock<IPackageManifest> PackageManifestMock { get; set; }
        private Mock<IPackage> PackageMock { get; set; }
        private Mock<IPackageScanner> PackageScannerMock { get; set; }

        /// <summary>
        ///     Gets or sets the IPlatformManager mockup for testing.
        /// </summary>
        private Mock<IPlatformManager> PlatformManagerMock { get; set; }

        /// <summary>
        ///     Gets or sets the IPlatform mockup for testing.
        /// </summary>
        private Mock<IPlatform> PlatformMock { get; set; }

        /// <summary>
        ///     Gets or sets the temporary data directory.
        /// </summary>
        private string Temp { get; set; }

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        ///     Tests the <see cref="PackageManager.AddPackageArchive(byte[])"/> method with a known good package payload.
        /// </summary>
        [Fact]
        public void AddPackageArchive()
        {
            byte[] data = File.ReadAllBytes(Path.Combine(Data, "package.zip"));

            IPackageManager test = PackageManager.Instantiate(ManagerMock.Object, PlatformManagerMock.Object);

            test.Inject("PackageFactory", PackageFactoryMock.Object);
            test.Inject("PackageScanner", PackageScannerMock.Object);

            IResult<IPackageArchive> package = test.AddPackageArchive(data);

            Assert.Equal(ResultCode.Success, package.ResultCode);
            Assert.Equal(PackageArchiveMock.Object, package.ReturnValue);
            Assert.True(File.Exists(Path.Combine(Temp, "OpenIIoT.Plugin.DefaultPlugin.1.0.0.zip")));
        }

        /// <summary>
        ///     Tests the <see cref="PackageManager.AddPackageArchiveAsync(byte[])"/> method with a known good package payload.
        /// </summary>
        /// <returns>The Task with which the execution is carried out.</returns>
        [Fact]
        public async Task AddPackageArchiveAsync()
        {
            byte[] data = File.ReadAllBytes(Path.Combine(Data, "package.zip"));

            IPackageManager test = PackageManager.Instantiate(ManagerMock.Object, PlatformManagerMock.Object);

            test.Inject("PackageFactory", PackageFactoryMock.Object);
            test.Inject("PackageScanner", PackageScannerMock.Object);

            IResult<IPackageArchive> package = await test.AddPackageArchiveAsync(data);

            Assert.Equal(ResultCode.Success, package.ResultCode);
            Assert.Equal(PackageArchiveMock.Object, package.ReturnValue);
            Assert.True(File.Exists(Path.Combine(Temp, "OpenIIoT.Plugin.DefaultPlugin.1.0.0.zip")));
        }

        /// <summary>
        ///     Tests the <see cref="PackageManager.AddPackageArchive(byte[])"/> method with a known bad package payload.
        /// </summary>
        [Fact]
        public void AddPackageArchiveBadData()
        {
            byte[] data = File.ReadAllBytes(Path.Combine(DataRoot, "notapackage.zip"));

            IPackageManager test = PackageManager.Instantiate(ManagerMock.Object, PlatformManagerMock.Object);
            IResult<IPackageArchive> package = test.AddPackageArchive(data);

            Assert.Equal(ResultCode.Failure, package.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="PackageManager.AddPackageArchive(byte[])"/> method with a mocked platform simulating a failed
        ///     file copy.
        /// </summary>
        [Fact]
        public void AddPackageArchiveCopyFailed()
        {
            IResult<string> successResult = new Result<string>();
            IResult<string> failResult = new Result<string>(ResultCode.Failure);

            byte[] data = File.ReadAllBytes(Path.Combine(Data, "package.zip"));

            PlatformMock.Setup(p => p.WriteFileBytes(It.IsAny<string>(), It.IsAny<byte[]>()))
                .Returns(successResult)
                    .Callback<string, byte[]>((f, b) => File.WriteAllBytes(f, b));

            PlatformMock.Setup(p => p.CopyFile(It.IsAny<string>(), It.IsAny<string>(), true))
                .Returns(failResult);

            IPackageManager test = PackageManager.Instantiate(ManagerMock.Object, PlatformManagerMock.Object);
            IResult<IPackageArchive> package = test.AddPackageArchive(data);

            Assert.Equal(ResultCode.Failure, package.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="PackageManager.AddPackageArchive(byte[])"/> method with a mocked platform simulating a failed
        ///     file write.
        /// </summary>
        [Fact]
        public void AddPackageArchiveWriteFailed()
        {
            IResult<string> failResult = new Result<string>(ResultCode.Failure);

            byte[] data = new byte[] { };

            PlatformMock.Setup(p => p.WriteFileBytes(It.IsAny<string>(), It.IsAny<byte[]>()))
                .Returns(failResult)
                    .Callback<string, byte[]>((f, b) => File.WriteAllBytes(f, b));

            IPackageManager test = PackageManager.Instantiate(ManagerMock.Object, PlatformManagerMock.Object);
            IResult<IPackageArchive> package = test.AddPackageArchive(data);

            Assert.Equal(ResultCode.Failure, package.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="PackageManager.DeletePackageArchive(IPackageArchive)"/> method.
        /// </summary>
        [Fact]
        public void DeletePackageArchive()
        {
            byte[] data = File.ReadAllBytes(Path.Combine(Data, "package.zip"));

            IPackageManager test = PackageManager.Instantiate(ManagerMock.Object, PlatformManagerMock.Object);

            test.Inject("PackageFactory", PackageFactoryMock.Object);
            test.Inject("PackageScanner", PackageScannerMock.Object);

            IResult<IPackageArchive> package = test.AddPackageArchive(data);

            Assert.Equal(ResultCode.Success, package.ResultCode);
            Assert.True(File.Exists(Path.Combine(Temp, "OpenIIoT.Plugin.DefaultPlugin.1.0.0.zip")));

            IResult deleteResult = test.DeletePackageArchive(package.ReturnValue);

            Assert.Equal(ResultCode.Success, deleteResult.ResultCode);
            Assert.False(File.Exists(Path.Combine(Temp, "OpenIIoT.Plugin.DefaultPlugin.1.0.0.zip")));
        }

        /// <summary>
        ///     Tests the <see cref="PackageManager.DeletePackageArchiveAsync(IPackageArchive)"/> method.
        /// </summary>
        /// <returns>The Task with which the execution is carried out.</returns>
        [Fact]
        public async Task DeletePackageArchiveAsync()
        {
            byte[] data = File.ReadAllBytes(Path.Combine(Data, "package.zip"));

            IPackageManager test = PackageManager.Instantiate(ManagerMock.Object, PlatformManagerMock.Object);

            test.Inject("PackageFactory", PackageFactoryMock.Object);
            test.Inject("PackageScanner", PackageScannerMock.Object);

            IResult<IPackageArchive> package = test.AddPackageArchive(data);

            Assert.Equal(ResultCode.Success, package.ResultCode);
            Assert.True(File.Exists(Path.Combine(Temp, "OpenIIoT.Plugin.DefaultPlugin.1.0.0.zip")));

            IResult deleteResult = await test.DeletePackageArchiveAsync(package.ReturnValue);

            Assert.Equal(ResultCode.Success, deleteResult.ResultCode);
            Assert.False(File.Exists(Path.Combine(Temp, "OpenIIoT.Plugin.DefaultPlugin.1.0.0.zip")));
        }

        /// <summary>
        ///     Tests the <see cref="PackageManager.DeletePackageArchive(IPackageArchive)"/> method with a Package Archive which
        ///     contains a null or empty FileName.
        /// </summary>
        [Fact]
        public void DeletePackageArchiveNoFileName()
        {
            PackageArchiveMock.Setup(p => p.FileName).Returns(string.Empty);

            IPackageManager test = PackageManager.Instantiate(ManagerMock.Object, PlatformManagerMock.Object);

            IResult deleteResult = test.DeletePackageArchive(PackageArchiveMock.Object);

            Assert.Equal(ResultCode.Failure, deleteResult.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="PackageManager.DeletePackageArchive(IPackageArchive)"/> method with a Package Archive which
        ///     does not exist.
        /// </summary>
        [Fact]
        public void DeletePackageArchiveNotFound()
        {
            PlatformMock.Setup(p => p.FileExists(It.IsAny<string>()))
                .Returns(false);

            IPackageManager test = PackageManager.Instantiate(ManagerMock.Object, PlatformManagerMock.Object);

            IResult deleteResult = test.DeletePackageArchive(PackageArchiveMock.Object);

            Assert.Equal(ResultCode.Failure, deleteResult.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="PackageManager.DeletePackageArchive(IPackageArchive)"/> method with a null Package Archive.
        /// </summary>
        [Fact]
        public void DeletePackageArchiveNull()
        {
            IPackageManager test = PackageManager.Instantiate(ManagerMock.Object, PlatformManagerMock.Object);

            IResult deleteResult = test.DeletePackageArchive(null);

            Assert.Equal(ResultCode.Failure, deleteResult.ResultCode);
        }

        /// <summary>
        ///     Disposes of this instance.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///     Tests the <see cref="PackageManager.FetchPackageArchive(IPackageArchive)"/> method with a known good Package.
        /// </summary>
        [Fact]
        public void FetchPackageArchive()
        {
            byte[] data = File.ReadAllBytes(Path.Combine(Data, "package.zip"));

            PlatformMock.Setup(p => p.ReadFileBytes(It.IsAny<string>()))
                .Returns(new Result<byte[]>().SetReturnValue(data));

            IPackageManager test = PackageManager.Instantiate(ManagerMock.Object, PlatformManagerMock.Object);

            test.Inject("PackageFactory", PackageFactoryMock.Object);
            test.Inject("PackageScanner", PackageScannerMock.Object);

            IResult<IPackageArchive> package = test.AddPackageArchive(data);

            Assert.Equal(ResultCode.Success, package.ResultCode);
            Assert.True(File.Exists(Path.Combine(Temp, "OpenIIoT.Plugin.DefaultPlugin.1.0.0.zip")));

            IResult<byte[]> readResult = test.FetchPackageArchive(package.ReturnValue);

            Assert.Equal(ResultCode.Success, readResult.ResultCode);
            Assert.Equal(data, readResult.ReturnValue);
        }

        /// <summary>
        ///     Tests the <see cref="PackageManager.FetchPackageArchiveAsync(IPackageArchive)"/> method with a known good Package.
        /// </summary>
        /// <returns>The Task with which the execution is carried out.</returns>
        [Fact]
        public async Task FetchPackageArchiveAsync()
        {
            byte[] data = File.ReadAllBytes(Path.Combine(Data, "package.zip"));

            PlatformMock.Setup(p => p.ReadFileBytes(It.IsAny<string>()))
                .Returns(new Result<byte[]>().SetReturnValue(data));

            IPackageManager test = PackageManager.Instantiate(ManagerMock.Object, PlatformManagerMock.Object);

            test.Inject("PackageFactory", PackageFactoryMock.Object);
            test.Inject("PackageScanner", PackageScannerMock.Object);

            IResult<IPackageArchive> package = test.AddPackageArchive(data);

            Assert.Equal(ResultCode.Success, package.ResultCode);
            Assert.True(File.Exists(Path.Combine(Temp, "OpenIIoT.Plugin.DefaultPlugin.1.0.0.zip")));

            IResult<byte[]> readResult = await test.FetchPackageArchiveAsync(package.ReturnValue);

            Assert.Equal(ResultCode.Success, readResult.ResultCode);
            Assert.Equal(data, readResult.ReturnValue);
        }

        /// <summary>
        ///     Tests the <see cref="PackageManager.FetchPackageArchive(IPackageArchive)"/> method with a file which is in the
        ///     Packages list but not on disk.
        /// </summary>
        [Fact]
        public void FetchPackageArchiveFileNotFound()
        {
            byte[] data = File.ReadAllBytes(Path.Combine(Data, "package.zip"));

            PlatformMock.Setup(p => p.FileExists(It.IsAny<string>())).Returns(false);

            IPackageManager test = PackageManager.Instantiate(ManagerMock.Object, PlatformManagerMock.Object);

            IResult<byte[]> readResult = test.FetchPackageArchive(PackageArchiveMock.Object);

            Assert.Equal(ResultCode.Failure, readResult.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="PackageManager.FetchPackageArchive(IPackageArchive)"/> method with a Package Archive missing a FileName.
        /// </summary>
        [Fact]
        public void FetchPackageArchiveNoFileName()
        {
            IPackageManager test = PackageManager.Instantiate(ManagerMock.Object, PlatformManagerMock.Object);

            PackageArchiveMock.Setup(p => p.FileName).Returns(string.Empty);

            IResult<byte[]> readResult = test.FetchPackageArchive(PackageArchiveMock.Object);

            Assert.Equal(ResultCode.Failure, readResult.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="PackageManager.FetchPackageArchive(IPackageArchive)"/> method with a null Package Archive.
        /// </summary>
        [Fact]
        public void FetchPackageArchiveNull()
        {
            IPackageManager test = PackageManager.Instantiate(ManagerMock.Object, PlatformManagerMock.Object);

            IResult<byte[]> readResult = test.FetchPackageArchive(null);

            Assert.Equal(ResultCode.Failure, readResult.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="PackageManager.InstallPackage(IPackageArchive)"/> method with a known good Package and default options.
        /// </summary>
        [Fact]
        public void InstallPackage()
        {
            IResult<string> successResult = new Result<string>();

            byte[] data = File.ReadAllBytes(Path.Combine(Data, "package.zip"));

            PlatformMock.Setup(p => p.WriteFileBytes(It.IsAny<string>(), It.IsAny<byte[]>()))
                .Returns(successResult)
                    .Callback<string, byte[]>((f, b) => File.WriteAllBytes(f, b));

            PlatformMock.Setup(p => p.CopyFile(It.IsAny<string>(), It.IsAny<string>(), true))
                .Returns(successResult)
                    .Callback<string, string, bool>((s, d, o) => File.Copy(s, d, o));

            IPackageManager test = PackageManager.Instantiate(ManagerMock.Object, PlatformManagerMock.Object);
            IResult<IPackageArchive> package = test.AddPackageArchive(data);

            Assert.Equal(ResultCode.Success, package.ResultCode);
            Assert.True(File.Exists(Path.Combine(Temp, "OpenIIoT.Plugin.DefaultPlugin.1.0.0.zip")));

            IResult installResult = test.InstallPackage(package.ReturnValue);

            Assert.True(Directory.Exists(Path.Combine(Temp, "OpenIIoT.Plugin.DefaultPlugin")));
        }

        /// <summary>
        ///     Tests the <see cref="PackageManager.InstallPackageAsync(IPackageArchive)"/> method with a known good Package and
        ///     default options.
        /// </summary>
        /// <returns>The Task with which the execution is carried out.</returns>
        [Fact]
        public async Task InstallPackageAsync()
        {
            IResult<string> successResult = new Result<string>();

            byte[] data = File.ReadAllBytes(Path.Combine(Data, "package.zip"));

            PlatformMock.Setup(p => p.WriteFileBytes(It.IsAny<string>(), It.IsAny<byte[]>()))
                .Returns(successResult)
                    .Callback<string, byte[]>((f, b) => File.WriteAllBytes(f, b));

            PlatformMock.Setup(p => p.CopyFile(It.IsAny<string>(), It.IsAny<string>(), true))
                .Returns(successResult)
                    .Callback<string, string, bool>((s, d, o) => File.Copy(s, d, o));

            IPackageManager test = PackageManager.Instantiate(ManagerMock.Object, PlatformManagerMock.Object);
            IResult<IPackageArchive> package = test.AddPackageArchive(data);

            Assert.Equal(ResultCode.Success, package.ResultCode);
            Assert.True(File.Exists(Path.Combine(Temp, "OpenIIoT.Plugin.DefaultPlugin.1.0.0.zip")));

            IResult installResult = await test.InstallPackageAsync(package.ReturnValue);

            Assert.True(Directory.Exists(Path.Combine(Temp, "OpenIIoT.Plugin.DefaultPlugin")));
        }

        /// <summary>
        ///     Tests the <see cref="PackageManager.InstallPackageAsync(IPackageArchive)"/> method with a known good Package and
        ///     null/default options.
        /// </summary>
        /// <returns>The Task with which the execution is carried out.</returns>
        [Fact]
        public async Task InstallPackageAsyncWithNullOptions()
        {
            IResult<string> successResult = new Result<string>();

            byte[] data = File.ReadAllBytes(Path.Combine(Data, "package.zip"));

            PlatformMock.Setup(p => p.WriteFileBytes(It.IsAny<string>(), It.IsAny<byte[]>()))
                .Returns(successResult)
                    .Callback<string, byte[]>((f, b) => File.WriteAllBytes(f, b));

            PlatformMock.Setup(p => p.CopyFile(It.IsAny<string>(), It.IsAny<string>(), true))
                .Returns(successResult)
                    .Callback<string, string, bool>((s, d, o) => File.Copy(s, d, o));

            IPackageManager test = PackageManager.Instantiate(ManagerMock.Object, PlatformManagerMock.Object);
            IResult<IPackageArchive> package = test.AddPackageArchive(data);

            Assert.Equal(ResultCode.Success, package.ResultCode);
            Assert.True(File.Exists(Path.Combine(Temp, "OpenIIoT.Plugin.DefaultPlugin.1.0.0.zip")));

            IResult installResult = await test.InstallPackageAsync(package.ReturnValue, default(PackageInstallationOptions));

            Assert.Equal(ResultCode.Failure, installResult.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="PackageManager.InstallPackageAsync(IPackageArchive)"/> method with a known good Package and
        ///     blank options.
        /// </summary>
        /// <returns>The Task with which the execution is carried out.</returns>
        [Fact]
        public async Task InstallPackageAsyncWithOptions()
        {
            IResult<string> successResult = new Result<string>();

            byte[] data = File.ReadAllBytes(Path.Combine(Data, "package.zip"));

            PlatformMock.Setup(p => p.WriteFileBytes(It.IsAny<string>(), It.IsAny<byte[]>()))
                .Returns(successResult)
                    .Callback<string, byte[]>((f, b) => File.WriteAllBytes(f, b));

            PlatformMock.Setup(p => p.CopyFile(It.IsAny<string>(), It.IsAny<string>(), true))
                .Returns(successResult)
                    .Callback<string, string, bool>((s, d, o) => File.Copy(s, d, o));

            IPackageManager test = PackageManager.Instantiate(ManagerMock.Object, PlatformManagerMock.Object);
            IResult<IPackageArchive> package = test.AddPackageArchive(data);

            Assert.Equal(ResultCode.Success, package.ResultCode);
            Assert.True(File.Exists(Path.Combine(Temp, "OpenIIoT.Plugin.DefaultPlugin.1.0.0.zip")));

            IResult installResult = await test.InstallPackageAsync(package.ReturnValue, new PackageInstallationOptions());

            Assert.True(Directory.Exists(Path.Combine(Temp, "OpenIIoT.Plugin.DefaultPlugin")));
        }

        /// <summary>
        ///     Tests the <see cref="PackageManager.InstallPackage(IPackageArchive)"/> method with scenario known to raise an exception.
        /// </summary>
        [Fact]
        public void InstallPackageFailure()
        {
            IResult<string> successResult = new Result<string>();

            byte[] data = File.ReadAllBytes(Path.Combine(Data, "package.zip"));

            PlatformMock.Setup(p => p.WriteFileBytes(It.IsAny<string>(), It.IsAny<byte[]>()))
                .Returns(successResult)
                    .Callback<string, byte[]>((f, b) => File.WriteAllBytes(f, b));

            PlatformMock.Setup(p => p.CopyFile(It.IsAny<string>(), It.IsAny<string>(), true))
                .Returns(successResult)
                    .Callback<string, string, bool>((s, d, o) => File.Copy(s, d, o));

            IPackageManager test = PackageManager.Instantiate(ManagerMock.Object, PlatformManagerMock.Object);
            IResult<IPackageArchive> package = test.AddPackageArchive(data);

            Assert.Equal(ResultCode.Success, package.ResultCode);
            Assert.True(File.Exists(Path.Combine(Temp, "OpenIIoT.Plugin.DefaultPlugin.1.0.0.zip")));

            IResult installResult = test.InstallPackage(package.ReturnValue);

            Assert.True(Directory.Exists(Path.Combine(Temp, "OpenIIoT.Plugin.DefaultPlugin")));

            // force the underlying extractor to raise an exception because the destination exists and overwrite = false
            installResult = test.InstallPackage(package.ReturnValue, new PackageInstallationOptions() { Overwrite = false });

            Assert.Equal(ResultCode.Failure, installResult.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="PackageManager.InstallPackage(IPackageArchive)"/> method with a Package which does not exist
        ///     in the collection.
        /// </summary>
        [Fact]
        public void InstallPackageNotFound()
        {
            IResult<IList<string>> dirResult = new Result<IList<string>>();
            dirResult.ReturnValue = Directory.GetFiles(Data).ToList();

            PlatformMock.Setup(p => p.ListFiles(It.IsAny<string>())).Returns(dirResult);

            IPackageManager test = PackageManager.Instantiate(ManagerMock.Object, PlatformManagerMock.Object);
            IPackageArchive package = new PackageArchive(new FileInfo(Guid.NewGuid().ToString()), null);

            IResult installResult = test.InstallPackage(package);

            Assert.Equal(ResultCode.Failure, installResult.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="PackageManager.Instantiate(IApplicationManager, IPlatformManager)"/> method.
        /// </summary>
        [Fact]
        public void Instantiate()
        {
            ManagerMock.Setup(a => a.State).Returns(State.Running);
            ManagerMock.Setup(a => a.IsInState(State.Starting, State.Running)).Returns(true);

            IPackageManager test = PackageManager.Instantiate(ManagerMock.Object, PlatformManagerMock.Object);

            Assert.Equal(0, test.Packages.Count);
            Assert.Equal(0, test.PackageArchives.Count);
        }

        /// <summary>
        ///     Tests the <see cref="PackageManager.Instantiate(IApplicationManager, IPlatformManager)"/> method after having
        ///     already instantiated the Manager.
        /// </summary>
        [Fact]
        public void InstantiateAlreadyInstantiated()
        {
            ManagerMock.Setup(a => a.State).Returns(State.Running);
            ManagerMock.Setup(a => a.IsInState(State.Starting, State.Running)).Returns(true);

            IPackageManager test = PackageManager.Instantiate(ManagerMock.Object, PlatformManagerMock.Object);

            Assert.Equal(0, test.Packages.Count);

            IPackageManager test2 = PackageManager.Instantiate(ManagerMock.Object, PlatformManagerMock.Object);

            Assert.Equal(test, test2);
        }

        /// <summary>
        ///     Tests the <see cref="PackageManager.ScanPackageArchives()"/> method.
        /// </summary>
        [Fact]
        public void ScanPackageArchives()
        {
            IPackageManager test = PackageManager.Instantiate(ManagerMock.Object, PlatformManagerMock.Object);

            test.Inject("PackageFactory", PackageFactoryMock.Object);

            PackageScannerMock.Setup(s => s.ScanPackageArchives())
                .Returns(new Result<IList<IPackageArchive>>().SetReturnValue(new[] { PackageArchiveMock.Object }.ToList()));

            test.Inject("PackageScanner", PackageScannerMock.Object);

            IResult<IList<IPackageArchive>> list = test.ScanPackageArchives();

            Assert.Equal(ResultCode.Success, list.ResultCode);
            Assert.Equal(1, list.ReturnValue.Count);
            Assert.Equal(PackageArchiveMock.Object, list.ReturnValue[0]);
        }

        /// <summary>
        ///     Tests the <see cref="PackageManager.ScanPackagesAsync()"/> method.
        /// </summary>
        /// <returns>The Task with which the execution is carried out.</returns>
        [Fact]
        public async Task ScanPackageArchivesAsync()
        {
            IPackageManager test = PackageManager.Instantiate(ManagerMock.Object, PlatformManagerMock.Object);

            test.Inject("PackageFactory", PackageFactoryMock.Object);

            PackageScannerMock.Setup(s => s.ScanPackageArchives())
                .Returns(new Result<IList<IPackageArchive>>().SetReturnValue(new[] { PackageArchiveMock.Object }.ToList()));

            test.Inject("PackageScanner", PackageScannerMock.Object);

            IResult<IList<IPackageArchive>> list = await test.ScanPackageArchivesAsync();

            Assert.Equal(ResultCode.Success, list.ResultCode);
            Assert.Equal(1, list.ReturnValue.Count);
            Assert.Equal(PackageArchiveMock.Object, list.ReturnValue[0]);
        }

        /// <summary>
        ///     Tests the <see cref="PackageManager.ScanPackages()"/> method.
        /// </summary>
        [Fact]
        public void ScanPackages()
        {
            IPackageManager test = PackageManager.Instantiate(ManagerMock.Object, PlatformManagerMock.Object);

            test.Inject("PackageFactory", PackageFactoryMock.Object);

            PackageScannerMock.Setup(s => s.ScanPackages())
                .Returns(new Result<IList<IPackage>>().SetReturnValue(new[] { PackageMock.Object }.ToList()));

            test.Inject("PackageScanner", PackageScannerMock.Object);

            IResult<IList<IPackage>> list = test.ScanPackages();

            Assert.Equal(ResultCode.Success, list.ResultCode);
            Assert.Equal(1, list.ReturnValue.Count);
            Assert.Equal(PackageMock.Object, list.ReturnValue[0]);
        }

        /// <summary>
        ///     Tests the <see cref="PackageManager.ScanPackagesAsync()"/> method.
        /// </summary>
        /// <returns>The Task with which the execution is carried out.</returns>
        [Fact]
        public async Task ScanPackagesAsync()
        {
            IPackageManager test = PackageManager.Instantiate(ManagerMock.Object, PlatformManagerMock.Object);

            test.Inject("PackageFactory", PackageFactoryMock.Object);

            PackageScannerMock.Setup(s => s.ScanPackages())
                .Returns(new Result<IList<IPackage>>().SetReturnValue(new[] { PackageMock.Object }.ToList()));

            test.Inject("PackageScanner", PackageScannerMock.Object);

            IResult<IList<IPackage>> list = await test.ScanPackagesAsync();

            Assert.Equal(ResultCode.Success, list.ResultCode);
            Assert.Equal(1, list.ReturnValue.Count);
            Assert.Equal(PackageMock.Object, list.ReturnValue[0]);
        }

        /// <summary>
        ///     Tests the Setup method using reflection.
        /// </summary>
        [Fact]
        public void Setup()
        {
            ManagerMock.Setup(a => a.State).Returns(State.Running);
            ManagerMock.Setup(a => a.IsInState(State.Starting, State.Running)).Returns(true);

            IPackageManager test = PackageManager.Instantiate(ManagerMock.Object, PlatformManagerMock.Object);

            MethodInfo setup = typeof(PackageManager).GetMethod("Setup", BindingFlags.NonPublic | BindingFlags.Instance);
            setup.Invoke(test, new object[] { });
        }

        /// <summary>
        ///     Tests the <see cref="PackageManager.Startup()"/> method via <see cref="Core.Common.Manager.Start()"/> .
        /// </summary>
        [Fact]
        public void Start()
        {
            IResult<IList<string>> fileResult = new Result<IList<string>>();
            fileResult.ReturnValue = Directory.GetFiles(Data).ToList();

            IResult<IList<string>> dirResult = new Result<IList<string>>();
            dirResult.ReturnValue = Directory.GetDirectories(Data).ToList();

            PlatformMock.Setup(p => p.ListFiles(It.IsAny<string>())).Returns(fileResult);
            PlatformMock.Setup(p => p.ListDirectories(It.IsAny<string>(), It.IsAny<string>())).Returns(dirResult);

            PlatformManagerMock.Setup(p => p.State).Returns(State.Running);
            PlatformManagerMock.Setup(p => p.IsInState(State.Starting, State.Running)).Returns(true);

            ManagerMock.Setup(a => a.State).Returns(State.Running);
            ManagerMock.Setup(a => a.IsInState(State.Starting, State.Running)).Returns(true);

            IPackageManager test = PackageManager.Instantiate(ManagerMock.Object, PlatformManagerMock.Object);

            IResult result = test.Start();

            Assert.NotEqual(ResultCode.Failure, result.ResultCode);
            Assert.Equal(State.Running, test.State);
        }

        /// <summary>
        ///     Tests the <see cref="PackageManager.Shutdown(StopType)"/> method via
        ///     <see cref="Core.Common.Manager.Stop(StopType)"/> .
        /// </summary>
        [Fact]
        public void Stop()
        {
            IResult<IList<string>> fileResult = new Result<IList<string>>();
            fileResult.ReturnValue = Directory.GetFiles(Data).ToList();

            IResult<IList<string>> dirResult = new Result<IList<string>>();
            dirResult.ReturnValue = Directory.GetDirectories(Data).ToList();

            PlatformMock.Setup(p => p.ListFiles(It.IsAny<string>())).Returns(fileResult);
            PlatformMock.Setup(p => p.ListDirectories(It.IsAny<string>(), It.IsAny<string>())).Returns(dirResult);

            PlatformManagerMock.Setup(p => p.State).Returns(State.Running);
            PlatformManagerMock.Setup(p => p.IsInState(State.Starting, State.Running)).Returns(true);

            ManagerMock.Setup(a => a.State).Returns(State.Running);
            ManagerMock.Setup(a => a.IsInState(State.Starting, State.Running)).Returns(true);

            IPackageManager test = PackageManager.Instantiate(ManagerMock.Object, PlatformManagerMock.Object);

            IResult result = test.Start();

            Assert.NotEqual(ResultCode.Failure, result.ResultCode);
            Assert.Equal(State.Running, test.State);

            result = test.Stop();

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal(State.Stopped, test.State);
        }

        /// <summary>
        ///     Tests the <see cref="PackageManager.Terminate()"/> method.
        /// </summary>
        [Fact]
        public void Terminate()
        {
            PackageManager.Terminate();
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        ///     Disposes of this instance.
        /// </summary>
        /// <param name="disposing">A value indicating whether this method has been called directly or indirectly from code.</param>
        protected virtual void Dispose(bool disposing)
        {
            Directory.Delete(Temp, true);

            PackageManager.Terminate();
        }

        #endregion Protected Methods

        #region Private Methods

        private void SetupMocks()
        {
            DirectoryMock.Setup(d => d.Packages).Returns(Temp);
            DirectoryMock.Setup(d => d.PackageArchives).Returns(Temp);
            DirectoryMock.Setup(d => d.Temp).Returns(Temp);
            DirectoryMock.Setup(d => d.Plugins).Returns(Temp);

            IResult<string> successResult = new Result<string>();

            PlatformMock.Setup(p => p.WriteFileBytes(It.IsAny<string>(), It.IsAny<byte[]>()))
                .Returns(successResult)
                    .Callback<string, byte[]>((f, b) => File.WriteAllBytes(f, b));

            PlatformMock.Setup(p => p.CopyFile(It.IsAny<string>(), It.IsAny<string>(), true))
                .Returns(successResult)
                    .Callback<string, string, bool>((s, d, o) => File.Copy(s, d, o));

            PlatformMock.Setup(p => p.DeleteFile(It.IsAny<string>()))
                .Returns(successResult)
                    .Callback<string>(s => File.Delete(s));

            PlatformMock.Setup(p => p.FileExists(It.IsAny<string>()))
                .Returns(true);

            PlatformManagerMock.Setup(p => p.Directories).Returns(DirectoryMock.Object);
            PlatformManagerMock.Setup(p => p.Platform).Returns(PlatformMock.Object);

            PackageManifestMock.Setup(p => p.Namespace).Returns("OpenIIoT.Plugin");
            PackageManifestMock.Setup(p => p.Title).Returns("DefaultPlugin");
            PackageManifestMock.Setup(p => p.Version).Returns("1.0.0");

            PackageArchiveMock.Setup(p => p.FQN).Returns("OpenIIoT.Plugin.DefaultPlugin");
            PackageArchiveMock.Setup(p => p.FileName).Returns(Path.Combine(Temp, "OpenIIoT.Plugin.DefaultPlugin.1.0.0.zip"));
            PackageArchiveMock.Setup(p => p.Manifest).Returns(PackageManifestMock.Object);

            PackageMock.Setup(p => p.FQN).Returns("OpenIIoT.Plugin.DefaultPlugin");
            PackageMock.Setup(p => p.DirectoryName).Returns(Path.Combine(Temp, "OpenIIoT.Plugin.DefaultPlugin"));
            PackageMock.Setup(p => p.Manifest).Returns(PackageManifestMock.Object);

            PackageFactoryMock.Setup(p => p.GetPackageArchive(It.IsAny<string>()))
                .Returns(new Result<IPackageArchive>().SetReturnValue(PackageArchiveMock.Object));

            PackageScannerMock.Setup(p => p.ScanPackageArchives())
                .Returns(new Result<IList<IPackageArchive>>().SetReturnValue(new[] { PackageArchiveMock.Object }.ToList()));

            PackageScannerMock.Setup(s => s.ScanPackages())
                .Returns(new Result<IList<IPackage>>().SetReturnValue(new[] { PackageMock.Object }.ToList()));
        }

        #endregion Private Methods

        /// <summary>
        ///     Tests the <see cref="PackageManager.FindPackage(string)"/> method with a known existing Package.
        /// </summary>
        [Fact]
        public void FindPackage()
        {
            IPackageManager test = PackageManager.Instantiate(ManagerMock.Object, PlatformManagerMock.Object);

            IList<IPackage> list = new List<IPackage>(new[] { PackageMock.Object }.ToList());
            test.Inject("PackageList", list);

            IPackage foundPackage = test.FindPackage(PackageMock.Object.FQN);

            Assert.Equal(PackageMock.Object, foundPackage);
        }

        /// <summary>
        ///     Tests the <see cref="PackageManager.FindPackageArchive(string)"/> method with a known existing Package Archive.
        /// </summary>
        [Fact]
        public void FindPackageArchive()
        {
            IPackageManager test = PackageManager.Instantiate(ManagerMock.Object, PlatformManagerMock.Object);

            IList<IPackageArchive> list = new List<IPackageArchive>(new[] { PackageArchiveMock.Object }.ToList());
            test.Inject("PackageArchiveList", list);

            IPackageArchive foundPackage = test.FindPackageArchive(PackageArchiveMock.Object.FQN);

            Assert.Equal(PackageArchiveMock.Object, foundPackage);
        }

        /// <summary>
        ///     Tests the <see cref="PackageManager.FindPackageArchiveAsync(string)"/> method with a known existing Package Archive.
        /// </summary>
        [Fact]
        public async void FindPackageArchiveAsync()
        {
            IPackageManager test = PackageManager.Instantiate(ManagerMock.Object, PlatformManagerMock.Object);

            IList<IPackageArchive> list = new List<IPackageArchive>(new[] { PackageArchiveMock.Object }.ToList());
            test.Inject("PackageArchiveList", list);

            IPackageArchive foundPackage = await test.FindPackageArchiveAsync(PackageArchiveMock.Object.FQN);

            Assert.Equal(PackageArchiveMock.Object, foundPackage);
        }

        /// <summary>
        ///     Tests the <see cref="PackageManager.FindPackageArchive(string)"/> method with a known missing Package Archive that
        ///     is not found upon a scan.
        /// </summary>
        [Fact]
        public void FindPackageArchiveNotFound()
        {
            IPackageManager test = PackageManager.Instantiate(ManagerMock.Object, PlatformManagerMock.Object);

            PackageScannerMock.Setup(p => p.ScanPackageArchives())
                .Returns(new Result<IList<IPackageArchive>>().SetReturnValue(new List<IPackageArchive>()));

            test.Inject("PackageFactory", PackageFactoryMock.Object);
            test.Inject("PackageScanner", PackageScannerMock.Object);

            IPackageArchive foundPackage = test.FindPackageArchive(PackageArchiveMock.Object.FQN);

            Assert.Equal(default(IPackageArchive), foundPackage);
        }

        /// <summary>
        ///     Tests the <see cref="PackageManager.FindPackageArchive(string)"/> method with a known missing Package Archive that
        ///     is found upon a scan.
        /// </summary>
        [Fact]
        public void FindPackageArchiveScanned()
        {
            IPackageManager test = PackageManager.Instantiate(ManagerMock.Object, PlatformManagerMock.Object);

            test.Inject("PackageFactory", PackageFactoryMock.Object);
            test.Inject("PackageScanner", PackageScannerMock.Object);

            IPackageArchive foundPackage = test.FindPackageArchive(PackageArchiveMock.Object.FQN);

            Assert.Equal(PackageArchiveMock.Object, foundPackage);
        }

        /// <summary>
        ///     Tests the <see cref="PackageManager.FindPackageAsync(string)"/> method with a known existing Package.
        /// </summary>
        [Fact]
        public async void FindPackageAsync()
        {
            IPackageManager test = PackageManager.Instantiate(ManagerMock.Object, PlatformManagerMock.Object);

            IList<IPackage> list = new List<IPackage>(new[] { PackageMock.Object }.ToList());
            test.Inject("PackageList", list);

            IPackage foundPackage = await test.FindPackageAsync(PackageMock.Object.FQN);

            Assert.Equal(PackageMock.Object, foundPackage);
        }

        /// <summary>
        ///     Tests the <see cref="PackageManager.FindPackage(string)"/> method with a known missing Package that is not found
        ///     upon a scan.
        /// </summary>
        [Fact]
        public void FindPackageNotFound()
        {
            IPackageManager test = PackageManager.Instantiate(ManagerMock.Object, PlatformManagerMock.Object);

            PackageScannerMock.Setup(p => p.ScanPackages())
                .Returns(new Result<IList<IPackage>>().SetReturnValue(new List<IPackage>()));

            test.Inject("PackageFactory", PackageFactoryMock.Object);
            test.Inject("PackageScanner", PackageScannerMock.Object);

            IPackage foundPackage = test.FindPackage(PackageMock.Object.FQN);

            Assert.Equal(default(IPackage), foundPackage);
        }

        /// <summary>
        ///     Tests the <see cref="PackageManager.FindPackage(string)"/> method with a known missing Package that is found upon a scan.
        /// </summary>
        [Fact]
        public void FindPackageScanned()
        {
            IPackageManager test = PackageManager.Instantiate(ManagerMock.Object, PlatformManagerMock.Object);

            test.Inject("PackageFactory", PackageFactoryMock.Object);
            test.Inject("PackageScanner", PackageScannerMock.Object);

            IPackage foundPackage = test.FindPackage(PackageMock.Object.FQN);

            Assert.Equal(PackageMock.Object, foundPackage);
        }

        ///// <summary>
        /////     Tests the <see cref="PackageManager.VerifyPackage(string)"/> method with a known good Package.
        ///// </summary>
        //[Fact]
        //public void VerifyPackage()
        //{
        //    IResult<string> successResult = new Result<string>();

        // byte[] data = File.ReadAllBytes(Path.Combine(Data, "package.zip"));

        // DirectoryMock.Setup(d => d.Packages).Returns(Temp); DirectoryMock.Setup(d => d.Temp).Returns(Temp);

        // PlatformMock.Setup(p => p.WriteFileBytes(It.IsAny<string>(), It.IsAny<byte[]>())) .Returns(successResult)
        // .Callback<string, byte[]>((f, b) => File.WriteAllBytes(f, b));

        // PlatformMock.Setup(p => p.CopyFile(It.IsAny<string>(), It.IsAny<string>(), true)) .Returns(successResult)
        // .Callback<string, string, bool>((s, d, o) => File.Copy(s, d, o));

        // PlatformManagerMock.Setup(p => p.Directories).Returns(DirectoryMock.Object); PlatformManagerMock.Setup(p => p.Platform).Returns(PlatformMock.Object);

        // IPackageManager test = PackageManager.Instantiate(ManagerMock.Object, PlatformManagerMock.Object);
        // IResult<IPackageArchive> package = test.AddPackageArchive(data);

        // Assert.Equal(ResultCode.Success, package.ResultCode); Assert.True(File.Exists(Path.Combine(Temp, "OpenIIoT.Plugin.DefaultPlugin.1.0.0.zip")));

        // IResult<bool> verifyResult = test.VerifyPackage(package.ReturnValue.FQN);

        //    Assert.Equal(ResultCode.Success, verifyResult.ResultCode);
        //    Assert.True(verifyResult.ReturnValue);
        //}

        ///// <summary>
        /////     Tests the <see cref="PackageManager.VerifyPackageAsync(string)"/> method with a known good Package.
        ///// </summary>
        ///// <returns>The Task with which the execution is carried out.</returns>
        //[Fact]
        //public async Task VerifyPackageAsync()
        //{
        //    IResult<string> successResult = new Result<string>();

        // byte[] data = File.ReadAllBytes(Path.Combine(Data, "package.zip"));

        // DirectoryMock.Setup(d => d.Packages).Returns(Temp); DirectoryMock.Setup(d => d.Temp).Returns(Temp);

        // PlatformMock.Setup(p => p.WriteFileBytes(It.IsAny<string>(), It.IsAny<byte[]>())) .Returns(successResult)
        // .Callback<string, byte[]>((f, b) => File.WriteAllBytes(f, b));

        // PlatformMock.Setup(p => p.CopyFile(It.IsAny<string>(), It.IsAny<string>(), true)) .Returns(successResult)
        // .Callback<string, string, bool>((s, d, o) => File.Copy(s, d, o));

        // PlatformManagerMock.Setup(p => p.Directories).Returns(DirectoryMock.Object); PlatformManagerMock.Setup(p => p.Platform).Returns(PlatformMock.Object);

        // IPackageManager test = PackageManager.Instantiate(ManagerMock.Object, PlatformManagerMock.Object);
        // IResult<IPackageArchive> package = test.AddPackageArchive(data);

        // Assert.Equal(ResultCode.Success, package.ResultCode); Assert.True(File.Exists(Path.Combine(Temp, "OpenIIoT.Plugin.DefaultPlugin.1.0.0.zip")));

        // IResult<bool> verifyResult = await test.VerifyPackageAsync(package.ReturnValue.FQN);

        //    Assert.Equal(ResultCode.Success, verifyResult.ResultCode);
        //    Assert.True(verifyResult.ReturnValue);
        //}

        ///// <summary>
        /////     Tests the <see cref="PackageManager.VerifyPackageAsync(string)"/> method with a known good Package and an explicit
        /////     PGP public key.
        ///// </summary>
        ///// <returns>The Task with which the execution is carried out.</returns>
        //[Fact]
        //public async Task VerifyPackageAsyncExplicitKey()
        //{
        //    IResult<string> successResult = new Result<string>();

        // byte[] data = File.ReadAllBytes(Path.Combine(Data, "package.zip")); string key = File.ReadAllText(Path.Combine(DataRoot,
        // "Key", "public.asc"));

        // DirectoryMock.Setup(d => d.Packages).Returns(Temp); DirectoryMock.Setup(d => d.Temp).Returns(Temp);

        // PlatformMock.Setup(p => p.WriteFileBytes(It.IsAny<string>(), It.IsAny<byte[]>())) .Returns(successResult)
        // .Callback<string, byte[]>((f, b) => File.WriteAllBytes(f, b));

        // PlatformMock.Setup(p => p.CopyFile(It.IsAny<string>(), It.IsAny<string>(), true)) .Returns(successResult)
        // .Callback<string, string, bool>((s, d, o) => File.Copy(s, d, o));

        // PlatformManagerMock.Setup(p => p.Directories).Returns(DirectoryMock.Object); PlatformManagerMock.Setup(p => p.Platform).Returns(PlatformMock.Object);

        // IPackageManager test = PackageManager.Instantiate(ManagerMock.Object, PlatformManagerMock.Object);
        // IResult<IPackageArchive> package = test.AddPackageArchive(data);

        // Assert.Equal(ResultCode.Success, package.ResultCode); Assert.True(File.Exists(Path.Combine(Temp, "OpenIIoT.Plugin.DefaultPlugin.1.0.0.zip")));

        // IResult<bool> verifyResult = await test.VerifyPackageAsync(package.ReturnValue.FQN, key);

        //    Assert.Equal(ResultCode.Success, verifyResult.ResultCode);
        //    Assert.True(verifyResult.ReturnValue);
        //}

        ///// <summary>
        /////     Tests the <see cref="PackageManager.VerifyPackage(string)"/> method with a Package FQN which is not in the Package list.
        ///// </summary>
        //[Fact]
        //public void VerifyPackageNotFound()
        //{
        //    IResult<IList<string>> dirResult = new Result<IList<string>>();
        //    dirResult.ReturnValue = new List<string>();

        // DirectoryMock.Setup(d => d.Packages).Returns(Temp); DirectoryMock.Setup(d => d.Temp).Returns(Temp);

        // PlatformMock.Setup(p => p.ListFiles(It.IsAny<string>())).Returns(dirResult);

        // PlatformManagerMock.Setup(p => p.Directories).Returns(DirectoryMock.Object); PlatformManagerMock.Setup(p => p.Platform).Returns(PlatformMock.Object);

        // IPackageManager test = PackageManager.Instantiate(ManagerMock.Object, PlatformManagerMock.Object);

        // IResult<bool> verifyResult = test.VerifyPackage("test");

        //    Assert.Equal(ResultCode.Failure, verifyResult.ResultCode);
        //    Assert.False(verifyResult.ReturnValue);
        //}

        ///// <summary>
        /////     Tests the <see cref="PackageManager.VerifyPackage(string)"/> method with a known good, signed Package.
        ///// </summary>
        //[Fact]
        //public void VerifySignedPackage()
        //{
        //    IResult<string> successResult = new Result<string>();

        // byte[] data = File.ReadAllBytes(Path.Combine(Data, "signedpackage.zip"));

        // DirectoryMock.Setup(d => d.Packages).Returns(Temp); DirectoryMock.Setup(d => d.Temp).Returns(Temp);

        // PlatformMock.Setup(p => p.WriteFileBytes(It.IsAny<string>(), It.IsAny<byte[]>())) .Returns(successResult)
        // .Callback<string, byte[]>((f, b) => File.WriteAllBytes(f, b));

        // PlatformMock.Setup(p => p.CopyFile(It.IsAny<string>(), It.IsAny<string>(), true)) .Returns(successResult)
        // .Callback<string, string, bool>((s, d, o) => File.Copy(s, d, o));

        // PlatformManagerMock.Setup(p => p.Directories).Returns(DirectoryMock.Object); PlatformManagerMock.Setup(p => p.Platform).Returns(PlatformMock.Object);

        // IPackageManager test = PackageManager.Instantiate(ManagerMock.Object, PlatformManagerMock.Object);
        // IResult<IPackageArchive> package = test.AddPackageArchive(data);

        // Assert.Equal(ResultCode.Success, package.ResultCode); Assert.True(File.Exists(Path.Combine(Temp, "OpenIIoT.Plugin.DefaultPlugin.1.0.0.zip")));

        // IResult<bool> verifyResult = test.VerifyPackage(package.ReturnValue.FQN);

        //    Assert.Equal(ResultCode.Success, verifyResult.ResultCode);
        //    Assert.True(verifyResult.ReturnValue);
        //}

        ///// <summary>
        /////     Tests the <see cref="PackageManager.VerifyPackage(string, string)"/> method with a known good, signed Package and a
        /////     bad PGP public key.
        ///// </summary>
        //[Fact]
        //public void VerifySignedPackageBadExplicitKey()
        //{
        //    IResult<string> successResult = new Result<string>();

        // byte[] data = File.ReadAllBytes(Path.Combine(Data, "signedpackage.zip")); string key = "test";

        // DirectoryMock.Setup(d => d.Packages).Returns(Temp); DirectoryMock.Setup(d => d.Temp).Returns(Temp);

        // PlatformMock.Setup(p => p.WriteFileBytes(It.IsAny<string>(), It.IsAny<byte[]>())) .Returns(successResult)
        // .Callback<string, byte[]>((f, b) => File.WriteAllBytes(f, b));

        // PlatformMock.Setup(p => p.CopyFile(It.IsAny<string>(), It.IsAny<string>(), true)) .Returns(successResult)
        // .Callback<string, string, bool>((s, d, o) => File.Copy(s, d, o));

        // PlatformManagerMock.Setup(p => p.Directories).Returns(DirectoryMock.Object); PlatformManagerMock.Setup(p => p.Platform).Returns(PlatformMock.Object);

        // IPackageManager test = PackageManager.Instantiate(ManagerMock.Object, PlatformManagerMock.Object);
        // IResult<IPackageArchive> package = test.AddPackageArchive(data);

        // Assert.Equal(ResultCode.Success, package.ResultCode); Assert.True(File.Exists(Path.Combine(Temp, "OpenIIoT.Plugin.DefaultPlugin.1.0.0.zip")));

        // IResult<bool> verifyResult = test.VerifyPackage(package.ReturnValue.FQN, key);

        //    Assert.Equal(ResultCode.Failure, verifyResult.ResultCode);
        //    Assert.False(verifyResult.ReturnValue);
        //}

        ///// <summary>
        /////     Tests the <see cref="PackageManager.VerifyPackage(string, string)"/> method with a known good, signed Package and
        /////     an explicit, known good PGP public key.
        ///// </summary>
        //[Fact]
        //public void VerifySignedPackageExplicitKey()
        //{
        //    IResult<string> successResult = new Result<string>();

        // byte[] data = File.ReadAllBytes(Path.Combine(Data, "signedpackage.zip")); string key =
        // File.ReadAllText(Path.Combine(DataRoot, "Key", "public.asc"));

        // DirectoryMock.Setup(d => d.Packages).Returns(Temp); DirectoryMock.Setup(d => d.Temp).Returns(Temp);

        // PlatformMock.Setup(p => p.WriteFileBytes(It.IsAny<string>(), It.IsAny<byte[]>())) .Returns(successResult)
        // .Callback<string, byte[]>((f, b) => File.WriteAllBytes(f, b));

        // PlatformMock.Setup(p => p.CopyFile(It.IsAny<string>(), It.IsAny<string>(), true)) .Returns(successResult)
        // .Callback<string, string, bool>((s, d, o) => File.Copy(s, d, o));

        // PlatformManagerMock.Setup(p => p.Directories).Returns(DirectoryMock.Object); PlatformManagerMock.Setup(p => p.Platform).Returns(PlatformMock.Object);

        // IPackageManager test = PackageManager.Instantiate(ManagerMock.Object, PlatformManagerMock.Object);
        // IResult<IPackageArchive> package = test.AddPackageArchive(data);

        // Assert.Equal(ResultCode.Success, package.ResultCode); Assert.True(File.Exists(Path.Combine(Temp, "OpenIIoT.Plugin.DefaultPlugin.1.0.0.zip")));

        // IResult<bool> verifyResult = test.VerifyPackage(package.ReturnValue.FQN, key);

        //    Assert.Equal(ResultCode.Success, verifyResult.ResultCode);
        //    Assert.True(verifyResult.ReturnValue);
        //}
    }
}