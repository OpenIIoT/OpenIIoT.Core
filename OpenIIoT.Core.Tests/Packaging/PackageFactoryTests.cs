/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄███████▄                                                                 ▄████████
      █     ███    ███                                                                ███    ███
      █     ███    ███   ▄█████   ▄██████    █  █▄     ▄█████     ▄████▄     ▄█████   ███    █▀    ▄█████   ▄██████     ██     ██████     █████ ▄█   ▄
      █     ███    ███   ██   ██ ██    ██   ██ ▄██▀    ██   ██   ██    ▀    ██   █   ▄███▄▄▄       ██   ██ ██    ██ ▀███████▄ ██    ██   ██  ██ ██   █▄
      █   ▀█████████▀    ██   ██ ██    ▀    ██▐█▀      ██   ██  ▄██        ▄██▄▄    ▀▀███▀▀▀       ██   ██ ██    ▀      ██  ▀ ██    ██  ▄██▄▄█▀ ▀▀▀▀▀██
      █     ███        ▀████████ ██    ▄  ▀▀████     ▀████████ ▀▀██ ███▄  ▀▀██▀▀      ███        ▀████████ ██    ▄      ██    ██    ██ ▀███████ ▄█   ██
      █     ███          ██   ██ ██    ██   ██ ▀██▄    ██   ██   ██    ██   ██   █    ███          ██   ██ ██    ██     ██    ██    ██   ██  ██ ██   ██
      █    ▄████▀        ██   █▀ ██████▀    ▀█   ▀█▀   ██   █▀   ██████▀    ███████   ███          ██   █▀ ██████▀     ▄██▀    ██████    ██  ██  █████
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
      █  Unit tests for the PackageFactory class.
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
    using System.IO;
    using Moq;
    using Newtonsoft.Json;
    using OpenIIoT.Core.Packaging;
    using OpenIIoT.SDK.Common.OperationResult;
    using OpenIIoT.SDK.Packaging;
    using OpenIIoT.SDK.Packaging.Manifest;
    using OpenIIoT.SDK.Packaging.Operations;
    using OpenIIoT.SDK.Platform;
    using Xunit;

    /// <summary>
    ///     Unit tests for the <see cref="PackageFactory"/> class.
    /// </summary>
    public class PackageFactoryTests : IDisposable
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PackageFactoryTests"/> class.
        /// </summary>
        public PackageFactoryTests()
        {
            TempDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(TempDirectory);

            TempFile = Path.Combine(TempDirectory, "archive.zip");
            File.WriteAllText(TempFile, string.Empty);

            PackageManifest = new PackageManifestBuilder().BuildDefault().Manifest;

            ManifestExtractorMock = new Mock<IManifestExtractor>();
            PackageVerifierMock = new Mock<IPackageVerifier>();
            PlatformMock = new Mock<IPlatform>();
            PlatformManagerMock = new Mock<IPlatformManager>();
            PackageMock = new Mock<IPackage>();
            PackageArchiveMock = new Mock<IPackageArchive>();

            SetupMocks();
        }

        #endregion Public Constructors

        #region Private Properties

        /// <summary>
        ///     Gets or sets the IManifestExtractor mockup.
        /// </summary>
        private Mock<IManifestExtractor> ManifestExtractorMock { get; set; }

        /// <summary>
        ///     Gets or sets the IPackageArchive mockup.
        /// </summary>
        private Mock<IPackageArchive> PackageArchiveMock { get; set; }

        /// <summary>
        ///     Gets or sets the IPackageManifest instance.
        /// </summary>
        private IPackageManifest PackageManifest { get; set; }

        /// <summary>
        ///     Gets or sets the IPackage mockup.
        /// </summary>
        private Mock<IPackage> PackageMock { get; set; }

        /// <summary>
        ///     Gets or sets the IPackageVerifier mockup.
        /// </summary>
        private Mock<IPackageVerifier> PackageVerifierMock { get; set; }

        /// <summary>
        ///     Gets or sets the IPlatformManager mockup.
        /// </summary>
        private Mock<IPlatformManager> PlatformManagerMock { get; set; }

        /// <summary>
        ///     Gets or sets the IPlatform mockup.
        /// </summary>
        private Mock<IPlatform> PlatformMock { get; set; }

        /// <summary>
        ///     Gets or sets the temporary directory.
        /// </summary>
        private string TempDirectory { get; set; }

        /// <summary>
        ///     Gets or sets the temporary archive file.
        /// </summary>
        private string TempFile { get; set; }

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        ///     Tests the constructor and all properties.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            PackageFactory test;

            Exception ex = Record.Exception(() => test = new PackageFactory(PlatformManagerMock.Object, ManifestExtractorMock.Object, PackageVerifierMock.Object));

            Assert.Null(ex);
        }

        /// <summary>
        ///     Disposes this instance.
        /// </summary>
        public void Dispose()
        {
            Directory.Delete(TempDirectory, true);
        }

        /// <summary>
        ///     Tests the <see cref="PackageFactory.GetPackage(string)"/> method.
        /// </summary>
        [Fact]
        public void GetPackage()
        {
            PackageFactory test = new PackageFactory(PlatformManagerMock.Object, ManifestExtractorMock.Object, PackageVerifierMock.Object);

            IResult<IPackage> result = test.GetPackage(TempDirectory);

            string fqn = PackageManifest.Namespace + "." + PackageManifest.Name;

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal(TempDirectory, result.ReturnValue.DirectoryName);
            Assert.Equal(fqn, result.ReturnValue.FQN);
            Assert.Equal(PackageManifest.Name, result.ReturnValue.Manifest.Name);
            Assert.Equal(PackageManifest.Namespace, result.ReturnValue.Manifest.Namespace);
        }

        /// <summary>
        ///     Tests the <see cref="PackageFactory.GetPackageArchive(string)"/> method.
        /// </summary>
        [Fact]
        public void GetPackageArchive()
        {
            PackageFactory test = new PackageFactory(PlatformManagerMock.Object, ManifestExtractorMock.Object, PackageVerifierMock.Object);

            IResult<IPackageArchive> result = test.GetPackageArchive(Guid.NewGuid().ToString());

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal(PackageManifest.Name, result.ReturnValue.Manifest.Name);
            Assert.Equal(PackageManifest.Namespace, result.ReturnValue.Manifest.Namespace);
        }

        /// <summary>
        ///     Tests the <see cref="PackageFactory.GetPackageArchive(string)"/> method with a simulated exception within the ManifestExtractor.
        /// </summary>
        [Fact]
        public void GetPackageArchiveFailedExtraction()
        {
            ManifestExtractorMock.Setup(m => m.ExtractManifest(It.IsAny<string>(), It.IsAny<string>()))
                .Throws(new Exception());

            PackageFactory test = new PackageFactory(PlatformManagerMock.Object, ManifestExtractorMock.Object, PackageVerifierMock.Object);

            IResult<IPackageArchive> result = test.GetPackageArchive(Guid.NewGuid().ToString());

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="PackageFactory.GetPackageArchive(string)"/> method with with a PackageArchive which does not
        ///     pass verification.
        /// </summary>
        [Fact]
        public void GetPackageArchiveRefuted()
        {
            PackageVerifierMock.Setup(p => p.VerifyPackage(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(false);

            PackageFactory test = new PackageFactory(PlatformManagerMock.Object, ManifestExtractorMock.Object, PackageVerifierMock.Object);

            IResult<IPackageArchive> result = test.GetPackageArchive(Guid.NewGuid().ToString());

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal(PackageVerification.Refuted, result.ReturnValue.Verification);
            Assert.Equal(PackageManifest.Name, result.ReturnValue.Manifest.Name);
            Assert.Equal(PackageManifest.Namespace, result.ReturnValue.Manifest.Namespace);
        }

        /// <summary>
        ///     Tests the <see cref="PackageFactory.GetPackageArchive(string)"/> method with a simulated exception within the PackageVerifier.
        /// </summary>
        [Fact]
        public void GetPackageArchiveVerificationFailed()
        {
            PackageVerifierMock.Setup(p => p.VerifyPackage(It.IsAny<string>(), It.IsAny<string>()))
                .Throws(new Exception());

            PackageFactory test = new PackageFactory(PlatformManagerMock.Object, ManifestExtractorMock.Object, PackageVerifierMock.Object);

            IResult<IPackageArchive> result = test.GetPackageArchive(Guid.NewGuid().ToString());

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal(PackageVerification.Refuted, result.ReturnValue.Verification);
            Assert.Equal(PackageManifest.Name, result.ReturnValue.Manifest.Name);
            Assert.Equal(PackageManifest.Namespace, result.ReturnValue.Manifest.Namespace);
        }

        /// <summary>
        ///     Tests the <see cref="PackageFactory.GetPackageArchive(string)"/> method with a PackageArchive which passes verification.
        /// </summary>
        [Fact]
        public void GetPackageArchiveVerified()
        {
            PackageVerifierMock.Setup(p => p.VerifyPackage(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);

            PackageFactory test = new PackageFactory(PlatformManagerMock.Object, ManifestExtractorMock.Object, PackageVerifierMock.Object);

            IResult<IPackageArchive> result = test.GetPackageArchive(Guid.NewGuid().ToString());

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal(PackageVerification.Verified, result.ReturnValue.Verification);
            Assert.Equal(PackageManifest.Name, result.ReturnValue.Manifest.Name);
            Assert.Equal(PackageManifest.Namespace, result.ReturnValue.Manifest.Namespace);
        }

        /// <summary>
        ///     Tests the <see cref="PackageFactory.GetPackage(string)"/> method with a known bad .manifest.json file.
        /// </summary>
        [Fact]
        public void GetPackageBadManifest()
        {
            PlatformMock.Setup(p => p.ReadFileText(It.IsAny<string>()))
                .Returns(new Result<string>().SetReturnValue("{"));

            PackageFactory test = new PackageFactory(PlatformManagerMock.Object, ManifestExtractorMock.Object, PackageVerifierMock.Object);

            IResult<IPackage> result = test.GetPackage(TempDirectory);

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="PackageFactory.GetPackage(string)"/> method with a failing file read.
        /// </summary>
        [Fact]
        public void GetPackageFailedManifestRead()
        {
            PlatformMock.Setup(p => p.ReadFileText(It.IsAny<string>()))
                .Returns(new Result<string>(ResultCode.Failure));

            PackageFactory test = new PackageFactory(PlatformManagerMock.Object, ManifestExtractorMock.Object, PackageVerifierMock.Object);

            IResult<IPackage> result = test.GetPackage(TempDirectory);

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        ///     Configures the mockups for the unit tests.
        /// </summary>
        private void SetupMocks()
        {
            string manifestString = JsonConvert.SerializeObject(PackageManifest);

            PlatformMock.Setup(p => p.ReadFileText(It.IsAny<string>()))
                .Returns(new Result<string>().SetReturnValue(manifestString));

            PlatformManagerMock.Setup(p => p.Platform).Returns(PlatformMock.Object);

            PackageMock.Setup(p => p.Manifest).Returns(PackageManifest);

            ManifestExtractorMock.Setup(m => m.ExtractManifest(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(PackageManifest);
        }

        #endregion Private Methods
    }
}