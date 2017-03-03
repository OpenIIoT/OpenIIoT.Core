/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █   ▄████████                                                                                                        ███                                    ▄████████
      █   ███    ███                                                                                                   ▀█████████▄                               ███    ███
      █   ███    █▀   ██████  ██▄▄▄▄     ▄█████  █     ▄████▄  ██   █     █████   ▄█████  ▀██████▄   █          ▄█████    ▀███▀▀██ ▄█   ▄     █████▄    ▄█████  ▄███▄▄▄▄██▀    ▄█████    ▄████▄   █    ▄█████     ██       █████ ▄█   ▄
      █   ███        ██    ██ ██▀▀▀█▄   ██   ▀█ ██    ██    ▀  ██   ██   ██  ██   ██   ██   ██   ██ ██         ██   █      ███   ▀ ██   █▄   ██   ██   ██   █  ▀▀███▀▀▀▀▀     ██   █    ██    ▀  ██    ██  ▀  ▀███████▄   ██  ██ ██   █▄
      █   ███        ██    ██ ██   ██  ▄██▄▄    ██▌  ▄██       ██   ██  ▄██▄▄█▀   ██   ██  ▄██▄▄█▀  ██        ▄██▄▄        ███     ▀▀▀▀▀██   ██   ██  ▄██▄▄    ▀███████████  ▄██▄▄     ▄██       ██▌   ██         ██  ▀  ▄██▄▄█▀ ▀▀▀▀▀██
      █   ███    █▄  ██    ██ ██   ██ ▀▀██▀▀    ██  ▀▀██ ███▄  ██   ██ ▀███████ ▀████████ ▀▀██▀▀█▄  ██       ▀▀██▀▀        ███     ▄█   ██ ▀██████▀  ▀▀██▀▀      ███    ███ ▀▀██▀▀    ▀▀██ ███▄  ██  ▀███████     ██    ▀███████ ▄█   ██
      █   ███    ███ ██    ██ ██   ██   ██      ██    ██    ██ ██   ██   ██  ██   ██   ██   ██   ██ ██▌    ▄   ██   █      ███     ██   ██   ██        ██   █    ███    ███   ██   █    ██    ██ ██     ▄  ██     ██      ██  ██ ██   ██
      █   ████████▀   ██████   █   █    ██      █     ██████▀  ██████    ██  ██   ██   █▀ ▄██████▀  ████▄▄██   ███████    ▄████▀    █████   ▄███▀      ███████   ███    ███   ███████   ██████▀  █    ▄████▀     ▄██▀     ██  ██  █████
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
      █  Unit tests for the ConfigurableTypeRegistry class.
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
using OpenIIoT.SDK.Common.Exceptions;
using OpenIIoT.SDK.Configuration;
using Utility.OperationResult;
using Xunit;

[assembly: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]

namespace OpenIIoT.Core.Tests.Configuration
{
    /// <summary>
    ///     Unit tests for the <see cref="Core.Configuration.ConfigurableTypeRegistry"/> class.
    /// </summary>
    [Collection("ConfigurableTypeRegistry")]
    public class ConfigurableTypeRegistry
    {
        #region Private Fields

        /// <summary>
        ///     The instance under test.
        /// </summary>
        private Core.Configuration.ConfigurableTypeRegistry registry;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ConfigurationRegistry"/> class.
        /// </summary>
        public ConfigurableTypeRegistry()
        {
            registry = new Core.Configuration.ConfigurableTypeRegistry();
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///     Tests the constructor.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            Assert.IsType<Core.Configuration.ConfigurableTypeRegistry>(registry);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Configuration.ConfigurableTypeRegistry.IsRegistered(Type)"/> method.
        /// </summary>
        [Fact]
        public void IsRegistered()
        {
            Assert.Equal(false, registry.IsRegistered(typeof(int)));
        }

        /// <summary>
        ///     Tests the properties.
        /// </summary>
        [Fact]
        public void Properties()
        {
            Assert.IsType<Dictionary<Type, SDK.Configuration.IConfigurationDefinition>>(registry.RegisteredTypes);
            Assert.Empty(registry.RegisteredTypes);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Configuration.ConfigurableTypeRegistry.RegisterType(Type, bool)"/> method.
        /// </summary>
        [Fact]
        public void Register()
        {
            IResult result = registry.RegisterType(typeof(ConfigurableMock));
            Assert.Equal(ResultCode.Success, result.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Configuration.ConfigurableTypeRegistry.RegisterType(Type, bool)"/> method with a
        ///     duplicate Type.
        /// </summary>
        [Fact]
        public void RegisterDuplicate()
        {
            IResult result = registry.RegisterType(typeof(ConfigurableMock));
            Assert.Equal(ResultCode.Success, result.ResultCode);

            result = registry.RegisterType(typeof(ConfigurableMock));
            Assert.Equal(ResultCode.Warning, result.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Configuration.ConfigurableTypeRegistry.RegisterType(Type, bool)"/> method with a Type
        ///     which throws an exception from the GetConfigurationDefinition method.
        /// </summary>
        [Fact]
        public void RegisterExceptionDefinition()
        {
            IResult result = registry.RegisterType(typeof(ConfigurableMockExceptionDefinition));
            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Configuration.ConfigurableTypeRegistry.RegisterType(Type, bool)"/> method with a Type
        ///     missing the GetConfigurationDefinition method
        /// </summary>
        [Fact]
        public void RegisterMissingDefinition()
        {
            IResult result = registry.RegisterType(typeof(ConfigurableMockMissingDefinition));
            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Configuration.ConfigurableTypeRegistry.RegisterType(Type, bool)"/> method with a Type
        ///     which does not implement <see cref="IConfigurable{T}"/> .
        /// </summary>
        [Fact]
        public void RegisterNotConfigurable()
        {
            IResult result = registry.RegisterType(typeof(int));
            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Configuration.ConfigurableTypeRegistry.RegisterType(Type, bool)"/> method with a
        ///     non-configurable Type and using the throwsExceptionOnFailure flag.
        /// </summary>
        [Fact]
        public void RegisterNotConfigurableThrowsException()
        {
            Assert.Throws<ConfigurationRegistrationException>(() => registry.RegisterType(typeof(int), true));
        }

        /// <summary>
        ///     Tests the <see cref="Core.Configuration.ConfigurableTypeRegistry.RegisterType(Type, bool)"/> method with a Type
        ///     returning a null value from the GetConfigurationDefinition method
        /// </summary>
        [Fact]
        public void RegisterNullDefinition()
        {
            IResult result = registry.RegisterType(typeof(ConfigurableMockNullDefinition));
            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Configuration.ConfigurableTypeRegistry.RegisterTypes(List{Type}, bool)"/> method with
        ///     both a configurable and non-configurable Type.
        /// </summary>
        [Fact]
        public void RegisterTypes()
        {
            IResult result = registry.RegisterTypes(new List<Type>() { typeof(ConfigurableMock), typeof(int) });
            Assert.Equal(ResultCode.Success, result.ResultCode);
        }

        #endregion Public Methods

        #region Private Classes

        /// <summary>
        ///     Mocks a configurable Type.
        /// </summary>
        /// <remarks>It is not feasible to use a mocking framework for this mockup due to the presence of static methods.</remarks>
        private class ConfigurableMock : IConfigurable<int>
        {
            #region Public Properties

            /// <summary>
            ///     Gets or sets the class Configuration.
            /// </summary>
            public int Configuration { get; set; }

            /// <summary>
            ///     Gets or sets the class ConfigurationDefinition.
            /// </summary>
            public IConfigurationDefinition ConfigurationDefinition { get; set; }

            #endregion Public Properties

            #region Public Methods

            /// <summary>
            ///     Returns the ConfigurationDefinition for the Type.
            /// </summary>
            /// <returns>The ConfigurationDefinition for the Type.</returns>
            public static IConfigurationDefinition GetConfigurationDefinition()
            {
                return new ConfigurationDefinition();
            }

            /// <summary>
            ///     Configures the Type using the configuration stored in the Configuration Manager, or, failing that, using the
            ///     default configuration.
            /// </summary>
            /// <returns>A Result containing the result of the operation.</returns>
            public IResult Configure()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            ///     Configures the Type using the supplied configuration.
            /// </summary>
            /// <param name="configuration">The configuration with which the Type should be configured.</param>
            /// <returns>A Result containing the result of the operation.</returns>
            public IResult Configure(int configuration)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            ///     Saves the Type's configuration to the Configuration Manager.
            /// </summary>
            /// <returns>A Result containing the result of the operation.</returns>
            public IResult SaveConfiguration()
            {
                throw new NotImplementedException();
            }

            #endregion Public Methods
        }

        /// <summary>
        ///     Mocks a configurable Type which throws an exception in the
        ///     <see cref="ConfigurableMockExceptionDefinition.GetConfigurationDefinition"/> method.
        /// </summary>
        /// <remarks>It is not feasible to use a mocking framework for this mockup due to the presence of static methods.</remarks>
        private class ConfigurableMockExceptionDefinition : IConfigurable<int>
        {
            #region Public Properties

            /// <summary>
            ///     Gets or sets the class Configuration.
            /// </summary>
            public int Configuration { get; set; }

            /// <summary>
            ///     Gets or sets the class ConfigurationDefinition.
            /// </summary>
            public IConfigurationDefinition ConfigurationDefinition { get; set; }

            #endregion Public Properties

            #region Public Methods

            /// <summary>
            ///     Returns the ConfigurationDefinition for the Type.
            /// </summary>
            /// <returns>The ConfigurationDefinition for the Type.</returns>
            public static IConfigurationDefinition GetConfigurationDefinition()
            {
                throw new Exception();
            }

            /// <summary>
            ///     Configures the Type using the configuration stored in the Configuration Manager, or, failing that, using the
            ///     default configuration.
            /// </summary>
            /// <returns>A Result containing the result of the operation.</returns>
            public IResult Configure()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            ///     Configures the Type using the supplied configuration.
            /// </summary>
            /// <param name="configuration">The configuration with which the Type should be configured.</param>
            /// <returns>A Result containing the result of the operation.</returns>
            public IResult Configure(int configuration)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            ///     Saves the Type's configuration to the Configuration Manager.
            /// </summary>
            /// <returns>A Result containing the result of the operation.</returns>
            public IResult SaveConfiguration()
            {
                throw new NotImplementedException();
            }

            #endregion Public Methods
        }

        /// <summary>
        ///     Mocks a configurable Type with a missing <see cref="ConfigurableMockMissingDefault.GetDefaultDefinition"/> method.
        /// </summary>
        /// <remarks>It is not feasible to use a mocking framework for this mockup due to the presence of static methods.</remarks>
        private class ConfigurableMockMissingDefault : IConfigurable<int>
        {
            #region Public Properties

            /// <summary>
            ///     Gets or sets the class Configuration.
            /// </summary>
            public int Configuration { get; set; }

            /// <summary>
            ///     Gets or sets the class ConfigurationDefinition.
            /// </summary>
            public IConfigurationDefinition ConfigurationDefinition { get; set; }

            #endregion Public Properties

            #region Public Methods

            /// <summary>
            ///     Returns the ConfigurationDefinition for the Type.
            /// </summary>
            /// <returns>The ConfigurationDefinition for the Type.</returns>
            public static IConfigurationDefinition GetConfigurationDefinition()
            {
                return new ConfigurationDefinition();
            }

            /// <summary>
            ///     Configures the Type using the configuration stored in the Configuration Manager, or, failing that, using the
            ///     default configuration.
            /// </summary>
            /// <returns>A Result containing the result of the operation.</returns>
            public IResult Configure()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            ///     Configures the Type using the supplied configuration.
            /// </summary>
            /// <param name="configuration">The configuration with which the Type should be configured.</param>
            /// <returns>A Result containing the result of the operation.</returns>
            public IResult Configure(int configuration)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            ///     Saves the Type's configuration to the Configuration Manager.
            /// </summary>
            /// <returns>A Result containing the result of the operation.</returns>
            public IResult SaveConfiguration()
            {
                throw new NotImplementedException();
            }

            #endregion Public Methods
        }

        /// <summary>
        ///     Mocks a configurable Type with a missing <see cref="ConfigurableMockMissingDefinition.GetConfigurationDefinition"/> method.
        /// </summary>
        /// <remarks>It is not feasible to use a mocking framework for this mockup due to the presence of static methods.</remarks>
        private class ConfigurableMockMissingDefinition : IConfigurable<int>
        {
            #region Public Properties

            /// <summary>
            ///     Gets or sets the class Configuration.
            /// </summary>
            public int Configuration { get; set; }

            /// <summary>
            ///     Gets or sets the class ConfigurationDefinition.
            /// </summary>
            public IConfigurationDefinition ConfigurationDefinition { get; set; }

            #endregion Public Properties

            #region Public Methods

            /// <summary>
            ///     Configures the Type using the configuration stored in the Configuration Manager, or, failing that, using the
            ///     default configuration.
            /// </summary>
            /// <returns>A Result containing the result of the operation.</returns>
            public IResult Configure()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            ///     Configures the Type using the supplied configuration.
            /// </summary>
            /// <param name="configuration">The configuration with which the Type should be configured.</param>
            /// <returns>A Result containing the result of the operation.</returns>
            public IResult Configure(int configuration)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            ///     Saves the Type's configuration to the Configuration Manager.
            /// </summary>
            /// <returns>A Result containing the result of the operation.</returns>
            public IResult SaveConfiguration()
            {
                throw new NotImplementedException();
            }

            #endregion Public Methods
        }

        /// <summary>
        ///     Mocks a configurable Type which returns a null value from the
        ///     <see cref="ConfigurableMockNullDefinition.GetConfigurationDefinition"/> method.
        /// </summary>
        /// <remarks>It is not feasible to use a mocking framework for this mockup due to the presence of static methods.</remarks>
        private class ConfigurableMockNullDefinition : IConfigurable<int>
        {
            #region Public Properties

            /// <summary>
            ///     Gets or sets the class Configuration.
            /// </summary>
            public int Configuration { get; set; }

            /// <summary>
            ///     Gets or sets the class ConfigurationDefinition.
            /// </summary>
            public IConfigurationDefinition ConfigurationDefinition { get; set; }

            #endregion Public Properties

            #region Public Methods

            /// <summary>
            ///     Returns the ConfigurationDefinition for the Type.
            /// </summary>
            /// <returns>The ConfigurationDefinition for the Type.</returns>
            public static IConfigurationDefinition GetConfigurationDefinition()
            {
                return null;
            }

            /// <summary>
            ///     Configures the Type using the configuration stored in the Configuration Manager, or, failing that, using the
            ///     default configuration.
            /// </summary>
            /// <returns>A Result containing the result of the operation.</returns>
            public IResult Configure()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            ///     Configures the Type using the supplied configuration.
            /// </summary>
            /// <param name="configuration">The configuration with which the Type should be configured.</param>
            /// <returns>A Result containing the result of the operation.</returns>
            public IResult Configure(int configuration)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            ///     Saves the Type's configuration to the Configuration Manager.
            /// </summary>
            /// <returns>A Result containing the result of the operation.</returns>
            public IResult SaveConfiguration()
            {
                throw new NotImplementedException();
            }

            #endregion Public Methods
        }

        #endregion Private Classes
    }
}