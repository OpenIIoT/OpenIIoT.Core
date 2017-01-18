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
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Facilitates the discovery and registration of all discoverable IProvider instances matching the Type T within the application.
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
using System.Linq;
using OpenIIoT.SDK.Common.Discovery;
using Utility.OperationResult;

namespace OpenIIoT.SDK.Common.Provider
{
    /// <summary>
    ///     Facilitates the discovery and registration of all discoverable <see cref="IProvider"/> instances matching the
    ///     <see cref="Type"/> T contained within the application.
    /// </summary>
    /// <typeparam name="T">The Type of IProvider for which the registry is to manage registration and discovery.</typeparam>
    public class ProviderRegistry<T> where T : IProvider
    {
        #region Private Fields

        /// <summary>
        ///     The Application Manager instance for the application.
        /// </summary>
        private IApplicationManager manager;

        /// <summary>
        ///     The list of registered <see cref="IProvider"/> instances.
        /// </summary>
        private IList<T> providers;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ProviderRegistry{T}"/> class.
        /// </summary>
        /// <param name="manager">The Application Manager instance for the application.</param>
        public ProviderRegistry(IApplicationManager manager)
        {
            this.manager = manager;
            providers = new List<T>();
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        ///     Gets the list of registered <see cref="IProvider"/> instances.
        /// </summary>
        public IReadOnlyList<T> Providers
        {
            get
            {
                return providers.ToList().AsReadOnly();
            }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///     Invokes the <see cref="Discoverer"/> to discover instances with a <see cref="Type"/> which is assignable from the
        ///     <see cref="Type"/> of this generic <see cref="ProviderRegistry{T}"/>.
        /// </summary>
        /// <returns>The list of discovered <see cref="IProvider"/> instances.</returns>
        public IReadOnlyList<T> Discover()
        {
            providers = Discoverer.Discover<T>(manager);

            return Providers;
        }

        /// <summary>
        ///     Searches the registry for an <see cref="IProvider"/> instance matching the specified instance and returns a value
        ///     indicating whether the specified instance was found was found.
        /// </summary>
        /// <param name="provider">The instance for which the registry is to be searched.</param>
        /// <returns>A value indicating whether the specified instance was found.</returns>
        public bool IsRegistered(T provider)
        {
            return providers.Any(r => object.ReferenceEquals(r, provider));
        }

        /// <summary>
        ///     Adds the specified <see cref="IProvider"/> instance to the registry.
        /// </summary>
        /// <param name="provider">The instance to add.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result Register(T provider)
        {
            Result retVal = new Result(ResultCode.Failure);

            if (!IsRegistered(provider))
            {
                providers.Add(provider);
                retVal.SetResultCode(ResultCode.Success);
            }

            return retVal;
        }

        /// <summary>
        ///     Removes the specified <see cref="IProvider"/> instance from the registry.
        /// </summary>
        /// <param name="provider">The instance to remove.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result UnRegister(T provider)
        {
            Result retVal = new Result(ResultCode.Failure);

            if (IsRegistered(provider))
            {
                providers.Remove(provider);
                retVal.SetResultCode(ResultCode.Success);
            }

            return retVal;
        }

        #endregion Public Methods
    }
}