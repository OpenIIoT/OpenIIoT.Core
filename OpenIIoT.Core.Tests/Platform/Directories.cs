/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █   ████████▄
      █   ███   ▀███
      █   ███    ███  █     █████    ▄█████  ▄██████     ██     ██████     █████  █     ▄█████   ▄█████
      █   ███    ███ ██    ██  ██   ██   █  ██    ██ ▀███████▄ ██    ██   ██  ██ ██    ██   █    ██  ▀
      █   ███    ███ ██▌  ▄██▄▄█▀  ▄██▄▄    ██    ▀      ██  ▀ ██    ██  ▄██▄▄█▀ ██▌  ▄██▄▄      ██
      █   ███    ███ ██  ▀███████ ▀▀██▀▀    ██    ▄      ██    ██    ██ ▀███████ ██  ▀▀██▀▀    ▀███████
      █   ███   ▄███ ██    ██  ██   ██   █  ██    ██     ██    ██    ██   ██  ██ ██    ██   █     ▄  ██
      █   ████████▀  █     ██  ██   ███████ ██████▀     ▄██▀    ██████    ██  ██ █     ███████  ▄████▀
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
      █  Unit tests for the Directories class.
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
using OpenIIoT.SDK.Common.Exceptions;
using Xunit;

namespace OpenIIoT.Core.Tests
{
    /// <summary>
    ///     Unit tests for the <see cref="Core.Platform.Directories"/> class.
    /// </summary>
    [Collection("Directories")]
    public class Directories
    {
        #region Private Fields

        /// <summary>
        ///     The shared dictionary containing a "bad" set of directories.
        /// </summary>
        private Dictionary<string, string> badDirs;

        /// <summary>
        ///     The shared dictionary containing a "good" set of directories.
        /// </summary>
        private Dictionary<string, string> goodDirs;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Directories"/> class.
        /// </summary>
        public Directories()
        {
            goodDirs = new Dictionary<string, string>();

            goodDirs.Add("Data", "Data");
            goodDirs.Add("Packages", "Packages");
            goodDirs.Add("Plugins", "Plugins");
            goodDirs.Add("Temp", "Temp");
            goodDirs.Add("Persistence", "Persistence");
            goodDirs.Add("Web", "Web");
            goodDirs.Add("Logs", "Logs");

            badDirs = new Dictionary<string, string>(goodDirs);

            badDirs.Remove("Data");
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///     Tests all constructor overloads.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            Core.Platform.Directories test = new Core.Platform.Directories(goodDirs);
            Assert.IsType<Core.Platform.Directories>(test);

            test = new Core.Platform.Directories();
            Assert.IsType<Core.Platform.Directories>(test);

            Assert.Throws<DirectoryConfigurationException>(() => new Core.Platform.Directories(badDirs));
        }

        /// <summary>
        ///     Tests all properties.
        /// </summary>
        [Fact]
        public void Properties()
        {
            Core.Platform.Directories test = new Core.Platform.Directories(goodDirs);

            Assert.Equal(FullDir("Data"), test.Data);
            Assert.Equal(FullDir("Packages"), test.Packages);
            Assert.Equal(FullDir("Plugins"), test.Plugins);
            Assert.Equal(FullDir("Temp"), test.Temp);
            Assert.Equal(FullDir("Persistence"), test.Persistence);
            Assert.Equal(FullDir("Web"), test.Web);
            Assert.Equal(FullDir("Logs"), test.Logs);
        }

        /// <summary>
        ///     Tests <see cref="ToDictionary"/> and spot-checks the outcome.
        /// </summary>
        [Fact]
        public void ToDictionary()
        {
            Core.Platform.Directories test = new Core.Platform.Directories(goodDirs);

            Assert.Equal(FullDir("Data"), test.Data);
            Assert.Equal(FullDir("Packages"), test.Packages);
            Assert.Equal(FullDir("Plugins"), test.Plugins);
            Assert.Equal(FullDir("Temp"), test.Temp);

            IDictionary<string, string> dict = test.ToDictionary();

            Assert.Equal(FullDir("Data"), dict["Data"]);
            Assert.Equal(FullDir("Packages"), dict["Packages"]);
            Assert.Equal(FullDir("Temp"), dict["Temp"]);
        }

        #endregion Public Methods

        #region Private Methods

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

        #endregion Private Methods
    }
}