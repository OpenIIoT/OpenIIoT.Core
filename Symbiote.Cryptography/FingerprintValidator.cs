namespace Symbiote.Cryptography
{
    /// <summary>
    /// Validates Plugin and Plugin Archive fingerprints.
    /// </summary>
    public class FingerprintValidator
    {
        /// <summary>
        /// Computes the fingerprint of the provided fully qualified plugin name, version and optional Checksum and 
        /// compares it to the provided fingerprint.  Returns true if the computed and provided fingerprints
        /// match, false otherwise.
        /// </summary>
        /// <param name="fingerprint">The fingerprint against which to compare the computed fingerprint.</param>
        /// <param name="fqn">The Fully Qualified Name of the plugin to which the provided fingerprint belongs.</param>
        /// <param name="version">The plugin version.</param>
        /// <param name="checksum">The optional checksum for the plugin payload, specified when validating the fingerprint of a plugin archive.</param>
        /// <returns>True if the supplied and computed fingerprints match, false otherwise.</returns>
        public static bool Validate(string fingerprint, string fqn, string version, string checksum = "")
        {
            if (ComputeHash(fqn + version + checksum, GenerateSalt()) == fingerprint) return true;
            return false;
        }

        /// <summary>
        /// Computes a cryptographic hash of the provided text using the provided salt.
        /// </summary>
        /// <param name="text">The text to hash.</param>
        /// <param name="salt">The salt with which to seed the hash function.</param>
        /// <returns>The computed hash.</returns>
        private static string ComputeHash(string text, string salt = "")
        {
            if (salt == "") salt = GenerateSalt();
            byte[] binText = System.Text.Encoding.ASCII.GetBytes(text);
            byte[] binSalt = System.Text.Encoding.ASCII.GetBytes(salt);
            byte[] binSaltedText;

            if (binSalt.Length > 0)
            {
                binSaltedText = new byte[binText.Length + binSalt.Length];

                for (int i = 0; i < binText.Length; i++)
                    binSaltedText[i] = binText[i];

                for (int i = 0; i < binSalt.Length; i++)
                    binSaltedText[binText.Length + i] = binSalt[i];
            }
            else binSaltedText = binText;

            byte[] checksum = System.Security.Cryptography.SHA256.Create().ComputeHash(binSaltedText);

            System.Text.StringBuilder builtString = new System.Text.StringBuilder();
            foreach (byte b in checksum)
            {
                builtString.Append(b.ToString("x2"));
            }
            return builtString.ToString();
        }

        /// <summary>
        /// Generate the salt.  Nothing too fancy, just avoiding storing it in plain text.
        /// This is obviously easily cracked.
        /// </summary>
        /// <returns>The salt.</returns>
        private static string GenerateSalt()
        {
            int[] s = new int[] { 121, 97, 32, 103, 111, 116, 116, 97, 32, 117, 115, 101, 32, 97, 32, 115, 97, 108, 116, 32, 121, 97, 32, 100, 105, 110, 103, 117, 115, 33 };
            string r = "";

            foreach (int i in s)
                r += (char)i;

            return r;
        }
    }
}
