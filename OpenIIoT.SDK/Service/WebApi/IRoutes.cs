/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █    ▄█     ▄████████
      █   ███    ███    ███
      █   ███▌  ▄███▄▄▄▄██▀  ██████  ██   █      ██       ▄█████   ▄█████
      █   ███▌ ▀▀███▀▀▀▀▀   ██    ██ ██   ██ ▀███████▄   ██   █    ██  ▀
      █   ███▌ ▀███████████ ██    ██ ██   ██     ██  ▀  ▄██▄▄      ██
      █   ███    ███    ███ ██    ██ ██   ██     ██    ▀▀██▀▀    ▀███████
      █   ███    ███    ███ ██    ██ ██   ██     ██      ██   █     ▄  ██
      █   █▀     ███    ███  ██████  ██████     ▄██▀     ███████  ▄████▀
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

namespace OpenIIoT.SDK.Service.WebApi
{
    /// <summary>
    ///     Web Routes for the <see cref="IWebApiService"/>.
    /// </summary>
    public interface IRoutes
    {
        #region Public Properties

        /// <summary>
        ///     Gets the base route for Api endpoints.
        /// </summary>
        string Api { get; }

        /// <summary>
        ///     Gets the user-friendly route for SwaggerUi.
        /// </summary>
        string Help { get; }

        /// <summary>
        ///     Gets the base route for Swagger components.
        /// </summary>
        string HelpRoot { get; }

        /// <summary>
        ///     Gets the user-defined web root.
        /// </summary>
        string Root { get; }

        /// <summary>
        ///     Gets the route for SignalR.
        /// </summary>
        string SignalR { get; }

        /// <summary>
        ///     Gets the route for the Swagger json file.
        /// </summary>
        string Swagger { get; }

        /// <summary>
        ///     Gets the route for SwaggerUi.
        /// </summary>
        string SwaggerUi { get; }

        #endregion Public Properties
    }
}