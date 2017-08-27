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

using Xunit;

namespace OpenIIoT.Core.Tests
{
    /// <summary>
    ///     Unit tests for the <see cref="ApplicationSettings"/> class.
    /// </summary>
    public class ApplicationSettings
    {
        #region Public Constructors

        public ApplicationSettings()
        {
            Settings = new Core.ApplicationSettings();
        }

        #endregion Public Constructors

        #region Private Properties

        private Core.ApplicationSettings Settings { get; set; }

        #endregion Private Properties

        #region Public Methods

        [Fact]
        public void ApplicationInstanceName()
        {
            string setting = Settings.ApplicationInstanceName;
            Assert.NotNull(setting);
            Assert.NotEqual(string.Empty, setting);
        }

        [Fact]
        public void ApplicationInstanceNameCached()
        {
            string setting = Settings.ApplicationInstanceName;
            Assert.NotNull(setting);
            Assert.NotEqual(string.Empty, setting);

            string setting2 = Settings.ApplicationInstanceName;
            Assert.Equal(setting, setting2);
        }

        [Fact]
        public void ConfigurationFileName()
        {
            string setting = Settings.ConfigurationFileName;
            Assert.NotNull(setting);
            Assert.NotEqual(string.Empty, setting);
        }

        [Fact]
        public void Constructor()
        {
            Assert.IsType<Core.ApplicationSettings>(Settings);
        }

        [Fact]
        public void DirectoryData()
        {
            string setting = Settings.DirectoryData;
            Assert.NotNull(setting);
            Assert.NotEqual(string.Empty, setting);
        }

        [Fact]
        public void DirectoryLogs()
        {
            string setting = Settings.DirectoryLogs;
            Assert.NotNull(setting);
            Assert.NotEqual(string.Empty, setting);
        }

        [Fact]
        public void DirectoryPackages()
        {
            string setting = Settings.DirectoryPackages;
            Assert.NotNull(setting);
            Assert.NotEqual(string.Empty, setting);
        }

        [Fact]
        public void DirectoryPersistence()
        {
            string setting = Settings.DirectoryPersistence;
            Assert.NotNull(setting);
            Assert.NotEqual(string.Empty, setting);
        }

        [Fact]
        public void DirectoryPlugins()
        {
            string setting = Settings.DirectoryPlugins;
            Assert.NotNull(setting);
            Assert.NotEqual(string.Empty, setting);
        }

        [Fact]
        public void DirectoryTemp()
        {
            string setting = Settings.DirectoryTemp;
            Assert.NotNull(setting);
            Assert.NotEqual(string.Empty, setting);
        }

        [Fact]
        public void DirectoryWeb()
        {
            string setting = Settings.DirectoryWeb;
            Assert.NotNull(setting);
            Assert.NotEqual(string.Empty, setting);
        }

        [Fact]
        public void SecurityDefaultUser()
        {
            string setting = Settings.SecurityDefaultUser;
            Assert.NotNull(setting);
            Assert.NotEqual(string.Empty, setting);
        }

        [Fact]
        public void SecurityDefaultUserPasswordHash()
        {
            string setting = Settings.SecurityDefaultUserPasswordHash;
            Assert.NotNull(setting);
            Assert.NotEqual(string.Empty, setting);
        }

        [Fact]
        public void SecuritySessionLength()
        {
            int setting = Settings.SecuritySessionLength;
            Assert.NotNull(setting);
            Assert.NotEqual(0, setting);
        }

        #endregion Public Methods
    }
}