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
using System.Collections.Generic;
using OpenIIoT.SDK.Platform;
using OpenIIoT.SDK.Common.Exceptions;
using Xunit;

namespace OpenIIoT.Core.Tests
{
    /// <summary>
    ///     Unit tests for the <see cref="Platform.PlatformDirectories"/> class.
    /// </summary>
    [Collection("PlatformDirectories")]
    public class PlatformDirectories
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
        ///     Initializes a new instance of the <see cref="PlatformDirectories"/> class.
        /// </summary>
        public PlatformDirectories()
        {
            goodDirs = new Dictionary<string, string>();

            goodDirs.Add("Data", "Data");
            goodDirs.Add("Archives", "Archives");
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
            Core.Platform.PlatformDirectories test = new Core.Platform.PlatformDirectories(goodDirs);
            Assert.IsType<Core.Platform.PlatformDirectories>(test);

            Assert.Throws<DirectoryConfigurationException>(() => new Core.Platform.PlatformDirectories(badDirs));
        }

        /// <summary>
        ///     Tests all properties.
        /// </summary>
        [Fact]
        public void Properties()
        {
            Core.Platform.PlatformDirectories test = new Core.Platform.PlatformDirectories(goodDirs);

            Assert.Equal(FullDir("Data"), test.Data);
            Assert.Equal(FullDir("Archives"), test.Archives);
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
            Core.Platform.PlatformDirectories test = new Core.Platform.PlatformDirectories(goodDirs);

            Assert.Equal(FullDir("Data"), test.Data);
            Assert.Equal(FullDir("Archives"), test.Archives);
            Assert.Equal(FullDir("Plugins"), test.Plugins);
            Assert.Equal(FullDir("Temp"), test.Temp);

            Dictionary<string, string> dict = test.ToDictionary();

            Assert.Equal(FullDir("Data"), dict["Data"]);
            Assert.Equal(FullDir("Archives"), dict["Archives"]);
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