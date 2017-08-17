using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using OpenIIoT.Core.Service.WebAPI;
using OpenIIoT.SDK;
using OpenIIoT.SDK.Common;
using System.Security.Claims;
using System;
using OpenIIoT.SDK.Security;
using System.Linq;

namespace OpenIIoT.Core.Security.WebAPI
{
    /// <summary>
    ///     API methods for application security.
    /// </summary>
    [Authorize]
    [RoutePrefix(WebAPIConstants.RoutePrefix)]
    public class SecurityController : ApiBaseController
    {
        #region Variables

        /// <summary>
        ///     The ApplicationManager for the application.
        /// </summary>
        private IApplicationManager manager = ApplicationManager.GetInstance();

        private ISecurityManager SecurityManager => manager.GetManager<ISecurityManager>();

        #endregion Variables

        #region Instance Methods

        [HttpGet]
        [Authorize]
        [Route("v1/security/sessions")]
        public async Task<HttpResponseMessage> GetSessions()
        {
            return Request.CreateResponse(HttpStatusCode.OK, SecurityManager.Sessions);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("v1/security/login/{user}/{password}")]
        public async Task<HttpResponseMessage> Login(string user, string password)
        {
            string hash = SDK.Common.Utility.ComputeSHA512Hash(Guid.NewGuid().ToString());

            ClaimsIdentity identity = new ClaimsIdentity("Basic");
            identity.AddClaim(new Claim(ClaimTypes.Name, "test"));

            identity.AddClaim(new Claim(ClaimTypes.Role, "Administrator"));
            identity.AddClaim(new Claim(ClaimTypes.Hash, hash));

            manager.GetManager<ISecurityManager>().StartSession(new ClaimsPrincipal(identity));

            return Request.CreateResponse(HttpStatusCode.OK, hash);
        }

        [HttpPost]
        [Authorize]
        [Route("v1/security/logout")]
        public async Task<HttpResponseMessage> Logout()
        {
            ClaimsPrincipal principal = Request.GetOwinContext().Authentication.User;

            SecurityManager.EndSession(principal);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        #endregion Instance Methods
    }
}