using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using OpenIIoT.Core.Service.WebAPI;
using OpenIIoT.SDK;
using OpenIIoT.SDK.Common;
using System.Security.Claims;
using System;
using System.Linq;
using Utility.OperationResult;
using System.Collections.Generic;

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
        [Route("v1/security/users")]
        public async Task<HttpResponseMessage> GetUsers()
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("v1/security/login/{user}/{password}")]
        public async Task<HttpResponseMessage> Login(string user, string password)
        {
            IResult<KeyValuePair<string, ClaimsPrincipal>> retVal = SecurityManager.StartSession(user, password);

            return Request.CreateResponse(HttpStatusCode.OK, retVal.ReturnValue.Key);
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