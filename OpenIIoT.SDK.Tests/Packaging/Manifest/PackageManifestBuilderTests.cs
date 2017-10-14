/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄███████▄                                                                 ▄▄▄▄███▄▄▄▄                                                                ▀█████████▄
      █     ███    ███                                                               ▄██▀▀▀███▀▀▀██▄                                                                ███    ███
      █     ███    ███   ▄█████   ▄██████    █  █▄     ▄█████     ▄████▄     ▄█████  ███   ███   ███   ▄█████  ██▄▄▄▄   █     ▄█████    ▄█████   ▄█████     ██      ███    ███ ██   █   █   █       ██████▄     ▄█████    █████
      █     ███    ███   ██   ██ ██    ██   ██ ▄██▀    ██   ██   ██    ▀    ██   █   ███   ███   ███   ██   ██ ██▀▀▀█▄ ██    ██   ▀█   ██   █    ██  ▀  ▀███████▄  ▄███▄▄▄██▀  ██   ██ ██  ██       ██   ▀██   ██   █    ██  ██
      █   ▀█████████▀    ██   ██ ██    ▀    ██▐█▀      ██   ██  ▄██        ▄██▄▄     ███   ███   ███   ██   ██ ██   ██ ██▌  ▄██▄▄     ▄██▄▄      ██         ██  ▀ ▀▀███▀▀▀██▄  ██   ██ ██▌ ██       ██    ██  ▄██▄▄     ▄██▄▄█▀
      █     ███        ▀████████ ██    ▄  ▀▀████     ▀████████ ▀▀██ ███▄  ▀▀██▀▀     ███   ███   ███ ▀████████ ██   ██ ██  ▀▀██▀▀    ▀▀██▀▀    ▀███████     ██      ███    ██▄ ██   ██ ██  ██       ██    ██ ▀▀██▀▀    ▀███████
      █     ███          ██   ██ ██    ██   ██ ▀██▄    ██   ██   ██    ██   ██   █   ███   ███   ███   ██   ██ ██   ██ ██    ██        ██   █     ▄  ██     ██      ███    ███ ██   ██ ██  ██▌    ▄ ██   ▄██   ██   █    ██  ██
      █    ▄████▀        ██   █▀ ██████▀    ▀█   ▀█▀   ██   █▀   ██████▀    ███████   ▀█   ███   █▀    ██   █▀  █   █  █     ██        ███████  ▄████▀     ▄██▀   ▄█████████▀  ██████  █   ████▄▄██ ██████▀    ███████   ██  ██
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
      █  Unit tests for the PackageManifestBuilder class.
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

namespace OpenIIoT.SDK.Tests.Packaging.Manifest
{
    using System.Collections.Generic;
    using OpenIIoT.SDK.Packaging.Manifest;
    using Xunit;

    /// <summary>
    ///     Unit tests for the <see cref="PackageManifest"/> class.
    /// </summary>
    public class PackageManifestBuilderTests
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PackageManifestBuilderTests"/> class.
        /// </summary>
        public PackageManifestBuilderTests()
        {
            Builder = new PackageManifestBuilder();
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        ///     Gets or sets the Builder under test.
        /// </summary>
        public PackageManifestBuilder Builder { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///     Tests the <see cref="PackageManifestBuilder.AddFile(PackageManifestFile)"/> method.
        /// </summary>
        [Fact]
        public void AddFile()
        {
            PackageManifestFile file = new PackageManifestFile()
            {
                Source = "source",
                Checksum = "checksum",
            };

            Builder.AddFile(file);

            Assert.Equal(1, Builder.Manifest.Files.Count);
            Assert.Equal("source", Builder.Manifest.Files[0].Source);
        }

        /// <summary>
        ///     Tests the <see cref="PackageManifestBuilder.AddFile(PackageManifestFile)"/> method with a file matching the type of
        ///     a previously added file.
        /// </summary>
        [Fact]
        public void AddFileExistingType()
        {
            PackageManifestFile file = new PackageManifestFile()
            {
                Source = "source",
                Checksum = "checksum",
            };

            PackageManifestFile file2 = new PackageManifestFile()
            {
                Source = "source2",
                Checksum = "checksum",
            };

            Builder.AddFile(file);
            Builder.AddFile(file2);

            Assert.Equal(2, Builder.Manifest.Files.Count);
            Assert.Equal("source", Builder.Manifest.Files[0].Source);
            Assert.Equal("source2", Builder.Manifest.Files[1].Source);
        }

        /// <summary>
        ///     Tests the <see cref="PackageManifestBuilder.BuildDefault"/> method.
        /// </summary>
        [Fact]
        public void BuildDefault()
        {
            PackageManifest manifest = Builder.BuildDefault().Manifest;

            Assert.NotEqual(string.Empty, manifest.Title);
            Assert.NotEqual(string.Empty, manifest.Version);
            Assert.NotEqual(string.Empty, manifest.Namespace);
            Assert.NotEqual(string.Empty, manifest.Description);
            Assert.NotEqual(string.Empty, manifest.Publisher);
            Assert.NotEqual(string.Empty, manifest.Copyright);
            Assert.NotEqual(string.Empty, manifest.License);
            Assert.NotEqual(string.Empty, manifest.Url);
        }

        /// <summary>
        ///     Tests the <see cref="PackageManifestBuilder.ClearFiles"/> method.
        /// </summary>
        [Fact]
        public void ClearFiles()
        {
            PackageManifestFile file = new PackageManifestFile()
            {
                Source = "source",
                Checksum = "checksum",
            };

            Builder.AddFile(file);

            Assert.Equal(1, Builder.Manifest.Files.Count);

            Builder.ClearFiles();

            Assert.Equal(0, Builder.Manifest.Files.Count);
        }

        /// <summary>
        ///     Tests the <see cref="PackageManifestBuilder.ClearFiles"/> method when the file list is empty.
        /// </summary>
        [Fact]
        public void ClearFilesNoFiles()
        {
            Builder.ClearFiles();

            Assert.Null(Builder.Manifest.Files);
        }

        /// <summary>
        ///     Tests the Constructor and all properties.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            PackageManifestBuilder test = new PackageManifestBuilder();

            Assert.NotNull(test.Manifest);
            Assert.Null(test.Manifest.Title);

            PackageManifest manifest = new PackageManifest();
            manifest.Title = "manifest";

            test = new PackageManifestBuilder(manifest);

            Assert.NotNull(test.Manifest);
            Assert.Equal(test.Manifest.Title, "manifest");
        }

        /// <summary>
        ///     Tests the <see cref="PackageManifestBuilder.Copyright(string)"/> method.
        /// </summary>
        [Fact]
        public void Copyright()
        {
            Assert.Null(Builder.Manifest.Copyright);

            PackageManifestBuilder builder = Builder.Copyright("Copyright");

            Assert.Same(builder, Builder);
            Assert.Equal("Copyright", Builder.Manifest.Copyright);
        }

        /// <summary>
        ///     Tests the <see cref="PackageManifestBuilder.Description(string)"/> method.
        /// </summary>
        [Fact]
        public void Description()
        {
            Assert.Null(Builder.Manifest.Description);

            PackageManifestBuilder builder = Builder.Description("Description");

            Assert.Same(builder, Builder);
            Assert.Equal("Description", Builder.Manifest.Description);
        }

        /// <summary>
        ///     Tests the <see cref="PackageManifestBuilder.Files(IList{PackageManifestFile})"/> method.
        /// </summary>
        [Fact]
        public void Files()
        {
            Assert.Null(Builder.Manifest.Files);

            IList<PackageManifestFile> files = new List<PackageManifestFile>();
            PackageManifestBuilder builder = Builder.Files(files);

            Assert.Same(builder, Builder);
            Assert.Same(files, Builder.Manifest.Files);
        }

        /// <summary>
        ///     Tests the <see cref="PackageManifestBuilder.License(string)"/> method.
        /// </summary>
        [Fact]
        public void License()
        {
            Assert.Null(Builder.Manifest.License);

            PackageManifestBuilder builder = Builder.License("License");

            Assert.Same(builder, Builder);
            Assert.Equal("License", Builder.Manifest.License);
        }

        /// <summary>
        ///     Tests the <see cref="PackageManifestBuilder.Namespace(string)"/> method.
        /// </summary>
        [Fact]
        public void Namespace()
        {
            Assert.Null(Builder.Manifest.Namespace);

            PackageManifestBuilder builder = Builder.Namespace("Namespace");

            Assert.Same(builder, Builder);
            Assert.Equal("Namespace", Builder.Manifest.Namespace);
        }

        /// <summary>
        ///     Tests the <see cref="PackageManifestBuilder.Publisher(string)"/> method.
        /// </summary>
        [Fact]
        public void Publisher()
        {
            Assert.Null(Builder.Manifest.Publisher);

            PackageManifestBuilder builder = Builder.Publisher("Publisher");

            Assert.Same(builder, Builder);
            Assert.Equal("Publisher", Builder.Manifest.Publisher);
        }

        /// <summary>
        ///     Tests the <see cref="PackageManifestBuilder.RemoveFile(PackageManifestFile)"/> method.
        /// </summary>
        [Fact]
        public void RemoveFile()
        {
            PackageManifestFile file = new PackageManifestFile()
            {
                Source = "source",
                Checksum = "checksum",
            };

            Builder.AddFile(file);

            Assert.Equal(1, Builder.Manifest.Files.Count);
            Assert.Equal("source", Builder.Manifest.Files[0].Source);

            Builder.RemoveFile(file);

            Assert.Equal(0, Builder.Manifest.Files.Count);
        }

        /// <summary>
        ///     Tests the <see cref="PackageManifestBuilder.RemoveFile(PackageManifestFile)"/> method when no files have yet been
        ///     added to the list.
        /// </summary>
        [Fact]
        public void RemoveFileNoFiles()
        {
            PackageManifestFile file = new PackageManifestFile()
            {
                Source = "source",
                Checksum = "checksum",
            };

            Builder.RemoveFile(file);

            Assert.Null(Builder.Manifest.Files);
        }

        /// <summary>
        ///     Tests the <see cref="PackageManifestBuilder.RemoveFile(PackageManifestFile)"/> method.
        /// </summary>
        [Fact]
        public void RemoveFileNotAdded()
        {
            PackageManifestFile file = new PackageManifestFile()
            {
                Source = "source",
                Checksum = "checksum",
            };

            PackageManifestFile file2 = new PackageManifestFile()
            {
                Source = "source2",
                Checksum = "checksum2",
            };

            Builder.AddFile(file);

            Assert.Equal(1, Builder.Manifest.Files.Count);
            Assert.Equal("source", Builder.Manifest.Files[0].Source);

            Builder.RemoveFile(file2);

            Assert.Equal(1, Builder.Manifest.Files.Count);
        }

        /// <summary>
        ///     Tests the <see cref="PackageManifestBuilder.Signature(PackageManifestSignature)"/> method.
        /// </summary>
        [Fact]
        public void Signature()
        {
            Assert.Null(Builder.Manifest.Signature);

            PackageManifestSignature signature = new PackageManifestSignature();
            PackageManifestBuilder builder = Builder.Signature(signature);

            Assert.Same(builder, Builder);
            Assert.Same(signature, Builder.Manifest.Signature);
        }

        /// <summary>
        ///     Tests the <see cref="PackageManifestBuilder.Title(string)"/> method.
        /// </summary>
        [Fact]
        public void Title()
        {
            Assert.Null(Builder.Manifest.Title);

            PackageManifestBuilder builder = Builder.Title("Title");

            Assert.Same(builder, Builder);
            Assert.Equal("Title", Builder.Manifest.Title);
        }

        /// <summary>
        ///     Tests the <see cref="PackageManifestBuilder.Url(string)"/> method.
        /// </summary>
        [Fact]
        public void Url()
        {
            Assert.Null(Builder.Manifest.Url);

            PackageManifestBuilder builder = Builder.Url("Url");

            Assert.Same(builder, Builder);
            Assert.Equal("Url", Builder.Manifest.Url);
        }

        /// <summary>
        ///     Tests the <see cref="PackageManifestBuilder.Version(string)"/> method.
        /// </summary>
        [Fact]
        public void Version()
        {
            Assert.Null(Builder.Manifest.Version);

            PackageManifestBuilder builder = Builder.Version("Version");

            Assert.Same(builder, Builder);
            Assert.Equal("Version", Builder.Manifest.Version);
        }

        #endregion Public Methods
    }
}