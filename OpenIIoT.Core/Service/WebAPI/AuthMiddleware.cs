using Microsoft.Owin;
using NLog;
using NLog.xLogger;
using OpenIIoT.SDK;
using OpenIIoT.SDK.Security;
using System;
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
                    ClaimsIdentity identity = new ClaimsIdentity("Basic");
                    identity.AddClaim(new Claim(ClaimTypes.Name, "test"));
                    identity.AddClaim(new Claim(ClaimTypes.Role, "Public"));

                    context.Request.User = new ClaimsPrincipal(identity);
                    //logger.Info("MISSING AUTH");
                    //context.Response.StatusCode = 401;
                    //context.Response.ReasonPhrase = "Get lost";
                    //context.Response.Redirect("http://reddit.com");
                    //return;
                }
                else
                {
                    ClaimsIdentity identity = new ClaimsIdentity("Basic");
                    identity.AddClaim(new Claim(ClaimTypes.Name, "test"));
                    identity.AddClaim(new Claim(ClaimTypes.Role, "Administrator"));

                    context.Request.User = new ClaimsPrincipal(identity);
                }
            }

            await Next.Invoke(context);
        }

        #endregion Public Methods
    }
}