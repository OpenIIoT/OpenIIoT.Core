/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄███████▄                                                                           ▄████████
      █     ███    ███                                                                           ███    ███
      █     ███    ███   ▄█████   ▄██████    █  █▄     ▄█████     ▄████▄   █  ██▄▄▄▄     ▄████▄  ███    █▀   ██████  ██▄▄▄▄      ██       █████  ██████   █        █          ▄█████    █████
      █     ███    ███   ██   ██ ██    ██   ██ ▄██▀    ██   ██   ██    ▀  ██  ██▀▀▀█▄   ██    ▀  ███        ██    ██ ██▀▀▀█▄ ▀███████▄   ██  ██ ██    ██ ██       ██         ██   █    ██  ██
      █   ▀█████████▀    ██   ██ ██    ▀    ██▐█▀      ██   ██  ▄██       ██▌ ██   ██  ▄██       ███        ██    ██ ██   ██     ██  ▀  ▄██▄▄█▀ ██    ██ ██       ██        ▄██▄▄     ▄██▄▄█▀
      █     ███        ▀████████ ██    ▄  ▀▀████     ▀████████ ▀▀██ ███▄  ██  ██   ██ ▀▀██ ███▄  ███    █▄  ██    ██ ██   ██     ██    ▀███████ ██    ██ ██       ██       ▀▀██▀▀    ▀███████
      █     ███          ██   ██ ██    ██   ██ ▀██▄    ██   ██   ██    ██ ██  ██   ██   ██    ██ ███    ███ ██    ██ ██   ██     ██      ██  ██ ██    ██ ██▌    ▄ ██▌    ▄   ██   █    ██  ██
      █    ▄████▀        ██   █▀ ██████▀    ▀█   ▀█▀   ██   █▀   ██████▀  █    █   █    ██████▀  ████████▀   ██████   █   █     ▄██▀     ██  ██  ██████  ████▄▄██ ████▄▄██   ███████   ██  ██
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
      █  Unit tests for the PackagingController class.
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

namespace OpenIIoT.Core.Tests.Packaging.WebApi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Moq;
    using OpenIIoT.Core.Packaging.WebApi;
    using OpenIIoT.Core.Packaging.WebApi.Data;
    using OpenIIoT.SDK;
    using OpenIIoT.SDK.Common.OperationResult;
    using OpenIIoT.SDK.Packaging;
    using Xunit;

    /// <summary>
    ///     Unit tests for the <see cref="PackagingController"/> class.
    /// </summary>
    public class PackagingControllerTests
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PackagingControllerTests"/> class.
        /// </summary>
        public PackagingControllerTests()
        {
            Manager = new Mock<IApplicationManager>();
            PackageManager = new Mock<IPackageManager>();
            Package = new Mock<IPackage>();
            PackageArchive = new Mock<IPackageArchive>();

            Controller = new PackagingController(Manager.Object)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration(),
            };

            SetupMocks();
        }

        #endregion Public Constructors

        #region Private Properties

        /// <summary>
        ///     Gets or sets the WebApi Controller under test.
        /// </summary>
        private PackagingController Controller { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="IApplicationManager"/> mockup.
        /// </summary>
        private Mock<IApplicationManager> Manager { get; set; }

        /// <summary>
        ///     Gets or sets the IPackage mockup.
        /// </summary>
        private Mock<IPackage> Package { get; set; }

        /// <summary>
        ///     Gets or sets the IPackageArchive mockup.
        /// </summary>
        private Mock<IPackageArchive> PackageArchive { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="IPackageManager"/> mockup.
        /// </summary>
        private Mock<IPackageManager> PackageManager { get; set; }

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        ///     Tests the constructor.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            PackagingController test;

            Exception ex = Record.Exception(() => test = new PackagingController(Manager.Object));

            Assert.Null(ex);
        }

        /// <summary>
        ///     Tests the <see cref="PackagingController.PackageArchivesAdd(string)"/> method.
        /// </summary>
        [Fact]
        public async void PackageArchivesAdd()
        {
            string data = "dGVzdA==";

            HttpResponseMessage response = await Controller.PackageArchivesAdd(data);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        /// <summary>
        ///     Tests the <see cref="PackagingController.PackageArchivesAdd(string)"/> method with known bad data.
        /// </summary>
        [Fact]
        public async void PackageArchivesAddBadData()
        {
            string data = "not base64";

            HttpResponseMessage response = await Controller.PackageArchivesAdd(data);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        /// <summary>
        ///     Tests the <see cref="PackagingController.PackageArchivesAdd(string)"/> method with a simulated failure.
        /// </summary>
        [Fact]
        public async void PackageArchivesAddFailure()
        {
            string data = "dGVzdA==";

            PackageManager.Setup(p => p.AddPackageArchiveAsync(It.IsAny<byte[]>()))
                .ReturnsAsync(new Result<IPackageArchive>(ResultCode.Failure));

            HttpResponseMessage response = await Controller.PackageArchivesAdd(data);

            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        }

        /// <summary>
        ///     Tests the <see cref="PackagingController.PackageArchivesAdd(string)"/> method with no data.
        /// </summary>
        [Fact]
        public async void PackageArchivesAddNoData()
        {
            string data = string.Empty;

            HttpResponseMessage response = await Controller.PackageArchivesAdd(data);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        /// <summary>
        ///     Tests the <see cref="PackagingController.PackageArchivesDelete(string)"/> method.
        /// </summary>
        [Fact]
        public async void PackageArchivesDelete()
        {
            HttpResponseMessage response = await Controller.PackageArchivesDelete("test");

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        /// <summary>
        ///     Tests the <see cref="PackagingController.PackageArchivesDelete(string)"/> method with a bad fqn parameter.
        /// </summary>
        [Fact]
        public async void PackageArchivesDeleteBadFqn()
        {
            HttpResponseMessage response = await Controller.PackageArchivesDelete(null);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        /// <summary>
        ///     Tests the <see cref="PackagingController.PackageArchivesDelete(string)"/> method with a simulated deletion failure.
        /// </summary>
        [Fact]
        public async void PackageArchivesDeleteFailed()
        {
            PackageManager.Setup(p => p.DeletePackageArchiveAsync(It.IsAny<IPackageArchive>()))
                .ReturnsAsync(new Result(ResultCode.Failure));

            HttpResponseMessage response = await Controller.PackageArchivesDelete("test");

            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        }

        /// <summary>
        ///     Tests the <see cref="PackagingController.PackageArchivesDelete(string)"/> method with a package which can not be found.
        /// </summary>
        [Fact]
        public async void PackageArchivesDeleteNotFound()
        {
            PackageManager.Setup(p => p.FindPackageArchiveAsync(It.IsAny<string>()))
                .ReturnsAsync(default(IPackageArchive));

            HttpResponseMessage response = await Controller.PackageArchivesDelete("test");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        /// <summary>
        ///     Tests the <see cref="PackagingController.PackagesArchivesGet(bool?)"/> method.
        /// </summary>
        [Fact]
        public async void PackageArchivesGet()
        {
            HttpResponseMessage response = await Controller.PackagesArchivesGet(false);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            IReadOnlyList<PackageArchiveSummaryData> value = response.GetContent<IReadOnlyList<PackageArchiveSummaryData>>();

            Assert.Equal(1, value.Count);
            Assert.Equal(PackageArchive.Object.FQN, value[0].FQN);
        }

        /// <summary>
        ///     Tests the <see cref="PackagingController.PackageArchivesGetFqn(string)"/> method.
        /// </summary>
        [Fact]
        public async void PackageArchivesGetFqn()
        {
            HttpResponseMessage response = await Controller.PackageArchivesGetFqn("test");

            Assert.Equal(PackageArchive.Object, response.GetContent<IPackageArchive>());
        }

        /// <summary>
        ///     Tests the <see cref="PackagingController.PackageArchivesGetFqnFile(string)"/> method.
        /// </summary>
        /// <remarks>Unclear how to write an assertion for the binary return data, so skipping it for now</remarks>
        [Fact]
        public async void PackageArchivesGetFqnFile()
        {
            HttpResponseMessage response = await Controller.PackageArchivesGetFqnFile("test");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        /// <summary>
        ///     Tests the <see cref="PackagingController.PackageArchivesGetFqnFile(string)"/> method with a simulated failure.
        /// </summary>
        [Fact]
        public async void PackageArchivesGetFqnFileFailure()
        {
            PackageManager.Setup(p => p.FetchPackageArchiveAsync(It.IsAny<IPackageArchive>()))
                .ReturnsAsync(new Result<byte[]>(ResultCode.Failure));

            HttpResponseMessage response = await Controller.PackageArchivesGetFqnFile("test");

            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        }

        /// <summary>
        ///     Tests the <see cref="PackagingController.PackageArchivesGetFqnFile(string)"/> method with a package archive which
        ///     can not be found.
        /// </summary>
        [Fact]
        public async void PackageArchivesGetFqnFileNotFound()
        {
            PackageManager.Setup(p => p.FindPackageArchiveAsync(It.IsAny<string>()))
                .ReturnsAsync(default(IPackageArchive));

            HttpResponseMessage response = await Controller.PackageArchivesGetFqnFile("test");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        /// <summary>
        ///     Tests the <see cref="PackagingController.PackageArchivesGetFqnFile(string)"/> method with a null FQN.
        /// </summary>
        [Fact]
        public async void PackageArchivesGetFqnFileNullFqn()
        {
            HttpResponseMessage response = await Controller.PackageArchivesGetFqnFile(null);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        /// <summary>
        ///     Tests the <see cref="PackagingController.PackageArchivesGetFqn(string)"/> method with a package archive which is
        ///     not found.
        /// </summary>
        [Fact]
        public async void PackageArchivesGetFqnNotFound()
        {
            PackageManager.Setup(p => p.FindPackageArchiveAsync(It.IsAny<string>()))
                .ReturnsAsync(default(IPackageArchive));

            HttpResponseMessage response = await Controller.PackageArchivesGetFqn("test");

            Assert.Equal(response.StatusCode, HttpStatusCode.NotFound);
        }

        /// <summary>
        ///     Tests the <see cref="PackagingController.PackageArchivesGetFqn(string)"/> method with a null FQN.
        /// </summary>
        [Fact]
        public async void PackageArchivesGetFqnNullFqn()
        {
            HttpResponseMessage response = await Controller.PackageArchivesGetFqn(null);

            Assert.Equal(response.StatusCode, HttpStatusCode.BadRequest);
        }

        /// <summary>
        ///     Tests the <see cref="PackagingController.PackageArchivesGetFqnVerification(string, string)"/> method.
        /// </summary>
        [Fact]
        public async void PackageArchivesGetFqnVerification()
        {
            HttpResponseMessage response = await Controller.PackageArchivesGetFqnVerification("test");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(PackageVerification.Verified, response.GetContent<PackageArchiveVerificationData>().Verification);
        }

        /// <summary>
        ///     Tests the <see cref="PackagingController.PackageArchivesGetFqnVerification(string, string)"/> method with a package
        ///     archive which can not be found.
        /// </summary>
        [Fact]
        public async void PackageArchivesGetFqnVerificationArchiveNotFound()
        {
            PackageManager.Setup(p => p.FindPackageArchiveAsync(It.IsAny<string>()))
                .ReturnsAsync(default(IPackageArchive));

            HttpResponseMessage response = await Controller.PackageArchivesGetFqnVerification("test");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        /// <summary>
        ///     Tests the <see cref="PackagingController.PackageArchivesGetFqnVerification(string, string)"/> method with an
        ///     explicit PGP key which is invalid.
        /// </summary>
        [Fact]
        public async void PackageArchivesGetFqnVerificationBadPublicKey()
        {
            string key = "nope";
            HttpResponseMessage response = await Controller.PackageArchivesGetFqnVerification("test", key);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        /// <summary>
        ///     Tests the <see cref="PackagingController.PackageArchivesGetFqnVerification(string, string)"/> method with a
        ///     simulated failure to determine verification.
        /// </summary>
        [Fact]
        public async void PackageArchivesGetFqnVerificationFailure()
        {
            PackageManager.Setup(p => p.VerifyPackageArchiveAsync(It.IsAny<IPackageArchive>()))
                .ReturnsAsync(new Result<bool>(ResultCode.Failure));

            HttpResponseMessage response = await Controller.PackageArchivesGetFqnVerification("test");

            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        }

        /// <summary>
        ///     Tests the <see cref="PackagingController.PackageArchivesGetFqnVerification(string, string)"/> method with a null FQN.
        /// </summary>
        [Fact]
        public async void PackageArchivesGetFqnVerificationNullFqn()
        {
            HttpResponseMessage response = await Controller.PackageArchivesGetFqnVerification(null);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        /// <summary>
        ///     Tests the <see cref="PackagingController.PackageArchivesGetFqnVerification(string, string)"/> method with an
        ///     explicit PGP key.
        /// </summary>
        [Fact]
        public async void PackageArchivesGetFqnVerificationPublicKey()
        {
            string key = "-----BEGIN PGP PUBLIC KEY BLOCK----- -----END PGP PUBLIC KEY BLOCK-----";
            HttpResponseMessage response = await Controller.PackageArchivesGetFqnVerification("test", key);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(PackageVerification.Verified, response.GetContent<PackageArchiveVerificationData>().Verification);
        }

        /// <summary>
        ///     Tests the <see cref="PackagingController.PackagesArchivesGet(bool?)"/> method with a forced scan.
        /// </summary>
        [Fact]
        public async void PackageArchivesGetScan()
        {
            HttpResponseMessage response = await Controller.PackagesArchivesGet(true);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            IReadOnlyList<PackageArchiveSummaryData> value = response.GetContent<IReadOnlyList<PackageArchiveSummaryData>>();

            Assert.Equal(1, value.Count);
            Assert.Equal(PackageArchive.Object.FQN, value[0].FQN);
        }

        /// <summary>
        ///     Tests the <see cref="PackagingController.PackagesArchivesGet(bool?)"/> method with a forced scan with a simulated failure.
        /// </summary>
        [Fact]
        public async void PackageArchivesGetScanFailure()
        {
            PackageManager.Setup(p => p.ScanPackageArchivesAsync())
                .ReturnsAsync(new Result<IList<IPackageArchive>>(ResultCode.Failure));

            HttpResponseMessage response = await Controller.PackagesArchivesGet(true);

            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        }

        /// <summary>
        ///     Tests the <see cref="PackagingController.PackagesGet(bool?)"/> method.
        /// </summary>
        [Fact]
        public async void PackagesGet()
        {
            HttpResponseMessage response = await Controller.PackagesGet(false);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            IReadOnlyList<PackageSummaryData> value = response.GetContent<IReadOnlyList<PackageSummaryData>>();

            Assert.Equal(1, value.Count);
            Assert.Equal(Package.Object.FQN, value[0].FQN);
        }

        /// <summary>
        ///     Tests the <see cref="PackagingController.PackagesGetFqn(string)"/> method.
        /// </summary>
        [Fact]
        public async void PackagesGetFqn()
        {
            HttpResponseMessage response = await Controller.PackagesGetFqn("test");

            Assert.Equal(Package.Object, response.GetContent<IPackage>());
        }

        /// <summary>
        ///     Tests the <see cref="PackagingController.PackagesGetFqn(string)"/> method with a package which is not found.
        /// </summary>
        [Fact]
        public async void PackagesGetFqnNotFound()
        {
            PackageManager.Setup(p => p.FindPackageAsync(It.IsAny<string>()))
                .ReturnsAsync(default(IPackage));

            HttpResponseMessage response = await Controller.PackagesGetFqn("test");

            Assert.Equal(response.StatusCode, HttpStatusCode.NotFound);
        }

        /// <summary>
        ///     Tests the <see cref="PackagingController.PackagesGetFqn(string)"/> method with a null FQN.
        /// </summary>
        [Fact]
        public async void PackagesGetFqnNullFqn()
        {
            HttpResponseMessage response = await Controller.PackagesGetFqn(null);

            Assert.Equal(response.StatusCode, HttpStatusCode.BadRequest);
        }

        /// <summary>
        ///     Tests the <see cref="PackagingController.PackagesGet(bool?)"/> method with a forced scan.
        /// </summary>
        [Fact]
        public async void PackagesGetScan()
        {
            HttpResponseMessage response = await Controller.PackagesGet(true);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            IReadOnlyList<PackageSummaryData> value = response.GetContent<IReadOnlyList<PackageSummaryData>>();

            Assert.Equal(1, value.Count);
            Assert.Equal(PackageArchive.Object.FQN, value[0].FQN);
        }

        /// <summary>
        ///     Tests the <see cref="PackagingController.PackagesGet(bool?)"/> method with a forced scan with a simulated failure.
        /// </summary>
        [Fact]
        public async void PackagesGetScanFailure()
        {
            PackageManager.Setup(p => p.ScanPackagesAsync())
                .ReturnsAsync(new Result<IList<IPackage>>(ResultCode.Failure));

            HttpResponseMessage response = await Controller.PackagesGet(true);

            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        }

        /// <summary>
        ///     Tests the <see cref="PackagingController.PackagesInstall(string, PackageInstallationOptions)"/> method.
        /// </summary>
        [Fact]
        public async void PackagesInstall()
        {
            PackageInstallationOptions options = new PackageInstallationOptions();

            HttpResponseMessage response = await Controller.PackagesInstall("test", options);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        /// <summary>
        ///     Tests the <see cref="PackagingController.PackagesInstall(string, PackageInstallationOptions)"/> method with bad options.
        /// </summary>
        [Fact]
        public async void PackagesInstallBadOptions()
        {
            Controller.ModelState.AddModelError("test", new Exception());

            HttpResponseMessage response = await Controller.PackagesInstall("test", new PackageInstallationOptions());

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        /// <summary>
        ///     Tests the <see cref="PackagingController.PackagesInstall(string, PackageInstallationOptions)"/> method with a
        ///     simulated installation failure.
        /// </summary>
        [Fact]
        public async void PackagesInstallFailure()
        {
            PackageManager.Setup(p => p.InstallPackageAsync(It.IsAny<IPackageArchive>(), It.IsAny<PackageInstallationOptions>()))
                .ReturnsAsync(new Result<IPackage>(ResultCode.Failure));

            PackageInstallationOptions options = new PackageInstallationOptions();

            HttpResponseMessage response = await Controller.PackagesInstall("test", options);

            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        }

        /// <summary>
        ///     Tests the <see cref="PackagingController.PackagesInstall(string, PackageInstallationOptions)"/> method with a
        ///     package archive which can not be found.
        /// </summary>
        [Fact]
        public async void PackagesInstallNotFound()
        {
            PackageManager.Setup(p => p.FindPackageArchiveAsync(It.IsAny<string>()))
                .ReturnsAsync(default(IPackageArchive));

            PackageInstallationOptions options = new PackageInstallationOptions();

            HttpResponseMessage response = await Controller.PackagesInstall("test", options);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        /// <summary>
        ///     Tests the <see cref="PackagingController.PackagesInstall(string, PackageInstallationOptions)"/> method with a null FQN.
        /// </summary>
        [Fact]
        public async void PackagesInstallNullFqn()
        {
            PackageInstallationOptions options = new PackageInstallationOptions();

            HttpResponseMessage response = await Controller.PackagesInstall(null, options);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        /// <summary>
        ///     Tests the <see cref="PackagingController.PackagesUninstall(string)"/> method.
        /// </summary>
        [Fact]
        public async void PackagesUninstall()
        {
            HttpResponseMessage response = await Controller.PackagesUninstall("test");

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        /// <summary>
        ///     Tests the <see cref="PackagingController.PackagesUninstall(string)"/> method with a simulated failure.
        /// </summary>
        [Fact]
        public async void PackagesUninstallFailure()
        {
            PackageManager.Setup(p => p.UninstallPackageAsync(It.IsAny<IPackage>()))
                .ReturnsAsync(new Result(ResultCode.Failure));

            HttpResponseMessage response = await Controller.PackagesUninstall("test");

            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        }

        /// <summary>
        ///     Tests the <see cref="PackagingController.PackagesUninstall(string)"/> method with a package which can not be found.
        /// </summary>
        [Fact]
        public async void PackagesUninstallNotFound()
        {
            PackageManager.Setup(p => p.FindPackageAsync(It.IsAny<string>()))
                .ReturnsAsync(default(IPackage));

            HttpResponseMessage response = await Controller.PackagesUninstall("test");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        /// <summary>
        ///     Tests the <see cref="PackagingController.PackagesUninstall(string)"/> method with a null FQN.
        /// </summary>
        [Fact]
        public async void PackagesUninstallNullFqn()
        {
            HttpResponseMessage response = await Controller.PackagesUninstall(null);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        ///     Configures the mockups.
        /// </summary>
        private void SetupMocks()
        {
            Package.Setup(p => p.FQN).Returns("fqn");
            PackageArchive.Setup(p => p.FQN).Returns("fqn");

            PackageManager.Setup(p => p.Packages)
                .Returns(new[] { Package.Object }.ToList().AsReadOnly());

            PackageManager.Setup(p => p.PackageArchives)
                .Returns(new[] { PackageArchive.Object }.ToList().AsReadOnly());

            PackageManager.Setup(p => p.UninstallPackageAsync(It.IsAny<IPackage>()))
                .ReturnsAsync(new Result());

            PackageManager.Setup(p => p.InstallPackageAsync(It.IsAny<IPackageArchive>(), It.IsAny<PackageInstallationOptions>()))
                .ReturnsAsync(new Result<IPackage>().SetReturnValue(Package.Object));

            PackageManager.Setup(p => p.ScanPackagesAsync())
                .ReturnsAsync(new Result<IList<IPackage>>());

            PackageManager.Setup(p => p.ScanPackageArchivesAsync())
                .ReturnsAsync(new Result<IList<IPackageArchive>>());

            PackageManager.Setup(p => p.AddPackageArchiveAsync(It.IsAny<byte[]>()))
                .ReturnsAsync(new Result<IPackageArchive>().SetReturnValue(PackageArchive.Object));

            PackageManager.Setup(p => p.FindPackageAsync(It.IsAny<string>()))
                .ReturnsAsync(Package.Object);

            PackageManager.Setup(p => p.FindPackageArchiveAsync(It.IsAny<string>()))
                .ReturnsAsync(PackageArchive.Object);

            PackageManager.Setup(p => p.FetchPackageArchiveAsync(It.IsAny<IPackageArchive>()))
                .ReturnsAsync(new Result<byte[]>().SetReturnValue(new byte[] { 1 }));

            PackageManager.Setup(p => p.DeletePackageArchiveAsync(It.IsAny<IPackageArchive>()))
                .ReturnsAsync(new Result());

            PackageManager.Setup(p => p.VerifyPackageArchiveAsync(It.IsAny<IPackageArchive>()))
                .ReturnsAsync(new Result<bool>().SetReturnValue(true));

            Manager.Setup(m => m.GetManager<IPackageManager>()).Returns(PackageManager.Object);
        }

        #endregion Private Methods
    }
}