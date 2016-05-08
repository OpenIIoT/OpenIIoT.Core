using System.Collections.Generic;

namespace Symbiote.Core
{
    /// <summary>
    /// BigFont transforms strings into large, stylized characters.
    /// </summary>
    static class BigFont
    {
        #region Variables

        /// <summary>
        /// The header string used for styled output.
        /// </summary>
        private static string header = "+----------------------------------- -   -----------------  - -   -             -------  -";

        /// <summary>
        /// The line prefix used for styled output.
        /// </summary>
        private static string linePrefix = "| ";

        /// <summary>
        /// The footer string used for styled output.
        /// </summary>
        private static string footer = "+-------- - -      ------------------ -  -- - -   ------------ - - - ---------  - -----------------    -";

        /// <summary>
        /// The height (in lines) of the characters in the alphabet.
        /// </summary>
        private static int height = 8;

        /// <summary>
        /// The alphabet.
        /// </summary>
        private static Dictionary<char, string[]> alphabet = new Dictionary<char, string[]>();

        #endregion

        #region Constructors

        /// <summary>
        /// The default constructor.  Initializes the alphabet.
        /// </summary>
        static BigFont()
        {
            alphabet.Add('A', new string[]
            {
                "  ▄████████  ",
                "  ███    ███ ",
                "  ███    ███ ",
                "  ███    ███ ",
                "▀███████████ ",
                "  ███    ███ ",
                "  ███    ███ ",
                "  ███    █▀  "
            });

            alphabet.Add('B', new string[]
            {
                "▀█████████▄  ",
                "  ███    ███ ",
                "  ███    ███ ",
                " ▄███▄▄▄██▀  ",
                "▀▀███▀▀▀██▄  ",
                "  ███    ██▄ ",
                "  ███    ███ ",
                "▄█████████▀  "
            });

            alphabet.Add('C', new string[]
            {
                "▄████████  ",
                "███    ███ ",
                "███    █▀  ",
                "███        ",
                "███        ",
                "███    █▄  ",
                "███    ███ ",
                "████████▀  "
            });

            alphabet.Add('D', new string[]
            {
                "████████▄  ",
                "███   ▀███ ",
                "███    ███ ",
                "███    ███ ",
                "███    ███ ",
                "███    ███ ",
                "███   ▄███ ",
                "████████▀  "
            });

            alphabet.Add('E', new string[]
            {
                "   ▄████████ ",
                "  ███    ███ ",
                "  ███    █▀  ",
                " ▄███▄▄▄     ",
                "▀▀███▀▀▀     ",
                "  ███    █▄  ",
                "  ███    ███ ",
                "  ██████████ "
            });

            alphabet.Add('F', new string[]
            {
                "   ▄████████ ",
                "  ███    ███ ",
                "  ███    █▀  ",
                " ▄███▄▄▄     ",
                "▀▀███▀▀▀     ",
                "  ███        ",
                "  ███        ",
                "  ███        "
            });

            alphabet.Add('G', new string[]
            {
                "   ▄██████▄  ",
                "  ███    ███ ",
                "  ███    █▀  ",
                " ▄███        ",
                "▀▀███ ████▄  ",
                "  ███    ███ ",
                "  ███    ███ ",
                "  ████████▀  "
            });

            alphabet.Add('H', new string[] 
            {
                "   ▄█    █▄    ",
                "  ███    ███   ",
                "  ███    ███   ",
                " ▄███▄▄▄▄███▄▄ ",
                "▀▀███▀▀▀▀███▀  ",
                "  ███    ███   ",
                "  ███    ███   ",
                "  ███    █▀    "
            });

            alphabet.Add('I', new string[] 
            {
                " ▄█  ",
                "███  ",
                "███▌ ",
                "███▌ ",
                "███▌ ",
                "███  ",
                "███  ",
                "█▀   "
            });

            alphabet.Add('J', new string[]
            {
                "     ▄█ ",
                "    ███ ",
                "    ███ ",
                "    ███ ",
                "    ███ ",
                "    ███ ",
                "    ███ ",
                "█▄ ▄███ ",
                "▀▀▀▀▀▀  "
            });

            alphabet.Add('K', new string[]
            {
                "   ▄█   ▄█▄ ",
                "  ███ ▄███▀ ",
                "  ███▐██▀   ",
                " ▄█████▀    ",
                "▀▀█████▄    ",
                "  ███▐██▄   ",
                "  ███ ▀███▄ ",
                "  ███   ▀█▀ ",
                "  ▀         "
            });

            alphabet.Add('L', new string[]
            {
                " ▄█       ",
                "███       ",
                "███       ",
                "███       ",
                "███       ",
                "███       ",
                "███▌    ▄ ",
                "█████▄▄██ ",
                "▀         "
            });

            alphabet.Add('M', new string[]
            {
                "   ▄▄▄▄███▄▄▄▄   ",
                " ▄██▀▀▀███▀▀▀██▄ ",
                " ███   ███   ███ ",
                " ███   ███   ███ ",
                " ███   ███   ███ ",
                " ███   ███   ███ ",
                " ███   ███   ███ ",
                "  ▀█   ███   █▀  "

            });

            alphabet.Add('N', new string[]
            {
                "███▄▄▄▄   ",
                "███▀▀▀██▄ ",
                "███   ███ ",
                "███   ███ ",
                "███   ███ ",
                "███   ███ ",
                "███   ███ ",
                " ▀█   █▀  "
            });

            alphabet.Add('O', new string[]
            {
                " ▄██████▄  ",
                "███    ███ ",
                "███    ███ ",
                "███    ███ ",
                "███    ███ ",
                "███    ███ ",
                "███    ███ ",
                " ▀██████▀  "
            });

            alphabet.Add('P', new string[]
            {
                "   ▄███████▄ ",
                "  ███    ███ ",
                "  ███    ███ ",
                "  ███    ███ ",
                "▀█████████▀  ",
                "  ███        ",
                "  ███        ",
                " ▄████▀      "
            });

            alphabet.Add('Q', new string[]
            {
                "████████▄   ",
                "███    ███  ",
                "███    ███  ",
                "███    ███  ",
                "███    ███  ",
                "███    ███  ",
                "███  ▀ ███  ",
                " ▀██████▀▄█ "
            });

            alphabet.Add('R', new string[]
            {
                "   ▄████████ ",
                "  ███    ███ ",
                "  ███    ███ ",
                " ▄███▄▄▄▄██▀ ",
                "▀▀███▀▀▀▀▀   ",
                "▀███████████ ",
                "  ███    ███ ",
                "  ███    ███ ",
                "  ███    ███ "
            });

            alphabet.Add('S', new string[]
            {
                "   ▄████████ ",
                "  ███    ███ ",
                "  ███    █▀  ",
                "  ███        ",
                "▀███████████ ",
                "         ███ ",
                "   ▄█    ███ ",
                " ▄████████▀  "
            });

            alphabet.Add('T', new string[]
            {
                "    ███     ",
                "▀█████████▄ ",
                "   ▀███▀▀██ ",
                "    ███   ▀ ",
                "    ███     ",
                "    ███     ",
                "    ███     ",
                "   ▄████▀   "
            });

            alphabet.Add('U', new string[]
            {
                "███    █▄  ",
                "███    ███ ",
                "███    ███ ",
                "███    ███ ",
                "███    ███ ",
                "███    ███ ",
                "███    ███ ",
                "████████▀  "
            });

            alphabet.Add('V', new string[]
            {
                " ▄█    █▄  ",
                "███    ███ ",
                "███    ███ ",
                "███    ███ ",
                "███    ███ ",
                "███    ███ ",
                "███    ███ ",
                " ▀██████▀  "
            });

            alphabet.Add('W', new string[]
            {
                " ▄█     █▄  ",
                "███     ███ ",
                "███     ███ ",
                "███     ███ ",
                "███     ███ ",
                "███     ███ ",
                "███ ▄█▄ ███ ",
                " ▀███▀███▀  "
            });

            alphabet.Add('X', new string[]
            {
                "▀████    ▐████▀ ",
                "  ███▌   ████▀  ",
                "   ███  ▐███    ",
                "   ▀███▄███▀    ",
                "   ████▀██▄     ",
                "   ▐███  ▀███   ",
                " ▄███     ███▄  ",
                "████       ███▄ "
            });

            alphabet.Add('Y', new string[]
            {
                "▄██   ▄   ",
                "███   ██▄ ",
                "███▄▄▄███ ",
                "▀▀▀▀▀▀███ ",
                "▄██   ███ ",
                "███   ███ ",
                "███   ███ ",
                " ▀█████▀  "
            });

            alphabet.Add('Z', new string[]
            {
                " ▄███████▄  ",
                "██▀     ▄██ ",
                "      ▄███▀ ",
                " ▀█▀▄███▀▄▄ ",
                "  ▄███▀   ▀ ",
                "▄███▀       ",
                "███▄     ▄█ ",
                " ▀████████▀ "
            });

            alphabet.Add('1', new string[]
            {
                "▄████   ",
                "  ███   ",
                "  ███▌  ",
                "  ███▌  ",
                "  ███▌  ",
                "  ███   ",
                "  ███   ",
                "▄▄███▄▄ "
            });

            alphabet.Add('2', new string[]
            {
                " ▄███████▄  ",
                "██▀     ▄██ ",
                "▀      ▄██▀ ",
                "     ▄██▀   ",
                "   ▄██▀     ",
                " ▄██▀       ",
                "███▄     ▄█ ",
                "▀█████████▀ "
            });

            alphabet.Add('3', new string[]
            {
                "██████████▄  ",
                "▀        ███ ",
                "         ███ ",
                "    ▄▄▄███▀  ",
                "   ▀▀█████▄  ",
                "         ██▄ ",
                "▄        ███ ",
                "▄█████████▀  "
            });

            alphabet.Add('4', new string[]
            {
                "  ▄██    ██  ",
                "  ███    ███ ",
                "  ███    ███ ",
                "  ███    ███ ",
                "▀███████████ ",
                "         ███ ",
                "         ███ ",
                "         █▀  "
            });

            alphabet.Add('5', new string[]
            {
                "  ██████████ ",
                "  ███        ",
                "  ███        ",
                "▀███████████ ",
                "         ███ ",
                "         ███ ",
                "   ▄█    ███ ",
                " ▄████████▀  "
            });

            alphabet.Add('6', new string[]
            {
                " ▄████▀      ",
                "  ███        ",
                "  ███        ",
                "▀█████████▄  ",
                "  ███    ███ ",
                "  ███    ███ ",
                "  ███    ███ ",
                "   ▀███████  "
            });

            alphabet.Add('7', new string[]
            {
                "▄████████▄  ",
                "        ▄██ ",
                "       ▄██▀ ",
                "      ▄██▀  ",
                "▀█▀ ▄██▀ █▀ ",
                "  ▄██▀      ",
                " ▄██▀       ",
                " ▀██        "
            });

            alphabet.Add('8', new string[]
            {
                " ▄███████▄  ",
                "███▀    ▄██ ",
                " ▀██▄  ▄██▀ ",
                "   ▀ ▄██▀   ",
                "   ▄██▀▄▄   ",
                " ▄██▀ ▀███▄ ",
                "███▄   ▄███ ",
                " ▀███████▀  "
            });

            alphabet.Add('9', new string[]
            {
                "▄███████▄   ",
                "███    ███  ",
                "█▄     ███  ",
                "███    ███  ",
                "▀█████████▀ ",
                "       ███  ",
                " ▄     ███  ",
                " ██▄▄▄████▄ "
            });

            alphabet.Add('0', new string[]
            {
                " ▄██████▄  ",
                "███    ███ ",
                "███    ███ ",
                "███ ▄█ ███ ",
                "███ █▀ ███ ",
                "███    ███ ",
                "███    ███ ",
                " ▀██████▀  "
            });

            alphabet.Add(' ', new string[]
            {
                "       ",
                "       ",
                "       ",
                "       ",
                "       ",
                "       ",
                "       ",
                "       "
            });

            alphabet.Add('(', new string[]
            {
                " ▄██▀ ",
                "██    ",
                "██    ",
                "██    ",
                "██    ",
                "██    ",
                "██    ",
                " ▀██▄ "
            });

            alphabet.Add(')', new string[]
            {
                "▀██▄  ",
                "   ██ ",
                "   ██ ",
                "   ██ ",
                "   ██ ",
                "   ██ ",
                "   ██ ",
                "▄██▀  "
            });

            alphabet.Add('{', new string[]
            {
                "    ▄██▀ ",
                "   ██    ",
                "   ██    ",
                " ▄█▀     ",
                " ▀█▄     ",
                "   ██    ",
                "   ██    ",
                "    ▀██▄ "
            });

            alphabet.Add('}', new string[]
            {
                "▀██▄    ",
                "   ██   ",
                "   ██   ",
                "    ▀█▄ ",
                "    ▄█▀ ",
                "   ██   ",
                "   ██   ",
                "▄██▀    "
            });

            alphabet.Add('/', new string[]
            {
                "       ▄█ ",
                "      ▄█▀ ",
                "     ▄█▀  ",
                "    ▄█▀   ",
                "   ▄█▀    ",
                "  ▄█▀     ",
                " ▄█▀      ",
                "▄█▀       "
            });

            alphabet.Add('\\', new string[]
            {
                " █▄        ",
                " ▀█▄       ",
                "  ▀█▄      ",
                "   ▀█▄     ",
                "    ▀█▄    ",
                "     ▀█▄   ",
                "      ▀█▄  ",
                "       ▀█▄ "
            });

            alphabet.Add('.', new string[]
            {
                "    ",
                "    ",
                "    ",
                "    ",
                "    ",
                "    ",
                "    ",
                "███ "
            });

            alphabet.Add(':', new string[]
            {
                "      ",
                "      ",
                "███   ",
                "███   ",
                "      ",
                "███   ",
                "███   ",
                "      "
            });

            alphabet.Add(';', new string[]
            {
                "      ",
                "      ",
                " ███  ",
                " ███  ",
                "      ",
                " ███  ",
                " ▄██  ",
                "▀▀    "
            });

            alphabet.Add('\'', new string[]
            {
                "██ ",
                "   ",
                "   ",
                "   ",
                "   ",
                "   ",
                "   ",
                "   "
            });

            alphabet.Add('"', new string[]
            {
                "██ ██ ",
                "      ",
                "      ",
                "      ",
                "      ",
                "      ",
                "      ",
                "      "
            });

            alphabet.Add('!', new string[]
            {
                " ▄███▄  ",
                "███████ ",
                "███████ ",
                "▀█████▀ ",
                " ▀███▀  ",
                "  ███   ",
                "        ",
                "  ██▀   "
            });

            alphabet.Add('?', new string[]
            {
                "▄████████▄  ",
                "██▀    ▀███ ",
                " ▀      ███ ",
                "   ▄▄▄▄██▀  ",
                "    ███     ",
                "    ███     ",
                "            ",
                "    ██▀     "
            });
            
        }

        #endregion

        #region Static Methods

        /// <summary>
        /// Generates a large string of characters corresponding to the input phrase.
        /// </summary>
        /// <remarks>
        /// Supports uppercase characters A-Z, spaces, open and close parenthesis and question marks.
        /// Any character that doesn't exist in the alphabet will be replaced with a question mark.
        /// </remarks>
        /// <param name="phrase">The phrase to generate.</param>
        /// <returns>A string array containing the stylized output.</returns>
        public static string[] Generate(string phrase)
        {
            string[] r = new string[height];

            foreach (char c in phrase.ToUpper())
                for (int i = 0; i < height; i++)
                    r[i] += alphabet[(alphabet.ContainsKey(c) ? c : '?')][i];

            return r;
        }

        /// <summary>
        /// Generates a larged, stylized string of characters corresponding to the input phrase.
        /// </summary>
        /// <param name="phrase">The phrase to generate.</param>
        /// <returns>A string array containing the stylized output.</returns>
        public static string[] GenerateStyled(string phrase)
        {
            string[] r = new string[height + 2];
            string[] g = Generate(phrase);

            r[0] = header;

            for (int i = 1; i <= height; i++)
                r[i] = linePrefix + g[i - 1];

            r[height + 1] = footer;

            return r;
        }

        #endregion
    }
}
