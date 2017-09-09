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

namespace OpenIIoT.Core.Service.WebApi
{
    /// <summary>
    ///     Owin middleeware for HTTP request and response logging.
    /// </summary>
    public class LoggingMiddleware : OwinMiddleware
    {
        #region Private Fields

        /// <summary>
        ///     The Logger for this class.
        /// </summary>
        private static xLogger logger = xLogManager.GetCurrentClassxLogger();

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        ///     Initializes a new instance of the <see cref="LoggingMiddleware"/> class.
        /// </summary>
        /// <param name="next">The middlware component which follows.</param>
        public LoggingMiddleware(OwinMiddleware next)
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

            if (logger.IsInfoEnabled)
            {
                string logString = GetLogString(context);
                PathString apiPathString = new PathString("/" + (WebApiService.StaticConfiguration.Root + "/" + WebApiConstants.ApiRoutePrefix).Trim('/'));

                if (context.Request.Path.StartsWithSegments(apiPathString))
                {
                    logger.Info(logString);
                }
                else if (logger.IsDebugEnabled)
                {
                    logger.Debug(logString);
                }
            }
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        ///     Constructs the logger string for the specified <paramref name="context"/>.
        /// </summary>
        /// <param name="context">The context from which the log information is retrieved.</param>
        /// <returns>The constructed logger string.</returns>
        private string GetLogString(IOwinContext context)
        {
            StringBuilder message = new StringBuilder();

            message.Append("[" + (context.Response.StatusCode.ToString() + " " + context.Response.ReasonPhrase).Trim(' ') + "] ");
            message.Append(context.Request.Method + " ");
            message.Append(context.Request.Path.Value);
            message.Append(" (" + (context.Request.RemoteIpAddress + "/" + GetTruncatedSessionToken(context.Response, 20)).Trim('/') + ")");

            return message.ToString();
        }

        /// <summary>
        ///     Retrieves the Session token from the response and, if present, truncates it to a fixed number of characters.
        /// </summary>
        /// <param name="response">The request from which to retrieve the Session token.</param>
        /// <param name="characterCount">The number of characters to which the Session token is to be truncated.</param>
        /// <returns>The truncated Session token, if present.</returns>
        private string GetTruncatedSessionToken(IOwinResponse response, int characterCount)
        {
            string retVal = string.Empty;

            try
            {
                string[] cookieParts = response.Headers["Set-Cookie"].Split('=');

                if (cookieParts[0] == WebApiConstants.SessionTokenCookieName)
                {
                    retVal = cookieParts[1].Split(';')[0].Substring(0, characterCount) + "...";
                }
            }
            catch (Exception)
            {
            }

            return retVal;
        }

        #endregion Private Methods
    }
}