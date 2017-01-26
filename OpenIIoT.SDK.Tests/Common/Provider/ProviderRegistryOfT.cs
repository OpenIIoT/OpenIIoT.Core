/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄███████▄                                                               ▄████████                                                               ▄██████▄                ███
      █     ███    ███                                                              ███    ███                                                              ███    ███           ▀█████████▄
      █     ███    ███    █████  ██████   █    █   █  ██████▄     ▄█████    █████  ▄███▄▄▄▄██▀    ▄█████    ▄████▄   █    ▄█████     ██       █████ ▄█   ▄  ███    ███    ▄█████    ▀███▀▀██
      █     ███    ███   ██  ██ ██    ██ ██    ██ ██  ██   ▀██   ██   █    ██  ██ ▀▀███▀▀▀▀▀     ██   █    ██    ▀  ██    ██  ▀  ▀███████▄   ██  ██ ██   █▄ ███    ███   ██   ▀█     ███   ▀
      █   ▀█████████▀   ▄██▄▄█▀ ██    ██ ██    ██ ██▌ ██    ██  ▄██▄▄     ▄██▄▄█▀ ▀███████████  ▄██▄▄     ▄██       ██▌   ██         ██  ▀  ▄██▄▄█▀ ▀▀▀▀▀██ ███    ███  ▄██▄▄        ███
      █     ███        ▀███████ ██    ██ ██    ██ ██  ██    ██ ▀▀██▀▀    ▀███████   ███    ███ ▀▀██▀▀    ▀▀██ ███▄  ██  ▀███████     ██    ▀███████ ▄█   ██ ███    ███ ▀▀██▀▀        ███
      █     ███          ██  ██ ██    ██  █▄  ▄█  ██  ██   ▄██   ██   █    ██  ██   ███    ███   ██   █    ██    ██ ██     ▄  ██     ██      ██  ██ ██   ██ ███    ███   ██          ███
      █    ▄████▀        ██  ██  ██████    ▀██▀   █   ██████▀    ███████   ██  ██   ███    ███   ███████   ██████▀  █    ▄████▀     ▄██▀     ██  ██  █████   ▀██████▀    ██         ▄████▀
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
      █  Unit tests for the ProviderRegistryOfT class.
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

using Moq;
using OpenIIoT.SDK.Common.Provider;
using Utility.OperationResult;
using Xunit;

namespace OpenIIoT.SDK.Tests.Common.Provider
{
    /// <summary>
    ///     Unit tests for the <see cref="ProviderRegistry{T}"/> class.
    /// </summary>
    [Collection("ProviderRegistryOfT")]
    public class ProviderRegistryOfT
    {
        #region Public Methods

        /// <summary>
        ///     Tests the class constructor.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            Mock<IApplicationManager> applicationManager = new Mock<IApplicationManager>();

            ProviderRegistry<IProvider> test = new ProviderRegistry<IProvider>(applicationManager.Object);

            Assert.IsType<ProviderRegistry<IProvider>>(test);
        }

        /// <summary>
        ///     Tess the <see cref="ProviderRegistry{T}.Discover"/> method.
        /// </summary>
        [Fact]
        public void Discover()
        {
            Mock<IApplicationManager> applicationManager = new Mock<IApplicationManager>();
            ProviderRegistry<IProvider> test = new ProviderRegistry<IProvider>(applicationManager.Object);

            Assert.Empty(test.Providers);

            test.Discover();

            Assert.Empty(test.Providers);
        }

        /// <summary>
        ///     Tests the <see cref="ProviderRegistry{T}.Register(T)"/> method.
        /// </summary>
        [Fact]
        public void Register()
        {
            Mock<IApplicationManager> applicationManager = new Mock<IApplicationManager>();
            ProviderRegistry<IProvider> test = new ProviderRegistry<IProvider>(applicationManager.Object);
            Mock<IProvider> provider = new Mock<IProvider>();

            Assert.Empty(test.Providers);

            Result result = test.Register(provider.Object);

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.NotEmpty(test.Providers);
        }

        /// <summary>
        ///     Tests the <see cref="ProviderRegistry{T}.Register(T)"/> method with an object that has already been registered.
        /// </summary>
        [Fact]
        public void RegisterAlreadyRegistered()
        {
            Mock<IApplicationManager> applicationManager = new Mock<IApplicationManager>();
            ProviderRegistry<IProvider> test = new ProviderRegistry<IProvider>(applicationManager.Object);
            Mock<IProvider> provider = new Mock<IProvider>();

            Result result = test.Register(provider.Object);

            Assert.Equal(ResultCode.Success, result.ResultCode);

            result = test.Register(provider.Object);

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="ProviderRegistry{T}.UnRegister(T)"/> method.
        /// </summary>
        [Fact]
        public void UnRegister()
        {
            Mock<IApplicationManager> applicationManager = new Mock<IApplicationManager>();
            ProviderRegistry<IProvider> test = new ProviderRegistry<IProvider>(applicationManager.Object);
            Mock<IProvider> provider = new Mock<IProvider>();
            test.Register(provider.Object);

            Assert.NotEmpty(test.Providers);

            Result result = test.UnRegister(provider.Object);

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Empty(test.Providers);
        }

        /// <summary>
        ///     Tests the <see cref="ProviderRegistry{T}.UnRegister(T)"/> method with an object that has not been registered.
        /// </summary>
        [Fact]
        public void UnRegisterNotRegistered()
        {
            Mock<IApplicationManager> applicationManager = new Mock<IApplicationManager>();
            ProviderRegistry<IProvider> test = new ProviderRegistry<IProvider>(applicationManager.Object);
            Mock<IProvider> provider = new Mock<IProvider>();

            Result result = test.UnRegister(provider.Object);

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        #endregion Public Methods
    }
}