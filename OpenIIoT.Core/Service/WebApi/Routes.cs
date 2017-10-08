/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄████████
      █     ███    ███
      █    ▄███▄▄▄▄██▀  ██████  ██   █      ██       ▄█████   ▄█████
      █   ▀▀███▀▀▀▀▀   ██    ██ ██   ██ ▀███████▄   ██   █    ██  ▀
      █   ▀███████████ ██    ██ ██   ██     ██  ▀  ▄██▄▄      ██
      █     ███    ███ ██    ██ ██   ██     ██    ▀▀██▀▀    ▀███████
      █     ███    ███ ██    ██ ██   ██     ██      ██   █     ▄  ██
      █     ███    ███  ██████  ██████     ▄██▀     ███████  ▄████▀
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Web Routes for the Web Service.
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
    using OpenIIoT.SDK.Service.WebApi;

    /// <summary>
    ///     Web Routes for the <see cref="WebApiService"/>.
    /// </summary>
    public class Routes : IRoutes
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Routes"/> class using the specified <paramref name="configuration"/>.
        /// </summary>
        /// <param name="configuration">
        ///     The configuration for the <see cref="WebApiService"/> containing user-defined route information.
        /// </param>
        public Routes(WebApiServiceConfiguration configuration)
        {
            Root = configuration.Root.TrimStart('/').TrimEnd('/');

            Api = $"{Root}/{WebApiConstants.ApiRoutePrefix}".TrimStart('/');
            SignalR = $"/{Root}/{WebApiConstants.SignalRRoutePrefix}".Replace("//", "/");
            HelpRoot = $"{Root}/{WebApiConstants.HelpRoutePrefix}".TrimStart('/');
            Swagger = $"{HelpRoot}/docs/{{apiVersion}}";
            SwaggerUi = $"{HelpRoot}/ui/{{*assetPath}}";
            Help = $"{HelpRoot}/ui/index";
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        ///     Gets the base route for Api endpoints.
        /// </summary>
        public string Api { get; private set; }

        /// <summary>
        ///     Gets the user-friendly route for SwaggerUi.
        /// </summary>
        public string Help { get; private set; }

        /// <summary>
        ///     Gets the base route for Swagger components.
        /// </summary>
        public string HelpRoot { get; private set; }

        /// <summary>
        ///     Gets the user-defined web root.
        /// </summary>
        public string Root { get; private set; }

        /// <summary>
        ///     Gets the route for SignalR.
        /// </summary>
        public string SignalR { get; private set; }

        /// <summary>
        ///     Gets the route for the Swagger json file.
        /// </summary>
        public string Swagger { get; private set; }

        /// <summary>
        ///     Gets the route for SwaggerUi.
        /// </summary>
        public string SwaggerUi { get; private set; }

        #endregion Public Properties
    }
}