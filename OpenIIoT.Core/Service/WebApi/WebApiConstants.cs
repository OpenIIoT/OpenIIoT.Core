/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █    ▄█     █▄                        ▄████████
      █   ███     ███                       ███    ███
      █   ███     ███    ▄█████ ▀██████▄    ███    ███    █████▄  █
      █   ███     ███   ██   █    ██   ██   ███    ███   ██   ██ ██
      █   ███     ███  ▄██▄▄     ▄██▄▄█▀  ▀███████████   ██   ██ ██▌
      █   ███     ███ ▀▀██▀▀    ▀▀██▀▀█▄    ███    ███ ▀██████▀  ██
      █   ███ ▄█▄ ███   ██   █    ██   ██   ███    ███   ██      ██
      █    ▀███▀███▀    ███████ ▄██████▀    ███    █▀   ▄███▀    █
      █
      █   ▄████████
      █   ███    ███
      █   ███    █▀   ██████  ██▄▄▄▄    ▄█████     ██      ▄█████  ██▄▄▄▄      ██      ▄█████
      █   ███        ██    ██ ██▀▀▀█▄   ██  ▀  ▀███████▄   ██   ██ ██▀▀▀█▄ ▀███████▄   ██  ▀
      █   ███        ██    ██ ██   ██   ██         ██  ▀   ██   ██ ██   ██     ██  ▀   ██
      █   ███    █▄  ██    ██ ██   ██ ▀███████     ██    ▀████████ ██   ██     ██    ▀███████
      █   ███    ███ ██    ██ ██   ██    ▄  ██     ██      ██   ██ ██   ██     ██       ▄  ██
      █   ████████▀   ██████   █   █   ▄████▀     ▄██▀     ██   █▀  █   █     ▄██▀    ▄████▀
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Constant values for the WebApi namespace.
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
    /// <summary>
    ///     Constant values for the <see cref="WebApi"/> namespace.
    /// </summary>
    public static class WebApiConstants
    {
        #region Public Fields

        /// <summary>
        ///     The name of the HTTP header containing the Api Key.
        /// </summary>
        public const string ApiKeyHeaderName = "X-ApiKey";

        /// <summary>
        ///     The route prefix for Api routes.
        /// </summary>
        public const string ApiRoutePrefix = "api";

        /// <summary>
        ///     The path to static assets.
        /// </summary>
        public const string AssetPath = "assets";

        /// <summary>
        ///     The route prefix for Api help/swagger.
        /// </summary>
        public const string HelpRoutePrefix = "help";

        /// <summary>
        ///     The route prefix for the login directory.
        /// </summary>
        public const string LoginRoutePrefix = "login";

        /// <summary>
        ///     The route prefix for Node modules.
        /// </summary>
        public const string ModulePath = "node_modules";

        /// <summary>
        ///     The route prefix for the 404 directory.
        /// </summary>
        public const string NotFoundRoutePrefix = "404";

        /// <summary>
        ///     The name of the cookie used to store the <see cref="SDK.Security.Session.Token"/>.
        /// </summary>
        public const string SessionTokenCookieName = "Session-Token";

        /// <summary>
        ///     The route prefix for SignalR.
        /// </summary>
        public const string SignalRRoutePrefix = "signalr";

        /// <summary>
        ///     The list of routes for which authentication is not required.
        /// </summary>
        public static readonly string[] AnonymousRoutes = { ApiRoutePrefix, SignalRRoutePrefix, HelpRoutePrefix, LoginRoutePrefix, NotFoundRoutePrefix, AssetPath, ModulePath };

        /// <summary>
        ///     The list of routes for which the <see cref="SDK.Security.Session"/> will not be extended, regardless of configuration.
        /// </summary>
        public static readonly string[] NonExtendableRoutes = { "api/v1/info" };

        /// <summary>
        ///     The list of routes which will not be redirected upon a 404 or <see cref="SDK.Security.Session"/> error.
        /// </summary>
        public static readonly string[] RedirectSuppressedRoutes = { ApiRoutePrefix, SignalRRoutePrefix, HelpRoutePrefix, LoginRoutePrefix, NotFoundRoutePrefix, AssetPath, ModulePath };

        #endregion Public Fields
    }
}