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

namespace OpenIIoT.Core.Service.WebApi.Middleware
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.Owin;
    using OpenIIoT.SDK;
    using OpenIIoT.SDK.Security;
    using OpenIIoT.SDK.Service.WebApi;
    using Security;

    /// <summary>
    ///     Owin Authentication middleware using basic session management provided by <see cref="ISecurityManager"/>.
    /// </summary>
    public class AuthenticationMiddleware : OwinMiddleware
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="AuthenticationMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next middleware in the chain.</param>
        /// <param name="configuration">The active <see cref="WebApiService"/> configuration.</param>
        public AuthenticationMiddleware(OwinMiddleware next, WebApiServiceConfiguration configuration)
            : base(next)
        {
            Configuration = configuration;
        }

        #endregion Public Constructors

        #region Private Properties

        /// <summary>
        ///     Gets or sets the active configuration for the <see cref="WebApiService"/>.
        /// </summary>
        private WebApiServiceConfiguration Configuration { get; set; }

        /// <summary>
        ///     Gets the <see cref="IApplicationManager"/> instance for the application.
        /// </summary>
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

        /// <summary>
        ///     Determines whether the specified <paramref name="route"/> is among the list of routes configured for anonymous access.
        /// </summary>
        /// <param name="route">The route to examine.</param>
        /// <returns>A value indicating whether the speciifed route is configured for anonymous access.</returns>
        private bool IsAnonymousRoute(PathString route)
        {
            List<PathString> anonymousPaths = WebApiConstants.AnonymousRoutes.Select(r => GetPathString(r)).ToList();

            return anonymousPaths.Any(p => route.StartsWithSegments(p));
        }

        /// <summary>
        ///     Determines whether the specified <paramref name="route"/> is among the list of routes which do not extend the
        ///     active <see cref="Session"/> when accessed.
        /// </summary>
        /// <param name="route">The route to examine.</param>
        /// <returns>A value indicating whether the specified route extends the active <see cref="Session"/> when accessed.</returns>
        private bool IsNonExtendableRoute(PathString route)
        {
            List<PathString> nonExtendablePaths = WebApiConstants.NonExtendableRoutes.Select(r => GetPathString(r)).ToList();
            return nonExtendablePaths.Any(p => route.StartsWithSegments(p));
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        ///     Authenticates the specified <paramref name="context"/>.
        /// </summary>
        /// <remarks>
        ///     The <see cref="Session.Token"/> is initially retrieved from the Api Key header from the request. If the Api Key
        ///     header is null or contains an empty string, the token is then retrieved from the Session Token cookie. If the token
        ///     is present in both the Api Key header and the Session Token cookie, the Api Key header takes precendece.
        /// </remarks>
        /// <param name="context">The <see cref="IOwinContext"/> to authenticate.</param>
        private void Authenticate(IOwinContext context)
        {
            string token = GetApiKey(context.Request);

            if (string.IsNullOrEmpty(token))
            {
                token = GetSessionToken(context.Request);
            }

            ISession session = SecurityManager.FindSession(token);

            if (session != default(Session) && !session.IsExpired)
            {
                context.Request.User = new ClaimsPrincipal(session.Ticket.Identity);

                if (!IsNonExtendableRoute(new PathString(context.Request.Path.Value)))
                {
                    SecurityManager.ExtendSession(session);
                }

                DateTime? expirationDate = ((DateTimeOffset)session.Ticket.ExpiresUtc).UtcDateTime;
                context.Response.Cookies.Append(WebApiConstants.SessionTokenCookieName, token, new CookieOptions() { Expires = expirationDate });
            }
        }

        /// <summary>
        ///     Retrieves the <see cref="Session.Token"/> from the Api Key header of the specified <paramref name="request"/>.
        /// </summary>
        /// <param name="request">The <see cref="IOwinRequest"/> from which to retrieve the Api Key.</param>
        /// <returns>The retrieved Api Key.</returns>
        private string GetApiKey(IOwinRequest request)
        {
            string retVal = default(string);

            if (request.Headers.ContainsKey(WebApiConstants.ApiKeyHeaderName))
            {
                retVal = request.Headers[WebApiConstants.ApiKeyHeaderName];
            }

            return retVal;
        }

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
        ///     Retrieves the <see cref="Session.Token"/> from the specified <paramref name="request"/>.
        /// </summary>
        /// <param name="request">The <see cref="IOwinRequest"/> from which to retrieve the Session Token cookie.</param>
        /// <returns>The <see cref="Session.Token"/>, if present.</returns>
        private string GetSessionToken(IOwinRequest request)
        {
            return request.Cookies[WebApiConstants.SessionTokenCookieName];
        }

        /// <summary>
        ///     Determines whether the specified <paramref name="request"/> is authenticated.
        /// </summary>
        /// <param name="request">The <see cref="IOwinRequest"/> to examine.</param>
        /// <returns>A value indicating whether the request is authenticated.</returns>
        private bool IsAuthenticated(IOwinRequest request)
        {
            return request.User != default(ClaimsPrincipal);
        }

        #endregion Private Methods
    }
}