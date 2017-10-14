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

[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]

namespace OpenIIoT.SDK.Tests.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using OpenIIoT.SDK.Common;
    using Xunit;

    /// <summary>
    ///     Mocks a class containing the <see cref="AttributeTestAttribute"/> Attribute.
    /// </summary>
    /// <remarks>
    ///     It is not feasible to use a mocking framework to mock this class because the underlying code being tested does not
    ///     detected attributes added at runtime.
    /// </remarks>
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
    public class AttributeTestAttribute : Attribute
    {
    }

    /// <summary>
    ///     Unit tests for the <see cref="Utility"/> class.
    /// </summary>
    public class UtilityTests
    {
        #region Public Methods

        /// <summary>
        ///     Tests the <see cref="Utility.Clone"/> extension method.
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
        ///     Tests the <see cref="Utility.ComputeSHA512Hash(string)"/> method.
        /// </summary>
        [Fact]
        public void ComputeSHA512Hash()
        {
            string unsaltedResult = "EE26B0DD4AF7E749AA1A8EE3C10AE9923F618980772E473F8819A5D4940E0DB27AC185F8A0E1D5F84F88BC887FD67B143732C304CC5FA9AD8E6F57F50028A8FF";

            string unsaltedHash = Utility.ComputeSHA512Hash("test");

            Assert.Equal(128, unsaltedHash.Length);
            Assert.Equal(unsaltedResult, unsaltedHash);
        }

        /// <summary>
        ///     Tests the <see cref="Utility.HasCustomAttribute{T}(System.Reflection.MemberInfo)"/> extension method.
        /// </summary>
        [Fact]
        public void HasAttribute()
        {
            AttributeTest hasAttribute = new AttributeTest();

            object noAttribute = new object();

            Assert.False(noAttribute.GetType().HasCustomAttribute<AttributeTestAttribute>());
            Assert.True(hasAttribute.GetType().HasCustomAttribute<AttributeTestAttribute>());
        }

        /// <summary>
        ///     Tests the <see cref="Utility.IsValidJson(string)"/> extension method with known good values.
        /// </summary>
        /// <param name="json">The Json string to test.</param>
        [Theory]
        [InlineData("{ \"boolean\": true }")]
        [InlineData("[ 1,2,3 ]")]
        public void IsValidJson(string json)
        {
            Assert.True(json.IsValidJson());
        }

        /// <summary>
        ///     Tests the <see cref="Utility.IsValidJson(string)"/> extension method with a known bad value.
        /// </summary>
        public void IsValidJsonInvalid()
        {
            string json = "hello world!";
            Assert.False(json.IsValidJson());
        }

        /// <summary>
        ///     Tests the <see cref="Utility.ShortGuid"/> method.
        /// </summary>
        [Fact]
        public void ShortGuid()
        {
            string guid1 = Utility.ShortGuid();
            string guid2 = Utility.ShortGuid();

            Assert.Equal(8, guid1.Length);
            Assert.Equal(8, guid2.Length);
            Assert.NotEqual(guid1, guid2);
        }

        /// <summary>
        ///     Tests the <see cref="Utility.SubArray{T}(T[], int, int)"/> extension method.
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
        ///     Tests the <see cref="Utility.TakeLast{T}(IEnumerable{T}, int)"/> extension method.
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
        ///     Tests the <see cref="Utility.WildcardToRegex(string)"/> method.
        /// </summary>
        [Fact]
        public void WildcardToRegex()
        {
            string wildcard = "test*string?";
            string regex = "^test.*string.$";

            Assert.Equal(regex, Utility.WildcardToRegex(wildcard));
        }

        #endregion Public Methods
    }
}