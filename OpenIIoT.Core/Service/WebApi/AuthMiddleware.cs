/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █     ▄████████                                   ▄▄▄▄███▄▄▄▄
      █     ███    ███                                ▄██▀▀▀███▀▀▀██▄
      █     ███    ███ ██   █      ██      ██   █     ███   ███   ███  █  ██████▄  ██████▄   █          ▄█████  █     █    ▄█████     █████    ▄█████
      █     ███    ███ ██   ██ ▀███████▄   ██   ██    ███   ███   ███ ██  ██   ▀██ ██   ▀██ ██         ██   █  ██     ██   ██   ██   ██  ██   ██   █
      █   ▀███████████ ██   ██     ██  ▀  ▄██▄▄▄██▄▄  ███   ███   ███ ██▌ ██    ██ ██    ██ ██        ▄██▄▄    ██     ██   ██   ██  ▄██▄▄█▀  ▄██▄▄
      █     ███    ███ ██   ██     ██    ▀▀██▀▀▀██▀   ███   ███   ███ ██  ██    ██ ██    ██ ██       ▀▀██▀▀    ██     ██ ▀████████ ▀███████ ▀▀██▀▀
      █     ███    ███ ██   ██     ██      ██   ██    ███   ███   ███ ██  ██   ▄██ ██   ▄██ ██▌    ▄   ██   █  ██ ▄█▄ ██   ██   ██   ██  ██   ██   █
      █     ███    █▀  ██████     ▄██▀     ██   ██     ▀█   ███   █▀  █   ██████▀  ██████▀  ████▄▄██   ███████  ███▀███    ██   █▀   ██  ██   ███████
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

using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin;
using NLog;
using NLog.xLogger;
using OpenIIoT.SDK;
using OpenIIoT.SDK.Security;

namespace OpenIIoT.Core.Service.WebApi
{
    /// <summary>
    ///     Owin Authentication middleware using basic session management provided by <see cref="ISecurityManager"/>.
    /// </summary>
    public class AuthMiddleware : OwinMiddleware
    {
        #region Private Fields

        /// <summary>
        ///     Gets the main logger for this class.
        /// </summary>
        private static xLogger logger = (xLogger)LogManager.GetCurrentClassLogger(typeof(xLogger));

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="AuthMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next middleware in the chain.</param>
        public AuthMiddleware(OwinMiddleware next)
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
            string path = $"{WebApiService.StaticConfiguration.Root}/{WebApiConstants.ApiRoutePrefix}".TrimStart('/').TrimEnd('/');
            path = $"/{path}";

            PathString apiPath = new PathString(path);

            string sessionToken = GetSessionToken(context.Request);

            string help = $"{WebApiService.StaticConfiguration.Root}/{WebApiConstants.HelpRoutePrefix}".TrimStart('/');
            help = $"/{help}";

            string login = $"{WebApiService.StaticConfiguration.Root}/login".TrimStart('/');
            login = $"/{login}";

            logger.Info("Path: " + context.Request.Path.Value);
            if (context.Request.Path.Value.StartsWith(help) || context.Request.Path.Value.StartsWith(login))
            {
                logger.Info("invoking next");
                await Next.Invoke(context);
            }
            else if (sessionToken == default(string))
            {
                context.Response.Redirect("login");
            }
            else
            {
                Session session = SecurityManager.FindSession(sessionToken);

                if (session != default(Session) && !session.IsExpired)
                {
                    context.Request.User = new ClaimsPrincipal(session.Ticket.Identity);
                    SecurityManager.ExtendSession(session);

                    await Next.Invoke(context);
                    context.Response.Cookies.Append("Session-Token", sessionToken);
                }
                else
                {
                    logger.Trace($"Session either not found or expired.");
                    context.Response.Redirect("login");
                }
            }
        }

        #endregion Public Methods

        #region Private Methods

        private string GetSessionToken(IOwinRequest request)
        {
            string retVal;

            if (request.Headers.ContainsKey("X-ApiKey"))
            {
                retVal = request.Headers["X-ApiKey"];
            }
            else
            {
                retVal = request.Cookies["Session-Token"];
            }

            return retVal;
        }

        private bool IsApiPath(IOwinRequest request)
        {
            string path = $"{WebApiService.StaticConfiguration.Root}/{WebApiConstants.ApiRoutePrefix}".TrimStart('/');
            path = $"/{path}";

            PathString apiPath = new PathString(path);
            return request.Path.StartsWithSegments(apiPath);
        }

        #endregion Private Methods
    }
}