/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀ 
      █   
      █   ███    █▄                                               
      █   ███    ███                                              
      █   ███    ███     ██     █   █        █      ██    ▄█   ▄  
      █   ███    ███ ▀███████▄ ██  ██       ██  ▀███████▄ ██   █▄ 
      █   ███    ███     ██  ▀ ██▌ ██       ██▌     ██  ▀ ▀▀▀▀▀██ 
      █   ███    ███     ██    ██  ██       ██      ██    ▄█   ██ 
      █   ███    ███     ██    ██  ██▌    ▄ ██      ██    ██   ██ 
      █   ████████▀     ▄██▀   █   ████▄▄██ █      ▄██▀    █████  
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄ 
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █ 
      ▄  
      █  Contains miscellaneous static methods.
      █ 
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀ ▀ ▀▀▀     ▀▀               ▀   
      █  The GNU Affero General Public License (GNU AGPL)
      █  
      █  Copyright (C) 2016 JP Dillingham (jp@dillingham.ws)
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
using System.Collections.Generic;
using System.Linq;
using NLog;
using Utility.BigFont;
using Symbiote.Core.SDK;

namespace Symbiote.Core.SDK
{
    /// <summary>
    /// Contains miscellaneous static methods.
    /// </summary>
    public static class Utility
    {
        #region Methods

        #region Public Methods

        #region Public Static Methods

        #region Extension Methods

        /// <summary>
        /// Returns a clone of the supplied list.
        /// </summary>
        /// <typeparam name="T">The list type to clone.</typeparam>
        /// <param name="listToClone">The list from which the clone should be created.</param>
        /// <returns>A clone of the supplied list.</returns>
        public static List<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }

        /// <summary>
        /// Returns a subset of the supplied array.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="data">The array.</param>
        /// <param name="index">The index at which the sub-array should start.</param>
        /// <param name="length">The length of the desired sub-array; the number of elements to select.</param>
        /// <returns>A subset of the supplied array.</returns>
        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }
        
        /// <summary>
        /// Returns the last N elements of the supplied IEnumerable.
        /// </summary>
        /// <typeparam name="T">The type of the IEnumerable.</typeparam>
        /// <param name="source">The IEnumerable.</param>
        /// <param name="n">The number of elements to take from the end of the collection.</param>
        /// <returns>An IEnumerable containing the last N elements of the supplied IEnumerable.</returns>
        public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> source, int n)
        {
            return source.Skip(Math.Max(0, source.Count() - n));
        }
        
        /// <summary>
        /// Returns the specified assembly attribute of the specified assembly.
        /// </summary>
        /// <typeparam name="T">The assembly attribute to return.</typeparam>
        /// <param name="ass">The assembly from which to retrieve the attribute.</param>
        /// <returns>The retrieved attribute.</returns>
        public static T GetAssemblyAttribute<T>(this System.Reflection.Assembly ass) where T : Attribute
        {
            object[] attributes = ass.GetCustomAttributes(typeof(T), false);

            if (attributes == null || attributes.Length == 0)
            {
                return null;
            }

            return attributes.OfType<T>().SingleOrDefault();
        }

        #endregion

        #region Miscellaneous

        /// <summary>
        /// Converts the specified wildcard pattern to a regular expression.
        /// </summary>
        /// <param name="pattern">The wildcard pattern to convert.</param>
        /// <returns>The regular expression resulting from the conversion.</returns>
        public static string WildcardToRegex(string pattern = "")
        {
            return "^" + System.Text.RegularExpressions.Regex.Escape(pattern)
                              .Replace(@"\*", ".*")
                              .Replace(@"\?", ".")
                       + "$";
        }

        /// <summary>
        /// Returns a truncated GUID.
        /// </summary>
        /// <returns>A truncated GUID.</returns>
        public static string ShortGuid()
        {
            return Guid.NewGuid().ToString().Split('-')[0];
        }

        /// <summary>
        /// Computes a cryptographic hash of the provided text using the provided salt.
        /// </summary>
        /// <param name="text">The text to hash.</param>
        /// <param name="salt">The salt with which to seed the hash function.</param>
        /// <returns>The computed hash.</returns>
        public static string ComputeHash(string text, string salt = "")
        {
            byte[] binText = System.Text.Encoding.ASCII.GetBytes(text);
            byte[] binSalt = System.Text.Encoding.ASCII.GetBytes(salt);
            byte[] binSaltedText;

            if (binSalt.Length > 0)
            {
                binSaltedText = new byte[binText.Length + binSalt.Length];

                for (int i = 0; i < binText.Length; i++)
                {
                    binSaltedText[i] = binText[i];
                }

                for (int i = 0; i < binSalt.Length; i++)
                {
                    binSaltedText[binText.Length + i] = binSalt[i];
                }
            }
            else
            {
                binSaltedText = binText;
            }

            byte[] checksum = System.Security.Cryptography.SHA256.Create().ComputeHash(binSaltedText);

            System.Text.StringBuilder builtString = new System.Text.StringBuilder();
            foreach (byte b in checksum)
            {
                builtString.Append(b.ToString("x2"));
            }

            return builtString.ToString();
        }

        #endregion

        #region Logging

        /// <summary>
        /// Sets the logging level of the LogManager to the specified level, disabling all lower logging levels.
        /// </summary>
        /// <param name="level">The desired logging level.</param>
        public static void SetLoggingLevel(string level)
        {
            try
            {
                // i'm pretty sure this is the first legitimate use case i've seen for a select case with fallthrough.
                switch (level.ToLower())
                {
                    case "fatal":
                        DisableLoggingLevel(LogLevel.Error);
                        goto case "error";
                    case "error":
                        DisableLoggingLevel(LogLevel.Warn);
                        goto case "warn";
                    case "warn":
                        DisableLoggingLevel(LogLevel.Info);
                        goto case "info";
                    case "info":
                        DisableLoggingLevel(LogLevel.Debug);
                        goto case "debug";
                    case "debug":
                        DisableLoggingLevel(LogLevel.Trace);
                        goto case "trace";
                    case "trace":
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Exception thrown while setting log level: " + ex, ex);
            }
        }

        /// <summary>
        /// Disables the specified logging level within the LogManager.
        /// </summary>
        /// <param name="level">The level to disable.</param>
        public static void DisableLoggingLevel(LogLevel level)
        {
            foreach (var rule in LogManager.Configuration.LoggingRules)
            {
                rule.DisableLoggingForLevel(level);
            }

            LogManager.ReconfigExistingLoggers();
        }

        #endregion

        #region Display

        /// <summary>
        /// Prints the logo for the application.
        /// </summary>
        /// <param name="logger">The logger to which the logo should be logged.</param>
        public static void PrintLogo(Logger logger)
        {
            // logger.Info(string.Empty);
            // logger.Info(@"┏━━━━━━━━━━━━━━ ━━ ━ ━━━━ ━━━━━━━━━━━━━━━━ ━ ━        ━  ━━    ━   ━━━━━━━━━━━  ━ ━ ━━ ━━━━━━ ━━━━━━┓");
            // logger.Info(@"┃''' '  '                                                                                           ┃");
            // logger.Info(@"┃''    ▄████████ ▄██   ▄     ▄▄▄▄███▄▄▄▄   ▀█████████▄   ▄█   ▄██████▄      ███        ▄████████    ┃");
            // logger.Info(@"┃`    ███    ███ ███   ██▄ ▄██▀▀▀███▀▀▀██▄   ███    ███ ███  ███    ███ ▀█████████▄   ███    ███    ┃");
            // logger.Info(@"┃     ███    █▀  ███▄▄▄███ ███   ███   ███   ███    ███ ███▌ ███    ███    ▀███▀▀██   ███    █▀     ┃");
            // logger.Info(@"┃     ███        ▀▀▀▀▀▀███ ███   ███   ███  ▄███▄▄▄██▀  ███▌ ███    ███     ███   ▀  ▄███▄▄▄        ┃");
            // logger.Info(@"┃   ▀███████████ ▄██   ███ ███   ███   ███ ▀▀███▀▀▀██▄  ███▌ ███    ███     ███     ▀▀███▀▀▀        ┃");
            // logger.Info(@"┃            ███ ███   ███ ███   ███   ███   ███    ██▄ ███  ███    ███     ███       ███    █▄     ┃");
            // logger.Info(@"┃      ▄█    ███ ███   ███ ███   ███   ███   ███    ███ ███  ███    ███     ███       ███    ███    ┃");
            // logger.Info(@"┃    ▄████████▀   ▀█████▀   ▀█   ███   █▀  ▄█████████▀  █▀    ▀██████▀     ▄████▀     ██████████   .┃");
            // logger.Info(@"┃                                                                                           . .  ...┃");
            // logger.Info(@"┗━━━━━━━━━━━━━ ━ ━━━━━━━━━━ ━ ━           ━  ━━ ━ ━ ━━━━━━━━━━━━━━━━━━━━━ ━ ━ ━━━━━━━━━━━━━━━━  ━ ━━┛");
            logger.Info(string.Empty);
            logger.Info(@"      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀ ");
            logger.Info(@"      █   ");

            foreach (string s in BigFontGenerator.Generate("Symbiote", Font.Graffiti, FontSize.Large))
            {
                logger.Info(@"      █  " + s);
            }

            logger.Info(@"      █");
            logger.Info(@" ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄ ");
            logger.Info(@" █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █ ");
            logger.Info(@"      ▄  ");
        }

        /// <summary>
        /// Prints the logo footer for the application.
        /// </summary>
        /// <param name="logger">The logger to which the logo should be logged.</param>
        public static void PrintLogoFooter(Logger logger)
        {
            // logger.Info(@"┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            // logger.Info(@"┃   ░ ░░░▒▒▒▒▒▒▓▓▓▓▓▓▓▓███████████████████████████████████████████████████████▓▓▓▓▓▓▓▓▒▒▒▒▒▒░░░ ░   ┃");
            // logger.Info(@"┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
            logger.Info(@"      █  ");
            logger.Info(@"      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██ ");
            logger.Info(@"                                                                                                   ██ ");
            logger.Info(@"                                                                                               ▀█▄ ██ ▄█▀ ");
            logger.Info(@"                                                                                                 ▀████▀   ");
            logger.Info(@"                                                                                                   ▀▀ ");
            logger.Info(string.Empty);
        }

        /// <summary>
        /// Recursively prints the application Model to the specified logger.
        /// </summary>
        /// <param name="logger">The logger to which the Model should be printed.</param>
        /// <param name="root">The root Item from which the print should begin.</param>
        /// <param name="indent">The current level of indent to apply.</param>
        /// <param name="levels">The list of indentation levels.</param>
        /// <param name="last">True if the specified element is the last in the current chain.</param>
        public static void PrintModel(Logger logger, Item root, int indent, List<bool> levels = null, bool last = false)
        {
            // if indent is zero we are starting with the root.  initialize the list and add the first level.
            if (indent == 0)
            {
                levels = new List<bool>();
            }
            
            // if indent is greater than the count of items in levels, the tree is deeper than it has been before.
            // add a new level to the list and initialize it to true.
            if (indent >= levels.Count)
            {
                levels.Add(true);
            }

            // set the value of the current level according to whether this element is the last in the current chain
            levels[indent] = !last;

            // build the prefix
            string prefix = string.Empty;
            for (int l = 0; l < indent; l++)
            {
                prefix += levels[l] ? " │  " : "    ";
            }
           
            logger.Info(@"      █" + prefix + (last ? (indent == 0 ? "  ■ " : " └─╴") : " ├─╴") + root.FQN);

            // print each of the children of this Item
            for (int i = 0; i < root.Children.Count; i++)
            {
                Item item = root.Children[i];
                PrintModel(logger, item, indent + 1, levels, i == root.Children.Count - 1);
            }
        }

        #endregion

        #endregion

        #endregion

        #endregion
    }
}
