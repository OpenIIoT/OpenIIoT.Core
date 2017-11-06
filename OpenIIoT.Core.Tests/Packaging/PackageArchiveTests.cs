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
      █  Unit tests for the PackageArchive class.
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
    using OpenIIoT.Core.Packaging;
    using OpenIIoT.SDK.Packaging;
    using OpenIIoT.SDK.Packaging.Manifest;
    using Xunit;

    /// <summary>
    ///     Unit tests for the <see cref="PackageArchive"/> class.
    /// </summary>
    public class PackageArchiveTests : IDisposable
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PackageArchiveTests"/> class.
        /// </summary>
        public PackageArchiveTests()
        {
            ManifestMock = new Mock<IPackageManifest>();

            SetupMocks();

            Temp = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(Temp);

            File.WriteAllText(Path.Combine(Temp, "archive.zip"), string.Empty);
        }

        #endregion Public Constructors

        #region Private Properties

        /// <summary>
        ///     Gets or sets the IPackageManifest mockup.
        /// </summary>
        private Mock<IPackageManifest> ManifestMock { get; set; }

        /// <summary>
        ///     Gets or sets the temporary test directory.
        /// </summary>
        private string Temp { get; set; }

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        ///     Tests the constructor and all properties.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            FileInfo file = new FileInfo(Path.Combine(Temp, "archive.zip"));
            PackageArchive test = new PackageArchive(file, ManifestMock.Object);

            Assert.IsType<PackageArchive>(test);
            Assert.NotNull(test);

            Assert.Equal(file.CreationTimeUtc, test.CreatedOn);
            Assert.Equal(file.FullName, test.FileName);
            Assert.Equal("OpenIIoT.Tests.Test", test.FQN);
            Assert.Equal(false, test.HasTrust);
            Assert.Equal(false, test.IsSigned);
            Assert.Equal(ManifestMock.Object, test.Manifest);
            Assert.Equal(file.LastWriteTimeUtc, test.ModifiedOn);
            Assert.Equal(PackageVerification.Unverified, test.Verification);
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
        ///     Tests the <see cref="PackageArchive.HasTrust"/> property with a signed Package Archive containing a Trust.
        /// </summary>
        [Fact]
        public void HasTrust()
        {
            ManifestMock.Setup(m => m.Signature)
                .Returns(new PackageManifestSignature() { Trust = "trust" });

            FileInfo file = new FileInfo(Path.Combine(Temp, "archive.zip"));
            PackageArchive test = new PackageArchive(file, ManifestMock.Object);

            Assert.Equal(true, test.HasTrust);
        }

        /// <summary>
        ///     Tests the <see cref="PackageArchive.IsSigned"/> property with a signed Package Archive.
        /// </summary>
        [Fact]
        public void IsSigned()
        {
            ManifestMock.Setup(m => m.Signature).Returns(new PackageManifestSignature());

            FileInfo file = new FileInfo(Path.Combine(Temp, "archive.zip"));
            PackageArchive test = new PackageArchive(file, ManifestMock.Object);

            Assert.Equal(true, test.IsSigned);
            Assert.Equal(false, test.HasTrust);
        }

        /// <summary>
        ///     Test the <see cref="PackageArchive.Verification"/> property.
        /// </summary>
        [Fact]
        public void Verification()
        {
            FileInfo file = new FileInfo(Path.Combine(Temp, "archive.zip"));
            PackageArchive test = new PackageArchive(file, ManifestMock.Object);

            Assert.Equal(PackageVerification.Unverified, test.Verification);

            test.Verification = PackageVerification.Verified;

            Assert.Equal(PackageVerification.Verified, test.Verification);
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
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        ///     Configures the mockups for the unit tests.
        /// </summary>
        private void SetupMocks()
        {
            ManifestMock.Setup(m => m.Name).Returns("Test");
            ManifestMock.Setup(m => m.Namespace).Returns("OpenIIoT.Tests");
        }

        #endregion Private Methods
    }
}