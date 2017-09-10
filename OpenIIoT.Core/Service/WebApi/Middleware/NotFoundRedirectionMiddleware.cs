/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █    ▄█
      █   ███
      █   ███        ██████     ▄████▄     ▄████▄   █  ██▄▄▄▄     ▄████▄
      █   ███       ██    ██   ██    ▀    ██    ▀  ██  ██▀▀▀█▄   ██    ▀
      █   ███       ██    ██  ▄██        ▄██       ██▌ ██   ██  ▄██
      █   ███       ██    ██ ▀▀██ ███▄  ▀▀██ ███▄  ██  ██   ██ ▀▀██ ███▄
      █   ███▌    ▄ ██    ██   ██    ██   ██    ██ ██  ██   ██   ██    ██
      █   █████▄▄██  ██████    ██████▀    ██████▀  █    █   █    ██████▀
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
      █  Owin middleeware for HTTP request and response logging.
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

using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;
using NLog.xLogger;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace OpenIIoT.Core.Service.WebApi
{
    /// <summary>
    ///     Owin middleware for 404 redirection.
    /// </summary>
    public class NotFoundRedirectionMiddleware : OwinMiddleware
    {
        #region Private Fields

        /// <summary>
        ///     The Logger for this class.
        /// </summary>
        private static xLogger logger = xLogManager.GetCurrentClassxLogger();

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        ///     Initializes a new instance of the <see cref="NotFoundRedirectionMiddleware"/> class.
        /// </summary>
        /// <param name="next">The middlware component which follows.</param>
        public NotFoundRedirectionMiddleware(OwinMiddleware next)
        : base(next)
        {
        }

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

        private PathString GetPathString(string path)
        {
            return new PathString("/" + (WebApiService.StaticConfiguration.Root + "/" + path).Trim('/'));
        }

        private bool IsRedirectSuppressedRoute(PathString route)
        {
            List<PathString> redirectSuppressedPaths = WebApiConstants.RedirectSuppressedRoutes.Select(r => GetPathString(r)).ToList();

            return redirectSuppressedPaths.Any(p => route.StartsWithSegments(p));
        }

        #endregion Private Methods
    }
}