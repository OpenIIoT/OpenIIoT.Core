/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀ 
      █
      █   ▀█████████▄   ▄█     ▄██████▄     ▄████████  ▄██████▄  ███▄▄▄▄       ███         ▄████████     ▄████████     
      █     ███    ███ ███    ███    ███   ███    ███ ███    ███ ███▀▀▀██▄ ▀█████████▄     ███    ███   ███    ███             
      █     ███    ███ ███▌   ███    █▀    ███    █▀  ███    ███ ███   ███    ▀███▀▀██     ███    █▀    ███    █▀   
      █    ▄███▄▄▄██▀  ███▌  ▄███         ▄███▄▄▄     ███    ███ ███   ███     ███   ▀     ███          ███         
      █   ▀▀███▀▀▀██▄  ███▌ ▀▀███ ████▄  ▀▀███▀▀▀     ███    ███ ███   ███     ███         ███        ▀███████████  
      █     ███    ██▄ ███    ███    ███   ███        ███    ███ ███   ███     ███         ███    █▄           ███  
      █     ███    ███ ███    ███    ███   ███        ███    ███ ███   ███     ███     ▄▄▄ ███    ███    ▄█    ███  
      █   ▄█████████▀  █▀     ████████▀    ███         ▀██████▀   ▀█   █▀     ▄████▀   ███ ████████▀   ▄████████▀   
      █
 ▄ ▄▄ █ ▄▄▄▄▄▄▄▄▄  ▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄ 
 █ ██ █ █████████  ████ ██████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █ 
      █ 
      █  Transforms strings into large, stylized characters.
      █ 
      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██ 
                                                                                                   ██   
                                                                                               ▀█▄ ██ ▄█▀                       
                                                                                                 ▀████▀   
                                                                                                   ▀▀                            */
using System;
using System.Collections.Generic;

namespace Symbiote.Core
{
    /// <summary>
    /// BigFont transforms strings into large, stylized characters.
    /// </summary>
    static class BigFont
    {
        #region Enumerations

        /// <summary>
        /// Font size enumeration; the integer value indicates the height in lines
        /// </summary>
        public enum FontSize
        {
            Large = 8,
            Medium = 6,
            Small = 4
        }

        #endregion

        #region Variables

        /// <summary>
        /// The header string used for styled output.
        /// </summary>
        private static string header = "┌─────────── ─ ───────────────────────── ─────────────────────────────────────────────────────────────────── ─────── ─    ─     ─";

        /// <summary>
        /// The line prefix used for styled output.
        /// </summary>
        private static string linePrefix = "│ ";

        /// <summary>
        /// The footer string used for styled output.
        /// </summary>
        private static string footer = "└──────────────────── ───────────────────────────────  ─  ─          ─ ─ ─    ─   ─";

        #endregion

        #region Properties

        /// <summary>
        /// The alphabet.
        /// </summary>
        public static Dictionary<Tuple<char, FontSize>, string[]> Alphabet { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// The default constructor.  Initializes the alphabet.
        /// </summary>
        static BigFont()
        {
            Alphabet = new Dictionary<Tuple<char, FontSize>, string[]>();

            Alphabet.Add(new Tuple<char, FontSize>('A', FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, FontSize>('B', FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, FontSize>('C', FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, FontSize>('D', FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, FontSize>('E', FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, FontSize>('F', FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, FontSize>('G', FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, FontSize>('H', FontSize.Large), new string[] 
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

            Alphabet.Add(new Tuple<char, FontSize>('I', FontSize.Large), new string[] 
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

            Alphabet.Add(new Tuple<char, FontSize>('J', FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, FontSize>('K', FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, FontSize>('L', FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, FontSize>('M', FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, FontSize>('N', FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, FontSize>('O', FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, FontSize>('P', FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, FontSize>('Q', FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, FontSize>('R', FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, FontSize>('S', FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, FontSize>('T', FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, FontSize>('U', FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, FontSize>('V', FontSize.Large), new string[]
            {
                " ▄█    █▄  ",
                "███    ███ ",     
                "███    ███ ",    
                "███    ███ ",   
                "███    ███ ",  
                "███    ███ ", 
                " ██▄  ▄██  ",
                "  ▀████▀   "
            });

            Alphabet.Add(new Tuple<char, FontSize>('W', FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, FontSize>('X', FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, FontSize>('Y', FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, FontSize>('Z', FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, FontSize>('1', FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, FontSize>('2', FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, FontSize>('3', FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, FontSize>('4', FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, FontSize>('5', FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, FontSize>('6', FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, FontSize>('7', FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, FontSize>('8', FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, FontSize>('9', FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, FontSize>('0', FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, FontSize>(' ', FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, FontSize>('(', FontSize.Large), new string[]
            {
                "  ▄██▀ ",
                " ██    ",
                "██     ",
                "██     ",
                "██     ",
                "██     ",
                " ██    ",
                "  ▀██▄ "
            });

            Alphabet.Add(new Tuple<char, FontSize>(')', FontSize.Large), new string[]
            {
                "▀██▄   ",
                "   ██  ",
                "    ██ ",
                "    ██ ",
                "    ██ ",
                "    ██ ",
                "   ██  ",
                "▄██▀   "
            });

            Alphabet.Add(new Tuple<char, FontSize>('[', FontSize.Large), new string[]
            {
                "██▀▀▀ ",
                "██    ",
                "██    ",
                "██    ",
                "██    ",
                "██    ",
                "██    ",
                "██▄▄▄ "
            });

            Alphabet.Add(new Tuple<char, FontSize>(']', FontSize.Large), new string[]
            {
                "▀▀▀██ ",
                "   ██ ",
                "   ██ ",
                "   ██ ",
                "   ██ ",
                "   ██ ",
                "   ██ ",
                "▄▄▄██ "
            });

            Alphabet.Add(new Tuple<char, FontSize>('<', FontSize.Large), new string[]
            {
                "      ▄▄ ",
                "    ▄█▀  ",
                "  ▄█▀    ",
                "▄█▀      ",
                "▀█▄      ",
                "  ▀█▄    ",
                "    ▀█▄  ",
                "      ▀▀ "
            });

            Alphabet.Add(new Tuple<char, FontSize>('>', FontSize.Large), new string[]
            {
                "▄▄       ",
                " ▀█▄     ",
                "   ▀█▄   ",
                "     ▀█▄ ",
                "     ▄█▀ ",
                "   ▄█▀   ",
                " ▄█▀     ",
                "▀▀       "
            });

            Alphabet.Add(new Tuple<char, FontSize>('{', FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, FontSize>('}', FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, FontSize>('/', FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, FontSize>('\\', FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, FontSize>('.', FontSize.Large), new string[]
            {
                "    ",
                "    ",
                "    ",
                "    ",
                "    ",
                "    ",
                "▄▄▄ ",
                "███ "
            });

            Alphabet.Add(new Tuple<char, FontSize>(',', FontSize.Large), new string[]
            {
                "     ",
                "     ",
                "     ",
                "     ",
                "     ",
                "     ",
                " ▄▄▄ ",
                " ▄██ "
            });

            Alphabet.Add(new Tuple<char, FontSize>(':', FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, FontSize>(';', FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, FontSize>('\'', FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, FontSize>('"', FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, FontSize>('!', FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, FontSize>('?', FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, FontSize>('A', FontSize.Medium), new string[]
            {
                "  ▄█████  ",
                "  ██   ██ ",
                "  ██   ██ ",
                "▀████████ ",
                "  ██   ██ ",
                "  ██   █▀ "
            });

            Alphabet.Add(new Tuple<char, FontSize>('B', FontSize.Medium), new string[]
            {
                "▀███████▄  ",
                "  ██    ██ ",
                " ▄██▄▄▄█▀  ",
                "▀▀██▀▀▀█▄  ",
                "  ██    ██ ",
                "▄███████▀  "
            });

            Alphabet.Add(new Tuple<char, FontSize>('C', FontSize.Medium), new string[]
            {
                " ▄███████ ",
                "██     ██ ",
                "██     ▀  ",
                "██     ▄  ",
                "██     ██ ",
                "███████▀  "
            });

            Alphabet.Add(new Tuple<char, FontSize>('D', FontSize.Medium), new string[]
            {
                "███████▄  ",
                "██    ▀██ ",
                "██     ██ ",
                "██     ██ ",
                "██    ▄██ ",
                "███████▀  "
            });

            Alphabet.Add(new Tuple<char, FontSize>('E', FontSize.Medium), new string[]
            {
                "   ▄██████ ",
                "  ██    █  ",
                " ▄██▄▄▄    ",
                "▀▀██▀▀▀    ",
                "  ██    █  ",
                "  ████████ "
            });

            Alphabet.Add(new Tuple<char, FontSize>('F', FontSize.Medium), new string[]
            {
                "   ▄██████ ",
                "  ██    ▀█ ",
                " ▄██▄▄▄    ",
                "▀▀██▀▀▀    ",
                "  ██       ",
                "  ██       "
            });
            Alphabet.Add(new Tuple<char, FontSize>('G', FontSize.Medium), new string[]
            {
                "   ▄████▄  ",
                "  ██    ▀  ",
                " ▄██       ",
                "▀▀██ ███▄  ",
                "  ██    ██ ",
                "  ██████▀  "
            });
            Alphabet.Add(new Tuple<char, FontSize>('H', FontSize.Medium), new string[]
            {
                "  ██   █    ",
                "  ██   ██   ",
                " ▄██▄▄▄██▄▄ ",
                "▀▀██▀▀▀██▀  ",
                "  ██   ██   ",
                "  ██   ██   "
            });

            Alphabet.Add(new Tuple<char, FontSize>('I', FontSize.Medium), new string[]
            {
                " █  ",
                "██  ",
                "██▌ ",
                "██  ",
                "██  ",
                "█   "
            });

            Alphabet.Add(new Tuple<char, FontSize>('J', FontSize.Medium), new string[]
            {
                "     █ ",
                "    ██ ",
                "    ██ ",
                "    ██ ",
                "█▄ ▄██ ",
                "▀▀▀▀▀  "
            });

            Alphabet.Add(new Tuple<char, FontSize>('K', FontSize.Medium), new string[]
            {
                "   █  █▄   ",
                "  ██ ▄██▀  ",
                "  ██▐█▀    ",
                "▀▀████     ",
                "  ██ ▀██▄  ",
                "  ▀█   ▀█▀ "
            });

            Alphabet.Add(new Tuple<char, FontSize>('L', FontSize.Medium), new string[]
            {
                " █       ",
                "██       ",
                "██       ",
                "██       ",
                "██▌    ▄ ",
                "████▄▄██ "
            });

            Alphabet.Add(new Tuple<char, FontSize>('M', FontSize.Medium), new string[]
            {
                "   ▄▄▄███▄▄▄  ",
                " ▄█▀▀▀██▀▀▀█▄ ",
                " ██   ██   ██ ",
                " ██   ██   ██ ",
                " ██   ██   ██ ",
                "  █   ██   █  "
            });

            Alphabet.Add(new Tuple<char, FontSize>('N', FontSize.Medium), new string[]
            {
                "██▄▄▄▄  ",
                "██▀▀▀█▄ ",
                "██   ██ ",
                "██   ██ ",
                "██   ██ ",
                " █   █  "
            });
            Alphabet.Add(new Tuple<char, FontSize>('O', FontSize.Medium), new string[]
            {
                " ██████  ",
                "██    ██ ",
                "██    ██ ",
                "██    ██ ",
                "██    ██ ",
                " ██████  "
            });
            Alphabet.Add(new Tuple<char, FontSize>('P', FontSize.Medium), new string[]
            {
                "   ██████▄ ",
                "  ██    ██ ",
                "  ██    ██ ",
                "▀███████▀  ",
                "  ██       ",
                " ▄███▀     "
            });
            Alphabet.Add(new Tuple<char, FontSize>('Q', FontSize.Medium), new string[]
            {
                "███████   ",
                "██    ██  ",
                "██    ██  ",
                "██    ██  ",
                "██  ▀ ██  ",
                " █████▀▄█ "
            });
            Alphabet.Add(new Tuple<char, FontSize>('R', FontSize.Medium), new string[]
            {
                "   ██████ ",
                "  ██   ██ ",
                " ▄██▄▄▄█▀ ",
                "▀████████ ",
                "  ██   ██ ",
                "  ██   ██ "
            });
            Alphabet.Add(new Tuple<char, FontSize>('S', FontSize.Medium), new string[]
            {
                "  ▄██████ ",
                "  ██   ▀  ",
                "  ██      ",
                "▀████████ ",
                "   ▄   ██ ",
                " ▄█████▀  "
            });
            Alphabet.Add(new Tuple<char, FontSize>('T', FontSize.Medium), new string[]
            {
                "    ██    ",
                "▀███████▄ ",
                "    ██  ▀ ",
                "    ██    ",
                "    ██    ",
                "   ▄██▀   "
            });
            Alphabet.Add(new Tuple<char, FontSize>('U', FontSize.Medium), new string[]
            {
                "██    █  ",
                "██    ██ ",
                "██    ██ ",
                "██    ██ ",
                "██    ██ ",
                "███████  "
            });
            Alphabet.Add(new Tuple<char, FontSize>('V', FontSize.Medium), new string[]
            {
                " █    █  ",
                "██    ██ ",
                "██    ██ ",
                "██    ██ ",
                " █▄  ▄█  ",
                "  ▀██▀   "
            });
            Alphabet.Add(new Tuple<char, FontSize>('W', FontSize.Medium), new string[]
            {
                " █     █  ",
                "██     ██ ",
                "██     ██ ",
                "██     ██ ",
                "██ ▄█▄ ██ ",
                " ███▀███  "
            });
            Alphabet.Add(new Tuple<char, FontSize>('X', FontSize.Medium), new string[]
            {
                "▀███   ▐██▀ ",
                "  ██   ██   ",
                "   ██▄██▀   ",
                "   ██▀██    ",
                " ▄██  ▀██   ",
                "███     ██▄ "
            });
            Alphabet.Add(new Tuple<char, FontSize>('Y', FontSize.Medium), new string[]
            {
                "▄█   ▄  ",
                "██   █▄ ",
                "▀▀▀▀▀██ ",
                "▄█   ██ ",
                "██   ██ ",
                " █████  "
            });
            Alphabet.Add(new Tuple<char, FontSize>('Z', FontSize.Medium), new string[]
            {
                " ▄██████▄ ",
                "██▀    ▄█ ",
                " ▀  ▄██▀  ",
                "  ▄██▀  ▀ ",
                " ██▄   ▄█ ",
                "▀██████▀  "
            });

            Alphabet.Add(new Tuple<char, FontSize>('1', FontSize.Medium), new string[]
            {
                "▄███   ",
                "  ██   ",
                "  ██▌  ",
                "  ██▌  ",
                "  ██   ",
                "▄▄██▄▄ "
            });

            Alphabet.Add(new Tuple<char, FontSize>('2', FontSize.Medium), new string[]
            {
                " ▄█████▄  ",
                "██▀   ▄██ ",
                "▀   ▄██▀  ",
                " ▄██▀     ",
                "██▄    ▄█ ",
                "▀███████▀ "
            });

            Alphabet.Add(new Tuple<char, FontSize>('3', FontSize.Medium), new string[]
            {
                "███████▄  ",
                "▀     ███ ",
                "    ▄██▀  ",
                "   ▀▀██▄  ",
                "▄     ███ ",
                "▄██████▀  "
            });

            Alphabet.Add(new Tuple<char, FontSize>('4', FontSize.Medium), new string[]
            {
                "  ▄█   █  ",
                "  ██   ██ ",
                "  ██   ██ ",
                "▀████████ ",
                "       ██ ",
                "       █▀ "
            });

            Alphabet.Add(new Tuple<char, FontSize>('5', FontSize.Medium), new string[]
            {
                "  ███████ ",
                "  ██      ",
                "▀████████ ",
                "       ██ ",
                "   ▄   ██ ",
                " ▄█████▀  "
            });

            Alphabet.Add(new Tuple<char, FontSize>('6', FontSize.Medium), new string[]
            {
                " ▄███▀     ",
                "  ██       ",
                "▀███████▄  ",
                "  ██    ██ ",
                "  ██    ██ ",
                "  ▀█████▀  "
            });

            Alphabet.Add(new Tuple<char, FontSize>('7', FontSize.Medium), new string[]
            {
                "▄██████▄  ",
                "      ▄██ ",
                "    ▄██▀  ",
                "█▀▄██▀ █▀ ",
                "▄██▀      ",
                "▀██       "
            });

            Alphabet.Add(new Tuple<char, FontSize>('8', FontSize.Medium), new string[]
            {
                " ▄██▀▀█▄  ",
                " ▀█▄  ▄█▀ ",
                "  ▀▄██▀   ",
                " ▄██▀▄▄   ",
                "██▄   ▄██ ",
                " ▀█████▀  "
            });

            Alphabet.Add(new Tuple<char, FontSize>('9', FontSize.Medium), new string[]
            {
                "▄█████▄   ",
                "██▀   ██  ",
                "█▄    ██  ",
                "▀███████▀ ",
                " ▄    ██  ",
                " ██▄▄███▄ "
            });

            Alphabet.Add(new Tuple<char, FontSize>('0', FontSize.Medium), new string[]
            {
                " ▄████▄  ",
                "██    ██ ",
                "██ ▄█ ██ ",
                "██ █▀ ██ ",
                "██    ██ ",
                " ▀████▀  "
            });

            Alphabet.Add(new Tuple<char, FontSize>(' ', FontSize.Medium), new string[]
            {
                "     ",
                "     ",
                "     ",
                "     ",
                "     ",
                "     "
            });

            Alphabet.Add(new Tuple<char, FontSize>('(', FontSize.Medium), new string[]
            {
                "  ▄█▀ ",
                " █    ",
                "█     ",
                "█     ",
                " █    ",
                "  ▀█▄ "
            });

            Alphabet.Add(new Tuple<char, FontSize>(')', FontSize.Medium), new string[]
            {
                "▀█▄   ",
                "   █  ",
                "    █ ",
                "    █ ",
                "   █  ",
                "▄█▀   "
            });

            Alphabet.Add(new Tuple<char, FontSize>('[', FontSize.Medium), new string[]
            {
                "█▀▀ ",
                "█   ",
                "█   ",
                "█   ",
                "█   ",
                "█▄▄ "
            });

            Alphabet.Add(new Tuple<char, FontSize>(']', FontSize.Medium), new string[]
            {
                " ▀▀█ ",
                "   █ ",
                "   █ ",
                "   █ ",
                "   █ ",
                " ▄▄█ "
            });

            Alphabet.Add(new Tuple<char, FontSize>('<', FontSize.Medium), new string[]
            {
                "    ▄ ",
                "  ▄▀  ",
                "▄▀    ",
                "▀▄    ",
                "  ▀▄  ",
                "    ▀ "
            });

            Alphabet.Add(new Tuple<char, FontSize>('>', FontSize.Medium), new string[]
            {
                "▄     ",
                " ▀▄   ",
                "   ▀▄ ",
                "   ▄▀ ",
                " ▄▀   ",
                "▀     "
            });

            Alphabet.Add(new Tuple<char, FontSize>('{', FontSize.Medium), new string[]
            {
                "   ▄█▀ ",
                "  █    ",
                "▄█▀    ",
                "▀█▄    ",
                "  █    ",
                "   ▀█▄ "
            });

            Alphabet.Add(new Tuple<char, FontSize>('}', FontSize.Medium), new string[]
            {
                "▀█▄    ",
                "   █   ",
                "   ▀█▄ ",
                "   ▄█▀ ",
                "   █   ",
                "▄█▀    "
            });

            Alphabet.Add(new Tuple<char, FontSize>('/', FontSize.Medium), new string[]
            {
                "     ▄█ ",
                "    ▄█▀ ",
                "   ▄█▀  ",
                "  ▄█▀   ",
                " ▄█▀    ",
                "▄█▀     "
            });

            Alphabet.Add(new Tuple<char, FontSize>('\\', FontSize.Medium), new string[]
            {
                " █▄      ",
                " ▀█▄     ",
                "  ▀█▄    ",
                "   ▀█▄   ",
                "    ▀█▄  ",
                "     ▀█▄ "
            });

            Alphabet.Add(new Tuple<char, FontSize>('.', FontSize.Medium), new string[]
            {
                "   ",
                "   ",
                "   ",
                "   ",
                "   ",
                "██ "
            });

            Alphabet.Add(new Tuple<char, FontSize>(',', FontSize.Medium), new string[]
            {
                "   ",
                "   ",
                "   ",
                "   ",
                "▄▄ ",
                "▄█ "
            });

            Alphabet.Add(new Tuple<char, FontSize>(':', FontSize.Medium), new string[]
            {
                "     ",
                "     ",
                "██   ",
                "     ",
                "██   ",
                "     "
            });

            Alphabet.Add(new Tuple<char, FontSize>(';', FontSize.Medium), new string[]
            {
                "    ",
                "    ",
                "██  ",
                "    ",
                "▀█  ",
                "▀   "
            });

            Alphabet.Add(new Tuple<char, FontSize>('\'', FontSize.Medium), new string[]
            {
                "█ ",
                "  ",
                "  ",
                "  ",
                "  ",
                "  "
            });

            Alphabet.Add(new Tuple<char, FontSize>('"', FontSize.Medium), new string[]
            {
                "█ █ ",
                "    ",
                "    ",
                "    ",
                "    ",
                "    "
            });

            Alphabet.Add(new Tuple<char, FontSize>('!', FontSize.Medium), new string[]
            {
                " ▄███▄  ",
                "▀█████▀ ",
                " ▀███▀  ",
                "  ███   ",
                "        ",
                "  ██▀   "
            });

            Alphabet.Add(new Tuple<char, FontSize>('?', FontSize.Medium), new string[]
            {
                "▄██████▄  ",
                "██▀   ▀██ ",
                "   ▄▄▄██▀ ",
                "   ███    ",
                "          ",
                "   ██▀    "
            });

            Alphabet.Add(new Tuple<char, FontSize>('A', FontSize.Small), new string[]
            {
                "▄█████  ",
                "██   ██ ",
                "███████ ",
                "██   ██ "
            });

            Alphabet.Add(new Tuple<char, FontSize>('B', FontSize.Small), new string[]
            {
                "▀█████▄  ",
                " ██▄▄▄▀ ",
                " ██   █ ",
                "▄█████▀  "
            });

            Alphabet.Add(new Tuple<char, FontSize>('C', FontSize.Small), new string[]
            {
                "▄█████  ",
                "██   ▀  ",
                "██   ▄  ",
                "█████▀  ",
            });

            Alphabet.Add(new Tuple<char, FontSize>('D', FontSize.Small), new string[]
            {
                "█████▄  ",
                "██   ██ ",
                "██   ██ ",
                "█████▀  "
            });

            Alphabet.Add(new Tuple<char, FontSize>('E', FontSize.Small), new string[]
            {
                " ▄████  ",
                " ██     ",
                "▀██▀▀   ",
                " ██████ ",
            });

            Alphabet.Add(new Tuple<char, FontSize>('F', FontSize.Small), new string[]
            {
                "   ▄████ ",
                " ▄██▄▄▄  ",
                "  ██     ",
                "  ██     "
            });
            Alphabet.Add(new Tuple<char, FontSize>('G', FontSize.Small), new string[]
            {
                "  ▄████▄ ",
                " ██    ▀ ",
                "▀██ ▀▀█▄ ",
                " ██████▀ ",
            });
            Alphabet.Add(new Tuple<char, FontSize>('H', FontSize.Small), new string[]
            {
                " ██  █   ",
                " ██▄▄██▄ ",
                "▀██▀▀██  ",
                " ██  ██  "
            });

            Alphabet.Add(new Tuple<char, FontSize>('I', FontSize.Small), new string[]
            {
                " █ ",
                "██ ",
                "██ ",
                "█  ",
            });

            Alphabet.Add(new Tuple<char, FontSize>('J', FontSize.Small), new string[]
            {
                "    █ ",
                "   ██ ",
                "▄ ▄██ ",
                "▀▀▀▀  "
            });

            Alphabet.Add(new Tuple<char, FontSize>('K', FontSize.Small), new string[]
            {
                " ██ ▄█▀  ",
                " ██▐█▀    ",
                "▀████     ",
                " ██ ▀█▄  ",
            });

            Alphabet.Add(new Tuple<char, FontSize>('L', FontSize.Small), new string[]
            {
                " █     ",
                "██     ",
                "██   ▄ ",
                "██▄▄██ "
            });

            Alphabet.Add(new Tuple<char, FontSize>('M', FontSize.Small), new string[]
            {
                "  ▄▄███▄▄  ",
                "▄█▀▀██▀▀█▄ ",
                "██  ██  ██ ",
                " █  ██  █  "
            });

            Alphabet.Add(new Tuple<char, FontSize>('N', FontSize.Small), new string[]
            {
                "██▄▄▄  ",
                "██▀▀█▄ ",
                "██  ██ ",
                " █  █  "
            });
            Alphabet.Add(new Tuple<char, FontSize>('O', FontSize.Small), new string[]
            {
                " █████  ",
                "██   ██ ",
                "██   ██ ",
                " █████  "
            });
            Alphabet.Add(new Tuple<char, FontSize>('P', FontSize.Small), new string[]
            {
                "  █████▄ ",
                " ██   ██ ",
                "▀██▀▀▀▀  ",
                "▄███▀     "
            });
            Alphabet.Add(new Tuple<char, FontSize>('Q', FontSize.Small), new string[]
            {
                "██████   ",
                "██   ██  ",
                "██ ▀ ██  ",
                " ████▀▄█ "
            });
            Alphabet.Add(new Tuple<char, FontSize>('R', FontSize.Small), new string[]
            {
                "  █████ ",
                " ██  ██ ",
                "▄██▄▄█▀ ",
                " ██  ██ "
            });
            Alphabet.Add(new Tuple<char, FontSize>('S', FontSize.Small), new string[]
            {
                " ▄█████ ",
                " ██  ▀  ",
                "▀▀▀▀▀██ ",
                "▄█████▀  "
            });
            Alphabet.Add(new Tuple<char, FontSize>('T', FontSize.Small), new string[]
            {
                "   ██    ",
                "▀██████▄ ",
                "   ██    ",
                "  ▄██▀   "
            });
            Alphabet.Add(new Tuple<char, FontSize>('U', FontSize.Small), new string[]
            {
                "█   █  ",
                "█   ██ ",
                "█   ██ ",
                "█████  "
            });
            Alphabet.Add(new Tuple<char, FontSize>('V', FontSize.Small), new string[]
            {
                " █   █  ",
                "██   ██ ",
                " █▄ ▄█  ",
                "  ▀█▀   "
            });
            Alphabet.Add(new Tuple<char, FontSize>('W', FontSize.Small), new string[]
            {
                " █   █  ",
                "██   ██ ",
                "██▄█▄██ ",
                " ██▀██  "
            });
            Alphabet.Add(new Tuple<char, FontSize>('X', FontSize.Small), new string[]
            {
                " ██   ██ ",
                "  ██▄██▀ ",
                "  ▄█▀█▄  ",
                "▄██  ▀██ "
            });
            Alphabet.Add(new Tuple<char, FontSize>('Y', FontSize.Small), new string[]
            {
                "▄█  ▄  ",
                "▀▀▀▀██ ",
                "██  ██ ",
                " ████  "
            });
            Alphabet.Add(new Tuple<char, FontSize>('Z', FontSize.Small), new string[]
            {
                "▄████▄ ",
                "▀  ▄█▀ ",
                " ▄█▀ ▀ ",
                "█████▀ "
            });

            Alphabet.Add(new Tuple<char, FontSize>('1', FontSize.Small), new string[]
            {
                "▄██   ",
                "  █▌  ",
                "  █▌  ",
                "▄▄█▄▄ "
            });

            Alphabet.Add(new Tuple<char, FontSize>('2', FontSize.Small), new string[]
            {
                "▄████▄ ",
                "▀  ▄█▀ ",
                " ▄█▀   ",
                "██████ "
            });

            Alphabet.Add(new Tuple<char, FontSize>('3', FontSize.Small), new string[]
            {
                "████▄  ",
                "▀   ██ ",
                "▄  ▀██ ",
                "▄███▀  "
            });

            Alphabet.Add(new Tuple<char, FontSize>('4', FontSize.Small), new string[]
            {
                " ▄█  █  ",
                " ██  ██ ",
                "▀██████ ",
                "     █▀ "
            });

            Alphabet.Add(new Tuple<char, FontSize>('5', FontSize.Small), new string[]
            {
                " ██▀▀▀▀▀ ",
                "▀███████ ",
                "  ▄   ██ ",
                "▄█████▀  "
            });

            Alphabet.Add(new Tuple<char, FontSize>('6', FontSize.Small), new string[]
            {
                " ██▀     ",
                "▀█████▄  ",
                " █    ██ ",
                " ▀████▀  "
            });

            Alphabet.Add(new Tuple<char, FontSize>('7', FontSize.Small), new string[]
            {
                "▄█████▄ ",
                "   ▄██▀ ",
                "▀▄██▀ ▀ ",
                "██▀     ",
            });

            Alphabet.Add(new Tuple<char, FontSize>('8', FontSize.Small), new string[]
            {
                " ▄█▀▀█  ",
                " ▀▄▄▄▀  ",
                "██   ██ ",
                " ▀▄▄▄▀  "
            });

            Alphabet.Add(new Tuple<char, FontSize>('9', FontSize.Small), new string[]
            {
                "▄████   ",
                "█▀   █  ",
                "▀▀▀▀▀█▀ ",
                " █▄▄██▄ "
            });

            Alphabet.Add(new Tuple<char, FontSize>('0', FontSize.Small), new string[]
            {
                " ▄███▄  ",
                "██ ▄ ██ ",
                "██ ▀ ██ ",
                " ▀███▀  "
            });

            Alphabet.Add(new Tuple<char, FontSize>(' ', FontSize.Small), new string[]
            {
                "   ",
                "   ",
                "   ",
                "   "
            });

            Alphabet.Add(new Tuple<char, FontSize>('(', FontSize.Small), new string[]
            {
                " ▄█▀ ",
                "█    ",
                "█    ",
                " ▀█▄ "
            });

            Alphabet.Add(new Tuple<char, FontSize>(')', FontSize.Small), new string[]
            {
                "▀█▄  ",
                "   █ ",
                "   █ ",
                "▄█▀  "
            });

            Alphabet.Add(new Tuple<char, FontSize>('[', FontSize.Small), new string[]
            {
                "█▀▀ ",
                "█   ",
                "█   ",
                "█▄▄ "
            });

            Alphabet.Add(new Tuple<char, FontSize>(']', FontSize.Small), new string[]
            {
                " ▀▀█ ",
                "   █ ",
                "   █ ",
                " ▄▄█ "
            });

            Alphabet.Add(new Tuple<char, FontSize>('<', FontSize.Small), new string[]
            {
                "  ▄ ",
                "▄▀  ",
                "▀▄  ",
                "  ▀ "
            });

            Alphabet.Add(new Tuple<char, FontSize>('>', FontSize.Small), new string[]
            {
                "▄   ",
                " ▀▄ ",
                " ▄▀ ",
                "▀   "
            });

            Alphabet.Add(new Tuple<char, FontSize>('{', FontSize.Small), new string[]
            {
                "   ▄█▀ ",
                " ▄█    ",
                " ▀█    ",
                "   ▀█▄ "
            });

            Alphabet.Add(new Tuple<char, FontSize>('}', FontSize.Small), new string[]
            {
                "▀█▄   ",
                "   █▄ ",
                "   █▀ ",
                "▄█▀   "
            });

            Alphabet.Add(new Tuple<char, FontSize>('/', FontSize.Small), new string[]
            {
                "   ▄▀ ",
                "  ▄▀  ",
                " ▄▀   ",
                "▄▀    ",
            });

            Alphabet.Add(new Tuple<char, FontSize>('\\', FontSize.Small), new string[]
            {
                "▀▄    ",
                " ▀▄   ",
                "  ▀▄  ",
                "   ▀▄ "
            });

            Alphabet.Add(new Tuple<char, FontSize>('.', FontSize.Small), new string[]
            {
                "   ",
                "   ",
                "   ",
                "▄  "
            });

            Alphabet.Add(new Tuple<char, FontSize>(',', FontSize.Small), new string[]
            {
                "   ",
                "   ",
                "   ",
                "▄▀ "
            });

            Alphabet.Add(new Tuple<char, FontSize>(':', FontSize.Small), new string[]
            {
                "  ",
                "▄ ",
                "▄ ",
                "  "
            });

            Alphabet.Add(new Tuple<char, FontSize>(';', FontSize.Small), new string[]
            {
                "   ",
                " ▄ ",
                " ▄ ",
                "▀  "
            });

            Alphabet.Add(new Tuple<char, FontSize>('\'', FontSize.Small), new string[]
            {
                "▀ ",
                "  ",
                "  ",
                "  "
            });

            Alphabet.Add(new Tuple<char, FontSize>('"', FontSize.Small), new string[]
            {
                "▀ ▀ ",
                "    ",
                "    ",
                "    "
            });

            Alphabet.Add(new Tuple<char, FontSize>('!', FontSize.Small), new string[]
            {
                "▄██▄ ",
                "▀██▀ ",
                " ██  ",
                " ▄▄  "
            });

            Alphabet.Add(new Tuple<char, FontSize>('?', FontSize.Small), new string[]
            {
                "▄███▄  ",
                "▀   ██ ",
                "  ██▀  ",
                "  ▄▄   "
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
        /// <param name="size">The size of the font to use.</param>
        /// <returns>A string array containing the stylized output.</returns>
        public static string[] Generate(string phrase, FontSize size = FontSize.Large)
        {
            string[] r = new string[(int)size];

            foreach (char c in phrase.ToUpper())
                for (int i = 0; i < (int)size; i++)
                    r[i] += Alphabet[new Tuple<char, FontSize>((Alphabet.ContainsKey(new Tuple<char, FontSize>(c, size)) ? c : '?'), size)][i];

            return r;
        }

        /// <summary>
        /// Generates a larged, stylized string of characters corresponding to the input phrase.
        /// </summary>
        /// <param name="phrase">The phrase to generate.</param>
        /// <param name="size">The size of the font to use.</param>
        /// <returns>A string array containing the stylized output.</returns>
        public static string[] GenerateStyled(string phrase, FontSize size = FontSize.Large)
        {
            string[] r = new string[(int)size + 2];
            string[] g = Generate(phrase, size);

            r[0] = header;

            for (int i = 1; i <= (int)size; i++)
                r[i] = linePrefix + g[i - 1];

            r[(int)size + 1] = footer;

            return r;
        }

        #endregion
    }
}
