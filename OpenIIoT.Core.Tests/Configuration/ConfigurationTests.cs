/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █   ▄████████
      █   ███    ███
      █   ███    █▀   ██████  ██▄▄▄▄     ▄█████  █     ▄████▄  ██   █     █████   ▄█████      ██     █   ██████  ██▄▄▄▄
      █   ███        ██    ██ ██▀▀▀█▄   ██   ▀█ ██    ██    ▀  ██   ██   ██  ██   ██   ██ ▀███████▄ ██  ██    ██ ██▀▀▀█▄
      █   ███        ██    ██ ██   ██  ▄██▄▄    ██▌  ▄██       ██   ██  ▄██▄▄█▀   ██   ██     ██  ▀ ██▌ ██    ██ ██   ██
      █   ███    █▄  ██    ██ ██   ██ ▀▀██▀▀    ██  ▀▀██ ███▄  ██   ██ ▀███████ ▀████████     ██    ██  ██    ██ ██   ██
      █   ███    ███ ██    ██ ██   ██   ██      ██    ██    ██ ██   ██   ██  ██   ██   ██     ██    ██  ██    ██ ██   ██
      █   ████████▀   ██████   █   █    ██      █     ██████▀  ██████    ██  ██   ██   █▀    ▄██▀   █    ██████   █   █
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
      █  Unit tests for the Configuration class.
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

namespace OpenIIoT.Core.Tests.Configuration
{
    using System;
    using System.Collections.Generic;
    using Moq;
    using OpenIIoT.Core.Configuration;
    using OpenIIoT.SDK.Common.OperationResult;
    using Xunit;
    using OpenIIoT.SDK.Configuration;

    /// <summary>
    ///     Unit tests for the <see cref="Configuration"/> class.
    /// </summary>
    public class ConfigurationTests
    {
        #region Private Fields

        /// <summary>
        ///     The Configuration under test.
        /// </summary>
        private Configuration configuration;

        /// <summary>
        ///     The registry to inject into the Configuration under test.
        /// </summary>
        private Mock<IConfigurableTypeRegistry> registry;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ConfigurationTests"/> class.
        /// </summary>
        public ConfigurationTests()
        {
            registry = new Mock<IConfigurableTypeRegistry>();
            configuration = new Configuration(registry.Object);
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///     Tests the <see cref="Configuration.AddInstance{T}(Type, object, string)"/> method.
        /// </summary>
        [Fact]
        public void AddInstance()
        {
            registry = new Mock<IConfigurableTypeRegistry>();
            registry.Setup(r => r.IsRegistered(It.IsAny<Type>())).Returns(true);

            configuration = new Configuration(registry.Object);

            IResult result = configuration.AddInstance<int>(typeof(int), 1, "test");

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.True(configuration.IsInstanceConfigured(typeof(int), "test").ReturnValue);
        }

        /// <summary>
        ///     Tests the <see cref="Configuration.AddInstance{T}(Type, object, string)"/> method with an instance that has already
        ///     been configured.
        /// </summary>
        [Fact]
        public void AddInstanceAlreadyConfigured()
        {
            registry = new Mock<IConfigurableTypeRegistry>();
            registry.Setup(r => r.IsRegistered(It.IsAny<Type>())).Returns(true);

            configuration = new Configuration(registry.Object);

            IResult result = configuration.AddInstance<int>(typeof(int), 1, "test");

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.True(configuration.IsInstanceConfigured(typeof(int), "test").ReturnValue);

            result = configuration.AddInstance<int>(typeof(int), 2, "test");

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="Configuration.AddInstance{T}(Type, object, string)"/> method with an instance whose Type has
        ///     not been configured.
        /// </summary>
        [Fact]
        public void AddInstanceNotRegistered()
        {
            IResult result = configuration.AddInstance<int>(typeof(int), string.Empty);

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        /// <summary>
        ///     Tests all constructor overloads.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            // instantiate a new configuration with no instances
            Configuration test = new Configuration(registry.Object);

            Assert.IsType<Configuration>(test);
            Assert.Empty(test.Instances);

            // instantiate a new configuration with a predetermined list of instances
            IDictionary<string, IDictionary<string, object>> instances = new Dictionary<string, IDictionary<string, object>>();
            instances.Add("test", new Dictionary<string, object>());

            test = new Configuration(registry.Object, instances);

            Assert.IsType<Configuration>(test);
            Assert.NotEmpty(test.Instances);
        }

        /// <summary>
        ///     Tests the <see cref="Configuration.GetInstance{T}(Type, string)"/> method.
        /// </summary>
        [Fact]
        public void GetInstance()
        {
            // prepare instance list
            Dictionary<string, object> instanceList = new Dictionary<string, object>();
            instanceList.Add(string.Empty, 1);

            IDictionary<string, IDictionary<string, object>> instances = new Dictionary<string, IDictionary<string, object>>();
            instances.Add(typeof(int).FullName, instanceList);

            configuration.LoadInstancesFrom(instances);

            IResult<int> result = configuration.GetInstance<int>(typeof(int), string.Empty);

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal(1, result.ReturnValue);
        }

        /// <summary>
        ///     Tests the <see cref="Configuration.GetInstance{T}(Type, string)"/> method with input which is known to raise an exception.
        /// </summary>
        [Fact]
        public void GetInstanceException()
        {
            // prepare instance list
            Dictionary<string, object> instanceList = new Dictionary<string, object>();
            instanceList.Add(string.Empty, new CircularObject());

            IDictionary<string, IDictionary<string, object>> instances = new Dictionary<string, IDictionary<string, object>>();
            instances.Add(typeof(CircularObject).FullName, instanceList);

            configuration.LoadInstancesFrom(instances);

            IResult<CircularObject> result = configuration.GetInstance<CircularObject>(typeof(CircularObject), string.Empty);

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="Configuration.GetInstance{T}(Type, string)"/> method with an instance which is not configured.
        /// </summary>
        [Fact]
        public void GetInstanceNotConfigured()
        {
            IResult<int> result = configuration.GetInstance<int>(typeof(int), string.Empty);

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="Configuration.IsInstanceConfigured(Type, string)"/> method.
        /// </summary>
        [Fact]
        public void IsInstanceConfigured()
        {
            // prepare instance list
            Dictionary<string, object> instanceList = new Dictionary<string, object>();
            instanceList.Add(string.Empty, 1);

            IDictionary<string, IDictionary<string, object>> instances = new Dictionary<string, IDictionary<string, object>>();
            instances.Add(typeof(int).FullName, instanceList);

            configuration.LoadInstancesFrom(instances);

            IResult<bool> result = configuration.IsInstanceConfigured(typeof(int), string.Empty);

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.True(result.ReturnValue);
        }

        /// <summary>
        ///     Tests the <see cref="Configuration.IsInstanceConfigured(Type, string)"/> with an instance for which there is a Type
        ///     entry but no matching instance.
        /// </summary>
        [Fact]
        public void IsInstanceConfiguredNoInstance()
        {
            // prepare instance list
            Dictionary<string, object> instanceList = new Dictionary<string, object>();
            instanceList.Add(string.Empty, 1);

            IDictionary<string, IDictionary<string, object>> instances = new Dictionary<string, IDictionary<string, object>>();
            instances.Add(typeof(int).FullName, instanceList);

            configuration.LoadInstancesFrom(instances);

            IResult<bool> result = configuration.IsInstanceConfigured(typeof(int), "test");

            Assert.Equal(ResultCode.Failure, result.ResultCode);
            Assert.False(result.ReturnValue);
        }

        /// <summary>
        ///     Tests the <see cref="Configuration.IsInstanceConfigured(Type, string)"/> method with an instance for which there is
        ///     no Type entry.
        /// </summary>
        [Fact]
        public void IsInstanceConfiguredNoType()
        {
            IResult<bool> result = configuration.IsInstanceConfigured(typeof(int), string.Empty);

            Assert.Equal(ResultCode.Failure, result.ResultCode);
            Assert.False(result.ReturnValue);
        }

        /// <summary>
        ///     Tests the <see cref="Configuration.LoadInstancesFrom(IDictionary{string, IDictionary{string, object}})"/> method.
        /// </summary>
        [Fact]
        public void LoadInstancesFrom()
        {
            IDictionary<string, IDictionary<string, object>> instances = new Dictionary<string, IDictionary<string, object>>();
            instances.Add("test", new Dictionary<string, object>());
            instances.Add("test 2", new Dictionary<string, object>());

            Assert.Empty(configuration.Instances);

            configuration.LoadInstancesFrom(instances);

            Assert.NotEmpty(configuration.Instances);
            Assert.Equal(2, configuration.Instances.Count);
            Assert.True(configuration.Instances.ContainsKey("test 2"));
        }

        /// <summary>
        ///     Tests the <see cref="Configuration.RemoveInstance(Type, string)"/> method.
        /// </summary>
        [Fact]
        public void RemoveInstance()
        {
            // prepare instance list
            Dictionary<string, object> instanceList = new Dictionary<string, object>();
            instanceList.Add(string.Empty, 1);

            IDictionary<string, IDictionary<string, object>> instances = new Dictionary<string, IDictionary<string, object>>();
            instances.Add(typeof(int).FullName, instanceList);

            configuration.LoadInstancesFrom(instances);

            Assert.NotEmpty(configuration.Instances);

            IResult result = configuration.RemoveInstance(typeof(int), string.Empty);

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Empty(configuration.Instances[typeof(int).FullName]);
        }

        /// <summary>
        ///     Tests the <see cref="Configuration.RemoveInstance(Type, string)"/> method with an instance that has not been configured.
        /// </summary>
        [Fact]
        public void RemoveInstanceNotConfigured()
        {
            IResult result = configuration.RemoveInstance(typeof(int), string.Empty);

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="Configuration.UpdateInstance(Type, object, string)"/> method.
        /// </summary>
        [Fact]
        public void UpdateInstance()
        {
            // prepare instance list
            Dictionary<string, object> instanceList = new Dictionary<string, object>();
            instanceList.Add(string.Empty, 1);

            IDictionary<string, IDictionary<string, object>> instances = new Dictionary<string, IDictionary<string, object>>();
            instances.Add(typeof(int).FullName, instanceList);

            configuration.LoadInstancesFrom(instances);

            IResult result = configuration.UpdateInstance(typeof(int), 2, string.Empty);

            Assert.Equal(ResultCode.Success, result.ResultCode);

            IResult<int> getResult = configuration.GetInstance<int>(typeof(int), string.Empty);

            Assert.Equal(ResultCode.Success, getResult.ResultCode);
            Assert.Equal(2, getResult.ReturnValue);
        }

        /// <summary>
        ///     Tests the <see cref="Configuration.UpdateInstance(Type, object, string)"/> method with an instance that has not
        ///     been configured.
        /// </summary>
        [Fact]
        public void UpdateInstanceNotConfigured()
        {
            IResult result = configuration.UpdateInstance(typeof(string), "test", string.Empty);

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        #endregion Public Methods

        #region Private Classes

        /// <summary>
        ///     Creates a class with a circular property to force a serialization exception.
        /// </summary>
        /// <remarks>
        ///     It is not feasible to use a mocking framework for this mockup due to the simplicity and the work involved to create
        ///     a matching interface.
        /// </remarks>
        private class CircularObject
        {
            #region Public Properties

            /// <summary>
            ///     Gets the circular reference.
            /// </summary>
            public CircularObject This
            {
                get
                {
                    return this;
                }
            }

            #endregion Public Properties
        }

        #endregion Private Classes
    }
}