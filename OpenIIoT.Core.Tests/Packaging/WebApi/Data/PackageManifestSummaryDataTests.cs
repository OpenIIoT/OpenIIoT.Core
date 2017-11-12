/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄███████▄                                                                 ▄▄▄▄███▄▄▄▄
      █     ███    ███                                                               ▄██▀▀▀███▀▀▀██▄
      █     ███    ███   ▄█████   ▄██████    █  █▄     ▄█████     ▄████▄     ▄█████  ███   ███   ███   ▄█████  ██▄▄▄▄   █     ▄█████    ▄█████   ▄█████     ██
      █     ███    ███   ██   ██ ██    ██   ██ ▄██▀    ██   ██   ██    ▀    ██   █   ███   ███   ███   ██   ██ ██▀▀▀█▄ ██    ██   ▀█   ██   █    ██  ▀  ▀███████▄
      █   ▀█████████▀    ██   ██ ██    ▀    ██▐█▀      ██   ██  ▄██        ▄██▄▄     ███   ███   ███   ██   ██ ██   ██ ██▌  ▄██▄▄     ▄██▄▄      ██         ██  ▀
      █     ███        ▀████████ ██    ▄  ▀▀████     ▀████████ ▀▀██ ███▄  ▀▀██▀▀     ███   ███   ███ ▀████████ ██   ██ ██  ▀▀██▀▀    ▀▀██▀▀    ▀███████     ██
      █     ███          ██   ██ ██    ██   ██ ▀██▄    ██   ██   ██    ██   ██   █   ███   ███   ███   ██   ██ ██   ██ ██    ██        ██   █     ▄  ██     ██
      █    ▄████▀        ██   █▀ ██████▀    ▀█   ▀█▀   ██   █▀   ██████▀    ███████   ▀█   ███   █▀    ██   █▀  █   █  █     ██        ███████  ▄████▀     ▄██▀
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
      █  Unit tests for the PackageManifestSummaryData class.
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
    using Moq;
    using OpenIIoT.Core.Packaging.WebApi.Data;
    using OpenIIoT.SDK.Packaging.Manifest;
    using Xunit;

    /// <summary>
    ///     Unit tests for the <see cref="PackageManifestSummaryData"/> class.
    /// </summary>
    public class PackageManifestSummaryDataTests
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PackageManifestSummaryDataTests"/> class.
        /// </summary>
        public PackageManifestSummaryDataTests()
        {
            PackageManifestMock = new Mock<IPackageManifest>();

            SetupMocks();
        }

        #endregion Public Constructors

        #region Private Properties

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
            PackageManifestSummaryData test = new PackageManifestSummaryData(PackageManifestMock.Object);

            Assert.NotNull(test);
            Assert.Equal("name", test.Name);
            Assert.Equal("version", test.Version);
            Assert.Equal("namespace", test.Namespace);
            Assert.Equal("description", test.Description);
            Assert.Equal("publisher", test.Publisher);
            Assert.Equal("copyright", test.Copyright);
            Assert.Equal("license", test.License);
            Assert.Equal("url", test.Url);

            Assert.NotNull(test.Signature);
            Assert.Equal("issuer", test.Signature.Issuer);
            Assert.Equal("subject", test.Signature.Subject);
        }

        /// <summary>
        ///     Tests the constructor with a Manifest containing a null Signature.
        /// </summary>
        [Fact]
        public void ConstructorNullSignature()
        {
            PackageManifestMock.Setup(p => p.Signature).Returns(default(PackageManifestSignature));

            PackageManifestSummaryData test = new PackageManifestSummaryData(PackageManifestMock.Object);

            Assert.NotNull(test);
            Assert.Equal("name", test.Name);
            Assert.Equal("version", test.Version);
            Assert.Equal("namespace", test.Namespace);
            Assert.Equal("description", test.Description);
            Assert.Equal("publisher", test.Publisher);
            Assert.Equal("copyright", test.Copyright);
            Assert.Equal("license", test.License);
            Assert.Equal("url", test.Url);

            Assert.Null(test.Signature);
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        ///     Configures the mockups for the unit tests.
        /// </summary>
        private void SetupMocks()
        {
            PackageManifestMock.Setup(p => p.Name).Returns("name");
            PackageManifestMock.Setup(p => p.Version).Returns("version");
            PackageManifestMock.Setup(p => p.Namespace).Returns("namespace");
            PackageManifestMock.Setup(p => p.Description).Returns("description");
            PackageManifestMock.Setup(p => p.Publisher).Returns("publisher");
            PackageManifestMock.Setup(p => p.Copyright).Returns("copyright");
            PackageManifestMock.Setup(p => p.License).Returns("license");
            PackageManifestMock.Setup(p => p.Url).Returns("url");
            PackageManifestMock.Setup(p => p.Signature)
                .Returns(new PackageManifestSignature()
                {
                    Issuer = "issuer",
                    Subject = "subject",
                });
        }

        #endregion Private Methods
    }
}