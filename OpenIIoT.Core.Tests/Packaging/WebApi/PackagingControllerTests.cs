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
    using Moq;
    using OpenIIoT.Core.Packaging.WebApi;
    using OpenIIoT.SDK;
    using OpenIIoT.SDK.Packaging;
    using Xunit;
    using System.Net.Http;
    using OpenIIoT.SDK.Common.OperationResult;
    using System.Net;
    using OpenIIoT.Core.Packaging;
    using System.Web.Http;

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
            PackageArchive = new Mock<IPackageArchive>();

            Controller = new PackagingController(Manager.Object);
            Controller.Request = new HttpRequestMessage();
            Controller.Configuration = new HttpConfiguration();

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
        ///     Tests the <see cref="PackagingController.PackageArchivesGetFqn(string)"/> method with a null FQN.
        /// </summary>
        [Fact]
        public async void PackageArchivesGetFqnNullFqn()
        {
            HttpResponseMessage response = await Controller.PackageArchivesGetFqn(null);

            Assert.Equal(response.StatusCode, HttpStatusCode.BadRequest);
        }

        /// <summary>
        ///     Tests the <see cref="PackagingController.PackageArchivesGetFqn(string)"/> method with a package archive which is
        ///     not found.
        /// </summary>
        [Fact]
        public async void PackageArchivesGetFqnNullNotFound()
        {
            PackageManager.Setup(p => p.FindPackageArchiveAsync(It.IsAny<string>()))
                .ReturnsAsync(default(IPackageArchive));

            HttpResponseMessage response = await Controller.PackageArchivesGetFqn("test");

            Assert.Equal(response.StatusCode, HttpStatusCode.NotFound);
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        ///     Configures the mockups.
        /// </summary>
        private void SetupMocks()
        {
            PackageManager.Setup(p => p.AddPackageArchiveAsync(It.IsAny<byte[]>()))
                .ReturnsAsync(new Result<IPackageArchive>().SetReturnValue(PackageArchive.Object));

            PackageManager.Setup(p => p.FindPackageArchiveAsync(It.IsAny<string>()))
                .ReturnsAsync(PackageArchive.Object);

            PackageManager.Setup(p => p.FetchPackageArchiveAsync(It.IsAny<IPackageArchive>()))
                .ReturnsAsync(new Result<byte[]>().SetReturnValue(new byte[] { 1 }));

            PackageManager.Setup(p => p.DeletePackageArchiveAsync(It.IsAny<IPackageArchive>()))
                .ReturnsAsync(new Result());

            Manager.Setup(m => m.GetManager<IPackageManager>()).Returns(PackageManager.Object);
        }

        #endregion Private Methods
    }
}