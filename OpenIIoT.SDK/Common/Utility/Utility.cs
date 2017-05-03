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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OpenIIoT.SDK.Common
{
    /// <summary>
    ///     Contains miscellaneous static methods.
    /// </summary>
    public static class Utility
    {
        #region Public Methods

        /// <summary>
        ///     Returns a clone of the specified list.
        /// </summary>
        /// <typeparam name="T">The list type to clone.</typeparam>
        /// <param name="list">The list from which the clone should be created.</param>
        /// <returns>A clone of the supplied list.</returns>
        public static List<T> Clone<T>(this IList<T> list) where T : ICloneable
        {
            return list.Select(i => (T)i.Clone()).ToList();
        }

        /// <summary>
        ///     Computes and returns the SHA512 hash of the contents of the specified file.
        /// </summary>
        /// <param name="file">The file for which the SHA512 hash is to be computed.</param>
        /// <returns>The SHA512 hash of the specified file.</returns>
        public static string ComputeFileSHA512Hash(string file)
        {
            if (File.Exists(file))
            {
                return ComputeSHA512Hash(File.ReadAllBytes(file));
            }
            else
            {
                throw new FileNotFoundException($"The file {file} could not be found.");
            }
        }

        /// <summary>
        ///     Computes and returns the SHA512 hash of the specified string.
        /// </summary>
        /// <param name="content">The string for which the SHA512 hash is to be computed.</param>
        /// <returns>The SHA512 hash of the specified string.</returns>
        public static string ComputeSHA512Hash(string content)
        {
            return ComputeSHA512Hash(Encoding.ASCII.GetBytes(content));
        }

        /// <summary>
        ///     Computes and returns the SHA512 hash of the specified byte array.
        /// </summary>
        /// <param name="content">The byte array for which the SHA512 hash is to be computed.</param>
        /// <returns>The SHA512 hash of the specified byte array.</returns>
        public static string ComputeSHA512Hash(byte[] content)
        {
            byte[] hash;

            using (SHA512 sha512 = new SHA512Managed())
            {
                hash = sha512.ComputeHash(content);
            }

            StringBuilder stringBuilder = new StringBuilder(128);

            foreach (byte b in hash)
            {
                stringBuilder.Append(b.ToString("X2"));
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        ///     Returns the path of the specified file, relative to the specified base directory.
        /// </summary>
        /// <param name="baseDirectory">The base directory of the relative file reference.</param>
        /// <param name="file">The file for which the relative path is to be returned.</param>
        /// <returns>The path of the specified file, relative to the specified base directory.</returns>
        public static string GetRelativePath(string baseDirectory, string file)
        {
            if (!baseDirectory.EndsWith(Path.DirectorySeparatorChar.ToString()))
            {
                baseDirectory += Path.DirectorySeparatorChar;
            }

            return file.Replace(baseDirectory, string.Empty);
        }

        /// <summary>
        ///     Returns a value indicating whether <see cref="Type"/> of the specified object instance contains the specified <see cref="Attribute"/>.
        /// </summary>
        /// <typeparam name="T">The <see cref="Attribute"/> for which to check.</typeparam>
        /// <param name="member">The object instance to check.</param>
        /// <returns>A value indicating whether the specified Type contains the specified Attribute.</returns>
        public static bool HasCustomAttribute<T>(this MemberInfo member) where T : Attribute
        {
            return Attribute.GetCustomAttribute(member, typeof(T), false) != default(Attribute);
        }

        /// <summary>
        ///     Returns a value indicating whether the specified string is valid Json.
        /// </summary>
        /// <param name="input">The string to validate.</param>
        /// <returns>A value indicating whether the specified string is valid Json.</returns>
        public static bool IsValidJson(this string input)
        {
            input = input.Trim();
            if ((input.StartsWith("{") && input.EndsWith("}")) || (input.StartsWith("[") && input.EndsWith("]")))
            {
                try
                {
                    var obj = JToken.Parse(input);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///     Returns a truncated GUID.
        /// </summary>
        /// <returns>A truncated GUID.</returns>
        public static string ShortGuid()
        {
            return Guid.NewGuid().ToString().Split('-')[0];
        }

        /// <summary>
        ///     Returns a subset of the specified array.
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
        ///     Returns the last N elements of the supplied IEnumerable.
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
        ///     Serializes and returns as json the specified object.
        /// </summary>
        /// <param name="obj">The object to serialize.</param>
        /// <returns>The serialized object.</returns>
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
            });
        }

        /// <summary>
        ///     Converts the specified wildcard pattern to a regular expression.
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

        #endregion Public Methods
    }
}