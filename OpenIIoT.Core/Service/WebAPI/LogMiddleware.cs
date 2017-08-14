using Microsoft.Owin;
using NLog;
using NLog.xLogger;
using System;
using System.Threading.Tasks;

namespace OpenIIoT.Core.Service.WebAPI
{
    public class LogMiddleware : OwinMiddleware
    {
        #region Private Fields

        /// <summary>
        ///     The main logger for the application.
        /// </summary>
        private static xLogger logger = (xLogger)LogManager.GetCurrentClassLogger(typeof(xLogger));

        #endregion Private Fields

        #region Public Methods

        // http://benfoster.io/blog/how-to-write-owin-middleware-in-5-different-steps
        public LogMiddleware(OwinMiddleware next)
        : base(next)
        {
        }

        public async override Task Invoke(IOwinContext context)
        {
            logger.Info($"Request: {context.Request.Uri}");

            await Next.Invoke(context);

            logger.Info("End Request");
        }

        #endregion Public Methods
    }
}