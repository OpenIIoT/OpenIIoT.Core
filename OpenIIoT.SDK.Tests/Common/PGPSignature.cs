/*
     █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
     █
     █      ▄███████▄    ▄██████▄     ▄███████▄    ▄████████
     █     ███    ███   ███    ███   ███    ███   ███    ███
     █     ███    ███   ███    █▀    ███    ███   ███    █▀   █     ▄████▄  ██▄▄▄▄    ▄█████      ██    ██   █     █████    ▄█████
     █     ███    ███  ▄███          ███    ███   ███        ██    ██    ▀  ██▀▀▀█▄   ██   ██ ▀███████▄ ██   ██   ██  ██   ██   █
     █   ▀█████████▀  ▀▀███ ████▄  ▀█████████▀  ▀███████████ ██▌  ▄██       ██   ██   ██   ██     ██  ▀ ██   ██  ▄██▄▄█▀  ▄██▄▄
     █     ███          ███    ███   ███                 ███ ██  ▀▀██ ███▄  ██   ██ ▀████████     ██    ██   ██ ▀███████ ▀▀██▀▀
     █     ███          ███    ███   ███           ▄█    ███ ██    ██    ██ ██   ██   ██   ██     ██    ██   ██   ██  ██   ██   █
     █    ▄████▀        ████████▀   ▄████▀       ▄████████▀  █     ██████▀   █   █    ██   █▀    ▄██▀   ██████    ██  ██   ███████
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
     █  Unit tests for the PGPSignature class.
     █
     █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀ ▀ ▀▀▀     ▀▀               ▀
     █  The MIT License (MIT)
     █
     █  Copyright (c) 2017 JP Dillingham (jp@dillingham.ws)
     █
     █  Permission is hereby granted, free of charge, to any person obtaining a copy
     █  of this software and associated documentation files (the "Software"), to deal
     █  in the Software without restriction, including without limitation the rights
     █  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
     █  copies of the Software, and to permit persons to whom the Software is
     █  furnished to do so, subject to the following conditions:
     █
     █  The above copyright notice and this permission notice shall be included in all
     █  copies or substantial portions of the Software.
     █
     █  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
     █  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
     █  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
     █  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
     █  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
     █  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
     █  SOFTWARE.
     █
     ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██
                                                                                                  ██
                                                                                              ▀█▄ ██ ▄█▀
                                                                                                ▀████▀
                                                                                                  ▀▀                            */

using System;
using System.IO;
using System.Text;
using Org.BouncyCastle.Bcpg.OpenPgp;
using Xunit;

namespace OpenIIoT.SDK.Tests.Common
{
    /// <summary>
    ///     Unit tests for the <see cref="PGPSignature"/> class.
    /// </summary>
    public class PGPSignature
    {
        #region Private Fields

        /// <summary>
        ///     The password for the private key file.
        /// </summary>
        private const string Password = "8&$gy$8rrPO^tbE1m5";

        /// <summary>
        ///     The contents of the new public key file.
        /// </summary>
        private string newPublicKey;

        /// <summary>
        ///     The contents of the private key file.
        /// </summary>
        private string privateKey;

        /// <summary>
        ///     The contents of the public key file.
        /// </summary>
        private string publicKey;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PGPSignature"/> class.
        /// </summary>
        public PGPSignature()
        {
            privateKey = File.ReadAllText(Path.Combine("Data", "Key", "privateKey.asc"));
            publicKey = File.ReadAllText(Path.Combine("Data", "Key", "publicKey.asc"));
            newPublicKey = File.ReadAllText(Path.Combine("Data", "Key", "newPublicKey.asc"));
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///     Tests the <see cref="SDK.Common.PGPSignature.Sign(byte[], string, string)"/> method.
        /// </summary>
        [Fact]
        public void Sign()
        {
            string text = "hello world!";

            byte[] bytes = Encoding.ASCII.GetBytes(text);
            byte[] signatureBytes = SDK.Common.PGPSignature.Sign(bytes, privateKey, Password);

            string signature = Encoding.ASCII.GetString(signatureBytes);

            Assert.NotNull(signature);
            Assert.NotEqual(string.Empty, signature);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Common.PGPSignature.Sign(byte[], string, string)"/> method with a blank string in place of
        ///     the password.
        /// </summary>
        /// <remarks>Assumes that the password is not an empty string.</remarks>
        [Fact]
        public void SignBadPassword()
        {
            Exception ex = Record.Exception(() => SDK.Common.PGPSignature.Sign(new byte[0], privateKey, string.Empty));

            Assert.NotNull(ex);
            Assert.IsType<PgpException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Common.PGPSignature.Sign(byte[], string, string)"/> method with a blank string in place of
        ///     the private key.
        /// </summary>
        [Fact]
        public void SignBlankKey()
        {
            Exception ex = Record.Exception(() => SDK.Common.PGPSignature.Sign(new byte[0], string.Empty, Password));

            Assert.NotNull(ex);
            Assert.IsType<PgpKeyValidationException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Common.PGPSignature.Sign(byte[], string, string)"/> method with null bytes.
        /// </summary>
        [Fact]
        public void SignNullBytes()
        {
            Exception ex = Record.Exception(() => SDK.Common.PGPSignature.Sign(null, privateKey, Password));

            Assert.NotNull(ex);
            Assert.IsType<NullReferenceException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Common.PGPSignature.Sign(byte[], string, string)"/> method with a null private key.
        /// </summary>
        [Fact]
        public void SignNullKey()
        {
            Exception ex = Record.Exception(() => SDK.Common.PGPSignature.Sign(new byte[0], null, Password));

            Assert.NotNull(ex);
            Assert.IsType<PgpKeyValidationException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Common.PGPSignature.Sign(byte[], string, string)"/> method with a null password.
        /// </summary>
        [Fact]
        public void SignNullPassword()
        {
            Exception ex = Record.Exception(() => SDK.Common.PGPSignature.Sign(new byte[0], privateKey, null));

            Assert.NotNull(ex);
            Assert.IsType<NullReferenceException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Common.PGPSignature.Sign(byte[], string, string)"/> method with a zero-length byte array.
        /// </summary>
        [Fact]
        public void SignZeroBytes()
        {
            byte[] signature = SDK.Common.PGPSignature.Sign(new byte[0], privateKey, Password);

            Assert.NotNull(Encoding.ASCII.GetString(signature));
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Common.PGPSignature.Verify(byte[], string)"/> method.
        /// </summary>
        [Fact]
        public void Verify()
        {
            string text = "hello world!";
            byte[] signature = GetSignature(text);

            Assert.NotNull(signature);
            Assert.NotEqual(0, signature.Length);

            byte[] message = SDK.Common.PGPSignature.Verify(signature, publicKey);

            Assert.NotNull(message);
            Assert.NotEqual(0, message.Length);
            Assert.Equal(text, Encoding.ASCII.GetString(message));
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Common.PGPSignature.Verify(byte[], string)"/> method with a known bad PGP public key.
        /// </summary>
        [Fact]
        public void VerifyBadKey()
        {
            string text = "hello world!";
            byte[] signature = GetSignature(text);

            Assert.NotNull(signature);
            Assert.NotEqual(0, signature.Length);

            Exception ex = Record.Exception(() => SDK.Common.PGPSignature.Verify(signature, string.Empty));

            Assert.NotNull(ex);
            Assert.IsType<PgpDataValidationException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Common.PGPSignature.Verify(byte[], string)"/> method with a known bad PGP signature.
        /// </summary>
        [Fact]
        public void VerifyBadSignature()
        {
            Exception ex = Record.Exception(() => SDK.Common.PGPSignature.Verify(new byte[0], publicKey));

            Assert.NotNull(ex);
            Assert.IsType<PgpDataValidationException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Common.PGPSignature.Verify(byte[], string)"/> method with null strings.
        /// </summary>
        [Fact]
        public void VerifyNulls()
        {
            Exception ex = Record.Exception(() => SDK.Common.PGPSignature.Verify(default(string), null));

            Assert.NotNull(ex);
            Assert.IsType<PgpDataValidationException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Common.PGPSignature.Verify(string, string)"/> method.
        /// </summary>
        [Fact]
        public void VerifyString()
        {
            string text = "hello again world!";
            string signature = GetSignatureString(text);

            Assert.NotNull(signature);
            Assert.NotEqual(string.Empty, signature);

            byte[] message = SDK.Common.PGPSignature.Verify(signature, publicKey);

            Assert.NotNull(message);
            Assert.NotEqual(0, message.Length);
            Assert.Equal(text, Encoding.ASCII.GetString(message));
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Common.PGPSignature.Verify(byte[], string)"/> method with a valid PGP public key that does
        ///     not match the private key which was used to generate the signature.
        /// </summary>
        [Fact]
        public void VerifyWrongKey()
        {
            string text = "hello world!";
            byte[] signature = GetSignature(text);

            Assert.NotNull(signature);
            Assert.NotEqual(0, signature.Length);

            Exception ex = Record.Exception(() => SDK.Common.PGPSignature.Verify(signature, newPublicKey));

            Assert.NotNull(ex);
            Assert.IsType<PgpDataValidationException>(ex);
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        ///     Returns a PGP signature of the specified text using the default private key.
        /// </summary>
        /// <param name="text">The text for which the signature will be generated.</param>
        /// <returns>The generated PGP signature.</returns>
        private byte[] GetSignature(string text)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(text);
            return SDK.Common.PGPSignature.Sign(bytes, privateKey, Password);
        }

        /// <summary>
        ///     Returns a PGP signature, in the form of a string, of the specified text using the default private key.
        /// </summary>
        /// <param name="text">The text for which the signature will be generated.</param>
        /// <returns>The generated PGP signature, in the form of a string.</returns>
        private string GetSignatureString(string text)
        {
            return Encoding.ASCII.GetString(GetSignature(text));
        }

        #endregion Private Methods
    }
}