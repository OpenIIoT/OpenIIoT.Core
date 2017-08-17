using Microsoft.Owin;
using NLog;
using NLog.xLogger;
using OpenIIoT.SDK;
using OpenIIoT.SDK.Security;
using System;
using System.Linq;
using System.Security.Claims;
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

        private ISecurityManager SecurityManager => ApplicationManager.GetInstance().GetManager<ISecurityManager>();

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

            apiPath = new PathString($"/{WebAPIConstants.RoutePrefix}");
            bool api = context.Request.Path.StartsWithSegments(apiPath);

            if (api)
            {
                if (context.Request.Headers.ContainsKey("X-ApiKey"))
                {
                    string key = context.Request.Headers["X-ApiKey"];

                    ClaimsPrincipal principal = SecurityManager.Sessions.Where(s => s.Claims.Where(c => c.Type == ClaimTypes.Hash).FirstOrDefault().Value == key).FirstOrDefault();

                    if (principal != default(ClaimsPrincipal))
                    {
                        context.Request.User = new ClaimsPrincipal(principal);
                    }
                }
            }

            await Next.Invoke(context);
        }

        #endregion Public Methods
    }
}