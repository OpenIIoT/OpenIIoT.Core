/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄████████
      █     ███    ███
      █     ███    █▀     ▄█████  ▄██████ ██   █     █████  █      ██    ▄█   ▄
      █     ███          ██   █  ██    ██ ██   ██   ██  ██ ██  ▀███████▄ ██   █▄
      █   ▀███████████  ▄██▄▄    ██    ▀  ██   ██  ▄██▄▄█▀ ██▌     ██  ▀ ▀▀▀▀▀██
      █            ███ ▀▀██▀▀    ██    ▄  ██   ██ ▀███████ ██      ██    ▄█   ██
      █      ▄█    ███   ██   █  ██    ██ ██   ██   ██  ██ ██      ██    ██   ██
      █    ▄████████▀    ███████ ██████▀  ██████    ██  ██ █      ▄██▀    █████
      █
      █   ▄████████
      █   ███    ███
      █   ███    █▀   ██████  ██▄▄▄▄      ██       █████  ██████   █        █          ▄█████    █████
      █   ███        ██    ██ ██▀▀▀█▄ ▀███████▄   ██  ██ ██    ██ ██       ██         ██   █    ██  ██
      █   ███        ██    ██ ██   ██     ██  ▀  ▄██▄▄█▀ ██    ██ ██       ██        ▄██▄▄     ▄██▄▄█▀
      █   ███    █▄  ██    ██ ██   ██     ██    ▀███████ ██    ██ ██       ██       ▀▀██▀▀    ▀███████
      █   ███    ███ ██    ██ ██   ██     ██      ██  ██ ██    ██ ██▌    ▄ ██▌    ▄   ██   █    ██  ██
      █   ████████▀   ██████   █   █     ▄██▀     ██  ██  ██████  ████▄▄██ ████▄▄██   ███████   ██  ██
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  WebAPI Controller for the Security namespace.
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

using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using OpenIIoT.Core.Service.WebAPI;
using OpenIIoT.SDK;
using OpenIIoT.SDK.Common;
using Utility.OperationResult;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;

namespace OpenIIoT.Core.Security.WebAPI
{
    /// <summary>
    ///     WebAPI Controller for the Security namespace.
    /// </summary>
    [Authorize]
    [RoutePrefix(WebAPIConstants.RoutePrefix)]
    public class SecurityController : ApiBaseController
    {
        #region Variables

        /// <summary>
        ///     Gets the IApplicationManager for the application.
        /// </summary>
        private IApplicationManager Manager => ApplicationManager.GetInstance();

        /// <summary>
        ///     Gets the ISecurityManager for the application.
        /// </summary>
        private ISecurityManager SecurityManager => Manager.GetManager<ISecurityManager>();

        #endregion Variables

        #region Instance Methods

        /// <summary>
        ///     Creates a new User.
        /// </summary>
        /// <param name="name">The name of the new User.</param>
        /// <param name="password">The plaintext password for the new User.</param>
        /// <param name="role">The Role for the new User.</param>
        /// <returns>An HTTP response message.</returns>
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [Route("v1/security/user")]
        [SwaggerResponse(HttpStatusCode.OK, "The User was created.", typeof(User))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "One or more parameters are invalid.", typeof(string))]
        [SwaggerResponse(HttpStatusCode.Conflict, "The specified User already exists.")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "An unexpected error was encountered during the operation.", typeof(Result))]
        public HttpResponseMessage CreateUser(string name, string password, Role role)
        {
            HttpResponseMessage retVal;

            if (string.IsNullOrEmpty(name))
            {
                retVal = Request.CreateResponse(HttpStatusCode.BadRequest, "The specified name is null or empty.");
            }
            else if (string.IsNullOrEmpty(password))
            {
                retVal = Request.CreateResponse(HttpStatusCode.BadRequest, "The specified password is null or empty.");
            }
            else if (role == Role.NotSpecified)
            {
                retVal = Request.CreateResponse(HttpStatusCode.BadRequest, "The User Role may not be 'NotSpecified'.");
            }
            else
            {
                User user = SecurityManager.FindUser(name);

                if (user == default(User))
                {
                    IResult<User> createResult = SecurityManager.CreateUser(name, password, role);

                    if (createResult.ResultCode != ResultCode.Failure)
                    {
                        retVal = Request.CreateResponse(HttpStatusCode.OK, createResult.ReturnValue, JsonFormatter(ContractResolverType.OptOut, "PasswordHash"));
                    }
                    else
                    {
                        Result result = (Result)createResult;
                        retVal = Request.CreateResponse(HttpStatusCode.InternalServerError, result, JsonFormatter());
                    }
                }
                else
                {
                    retVal = Request.CreateResponse(HttpStatusCode.Conflict, "The specified User already exists.");
                }
            }

            return retVal;
        }

        /// <summary>
        ///     Deletes the specified User.
        /// </summary>
        /// <param name="name">The name of the User to delete.</param>
        /// <returns>An HTTP response message.</returns>
        [HttpDelete]
        [Authorize(Roles = "Administrator")]
        [Route("v1/security/user/{name}")]
        [SwaggerResponse(HttpStatusCode.OK, "The User was deleted.")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "One or more parameters are invalid.", typeof(string))]
        [SwaggerResponse(HttpStatusCode.NotFound, "The specified User does not exist.")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "An unexpected error was encountered during the operation.", typeof(Result))]
        public HttpResponseMessage DeleteUser(string name)
        {
            HttpResponseMessage retVal;

            if (string.IsNullOrEmpty(name))
            {
                retVal = Request.CreateResponse(HttpStatusCode.BadRequest, "The specified name is null or empty.");
            }
            else
            {
                User user = SecurityManager.FindUser(name);

                if (user != default(User))
                {
                    IResult deleteResult = SecurityManager.DeleteUser(user.Name);

                    if (deleteResult.ResultCode != ResultCode.Failure)
                    {
                        retVal = Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        retVal = Request.CreateResponse(HttpStatusCode.InternalServerError, deleteResult, JsonFormatter());
                    }
                }
                else
                {
                    retVal = Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }

            return retVal;
        }

        /// <summary>
        ///     Gets the list of built-in User Roles.
        /// </summary>
        /// <returns>An HTTP response message.</returns>
        [HttpGet]
        [Authorize]
        [Route("v1/security/role")]
        [SwaggerResponse(HttpStatusCode.OK, "The list was retrieved successfully.", typeof(IReadOnlyList<Role>))]
        public HttpResponseMessage GetRoles()
        {
            return Request.CreateResponse(HttpStatusCode.OK, SecurityManager.Roles, JsonFormatter());
        }

        /// <summary>
        ///     Gets the list of active Sessions.
        /// </summary>
        /// <returns>An HTTP response message.</returns>
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        [Route("v1/security/session")]
        [SwaggerResponse(HttpStatusCode.OK, "The list was retrieved successfully.", typeof(IReadOnlyList<Session>))]
        public HttpResponseMessage GetSessions()
        {
            return Request.CreateResponse(HttpStatusCode.OK, SecurityManager.Sessions, JsonFormatter(ContractResolverType.OptOut, "Subject"));
        }

        /// <summary>
        ///     Gets the list of configured Users.
        /// </summary>
        /// <returns>An HTTP response message.</returns>
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        [Route("v1/security/user")]
        [SwaggerResponse(HttpStatusCode.OK, "The list was retrieved successfully.", typeof(IReadOnlyList<User>))]
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
            string apiKey = Request.GetOwinContext().Authentication.User.Claims.Where(c => c.Type == ClaimTypes.Hash).FirstOrDefault().Value;

            if (!string.IsNullOrEmpty(apiKey))
            {
                Session session = SecurityManager.FindSession(apiKey);

                SecurityManager.EndSession(session);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("v1/security/user/{name}")]
        public HttpResponseMessage UpdateUser(string name, string password = null, Role role = Role.NotSpecified)
        {
            User user = SecurityManager.FindUser(name);

            if (user != default(User))
            {
                IResult<User> updateResult = SecurityManager.UpdateUser(user.Name, password, role);

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