using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using OpenIIoT.Core.Service.WebAPI;
using OpenIIoT.SDK;
using OpenIIoT.SDK.Common;
using System.Security.Claims;
using System;

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

        #endregion Variables

        #region Instance Methods

        [HttpPost]
        [AllowAnonymous]
        [Route("v1/security/login/{user}/{password}")]
        public async Task<HttpResponseMessage> Login(string user, string password)
        {
            string hash = SDK.Common.Utility.ComputeSHA512Hash(Guid.NewGuid().ToString());

            ClaimsIdentity identity = new ClaimsIdentity("Basic");
            identity.AddClaim(new Claim(ClaimTypes.Name, "test"));
            identity.AddClaim(new Claim(ClaimTypes.Role, "Public"));
            identity.AddClaim(new Claim(ClaimTypes.Hash, hash));

            Request.GetOwinContext().Authentication.User = new ClaimsPrincipal(identity);

            return Request.CreateResponse(HttpStatusCode.OK, hash);
        }

        [HttpPost]
        [Authorize]
        [Route("v1/security/logout")]
        public async Task<HttpResponseMessage> Logout()
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        #endregion Instance Methods
    }
}