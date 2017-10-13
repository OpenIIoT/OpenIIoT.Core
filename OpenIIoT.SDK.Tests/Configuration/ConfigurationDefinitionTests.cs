/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █   ▄████████                                                                                                      ████████▄
      █   ███    ███                                                                                                     ███   ▀███
      █   ███    █▀   ██████  ██▄▄▄▄     ▄█████  █     ▄████▄  ██   █     █████   ▄█████      ██     █   ██████  ██▄▄▄▄  ███    ███    ▄█████    ▄█████  █  ██▄▄▄▄   █      ██     █   ██████  ██▄▄▄▄
      █   ███        ██    ██ ██▀▀▀█▄   ██   ▀█ ██    ██    ▀  ██   ██   ██  ██   ██   ██ ▀███████▄ ██  ██    ██ ██▀▀▀█▄ ███    ███   ██   █    ██   ▀█ ██  ██▀▀▀█▄ ██  ▀███████▄ ██  ██    ██ ██▀▀▀█▄
      █   ███        ██    ██ ██   ██  ▄██▄▄    ██▌  ▄██       ██   ██  ▄██▄▄█▀   ██   ██     ██  ▀ ██▌ ██    ██ ██   ██ ███    ███  ▄██▄▄     ▄██▄▄    ██▌ ██   ██ ██▌     ██  ▀ ██▌ ██    ██ ██   ██
      █   ███    █▄  ██    ██ ██   ██ ▀▀██▀▀    ██  ▀▀██ ███▄  ██   ██ ▀███████ ▀████████     ██    ██  ██    ██ ██   ██ ███    ███ ▀▀██▀▀    ▀▀██▀▀    ██  ██   ██ ██      ██    ██  ██    ██ ██   ██
      █   ███    ███ ██    ██ ██   ██   ██      ██    ██    ██ ██   ██   ██  ██   ██   ██     ██    ██  ██    ██ ██   ██ ███   ▄███   ██   █    ██      ██  ██   ██ ██      ██    ██  ██    ██ ██   ██
      █   ████████▀   ██████   █   █    ██      █     ██████▀  ██████    ██  ██   ██   █▀    ▄██▀   █    ██████   █   █  ████████▀    ███████   ██      █    █   █  █      ▄██▀   █    ██████   █   █
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
      █  Unit tests for the ConfigurationDefinition class.
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

namespace OpenIIoT.SDK.Tests.Configuration
{
    using OpenIIoT.SDK.Common.OperationResult;
    using OpenIIoT.SDK.Configuration;
    using Xunit;

    /// <summary>
    ///     Unit tests for the <see cref="ConfigurationDefinition"/> class.
    /// </summary>
    public class ConfigurationDefinitionTests
    {
        #region Public Methods

        /// <summary>
        ///     Tests all constructor overloads.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            ConfigurationDefinition config = new ConfigurationDefinition();

            Assert.IsType<ConfigurationDefinition>(config);

            config = new ConfigurationDefinition("form", "schema", typeof(int), 1);

            Assert.IsType<ConfigurationDefinition>(config);
        }

        /// <summary>
        ///     Tests the <see cref="ConfigurationDefinition.IsValid"/> method with a valid instance of a ConfigurationDefinition.
        /// </summary>
        [Fact]
        public void IsValid()
        {
            ConfigurationDefinition config = new ConfigurationDefinition("{ \"form\": \"\" }", "{ \"schema\": \"\" }", typeof(int), 1);

            Assert.True(config.IsValid().ReturnValue);
        }

        /// <summary>
        ///     Tests the <see cref="ConfigurationDefinition.IsValid"/> method with an instance with mismatched Model and Default properties.
        /// </summary>
        [Fact]
        public void IsValidInvalidDefault()
        {
            ConfigurationDefinition config = new ConfigurationDefinition("form", "{ \"schema\": \"\" }", typeof(int), "test");

            IResult<bool> result = config.IsValid();

            Assert.False(result.ReturnValue);
            Assert.True(result.GetLastError().Contains("Default"));
        }

        /// <summary>
        ///     Tests the <see cref="ConfigurationDefinition.IsValid"/> method with an instance with a Form property containing
        ///     invalid Json.
        /// </summary>
        [Fact]
        public void IsValidInvalidForm()
        {
            ConfigurationDefinition config = new ConfigurationDefinition("form", "{ \"schema\": \"\" }", typeof(int), 1);

            IResult<bool> result = config.IsValid();

            Assert.False(result.ReturnValue);
            Assert.True(result.GetLastError().Contains("Form"));
        }

        /// <summary>
        ///     Tests the <see cref="ConfigurationDefinition.IsValid"/> method with an instance with a null Model property.
        /// </summary>
        [Fact]
        public void IsValidInvalidModel()
        {
            ConfigurationDefinition config = new ConfigurationDefinition("form", "{ \"schema\": \"\" }", null, null);

            IResult<bool> result = config.IsValid();

            Assert.False(result.ReturnValue);
            Assert.True(result.GetLastError().Contains("Model"));
        }

        /// <summary>
        ///     Tests the <see cref="ConfigurationDefinition.IsValid"/> method with an instance with a Schema property containing
        ///     invalid Json.
        /// </summary>
        [Fact]
        public void IsValidInvalidSchema()
        {
            ConfigurationDefinition config = new ConfigurationDefinition("{ \"form\": \"\" }", "schema", typeof(int), 1);

            IResult<bool> result = config.IsValid();

            Assert.False(result.ReturnValue);
            Assert.True(result.GetLastError().Contains("Schema"));
        }

        /// <summary>
        ///     Tests all properties.
        /// </summary>
        [Fact]
        public void Properties()
        {
            ConfigurationDefinition config = new ConfigurationDefinition("form", "schema", typeof(int), 1);

            Assert.IsType<ConfigurationDefinition>(config);
            Assert.Equal("form", config.Form);
            Assert.Equal("schema", config.Schema);
            Assert.Equal(typeof(int), config.Model);
            Assert.Equal(1, config.DefaultConfiguration);
        }

        #endregion Public Methods
    }
}