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

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        ///     Configures the mockups.
        /// </summary>
        private void SetupMocks()
        {
            PackageManager.Setup(p => p.AddPackageArchiveAsync(It.IsAny<byte[]>()))
                .ReturnsAsync(new Result<IPackageArchive>().SetReturnValue(PackageArchive.Object));

            Manager.Setup(m => m.GetManager<IPackageManager>()).Returns(PackageManager.Object);
        }

        #endregion Private Methods
    }
}