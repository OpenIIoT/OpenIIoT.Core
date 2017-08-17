using Microsoft.Owin;
using NLog;
using NLog.xLogger;
using OpenIIoT.Core.Security;
using OpenIIoT.SDK;
using OpenIIoT.SDK.Security;
using System;
using System.Collections.Generic;
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

                    //IReadOnlyList<ClaimsPrincipal> sessions = SecurityManager.Sessions;

                    //foreach (ClaimsPrincipal c in sessions)
                    //{
                    //    if (c.HasClaim(claim => claim.Type == ClaimTypes.Hash))
                    //    {
                    //        string hash = c.Claims.Where(claim => claim.Type == ClaimTypes.Hash).FirstOrDefault().Value;

                    //        if (hash == key)
                    //        {
                    //            context.Request.User = c;
                    //        }
                    //    }
                    //}

                    ClaimsPrincipal principal = SecurityManager.FindSession(key);

                    if (principal != default(ClaimsPrincipal))
                    {
                        context.Request.User = principal;
                    }
                }
            }

            await Next.Invoke(context);
        }

        #endregion Public Methods
    }
}