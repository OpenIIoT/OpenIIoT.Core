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

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Moq;
using Xunit;
using System;
using Utility.OperationResult;

[assembly: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]

namespace OpenIIoT.SDK.Tests.Configuration
{
    /// <summary>
    ///     Unit tests for the <see cref="SDK.Configuration.Configuration"/> class.
    /// </summary>
    [Collection("Configuration")]
    public class Configuration
    {
        private Mock<SDK.Configuration.IConfigurableTypeRegistry> registry;
        private SDK.Configuration.Configuration configuration;

        public Configuration()
        {
            registry = new Mock<SDK.Configuration.IConfigurableTypeRegistry>();
            configuration = new SDK.Configuration.Configuration(registry.Object);
        }

        [Fact]
        public void Constructor()
        {
            // instantiate a new configuration with no instances
            SDK.Configuration.Configuration test = new SDK.Configuration.Configuration(registry.Object);

            Assert.IsType<SDK.Configuration.Configuration>(test);
            Assert.Empty(test.Instances);

            // instantiate a new configuration with a predetermined list of instances
            Dictionary<string, Dictionary<string, object>> instances = new Dictionary<string, Dictionary<string, object>>();
            instances.Add("test", new Dictionary<string, object>());

            test = new SDK.Configuration.Configuration(registry.Object, instances);

            Assert.IsType<SDK.Configuration.Configuration>(test);
            Assert.NotEmpty(test.Instances);
        }

        [Fact]
        public void LoadInstancesFrom()
        {
            Dictionary<string, Dictionary<string, object>> instances = new Dictionary<string, Dictionary<string, object>>();
            instances.Add("test", new Dictionary<string, object>());
            instances.Add("test 2", new Dictionary<string, object>());

            Assert.Empty(configuration.Instances);

            configuration.LoadInstancesFrom(instances);

            Assert.NotEmpty(configuration.Instances);
            Assert.Equal(2, configuration.Instances.Count);
            Assert.True(configuration.Instances.ContainsKey("test 2"));
        }

        [Fact]
        public void IsInstanceConfiguredNoType()
        {
            Result<bool> result = configuration.IsInstanceConfigured(typeof(int), "");

            Assert.Equal(ResultCode.Failure, result.ResultCode);
            Assert.False(result.ReturnValue);
        }

        [Fact]
        public void IsInstanceConfiguredNoInstance()
        {
            // prepare instance list
            Dictionary<string, object> instanceList = new Dictionary<string, object>();
            instanceList.Add("", 1);

            Dictionary<string, Dictionary<string, object>> instances = new Dictionary<string, Dictionary<string, object>>();
            instances.Add(typeof(int).FullName, instanceList);

            configuration.LoadInstancesFrom(instances);

            Result<bool> result = configuration.IsInstanceConfigured(typeof(int), "test");

            Assert.Equal(ResultCode.Failure, result.ResultCode);
            Assert.False(result.ReturnValue);
        }

        [Fact]
        public void IsInstanceConfigured()
        {
            // prepare instance list
            Dictionary<string, object> instanceList = new Dictionary<string, object>();
            instanceList.Add("", 1);

            Dictionary<string, Dictionary<string, object>> instances = new Dictionary<string, Dictionary<string, object>>();
            instances.Add(typeof(int).FullName, instanceList);

            configuration.LoadInstancesFrom(instances);

            Result<bool> result = configuration.IsInstanceConfigured(typeof(int), "");

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.True(result.ReturnValue);
        }

        [Fact]
        public void AddInstance()
        {
            registry.Setup(r => r.IsRegistered(It.IsAny<Type>())).Returns(true);
        }

        [Fact]
        public void GetInstanceNotConfigured()
        {
            Result<int> result = configuration.GetInstance<int>(typeof(int), "");

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        [Fact]
        public void GetInstance()
        {
            // prepare instance list
            Dictionary<string, object> instanceList = new Dictionary<string, object>();
            instanceList.Add("", 1);

            Dictionary<string, Dictionary<string, object>> instances = new Dictionary<string, Dictionary<string, object>>();
            instances.Add(typeof(int).FullName, instanceList);

            configuration.LoadInstancesFrom(instances);

            Result<int> result = configuration.GetInstance<int>(typeof(int), "");

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal(1, result.ReturnValue);
        }

        [Fact]
        public void GetInstanceException()
        {
            // prepare instance list
            Dictionary<string, object> instanceList = new Dictionary<string, object>();
            instanceList.Add("", new CircularObject());

            Dictionary<string, Dictionary<string, object>> instances = new Dictionary<string, Dictionary<string, object>>();
            instances.Add(typeof(CircularObject).FullName, instanceList);

            configuration.LoadInstancesFrom(instances);

            Result<CircularObject> result = configuration.GetInstance<CircularObject>(typeof(CircularObject), "");

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        [Fact]
        public void UpdateInstance()
        {
            // prepare instance list
            Dictionary<string, object> instanceList = new Dictionary<string, object>();
            instanceList.Add("", 1);

            Dictionary<string, Dictionary<string, object>> instances = new Dictionary<string, Dictionary<string, object>>();
            instances.Add(typeof(int).FullName, instanceList);

            configuration.LoadInstancesFrom(instances);

            Result result = configuration.UpdateInstance(typeof(int), 2, "");

            Assert.Equal(ResultCode.Success, result.ResultCode);

            Result<int> getResult = configuration.GetInstance<int>(typeof(int), "");

            Assert.Equal(ResultCode.Success, getResult.ResultCode);
            Assert.Equal(2, getResult.ReturnValue);
        }

        [Fact]
        public void RemoveInstance()
        {
            // prepare instance list
            Dictionary<string, object> instanceList = new Dictionary<string, object>();
            instanceList.Add("", 1);

            Dictionary<string, Dictionary<string, object>> instances = new Dictionary<string, Dictionary<string, object>>();
            instances.Add(typeof(int).FullName, instanceList);

            configuration.LoadInstancesFrom(instances);

            Assert.NotEmpty(configuration.Instances);

            Result result = configuration.RemoveInstance(typeof(int), "");

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Empty(configuration.Instances[typeof(int).FullName]);
        }

        [Fact]
        public void UpdateInstanceNotConfigured()
        {
            Result result = configuration.UpdateInstance(typeof(string), "test", "");

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        [Fact]
        public void RemoveInstanceNotConfigured()
        {
            Result result = configuration.RemoveInstance(typeof(int), "");

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        /// <summary>
        ///     Creates a class with a circular property to force a serialization exception.
        /// </summary>
        /// <remarks>
        ///     It is not feasible to use a mocking framework for this mockup due to the simplicity and the work involved to create
        ///     a matching interface.
        /// </remarks>
        private class CircularObject
        {
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
        }
    }
}