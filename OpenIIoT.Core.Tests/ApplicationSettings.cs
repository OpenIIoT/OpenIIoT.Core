/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █     ▄████████                                                                                        ▄████████
      █     ███    ███                                                                                      ███    ███
      █     ███    ███    █████▄    █████▄  █        █   ▄██████   ▄█████      ██     █   ██████  ██▄▄▄▄    ███    █▀     ▄█████     ██        ██     █  ██▄▄▄▄     ▄████▄    ▄█████
      █     ███    ███   ██   ██   ██   ██ ██       ██  ██    ██   ██   ██ ▀███████▄ ██  ██    ██ ██▀▀▀█▄   ███          ██   █  ▀███████▄ ▀███████▄ ██  ██▀▀▀█▄   ██    ▀    ██  ▀
      █   ▀███████████   ██   ██   ██   ██ ██       ██▌ ██    ▀    ██   ██     ██  ▀ ██▌ ██    ██ ██   ██ ▀███████████  ▄██▄▄        ██  ▀     ██  ▀ ██▌ ██   ██  ▄██         ██
      █     ███    ███ ▀██████▀  ▀██████▀  ██       ██  ██    ▄  ▀████████     ██    ██  ██    ██ ██   ██          ███ ▀▀██▀▀        ██        ██    ██  ██   ██ ▀▀██ ███▄  ▀███████
      █     ███    ███   ██        ██      ██▌    ▄ ██  ██    ██   ██   ██     ██    ██  ██    ██ ██   ██    ▄█    ███   ██   █      ██        ██    ██  ██   ██   ██    ██    ▄  ██
      █     ███    █▀   ▄███▀     ▄███▀    ████▄▄██ █   ██████▀    ██   █▀    ▄██▀   █    ██████   █   █   ▄████████▀    ███████    ▄██▀      ▄██▀   █    █   █    ██████▀   ▄████▀
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
      █  Unit tests for the ApplicationSettings class.
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
using Xunit;

namespace OpenIIoT.Core.Tests
{
    /// <summary>
    ///     Unit tests for the <see cref="ApplicationSettings"/> class.
    /// </summary>
    public class ApplicationSettings
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApplicationSettings"/> class.
        /// </summary>
        public ApplicationSettings()
        {
            Settings = new Core.ApplicationSettings();
        }

        #endregion Public Constructors

        #region Private Properties

        /// <summary>
        ///     Gets or sets the application settings.
        /// </summary>
        private Core.ApplicationSettings Settings { get; set; }

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        ///     Tests the <see cref="Core.ApplicationSettings.ApplicationInstanceName"/> property.
        /// </summary>
        [Fact]
        public void ApplicationInstanceName()
        {
            string setting = Settings.ApplicationInstanceName;
            Assert.NotNull(setting);
            Assert.NotEqual(string.Empty, setting);
        }

        /// <summary>
        ///     Tests the <see cref="Core.ApplicationSettings.ApplicationInstanceName"/> property twice to ensure setting caching
        ///     is working properly.
        /// </summary>
        [Fact]
        public void ApplicationInstanceNameCached()
        {
            string setting = Settings.ApplicationInstanceName;
            Assert.NotNull(setting);
            Assert.NotEqual(string.Empty, setting);

            string setting2 = Settings.ApplicationInstanceName;
            Assert.Equal(setting, setting2);
        }

        /// <summary>
        ///     Tests the <see cref="Core.ApplicationSettings.ConfigurationFileName"/> property.
        /// </summary>
        [Fact]
        public void ConfigurationFileName()
        {
            string setting = Settings.ConfigurationFileName;
            Assert.NotNull(setting);
            Assert.NotEqual(string.Empty, setting);
        }

        /// <summary>
        ///     Tests the constructor.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            Assert.IsType<Core.ApplicationSettings>(Settings);
        }

        /// <summary>
        ///     Tests the <see cref="Core.ApplicationSettings.DirectoryData"/> property.
        /// </summary>
        [Fact]
        public void DirectoryData()
        {
            string setting = Settings.DirectoryData;
            Assert.NotNull(setting);
            Assert.NotEqual(string.Empty, setting);
        }

        /// <summary>
        ///     Tests the <see cref="Core.ApplicationSettings.DirectoryLogs"/> property.
        /// </summary>
        [Fact]
        public void DirectoryLogs()
        {
            string setting = Settings.DirectoryLogs;
            Assert.NotNull(setting);
            Assert.NotEqual(string.Empty, setting);
        }

        /// <summary>
        ///     Tests the <see cref="Core.ApplicationSettings.DirectoryPackages"/> property.
        /// </summary>
        [Fact]
        public void DirectoryPackages()
        {
            string setting = Settings.DirectoryPackages;
            Assert.NotNull(setting);
            Assert.NotEqual(string.Empty, setting);
        }

        /// <summary>
        ///     Tests the <see cref="Core.ApplicationSettings.DirectoryPersistence"/> property.
        /// </summary>
        [Fact]
        public void DirectoryPersistence()
        {
            string setting = Settings.DirectoryPersistence;
            Assert.NotNull(setting);
            Assert.NotEqual(string.Empty, setting);
        }

        /// <summary>
        ///     Tests the <see cref="Core.ApplicationSettings.DirectoryPlugins"/> property.
        /// </summary>
        [Fact]
        public void DirectoryPlugins()
        {
            string setting = Settings.DirectoryPlugins;
            Assert.NotNull(setting);
            Assert.NotEqual(string.Empty, setting);
        }

        /// <summary>
        ///     Tests the <see cref="Core.ApplicationSettings.DirectoryTemp"/> property.
        /// </summary>
        [Fact]
        public void DirectoryTemp()
        {
            string setting = Settings.DirectoryTemp;
            Assert.NotNull(setting);
            Assert.NotEqual(string.Empty, setting);
        }

        /// <summary>
        ///     Tests the <see cref="Core.ApplicationSettings.DirectoryWeb"/> property.
        /// </summary>
        [Fact]
        public void DirectoryWeb()
        {
            string setting = Settings.DirectoryWeb;
            Assert.NotNull(setting);
            Assert.NotEqual(string.Empty, setting);
        }

        /// <summary>
        ///     Tests the <see cref="Core.ApplicationSettings.ResetCache"/> method.
        /// </summary>
        [Fact]
        public void ResetCache()
        {
            Exception ex = Record.Exception(() => Settings.ResetCache());
            Assert.Null(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Core.ApplicationSettings.SecurityDefaultUser"/> property.
        /// </summary>
        [Fact]
        public void SecurityDefaultUser()
        {
            string setting = Settings.SecurityDefaultUser;
            Assert.NotNull(setting);
            Assert.NotEqual(string.Empty, setting);
        }

        /// <summary>
        ///     Tests the <see cref="Core.ApplicationSettings.SecurityDefaultUserPasswordHash"/> property.
        /// </summary>
        [Fact]
        public void SecurityDefaultUserPasswordHash()
        {
            string setting = Settings.SecurityDefaultUserPasswordHash;
            Assert.NotNull(setting);
            Assert.NotEqual(string.Empty, setting);
        }

        /// <summary>
        ///     Tests the <see cref="Core.ApplicationSettings.SecuritySessionLength"/> property.
        /// </summary>
        [Fact]
        public void SecuritySessionLength()
        {
            int setting = Settings.SecuritySessionLength;
            Assert.NotNull(setting);
            Assert.NotEqual(0, setting);
        }

        /// <summary>
        ///     Tests the <see cref="Core.ApplicationSettings.SecuritySessionPurgeInterval"/> property.
        /// </summary>
        [Fact]
        public void SecuritySessionPurgeInterval()
        {
            int setting = Settings.SecuritySessionPurgeInterval;
            Assert.NotNull(setting);
            Assert.NotEqual(0, setting);
        }

        /// <summary>
        ///     Tests the <see cref="Core.ApplicationSettings.SecuritySlidingSessions"/> property.
        /// </summary>
        [Fact]
        public void SecuritySlidingSessions()
        {
            bool setting = Settings.SecuritySlidingSessions;
        }

        #endregion Public Methods
    }
}