/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █     ▄████████
      █     ███    ███
      █     ███    ███ ██   █      ██      ██   █       ▄█████ ██▄▄▄▄      ██     █   ▄██████   ▄█████      ██     █   ██████  ██▄▄▄▄
      █     ███    ███ ██   ██ ▀███████▄   ██   ██     ██   █  ██▀▀▀█▄ ▀███████▄ ██  ██    ██   ██   ██ ▀███████▄ ██  ██    ██ ██▀▀▀█▄
      █   ▀███████████ ██   ██     ██  ▀  ▄██▄▄▄██▄▄  ▄██▄▄    ██   ██     ██  ▀ ██▌ ██    ▀    ██   ██     ██  ▀ ██▌ ██    ██ ██   ██
      █     ███    ███ ██   ██     ██    ▀▀██▀▀▀██▀  ▀▀██▀▀    ██   ██     ██    ██  ██    ▄  ▀████████     ██    ██  ██    ██ ██   ██
      █     ███    ███ ██   ██     ██      ██   ██     ██   █  ██   ██     ██    ██  ██    ██   ██   ██     ██    ██  ██    ██ ██   ██
      █     ███    █▀  ██████     ▄██▀     ██   ██     ███████  █   █     ▄██▀   █   ██████▀    ██   █▀    ▄██▀   █    ██████   █   █
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
      █  Owin Authentication middleware using basic session management provided by ISecurityManager.
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
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin;
using NLog;
using NLog.xLogger;
using OpenIIoT.SDK;
using OpenIIoT.SDK.Security;
using System.Net;

namespace OpenIIoT.Core.Service.WebApi.Middleware
{
    /// <summary>
    ///     Owin Authentication middleware using basic session management provided by <see cref="ISecurityManager"/>.
    /// </summary>
    public class AuthenticationMiddleware : OwinMiddleware
    {
        #region Private Fields

        /// <summary>
        ///     Gets the main logger for this class.
        /// </summary>
        private static xLogger logger = (xLogger)LogManager.GetCurrentClassLogger(typeof(xLogger));

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="AuthenticationMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next middleware in the chain.</param>
        public AuthenticationMiddleware(OwinMiddleware next)
            : base(next)
        {
        }

        #endregion Public Constructors

        #region Private Properties

        private IApplicationManager Manager => ApplicationManager.GetInstance();

        /// <summary>
        ///     Gets the ISecurityManager instance for the application.
        /// </summary>
        private ISecurityManager SecurityManager => Manager.GetManager<ISecurityManager>();

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        ///     Retrieves the <see cref="Session"/> associated with the hash provided in the 'X-token' header and sets the
        ///     request's <see cref="OwinRequest.User"/> property to the retrieved <see cref="Session.Ticket"/>.
        /// </summary>
        /// <param name="context">The Owin context for the current request.</param>
        /// <returns>The Task context under which the method is invoked.</returns>
        public async override Task Invoke(IOwinContext context)
        {
            PathString requestPath = new PathString(context.Request.Path.Value);

            Authenticate(context);

            if (IsAnonymousRoute(requestPath))
            {
                await Next.Invoke(context);
            }
            else
            {
                if (IsAuthenticated(context.Request))
                {
                    await Next.Invoke(context);
                }
                else
                {
                    context.Response.Cookies.Append(
                        WebApiConstants.SessionTokenCookieName,
                        string.Empty,
                        new CookieOptions()
                        {
                            Expires = DateTime.UtcNow.AddYears(-1),
                        });

                    string redirect = $"{GetPathString(WebApiConstants.LoginRoutePrefix).Value}?{context.Request.Path.Value}{context.Request.QueryString}";
                    context.Response.Redirect(redirect);
                }
            }
        }

        private bool IsAnonymousRoute(PathString route)
        {
            List<PathString> anonymousPaths = WebApiConstants.AnonymousRoutes.Select(r => GetPathString(r)).ToList();

            return anonymousPaths.Any(p => route.StartsWithSegments(p));
        }

        #endregion Public Methods

        #region Private Methods

        private void Authenticate(IOwinContext context)
        {
            string token = GetApiKey(context.Request);

            if (token == string.Empty)
            {
                token = GetSessionToken(context.Request);
            }

            Session session = SecurityManager.FindSession(token);

            if (session != default(Session) && !session.IsExpired)
            {
                context.Request.User = new ClaimsPrincipal(session.Ticket.Identity);
                SecurityManager.ExtendSession(session);

                DateTime? expirationDate = ((DateTimeOffset)session.Ticket.Properties.ExpiresUtc).UtcDateTime;
                context.Response.Cookies.Append(WebApiConstants.SessionTokenCookieName, token, new CookieOptions() { Expires = expirationDate });
            }
        }

        private string GetApiKey(IOwinRequest request)
        {
            string retVal = string.Empty;

            if (request.Headers.ContainsKey(WebApiConstants.ApiKeyHeaderName))
            {
                retVal = request.Headers[WebApiConstants.ApiKeyHeaderName];
            }

            return retVal;
        }

        private PathString GetPathString(string path)
        {
            return new PathString("/" + (WebApiService.StaticConfiguration.Root + "/" + path).Trim('/'));
        }

        private string GetSessionToken(IOwinRequest request)
        {
            return request.Cookies[WebApiConstants.SessionTokenCookieName];
        }

        private bool IsAuthenticated(IOwinRequest request)
        {
            return request.User != default(ClaimsPrincipal);
        }

        #endregion Private Methods
    }
}