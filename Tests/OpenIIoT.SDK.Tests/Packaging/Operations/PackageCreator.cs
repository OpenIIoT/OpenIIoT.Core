/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄███████▄                                                              ▄████████
      █     ███    ███                                                              ███    ███
      █     ███    ███   ▄█████   ▄██████    █  █▄     ▄█████     ▄████▄     ▄█████ ███    █▀     █████    ▄█████   ▄█████      ██     ██████     █████
      █     ███    ███   ██   ██ ██    ██   ██ ▄██▀    ██   ██   ██    ▀    ██   █  ███          ██  ██   ██   █    ██   ██ ▀███████▄ ██    ██   ██  ██
      █   ▀█████████▀    ██   ██ ██    ▀    ██▐█▀      ██   ██  ▄██        ▄██▄▄    ███         ▄██▄▄█▀  ▄██▄▄      ██   ██     ██  ▀ ██    ██  ▄██▄▄█▀
      █     ███        ▀████████ ██    ▄  ▀▀████     ▀████████ ▀▀██ ███▄  ▀▀██▀▀    ███    █▄  ▀███████ ▀▀██▀▀    ▀████████     ██    ██    ██ ▀███████
      █     ███          ██   ██ ██    ██   ██ ▀██▄    ██   ██   ██    ██   ██   █  ███    ███   ██  ██   ██   █    ██   ██     ██    ██    ██   ██  ██
      █    ▄████▀        ██   █▀ ██████▀    ▀█   ▀█▀   ██   █▀   ██████▀    ███████ ████████▀    ██  ██   ███████   ██   █▀    ▄██▀    ██████    ██  ██
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
      █  Unit tests for the PackageCreator class.
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
    ///     Unit tests for the <see cref="Packaging.Operations.PackageCreator"/> class.
    /// </summary>
    public sealed class PackageCreator : IDisposable
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PackageCreator"/> class.
        /// </summary>
        public PackageCreator()
        {
            Creator = new Packaging.Operations.PackageCreator();

            Uri codeBaseUri = new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            string codeBasePath = Uri.UnescapeDataString(codeBaseUri.AbsolutePath);

            DataDirectory = Path.Combine(Path.GetDirectoryName(codeBasePath), "Data");
            PayloadDirectory = Path.Combine(DataDirectory, "Payload");

            TempDirectory = Path.Combine(Path.GetTempPath(), GetType().Namespace.Split('.')[0], Guid.NewGuid().ToString());

            Directory.CreateDirectory(TempDirectory);
        }

        #endregion Public Constructors

        #region Private Properties

        /// <summary>
        ///     Gets or sets the Package Creator to test.
        /// </summary>
        private Packaging.Operations.PackageCreator Creator { get; set; }

        /// <summary>
        ///     Gets or sets the data directory used for tests.
        /// </summary>
        private string DataDirectory { get; set; }

        /// <summary>
        ///     Gets or sets the payload directory used for tests.
        /// </summary>
        private string PayloadDirectory { get; set; }

        /// <summary>
        ///     Gets or sets the temporary directory used for tests.
        /// </summary>
        private string TempDirectory { get; set; }

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageCreator.CreatePackage(string, string, string, bool)"/> method.
        /// </summary>
        [Fact]
        public void CreatePackage()
        {
            string manifest = Path.Combine(DataDirectory, "Manifest", "manifest.json");
            string package = Path.Combine(TempDirectory, "package.zip");

            Exception ex = Record.Exception(() => Creator.CreatePackage(PayloadDirectory, manifest, package));

            Assert.Null(ex);

            bool verified = false;

            ex = Record.Exception(() => verified = new Packaging.Operations.PackageVerifier().VerifyPackage(package));

            Assert.Null(ex);
            Assert.True(verified);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageCreator.CreatePackage(string, string, string, bool)"/> method with
        ///     a blank directory.
        /// </summary>
        [Fact]
        public void CreatePackageDirectoryBlank()
        {
            Exception ex = Record.Exception(() => Creator.CreatePackage(string.Empty, string.Empty, string.Empty));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageCreator.CreatePackage(string, string, string, bool)"/> method with
        ///     a directory containing no files.
        /// </summary>
        [Fact]
        public void CreatePackageDirectoryEmpty()
        {
            string directory = Path.Combine(TempDirectory, "empty");
            Directory.CreateDirectory(directory);

            Exception ex = Record.Exception(() => Creator.CreatePackage(directory, string.Empty, string.Empty));

            Assert.NotNull(ex);
            Assert.IsType<FileNotFoundException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageCreator.CreatePackage(string, string, string, bool)"/> method with
        ///     a directory which does not exist.
        /// </summary>
        [Fact]
        public void CreatePackageDirectoryNotFound()
        {
            Exception ex = Record.Exception(() => Creator.CreatePackage(Guid.NewGuid().ToString(), string.Empty, string.Empty));

            Assert.NotNull(ex);
            Assert.IsType<DirectoryNotFoundException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageCreator.CreatePackage(string, string, string, bool)"/> method with
        ///     a null directory.
        /// </summary>
        [Fact]
        public void CreatePackageDirectoryNull()
        {
            Exception ex = Record.Exception(() => Creator.CreatePackage(null, string.Empty, string.Empty));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageCreator.CreatePackage(string, string, string, bool)"/> method with
        ///     a manifest containing no data.
        /// </summary>
        [Fact]
        public void CreatePackageManifestEmpty()
        {
            string manifest = Path.Combine(DataDirectory, "Manifest", "blankmanifest.json");
            Exception ex = Record.Exception(() => Creator.CreatePackage(PayloadDirectory, manifest, string.Empty));

            Assert.NotNull(ex);
            Assert.IsType<InvalidDataException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageCreator.CreatePackage(string, string, string, bool)"/> method with
        ///     a manifest containing invalid json data.
        /// </summary>
        [Fact]
        public void CreatePackageManifestInvalid()
        {
            string manifest = Path.Combine(DataDirectory, "Manifest", "invalidmanifest.json");
            Exception ex = Record.Exception(() => Creator.CreatePackage(PayloadDirectory, manifest, string.Empty));

            Assert.NotNull(ex);
            Assert.IsType<FileLoadException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageCreator.CreatePackage(string, string, string, bool)"/> method with
        ///     a manifest which does not exist.
        /// </summary>
        [Fact]
        public void CreatePackageManifestNotFound()
        {
            Exception ex = Record.Exception(() => Creator.CreatePackage(PayloadDirectory, Guid.NewGuid().ToString(), string.Empty));

            Assert.NotNull(ex);
            Assert.IsType<FileNotFoundException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageCreator.CreatePackage(string, string, string, bool)"/> method with
        ///     a null manifest argument.
        /// </summary>
        [Fact]
        public void CreatePackageManifestNull()
        {
            Exception ex = Record.Exception(() => Creator.CreatePackage(PayloadDirectory, null, string.Empty));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageCreator.CreatePackage(string, string, string, bool)"/> method with
        ///     a manifest containing a file missing from the specified payload.
        /// </summary>
        [Fact]
        public void CreatePackageMissingFile()
        {
            string manifest = Path.Combine(DataDirectory, "Manifest", "missingfilemanifest.json");
            string package = Path.Combine(TempDirectory, "package.zip");

            Exception ex = Record.Exception(() => Creator.CreatePackage(PayloadDirectory, manifest, package));

            Assert.NotNull(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageCreator.CreatePackage(string, string, string, bool)"/> method with
        ///     a manifest containing no checksum properties for non-binary files.
        /// </summary>
        [Fact]
        public void CreatePackageNoChecksum()
        {
            string manifest = Path.Combine(DataDirectory, "Manifest", "nochecksummanifest.json");
            string package = Path.Combine(TempDirectory, "package.zip");

            Exception ex = Record.Exception(() => Creator.CreatePackage(PayloadDirectory, manifest, package));

            Assert.Null(ex);

            bool verified = false;

            ex = Record.Exception(() => verified = new Packaging.Operations.PackageVerifier().VerifyPackage(package));

            Assert.Null(ex);
            Assert.True(verified);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageCreator.CreatePackage(string, string, string, bool)"/> method with
        ///     a blank package argument.
        /// </summary>
        [Fact]
        public void CreatePackagePackageBlank()
        {
            string manifest = Path.Combine(DataDirectory, "Manifest", "manifest.json");
            string package = string.Empty;

            Exception ex = Record.Exception(() => Creator.CreatePackage(PayloadDirectory, manifest, package));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageCreator.CreatePackage(string, string, string, bool)"/> method with
        ///     a package argument containing a file which already exists.
        /// </summary>
        [Fact]
        public void CreatePackagePackageExists()
        {
            string manifest = Path.Combine(DataDirectory, "Manifest", "manifest.json");
            string package = Path.Combine(TempDirectory, "package.zip");

            File.WriteAllText(package, string.Empty);

            Exception ex = Record.Exception(() => Creator.CreatePackage(PayloadDirectory, manifest, package));

            Assert.NotNull(ex);
            Assert.IsType<InvalidOperationException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageCreator.CreatePackage(string, string, string, bool)"/> method with
        ///     a a package argument containing a file which already exists, and with the overwrite option set to true.
        /// </summary>
        [Fact]
        public void CreatePackagePackageExistsOverwrite()
        {
            string manifest = Path.Combine(DataDirectory, "Manifest", "manifest.json");
            string package = Path.Combine(TempDirectory, "package.zip");

            File.WriteAllText(package, string.Empty);

            Exception ex = Record.Exception(() => Creator.CreatePackage(PayloadDirectory, manifest, package, true));

            Assert.Null(ex);

            bool verified = false;

            ex = Record.Exception(() => verified = new Packaging.Operations.PackageVerifier().VerifyPackage(package));

            Assert.Null(ex);
            Assert.True(verified);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageCreator.CreatePackage(string, string, string, bool)"/> method with
        ///     a null package argument.
        /// </summary>
        [Fact]
        public void CreatePackagePackageNull()
        {
            string manifest = Path.Combine(DataDirectory, "Manifest", "manifest.json");
            string package = null;

            Exception ex = Record.Exception(() => Creator.CreatePackage(PayloadDirectory, manifest, package));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageCreator.CreatePackage(string, string, string, bool)"/> method with
        ///     the Update event bound.
        /// </summary>
        [Fact]
        public void CreatePackageWithUpdate()
        {
            Creator.Updated += Creator_Updated;

            string manifest = Path.Combine(DataDirectory, "Manifest", "manifest.json");
            string package = Path.Combine(TempDirectory, "package.zip");

            Exception ex = Record.Exception(() => Creator.CreatePackage(PayloadDirectory, manifest, package));

            Assert.Null(ex);

            bool verified = false;

            ex = Record.Exception(() => verified = new Packaging.Operations.PackageVerifier().VerifyPackage(package));

            Assert.Null(ex);
            Assert.True(verified);
        }

        /// <summary>
        ///     Tests the
        ///     <see cref="Packaging.Operations.PackageCreator.CreatePackage(string, string, string, bool, string, string, string, bool)"/>
        ///     method with arguments required to create a signed package.
        /// </summary>
        [Fact]
        public void CreateSignedPackage()
        {
            string manifest = Path.Combine(DataDirectory, "Manifest", "manifest.json");
            string package = Path.Combine(TempDirectory, "signedpackage.zip");
            string privateKeyFile = Path.Combine(DataDirectory, "Key", "private.asc");
            string privateKey = File.ReadAllText(privateKeyFile);
            string passphrase = File.ReadAllText(Path.Combine(DataDirectory, "Key", "passphrase.txt"));
            string keybaseUsername = File.ReadAllText(Path.Combine(DataDirectory, "Key", "keybaseUsername.txt"));

            Exception ex = Record.Exception(() => Creator.CreatePackage(PayloadDirectory, manifest, package, true, privateKey, passphrase, keybaseUsername));

            Assert.Null(ex);

            bool verified = false;

            ex = Record.Exception(() => verified = new Packaging.Operations.PackageVerifier().VerifyPackage(package));

            Assert.Null(ex);
            Assert.True(verified);
        }

        /// <summary>
        ///     Tests the
        ///     <see cref="Packaging.Operations.PackageCreator.CreatePackage(string, string, string, bool, string, string, string, bool)"/>
        ///     method with a blank keybaseUsername argument.
        /// </summary>
        [Fact]
        public void CreateSignedPackageKeybaseUsernameBlank()
        {
            string manifest = Path.Combine(DataDirectory, "Manifest", "manifest.json");
            string package = Path.Combine(TempDirectory, "signedpackage.zip");
            string privateKey = Path.Combine(DataDirectory, "Key", "private.asc");
            string passphrase = File.ReadAllText(Path.Combine(DataDirectory, "Key", "passphrase.txt"));
            string keybaseUsername = string.Empty;

            Exception ex = Record.Exception(() => Creator.CreatePackage(PayloadDirectory, manifest, package, true, privateKey, passphrase, keybaseUsername));

            Assert.NotNull(ex);
        }

        /// <summary>
        ///     Tests the
        ///     <see cref="Packaging.Operations.PackageCreator.CreatePackage(string, string, string, bool, string, string, string, bool)"/>
        ///     method with a null keybaseUsername argument.
        /// </summary>
        [Fact]
        public void CreateSignedPackageKeybaseUsernameNull()
        {
            string manifest = Path.Combine(DataDirectory, "Manifest", "manifest.json");
            string package = Path.Combine(TempDirectory, "signedpackage.zip");
            string privateKey = Path.Combine(DataDirectory, "Key", "private.asc");
            string passphrase = File.ReadAllText(Path.Combine(DataDirectory, "Key", "passphrase.txt"));
            string keybaseUsername = null;

            Exception ex = Record.Exception(() => Creator.CreatePackage(PayloadDirectory, manifest, package, true, privateKey, passphrase, keybaseUsername));

            Assert.NotNull(ex);
        }

        /// <summary>
        ///     Tests the
        ///     <see cref="Packaging.Operations.PackageCreator.CreatePackage(string, string, string, bool, string, string, string, bool)"/>
        ///     method with a blank passphrase argument.
        /// </summary>
        [Fact]
        public void CreateSignedPackagePassphraseBlank()
        {
            string manifest = Path.Combine(DataDirectory, "Manifest", "manifest.json");
            string package = Path.Combine(TempDirectory, "signedpackage.zip");
            string privateKey = Path.Combine(DataDirectory, "Key", "private.asc");
            string passphrase = string.Empty;
            string keybaseUsername = File.ReadAllText(Path.Combine(DataDirectory, "Key", "keybaseUsername.txt"));

            Exception ex = Record.Exception(() => Creator.CreatePackage(PayloadDirectory, manifest, package, true, privateKey, passphrase, keybaseUsername));

            Assert.NotNull(ex);
        }

        /// <summary>
        ///     Tests the
        ///     <see cref="Packaging.Operations.PackageCreator.CreatePackage(string, string, string, bool, string, string, string, bool)"/>
        ///     method with a password argument which does not match the specified PGP private key.
        /// </summary>
        [Fact]
        public void CreateSignedPackagePassphraseIncorrect()
        {
            string manifest = Path.Combine(DataDirectory, "Manifest", "manifest.json");
            string package = Path.Combine(TempDirectory, "signedpackage.zip");
            string privateKey = Path.Combine(DataDirectory, "Key", "private.asc");
            string passphrase = "incorrect";
            string keybaseUsername = File.ReadAllText(Path.Combine(DataDirectory, "Key", "keybaseUsername.txt"));

            Exception ex = Record.Exception(() => Creator.CreatePackage(PayloadDirectory, manifest, package, true, privateKey, passphrase, keybaseUsername));

            Assert.NotNull(ex);
        }

        /// <summary>
        ///     Tests the
        ///     <see cref="Packaging.Operations.PackageCreator.CreatePackage(string, string, string, bool, string, string, string, bool)"/>
        ///     method with a null passphrase argument.
        /// </summary>
        [Fact]
        public void CreateSignedPackagePassphraseNull()
        {
            string manifest = Path.Combine(DataDirectory, "Manifest", "manifest.json");
            string package = Path.Combine(TempDirectory, "signedpackage.zip");
            string privateKey = Path.Combine(DataDirectory, "Key", "private.asc");
            string passphrase = null;
            string keybaseUsername = File.ReadAllText(Path.Combine(DataDirectory, "Key", "keybaseUsername.txt"));

            Exception ex = Record.Exception(() => Creator.CreatePackage(PayloadDirectory, manifest, package, true, privateKey, passphrase, keybaseUsername));

            Assert.NotNull(ex);
        }

        /// <summary>
        ///     Tests the
        ///     <see cref="Packaging.Operations.PackageCreator.CreatePackage(string, string, string, bool, string, string, string, bool)"/>
        ///     method with a blank privateKey argument.
        /// </summary>
        [Fact]
        public void CreateSignedPackagePrivateKeyBlank()
        {
            string manifest = Path.Combine(DataDirectory, "Manifest", "manifest.json");
            string package = Path.Combine(TempDirectory, "signedpackage.zip");
            string privateKey = string.Empty;
            string passphrase = File.ReadAllText(Path.Combine(DataDirectory, "Key", "passphrase.txt"));
            string keybaseUsername = File.ReadAllText(Path.Combine(DataDirectory, "Key", "keybaseUsername.txt"));

            Exception ex = Record.Exception(() => Creator.CreatePackage(PayloadDirectory, manifest, package, true, privateKey, passphrase, keybaseUsername));

            Assert.NotNull(ex);
        }

        /// <summary>
        ///     Tests the
        ///     <see cref="Packaging.Operations.PackageCreator.CreatePackage(string, string, string, bool, string, string, string, bool)"/>
        ///     method with a privateKey argument containing a file which is blank.
        /// </summary>
        [Fact]
        public void CreateSignedPackagePrivateKeyEmptyFile()
        {
            string manifest = Path.Combine(DataDirectory, "Manifest", "manifest.json");
            string package = Path.Combine(TempDirectory, "signedpackage.zip");
            string privateKey = Path.Combine(DataDirectory, "empty.txt");
            string passphrase = File.ReadAllText(Path.Combine(DataDirectory, "Key", "passphrase.txt"));
            string keybaseUsername = File.ReadAllText(Path.Combine(DataDirectory, "Key", "keybaseUsername.txt"));

            Exception ex = Record.Exception(() => Creator.CreatePackage(PayloadDirectory, manifest, package, true, privateKey, passphrase, keybaseUsername));

            Assert.NotNull(ex);
        }

        /// <summary>
        ///     Tests the
        ///     <see cref="Packaging.Operations.PackageCreator.CreatePackage(string, string, string, bool, string, string, string, bool)"/>
        ///     method with a privateKey argument containing a file which does not exist.
        /// </summary>
        [Fact]
        public void CreateSignedPackagePrivateKeyNotFound()
        {
            string manifest = Path.Combine(DataDirectory, "Manifest", "manifest.json");
            string package = Path.Combine(TempDirectory, "signedpackage.zip");
            string privateKey = Path.Combine(DataDirectory, "Key", Guid.NewGuid().ToString());
            string passphrase = File.ReadAllText(Path.Combine(DataDirectory, "Key", "passphrase.txt"));
            string keybaseUsername = File.ReadAllText(Path.Combine(DataDirectory, "Key", "keybaseUsername.txt"));

            Exception ex = Record.Exception(() => Creator.CreatePackage(PayloadDirectory, manifest, package, true, privateKey, passphrase, keybaseUsername));

            Assert.NotNull(ex);
        }

        /// <summary>
        ///     Tests the
        ///     <see cref="Packaging.Operations.PackageCreator.CreatePackage(string, string, string, bool, string, string, string, bool)"/>
        ///     method with a null privateKey argument.
        /// </summary>
        [Fact]
        public void CreateSignedPackagePrivateKeyNull()
        {
            string manifest = Path.Combine(DataDirectory, "Manifest", "manifest.json");
            string package = Path.Combine(TempDirectory, "signedpackage.zip");
            string privateKey = null;
            string passphrase = File.ReadAllText(Path.Combine(DataDirectory, "Key", "passphrase.txt"));
            string keybaseUsername = File.ReadAllText(Path.Combine(DataDirectory, "Key", "keybaseUsername.txt"));

            Exception ex = Record.Exception(() => Creator.CreatePackage(PayloadDirectory, manifest, package, true, privateKey, passphrase, keybaseUsername));

            Assert.NotNull(ex);
        }

        /// <summary>
        ///     Disposes this instance of <see cref="PackageCreator"/>.
        /// </summary>
        public void Dispose()
        {
            Directory.Delete(TempDirectory, true);
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        ///     Handles <see cref="PackagingOperation.Updated"/> events.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event args.</param>
        private void Creator_Updated(object sender, Packaging.PackagingUpdateEventArgs e)
        {
        }

        #endregion Private Methods
    }
}