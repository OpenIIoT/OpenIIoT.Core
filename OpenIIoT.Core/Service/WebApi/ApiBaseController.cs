/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █     ▄████████                ▀█████████▄
      █     ███    ███                 ███    ███
      █     ███    ███    █████▄  █    ███    ███   ▄█████    ▄█████    ▄█████
      █     ███    ███   ██   ██ ██   ▄███▄▄▄██▀    ██   ██   ██  ▀    ██   █
      █   ▀███████████   ██   ██ ██▌ ▀▀███▀▀▀██▄    ██   ██   ██      ▄██▄▄
      █     ███    ███ ▀██████▀  ██    ███    ██▄ ▀████████ ▀███████ ▀▀██▀▀
      █     ███    ███   ██      ██    ███    ███   ██   ██    ▄  ██   ██   █
      █     ███    █▀   ▄███▀    █   ▄█████████▀    ██   █▀  ▄████▀    ███████
      █
      █   ▄████████
      █   ███    ███
      █   ███    █▀   ██████  ██▄▄▄▄      ██       █████  ██████   █        █          ▄█████    █████
      █   ███        ██    ██ ██▀▀▀█▄ ▀███████▄   ██  ██ ██    ██ ██       ██         ██   █    ██  ██
      █   ███        ██    ██ ██   ██     ██  ▀  ▄██▄▄█▀ ██    ██ ██       ██        ▄██▄▄     ▄██▄▄█▀
      █   ███    █▄  ██    ██ ██   ██     ██    ▀███████ ██    ██ ██       ██       ▀▀██▀▀    ▀███████
      █   ███    ███ ██    ██ ██   ██     ██      ██  ██ ██    ██ ██▌    ▄ ██▌    ▄   ██   █    ██  ██
      █   ████████▀   ██████   █   █     ▄██▀     ██  ██  ██████  ████▄▄██ ████▄▄██   ███████   ██  ██
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  The abstract base controller from which ApiController instances may inherit.
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

namespace OpenIIoT.Core.Service.WebApi
{
    using System.Diagnostics.CodeAnalysis;
    using System.Net.Http.Formatting;
    using System.Web.Http;
    using Newtonsoft.Json;
    using OpenIIoT.SDK;
    using OpenIIoT.SDK.Common;

    /// <summary>
    ///     The abstract base controller from which <see cref="ApiController"/> instances may inherit.
    /// </summary>
    public abstract class ApiBaseController : ApiController
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApiBaseController"/> class.
        /// </summary>
        [ExcludeFromCodeCoverage]
        protected ApiBaseController()
            : this(ApplicationManager.GetInstance())
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApiBaseController"/> class with the specified
        ///     <see cref="IApplicationManager"/> instance.
        /// </summary>
        /// <param name="manager">The IApplicationManager instance used to resolve dependencies.</param>
        protected ApiBaseController(IApplicationManager manager)
        {
            Manager = manager;
        }

        #endregion Public Constructors

        #region Protected Properties

        /// <summary>
        ///     Gets the <see cref="IApplicationManager"/> instance for the application.
        /// </summary>
        protected IApplicationManager Manager { get; private set; }

        #endregion Protected Properties

        #region Protected Methods

        /// <summary>
        ///     Returns the JsonMediaTypeFormatter to use with this controller.
        /// </summary>
        /// <param name="resolverType">
        ///     A ContractResolverType representing the desired behavior of serializationProperties, OptIn or OptOut.
        /// </param>
        /// <param name="properties">
        ///     A list of properties to exclude or include, depending on the ContractResolverType, in the serialized result.
        /// </param>
        /// <returns>A configured instance of JsonMediaTypeFormatter</returns>
        protected JsonMediaTypeFormatter JsonFormatter(ContractResolverType resolverType, params string[] properties)
        {
            JsonMediaTypeFormatter retVal = new JsonMediaTypeFormatter
            {
                SerializerSettings = new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,
                    DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                    Formatting = Formatting.Indented,
                    ContractResolver = new ContractResolver(resolverType, properties),
                },
            };

            retVal.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());

            return retVal;
        }

        /// <summary>
        ///     Returns the default JsonMediaTypeFormatter.
        /// </summary>
        /// <returns>The default instance of JsonMediaTypeFormatter</returns>
        protected JsonMediaTypeFormatter JsonFormatter()
        {
            return JsonFormatter(ContractResolverType.OptOut);
        }

        #endregion Protected Methods
    }
}