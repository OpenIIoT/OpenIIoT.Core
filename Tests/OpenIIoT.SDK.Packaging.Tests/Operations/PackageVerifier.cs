/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄███████▄                                                               ▄█    █▄
      █     ███    ███                                                              ███    ███
      █     ███    ███   ▄█████   ▄██████    █  █▄     ▄█████     ▄████▄     ▄█████ ███    ███    ▄█████    █████  █     ▄█████  █     ▄█████    █████
      █     ███    ███   ██   ██ ██    ██   ██ ▄██▀    ██   ██   ██    ▀    ██   █  ███    ███   ██   █    ██  ██ ██    ██   ▀█ ██    ██   █    ██  ██
      █   ▀█████████▀    ██   ██ ██    ▀    ██▐█▀      ██   ██  ▄██        ▄██▄▄    ███    ███  ▄██▄▄     ▄██▄▄█▀ ██▌  ▄██▄▄    ██▌  ▄██▄▄     ▄██▄▄█▀
      █     ███        ▀████████ ██    ▄  ▀▀████     ▀████████ ▀▀██ ███▄  ▀▀██▀▀    ███    ███ ▀▀██▀▀    ▀███████ ██  ▀▀██▀▀    ██  ▀▀██▀▀    ▀███████
      █     ███          ██   ██ ██    ██   ██ ▀██▄    ██   ██   ██    ██   ██   █   ██▄  ▄██    ██   █    ██  ██ ██    ██      ██    ██   █    ██  ██
      █    ▄████▀        ██   █▀ ██████▀    ▀█   ▀█▀   ██   █▀   ██████▀    ███████   ▀████▀     ███████   ██  ██ █     ██      █     ███████   ██  ██
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
      █  Unit tests for the PackageVerifier class.
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
using System.Net;
using Xunit;

namespace OpenIIoT.SDK.Packaging.Tests.Operations
{
    /// <summary>
    ///     Unit tests for the <see cref="Packaging.Operations.PackageVerifier"/> class.
    /// </summary>
    public sealed class PackageVerifier : IDisposable
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PackageVerifier"/> class.
        /// </summary>
        public PackageVerifier()
        {
            Verifier = new Packaging.Operations.PackageVerifier();

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
        ///     Gets or sets the Package Verifier to test.
        /// </summary>
        private Packaging.Operations.PackageVerifier Verifier { get; set; }

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        ///     Disposes this instance of <see cref="PackageVerifier"/>.
        /// </summary>
        public void Dispose()
        {
            Directory.Delete(TempDirectory, true);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageVerifier.VerifyPackage(string, string)"/> method.
        /// </summary>
        [Fact]
        public void VerifyPackage()
        {
            string package = Path.Combine(DataDirectory, "Package", "trustedpackage.zip");
            string publicKey = File.ReadAllText(Path.Combine(DataDirectory, "Key", "public.asc"));

            bool verified = false;

            Verifier.TrustPGPPublicKey = publicKey;

            Exception ex = Record.Exception(() => verified = Verifier.VerifyPackage(package));

            Assert.Null(ex);
            Assert.True(verified);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageVerifier.VerifyPackage(string, string)"/> method with an
        ///     explicitly defined public key.
        /// </summary>
        [Fact]
        public void VerifyPackageExplicitPublicKey()
        {
            string package = Path.Combine(DataDirectory, "Package", "trustedpackage.zip");
            string publicKeyFile = Path.Combine(DataDirectory, "Key", "public.asc");
            string publicKey = File.ReadAllText(Path.Combine(DataDirectory, "Key", "public.asc"));

            bool verified = false;

            Verifier.TrustPGPPublicKey = publicKey;

            Exception ex = Record.Exception(() => verified = Verifier.VerifyPackage(package, publicKeyFile));

            Assert.Null(ex);
            Assert.True(verified);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageVerifier.VerifyPackage(string, string)"/> method with an
        ///     explicitly defined public key which can not be found on the local filesystem.
        /// </summary>
        [Fact]
        public void VerifyPackageExplicitPublicKeyNotFound()
        {
            string package = Path.Combine(DataDirectory, "Package", "trustedpackage.zip");

            Exception ex = Record.Exception(() => Verifier.VerifyPackage(package, Guid.NewGuid().ToString()));

            Assert.NotNull(ex);
            Assert.IsType<FileNotFoundException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageVerifier.VerifyPackage(string, string)"/> method with an
        ///     explicitly defined public key which is an empty file.
        /// </summary>
        [Fact]
        public void VerifyPackageExplicitPublicKeyFileEmpty()
        {
            string package = Path.Combine(DataDirectory, "Package", "trustedpackage.zip");
            string publicKeyFile = Path.Combine(DataDirectory, "empty.txt");

            Exception ex = Record.Exception(() => Verifier.VerifyPackage(package, publicKeyFile));

            Assert.NotNull(ex);
            Assert.IsType<InvalidDataException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageVerifier.VerifyPackage(string, string)"/> method with an
        ///     explicitly defined public key which is in use by another process.
        /// </summary>
        [Fact]
        public void VerifyPackageExplicitPublicKeyCanNotRead()
        {
            string package = Path.Combine(DataDirectory, "Package", "trustedpackage.zip");
            string publicKeyFile = Path.Combine(DataDirectory, "Key", "public.asc");

            FileStream stream = default(FileStream);

            try
            {
                stream = File.Open(publicKeyFile, FileMode.Open, FileAccess.ReadWrite, FileShare.None);

                Exception ex = Record.Exception(() => Verifier.VerifyPackage(package, publicKeyFile));

                Assert.NotNull(ex);
                Assert.IsType<IOException>(ex);
            }
            finally
            {
                stream?.Close();
            }
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageVerifier.VerifyPackage(string, string)"/> method with an empty
        ///     package argument.
        /// </summary>
        [Fact]
        public void VerifyPackagePackageEmpty()
        {
            Exception ex = Record.Exception(() => Verifier.VerifyPackage(string.Empty));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageVerifier.VerifyPackage(string, string)"/> method with an empty
        ///     package file.
        /// </summary>
        [Fact]
        public void VerifyPackagePackageFileEmpty()
        {
            string package = Path.Combine(DataDirectory, "Package", "emptypackage.zip");

            Exception ex = Record.Exception(() => Verifier.VerifyPackage(package));

            Assert.NotNull(ex);
            Assert.IsType<InvalidDataException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageVerifier.VerifyPackage(string, string)"/> method with a package
        ///     file containing a payload and manifest with mismatched checksums.
        /// </summary>
        [Fact]
        public void VerifyPackagePackageBadChecksum()
        {
            string package = Path.Combine(DataDirectory, "Package", "badchecksum.zip");

            Exception ex = Record.Exception(() => Verifier.VerifyPackage(package));

            Assert.NotNull(ex);
            Assert.IsType<Exception>(ex);
            Assert.IsType<InvalidDataException>(ex.InnerException);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageVerifier.VerifyPackage(string, string)"/> method with a package
        ///     file containing a malformed manifest.
        /// </summary>
        [Fact]
        public void VerifyPackagePackageBadManifest()
        {
            string package = Path.Combine(DataDirectory, "Package", "badmanifest.zip");

            Exception ex = Record.Exception(() => Verifier.VerifyPackage(package));

            Assert.NotNull(ex);
            Assert.IsType<Exception>(ex);
            Assert.IsType<InvalidDataException>(ex.InnerException);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageVerifier.VerifyPackage(string, string)"/> method with a package
        ///     file containing an empty payload.
        /// </summary>
        [Fact]
        public void VerifyPackagePackageEmptyPayload()
        {
            string package = Path.Combine(DataDirectory, "Package", "emptypayload.zip");

            Exception ex = Record.Exception(() => Verifier.VerifyPackage(package));

            Assert.NotNull(ex);
            Assert.IsType<Exception>(ex);
            Assert.IsType<InvalidDataException>(ex.InnerException);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageVerifier.VerifyPackage(string, string)"/> method with a package
        ///     file containing an invalid digest.
        /// </summary>
        [Fact]
        public void VerifyPackagePackageBadDigest()
        {
            string package = Path.Combine(DataDirectory, "Package", "baddigest.zip");

            Exception ex = Record.Exception(() => Verifier.VerifyPackage(package));

            Assert.NotNull(ex);
            Assert.IsType<Exception>(ex);
            Assert.IsType<InvalidDataException>(ex.InnerException);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageVerifier.VerifyPackage(string, string)"/> method with a package
        ///     file containing a file which does not match it's manifest checksum.
        /// </summary>
        [Fact]
        public void VerifyPackagePackageBadFileChecksum()
        {
            string package = Path.Combine(DataDirectory, "Package", "badfilechecksum.zip");

            Exception ex = Record.Exception(() => Verifier.VerifyPackage(package));

            Assert.NotNull(ex);
            Assert.IsType<Exception>(ex);
            Assert.IsType<InvalidDataException>(ex.InnerException);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageVerifier.VerifyPackage(string, string)"/> method with a package
        ///     file signed with an invalid keybase username.
        /// </summary>
        [Fact]
        public void VerifyPackagePackageInvalidKeybaseUsername()
        {
            string package = Path.Combine(DataDirectory, "Package", "invalidkeybaseusername.zip");

            Exception ex = Record.Exception(() => Verifier.VerifyPackage(package));

            Assert.NotNull(ex);
            Assert.IsType<Exception>(ex);
            Assert.IsType<WebException>(ex.InnerException);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageVerifier.VerifyPackage(string, string)"/> method with a package
        ///     file containing which is missing a file from the manifest.
        /// </summary>
        [Fact]
        public void VerifyPackagePackageMissingFile()
        {
            string package = Path.Combine(DataDirectory, "Package", "missingfile.zip");

            Exception ex = Record.Exception(() => Verifier.VerifyPackage(package));

            Assert.NotNull(ex);
            Assert.IsType<Exception>(ex);
            Assert.IsType<FileNotFoundException>(ex.InnerException);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageVerifier.VerifyPackage(string, string)"/> method with a package
        ///     file containing a blank digest.
        /// </summary>
        [Fact]
        public void VerifyPackagePackageBlankDigest()
        {
            string package = Path.Combine(DataDirectory, "Package", "blankdigest.zip");

            Exception ex = Record.Exception(() => Verifier.VerifyPackage(package));

            Assert.NotNull(ex);
            Assert.IsType<Exception>(ex);
            Assert.IsType<InvalidDataException>(ex.InnerException);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageVerifier.VerifyPackage(string, string)"/> method with a package
        ///     file containing a blank trust.
        /// </summary>
        [Fact]
        public void VerifyPackagePackageBlankTrust()
        {
            string package = Path.Combine(DataDirectory, "Package", "blanktrust.zip");

            Exception ex = Record.Exception(() => Verifier.VerifyPackage(package));

            Assert.NotNull(ex);
            Assert.IsType<Exception>(ex);
            Assert.IsType<InvalidDataException>(ex.InnerException);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageVerifier.VerifyPackage(string, string)"/> method with a package
        ///     file containing a trust which is valid but does not match the digest.
        /// </summary>
        [Fact]
        public void VerifyPackagePackageTrustDigestMismatch()
        {
            string package = Path.Combine(DataDirectory, "Package", "trustdigestmismatch.zip");
            string publicKey = File.ReadAllText(Path.Combine(DataDirectory, "Key", "public.asc"));

            Verifier.TrustPGPPublicKey = publicKey;

            Exception ex = Record.Exception(() => Verifier.VerifyPackage(package));

            Assert.NotNull(ex);
            Assert.IsType<Exception>(ex);
            Assert.IsType<InvalidDataException>(ex.InnerException);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageVerifier.VerifyPackage(string, string)"/> method with a package
        ///     file containing an invalid trust.
        /// </summary>
        [Fact]
        public void VerifyPackagePackageBadTrust()
        {
            string package = Path.Combine(DataDirectory, "Package", "badtrust.zip");

            Exception ex = Record.Exception(() => Verifier.VerifyPackage(package));

            Assert.NotNull(ex);
            Assert.IsType<Exception>(ex);
            Assert.IsType<InvalidDataException>(ex.InnerException);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageVerifier.VerifyPackage(string, string)"/> method with a package
        ///     file which is trusted but contains a blank digest.
        /// </summary>
        [Fact]
        public void VerifyPackagePackageTrustedBlankDigest()
        {
            string package = Path.Combine(DataDirectory, "Package", "trustednodigest.zip");

            Exception ex = Record.Exception(() => Verifier.VerifyPackage(package));

            Assert.NotNull(ex);
            Assert.IsType<Exception>(ex);
            Assert.IsType<InvalidDataException>(ex.InnerException);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageVerifier.VerifyPackage(string, string)"/> method with a package
        ///     file containing a digest which does not match the manifest.
        /// </summary>
        [Fact]
        public void VerifyPackagePackageManifestDigestMismatch()
        {
            string package = Path.Combine(DataDirectory, "Package", "manifestdigestmismatch.zip");

            Exception ex = Record.Exception(() => Verifier.VerifyPackage(package));

            Assert.NotNull(ex);
            Assert.IsType<Exception>(ex);
            Assert.IsType<InvalidDataException>(ex.InnerException);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageVerifier.VerifyPackage(string, string)"/> method with a package
        ///     file without a manifest.
        /// </summary>
        [Fact]
        public void VerifyPackagePackageNoManifest()
        {
            string package = Path.Combine(DataDirectory, "Package", "plainzip.zip");

            Exception ex = Record.Exception(() => Verifier.VerifyPackage(package));

            Assert.NotNull(ex);
            Assert.IsType<Exception>(ex);
            Assert.IsType<FileNotFoundException>(ex.InnerException);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageVerifier.VerifyPackage(string, string)"/> method with a plain zip
        ///     file not containing a manifest or payload.
        /// </summary>
        [Fact]
        public void VerifyPackagePackageNoPayload()
        {
            string package = Path.Combine(DataDirectory, "Package", "nopayload.zip");

            Exception ex = Record.Exception(() => Verifier.VerifyPackage(package));

            Assert.NotNull(ex);
            Assert.IsType<Exception>(ex);
            Assert.IsType<FileNotFoundException>(ex.InnerException);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageVerifier.VerifyPackage(string, string)"/> method with a package
        ///     argument containing a file which can not be found on the local filesystem.
        /// </summary>
        [Fact]
        public void VerifyPackagePackageNotFound()
        {
            Exception ex = Record.Exception(() => Verifier.VerifyPackage(Guid.NewGuid().ToString()));

            Assert.NotNull(ex);
            Assert.IsType<FileNotFoundException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageVerifier.VerifyPackage(string, string)"/> method with a null
        ///     package argument.
        /// </summary>
        [Fact]
        public void VerifyPackagePackageNull()
        {
            Exception ex = Record.Exception(() => Verifier.VerifyPackage(null));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Packaging.Operations.PackageVerifier.VerifyPackage(string, string)"/> method with the Update
        ///     event bound.
        /// </summary>
        [Fact]
        public void VerifyPackageWithUpdate()
        {
            string package = Path.Combine(DataDirectory, "Package", "trustedpackage.zip");
            string publicKey = File.ReadAllText(Path.Combine(DataDirectory, "Key", "public.asc"));

            bool verified = false;

            Verifier.TrustPGPPublicKey = publicKey;
            Verifier.Updated += Verifier_Updated;

            Exception ex = Record.Exception(() => verified = Verifier.VerifyPackage(package));

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
        private void Verifier_Updated(object sender, Packaging.PackagingUpdateEventArgs e)
        {
        }

        #endregion Private Methods
    }
}