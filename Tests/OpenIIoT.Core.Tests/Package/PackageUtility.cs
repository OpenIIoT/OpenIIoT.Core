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

            DataRoot = Path.Combine(dirPath, "Package", "Data");
            Data = Path.Combine(DataRoot, "Package");
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
    }
}