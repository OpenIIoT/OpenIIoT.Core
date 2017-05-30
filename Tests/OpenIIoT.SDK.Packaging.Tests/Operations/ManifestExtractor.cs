/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄▄▄▄███▄▄▄▄                                                                   ▄████████
      █    ▄██▀▀▀███▀▀▀██▄                                                                ███    ███
      █    ███   ███   ███   ▄█████  ██▄▄▄▄   █     ▄█████    ▄█████   ▄█████     ██      ███    █▀  ▀███  ▐██▀     ██       █████   ▄█████   ▄██████     ██     ██████     █████
      █    ███   ███   ███   ██   ██ ██▀▀▀█▄ ██    ██   ▀█   ██   █    ██  ▀  ▀███████▄  ▄███▄▄▄       ██  ██   ▀███████▄   ██  ██   ██   ██ ██    ██ ▀███████▄ ██    ██   ██  ██
      █    ███   ███   ███   ██   ██ ██   ██ ██▌  ▄██▄▄     ▄██▄▄      ██         ██  ▀ ▀▀███▀▀▀        ████▀       ██  ▀  ▄██▄▄█▀   ██   ██ ██    ▀      ██  ▀ ██    ██  ▄██▄▄█▀
      █    ███   ███   ███ ▀████████ ██   ██ ██  ▀▀██▀▀    ▀▀██▀▀    ▀███████     ██      ███    █▄     ████        ██    ▀███████ ▀████████ ██    ▄      ██    ██    ██ ▀███████
      █    ███   ███   ███   ██   ██ ██   ██ ██    ██        ██   █     ▄  ██     ██      ███    ███  ▄██ ▀██       ██      ██  ██   ██   ██ ██    ██     ██    ██    ██   ██  ██
      █     ▀█   ███   █▀    ██   █▀  █   █  █     ██        ███████  ▄████▀     ▄██▀     ██████████ ███    ██▄    ▄██▀     ██  ██   ██   █▀ ██████▀     ▄██▀    ██████    ██  ██
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
      █  Unit tests for the ManifestExtractor class.
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
using Newtonsoft.Json;
using OpenIIoT.SDK.Packaging.Manifest;
using Xunit;

namespace OpenIIoT.SDK.Packaging.Tests.Operations
{
    /// <summary>
    ///     Unit tests for the <see cref="Packaging.Operations.ManifestExtractor"/> class.
    /// </summary>
    public sealed class ManifestExtractor : IDisposable
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ManifestExtractor"/> class.
        /// </summary>
        public ManifestExtractor()
        {
            Extractor = new Packaging.Operations.ManifestExtractor();

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
        ///     Gets or sets the Manifest generator to test.
        /// </summary>
        private Packaging.Operations.ManifestExtractor Extractor { get; set; }

        /// <summary>
        ///     Gets or sets the temporary directory used for tests.
        /// </summary>
        private string TempDirectory { get; set; }

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        ///     Disposes this instance of <see cref="ManifestExtractor"/>.
        /// </summary>
        public void Dispose()
        {
            Directory.Delete(TempDirectory, true);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.ManifestExtractor.ExtractManifest(string, string)"/> method.
        /// </summary>
        [Fact]
        public void ExtractManifest()
        {
            PackageManifest manifest = Extractor.ExtractManifest(Path.Combine(DataDirectory, "Package", "package.zip"));

            Assert.NotNull(manifest);
            Assert.Equal("DefaultPlugin", manifest.Title);
            Assert.Equal(3, manifest.Files.Count);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.ManifestExtractor.ExtractManifest(string, string)"/> method with a
        ///     package with a known bad manifest file as input.
        /// </summary>
        [Fact]
        public void ExtractManifestBadManifest()
        {
            Exception ex = Record.Exception(() => Extractor.ExtractManifest(Path.Combine(DataDirectory, "Package", "badmanifest.zip")));

            Assert.NotNull(ex);
            Assert.IsType<JsonException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.ManifestExtractor.ExtractManifest(string, string)"/> method with an empty
        ///     string as input.
        /// </summary>
        [Fact]
        public void ExtractManifestBlankPackage()
        {
            Exception ex = Record.Exception(() => Extractor.ExtractManifest(string.Empty));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.ManifestExtractor.ExtractManifest(string, string)"/> method with a file
        ///     which is not a zip archive.
        /// </summary>
        [Fact]
        public void ExtractManifestNotAPackage()
        {
            Exception ex = Record.Exception(() => Extractor.ExtractManifest(Path.Combine(DataDirectory, "Package", "notapackage.zip")));

            Assert.NotNull(ex);
            Assert.IsType<IOException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.ManifestExtractor.ExtractManifest(string, string)"/> method with an input
        ///     package file known not to exist.
        /// </summary>
        [Fact]
        public void ExtractManifestNotFoundPackage()
        {
            Exception ex = Record.Exception(() => Extractor.ExtractManifest(Path.Combine(DataDirectory, Guid.NewGuid().ToString())));

            Assert.NotNull(ex);
            Assert.IsType<FileNotFoundException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.ManifestExtractor.ExtractManifest(string, string)"/> method with a null
        ///     value as input.
        /// </summary>
        [Fact]
        public void ExtractManifestNullPackage()
        {
            Exception ex = Record.Exception(() => Extractor.ExtractManifest(null));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.ManifestExtractor.ExtractManifest(string, string)"/> method with a
        ///     non-package zip file as input.
        /// </summary>
        [Fact]
        public void ExtractManifestPlainZip()
        {
            Exception ex = Record.Exception(() => Extractor.ExtractManifest(Path.Combine(DataDirectory, "Package", "plainzip.zip")));

            Assert.NotNull(ex);
            Assert.IsType<IOException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.ManifestExtractor.ExtractManifest(string, string)"/> method with an
        ///     invalid output file argument.
        /// </summary>
        [Fact]
        public void ExtractManifestToBadFile()
        {
            string inputFile = Path.Combine(DataDirectory, "Package", "package.zip");

            Exception ex = Record.Exception(() => Extractor.ExtractManifest(inputFile, "/"));

            Assert.NotNull(ex);
            Assert.IsType<Exception>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.ManifestExtractor.ExtractManifest(string, string)"/> method with a valid
        ///     output file argument
        /// </summary>
        [Fact]
        public void ExtractManifestToFile()
        {
            string inputFile = Path.Combine(DataDirectory, "Package", "package.zip");
            string outputFile = Path.Combine(TempDirectory, "manifest.json");

            PackageManifest manifest = Extractor.ExtractManifest(inputFile, outputFile);

            Assert.True(File.Exists(outputFile));
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.ManifestExtractor.ExtractManifest(string, string)"/> method with the
        ///     Update event bound.
        /// </summary>
        [Fact]
        public void ExtractManifestWithUpdate()
        {
            Extractor.Updated += Extractor_Updated;

            PackageManifest manifest = Extractor.ExtractManifest(Path.Combine(DataDirectory, "Package", "package.zip"));

            Assert.NotNull(manifest);
            Assert.Equal("DefaultPlugin", manifest.Title);
            Assert.Equal(3, manifest.Files.Count);
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