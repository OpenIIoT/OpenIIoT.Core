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

namespace OpenIIoT.Core.Service.WebApi.Middleware
{
    using System;
    using System.Diagnostics;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Owin;
    using NLog.xLogger;
    using OpenIIoT.SDK.Service.WebApi;

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

        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="LoggingMiddleware"/> class.
        /// </summary>
        /// <param name="next">The middlware component which follows.</param>
        /// <param name="configuration">The active configuration for the <see cref="WebApiService"/>.</param>
        public LoggingMiddleware(OwinMiddleware next, WebApiServiceConfiguration configuration)
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

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        ///     Invokes the middleware function and transfers execution to the next middleware component.
        /// </summary>
        /// <param name="context">The context within which the middleware is to execute</param>
        /// <returns>The result of the asynchronous middleware function.</returns>
        public async override Task Invoke(IOwinContext context)
        {
            Stopwatch benchmark = new Stopwatch();
            benchmark.Start();

            await Next.Invoke(context);

            benchmark.Stop();

            if (logger.IsInfoEnabled)
            {
                string logString = GetLogString(context, benchmark.Elapsed);
                PathString apiPathString = new PathString("/" + (Configuration.Root + "/" + WebApiConstants.ApiRoutePrefix).Trim('/'));

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
        ///     Returns the specified <paramref name="value"/> formatted as a binary size representation, with suffix.
        /// </summary>
        /// <param name="value">The value to format.</param>
        /// <param name="decimalPlaces">The number of decimal places to which the value is to be rounded.</param>
        /// <returns>The specified value with the size suffix appended.</returns>
        private string GetFormattedSize(double value, int decimalPlaces = 1)
        {
            string[] sizeSuffixes = { "bytes", "KB", "MB", "GB" };

            if (value <= 0)
            {
                return "0 bytes";
            }

            int mag = (int)Math.Log(value, 1024);
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

            if (Math.Round(adjustedSize, decimalPlaces) >= 1000)
            {
                mag += 1;
                adjustedSize /= 1024;
            }

            return string.Format(
                "{0:n" + decimalPlaces + "} {1}",
                adjustedSize,
                sizeSuffixes[mag]);
        }

        /// <summary>
        ///     Constructs the logger string for the specified <paramref name="context"/>.
        /// </summary>
        /// <param name="context">The context from which the log information is retrieved.</param>
        /// <param name="duration">The duration of the span between the request and response.</param>
        /// <returns>The constructed logger string.</returns>
        private string GetLogString(IOwinContext context, TimeSpan duration)
        {
            StringBuilder message = new StringBuilder();

            message.Append("[" + (context.Response.StatusCode.ToString() + " " + context.Response.ReasonPhrase).Trim(' ') + "] ");
            message.Append(context.Request.Method + " ");
            message.Append(context.Request.Path.Value);
            message.Append(" (" + (context.Request.RemoteIpAddress + "/" + GetTruncatedSessionToken(context.Response, 20)).Trim('/') + ") ");
            message.Append(GetFormattedSize((double)(context.Response.ContentLength ?? 0), 2) + ", " + duration.TotalMilliseconds + "ms");

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