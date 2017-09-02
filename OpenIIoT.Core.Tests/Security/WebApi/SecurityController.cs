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
      █       ███
      █   ▀█████████▄
      █      ▀███▀▀██    ▄█████   ▄█████     ██      ▄█████
      █       ███   ▀   ██   █    ██  ▀  ▀███████▄   ██  ▀
      █       ███      ▄██▄▄      ██         ██  ▀   ██
      █       ███     ▀▀██▀▀    ▀███████     ██    ▀███████
      █       ███       ██   █     ▄  ██     ██       ▄  ██
      █      ▄████▀     ███████  ▄████▀     ▄██▀    ▄████▀
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Unit tests for the SecurityController class.
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

using System.Net;
using System.Net.Http;
using System.Web.Http;
using Moq;
using OpenIIoT.SDK;
using OpenIIoT.SDK.Security;
using Utility.OperationResult;
using Xunit;
using System;
using System.Linq;
using System.Collections.Generic;

namespace OpenIIoT.Core.Tests.Security.WebApi
{
    /// <summary>
    ///     Unit tests for the <see cref="Core.Security.WebApi.SecurityController"/> class.
    /// </summary>
    public class SecurityController
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="SecurityController"/> class.
        /// </summary>
        public SecurityController()
        {
            SecurityManager = new Mock<ISecurityManager>();

            Manager = new Mock<IApplicationManager>();
            Manager.Setup(m => m.GetManager<ISecurityManager>()).Returns(SecurityManager.Object);

            Controller = new Core.Security.WebApi.SecurityController(Manager.Object);
            Controller.Request = new HttpRequestMessage();
            Controller.Configuration = new HttpConfiguration();
        }

        #endregion Public Constructors

        #region Private Properties

        /// <summary>
        ///     Gets or sets the WebApi Controller under test.
        /// </summary>
        private Core.Security.WebApi.SecurityController Controller { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="IApplicationManager"/> mockup.
        /// </summary>
        private Mock<IApplicationManager> Manager { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="ISecurityManager"/> mockup.
        /// </summary>
        private Mock<ISecurityManager> SecurityManager { get; set; }

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        ///     Tests the constructor.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            Core.Security.WebApi.SecurityController test = new Core.Security.WebApi.SecurityController(Manager.Object);

            Assert.IsType<Core.Security.WebApi.SecurityController>(test);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Security.WebApi.SecurityController.CreateUser(string, string, Role)"/> method.
        /// </summary>
        [Fact]
        public void CreateUser()
        {
            string hash = "B109F3BBBC244EB82441917ED06D618B9008DD09B3BEFD1B5E07394C706A8BB980B1D7785E5976EC049B46DF5F1326AF5A2EA6D103FD07C95385FFAB0CACBC86";
            SDK.Security.User user = new User("user", hash, Role.Reader);

            SecurityManager.Setup(s => s.CreateUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Role>())).Returns(new Result<User>().SetReturnValue(user));

            HttpResponseMessage response = Controller.CreateUser("user", "password", Role.Reader);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            SDK.Security.User responseUser = response.GetContent<User>();

            Assert.Equal("user", responseUser.Name);
            Assert.Equal(hash, responseUser.PasswordHash);
            Assert.Equal(Role.Reader, responseUser.Role);

            SecurityManager.Verify(s => s.CreateUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Role>()), Times.Once());
        }

        /// <summary>
        ///     Tests the <see cref="Core.Security.WebApi.SecurityController.CreateUser(string, string, Role)"/> method with a
        ///     known bad password.
        /// </summary>
        [Fact]
        public void CreateUserBadPassword()
        {
            HttpResponseMessage response = Controller.CreateUser("user", string.Empty, Role.Reader);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.False(string.IsNullOrEmpty(response.GetContent<string>()));
        }

        /// <summary>
        ///     Tests the <see cref="Core.Security.WebApi.SecurityController.CreateUser(string, string, Role)"/> method with a
        ///     known bad user name.
        /// </summary>
        [Fact]
        public void CreateUserBadUser()
        {
            HttpResponseMessage response = Controller.CreateUser(string.Empty, "password", Role.Reader);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.False(string.IsNullOrEmpty(response.GetContent<string>()));
        }

        /// <summary>
        ///     Tests the <see cref="Core.Security.WebApi.SecurityController.CreateUser(string, string, Role)"/> method with
        ///     <see cref="ISecurityManager"/> returning a failing result.
        /// </summary>
        [Fact]
        public void CreateUserFailure()
        {
            SecurityManager.Setup(s => s.FindUser(It.IsAny<string>())).Returns(default(SDK.Security.User));
            SecurityManager.Setup(s => s.CreateUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Role>())).Returns(new Result<User>(ResultCode.Failure));

            HttpResponseMessage response = Controller.CreateUser("user", "password", Role.Reader);

            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
            Assert.Equal(ResultCode.Failure, response.GetContent<IResult>().ResultCode);

            SecurityManager.Verify(s => s.CreateUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Role>()), Times.Once);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Security.WebApi.SecurityController.CreateUser(string, string, Role)"/> method with an
        ///     existing user.
        /// </summary>
        [Fact]
        public void CreateUserUserExists()
        {
            SDK.Security.User user = new User("user", "B109F3BBBC244EB82441917ED06D618B9008DD09B3BEFD1B5E07394C706A8BB980B1D7785E5976EC049B46DF5F1326AF5A2EA6D103FD07C95385FFAB0CACBC86", Role.Reader);
            SecurityManager.Setup(s => s.FindUser(It.IsAny<string>())).Returns(user);

            HttpResponseMessage response = Controller.CreateUser("user", "password", Role.Reader);

            Assert.Equal(HttpStatusCode.Conflict, response.StatusCode);
            Assert.False(string.IsNullOrEmpty(response.GetContent<string>()));
        }

        /// <summary>
        ///     Tests the <see cref="Core.Security.WebApi.SecurityController.DeleteUser(string)"/> method.
        /// </summary>
        [Fact]
        public void DeleteUser()
        {
            SDK.Security.User user = new User("user", "B109F3BBBC244EB82441917ED06D618B9008DD09B3BEFD1B5E07394C706A8BB980B1D7785E5976EC049B46DF5F1326AF5A2EA6D103FD07C95385FFAB0CACBC86", Role.Reader);
            SecurityManager.Setup(s => s.FindUser(It.IsAny<string>())).Returns(user);
            SecurityManager.Setup(s => s.DeleteUser(It.IsAny<string>())).Returns(new Result());

            HttpResponseMessage response = Controller.DeleteUser("user");

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

            SecurityManager.Verify(s => s.FindUser(It.IsAny<string>()), Times.Once);
            SecurityManager.Verify(s => s.DeleteUser(It.IsAny<string>()), Times.Once);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Security.WebApi.SecurityController.DeleteUser(string)"/> method with a known bad user name.
        /// </summary>
        [Fact]
        public void DeleteUserBadUser()
        {
            HttpResponseMessage response = Controller.DeleteUser(string.Empty);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.False(string.IsNullOrEmpty(response.GetContent<string>()));
        }

        /// <summary>
        ///     Tests the <see cref="Core.Security.WebApi.SecurityController.DeleteUser(string)"/> method with
        ///     <see cref="ISecurityManager"/> returning a failing result.
        /// </summary>
        [Fact]
        public void DeleteUserFailure()
        {
            SDK.Security.User user = new User("user", "B109F3BBBC244EB82441917ED06D618B9008DD09B3BEFD1B5E07394C706A8BB980B1D7785E5976EC049B46DF5F1326AF5A2EA6D103FD07C95385FFAB0CACBC86", Role.Reader);
            SecurityManager.Setup(s => s.FindUser(It.IsAny<string>())).Returns(user);
            SecurityManager.Setup(s => s.DeleteUser(It.IsAny<string>())).Returns(new Result(ResultCode.Failure));

            HttpResponseMessage response = Controller.DeleteUser("user");

            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
            Assert.Equal(ResultCode.Failure, response.GetContent<IResult>().ResultCode);

            SecurityManager.Verify(s => s.FindUser(It.IsAny<string>()), Times.Once);
            SecurityManager.Verify(s => s.DeleteUser(It.IsAny<string>()), Times.Once);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Security.WebApi.SecurityController.DeleteUser(string)"/> method with a user which is not found.
        /// </summary>
        [Fact]
        public void DeleteUserUserNotFound()
        {
            SecurityManager.Setup(s => s.FindUser(It.IsAny<string>())).Returns(default(User));

            HttpResponseMessage response = Controller.DeleteUser("user");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

            SecurityManager.Verify(s => s.FindUser(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void GetRoles()
        {
            SecurityManager.Setup(s => s.Roles).Returns(new[] { Role.Reader, Role.ReadWriter, Role.Administrator }.ToList());

            HttpResponseMessage response = Controller.GetRoles();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            IReadOnlyList<Role> roles = response.GetContent<IReadOnlyList<Role>>();

            Assert.NotEmpty(roles);
            Assert.Contains(Role.Reader, roles);
            Assert.Contains(Role.ReadWriter, roles);
            Assert.Contains(Role.Administrator, roles);

            SecurityManager.Verify(s => s.Roles, Times.Once);
        }

        [Fact]
        public void GetSessions()
        {
            SecurityManager.Setup(s => s.Sessions).Returns(new[] { new Session("key", null) }.ToList().AsReadOnly());

            HttpResponseMessage response = Controller.GetSessions();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            IReadOnlyList<Session> sessions = response.GetContent<IReadOnlyList<Session>>();

            Assert.NotEmpty(sessions);
            Assert.Equal("key", sessions[0].ApiKey);

            SecurityManager.Verify(s => s.Sessions, Times.Once);
        }

        [Fact]
        public void GetUsers()
        {
            SecurityManager.Setup(s => s.Users).Returns(new[] { new User("user", "hash", Role.Reader) }.ToList().AsReadOnly());

            HttpResponseMessage response = Controller.GetUsers();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            IReadOnlyList<User> users = response.GetContent<IReadOnlyList<User>>();

            Assert.NotEmpty(users);
            Assert.Equal("user", users[0].Name);
            Assert.Equal("hash", users[0].PasswordHash);
            Assert.Equal(Role.Reader, users[0].Role);

            SecurityManager.Verify(s => s.Users, Times.Once);
        }

        [Fact]
        public void Login()
        {
            SecurityManager.Setup(s => s.StartSession(It.IsAny<string>(), It.IsAny<string>())).Returns(new Result<Session>().SetReturnValue(new Session("key", null)));

            HttpResponseMessage response = Controller.Login("user", "password");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("key", response.GetContent<Session>().ApiKey);

            SecurityManager.Verify(s => s.StartSession(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void LoginBadPassword()
        {
            HttpResponseMessage response = Controller.Login("user", string.Empty);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.False(string.IsNullOrEmpty(response.GetContent<string>()));
        }

        [Fact]
        public void LoginBadUser()
        {
            HttpResponseMessage response = Controller.Login(string.Empty, "password");

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.False(string.IsNullOrEmpty(response.GetContent<string>()));
        }

        [Fact]
        public void LoginFailure()
        {
            SecurityManager.Setup(s => s.StartSession(It.IsAny<string>(), It.IsAny<string>())).Returns(new Result<Session>(ResultCode.Failure));

            HttpResponseMessage response = Controller.Login("user", "password");

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
            Assert.Equal(ResultCode.Failure, response.GetContent<IResult>().ResultCode);

            SecurityManager.Verify(s => s.StartSession(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void Logout()
        {
            SecurityManager.Setup(s => s.FindSession(It.IsAny<string>())).Returns(new Session("key", null));
            SecurityManager.Setup(s => s.EndSession(It.IsAny<Session>())).Returns(new Result());

            HttpResponseMessage response = Controller.Logout();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            SecurityManager.Verify(s => s.FindSession(It.IsAny<string>()), Times.Once);
            SecurityManager.Verify(s => s.EndSession(It.IsAny<Session>()), Times.Once);
        }

        [Fact]
        public void LogoutFailure()
        {
            SecurityManager.Setup(s => s.FindSession(It.IsAny<string>())).Returns(new Session("key", null));
            SecurityManager.Setup(s => s.EndSession(It.IsAny<Session>())).Returns(new Result(ResultCode.Failure));

            HttpResponseMessage response = Controller.Logout();

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
            Assert.Equal(ResultCode.Failure, response.GetContent<IResult>().ResultCode);

            SecurityManager.Verify(s => s.FindSession(It.IsAny<string>()), Times.Once);
            SecurityManager.Verify(s => s.EndSession(It.IsAny<Session>()), Times.Once);
        }

        [Fact]
        public void UpdateUser()
        {
            SDK.Security.User user = new User("user", "B109F3BBBC244EB82441917ED06D618B9008DD09B3BEFD1B5E07394C706A8BB980B1D7785E5976EC049B46DF5F1326AF5A2EA6D103FD07C95385FFAB0CACBC86", Role.Reader);
            SecurityManager.Setup(s => s.FindUser(It.IsAny<string>())).Returns(user);
            SecurityManager.Setup(s => s.UpdateUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Role?>())).Returns(new Result<User>().SetReturnValue(user));

            HttpResponseMessage response = Controller.UpdateUser("user", "newpassword", Role.ReadWriter);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            IResult<User> result = response.GetContent<IResult<User>>();

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal(user.Name, result.ReturnValue.Name);
            Assert.Equal(user.PasswordHash, result.ReturnValue.PasswordHash);
            Assert.Equal(user.Role, result.ReturnValue.Role);

            SecurityManager.Verify(s => s.UpdateUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Role?>()), Times.Once);
        }

        [Fact]
        public void UpdateUserBadPassword()
        {
            HttpResponseMessage response = Controller.UpdateUser("user", string.Empty, Role.ReadWriter);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.False(string.IsNullOrEmpty(response.GetContent<string>()));
        }

        [Fact]
        public void UpdateUserBadUser()
        {
            HttpResponseMessage response = Controller.UpdateUser(string.Empty, "newpassword", Role.ReadWriter);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.False(string.IsNullOrEmpty(response.GetContent<string>()));
        }

        [Fact]
        public void UpdateUserFailure()
        {
            SDK.Security.User user = new User("user", "B109F3BBBC244EB82441917ED06D618B9008DD09B3BEFD1B5E07394C706A8BB980B1D7785E5976EC049B46DF5F1326AF5A2EA6D103FD07C95385FFAB0CACBC86", Role.Reader);
            SecurityManager.Setup(s => s.FindUser(It.IsAny<string>())).Returns(user);
            SecurityManager.Setup(s => s.UpdateUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Role?>())).Returns(new Result<User>(ResultCode.Failure));

            HttpResponseMessage response = Controller.UpdateUser("user", "newpassword", Role.ReadWriter);

            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);

            IResult<User> result = response.GetContent<IResult<User>>();

            Assert.Equal(ResultCode.Failure, result.ResultCode);

            SecurityManager.Verify(s => s.UpdateUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Role?>()), Times.Once);
        }

        [Fact]
        public void UpdateUserNothingToUpdate()
        {
            HttpResponseMessage response = Controller.UpdateUser("user", null, null);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.False(string.IsNullOrEmpty(response.GetContent<string>()));
        }

        [Fact]
        public void UpdateUserPassword()
        {
            SDK.Security.User user = new User("user", "B109F3BBBC244EB82441917ED06D618B9008DD09B3BEFD1B5E07394C706A8BB980B1D7785E5976EC049B46DF5F1326AF5A2EA6D103FD07C95385FFAB0CACBC86", Role.Reader);
            SecurityManager.Setup(s => s.FindUser(It.IsAny<string>())).Returns(user);
            SecurityManager.Setup(s => s.UpdateUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Role?>())).Returns(new Result<User>().SetReturnValue(user));

            HttpResponseMessage response = Controller.UpdateUser("user", "newpassword", null);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            IResult<User> result = response.GetContent<IResult<User>>();

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal(user.Name, result.ReturnValue.Name);
            Assert.Equal(user.PasswordHash, result.ReturnValue.PasswordHash);
            Assert.Equal(user.Role, result.ReturnValue.Role);

            SecurityManager.Verify(s => s.UpdateUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Role?>()), Times.Once);
        }

        [Fact]
        public void UpdateUserRole()
        {
            SDK.Security.User user = new User("user", "B109F3BBBC244EB82441917ED06D618B9008DD09B3BEFD1B5E07394C706A8BB980B1D7785E5976EC049B46DF5F1326AF5A2EA6D103FD07C95385FFAB0CACBC86", Role.Reader);
            SecurityManager.Setup(s => s.FindUser(It.IsAny<string>())).Returns(user);
            SecurityManager.Setup(s => s.UpdateUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Role?>())).Returns(new Result<User>().SetReturnValue(user));

            HttpResponseMessage response = Controller.UpdateUser("user", null, Role.ReadWriter);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            IResult<User> result = response.GetContent<IResult<User>>();

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal(user.Name, result.ReturnValue.Name);
            Assert.Equal(user.PasswordHash, result.ReturnValue.PasswordHash);
            Assert.Equal(user.Role, result.ReturnValue.Role);

            SecurityManager.Verify(s => s.UpdateUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Role?>()), Times.Once);
        }

        [Fact]
        public void UpdateUserUserNotFound()
        {
            SecurityManager.Setup(s => s.FindUser(It.IsAny<string>())).Returns(default(User));

            HttpResponseMessage response = Controller.UpdateUser("user", "newpassword", Role.ReadWriter);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        #endregion Public Methods
    }
}