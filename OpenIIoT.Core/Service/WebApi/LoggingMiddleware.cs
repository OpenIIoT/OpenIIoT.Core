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

using System.Threading.Tasks;
using Microsoft.Owin;
using NLog;
using NLog.xLogger;
using System.Text;
using System;

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

        // http://benfoster.io/blog/how-to-write-owin-middleware-in-5-different-steps
        public LoggingMiddleware(OwinMiddleware next)
        : base(next)
        {
        }

        public async override Task Invoke(IOwinContext context)
        {
            await Next.Invoke(context);

            string line = "[" + (context.Response.StatusCode.ToString() + " " + context.Response.ReasonPhrase).Trim(' ') + "] ";

            line += context.Request.Method + " " + context.Request.Path.Value + " (" + (context.Request.RemoteIpAddress + "/" + GetTruncatedSessionToken(context.Response)).Trim('/') + ")";

            logger.Info(line);
        }

        #endregion Public Methods

        #region Private Methods

        private string GetTruncatedSessionToken(IOwinResponse response)
        {
            string retVal = string.Empty;

            try
            {
                string[] cookieParts = response.Headers["Set-Cookie"].Split('=');

                if (cookieParts[0] == WebApiConstants.SessionTokenCookieName)
                {
                    retVal = cookieParts[1].Split(';')[0].Substring(0, 20) + "...";
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