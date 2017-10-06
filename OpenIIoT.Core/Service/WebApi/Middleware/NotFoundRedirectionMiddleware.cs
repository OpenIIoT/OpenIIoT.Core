/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █   ███▄▄▄▄                         ▄████████                                      ▄████████
      █   ███▀▀▀██▄                      ███    ███                                     ███    ███
      █   ███   ███  ██████      ██      ███    █▀   ██████  ██   █  ██▄▄▄▄  ██████▄   ▄███▄▄▄▄██▀    ▄█████ ██████▄   █     █████    ▄█████  ▄██████     ██     █   ██████  ██▄▄▄▄
      █   ███   ███ ██    ██ ▀███████▄  ▄███▄▄▄     ██    ██ ██   ██ ██▀▀▀█▄ ██   ▀██ ▀▀███▀▀▀▀▀     ██   █  ██   ▀██ ██    ██  ██   ██   █  ██    ██ ▀███████▄ ██  ██    ██ ██▀▀▀█▄
      █   ███   ███ ██    ██     ██  ▀ ▀▀███▀▀▀     ██    ██ ██   ██ ██   ██ ██    ██ ▀███████████  ▄██▄▄    ██    ██ ██▌  ▄██▄▄█▀  ▄██▄▄    ██    ▀      ██  ▀ ██▌ ██    ██ ██   ██
      █   ███   ███ ██    ██     ██      ███        ██    ██ ██   ██ ██   ██ ██    ██   ███    ███ ▀▀██▀▀    ██    ██ ██  ▀███████ ▀▀██▀▀    ██    ▄      ██    ██  ██    ██ ██   ██
      █   ███   ███ ██    ██     ██      ███        ██    ██ ██   ██ ██   ██ ██   ▄██   ███    ███   ██   █  ██   ▄██ ██    ██  ██   ██   █  ██    ██     ██    ██  ██    ██ ██   ██
      █    ▀█   █▀   ██████     ▄██▀     ███         ██████  ██████   █   █  ██████▀    ███    ███   ███████ ██████▀  █     ██  ██   ███████ ██████▀     ▄██▀   █    ██████   █   █
      █
      █      ▄▄▄▄███▄▄▄▄
      █    ▄██▀▀▀███▀▀▀██▄
      █    ███   ███   ███  █  ██████▄  ██████▄   █          ▄█████  █     █    ▄█████     █████    ▄█████
      █    ███   ███   ███ ██  ██   ▀██ ██   ▀██ ██         ██   █  ██     ██   ██   ██   ██  ██   ██   █
      █    ███   ███   ███ ██▌ ██    ██ ██    ██ ██        ▄██▄▄    ██     ██   ██   ██  ▄██▄▄█▀  ▄██▄▄
      █    ███   ███   ███ ██  ██    ██ ██    ██ ██       ▀▀██▀▀    ██     ██ ▀████████ ▀███████ ▀▀██▀▀
      █    ███   ███   ███ ██  ██   ▄██ ██   ▄██ ██▌    ▄   ██   █  ██ ▄█▄ ██   ██   ██   ██  ██   ██   █
      █     ▀█   ███   █▀  █   ██████▀  ██████▀  ████▄▄██   ███████  ███▀███    ██   █▀   ██  ██   ███████
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Owin middleware for redirection of 404/Not Found responses.
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
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Owin;

    /// <summary>
    ///     Owin middleware for 404 redirection.
    /// </summary>
    public class NotFoundRedirectionMiddleware : OwinMiddleware
    {
        #region Public Methods

        /// <summary>
        ///     Initializes a new instance of the <see cref="NotFoundRedirectionMiddleware"/> class.
        /// </summary>
        /// <param name="next">The middlware component which follows.</param>
        /// <param name="configuration">The active configuration for the <see cref="WebApiService"/>.</param>
        public NotFoundRedirectionMiddleware(OwinMiddleware next, WebApiServiceConfiguration configuration)
        : base(next)
        {
            Configuration = configuration;
        }

        /// <summary>
        ///     Gets or sets the active configuration for the <see cref="WebApiService"/>.
        /// </summary>
        private WebApiServiceConfiguration Configuration { get; set; }

        /// <summary>
        ///     Invokes the middleware function and transfers execution to the next middleware component.
        /// </summary>
        /// <param name="context">The context within which the middleware is to execute</param>
        /// <returns>The result of the asynchronous middleware function.</returns>
        public async override Task Invoke(IOwinContext context)
        {
            await Next.Invoke(context);

            if (context.Response.StatusCode == 404 && !IsRedirectSuppressedRoute(new PathString(context.Request.Path.Value)))
            {
                context.Response.Redirect(GetPathString(WebApiConstants.NotFoundRoutePrefix).Value);
            }
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        ///     Builds and returns a <see cref="PathString"/> from the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="path">The path from which the <see cref="PathString"/> is to be built.</param>
        /// <returns>The built <see cref="PathString"/>.</returns>
        private PathString GetPathString(string path)
        {
            return new PathString("/" + (Configuration.Root + "/" + path).Trim('/'));
        }

        /// <summary>
        ///     Determines whether the specified <paramref name="route"/> is among the list of routes for which 404 redirection is suppressed.
        /// </summary>
        /// <param name="route">The route to examine.</param>
        /// <returns>A value indicating whether 404 redirection is suppressed for the route.</returns>
        private bool IsRedirectSuppressedRoute(PathString route)
        {
            List<PathString> redirectSuppressedPaths = WebApiConstants.RedirectSuppressedRoutes.Select(r => GetPathString(r)).ToList();

            return redirectSuppressedPaths.Any(p => route.StartsWithSegments(p));
        }

        #endregion Private Methods
    }
}