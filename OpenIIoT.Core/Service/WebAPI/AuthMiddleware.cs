using Microsoft.Owin;
using NLog;
using NLog.xLogger;
using System;
using System.Threading.Tasks;

namespace OpenIIoT.Core.Service.WebAPI
{
    public class AuthMiddleware : OwinMiddleware
    {
        #region Private Fields

        /// <summary>
        ///     The main logger for the application.
        /// </summary>
        private static xLogger logger = (xLogger)LogManager.GetCurrentClassLogger(typeof(xLogger));

        #endregion Private Fields

        #region Public Methods

        // http://benfoster.io/blog/how-to-write-owin-middleware-in-5-different-steps
        public AuthMiddleware(OwinMiddleware next)
        : base(next)
        {
        }

        public async override Task Invoke(IOwinContext context)
        {
            PathString apiPath;

            try
            {
                apiPath = new PathString($"/{WebAPIConstants.RoutePrefix}");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            bool api = context.Request.Path.StartsWithSegments(apiPath);

            if (api)
            {
                if (!context.Request.Headers.ContainsKey("X-ApiKey"))
                {
                    logger.Info("MISSING AUTH");
                    context.Response.StatusCode = 401;
                    context.Response.ReasonPhrase = "Get lost";
                    context.Response.Redirect("http://reddit.com");
                    return;
                }
            }

            await Next.Invoke(context);
        }

        #endregion Public Methods
    }
}