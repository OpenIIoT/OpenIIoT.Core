/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄███████▄                                                                ▄████████
      █     ███    ███                                                                ███    ███
      █     ███    ███   ▄█████   ▄██████    █  █▄     ▄█████     ▄████▄     ▄█████   ███    ███    █████  ▄██████   ██   █     █   █    █     ▄█████
      █     ███    ███   ██   ██ ██    ██   ██ ▄██▀    ██   ██   ██    ▀    ██   █    ███    ███   ██  ██ ██    ██   ██   ██   ██  ██    ██   ██   █
      █   ▀█████████▀    ██   ██ ██    ▀    ██▐█▀      ██   ██  ▄██        ▄██▄▄    ▀███████████  ▄██▄▄█▀ ██    ▀   ▄██▄▄▄██▄▄ ██▌ ██    ██  ▄██▄▄
      █     ███        ▀████████ ██    ▄  ▀▀████     ▀████████ ▀▀██ ███▄  ▀▀██▀▀      ███    ███ ▀███████ ██    ▄  ▀▀██▀▀▀██▀  ██  ██    ██ ▀▀██▀▀
      █     ███          ██   ██ ██    ██   ██ ▀██▄    ██   ██   ██    ██   ██   █    ███    ███   ██  ██ ██    ██   ██   ██   ██   █▄  ▄█    ██   █
      █    ▄████▀        ██   █▀ ██████▀    ▀█   ▀█▀   ██   █▀   ██████▀    ███████   ███    █▀    ██  ██ ██████▀    ██   ██   █     ▀██▀     ███████
      █
      █      ▄████████                                                            ████████▄
      █     ███    ███                                                            ███   ▀███
      █     ███    █▀  ██   █     ▄▄██▄▄▄     ▄▄██▄▄▄    ▄█████     █████ ▄█   ▄  ███    ███   ▄█████      ██      ▄█████
      █     ███        ██   ██  ▄█▀▀██▀▀█▄  ▄█▀▀██▀▀█▄   ██   ██   ██  ██ ██   █▄ ███    ███   ██   ██ ▀███████▄   ██   ██
      █   ▀███████████ ██   ██  ██  ██  ██  ██  ██  ██   ██   ██  ▄██▄▄█▀ ▀▀▀▀▀██ ███    ███   ██   ██     ██  ▀   ██   ██
      █            ███ ██   ██  ██  ██  ██  ██  ██  ██ ▀████████ ▀███████ ▄█   ██ ███    ███ ▀████████     ██    ▀████████
      █      ▄█    ███ ██   ██  ██  ██  ██  ██  ██  ██   ██   ██   ██  ██ ██   ██ ███   ▄███   ██   ██     ██      ██   ██
      █    ▄████████▀  ██████    █  ██  █    █  ██  █    ██   █▀   ██  ██  █████  ████████▀    ██   █▀    ▄██▀     ██   █▀
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
      █  Unit tests for the PackageArchiveSummaryData class.
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

namespace OpenIIoT.Core.Tests.Packaging.WebApi.Data
{
    using System;
    using Moq;
    using OpenIIoT.Core.Packaging.WebApi.Data;
    using OpenIIoT.SDK.Packaging;
    using OpenIIoT.SDK.Packaging.Manifest;
    using Xunit;

    /// <summary>
    ///     Unit tests for the <see cref="PackageArchiveSummaryData"/> class.
    /// </summary>
    public class PackageArchiveSummaryDataTests
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PackageArchiveSummaryDataTests"/> class.
        /// </summary>
        public PackageArchiveSummaryDataTests()
        {
            PackageManifestMock = new Mock<IPackageManifest>();
            PackageArchiveMock = new Mock<IPackageArchive>();

            SetupMocks();
        }

        #endregion Public Constructors

        #region Private Properties

        /// <summary>
        ///     Gets or sets the IPackageArchive mockup.
        /// </summary>
        private Mock<IPackageArchive> PackageArchiveMock { get; set; }

        /// <summary>
        ///     Gets or sets the IPackageManifest mockup.
        /// </summary>
        private Mock<IPackageManifest> PackageManifestMock { get; set; }

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        ///     Tests the constructor and all properties.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            PackageArchiveSummaryData test = new PackageArchiveSummaryData(PackageArchiveMock.Object);

            Assert.NotNull(test);
            Assert.Equal("name.namespace", test.FQN);
            Assert.Equal("filename", test.FileName);
            Assert.Equal(PackageVerification.Unverified, test.Verification);
            Assert.Equal(false, test.HasTrust);
            Assert.Equal(false, test.IsSigned);
            Assert.Equal(PackageArchiveMock.Object.CreatedOn, test.CreatedOn);
            Assert.Equal(PackageArchiveMock.Object.ModifiedOn, test.ModifiedOn);
            Assert.Equal("name", test.Manifest.Name);
            Assert.Equal("namespace", test.Manifest.Namespace);
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        ///     Configures the mockups for the unit tests.
        /// </summary>
        private void SetupMocks()
        {
            PackageManifestMock.Setup(p => p.Name).Returns("name");
            PackageManifestMock.Setup(p => p.Namespace).Returns("namespace");

            PackageArchiveMock.Setup(p => p.FQN).Returns("name.namespace");
            PackageArchiveMock.Setup(p => p.FileName).Returns("filename");
            PackageArchiveMock.Setup(p => p.Verification).Returns(PackageVerification.Unverified);
            PackageArchiveMock.Setup(p => p.HasTrust).Returns(false);
            PackageArchiveMock.Setup(p => p.IsSigned).Returns(false);
            PackageArchiveMock.Setup(p => p.CreatedOn).Returns(DateTime.Now);
            PackageArchiveMock.Setup(p => p.ModifiedOn).Returns(DateTime.Now);
            PackageArchiveMock.Setup(p => p.Manifest).Returns(PackageManifestMock.Object);
        }

        #endregion Private Methods
    }
}