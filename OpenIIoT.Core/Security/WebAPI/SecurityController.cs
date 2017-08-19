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

        [HttpPost]
        [Authorize]
        [Route("v1/security/user")]
        public HttpResponseMessage CreateUser(string name, string password, Role role)
        {
            User user = SecurityManager.FindUser(name);

            if (user == default(User))
            {
                IResult<User> createResult = SecurityManager.CreateUser(name, password, role);

                if (createResult.ResultCode != ResultCode.Failure)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, createResult.ReturnValue, JsonFormatter());
                }
                else
                {
                    Result result = (Result)createResult;
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, result, JsonFormatter());
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [HttpDelete]
        [Authorize]
        [Route("v1/security/user/{nane}")]
        public HttpResponseMessage DeleteUser(string name)
        {
            User user = SecurityManager.FindUser(name);

            if (user != default(User))
            {
                IResult deleteResult = SecurityManager.DeleteUser(user);

                if (deleteResult.ResultCode != ResultCode.Failure)
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, deleteResult, JsonFormatter());
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("v1/security/role")]
        public HttpResponseMessage GetRoles()
        {
            return Request.CreateResponse(HttpStatusCode.OK, SecurityManager.Roles, JsonFormatter());
        }

        [HttpGet]
        [Authorize]
        [Route("v1/security/user")]
        public HttpResponseMessage GetUsers()
        {
            return Request.CreateResponse(HttpStatusCode.OK, SecurityManager.Users, JsonFormatter(ContractResolverType.OptOut, "PasswordHash"));
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("v1/security/login")]
        public HttpResponseMessage Login(string user, string password)
        {
            IResult<Session> retVal = SecurityManager.StartSession(user, password);

            return Request.CreateResponse(HttpStatusCode.OK, retVal.ReturnValue.ApiKey, JsonFormatter());
        }

        [HttpPost]
        [Authorize]
        [Route("v1/security/logout")]
        public HttpResponseMessage Logout()
        {
            ClaimsPrincipal principal = Request.GetOwinContext().Authentication.User;
            Session session = SecurityManager.FindSession(principal);

            SecurityManager.EndSession(session);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPut]
        [Authorize]
        [Route("v1/security/user/{name}")]
        public HttpResponseMessage UpdateUser(string name, string password = null, Role role = Role.NotSpecified)
        {
            User user = SecurityManager.FindUser(name);

            if (user != default(User))
            {
                IResult<User> updateResult = SecurityManager.UpdateUser(user, password, role);

                if (updateResult.ResultCode != ResultCode.Failure)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, updateResult, JsonFormatter(ContractResolverType.OptOut, "PasswordHash"));
                }
                else
                {
                    Result result = (Result)updateResult;
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, updateResult, JsonFormatter());
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        #endregion Instance Methods
    }
}