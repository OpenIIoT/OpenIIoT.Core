/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀ 
      █
      █   ▀█████████▄   ▄█     ▄██████▄     ▄████████  ▄██████▄  ███▄▄▄▄       ███         
      █     ███    ███ ███    ███    ███   ███    ███ ███    ███ ███▀▀▀██▄ ▀█████████▄                  
      █     ███    ███ ███▌   ███    █▀    ███    █▀  ███    ███ ███   ███    ▀███▀▀██    ▄██████   ▄█████
      █    ▄███▄▄▄██▀  ███▌  ▄███         ▄███▄▄▄     ███    ███ ███   ███     ███   ▀    ██    ██   ██  ▀   
      █   ▀▀███▀▀▀██▄  ███▌ ▀▀███ ████▄  ▀▀███▀▀▀     ███    ███ ███   ███     ███        ██    ▀    ██
      █     ███    ██▄ ███    ███    ███   ███        ███    ███ ███   ███     ███        ██    ▄  ▀███████ 
      █     ███    ███ ███    ███    ███   ███        ███    ███ ███   ███     ███        ██    ██    ▄  ██
      █   ▄█████████▀  █▀     ████████▀    ███         ▀██████▀   ▀█   █▀     ▄████▀   ██ ██████▀   ▄████▀
      █
 ▄ ▄▄ █ ▄▄▄▄▄▄▄▄▄  ▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄ 
 █ ██ █ █████████  ████ ██████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █ 
      █ 
      █  Transforms strings into large, stylized characters.
      █ 
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀ ▀ ▀▀▀     ▀▀               ▀   
      █  The MIT License (MIT)
      █  
      █  Copyright (c) 2016 JP Dillingham (jp@dillingham.ws)
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
                                                                                                   ▀▀                               */
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
            Default,
            Large = 8,
            Medium = 6,
            Small = 4
        }

        /// <summary>
        /// Font type enumeration
        /// </summary>
        public enum Font
        {
            Default,
            Block,
            Graffiti
        }

        #endregion

        #region Variables

        /// <summary>
        /// The default font used to initialize the DefaultFont property.
        /// </summary>
        private const Font defaultFont = Font.Block;

        /// <summary>
        /// The default font size used to initialize the DefaultFontSize property.
        /// </summary>
        private const FontSize defaultFontSize = FontSize.Large;

        #endregion

        #region Properties

        /// <summary>
        /// The default font.
        /// </summary>
        public static Font DefaultFont { get; set; }

        /// <summary>
        /// The default font size.
        /// </summary>
        public static FontSize DefaultFontSize { get; set; }

        /// <summary>
        /// The alphabet.
        /// </summary>
        public static Dictionary<Tuple<char, Font, FontSize>, string[]> Alphabet { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// The default constructor.  Initializes the alphabet.
        /// </summary>
        static BigFont()
        {
            // initialize the default properties
            DefaultFont = defaultFont;
            DefaultFontSize = defaultFontSize;

            // create the "Alphabet"
            Alphabet = new Dictionary<Tuple<char, Font, FontSize>, string[]>();

            #region Block

            /*
            █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀ 
            █
            █  ████████▄  ███        ▄██████▄   ▄██████▄  ███    ▄██▀
            █  ███    ███ ███       ███    ███ ███    ███ ███  ▄██▀
            █  ███    ███ ███       ███    ███ ███    ███ ███▄██▀
            █  ███▄▄▄▄██▀ ███       ███    ███ ███        ████▀
            █  ███▀▀▀▀██▄ ███       ███    ███ ███        ████▄
            █  ███    ███ ███       ███    ███ ███    ███ ███▀██▄
            █  ███    ███ ███       ███    ███ ███    ███ ███  ▀██▄
            █  ████████▀  █████████  ▀██████▀   ▀██████▀  ███    ▀██▄
            █
            ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀ ▀                                 */

            Alphabet.Add(new Tuple<char, Font, FontSize>('A', Font.Block, FontSize.Large), new string[]
            {
                " ▄██████▄  ",
                "███    ███ ",
                "███    ███ ",
                "███    ███ ",
                "██████████ ",
                "███    ███ ",
                "███    ███ ",
                "███    ███ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('B', Font.Block, FontSize.Large), new string[]
            {
                "████████▄  ",
                "███    ███ ",
                "███    ███ ",
                "███▄▄▄▄██▀ ",
                "███▀▀▀▀██▄ ",
                "███    ███ ",
                "███    ███ ",
                "████████▀  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('C', Font.Block, FontSize.Large), new string[]
            {
                " ▄██████▄  ",
                "███    ███ ",
                "███    ███ ",
                "███        ",
                "███        ",
                "███    ███ ",
                "███    ███ ",
                " ▀██████▀  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('D', Font.Block, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('E', Font.Block, FontSize.Large), new string[]
            {
                "████████ ",
                "███      ",
                "███      ",
                "███▄▄▄   ",
                "███▀▀▀   ",
                "███      ",
                "███      ",
                "████████ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('F', Font.Block, FontSize.Large), new string[]
            {
                "████████ ",
                "███      ",
                "███      ",
                "███▄▄▄   ",
                "███▀▀▀   ",
                "███      ",
                "███      ",
                "███      "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('G', Font.Block, FontSize.Large), new string[]
            {
                " ▄██████▄  ",
                "███    ███ ",
                "███    ███ ",
                "███        ",
                "███        ",
                "███  █████ ",
                "███    ███ ",
                " ▀██████▀  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('H', Font.Block, FontSize.Large), new string[]
            {
                "███    ███ ",
                "███    ███ ",
                "███    ███ ",
                "███▄▄▄▄███ ",
                "███▀▀▀▀███ ",
                "███    ███ ",
                "███    ███ ",
                "███    ███ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('I', Font.Block, FontSize.Large), new string[]
            {
                "███ ",
                "███ ",
                "███ ",
                "███ ",
                "███ ",
                "███ ",
                "███ ",
                "███ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('J', Font.Block, FontSize.Large), new string[]
            {
                "       ███ ",
                "       ███ ",
                "       ███ ",
                "       ███ ",
                "       ███ ",
                "       ███ ",
                "       ███ ",
                " ██▄  ▄███ ",
                "  ▀█████▀  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('K', Font.Block, FontSize.Large), new string[]
            {
                "███    ▄██▀ ",
                "███  ▄██▀   ",
                "███▄██▀     ",
                "████▀       ",
                "████▄       ",
                "███▀██▄     ",
                "███  ▀██▄   ",
                "███    ▀██▄ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('L', Font.Block, FontSize.Large), new string[]
            {
                "███       ",
                "███       ",
                "███       ",
                "███       ",
                "███       ",
                "███       ",
                "███       ",
                "█████████ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('M', Font.Block, FontSize.Large), new string[]
            {
                "█████▄   ▄█████ ",
                "███ ▀█▄ ▄█▀ ███ ",
                "███  ▀█▄█▀  ███ ",
                "███   ▀█▀   ███ ",
                "███         ███ ",
                "███         ███ ",
                "███         ███ ",
                "███         ███ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('N', Font.Block, FontSize.Large), new string[]
            {
                "███▄     ███ ",
                "████▄    ███ ",
                "███▀█▄   ███ ",
                "███ ▀█▄  ███ ",
                "███  ▀█▄ ███ ",
                "███   ▀█▄███ ",
                "███    ▀████ ",
                "███     ▀███ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('O', Font.Block, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('P', Font.Block, FontSize.Large), new string[]
            {
                "████████▄  ",
                "███    ███ ",
                "███    ███ ",
                "███    ███ ",
                "████████▀  ",
                "███        ",
                "███        ",
                "███        "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('Q', Font.Block, FontSize.Large), new string[]
            {
                " ▄██████▄  ",
                "███    ███ ",
                "███    ███ ",
                "███    ███ ",
                "███    ███ ",
                "███    ███ ",
                "███  ▀▄███ ",
                " ▀██████▀▄ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('R', Font.Block, FontSize.Large), new string[]
            {
                "████████▄   ",
                "███    ███  ",
                "███    ███  ",
                "███    ███  ",
                "████████▀   ",
                "███▀██▄     ",
                "███  ▀██▄   ",
                "███    ▀██▄ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('S', Font.Block, FontSize.Large), new string[]
            {
                " ▄██████▄  ",
                "███    ███ ",
                "███        ",
                "▀██▄▄▄▄▄   ",
                "  ▀▀▀▀▀██▄ ",
                "       ███ ",
                "███    ███ ",
                " ▀██████▀  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('T', Font.Block, FontSize.Large), new string[]
            {
                "███████████ ",
                "    ███     ",
                "    ███     ",
                "    ███     ",
                "    ███     ",
                "    ███     ",
                "    ███     ",
                "    ███     "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('U', Font.Block, FontSize.Large), new string[]
            {
                "███    ███ ",
                "███    ███ ",
                "███    ███ ",
                "███    ███ ",
                "███    ███ ",
                "███    ███ ",
                "███    ███ ",
                " ▀██████▀  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('V', Font.Block, FontSize.Large), new string[]
            {
                "███    ███ ",
                "███    ███ ",
                "███    ███ ",
                "███    ███ ",
                "███    ███ ",
                " ██▄  ▄██  ",
                "  ██▄▄██   ",
                "   ▀██▀    "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('W', Font.Block, FontSize.Large), new string[]
            {
                "███         ███ ",
                "███         ███ ",
                "███         ███ ",
                "███         ███ ",
                "███   ▄█▄   ███ ",
                "███  ▄█▀█▄  ███ ",
                "███ ▄█▀ ▀█▄ ███ ",
                "█████▀   ▀█████ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('X', Font.Block, FontSize.Large), new string[]
            {
                "▀██▄       ▄██▀ ",
                " ▀██▄     ▄██▀  ",
                "   ▀██▄ ▄██▀    ",
                "     ▀███▀      ",
                "     ▄███▄      ",
                "   ▄██▀ ▀██▄    ",
                " ▄██▀     ▀██▄  ",
                "▄██▀        ██▄ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('Y', Font.Block, FontSize.Large), new string[]
            {
                "▀██▄       ▄██▀ ",
                " ▀██▄     ▄██▀  ",
                "   ▀██▄ ▄██▀    ",
                "     ▀███▀      ",
                "      ███       ",
                "      ███       ",
                "      ███       ",
                "      ███       "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('Z', Font.Block, FontSize.Large), new string[]
            {
                "███████████ ",
                "      ▄██▀  ",
                "     ▄██▀   ",
                "    ▄██▀    ",
                "   ▄██      ",
                "  ▄██▀      ",
                " ▄██▀       ",
                "███████████ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('1', Font.Block, FontSize.Large), new string[]
            {
                "▄████   ",
                "  ███   ",
                "  ███   ",
                "  ███   ",
                "  ███   ",
                "  ███   ",
                "  ███   ",
                "▄▄███▄▄ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('2', Font.Block, FontSize.Large), new string[]
            {
                " ▄███████▄  ",
                "██▀     ▄██ ",
                "       ▄██▀ ",
                "     ▄██▀   ",
                "   ▄██▀     ",
                " ▄██▀       ",
                "███▄        ",
                "███████████ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('3', Font.Block, FontSize.Large), new string[]
            {
                "██████████▄  ",
                "         ███ ",
                "         ███ ",
                "    ▄▄▄███▀  ",
                "   ▀▀█████▄  ",
                "         ██▄ ",
                "         ███ ",
                "██████████▀  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('4', Font.Block, FontSize.Large), new string[]
            {
                "███    ███ ",
                "███    ███ ",
                "███    ███ ",
                "███    ███ ",
                "██████████ ",
                "       ███ ",
                "       ███ ",
                "       ███ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('5', Font.Block, FontSize.Large), new string[]
            {
                "██████████ ",
                "███        ",
                "███        ",
                "████████▄  ",
                "       ███ ",
                "       ███ ",
                "       ███ ",
                "████████▀  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('6', Font.Block, FontSize.Large), new string[]
            {
                "  ▄██▀     ",
                "▄██▀       ",
                "███        ",
                "████████▄  ",
                "███    ███ ",
                "███    ███ ",
                "███    ███ ",
                " ▀██████▀  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('7', Font.Block, FontSize.Large), new string[]
            {
                "███████████ ",
                "        ▄██ ",
                "       ▄██▀ ",
                "      ▄██▀  ",
                "    ▄██▀    ",
                "  ▄██▀      ",
                "▄██▀        ",
                "███         "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('8', Font.Block, FontSize.Large), new string[]
            {
                " ▄███████▄  ",
                "███▀   ▀███ ",
                " ███   ███  ",
                "  ▀██▄██▀   ",
                "   ██▀██    ",
                " ▄██   ██▄  ",
                "███▄   ▄███ ",
                " ▀███████▀  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('9', Font.Block, FontSize.Large), new string[]
            {
                " ▄██████▄  ",
                "███    ███ ",
                "███    ███ ",
                "███    ███ ",
                " ▀████████ ",
                "       ███ ",
                "       ███ ",
                " ███████▀  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('0', Font.Block, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>(' ', Font.Block, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('(', Font.Block, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>(')', Font.Block, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('[', Font.Block, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>(']', Font.Block, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('<', Font.Block, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('>', Font.Block, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('{', Font.Block, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('}', Font.Block, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('/', Font.Block, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('\\', Font.Block, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('.', Font.Block, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>(',', Font.Block, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>(':', Font.Block, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>(';', Font.Block, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('\'', Font.Block, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('"', Font.Block, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('!', Font.Block, FontSize.Large), new string[]
            {
                "▄███▄ ",
                "█████ ",
                "█████ ",
                "█████ ",
                "▀███▀ ",
                " ███  ",
                "      ",
                " ███  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('?', Font.Block, FontSize.Large), new string[]
            {
                " ▄███████▄  ",
                "██▀    ▀███ ",
                "        ███ ",
                "    ▄▄▄██▀  ",
                "    ███     ",
                "    ███     ",
                "            ",
                "    ███     "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('A', Font.Block, FontSize.Medium), new string[]
            {
                "▄█████▄ ",
                "██   ██ ",
                "██   ██ ",
                "███████ ",
                "██   ██ ",
                "██   ██ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('B', Font.Block, FontSize.Medium), new string[]
            {
                "██████▄ ",
                "██   ██ ",
                "██▄▄▄█▀ ",
                "██▀▀▀█▄ ",
                "██   ██ ",
                "██████▀ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('C', Font.Block, FontSize.Medium), new string[]
            {
                "▄█████▄ ",
                "██   ██ ",
                "██      ",
                "██      ",
                "██   ██ ",
                "▀█████▀ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('D', Font.Block, FontSize.Medium), new string[]
            {
                "██████▄  ",
                "██   ▀██ ",
                "██    ██ ",
                "██    ██ ",
                "██   ▄██ ",
                "██████▀  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('E', Font.Block, FontSize.Medium), new string[]
            {
                "██████ ",
                "██     ",
                "██▄▄   ",
                "██▀▀   ",
                "██     ",
                "██████ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('F', Font.Block, FontSize.Medium), new string[]
            {
                "██████ ",
                "██     ",
                "██▄▄   ",
                "██▀▀   ",
                "██     ",
                "██     "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('G', Font.Block, FontSize.Medium), new string[]
            {
                "▄█████▄ ",
                "██   ██ ",
                "██      ",
                "██  ███ ",
                "██   ██ ",
                "▀█████▀ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('H', Font.Block, FontSize.Medium), new string[]
            {
                "██   ██ ",
                "██   ██ ",
                "██▄▄▄██ ",
                "██▀▀▀██ ",
                "██   ██ ",
                "██   ██ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('I', Font.Block, FontSize.Medium), new string[]
            {
                "██ ",
                "██ ",
                "██ ",
                "██ ",
                "██ ",
                "██ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('J', Font.Block, FontSize.Medium), new string[]
            {
                "     ██ ",
                "     ██ ",
                "     ██ ",
                "     ██ ",
                "▄▄  ▄██ ",
                "▀█████▀ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('K', Font.Block, FontSize.Medium), new string[]
            {
                "██   ▄█▀ ",
                "██ ▄█▀   ",
                "███▀     ",
                "███▄     ",
                "██ ▀█▄   ",
                "██   ▀█▄ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('L', Font.Block, FontSize.Medium), new string[]
            {
                "██       ",
                "██       ",
                "██       ",
                "██       ",
                "██       ",
                "████████ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('M', Font.Block, FontSize.Medium), new string[]
            {
                "███▄  ▄███ ",
                "██▀█▄▄█▀██ ",
                "██ ▀██▀ ██ ",
                "██      ██ ",
                "██      ██ ",
                "██      ██ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('N', Font.Block, FontSize.Medium), new string[]
            {
                "██     ██ ",
                "███▄   ██ ",
                "██▀█▄  ██ ",
                "██ ▀█▄ ██ ",
                "██  ▀█▄██ ",
                "██    ▀██ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('O', Font.Block, FontSize.Medium), new string[]
            {
                "▄██████▄ ",
                "██    ██ ",
                "██    ██ ",
                "██    ██ ",
                "██    ██ ",
                "▀██████▀ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('P', Font.Block, FontSize.Medium), new string[]
            {
                "██████▄ ",
                "██   ██ ",
                "██   ██ ",
                "██████▀ ",
                "██      ",
                "██      "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('Q', Font.Block, FontSize.Medium), new string[]
            {
                "▄█████▄  ",
                "██   ██  ",
                "██   ██  ",
                "██   ██  ",
                "██ ▀▄██  ",
                "▀█████▀▄ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('R', Font.Block, FontSize.Medium), new string[]
            {
                "██████▄ ",
                "██   ██ ",
                "██   ██ ",
                "██████▀ ",
                "██▀██▄  ",
                "██  ▀██ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('S', Font.Block, FontSize.Medium), new string[]
            {
                "▄█████▄ ",
                "██   ▀▀ ",
                "██▄▄▄▄  ",
                " ▀▀▀▀██ ",
                "▄▄   ██ ",
                "▀█████▀ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('T', Font.Block, FontSize.Medium), new string[]
            {
                "████████ ",
                "   ██    ",
                "   ██    ",
                "   ██    ",
                "   ██    ",
                "   ██    "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('U', Font.Block, FontSize.Medium), new string[]
            {
                "██   ██ ",
                "██   ██ ",
                "██   ██ ",
                "██   ██ ",
                "██   ██ ",
                "▀█████▀ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('V', Font.Block, FontSize.Medium), new string[]
            {
                "██    ██ ",
                "██    ██ ",
                "██    ██ ",
                "██    ██ ",
                " █▄  ▄█  ",
                "  ▀██▀   "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('W', Font.Block, FontSize.Medium), new string[]
            {
                "██      ██ ",
                "██      ██ ",
                "██      ██ ",
                "██ ▄██▄ ██ ",
                "██▄█▀▀█▄██ ",
                "███▀  ▀███ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('X', Font.Block, FontSize.Medium), new string[]
            {
                "▀██▄   ▄██▀ ",
                " ▀██▄ ▄██▀  ",
                "   ▀███▀    ",
                "   ▄███▄    ",
                " ▄██▀ ▀██▄  ",
                "▄██▀   ▀██▄ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('Y', Font.Block, FontSize.Medium), new string[]
            {
                "▀██▄   ▄██▀ ",
                " ▀██▄ ▄██▀  ",
                "   ▀███▀    ",
                "    ▐█▌     ",
                "    ▐█▌     ",
                "    ▐█▌     "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('Z', Font.Block, FontSize.Medium), new string[]
            {
                "███████ ",
                "    ▄█▀ ",
                "   ▄█▀  ",
                "  ▄█▀   ",
                " ▄█▀    ",
                "███████ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('1', Font.Block, FontSize.Medium), new string[]
            {
                "▄███   ",
                "  ██   ",
                "  ██   ",
                "  ██   ",
                "  ██   ",
                "▄▄██▄▄ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('2', Font.Block, FontSize.Medium), new string[]
            {
                " ▄█████▄  ",
                "██▀   ▄██ ",
                "    ▄██▀  ",
                " ▄██▀     ",
                "██▄       ",
                "█████████ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('3', Font.Block, FontSize.Medium), new string[]
            {
                "███████▄  ",
                "      ███ ",
                "    ▄██▀  ",
                "   ▀▀██▄  ",
                "      ███ ",
                "███████▀  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('4', Font.Block, FontSize.Medium), new string[]
            {
                "██   ██ ",
                "██   ██ ",
                "██   ██ ",
                "███████ ",
                "     ██ ",
                "     ██ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('5', Font.Block, FontSize.Medium), new string[]
            {
                "███████ ",
                "██      ",
                "██████▄ ",
                "     ██ ",
                "     ██ ",
                "██████▀  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('6', Font.Block, FontSize.Medium), new string[]
            {
                "▄██▀     ",
                "██       ",
                "███████▄ ",
                "██    ██ ",
                "██    ██ ",
                "▀██████▀ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('7', Font.Block, FontSize.Medium), new string[]
            {
                "█████████ ",
                "      ▄██ ",
                "    ▄██▀  ",
                "  ▄██▀    ",
                "▄██▀      ",
                "███       "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('8', Font.Block, FontSize.Medium), new string[]
            {
                "▄██▀▀██▄ ",
                "▀█▄  ▄█▀ ",
                "  ▀██▀   ",
                "  ▄██▄   ",
                "▄█▀  ▀█▄ ",
                "▀██▄▄██▀ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('9', Font.Block, FontSize.Medium), new string[]
            {
                "▄█████▄ ",
                "██   ██ ",
                "██   ██ ",
                "▀██████ ",
                "     ██ ",
                " █████▀ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('0', Font.Block, FontSize.Medium), new string[]
            {
                " ▄████▄  ",
                "██    ██ ",
                "██ ▄█ ██ ",
                "██ █▀ ██ ",
                "██    ██ ",
                " ▀████▀  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>(' ', Font.Block, FontSize.Medium), new string[]
            {
                "     ",
                "     ",
                "     ",
                "     ",
                "     ",
                "     "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('(', Font.Block, FontSize.Medium), new string[]
            {
                "  ▄█▀ ",
                " █    ",
                "█     ",
                "█     ",
                " █    ",
                "  ▀█▄ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>(')', Font.Block, FontSize.Medium), new string[]
            {
                "▀█▄   ",
                "   █  ",
                "    █ ",
                "    █ ",
                "   █  ",
                "▄█▀   "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('[', Font.Block, FontSize.Medium), new string[]
            {
                "█▀▀ ",
                "█   ",
                "█   ",
                "█   ",
                "█   ",
                "█▄▄ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>(']', Font.Block, FontSize.Medium), new string[]
            {
                " ▀▀█ ",
                "   █ ",
                "   █ ",
                "   █ ",
                "   █ ",
                " ▄▄█ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('<', Font.Block, FontSize.Medium), new string[]
            {
                "    ▄ ",
                "  ▄▀  ",
                "▄▀    ",
                "▀▄    ",
                "  ▀▄  ",
                "    ▀ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('>', Font.Block, FontSize.Medium), new string[]
            {
                "▄     ",
                " ▀▄   ",
                "   ▀▄ ",
                "   ▄▀ ",
                " ▄▀   ",
                "▀     "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('{', Font.Block, FontSize.Medium), new string[]
            {
                "   ▄█▀ ",
                "  █    ",
                "▄█▀    ",
                "▀█▄    ",
                "  █    ",
                "   ▀█▄ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('}', Font.Block, FontSize.Medium), new string[]
            {
                "▀█▄    ",
                "   █   ",
                "   ▀█▄ ",
                "   ▄█▀ ",
                "   █   ",
                "▄█▀    "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('/', Font.Block, FontSize.Medium), new string[]
            {
                "     ▄█ ",
                "    ▄█▀ ",
                "   ▄█▀  ",
                "  ▄█▀   ",
                " ▄█▀    ",
                "▄█▀     "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('\\', Font.Block, FontSize.Medium), new string[]
            {
                " █▄      ",
                " ▀█▄     ",
                "  ▀█▄    ",
                "   ▀█▄   ",
                "    ▀█▄  ",
                "     ▀█▄ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('.', Font.Block, FontSize.Medium), new string[]
            {
                "   ",
                "   ",
                "   ",
                "   ",
                "   ",
                "██ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>(',', Font.Block, FontSize.Medium), new string[]
            {
                "   ",
                "   ",
                "   ",
                "   ",
                "▄▄ ",
                "▄█ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>(':', Font.Block, FontSize.Medium), new string[]
            {
                "     ",
                "     ",
                "██   ",
                "     ",
                "██   ",
                "     "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>(';', Font.Block, FontSize.Medium), new string[]
            {
                "    ",
                "    ",
                "██  ",
                "    ",
                "▀█  ",
                "▀   "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('\'', Font.Block, FontSize.Medium), new string[]
            {
                "█ ",
                "  ",
                "  ",
                "  ",
                "  ",
                "  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('"', Font.Block, FontSize.Medium), new string[]
            {
                "█ █ ",
                "    ",
                "    ",
                "    ",
                "    ",
                "    "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('!', Font.Block, FontSize.Medium), new string[]
            {
                "▄███▄ ",
                "█████ ",
                "▀███▀ ",
                " ███  ",
                "      ",
                " ███  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('?', Font.Block, FontSize.Medium), new string[]
            {
                "▄██████▄  ",
                "██▀   ▀██ ",
                "   ▄▄▄██▀ ",
                "   ███    ",
                "          ",
                "   ███    "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('A', Font.Block, FontSize.Small), new string[]
            {
                "▄████▄ ",
                "██  ██ ",
                "██████ ",
                "██  ██ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('B', Font.Block, FontSize.Small), new string[]
            {
                "██▀▀█▄ ",
                "██▄▄█▀ ",
                "██  ██ ",
                "█████▀ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('C', Font.Block, FontSize.Small), new string[]
            {
                "▄████▄ ",
                "██  ▀▀ ",
                "██  ▄▄ ",
                "▀████▀ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('D', Font.Block, FontSize.Small), new string[]
            {
                "█████▄ ",
                "██  ██ ",
                "██  ██ ",
                "█████▀ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('E', Font.Block, FontSize.Small), new string[]
            {
                "█████ ",
                "██▄▄  ",
                "██▀▀  ",
                "█████ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('F', Font.Block, FontSize.Small), new string[]
            {
                "█████ ",
                "██▄▄  ",
                "██▀▀  ",
                "██    "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('G', Font.Block, FontSize.Small), new string[]
            {
                "▄████▄ ",
                "██  ▀▀ ",
                "██ ▀██ ",
                "▀████▀ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('H', Font.Block, FontSize.Small), new string[]
            {
                "██  ██ ",
                "██▄▄██ ",
                "██▀▀██ ",
                "██  ██ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('I', Font.Block, FontSize.Small), new string[]
            {
                "██ ",
                "██ ",
                "██ ",
                "██ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('J', Font.Block, FontSize.Small), new string[]
            {
                "    ██ ",
                "    ██ ",
                "▄▄  ██ ",
                "▀████▀ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('K', Font.Block, FontSize.Small), new string[]
            {
                "██ ▄█▀ ",
                "███▀   ",
                "███▄   ",
                "██ ▀█▄ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('L', Font.Block, FontSize.Small), new string[]
            {
                "██     ",
                "██     ",
                "██     ",
                "██████ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('M', Font.Block, FontSize.Small), new string[]
            {
                "███▄███ ",
                "██ ▀ ██ ",
                "██   ██ ",
                "██   ██ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('N', Font.Block, FontSize.Small), new string[]
            {
                "██  ██ ",
                "███▄██ ",
                "██▀███ ",
                "██  ██ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('O', Font.Block, FontSize.Small), new string[]
            {
                "▄████▄ ",
                "██  ██ ",
                "██  ██ ",
                "▀████▀ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('P', Font.Block, FontSize.Small), new string[]
            {
                "█████▄ ",
                "██  ██ ",
                "██▀▀▀  ",
                "██     "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('Q', Font.Block, FontSize.Small), new string[]
            {
                "▄████▄  ",
                "██  ██  ",
                "██ ▄██  ",
                "▀████▀▄ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('R', Font.Block, FontSize.Small), new string[]
            {
                "████▄ ",
                "██ ██ ",
                "████▀ ",
                "██▀█▄ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('S', Font.Block, FontSize.Small), new string[]
            {
                "▄████ ",
                "██▄▄▄ ",
                "▀▀▀██ ",
                "████▀ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('T', Font.Block, FontSize.Small), new string[]
            {
                "██████ ",
                "  ██   ",
                "  ██   ",
                "  ██   "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('U', Font.Block, FontSize.Small), new string[]
            {
                "██ ██ ",
                "██ ██ ",
                "██ ██ ",
                "▀███▀ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('V', Font.Block, FontSize.Small), new string[]
            {
                "██ ██ ",
                "██ ██ ",
                "▐█ █▌ ",
                " ▀█▀  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('W', Font.Block, FontSize.Small), new string[]
            {
                "██   ██ ",
                "██   ██ ",
                "██ ▄ ██ ",
                "███▀███ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('X', Font.Block, FontSize.Small), new string[]
            {
                "▀█▄ ▄█▀ ",
                " ▀█▄█▀  ",
                " ▄█▀█▄  ",
                "▄█▀ ▀█▄ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('Y', Font.Block, FontSize.Small), new string[]
            {
                "▀█▄ ▄█▀ ",
                " ▀█▄█▀  ",
                "  ▐█▌   ",
                "  ▐█▌   "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('Z', Font.Block, FontSize.Small), new string[]
            {
                "█████ ",
                "  ▄█▀ ",
                " ▄█▀  ",
                "█████ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('1', Font.Block, FontSize.Small), new string[]
            {
                "▄███  ",
                "  ██  ",
                "  ██  ",
                "▄▄██▄ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('2', Font.Block, FontSize.Small), new string[]
            {
                "▄████▄ ",
                "▀  ▄█▀ ",
                " ▄█▀   ",
                "██████ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('3', Font.Block, FontSize.Small), new string[]
            {
                "█████▄ ",
                "    ██ ",
                "   ▀█▄ ",
                "█████▀ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('4', Font.Block, FontSize.Small), new string[]
            {
                "██  ██ ",
                "██  ██ ",
                "██████ ",
                "    ██ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('5', Font.Block, FontSize.Small), new string[]
            {
                "██▀▀▀▀ ",
                "██▄▄▄  ",
                "    ██ ",
                "█████▀ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('6', Font.Block, FontSize.Small), new string[]
            {
                "▄█▀    ",
                "██▄▄▄  ",
                "██  ██ ",
                "▀████▀ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('7', Font.Block, FontSize.Small), new string[]
            {
                "██████ ",
                "  ▄██▀ ",
                "▄██▀   ",
                "██     ",
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('8', Font.Block, FontSize.Small), new string[]
            {
                "▄██▀██▄ ",
                "▀█▄▄▄█▀ ",
                "▄█▀ ▀█▄ ",
                "▀██▄██▀ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('9', Font.Block, FontSize.Small), new string[]
            {
                "▄█████▄ ",
                "██   ██ ",
                " ▀▀▀▀██ ",
                " ▄▄▄▄█▀ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('0', Font.Block, FontSize.Small), new string[]
            {
                "▄█████▄ ",
                "██ ▄ ██ ",
                "██ ▀ ██ ",
                "▀█████▀ " 
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>(' ', Font.Block, FontSize.Small), new string[]
            {
                "   ",
                "   ",
                "   ",
                "   "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('(', Font.Block, FontSize.Small), new string[]
            {
                " ▄█▀ ",
                "█    ",
                "█    ",
                " ▀█▄ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>(')', Font.Block, FontSize.Small), new string[]
            {
                "▀█▄  ",
                "   █ ",
                "   █ ",
                "▄█▀  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('[', Font.Block, FontSize.Small), new string[]
            {
                "█▀▀ ",
                "█   ",
                "█   ",
                "█▄▄ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>(']', Font.Block, FontSize.Small), new string[]
            {
                " ▀▀█ ",
                "   █ ",
                "   █ ",
                " ▄▄█ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('<', Font.Block, FontSize.Small), new string[]
            {
                "  ▄ ",
                "▄▀  ",
                "▀▄  ",
                "  ▀ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('>', Font.Block, FontSize.Small), new string[]
            {
                "▄   ",
                " ▀▄ ",
                " ▄▀ ",
                "▀   "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('{', Font.Block, FontSize.Small), new string[]
            {
                "   ▄█▀ ",
                " ▄█    ",
                " ▀█    ",
                "   ▀█▄ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('}', Font.Block, FontSize.Small), new string[]
            {
                "▀█▄   ",
                "   █▄ ",
                "   █▀ ",
                "▄█▀   "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('/', Font.Block, FontSize.Small), new string[]
            {
                "   ▄▀ ",
                "  ▄▀  ",
                " ▄▀   ",
                "▄▀    ",
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('\\', Font.Block, FontSize.Small), new string[]
            {
                "▀▄    ",
                " ▀▄   ",
                "  ▀▄  ",
                "   ▀▄ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('.', Font.Block, FontSize.Small), new string[]
            {
                "   ",
                "   ",
                "   ",
                "▄  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>(',', Font.Block, FontSize.Small), new string[]
            {
                "   ",
                "   ",
                "   ",
                "▄▀ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>(':', Font.Block, FontSize.Small), new string[]
            {
                "  ",
                "  ",
                "▄ ",
                "▄ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>(';', Font.Block, FontSize.Small), new string[]
            {
                "   ",
                "   ",
                " ▀ ",
                "▄▀ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('\'', Font.Block, FontSize.Small), new string[]
            {
                "▀ ",
                "  ",
                "  ",
                "  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('"', Font.Block, FontSize.Small), new string[]
            {
                "▀ ▀ ",
                "    ",
                "    ",
                "    "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('!', Font.Block, FontSize.Small), new string[]
            {
                "▄██▄ ",
                "▀██▀ ",
                " ██  ",
                " ▄▄  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('?', Font.Block, FontSize.Small), new string[]
            {
                "▄███▄  ",
                "▀   ██ ",
                "  ██▀  ",
                "  ▄▄   "
            });

            #endregion

            #region Graffiti

            /*
            █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀ 
            █  
            █      ▄██████▄     ▄████████   ▄████████     ▄████████    ▄████████  ▄█      ███      ▄█
            █     ███    ███   ███    ███   ███    ███   ███    ███   ███    ███ ███  ▀█████████▄ ███
            █     ███    █▀   ▄███▄▄▄▄██▀   ███    ███   ███    █▀    ███    █▀  ███▌    ▀███▀▀██ ███▌
            █    ▄███        ▀▀███▀▀▀▀▀     ███    ███  ▄███▄▄▄      ▄███▄▄▄     ███▌     ███   ▀ ███▌
            █   ▀▀███ ████▄  ▀███████████ ▀███████████ ▀▀███▀▀▀     ▀▀███▀▀▀     ███▌     ███     ███▌
            █     ███    ███   ███    ███   ███    ███   ███          ███        ███      ███     ███
            █     ███    ███   ███    ███   ███    ███   ███          ███        ███      ███     ███
            █     ████████▀    ███    ███   ███    █▀    ███          ███        █▀      ▄████▀   █▀
            █
            ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀ ▀                                 */

            Alphabet.Add(new Tuple<char, Font, FontSize>('A', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('B', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('C', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('D', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('E', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('F', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('G', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('H', Font.Graffiti, FontSize.Large), new string[] 
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('I', Font.Graffiti, FontSize.Large), new string[] 
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('J', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('K', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('L', Font.Graffiti, FontSize.Large), new string[]
            {
                " ▄█       ",
                "███       ",
                "███       ",
                "███       ",
                "███       ",
                "███       ",
                "███▌    ▄ ",
                "█████▄▄██ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('M', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('N', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('O', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('P', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('Q', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('R', Font.Graffiti, FontSize.Large), new string[]
            {
                "   ▄████████ ",
                "  ███    ███ ",
                " ▄███▄▄▄▄██▀ ",
                "▀▀███▀▀▀▀▀   ",
                "▀███████████ ",
                "  ███    ███ ",
                "  ███    ███ ",
                "  ███    ███ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('S', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('T', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('U', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('V', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('W', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('X', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('Y', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('Z', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('1', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('2', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('3', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('4', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('5', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('6', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('7', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('8', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('9', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('0', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>(' ', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('(', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>(')', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('[', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>(']', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('<', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('>', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('{', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('}', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('/', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('\\', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('.', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>(',', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>(':', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>(';', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('\'', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('"', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('!', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('?', Font.Graffiti, FontSize.Large), new string[]
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

            Alphabet.Add(new Tuple<char, Font, FontSize>('A', Font.Graffiti, FontSize.Medium), new string[]
            {
                "  ▄█████  ",
                "  ██   ██ ",
                "  ██   ██ ",
                "▀████████ ",
                "  ██   ██ ",
                "  ██   █▀ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('B', Font.Graffiti, FontSize.Medium), new string[]
            {
                "▀██████▄  ",
                "  ██   ██ ",
                " ▄██▄▄█▀  ",
                "▀▀██▀▀█▄  ",
                "  ██   ██ ",
                "▄██████▀  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('C', Font.Graffiti, FontSize.Medium), new string[]
            {
                " ▄██████ ",
                "██    ██ ",
                "██    ▀  ",
                "██    ▄  ",
                "██    ██ ",
                "██████▀  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('D', Font.Graffiti, FontSize.Medium), new string[]
            {
                "██████▄  ",
                "██   ▀██ ",
                "██    ██ ",
                "██    ██ ",
                "██   ▄██ ",
                "██████▀  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('E', Font.Graffiti, FontSize.Medium), new string[]
            {
                "   ▄█████ ",
                "  ██   █  ",
                " ▄██▄▄    ",
                "▀▀██▀▀    ",
                "  ██   █  ",
                "  ███████ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('F', Font.Graffiti, FontSize.Medium), new string[]
            {
                "   ▄█████ ",
                "  ██   ▀█ ",
                " ▄██▄▄    ",
                "▀▀██▀▀    ",
                "  ██      ",
                "  ██      "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('G', Font.Graffiti, FontSize.Medium), new string[]
            {
                "   ▄████▄  ",
                "  ██    ▀  ",
                " ▄██       ",
                "▀▀██ ███▄  ",
                "  ██    ██ ",
                "  ██████▀  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('H', Font.Graffiti, FontSize.Medium), new string[]
            {
                "  ██   █    ",
                "  ██   ██   ",
                " ▄██▄▄▄██▄▄ ",
                "▀▀██▀▀▀██▀  ",
                "  ██   ██   ",
                "  ██   ██   "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('I', Font.Graffiti, FontSize.Medium), new string[]
            {
                " █  ",
                "██  ",
                "██▌ ",
                "██  ",
                "██  ",
                "█   "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('J', Font.Graffiti, FontSize.Medium), new string[]
            {
                "     █ ",
                "    ██ ",
                "    ██ ",
                "    ██ ",
                "█▄ ▄██ ",
                "▀▀▀▀▀  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('K', Font.Graffiti, FontSize.Medium), new string[]
            {
                "   █  █▄   ",
                "  ██ ▄██▀  ",
                "  ██▐█▀    ",
                "▀▀████     ",
                "  ██ ▀██▄  ",
                "  ▀█   ▀█▀ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('L', Font.Graffiti, FontSize.Medium), new string[]
            {
                " █       ",
                "██       ",
                "██       ",
                "██       ",
                "██▌    ▄ ",
                "████▄▄██ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('M', Font.Graffiti, FontSize.Medium), new string[]
            {
                "   ▄▄██▄▄▄  ",
                " ▄█▀▀██▀▀█▄ ",
                " ██  ██  ██ ",
                " ██  ██  ██ ",
                " ██  ██  ██ ",
                "  █  ██  █  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('N', Font.Graffiti, FontSize.Medium), new string[]
            {
                "██▄▄▄▄  ",
                "██▀▀▀█▄ ",
                "██   ██ ",
                "██   ██ ",
                "██   ██ ",
                " █   █  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('O', Font.Graffiti, FontSize.Medium), new string[]
            {
                " ██████  ",
                "██    ██ ",
                "██    ██ ",
                "██    ██ ",
                "██    ██ ",
                " ██████  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('P', Font.Graffiti, FontSize.Medium), new string[]
            {
                "   █████▄ ",
                "  ██   ██ ",
                "  ██   ██ ",
                "▀██████▀  ",
                "  ██      ",
                " ▄███▀    "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('Q', Font.Graffiti, FontSize.Medium), new string[]
            {
                "██████   ",
                "██   ██  ",
                "██   ██  ",
                "██   ██  ",
                "██ ▀ ██  ",
                " ████▀▄█ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('R', Font.Graffiti, FontSize.Medium), new string[]
            {
                "   █████ ",
                "  ██  ██ ",
                " ▄██▄▄█▀ ",
                "▀███████ ",
                "  ██  ██ ",
                "  ██  ██ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('S', Font.Graffiti, FontSize.Medium), new string[]
            {
                "  ▄█████ ",
                "  ██  ▀  ",
                "  ██     ",
                "▀███████ ",
                "   ▄  ██ ",
                " ▄████▀  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('T', Font.Graffiti, FontSize.Medium), new string[]
            {
                "    ██    ",
                "▀███████▄ ",
                "    ██  ▀ ",
                "    ██    ",
                "    ██    ",
                "   ▄██▀   "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('U', Font.Graffiti, FontSize.Medium), new string[]
            {
                "██   █  ",
                "██   ██ ",
                "██   ██ ",
                "██   ██ ",
                "██   ██ ",
                "██████  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('V', Font.Graffiti, FontSize.Medium), new string[]
            {
                " █    █  ",
                "██    ██ ",
                "██    ██ ",
                "██    ██ ",
                " █▄  ▄█  ",
                "  ▀██▀   "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('W', Font.Graffiti, FontSize.Medium), new string[]
            {
                " █     █  ",
                "██     ██ ",
                "██     ██ ",
                "██     ██ ",
                "██ ▄█▄ ██ ",
                " ███▀███  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('X', Font.Graffiti, FontSize.Medium), new string[]
            {
                "▀███  ▐██▀ ",
                "  ██  ██   ",
                "   ████▀   ",
                "   ████    ",
                " ▄██ ▀██   ",
                "███    ██▄ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('Y', Font.Graffiti, FontSize.Medium), new string[]
            {
                "▄█   ▄  ",
                "██   █▄ ",
                "▀▀▀▀▀██ ",
                "▄█   ██ ",
                "██   ██ ",
                " █████  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('Z', Font.Graffiti, FontSize.Medium), new string[]
            {
                " ▄██████▄ ",
                "██▀    ▄█ ",
                " ▀  ▄██▀  ",
                "  ▄██▀  ▀ ",
                " ██▄   ▄█ ",
                "▀██████▀  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('1', Font.Graffiti, FontSize.Medium), new string[]
            {
                "▄███   ",
                "  ██   ",
                "  ██▌  ",
                "  ██▌  ",
                "  ██   ",
                "▄▄██▄▄ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('2', Font.Graffiti, FontSize.Medium), new string[]
            {
                " ▄█████▄  ",
                "██▀   ▄██ ",
                "▀   ▄██▀  ",
                " ▄██▀     ",
                "██▄    ▄█ ",
                "▀███████▀ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('3', Font.Graffiti, FontSize.Medium), new string[]
            {
                "███████▄  ",
                "▀     ███ ",
                "    ▄██▀  ",
                "   ▀▀██▄  ",
                "▄     ███ ",
                "▄██████▀  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('4', Font.Graffiti, FontSize.Medium), new string[]
            {
                "  ▄█   █  ",
                "  ██   ██ ",
                "  ██   ██ ",
                "▀████████ ",
                "       ██ ",
                "       █▀ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('5', Font.Graffiti, FontSize.Medium), new string[]
            {
                "  ███████ ",
                "  ██      ",
                "▀████████ ",
                "       ██ ",
                "   ▄   ██ ",
                " ▄█████▀  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('6', Font.Graffiti, FontSize.Medium), new string[]
            {
                " ▄███▀     ",
                "  ██       ",
                "▀███████▄  ",
                "  ██    ██ ",
                "  ██    ██ ",
                "  ▀█████▀  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('7', Font.Graffiti, FontSize.Medium), new string[]
            {
                "▄██████▄  ",
                "      ▄██ ",
                "    ▄██▀  ",
                "█▀▄██▀ █▀ ",
                "▄██▀      ",
                "▀██       "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('8', Font.Graffiti, FontSize.Medium), new string[]
            {
                " ▄██▀▀█▄  ",
                " ▀█▄  ▄█▀ ",
                "  ▀▄██▀   ",
                " ▄██▀▄▄   ",
                "██▄   ▄██ ",
                " ▀█████▀  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('9', Font.Graffiti, FontSize.Medium), new string[]
            {
                "▄█████▄   ",
                "██▀   ██  ",
                "█▄    ██  ",
                "▀███████▀ ",
                " ▄    ██  ",
                " ██▄▄███▄ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('0', Font.Graffiti, FontSize.Medium), new string[]
            {
                " ▄████▄  ",
                "██    ██ ",
                "██ ▄█ ██ ",
                "██ █▀ ██ ",
                "██    ██ ",
                " ▀████▀  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>(' ', Font.Graffiti, FontSize.Medium), new string[]
            {
                "     ",
                "     ",
                "     ",
                "     ",
                "     ",
                "     "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('(', Font.Graffiti, FontSize.Medium), new string[]
            {
                "  ▄█▀ ",
                " █    ",
                "█     ",
                "█     ",
                " █    ",
                "  ▀█▄ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>(')', Font.Graffiti, FontSize.Medium), new string[]
            {
                "▀█▄   ",
                "   █  ",
                "    █ ",
                "    █ ",
                "   █  ",
                "▄█▀   "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('[', Font.Graffiti, FontSize.Medium), new string[]
            {
                "█▀▀ ",
                "█   ",
                "█   ",
                "█   ",
                "█   ",
                "█▄▄ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>(']', Font.Graffiti, FontSize.Medium), new string[]
            {
                " ▀▀█ ",
                "   █ ",
                "   █ ",
                "   █ ",
                "   █ ",
                " ▄▄█ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('<', Font.Graffiti, FontSize.Medium), new string[]
            {
                "    ▄ ",
                "  ▄▀  ",
                "▄▀    ",
                "▀▄    ",
                "  ▀▄  ",
                "    ▀ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('>', Font.Graffiti, FontSize.Medium), new string[]
            {
                "▄     ",
                " ▀▄   ",
                "   ▀▄ ",
                "   ▄▀ ",
                " ▄▀   ",
                "▀     "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('{', Font.Graffiti, FontSize.Medium), new string[]
            {
                "   ▄█▀ ",
                "  █    ",
                "▄█▀    ",
                "▀█▄    ",
                "  █    ",
                "   ▀█▄ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('}', Font.Graffiti, FontSize.Medium), new string[]
            {
                "▀█▄    ",
                "   █   ",
                "   ▀█▄ ",
                "   ▄█▀ ",
                "   █   ",
                "▄█▀    "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('/', Font.Graffiti, FontSize.Medium), new string[]
            {
                "     ▄█ ",
                "    ▄█▀ ",
                "   ▄█▀  ",
                "  ▄█▀   ",
                " ▄█▀    ",
                "▄█▀     "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('\\', Font.Graffiti, FontSize.Medium), new string[]
            {
                " █▄      ",
                " ▀█▄     ",
                "  ▀█▄    ",
                "   ▀█▄   ",
                "    ▀█▄  ",
                "     ▀█▄ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('.', Font.Graffiti, FontSize.Medium), new string[]
            {
                "   ",
                "   ",
                "   ",
                "   ",
                "   ",
                "██ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>(',', Font.Graffiti, FontSize.Medium), new string[]
            {
                "   ",
                "   ",
                "   ",
                "   ",
                "▄▄ ",
                "▄█ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>(':', Font.Graffiti, FontSize.Medium), new string[]
            {
                "     ",
                "     ",
                "██   ",
                "     ",
                "██   ",
                "     "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>(';', Font.Graffiti, FontSize.Medium), new string[]
            {
                "    ",
                "    ",
                "██  ",
                "    ",
                "▀█  ",
                "▀   "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('\'', Font.Graffiti, FontSize.Medium), new string[]
            {
                "█ ",
                "  ",
                "  ",
                "  ",
                "  ",
                "  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('"', Font.Graffiti, FontSize.Medium), new string[]
            {
                "█ █ ",
                "    ",
                "    ",
                "    ",
                "    ",
                "    "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('!', Font.Graffiti, FontSize.Medium), new string[]
            {
                " ▄███▄  ",
                "▀█████▀ ",
                " ▀███▀  ",
                "  ███   ",
                "        ",
                "  ██▀   "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('?', Font.Graffiti, FontSize.Medium), new string[]
            {
                "▄██████▄  ",
                "██▀   ▀██ ",
                "   ▄▄▄██▀ ",
                "   ███    ",
                "          ",
                "   ██▀    "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('A', Font.Graffiti, FontSize.Small), new string[]
            {
                "▄█████  ",
                "██   ██ ",
                "███████ ",
                "██   ██ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('B', Font.Graffiti, FontSize.Small), new string[]
            {
                "▀█████▄ ",
                " ██▄▄▄▀ ",
                " ██   █ ",
                "▄█████▀ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('C', Font.Graffiti, FontSize.Small), new string[]
            {
                "▄█████  ",
                "██   ▀  ",
                "██   ▄  ",
                "█████▀  ",
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('D', Font.Graffiti, FontSize.Small), new string[]
            {
                "█████▄  ",
                "██   ██ ",
                "██   ██ ",
                "█████▀  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('E', Font.Graffiti, FontSize.Small), new string[]
            {
                " ▄████  ",
                " ██     ",
                "▀██▀▀   ",
                " ██████ ",
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('F', Font.Graffiti, FontSize.Small), new string[]
            {
                "   ▄████ ",
                " ▄██▄▄▄  ",
                "  ██     ",
                "  ██     "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('G', Font.Graffiti, FontSize.Small), new string[]
            {
                "  ▄████▄ ",
                " ██    ▀ ",
                "▀██ ▀▀█▄ ",
                " ██████▀ ",
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('H', Font.Graffiti, FontSize.Small), new string[]
            {
                " ██  █   ",
                " ██▄▄██▄ ",
                "▀██▀▀██  ",
                " ██  ██  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('I', Font.Graffiti, FontSize.Small), new string[]
            {
                " █ ",
                "██ ",
                "██ ",
                "█  ",
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('J', Font.Graffiti, FontSize.Small), new string[]
            {
                "    █ ",
                "   ██ ",
                "▄ ▄██ ",
                "▀▀▀▀  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('K', Font.Graffiti, FontSize.Small), new string[]
            {
                " ██ ▄█▀  ",
                " ██▐█▀   ",
                "▀████    ",
                " ██ ▀█▄  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('L', Font.Graffiti, FontSize.Small), new string[]
            {
                " █     ",
                "██     ",
                "██   ▄ ",
                "██▄▄██ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('M', Font.Graffiti, FontSize.Small), new string[]
            {
                "  ▄▄███▄▄  ",
                "▄█▀▀██▀▀█▄ ",
                "██  ██  ██ ",
                " █  ██  █  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('N', Font.Graffiti, FontSize.Small), new string[]
            {
                "██▄▄▄  ",
                "██▀▀█▄ ",
                "██  ██ ",
                " █  █  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('O', Font.Graffiti, FontSize.Small), new string[]
            {
                " █████  ",
                "██   ██ ",
                "██   ██ ",
                " █████  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('P', Font.Graffiti, FontSize.Small), new string[]
            {
                "  █████▄ ",
                " ██   ██ ",
                "▀██▀▀▀▀  ",
                "▄███▀    "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('Q', Font.Graffiti, FontSize.Small), new string[]
            {
                "██████   ",
                "██   ██  ",
                "██ ▀ ██  ",
                " ████▀▄█ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('R', Font.Graffiti, FontSize.Small), new string[]
            {
                "  █████ ",
                " ██  ██ ",
                "▄██▄▄█▀ ",
                " ██  ██ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('S', Font.Graffiti, FontSize.Small), new string[]
            {
                " ▄█████ ",
                " ██  ▀  ",
                "▀▀▀▀▀██ ",
                "▄█████▀ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('T', Font.Graffiti, FontSize.Small), new string[]
            {
                "   ██    ",
                "▀██████▄ ",
                "   ██    ",
                "  ▄██▀   "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('U', Font.Graffiti, FontSize.Small), new string[]
            {
                "█   █  ",
                "█   ██ ",
                "█   ██ ",
                "█████  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('V', Font.Graffiti, FontSize.Small), new string[]
            {
                " █   █  ",
                "██   ██ ",
                " █▄ ▄█  ",
                "  ▀█▀   "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('W', Font.Graffiti, FontSize.Small), new string[]
            {
                " █   █  ",
                "██   ██ ",
                "██▄█▄██ ",
                " ██▀██  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('X', Font.Graffiti, FontSize.Small), new string[]
            {
                " ██   ██ ",
                "  ██▄██▀ ",
                "  ▄█▀█▄  ",
                "▄██  ▀██ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('Y', Font.Graffiti, FontSize.Small), new string[]
            {
                "▄█  ▄  ",
                "▀▀▀▀██ ",
                "██  ██ ",
                " ████  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('Z', Font.Graffiti, FontSize.Small), new string[]
            {
                "▄████▄ ",
                "▀  ▄█▀ ",
                " ▄█▀ ▀ ",
                "█████▀ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('1', Font.Graffiti, FontSize.Small), new string[]
            {
                "▄██   ",
                "  █▌  ",
                "  █▌  ",
                "▄▄█▄▄ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('2', Font.Graffiti, FontSize.Small), new string[]
            {
                "▄████▄ ",
                "▀  ▄█▀ ",
                " ▄█▀   ",
                "██████ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('3', Font.Graffiti, FontSize.Small), new string[]
            {
                "████▄  ",
                "▀   ██ ",
                "▄  ▀██ ",
                "▄███▀  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('4', Font.Graffiti, FontSize.Small), new string[]
            {
                " ▄█  █  ",
                " ██  ██ ",
                "▀██████ ",
                "     █▀ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('5', Font.Graffiti, FontSize.Small), new string[]
            {
                " ██▀▀▀▀▀ ",
                "▀███████ ",
                "  ▄   ██ ",
                "▄█████▀  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('6', Font.Graffiti, FontSize.Small), new string[]
            {
                " ██▀     ",
                "▀█████▄  ",
                " █    ██ ",
                " ▀████▀  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('7', Font.Graffiti, FontSize.Small), new string[]
            {
                "▄█████▄ ",
                "   ▄██▀ ",
                "▀▄██▀ ▀ ",
                "██▀     ",
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('8', Font.Graffiti, FontSize.Small), new string[]
            {
                " ▄█▀▀█  ",
                " ▀▄▄▄▀  ",
                "██   ██ ",
                " ▀▄▄▄▀  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('9', Font.Graffiti, FontSize.Small), new string[]
            {
                "▄████   ",
                "█▀   █  ",
                "▀▀▀▀▀█▀ ",
                " █▄▄██▄ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('0', Font.Graffiti, FontSize.Small), new string[]
            {
                " ▄███▄  ",
                "██ ▄ ██ ",
                "██ ▀ ██ ",
                " ▀███▀  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>(' ', Font.Graffiti, FontSize.Small), new string[]
            {
                "   ",
                "   ",
                "   ",
                "   "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('(', Font.Graffiti, FontSize.Small), new string[]
            {
                " ▄█▀ ",
                "█    ",
                "█    ",
                " ▀█▄ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>(')', Font.Graffiti, FontSize.Small), new string[]
            {
                "▀█▄  ",
                "   █ ",
                "   █ ",
                "▄█▀  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('[', Font.Graffiti, FontSize.Small), new string[]
            {
                "█▀▀ ",
                "█   ",
                "█   ",
                "█▄▄ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>(']', Font.Graffiti, FontSize.Small), new string[]
            {
                " ▀▀█ ",
                "   █ ",
                "   █ ",
                " ▄▄█ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('<', Font.Graffiti, FontSize.Small), new string[]
            {
                "  ▄ ",
                "▄▀  ",
                "▀▄  ",
                "  ▀ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('>', Font.Graffiti, FontSize.Small), new string[]
            {
                "▄   ",
                " ▀▄ ",
                " ▄▀ ",
                "▀   "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('{', Font.Graffiti, FontSize.Small), new string[]
            {
                "   ▄█▀ ",
                " ▄█    ",
                " ▀█    ",
                "   ▀█▄ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('}', Font.Graffiti, FontSize.Small), new string[]
            {
                "▀█▄   ",
                "   █▄ ",
                "   █▀ ",
                "▄█▀   "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('/', Font.Graffiti, FontSize.Small), new string[]
            {
                "   ▄▀ ",
                "  ▄▀  ",
                " ▄▀   ",
                "▄▀    ",
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('\\', Font.Graffiti, FontSize.Small), new string[]
            {
                "▀▄    ",
                " ▀▄   ",
                "  ▀▄  ",
                "   ▀▄ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('.', Font.Graffiti, FontSize.Small), new string[]
            {
                "   ",
                "   ",
                "   ",
                "▄  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>(',', Font.Graffiti, FontSize.Small), new string[]
            {
                "   ",
                "   ",
                "   ",
                "▄▀ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>(':', Font.Graffiti, FontSize.Small), new string[]
            {
                "  ",
                "  ",
                "▄ ",
                "▄ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>(';', Font.Graffiti, FontSize.Small), new string[]
            {
                "   ",
                "   ",
                " ▀ ",
                "▄▀ "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('\'', Font.Graffiti, FontSize.Small), new string[]
            {
                "▀ ",
                "  ",
                "  ",
                "  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('"', Font.Graffiti, FontSize.Small), new string[]
            {
                "▀ ▀ ",
                "    ",
                "    ",
                "    "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('!', Font.Graffiti, FontSize.Small), new string[]
            {
                "▄██▄ ",
                "▀██▀ ",
                " ██  ",
                " ▄▄  "
            });

            Alphabet.Add(new Tuple<char, Font, FontSize>('?', Font.Graffiti, FontSize.Small), new string[]
            {
                "▄███▄  ",
                "▀   ██ ",
                "  ██▀  ",
                "  ▄▄   "
            });

            #endregion
        }

        #endregion

        #region Static Methods

        /// <summary>
        /// Generates a large string of characters corresponding to the input phrase.
        /// </summary>
        /// <remarks>
        /// Any character that doesn't exist in the alphabet will be replaced with a question mark.
        /// </remarks>
        /// <param name="phrase">The phrase to generate.</param>
        /// <param name="size">The size of the font to use.</param>
        /// <returns>A string array containing the generated output.</returns>
        /// <seealso cref="Generate(string, Font, FontSize)"/>
        public static string[] Generate(string phrase, FontSize size = FontSize.Default)
        {
            return Generate(phrase, DefaultFont, (size == FontSize.Default ? DefaultFontSize : size));
        }

        /// <summary>
        /// Generates a large string of characters corresponding to the input phrase.
        /// </summary>
        /// <remarks>
        /// Any character that doesn't exist in the alphabet will be replaced with a question mark.
        /// </remarks>
        /// <param name="phrase">The phrase to generate.</param>
        /// <param name="font">The Font type to use.</param>
        /// <param name="size">The size of the font to use.</param>
        /// <returns>A string array containing the generated output.</returns>
        public static string[] Generate(string phrase, Font font = Font.Default, FontSize size = FontSize.Default)
        {
            // substitute default font and size values with the configured default values
            font = (font == Font.Default ? DefaultFont : font);
            size = (size == FontSize.Default ? DefaultFontSize : size);

            // create the result array of the proper size
            string[] r = new string[(int)size];

            // populate the result array
            foreach (char c in phrase.ToUpper())
                for (int i = 0; i < (int)size; i++)
                    r[i] += Alphabet[new Tuple<char, Font, FontSize>((Alphabet.ContainsKey(new Tuple<char, Font, FontSize>(c, font, size)) ? c : '?'), font, size)][i];

            return r;
        }

        #endregion
    }
}
