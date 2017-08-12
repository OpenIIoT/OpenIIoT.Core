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
▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
█████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
     ▄
     █  Provides methods used to sign and verify payloads using PGP public/private key encryption.
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
     █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀     ▀▀▀
     █  Dependencies:
     █     └─ BouncyCastle.OpenPgp (https://www.nuget.org/packages/BouncyCastle.OpenPGP/)
     █
     ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██
                                                                                                  ██
                                                                                              ▀█▄ ██ ▄█▀
                                                                                                ▀████▀
                                                                                                  ▀▀                            */

using System;
using System.IO;
using System.Linq;
using System.Text;
using Org.BouncyCastle.Bcpg;
using Org.BouncyCastle.Bcpg.OpenPgp;

namespace Utility.PGPSignatureTools
{
    /// <summary>
    ///     Provides methods used to sign and verify payloads using PGP public/private key encryption.
    /// </summary>
    public static class PGPSignature
    {
        #region Public Methods

        /// <summary>
        ///     Signs the specified byte array using the specified key after unlocking the key with the specified passphrase.
        /// </summary>
        /// <param name="bytes">The byte array containing the payload to sign.</param>
        /// <param name="key">The PGP key to be used to sign the payload.</param>
        /// <param name="passphrase">The passphrase used to unlock the PGP key.</param>
        /// <returns>A byte array containing the generated PGP signature.</returns>
        public static byte[] Sign(byte[] bytes, string key, string passphrase)
        {
            // prepare a memory stream to hold the signature
            MemoryStream memoryStream = new MemoryStream();

            // prepare an armored output stream to produce an armored ASCII signature
            Stream outputStream = new ArmoredOutputStream(memoryStream);

            // retrieve the keys
            PgpSecretKey secretKey = ReadSecretKeyFromString(key);
            PgpPrivateKey privateKey = secretKey.ExtractPrivateKey(passphrase.ToCharArray());

            // create and initialize a signature generator
            PgpSignatureGenerator signatureGenerator = new PgpSignatureGenerator(secretKey.PublicKey.Algorithm, HashAlgorithmTag.Sha512);
            signatureGenerator.InitSign(PgpSignature.BinaryDocument, privateKey);

            // retrieve the first user id contained within the public key and use it to set the signature signer
            foreach (string userId in secretKey.PublicKey.GetUserIds())
            {
                PgpSignatureSubpacketGenerator signatureSubpacketGenerator = new PgpSignatureSubpacketGenerator();
                signatureSubpacketGenerator.SetSignerUserId(false, userId);
                signatureGenerator.SetHashedSubpackets(signatureSubpacketGenerator.Generate());

                break;
            }

            // prepare a compressed data generator and compressed output stream to compress the data
            PgpCompressedDataGenerator compressedDataGenerator = new PgpCompressedDataGenerator(CompressionAlgorithmTag.ZLib);
            Stream compressedOutputStream = compressedDataGenerator.Open(outputStream);

            // generate the signature taken pretty much verbatim from the bouncycastle example; not sure what all of it does.
            BcpgOutputStream bcpgOutputStream = new BcpgOutputStream(compressedOutputStream);

            signatureGenerator.GenerateOnePassVersion(false).Encode(bcpgOutputStream);

            PgpLiteralDataGenerator literalDataGenerator = new PgpLiteralDataGenerator();
            Stream literalOutputStream = literalDataGenerator.Open(bcpgOutputStream, PgpLiteralData.Binary, "signatureData", DateTime.UtcNow, new byte[4092]);

            foreach (byte b in bytes)
            {
                literalOutputStream.WriteByte(b);
                signatureGenerator.Update(b);
            }

            literalDataGenerator.Close();

            signatureGenerator.Generate().Encode(bcpgOutputStream);

            compressedDataGenerator.Close();

            outputStream.Close();

            // fetch a byte array containing the contents of the memory stream
            byte[] retVal = memoryStream.ToArray();

            // close the memory stream
            memoryStream.Close();

            // return the generated signature
            return retVal;
        }

        /// <summary>
        ///     Verifies the specified signature using the specified public key.
        /// </summary>
        /// <param name="input">A byte array containing the signature to verify.</param>
        /// <param name="publicKey">The public key with which to decode the signature.</param>
        /// <returns>A byte array containing the message contained within the signature.</returns>
        /// <exception cref="PgpDataValidationException">
        ///     Thrown when the specified signature is invalid, or if an exception is encountered while validating.
        /// </exception>
        public static byte[] Verify(byte[] input, string publicKey)
        {
            return Verify(Encoding.ASCII.GetString(input), publicKey);
        }

        /// <summary>
        ///     Verifies the specified signature using the specified public key.
        /// </summary>
        /// <param name="input">The signature to verify.</param>
        /// <param name="publicKey">The public key with which to decode the signature.</param>
        /// <returns>A byte array containing the message contained within the signature.</returns>
        /// <exception cref="PgpDataValidationException">
        ///     Thrown when the specified signature is invalid, or if an exception is encountered while validating.
        /// </exception>
        public static byte[] Verify(string input, string publicKey)
        {
            // create input streams from
            Stream inputStream = new MemoryStream(Encoding.UTF8.GetBytes(input ?? string.Empty));
            Stream publicKeyStream = new MemoryStream(Encoding.UTF8.GetBytes(publicKey ?? string.Empty));

            // enclose all operations in a try/catch. if we encounter any exceptions verification fails.
            try
            {
                // lines taken pretty much verbatim from the bouncycastle example. not sure what it all does.
                inputStream = PgpUtilities.GetDecoderStream(inputStream);

                PgpObjectFactory pgpFact = new PgpObjectFactory(inputStream);
                PgpCompressedData c1 = (PgpCompressedData)pgpFact.NextPgpObject();
                pgpFact = new PgpObjectFactory(c1.GetDataStream());

                PgpOnePassSignatureList p1 = (PgpOnePassSignatureList)pgpFact.NextPgpObject();
                PgpOnePassSignature ops = p1[0];

                PgpLiteralData p2 = (PgpLiteralData)pgpFact.NextPgpObject();
                Stream dIn = p2.GetInputStream();
                PgpPublicKeyRingBundle pgpRing = new PgpPublicKeyRingBundle(PgpUtilities.GetDecoderStream(publicKeyStream));
                PgpPublicKey key = pgpRing.GetPublicKey(ops.KeyId);

                // set up a memorystream to contain the message contained within the signature
                MemoryStream memoryStream = new MemoryStream();

                ops.InitVerify(key);

                int ch;
                while ((ch = dIn.ReadByte()) >= 0)
                {
                    ops.Update((byte)ch);
                    memoryStream.WriteByte((byte)ch);
                }

                // save the contents of the memorystream to a byte array
                byte[] retVal = memoryStream.ToArray();

                memoryStream.Close();

                PgpSignatureList p3 = (PgpSignatureList)pgpFact.NextPgpObject();
                PgpSignature firstSig = p3[0];

                // verify.
                if (ops.Verify(firstSig))
                {
                    return retVal;
                }
                else
                {
                    throw new PgpDataValidationException();
                }
            }
            catch (Exception)
            {
                throw new PgpDataValidationException();
            }
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        ///     Reads and returns the PGP secret key from the specified input stream.
        /// </summary>
        /// <param name="input">The input stream containing the PGP secret key to be read.</param>
        /// <returns>The retrieved PGP secret key.</returns>
        private static PgpSecretKey ReadSecretKey(Stream input)
        {
            try
            {
                PgpSecretKeyRingBundle pgpSec = new PgpSecretKeyRingBundle(PgpUtilities.GetDecoderStream(input));
                PgpSecretKeyRing pgpKeyRing = pgpSec.GetKeyRings().OfType<PgpSecretKeyRing>().FirstOrDefault();
                PgpSecretKey pgpSecretKey = pgpKeyRing.GetSecretKeys().OfType<PgpSecretKey>().FirstOrDefault();

                if (pgpSecretKey.IsSigningKey)
                {
                    return pgpSecretKey;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                throw new PgpKeyValidationException("Can't find a valid signing key in the specified key ring.");
            }
        }

        /// <summary>
        ///     Reads and returns the PGP secret key from the specified key string.
        /// </summary>
        /// <param name="key">The key string from which the PGP secret key is to be read.</param>
        /// <returns>The retrieved PGP secret key.</returns>
        private static PgpSecretKey ReadSecretKeyFromString(string key)
        {
            return ReadSecretKey(new MemoryStream(Encoding.UTF8.GetBytes(key ?? string.Empty)));
        }

        #endregion Private Methods
    }
}