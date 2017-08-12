/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄███████▄                                                                  ███
      █     ███    ███                                                              ▀█████████▄
      █     ███    ███   ▄█████   ▄██████    █  █▄     ▄█████     ▄████▄     ▄█████    ▀███▀▀██    █████ ██   █    ▄█████     ██       ▄█████    █████
      █     ███    ███   ██   ██ ██    ██   ██ ▄██▀    ██   ██   ██    ▀    ██   █      ███   ▀   ██  ██ ██   ██   ██  ▀  ▀███████▄   ██   █    ██  ██
      █   ▀█████████▀    ██   ██ ██    ▀    ██▐█▀      ██   ██  ▄██        ▄██▄▄        ███      ▄██▄▄█▀ ██   ██   ██         ██  ▀  ▄██▄▄     ▄██▄▄█▀
      █     ███        ▀████████ ██    ▄  ▀▀████     ▀████████ ▀▀██ ███▄  ▀▀██▀▀        ███     ▀███████ ██   ██ ▀███████     ██    ▀▀██▀▀    ▀███████
      █     ███          ██   ██ ██    ██   ██ ▀██▄    ██   ██   ██    ██   ██   █      ███       ██  ██ ██   ██    ▄  ██     ██      ██   █    ██  ██
      █    ▄████▀        ██   █▀ ██████▀    ▀█   ▀█▀   ██   █▀   ██████▀    ███████    ▄████▀     ██  ██ ██████   ▄████▀     ▄██▀     ███████   ██  ██
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
      █  Unit tests for the PackageTruster class.
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
using Xunit;
using Org.BouncyCastle.Bcpg.OpenPgp;

namespace OpenIIoT.SDK.Packaging.Tests.Operations
{
    /// <summary>
    ///     Unit tests for the <see cref="Packaging.Operations.PackageTruster"/> class.
    /// </summary>
    public sealed class PackageTruster : IDisposable
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PackageTruster"/> class.
        /// </summary>
        public PackageTruster()
        {
            Truster = new Packaging.Operations.PackageTruster();

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
        ///     Gets or sets the temporary directory used for tests.
        /// </summary>
        private string TempDirectory { get; set; }

        /// <summary>
        ///     Gets or sets the Package Truster to test.
        /// </summary>
        private Packaging.Operations.PackageTruster Truster { get; set; }

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        ///     Disposes this instance of <see cref="PackageTruster"/>.
        /// </summary>
        public void Dispose()
        {
            Directory.Delete(TempDirectory, true);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageTruster.TrustPackage(string, string, string)"/> method.
        /// </summary>
        [Fact]
        public void TrustPackage()
        {
            string package = Path.Combine(DataDirectory, "Package", "signedpackage.zip");
            string temp = Path.Combine(TempDirectory, "signedpackage.zip");
            string keyFile = Path.Combine(DataDirectory, "Key", "private.asc");
            string key = File.ReadAllText(keyFile);
            string passphrase = File.ReadAllText(Path.Combine(DataDirectory, "Key", "passphrase.txt"));
            string publicKey = File.ReadAllText(Path.Combine(DataDirectory, "Key", "public.asc"));

            File.Copy(package, temp);

            Exception ex = Record.Exception(() => Truster.TrustPackage(temp, key, passphrase));

            Assert.Null(ex);

            bool verified = false;

            Packaging.Operations.PackageVerifier verifier = new Packaging.Operations.PackageVerifier();
            verifier.TrustPGPPublicKey = publicKey;

            ex = Record.Exception(() => verified = verifier.VerifyPackage(temp));

            Assert.Null(ex);
            Assert.True(verified);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageTruster.TrustPackage(string, string, string)"/> method with a
        ///     package which contains a bad manifest.
        /// </summary>
        [Fact]
        public void TrustPackagePackageBadManifest()
        {
            string package = Path.Combine(DataDirectory, "Package", "badmanifest.zip");
            string temp = Path.Combine(TempDirectory, "package.zip");
            string keyFile = Path.Combine(DataDirectory, "Key", "private.asc");
            string key = File.ReadAllText(keyFile);
            string passphrase = File.ReadAllText(Path.Combine(DataDirectory, "Key", "passphrase.txt"));
            string publicKey = File.ReadAllText(Path.Combine(DataDirectory, "Key", "public.asc"));

            File.Copy(package, temp);

            Exception ex = Record.Exception(() => Truster.TrustPackage(temp, key, passphrase));

            Assert.NotNull(ex);
            Assert.IsType<JsonException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageTruster.TrustPackage(string, string, string)"/> method with an
        ///     empty package argument.
        /// </summary>
        [Fact]
        public void TrustPackagePackageEmpty()
        {
            Exception ex = Record.Exception(() => Truster.TrustPackage(string.Empty, "key", "passphrase"));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageTruster.TrustPackage(string, string, string)"/> method with a
        ///     package which is in use.
        /// </summary>
        [Fact]
        public void TrustPackagePackageInUse()
        {
            string package = Path.Combine(DataDirectory, "Package", "signedpackage.zip");
            string temp = Path.Combine(TempDirectory, "signedpackage.zip");
            string keyFile = Path.Combine(DataDirectory, "Key", "private.asc");
            string key = File.ReadAllText(keyFile);
            string passphrase = File.ReadAllText(Path.Combine(DataDirectory, "Key", "passphrase.txt"));
            string publicKey = File.ReadAllText(Path.Combine(DataDirectory, "Key", "public.asc"));

            File.Copy(package, temp);

            FileStream stream = File.Open(temp, FileMode.Open, FileAccess.Write, FileShare.None);

            Exception ex = Record.Exception(() => Truster.TrustPackage(temp, key, passphrase));

            Assert.NotNull(ex);
            Assert.IsType<IOException>(ex);

            stream?.Close();
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageTruster.TrustPackage(string, string, string)"/> method with a
        ///     package which is not a valid package.
        /// </summary>
        [Fact]
        public void TrustPackagePackageNotAPackage()
        {
            string package = Path.Combine(DataDirectory, "Package", "notapackage.zip");
            string temp = Path.Combine(TempDirectory, "package.zip");
            string keyFile = Path.Combine(DataDirectory, "Key", "private.asc");
            string key = File.ReadAllText(keyFile);
            string passphrase = File.ReadAllText(Path.Combine(DataDirectory, "Key", "passphrase.txt"));
            string publicKey = File.ReadAllText(Path.Combine(DataDirectory, "Key", "public.asc"));

            File.Copy(package, temp);

            Exception ex = Record.Exception(() => Truster.TrustPackage(temp, key, passphrase));

            Assert.NotNull(ex);
            Assert.IsType<IOException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageTruster.TrustPackage(string, string, string)"/> method with a
        ///     package argument which can't be found on the local filesystem.
        /// </summary>
        [Fact]
        public void TrustPackagePackageNotFound()
        {
            Exception ex = Record.Exception(() => Truster.TrustPackage(Guid.NewGuid().ToString(), "key", "passphrase"));

            Assert.NotNull(ex);
            Assert.IsType<FileNotFoundException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageTruster.TrustPackage(string, string, string)"/> method with a
        ///     package which has not been signed.
        /// </summary>
        [Fact]
        public void TrustPackagePackageNotSigned()
        {
            string package = Path.Combine(DataDirectory, "Package", "package.zip");
            string temp = Path.Combine(TempDirectory, "package.zip");
            string keyFile = Path.Combine(DataDirectory, "Key", "private.asc");
            string key = File.ReadAllText(keyFile);
            string passphrase = File.ReadAllText(Path.Combine(DataDirectory, "Key", "passphrase.txt"));
            string publicKey = File.ReadAllText(Path.Combine(DataDirectory, "Key", "public.asc"));

            File.Copy(package, temp);

            Exception ex = Record.Exception(() => Truster.TrustPackage(temp, key, passphrase));

            Assert.NotNull(ex);
            Assert.IsType<InvalidOperationException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageTruster.TrustPackage(string, string, string)"/> method with a null
        ///     package argument.
        /// </summary>
        [Fact]
        public void TrustPackagePackageNull()
        {
            Exception ex = Record.Exception(() => Truster.TrustPackage(null, "key", "passphrase"));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageTruster.TrustPackage(string, string, string)"/> method with an
        ///     empty passphrase argument.
        /// </summary>
        [Fact]
        public void TrustPackagePassphraseEmpty()
        {
            string package = Path.Combine(DataDirectory, "Package", "signedpackage.zip");
            string keyFile = Path.Combine(DataDirectory, "Key", "private.asc");
            string key = File.ReadAllText(keyFile);

            Exception ex = Record.Exception(() => Truster.TrustPackage(package, key, string.Empty));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageTruster.TrustPackage(string, string, string)"/> method with a
        ///     passphrase which does not match the key.
        /// </summary>
        [Fact]
        public void TrustPackagePassphraseMismatch()
        {
            string package = Path.Combine(DataDirectory, "Package", "signedpackage.zip");
            string keyFile = Path.Combine(DataDirectory, "Key", "private.asc");
            string key = File.ReadAllText(keyFile);

            Exception ex = Record.Exception(() => Truster.TrustPackage(package, key, "mismatch"));

            Assert.NotNull(ex);
            Assert.IsType<PgpException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageTruster.TrustPackage(string, string, string)"/> method with a null
        ///     passphrase argument.
        /// </summary>
        [Fact]
        public void TrustPackagePassphraseNull()
        {
            string package = Path.Combine(DataDirectory, "Package", "signedpackage.zip");
            string keyFile = Path.Combine(DataDirectory, "Key", "private.asc");
            string key = File.ReadAllText(keyFile);

            Exception ex = Record.Exception(() => Truster.TrustPackage(package, key, null));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageTruster.TrustPackage(string, string, string)"/> method with a
        ///     private key file which is empty.
        /// </summary>
        [Fact]
        public void TrustPackagePrivateKeyEmpty()
        {
            string package = Path.Combine(DataDirectory, "Package", "signedpackage.zip");

            Exception ex = Record.Exception(() => Truster.TrustPackage(package, string.Empty, "passphrase"));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageTruster.TrustPackage(string, string, string)"/> method with an
        ///     empty private key argument.
        /// </summary>
        [Fact]
        public void TrustPackagePrivateKeyEmptyFile()
        {
            string package = Path.Combine(DataDirectory, "Package", "signedpackage.zip");
            string keyFile = Path.Combine(DataDirectory, "empty.txt");
            string key = File.ReadAllText(keyFile);

            Exception ex = Record.Exception(() => Truster.TrustPackage(package, key, "passphrase"));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageTruster.TrustPackage(string, string, string)"/> method with a null
        ///     private key file.
        /// </summary>
        [Fact]
        public void TrustPackagePrivateKeyNull()
        {
            string package = Path.Combine(DataDirectory, "Package", "signedpackage.zip");

            Exception ex = Record.Exception(() => Truster.TrustPackage(package, null, "passphrase"));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageTruster.TrustPackage(string, string, string)"/> method with the
        ///     Update event bound.
        /// </summary>
        [Fact]
        public void TrustPackageWithUpdate()
        {
            string package = Path.Combine(DataDirectory, "Package", "signedpackage.zip");
            string temp = Path.Combine(TempDirectory, "signedpackage.zip");
            string keyFile = Path.Combine(DataDirectory, "Key", "private.asc");
            string key = File.ReadAllText(keyFile);
            string passphrase = File.ReadAllText(Path.Combine(DataDirectory, "Key", "passphrase.txt"));
            string publicKey = File.ReadAllText(Path.Combine(DataDirectory, "Key", "public.asc"));

            File.Copy(package, temp);

            Truster.Updated += Truster_Updated;

            Exception ex = Record.Exception(() => Truster.TrustPackage(temp, key, passphrase));

            Assert.Null(ex);

            bool verified = false;

            Packaging.Operations.PackageVerifier verifier = new Packaging.Operations.PackageVerifier();
            verifier.TrustPGPPublicKey = publicKey;

            ex = Record.Exception(() => verified = verifier.VerifyPackage(temp));

            Assert.Null(ex);
            Assert.True(verified);
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        ///     Handles <see cref="PackagingOperation.Updated"/> events.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event args.</param>
        private void Truster_Updated(object sender, Packaging.PackagingUpdateEventArgs e)
        {
        }

        #endregion Private Methods
    }
}