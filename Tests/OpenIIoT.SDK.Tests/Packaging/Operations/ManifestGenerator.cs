/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄▄▄▄███▄▄▄▄                                                                   ▄██████▄
      █    ▄██▀▀▀███▀▀▀██▄                                                                ███    ███
      █    ███   ███   ███   ▄█████  ██▄▄▄▄   █     ▄█████    ▄█████   ▄█████     ██      ███    █▀     ▄█████ ██▄▄▄▄     ▄█████    █████   ▄█████      ██     ██████     █████
      █    ███   ███   ███   ██   ██ ██▀▀▀█▄ ██    ██   ▀█   ██   █    ██  ▀  ▀███████▄  ▄███          ██   █  ██▀▀▀█▄   ██   █    ██  ██   ██   ██ ▀███████▄ ██    ██   ██  ██
      █    ███   ███   ███   ██   ██ ██   ██ ██▌  ▄██▄▄     ▄██▄▄      ██         ██  ▀ ▀▀███ ████▄   ▄██▄▄    ██   ██  ▄██▄▄     ▄██▄▄█▀   ██   ██     ██  ▀ ██    ██  ▄██▄▄█▀
      █    ███   ███   ███ ▀████████ ██   ██ ██  ▀▀██▀▀    ▀▀██▀▀    ▀███████     ██      ███    ███ ▀▀██▀▀    ██   ██ ▀▀██▀▀    ▀███████ ▀████████     ██    ██    ██ ▀███████
      █    ███   ███   ███   ██   ██ ██   ██ ██    ██        ██   █     ▄  ██     ██      ███    ███   ██   █  ██   ██   ██   █    ██  ██   ██   ██     ██    ██    ██   ██  ██
      █     ▀█   ███   █▀    ██   █▀  █   █  █     ██        ███████  ▄████▀     ▄██▀     ████████▀    ███████  █   █    ███████   ██  ██   ██   █▀    ▄██▀    ██████    ██  ██
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
      █  Unit tests for the ManifestGenerator class.
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
using System.Linq;
using OpenIIoT.SDK.Packaging.Manifest;
using Xunit;

namespace OpenIIoT.SDK.Packaging.Tests.Operations
{
    /// <summary>
    ///     Unit tests for the <see cref="Packaging.Operations.ManifestGenerator"/> class.
    /// </summary>
    public sealed class ManifestGenerator : IDisposable
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ManifestGenerator"/> class.
        /// </summary>
        public ManifestGenerator()
        {
            Generator = new Packaging.Operations.ManifestGenerator();
            TempDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

            Directory.CreateDirectory(TempDirectory);
        }

        #endregion Public Constructors

        #region Private Properties

        /// <summary>
        ///     Gets or sets the Manifest generator to test.
        /// </summary>
        private Packaging.Operations.ManifestGenerator Generator { get; set; }

        /// <summary>
        ///     Gets or sets the temporary directory used for tests.
        /// </summary>
        private string TempDirectory { get; set; }

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        ///     Disposes this instance of <see cref="ManifestGenerator"/>.
        /// </summary>
        public void Dispose()
        {
            Directory.Delete(TempDirectory, true);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Packaging.Operations.ManifestGenerator.GenerateManifest(string, bool, string)"/> method
        ///     with an empty string.
        /// </summary>
        [Fact]
        public void GenerateBlankDirectory()
        {
            Exception ex = Record.Exception(() => Generator.GenerateManifest(string.Empty));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Packaging.Operations.ManifestGenerator.GenerateManifest(string, bool, string)"/> method
        ///     with an empty directory.
        /// </summary>
        [Fact]
        public void GenerateEmptyDirectory()
        {
            Exception ex = Record.Exception(() => Generator.GenerateManifest(TempDirectory));

            Assert.NotNull(ex);
            Assert.IsType<FileNotFoundException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Packaging.Operations.ManifestGenerator.GenerateManifest(string, bool, string)"/> method
        ///     with a directory containing three files; one of each type.
        /// </summary>
        [Fact]
        public void GenerateManifest()
        {
            File.WriteAllText(Path.Combine(TempDirectory, "index.html"), " ");
            File.WriteAllText(Path.Combine(TempDirectory, "binary.dll"), " ");
            File.WriteAllText(Path.Combine(TempDirectory, "resource.bmp"), " ");

            PackageManifest manifest = Generator.GenerateManifest(TempDirectory, false);

            Assert.NotEmpty(manifest.Files);
            Assert.Equal(3, manifest.Files.Count);
            Assert.NotNull(manifest.Files.Select(f => f.Source == "index.html"));
            Assert.NotNull(manifest.Files.Select(f => f.Source == "binary.dll"));
            Assert.NotNull(manifest.Files.Select(f => f.Source == "resource.bmp"));
            Assert.False(manifest.Files.All(f => f.Checksum != null));
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Packaging.Operations.ManifestGenerator.GenerateManifest(string, bool, string)"/> method
        ///     with an output file containing an invalid character.
        /// </summary>
        [Fact]
        public void GenerateManifestToBadFile()
        {
            File.WriteAllText(Path.Combine(TempDirectory, "index.html"), " ");
            File.WriteAllText(Path.Combine(TempDirectory, "binary.dll"), " ");
            File.WriteAllText(Path.Combine(TempDirectory, "resource.bmp"), " ");

            Exception ex = Record.Exception(() => Generator.GenerateManifest(TempDirectory, true, Path.Combine(TempDirectory, "/")));

            Assert.NotNull(ex);
            Assert.IsType<Exception>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Packaging.Operations.ManifestGenerator.GenerateManifest(string, bool, string)"/> method
        ///     with a directory containing three files; one of each type, and with an output file specified.
        /// </summary>
        [Fact]
        public void GenerateManifestToFile()
        {
            File.WriteAllText(Path.Combine(TempDirectory, "index.html"), " ");
            File.WriteAllText(Path.Combine(TempDirectory, "binary.dll"), " ");
            File.WriteAllText(Path.Combine(TempDirectory, "resource.bmp"), " ");

            PackageManifest manifest = Generator.GenerateManifest(TempDirectory, true, Path.Combine(TempDirectory, "manifest.json"));

            Assert.NotEmpty(manifest.Files);
            Assert.Equal(3, manifest.Files.Count);
            Assert.NotNull(manifest.Files.Select(f => f.Source == "index.html"));
            Assert.NotNull(manifest.Files.Select(f => f.Source == "binary.dll"));
            Assert.NotNull(manifest.Files.Select(f => f.Source == "resource.bmp"));
            Assert.True(manifest.Files.All(f => f.Checksum != null));
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Packaging.Operations.ManifestGenerator.GenerateManifest(string, bool, string)"/> method
        ///     with a directory containing three files; one of each type, and using the checksum option.
        /// </summary>
        [Fact]
        public void GenerateManifestWithChecksums()
        {
            File.WriteAllText(Path.Combine(TempDirectory, "index.html"), " ");
            File.WriteAllText(Path.Combine(TempDirectory, "binary.dll"), " ");
            File.WriteAllText(Path.Combine(TempDirectory, "resource.bmp"), " ");

            PackageManifest manifest = Generator.GenerateManifest(TempDirectory, true);

            Assert.NotEmpty(manifest.Files);
            Assert.Equal(3, manifest.Files.Count);
            Assert.NotNull(manifest.Files.Select(f => f.Source == "index.html"));
            Assert.NotNull(manifest.Files.Select(f => f.Source == "binary.dll"));
            Assert.NotNull(manifest.Files.Select(f => f.Source == "resource.bmp"));
            Assert.True(manifest.Files.All(f => f.Checksum != null));
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Packaging.Operations.ManifestGenerator.GenerateManifest(string, bool, string)"/> method
        ///     with a directory containing three files; one of each type with the Update event bound.
        /// </summary>
        [Fact]
        public void GenerateManifestWithUpdate()
        {
            Generator.Updated += Generator_Updated;

            File.WriteAllText(Path.Combine(TempDirectory, "index.html"), " ");
            File.WriteAllText(Path.Combine(TempDirectory, "binary.dll"), " ");
            File.WriteAllText(Path.Combine(TempDirectory, "resource.bmp"), " ");

            PackageManifest manifest = Generator.GenerateManifest(TempDirectory);

            Assert.NotEmpty(manifest.Files);
            Assert.Equal(3, manifest.Files.Count);
            Assert.NotNull(manifest.Files.Select(f => f.Source == "index.html"));
            Assert.NotNull(manifest.Files.Select(f => f.Source == "binary.dll"));
            Assert.NotNull(manifest.Files.Select(f => f.Source == "resource.bmp"));
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Packaging.Operations.ManifestGenerator.GenerateManifest(string, bool, string)"/> method
        ///     with a directory which does not exist.
        /// </summary>
        [Fact]
        public void GenerateNonExistentDirectory()
        {
            Exception ex = Record.Exception(() => Generator.GenerateManifest("doesn't exist"));

            Assert.NotNull(ex);
            Assert.IsType<DirectoryNotFoundException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Packaging.Operations.ManifestGenerator.GenerateManifest(string, bool, string)"/> method
        ///     with a null directory.
        /// </summary>
        [Fact]
        public void GenerateNullDirectory()
        {
            Exception ex = Record.Exception(() => Generator.GenerateManifest(null));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        ///     Handles <see cref="PackagingOperation.Updated"/> events.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event args.</param>
        private void Generator_Updated(object sender, Packaging.PackagingUpdateEventArgs e)
        {
        }

        #endregion Private Methods
    }
}