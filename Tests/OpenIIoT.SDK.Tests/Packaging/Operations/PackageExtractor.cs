/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄███████▄                                                                 ▄████████
      █     ███    ███                                                                ███    ███
      █     ███    ███   ▄█████   ▄██████    █  █▄     ▄█████     ▄████▄     ▄█████   ███    █▀  ▀███  ▐██▀     ██       █████   ▄█████   ▄██████     ██     ██████     █████
      █     ███    ███   ██   ██ ██    ██   ██ ▄██▀    ██   ██   ██    ▀    ██   █   ▄███▄▄▄       ██  ██   ▀███████▄   ██  ██   ██   ██ ██    ██ ▀███████▄ ██    ██   ██  ██
      █   ▀█████████▀    ██   ██ ██    ▀    ██▐█▀      ██   ██  ▄██        ▄██▄▄    ▀▀███▀▀▀        ████▀       ██  ▀  ▄██▄▄█▀   ██   ██ ██    ▀      ██  ▀ ██    ██  ▄██▄▄█▀
      █     ███        ▀████████ ██    ▄  ▀▀████     ▀████████ ▀▀██ ███▄  ▀▀██▀▀      ███    █▄     ████        ██    ▀███████ ▀████████ ██    ▄      ██    ██    ██ ▀███████
      █     ███          ██   ██ ██    ██   ██ ▀██▄    ██   ██   ██    ██   ██   █    ███    ███  ▄██ ▀██       ██      ██  ██   ██   ██ ██    ██     ██    ██    ██   ██  ██
      █    ▄████▀        ██   █▀ ██████▀    ▀█   ▀█▀   ██   █▀   ██████▀    ███████   ██████████ ███    ██▄    ▄██▀     ██  ██   ██   █▀ ██████▀     ▄██▀    ██████    ██  ██
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
      █  Unit tests for the PackageExtractor class.
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
using System.IO;
using Xunit;

namespace OpenIIoT.SDK.Packaging.Tests.Operations
{
    /// <summary>
    ///     Unit tests for the <see cref="Packaging.Operations.PackageExtractor"/> class.
    /// </summary>
    public sealed class PackageExtractor : IDisposable
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PackageExtractor"/> class.
        /// </summary>
        public PackageExtractor()
        {
            Extractor = new Packaging.Operations.PackageExtractor();

            Uri codeBaseUri = new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            string codeBasePath = Uri.UnescapeDataString(codeBaseUri.AbsolutePath);
            string dirPath = Path.GetDirectoryName(codeBasePath);

            DataDirectory = Path.Combine(dirPath, "Data");

            TempDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

            Directory.CreateDirectory(TempDirectory);
        }

        #endregion Public Constructors

        #region Private Properties

        /// <summary>
        ///     Gets or sets the data directory used for tests.
        /// </summary>
        private string DataDirectory { get; set; }

        /// <summary>
        ///     Gets or sets the Package Extractor to test.
        /// </summary>
        private Packaging.Operations.PackageExtractor Extractor { get; set; }

        /// <summary>
        ///     Gets or sets the temporary directory used for tests.
        /// </summary>
        private string TempDirectory { get; set; }

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        ///     Disposes this instance of <see cref="PackageExtractor"/>.
        /// </summary>
        public void Dispose()
        {
            Directory.Delete(TempDirectory, true);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageExtractor.ExtractPackage(string, string, bool, bool)"/> method.
        /// </summary>
        [Fact]
        public void ExtractPackage()
        {
            string package = Path.Combine(DataDirectory, "Package", "package.zip");
            string output = Path.Combine(TempDirectory, "output");

            Exception ex = Record.Exception(() => Extractor.ExtractPackage(package, output));

            Assert.Null(ex);
            Assert.Equal(3, Directory.GetFiles(output).Length);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageExtractor.ExtractPackage(string, string, bool, bool)"/> method
        ///     with an invalid package.
        /// </summary>
        [Fact]
        public void ExtractPackageBadPackage()
        {
            string package = Path.Combine(DataDirectory, "Package", "notapackage.zip");
            string output = Path.Combine(TempDirectory, "output");

            Directory.CreateDirectory(output);

            Exception ex = Record.Exception(() => Extractor.ExtractPackage(package, output, true, true));

            Assert.NotNull(ex);
            Assert.IsType<Exception>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageExtractor.ExtractPackage(string, string, bool, bool)"/> method
        ///     with a blank output directory argument.
        /// </summary>
        [Fact]
        public void ExtractPackageOutputDirectoryBlank()
        {
            string package = Path.Combine(DataDirectory, "Package", "package.zip");

            Exception ex = Record.Exception(() => Extractor.ExtractPackage(package, string.Empty));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageExtractor.ExtractPackage(string, string, bool, bool)"/> method.
        /// </summary>
        [Fact]
        public void ExtractPackageOutputDirectoryExistsButEmptyNoOverwrite()
        {
            string package = Path.Combine(DataDirectory, "Package", "package.zip");
            string output = Path.Combine(TempDirectory, "output");

            Directory.CreateDirectory(output);

            Exception ex = Record.Exception(() => Extractor.ExtractPackage(package, output));

            Assert.Null(ex);
            Assert.Equal(3, Directory.GetFiles(output).Length);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageExtractor.ExtractPackage(string, string, bool, bool)"/> method.
        /// </summary>
        [Fact]
        public void ExtractPackageOutputDirectoryExistsButEmptyWithOverwrite()
        {
            string package = Path.Combine(DataDirectory, "Package", "package.zip");
            string output = Path.Combine(TempDirectory, "output");

            Directory.CreateDirectory(output);

            Exception ex = Record.Exception(() => Extractor.ExtractPackage(package, output, true));

            Assert.Null(ex);
            Assert.Equal(3, Directory.GetFiles(output).Length);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageExtractor.ExtractPackage(string, string, bool, bool)"/> method
        ///     with an output directory which already exists, and with the overwrite option not used.
        /// </summary>
        [Fact]
        public void ExtractPackageOutputDirectoryExistsNoOverwrite()
        {
            string package = Path.Combine(DataDirectory, "Package", "package.zip");
            string output = Path.Combine(TempDirectory, "output");

            // create the output directory and a file within it
            Directory.CreateDirectory(output);
            File.WriteAllText(Path.Combine(output, "file.txt"), string.Empty);

            Exception ex = Record.Exception(() => Extractor.ExtractPackage(package, output));

            Assert.NotNull(ex);
            Assert.IsType<InvalidOperationException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageExtractor.ExtractPackage(string, string, bool, bool)"/> method
        ///     with an output directory which already exists, and with the overwrite option set to true.
        /// </summary>
        [Fact]
        public void ExtractPackageOutputDirectoryExistsWithOverwrite()
        {
            string package = Path.Combine(DataDirectory, "Package", "package.zip");
            string output = Path.Combine(TempDirectory, "output");

            Directory.CreateDirectory(output);

            Exception ex = Record.Exception(() => Extractor.ExtractPackage(package, output, true));

            Assert.Null(ex);
            Assert.Equal(3, Directory.GetFiles(output).Length);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageExtractor.ExtractPackage(string, string, bool, bool)"/> method
        ///     with a null output directory argument.
        /// </summary>
        [Fact]
        public void ExtractPackageOutputDirectoryNull()
        {
            string package = Path.Combine(DataDirectory, "Package", "package.zip");

            Exception ex = Record.Exception(() => Extractor.ExtractPackage(package, null));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageExtractor.ExtractPackage(string, string, bool, bool)"/> method
        ///     with a blank output directory argument.
        /// </summary>
        [Fact]
        public void ExtractPackagePackageBlank()
        {
            Exception ex = Record.Exception(() => Extractor.ExtractPackage(string.Empty, string.Empty));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageExtractor.ExtractPackage(string, string, bool, bool)"/> method
        ///     with a package file argument which contains an empty (zero byte) file.
        /// </summary>
        [Fact]
        public void ExtractPackagePackageEmpty()
        {
            string package = Path.Combine(DataDirectory, "Package", "emptypackage.zip");

            Exception ex = Record.Exception(() => Extractor.ExtractPackage(package, string.Empty));

            Assert.NotNull(ex);
            Assert.IsType<InvalidDataException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageExtractor.ExtractPackage(string, string, bool, bool)"/> method
        ///     with a package file argument which can not be found on the local file system.
        /// </summary>
        [Fact]
        public void ExtractPackagePackageNotFound()
        {
            Exception ex = Record.Exception(() => Extractor.ExtractPackage(Guid.NewGuid().ToString(), string.Empty));

            Assert.NotNull(ex);
            Assert.IsType<FileNotFoundException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageExtractor.ExtractPackage(string, string, bool, bool)"/> method
        ///     with a package file argument which contains a file that can not be read.
        /// </summary>
        [Fact]
        public void ExtractPackagePackageNotReadable()
        {
            string package = Path.Combine(DataDirectory, "Package", "package.zip");
            string temp = Path.Combine(TempDirectory, "package.zip");

            FileStream stream = default(FileStream);

            try
            {
                File.Copy(package, temp);

                stream = File.OpenWrite(temp);

                Exception ex = Record.Exception(() => Extractor.ExtractPackage(temp, string.Empty));

                Assert.NotNull(ex);
                Assert.IsType<IOException>(ex);
            }
            finally
            {
                stream?.Close();
            }
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageExtractor.ExtractPackage(string, string, bool, bool)"/> method
        ///     with a null package argument.
        /// </summary>
        [Fact]
        public void ExtractPackagePackageNull()
        {
            Exception ex = Record.Exception(() => Extractor.ExtractPackage(null, string.Empty));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageExtractor.ExtractPackage(string, string, bool, bool)"/> method
        ///     with the skip verification option set to true.
        /// </summary>
        [Fact]
        public void ExtractPackageSkipVerification()
        {
            string package = Path.Combine(DataDirectory, "Package", "package.zip");
            string output = Path.Combine(TempDirectory, "output");

            Exception ex = Record.Exception(() => Extractor.ExtractPackage(package, output, true, true));

            Assert.Null(ex);
            Assert.Equal(3, Directory.GetFiles(output).Length);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageExtractor.ExtractPackage(string, string, bool, bool)"/> method
        ///     with the Update event bound.
        /// </summary>
        [Fact]
        public void ExtractPackageWithUpdate()
        {
            Extractor.Updated += Extractor_Updated;

            string package = Path.Combine(DataDirectory, "Package", "package.zip");
            string output = Path.Combine(TempDirectory, "output");

            Exception ex = Record.Exception(() => Extractor.ExtractPackage(package, output));

            Assert.Null(ex);
            Assert.Equal(3, Directory.GetFiles(output).Length);
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        ///     Handles <see cref="PackagingOperation.Updated"/> events.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event args.</param>
        private void Extractor_Updated(object sender, Packaging.PackagingUpdateEventArgs e)
        {
        }

        #endregion Private Methods
    }
}