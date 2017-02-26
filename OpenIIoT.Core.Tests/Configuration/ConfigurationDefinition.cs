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

using Utility.OperationResult;
using Xunit;

namespace OpenIIoT.Core.Tests.Configuration
{
    /// <summary>
    ///     Unit tests for the <see cref="Core.Configuration.ConfigurationDefinition"/> class.
    /// </summary>
    [Collection("ConfigurationDefinition")]
    public class ConfigurationDefinition
    {
        #region Public Methods

        /// <summary>
        ///     Tests all constructor overloads.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            Core.Configuration.ConfigurationDefinition config = new Core.Configuration.ConfigurationDefinition();

            Assert.IsType<Core.Configuration.ConfigurationDefinition>(config);

            config = new Core.Configuration.ConfigurationDefinition("form", "schema", typeof(int), 1);

            Assert.IsType<Core.Configuration.ConfigurationDefinition>(config);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Configuration.ConfigurationDefinition.IsValid"/> method with a valid instance of a ConfigurationDefinition.
        /// </summary>
        [Fact]
        public void IsValid()
        {
            Core.Configuration.ConfigurationDefinition config = new Core.Configuration.ConfigurationDefinition("{ \"form\": \"\" }", "{ \"schema\": \"\" }", typeof(int), 1);

            Assert.True(config.IsValid().ReturnValue);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Configuration.ConfigurationDefinition.IsValid"/> method with an instance with mismatched
        ///     Model and Default properties.
        /// </summary>
        [Fact]
        public void IsValidInvalidDefault()
        {
            Core.Configuration.ConfigurationDefinition config = new Core.Configuration.ConfigurationDefinition("form", "{ \"schema\": \"\" }", typeof(int), "test");

            IResult<bool> result = config.IsValid();

            Assert.False(result.ReturnValue);
            Assert.True(result.GetLastError().Contains("Default"));
        }

        /// <summary>
        ///     Tests the <see cref="Core.Configuration.ConfigurationDefinition.IsValid"/> method with an instance with a Form
        ///     property containing invalid Json.
        /// </summary>
        [Fact]
        public void IsValidInvalidForm()
        {
            Core.Configuration.ConfigurationDefinition config = new Core.Configuration.ConfigurationDefinition("form", "{ \"schema\": \"\" }", typeof(int), 1);

            IResult<bool> result = config.IsValid();

            Assert.False(result.ReturnValue);
            Assert.True(result.GetLastError().Contains("Form"));
        }

        /// <summary>
        ///     Tests the <see cref="Core.Configuration.ConfigurationDefinition.IsValid"/> method with an instance with a null
        ///     Model property.
        /// </summary>
        [Fact]
        public void IsValidInvalidModel()
        {
            Core.Configuration.ConfigurationDefinition config = new Core.Configuration.ConfigurationDefinition("form", "{ \"schema\": \"\" }", null, null);

            IResult<bool> result = config.IsValid();

            Assert.False(result.ReturnValue);
            Assert.True(result.GetLastError().Contains("Model"));
        }

        /// <summary>
        ///     Tests the <see cref="Core.Configuration.ConfigurationDefinition.IsValid"/> method with an instance with a Schema
        ///     property containing invalid Json.
        /// </summary>
        [Fact]
        public void IsValidInvalidSchema()
        {
            Core.Configuration.ConfigurationDefinition config = new Core.Configuration.ConfigurationDefinition("{ \"form\": \"\" }", "schema", typeof(int), 1);

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
            Core.Configuration.ConfigurationDefinition config = new Core.Configuration.ConfigurationDefinition("form", "schema", typeof(int), 1);

            Assert.IsType<Core.Configuration.ConfigurationDefinition>(config);
            Assert.Equal("form", config.Form);
            Assert.Equal("schema", config.Schema);
            Assert.Equal(typeof(int), config.Model);
            Assert.Equal(1, config.DefaultConfiguration);
        }

        #endregion Public Methods
    }
}