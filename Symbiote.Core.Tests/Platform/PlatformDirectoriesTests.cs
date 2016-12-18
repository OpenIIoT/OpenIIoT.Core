/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄███████▄                                                                      ████████▄
      █     ███    ███                                                                      ███   ▀███
      █     ███    ███  █         ▄█████      ██       ▄█████  ██████     █████    ▄▄██▄▄▄  ███    ███  █     █████    ▄█████  ▄██████     ██     ██████     █████  █     ▄█████   ▄█████
      █     ███    ███ ██         ██   ██ ▀███████▄   ██   ▀█ ██    ██   ██  ██  ▄█▀▀██▀▀█▄ ███    ███ ██    ██  ██   ██   █  ██    ██ ▀███████▄ ██    ██   ██  ██ ██    ██   █    ██  ▀
      █   ▀█████████▀  ██         ██   ██     ██  ▀  ▄██▄▄    ██    ██  ▄██▄▄█▀  ██  ██  ██ ███    ███ ██▌  ▄██▄▄█▀  ▄██▄▄    ██    ▀      ██  ▀ ██    ██  ▄██▄▄█▀ ██▌  ▄██▄▄      ██
      █     ███        ██       ▀████████     ██    ▀▀██▀▀    ██    ██ ▀███████  ██  ██  ██ ███    ███ ██  ▀███████ ▀▀██▀▀    ██    ▄      ██    ██    ██ ▀███████ ██  ▀▀██▀▀    ▀███████
      █     ███        ██▌    ▄   ██   ██     ██      ██      ██    ██   ██  ██  ██  ██  ██ ███   ▄███ ██    ██  ██   ██   █  ██    ██     ██    ██    ██   ██  ██ ██    ██   █     ▄  ██
      █    ▄████▀      ████▄▄██   ██   █▀    ▄██▀     ██       ██████    ██  ██   █  ██  █  ████████▀  █     ██  ██   ███████ ██████▀     ▄██▀    ██████    ██  ██ █     ███████  ▄████▀
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
      █  Unit tests for the PlatformDirectories class.
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
using Xunit;
using System.Collections.Generic;
using Symbiote.Core.Platform;
using Symbiote.SDK.Platform;

namespace Symbiote.Core.Tests
{
    /// <summary>
    ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a Manager with a known bad dependency.
    /// </summary>
    /// <remarks>Presented in a distinct class to enforce execution order.</remarks>
    [Collection("PlatformDirectories")]
    public class PlatformDirectoriesTests
    {
        /// <summary>
        ///     Tests <see cref="PlatformDirectories()"/> and all properties.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            PlatformDirectories test = new PlatformDirectories(GetTestDirs());

            Assert.Equal(FullDir("Data"), test.Data);
            Assert.Equal(FullDir("Archives"), test.Archives);
            Assert.Equal(FullDir("Plugins"), test.Plugins);
            Assert.Equal(FullDir("Temp"), test.Temp);
            Assert.Equal(FullDir("Persistence"), test.Persistence);
            Assert.Equal(FullDir("Web"), test.Web);
            Assert.Equal(FullDir("Logs"), test.Logs);
        }

        [Fact]
        public void BadConstructor()
        {
            Assert.Throws<DirectoryConfigurationException>(() => new PlatformDirectories(GetBadTestDirs()));
        }

        /// <summary>
        ///     Tests <see cref="ToDictionary"/> and spot-checks the outcome.
        /// </summary>
        [Fact]
        public void ToDictionary()
        {
            PlatformDirectories test = new PlatformDirectories(GetTestDirs());

            Assert.Equal(FullDir("Data"), test.Data);
            Assert.Equal(FullDir("Archives"), test.Archives);
            Assert.Equal(FullDir("Plugins"), test.Plugins);
            Assert.Equal(FullDir("Temp"), test.Temp);

            Dictionary<string, string> dict = test.ToDictionary();

            Assert.Equal(FullDir("Data"), dict["Data"]);
            Assert.Equal(FullDir("Archives"), dict["Archives"]);
            Assert.Equal(FullDir("Temp"), dict["Temp"]);
        }

        /// <summary>
        ///     Returns the fully qualified path for the specified directory, relative to the application root.
        /// </summary>
        /// <param name="dir">The directory to qualify.</param>
        /// <returns>The fully qualified path for the specified directory, relative to the application root.</returns>
        private string FullDir(string dir)
        {
            string root = System.IO.Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            return System.IO.Path.Combine(root, dir);
        }

        /// <summary>
        ///     Returns a dictionary containing the necessary directory key-value pairs.
        /// </summary>
        /// <returns>A dictionary containing the necessary directory key-value pairs.</returns>
        private Dictionary<string, string> GetTestDirs()
        {
            Dictionary<string, string> retVal = new Dictionary<string, string>();

            retVal.Add("Data", "Data");
            retVal.Add("Archives", "Archives");
            retVal.Add("Plugins", "Plugins");
            retVal.Add("Temp", "Temp");
            retVal.Add("Persistence", "Persistence");
            retVal.Add("Web", "Web");
            retVal.Add("Logs", "Logs");

            return retVal;
        }

        /// <summary>
        ///     Returns a dictionary containing an invalid number of directory key-value pairs.
        /// </summary>
        /// <returns>A dictionary containing an invalid number of directory key-value pairs.</returns>
        private Dictionary<string, string> GetBadTestDirs()
        {
            Dictionary<string, string> retVal = GetTestDirs();
            retVal.Remove("Data");
            return retVal;
        }
    }
}