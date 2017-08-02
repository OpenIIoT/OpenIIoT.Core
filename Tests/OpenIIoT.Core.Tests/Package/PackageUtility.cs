/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄███████▄                                                              ███    █▄
      █     ███    ███                                                              ███    ███
      █     ███    ███   ▄█████   ▄██████    █  █▄     ▄█████     ▄████▄     ▄█████ ███    ███     ██     █   █        █      ██    ▄█   ▄
      █     ███    ███   ██   ██ ██    ██   ██ ▄██▀    ██   ██   ██    ▀    ██   █  ███    ███ ▀███████▄ ██  ██       ██  ▀███████▄ ██   █▄
      █   ▀█████████▀    ██   ██ ██    ▀    ██▐█▀      ██   ██  ▄██        ▄██▄▄    ███    ███     ██  ▀ ██▌ ██       ██▌     ██  ▀ ▀▀▀▀▀██
      █     ███        ▀████████ ██    ▄  ▀▀████     ▀████████ ▀▀██ ███▄  ▀▀██▀▀    ███    ███     ██    ██  ██       ██      ██    ▄█   ██
      █     ███          ██   ██ ██    ██   ██ ▀██▄    ██   ██   ██    ██   ██   █  ███    ███     ██    ██  ██▌    ▄ ██      ██    ██   ██
      █    ▄████▀        ██   █▀ ██████▀    ▀█   ▀█▀   ██   █▀   ██████▀    ███████ ████████▀     ▄██▀   █   ████▄▄██ █      ▄██▀    █████
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
      █  Unit tests for the PackageUtility class.
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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Moq;
using OpenIIoT.SDK.Package;
using OpenIIoT.SDK.Platform;
using Utility.OperationResult;
using Xunit;

namespace OpenIIoT.Core.Tests.Package
{
    /// <summary>
    ///     Unit tests for the <see cref="Core.Package.PackageUtility"/> class.
    /// </summary>
    public class PackageUtility : IDisposable
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PackageUtility"/> class.
        /// </summary>
        public PackageUtility()
        {
            Temp = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

            Directory.CreateDirectory(Temp);

            Uri codeBaseUri = new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            string codeBasePath = Uri.UnescapeDataString(codeBaseUri.AbsolutePath);
            string dirPath = Path.GetDirectoryName(codeBasePath);

            Data = Path.Combine(dirPath, "Package", "Data", "Package");
        }

        #endregion Public Constructors

        #region Private Properties

        /// <summary>
        ///     Gets or sets the test data directory.
        /// </summary>
        private string Data { get; set; }

        /// <summary>
        ///     Gets or sets the temporary data directory.
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
            Core.Package.PackageUtility test = new Core.Package.PackageUtility(new Mock<IPlatform>().Object);

            Assert.IsType<Core.Package.PackageUtility>(test);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Package.PackageUtility.Create(byte[])"/> method with a known good package payload.
        /// </summary>
        [Fact]
        public void CreatePackage()
        {
            byte[] data = File.ReadAllBytes(Path.Combine(Data, "package.zip"));

            Mock<IDirectories> dirMock = new Mock<IDirectories>();
            dirMock.Setup(d => d.Packages).Returns(Temp);
            dirMock.Setup(d => d.Temp).Returns(Temp);

            TestPlatform platform = new TestPlatform(dirMock.Object);

            Core.Package.PackageUtility test = new Core.Package.PackageUtility(platform);

            IResult<IPackage> package = test.Create(data);

            Assert.Equal(ResultCode.Success, package.ResultCode);
            Assert.True(File.Exists(Path.Combine(Temp, "OpenIIoT.Plugin.DefaultPlugin.1.0.0.zip")));
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
        ///     Tests the <see cref="Core.Package.PackageReader.Read(string)"/> method with a known good package.
        /// </summary>
        [Fact]
        public void ReadPackage()
        {
            Core.Package.PackageUtility reader = new Core.Package.PackageUtility(new Mock<IPlatform>().Object);

            IResult<IPackage> result = reader.Read(Path.Combine(Data, "package.zip"));

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.IsType<Core.Package.Package>(result.ReturnValue);
            Assert.NotEqual(string.Empty, result.ReturnValue.FQN);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Package.PackageReader.Read(string)"/> method with a known bad package.
        /// </summary>
        [Fact]
        public void ReadPackageNotAPackage()
        {
            Core.Package.PackageUtility reader = new Core.Package.PackageUtility(new Mock<IPlatform>().Object);

            IResult<IPackage> result = reader.Read(Path.Combine(Data, "notapackage.zip"));

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Package.PackageUtility.Scan(string)"/> method with a bad directory.
        /// </summary>
        [Fact]
        public void ScanBadDirectory()
        {
            IResult<IList<string>> dirResult = new Result<IList<string>>(ResultCode.Failure);

            Mock<IPlatform> platformMock = new Mock<IPlatform>();
            platformMock.Setup(p => p.ListFiles(Data)).Returns(dirResult);

            Core.Package.PackageUtility lister = new Core.Package.PackageUtility(platformMock.Object);

            IResult<IList<IPackage>> list = lister.Scan(Data);

            Assert.Equal(ResultCode.Failure, list.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Package.PackageUtility.Scan()"/> method.
        /// </summary>
        [Fact]
        public void ScanDefaultDirectory()
        {
            Mock<IDirectories> dirMock = new Mock<IDirectories>();
            dirMock.Setup(d => d.Packages).Returns(Data);

            Mock<IPlatform> platformMock = new Mock<IPlatform>();
            platformMock.Setup(p => p.Directories).Returns(dirMock.Object);

            IResult<IList<string>> dirResult = new Result<IList<string>>();
            platformMock.Setup(p => p.ListFiles(Data)).Returns(dirResult);

            Core.Package.PackageUtility lister = new Core.Package.PackageUtility(platformMock.Object);

            IResult<IList<IPackage>> list = lister.Scan();

            Assert.Equal(ResultCode.Success, list.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Package.PackageUtility.Scan(string)"/> method with an empty directory.
        /// </summary>
        [Fact]
        public void ScanEmptyDirectory()
        {
            IResult<IList<string>> dirResult = new Result<IList<string>>();
            dirResult.ReturnValue = new List<string>();

            Mock<IPlatform> platformMock = new Mock<IPlatform>();
            platformMock.Setup(p => p.ListFiles(Data)).Returns(dirResult);

            Core.Package.PackageUtility lister = new Core.Package.PackageUtility(platformMock.Object);

            IResult<IList<IPackage>> list = lister.Scan(Data);

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
            File.WriteAllText(Path.Combine(Temp, "package.zip"), "hello world!");

            IResult<IList<string>> dirResult = new Result<IList<string>>();
            dirResult.ReturnValue = Directory.GetFiles(Temp).ToList();

            Mock<IPlatform> platformMock = new Mock<IPlatform>();
            platformMock.Setup(p => p.ListFiles(Temp)).Returns(dirResult);

            Core.Package.PackageUtility scanner = new Core.Package.PackageUtility(platformMock.Object);

            IResult<IList<IPackage>> list = scanner.Scan(Temp);

            Assert.Equal(ResultCode.Warning, list.ResultCode);
            Assert.Equal(0, list.ReturnValue.Count);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Package.PackageScanner.Scan(string)"/> method with a directory containing Package files.
        /// </summary>
        [Fact]
        public void ScanPackages()
        {
            IResult<IList<string>> dirResult = new Result<IList<string>>();
            dirResult.ReturnValue = Directory.GetFiles(Data).ToList();

            Mock<IPlatform> platformMock = new Mock<IPlatform>();
            platformMock.Setup(p => p.ListFiles(Data)).Returns(dirResult);

            Core.Package.PackageUtility scanner = new Core.Package.PackageUtility(platformMock.Object);

            IResult<IList<IPackage>> list = scanner.Scan(Data);

            Assert.Equal(ResultCode.Success, list.ResultCode);
            Assert.Equal(3, list.ReturnValue.Count);

            // spot check a few Manifest fields to see if the manifest was fetched properly
            Assert.NotNull(list.ReturnValue[0].FQN);
            Assert.NotEqual(0, list.ReturnValue[0].FQN.Length);
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

        #region Private Classes

        /// <summary>
        ///     Platform concretion used for testing.
        /// </summary>
        /// <remarks>
        ///     It isn't feasible to mock this object as the required functionality for some operations is difficult to mock.
        /// </remarks>
        private class TestPlatform : Core.Platform.Platform
        {
            #region Public Constructors

            /// <summary>
            ///     Initializes a new instance of the <see cref="TestPlatform"/> class.
            /// </summary>
            /// <param name="directories">The Directories to use.</param>
            public TestPlatform(IDirectories directories)
                : base(directories)
            {
            }

            #endregion Public Constructors
        }

        #endregion Private Classes
    }
}