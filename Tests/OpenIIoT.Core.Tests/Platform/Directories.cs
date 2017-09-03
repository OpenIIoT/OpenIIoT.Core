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

using System.Collections.Generic;
using OpenIIoT.SDK;
using Xunit;
using Moq;
using System;
using OpenIIoT.SDK.Common.Exceptions;
using OpenIIoT.Core.Platform;

namespace OpenIIoT.Core.Tests
{
    /// <summary>
    ///     Unit tests for the <see cref="Core.Platform.Directories"/> class.
    /// </summary>
    [Collection("Directories")]
    public class Directories
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Directories"/> class.
        /// </summary>
        public Directories()
        {
            Settings = new Mock<PlatformSettings>();
            Settings.Setup(s => s.DirectoryData).Returns("Data");
            Settings.Setup(s => s.DirectoryLogs).Returns("Logs");
            Settings.Setup(s => s.DirectoryPackages).Returns("Packages");
            Settings.Setup(s => s.DirectoryPersistence).Returns("Persistence");
            Settings.Setup(s => s.DirectoryPlugins).Returns("Plugins");
            Settings.Setup(s => s.DirectoryTemp).Returns("Temp");
            Settings.Setup(s => s.DirectoryWeb).Returns("Web");
        }

        #endregion Public Constructors

        #region Private Properties

        /// <summary>
        ///     Gets or sets the application settings.
        /// </summary>
        private Mock<PlatformSettings> Settings { get; set; }

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        ///     Tests the constructor.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            Core.Platform.Directories test = new Core.Platform.Directories(Settings.Object);

            Assert.IsType<Core.Platform.Directories>(test);
        }

        /// <summary>
        ///     Tests the constructor.
        /// </summary>
        [Fact]
        public void ConstructorFailure()
        {
            Settings.Setup(s => s.DirectoryData).Returns(default(string));

            Exception ex = Record.Exception(() => new Core.Platform.Directories(Settings.Object));

            Assert.IsType<DirectoryConfigurationException>(ex);
        }

        /// <summary>
        ///     Tests all properties.
        /// </summary>
        [Fact]
        public void Properties()
        {
            Core.Platform.Directories test = new Core.Platform.Directories(Settings.Object);

            Assert.NotNull(test.Data);
            Assert.NotNull(test.Logs);
            Assert.NotNull(test.Packages);
            Assert.NotNull(test.Persistence);
            Assert.NotNull(test.Plugins);
            Assert.NotNull(test.Root);
            Assert.NotNull(test.Temp);
            Assert.NotNull(test.Web);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.Directories.ToDictionary()"/> method.
        /// </summary>
        [Fact]
        public void ToDictionary()
        {
            Core.Platform.Directories test = new Core.Platform.Directories(Settings.Object);

            IDictionary<string, string> dict = test.ToDictionary();

            Assert.NotEmpty(dict);
            Assert.True(dict.ContainsKey("Data"));
            Assert.NotNull(dict["Data"]);
            Assert.True(dict.ContainsKey("Logs"));
            Assert.NotNull(dict["Logs"]);
            Assert.True(dict.ContainsKey("Packages"));
            Assert.NotNull(dict["Packages"]);
            Assert.True(dict.ContainsKey("Persistence"));
            Assert.NotNull(dict["Persistence"]);
            Assert.True(dict.ContainsKey("Plugins"));
            Assert.NotNull(dict["Plugins"]);
            Assert.True(dict.ContainsKey("Root"));
            Assert.NotNull(dict["Root"]);
            Assert.True(dict.ContainsKey("Temp"));
            Assert.NotNull(dict["Temp"]);
            Assert.True(dict.ContainsKey("Web"));
            Assert.NotNull(dict["Web"]);
        }

        #endregion Public Methods
    }
}