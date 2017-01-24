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
      █  Unit tests for the Utility class.
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
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using OpenIIoT.SDK.Common;
using Xunit;

namespace OpenIIoT.SDK.Tests
{
    /// <summary>
    ///     Unit tests for the <see cref="SDK.Common.Utility"/> class.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    [Collection("Utility")]
    public class Utility
    {
        #region Public Methods

        /// <summary>
        ///     Tests the <see cref="SDK.Common.Utility.Clone"/> extension method.
        /// </summary>
        [Fact]
        public void Clone()
        {
            List<string> list = new List<string>();
            list.Add("one");
            list.Add("two");
            list.Add("three");

            List<string> clonedList = list.Clone();

            Assert.Equal(list, clonedList);
            Assert.Equal(list.Count, clonedList.Count);
            Assert.Equal(list[0], clonedList[0]);
            Assert.Equal(list[1], clonedList[1]);
            Assert.Equal(list[2], clonedList[2]);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Common.Utility.ComputeHash(string, string)"/> method.
        /// </summary>
        [Fact]
        public void ComputeHash()
        {
            string unsaltedResult = "982d9e3eb996f559e633f4d194def3761d909f5a3b647d1a851fead67c32c9d1";
            string saltedResult = "3353e16497ad272fea4382119ff2801e54f0a4cf2057f4e32d00317bda5126c3";

            string unsaltedHash = SDK.Common.Utility.ComputeHash("text");

            Assert.Equal(64, unsaltedHash.Length);
            Assert.Equal(unsaltedResult, unsaltedHash);

            string saltedHash = SDK.Common.Utility.ComputeHash("text", "salt");

            Assert.Equal(64, saltedHash.Length);
            Assert.Equal(saltedResult, saltedHash);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Common.Utility.ShortGuid"/> method.
        /// </summary>
        [Fact]
        public void ShortGuid()
        {
            string guid1 = SDK.Common.Utility.ShortGuid();
            string guid2 = SDK.Common.Utility.ShortGuid();

            Assert.Equal(8, guid1.Length);
            Assert.Equal(8, guid2.Length);
            Assert.NotEqual(guid1, guid2);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Common.Utility.SubArray{T}(T[], int, int)"/> extension method.
        /// </summary>
        [Fact]
        public void SubArray()
        {
            string[] array = new string[] { "one", "two", "three", "four", "five" };

            string[] subArray1 = array.SubArray(0, 2);
            Assert.Equal(2, subArray1.Length);
            Assert.Equal("one", subArray1[0]);
            Assert.Equal("two", subArray1[1]);

            string[] subArray2 = array.SubArray(2, 1);
            Assert.Equal(1, subArray2.Length);
            Assert.Equal("three", subArray2[0]);

            Assert.Throws<ArgumentException>(() => array.SubArray(0, 10));

            string[] subArray3 = array.SubArray(0, 5);
            Assert.Equal(5, subArray3.Length);
            Assert.Equal("one", subArray3[0]);
            Assert.Equal("five", subArray3[4]);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Common.Utility.TakeLast{T}(IEnumerable{T}, int)"/> extension method.
        /// </summary>
        [Fact]
        public void TakeLast()
        {
            List<string> list = new List<string>(new string[] { "one", "two", "three", "four", "five" });

            List<string> result1 = list.TakeLast(3).ToList();
            Assert.Equal(3, result1.Count);
            Assert.Equal("three", result1[0]);
            Assert.Equal("five", result1[2]);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Common.Utility.WildcardToRegex(string)"/> method.
        /// </summary>
        [Fact]
        public void WildcardToRegex()
        {
            string wildcard = "test*string?";
            string regex = "^test.*string.$";

            Assert.Equal(regex, SDK.Common.Utility.WildcardToRegex(wildcard));
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Common.Utility.HasCustomAttribute{T}(object)"/> extension method.
        /// </summary>
        [Fact]
        public void HasAttribute()
        {
            AttributeTest hasAttribute = new AttributeTest();

            object noAttribute = new object();

            Assert.False(noAttribute.GetType().HasCustomAttribute<AttributeTestAttribute>());
            Assert.True(hasAttribute.GetType().HasCustomAttribute<AttributeTestAttribute>());
        }

        #endregion Public Methods
    }

    /// <summary>
    ///     Mocks a class containing the <see cref="AttributeTestAttribute"/> Attribute.
    /// </summary>
    /// <remarks>
    ///     It is not feasible to use a mocking framework to mock this class because the underlying code being tested does not
    ///     detected attributes added at runtime.
    /// </remarks>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    [AttributeTest]
    public class AttributeTest
    {
    }

    /// <summary>
    ///     Creates an attribute for testing.
    /// </summary>
    /// <remarks>
    ///     It is not feasible to use a mocking framework to mock this class because the underlying code being tested does not
    ///     detected attributes added at runtime.
    /// </remarks>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class AttributeTestAttribute : Attribute
    {
    }
}