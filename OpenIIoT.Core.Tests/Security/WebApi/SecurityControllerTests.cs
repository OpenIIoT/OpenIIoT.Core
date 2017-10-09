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

namespace OpenIIoT.Core.Tests.Security.WebApi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Security.Claims;
    using System.Web.Http;
    using Moq;
    using OpenIIoT.Core.Security;
    using OpenIIoT.Core.Security.WebApi;
    using OpenIIoT.Core.Security.WebApi.DTO;
    using OpenIIoT.SDK;
    using OpenIIoT.SDK.Common.OperationResult;
    using OpenIIoT.SDK.Security;
    using Xunit;
    using OpenIIoT.Core.Service.WebApi.ModelValidation;

    /// <summary>
    ///     Unit tests for the <see cref="SecurityController"/> class.
    /// </summary>
    [Collection("SecurityController")]
    public class SecurityControllerTests
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="SecurityControllerTests"/> class.
        /// </summary>
        public SecurityControllerTests()
        {
            SecurityManager = new Mock<ISecurityManager>();

            Manager = new Mock<IApplicationManager>();
            Manager.Setup(m => m.GetManager<ISecurityManager>()).Returns(SecurityManager.Object);

            Controller = new SecurityController(Manager.Object);
            Controller.Request = new HttpRequestMessage();
            Controller.Configuration = new HttpConfiguration();

            User = new User("name", "displayName", "name@test.com", "hash", Role.Reader);
        }

        #endregion Public Constructors

        #region Private Properties

        /// <summary>
        ///     Gets or sets the WebApi Controller under test.
        /// </summary>
        private SecurityController Controller { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="IApplicationManager"/> mockup.
        /// </summary>
        private Mock<IApplicationManager> Manager { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="ISecurityManager"/> mockup.
        /// </summary>
        private Mock<ISecurityManager> SecurityManager { get; set; }

        private IUser User { get; set; }

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        ///     Tests the constructor.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            SecurityController test = new SecurityController(Manager.Object);

            Assert.IsType<SecurityController>(test);
        }

        /// <summary>
        ///     Tests the <see cref="SecurityController.RolesGet"/> method.
        /// </summary>
        [Fact]
        public void RolesGet()
        {
            SecurityManager.Setup(s => s.Roles).Returns(new[] { Role.Reader, Role.ReadWriter, Role.Administrator }.ToList());

            HttpResponseMessage response = Controller.RolesGet();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            IReadOnlyList<Role> roles = response.GetContent<IReadOnlyList<Role>>();

            Assert.NotEmpty(roles);
            Assert.Contains(Role.Reader, roles);
            Assert.Contains(Role.ReadWriter, roles);
            Assert.Contains(Role.Administrator, roles);

            SecurityManager.Verify(s => s.Roles, Times.Once);
        }

        /// <summary>
        ///     Tests the <see cref="SecurityController.SessionsEnd"/> method.
        /// </summary>
        [Fact]
        public void SessionsEnd()
        {
            SecurityManager.Setup(s => s.FindSession(It.IsAny<string>())).Returns(new Session(User, null));
            SecurityManager.Setup(s => s.EndSession(It.IsAny<ISession>())).Returns(new Result());

            HttpResponseMessage response = Controller.SessionsEnd();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            SecurityManager.Verify(s => s.FindSession(It.IsAny<string>()), Times.Once);
            SecurityManager.Verify(s => s.EndSession(It.IsAny<ISession>()), Times.Once);
        }

        /// <summary>
        ///     Tests the <see cref="SecurityController.SessionsEnd"/> method with an <see cref="ISecurityManager"/> returning a
        ///     failing result.
        /// </summary>
        [Fact]
        public void SessionsEndFailure()
        {
            SecurityManager.Setup(s => s.FindSession(It.IsAny<string>())).Returns(new Session(User, null));
            SecurityManager.Setup(s => s.EndSession(It.IsAny<ISession>())).Returns(new Result(ResultCode.Failure));

            HttpResponseMessage response = Controller.SessionsEnd();

            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
            Assert.Equal(ResultCode.Failure, response.GetContent<IResult>().ResultCode);

            SecurityManager.Verify(s => s.FindSession(It.IsAny<string>()), Times.Once);
            SecurityManager.Verify(s => s.EndSession(It.IsAny<ISession>()), Times.Once);
        }

        /// <summary>
        ///     Tests the <see cref="SecurityController.SessionsGet"/> method.
        /// </summary>
        [Fact]
        public void SessionsGet()
        {
            ClaimsIdentity identity = new ClaimsIdentity();
            identity.AddClaim(new Claim(ClaimTypes.Hash, "key"));

            SecurityManager.Setup(s => s.Sessions).Returns(new[] { new Session(User, identity) }.ToList().AsReadOnly());

            HttpResponseMessage response = Controller.SessionsGet();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            IReadOnlyList<SessionData> sessions = response.GetContent<IReadOnlyList<SessionData>>();

            Assert.NotEmpty(sessions);
            Assert.Equal("key", sessions[0].Token);

            SecurityManager.Verify(s => s.Sessions, Times.Once);
        }

        /// <summary>
        ///     Tests the <see cref="SecurityController.SessionsGetCurrent"/> method.
        /// </summary>
        [Fact]
        public void SessionsGetCurrent()
        {
            ClaimsIdentity identity = new ClaimsIdentity();
            identity.AddClaim(new Claim(ClaimTypes.Hash, "key"));

            SecurityManager.Setup(s => s.FindSession(It.IsAny<string>())).Returns(new Session(User, identity));

            HttpResponseMessage response = Controller.SessionsGetCurrent();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("key", response.GetContent<SessionData>().Token);

            SecurityManager.Verify(s => s.FindSession(It.IsAny<string>()), Times.Once);
        }

        /// <summary>
        ///     Tests the <see cref="SecurityController.SessionsStart(SessionStartData)"/> method.
        /// </summary>
        [Fact]
        public void SessionsStart()
        {
            ClaimsIdentity identity = new ClaimsIdentity();
            identity.AddClaim(new Claim(ClaimTypes.Hash, "key"));

            SecurityManager.Setup(s => s.StartSession(It.IsAny<string>(), It.IsAny<string>())).Returns(new Result<ISession>().SetReturnValue(new Session(User, identity)));

            HttpResponseMessage response = Controller.SessionsStart(new SessionStartData() { Name = "user", Password = "password" });

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("key", response.GetContent<SessionData>().Token);

            SecurityManager.Verify(s => s.StartSession(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        /// <summary>
        ///     Tests the <see cref="SecurityController.SessionsStart(SessionStartData)"/> method with an
        ///     <see cref="ISecurityManager"/> returning a failing result.
        /// </summary>
        [Fact]
        public void SessionsStartFailure()
        {
            SecurityManager.Setup(s => s.StartSession(It.IsAny<string>(), It.IsAny<string>())).Returns(new Result<ISession>(ResultCode.Failure));

            HttpResponseMessage response = Controller.SessionsStart(new SessionStartData() { Name = "user", Password = "password" });

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
            Assert.Equal(ResultCode.Failure, response.GetContent<IResult>().ResultCode);

            SecurityManager.Verify(s => s.StartSession(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        /// <summary>
        ///     Tests the <see cref="SecurityController.UsersCreate(UserCreateData)"/> method.
        /// </summary>
        [Fact]
        public void UsersCreate()
        {
            string hash = "B109F3BBBC244EB82441917ED06D618B9008DD09B3BEFD1B5E07394C706A8BB980B1D7785E5976EC049B46DF5F1326AF5A2EA6D103FD07C95385FFAB0CACBC86";
            User user = new User("user", "user", "test@test.com", hash, Role.Reader);

            SecurityManager.Setup(s => s.CreateUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Role>())).Returns(new Result<IUser>().SetReturnValue(user));

            HttpResponseMessage response = Controller.UsersCreate(new UserCreateData() { Name = "user", DisplayName = "name", Email = "test@test.com", Password = "password", Role = Role.Reader });

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            UserData responseUser = response.GetContent<UserData>();

            Assert.Equal("user", responseUser.Name);
            Assert.Equal(Role.Reader, responseUser.Role);

            SecurityManager.Verify(s => s.CreateUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Role>()), Times.Once());
        }

        /// <summary>
        ///     Tests the <see cref="SecurityController.UsersCreate(UserCreateData)"/> method with <see cref="ISecurityManager"/>
        ///     returning a failing result.
        /// </summary>
        [Fact]
        public void UsersCreateFailure()
        {
            SecurityManager.Setup(s => s.FindUser(It.IsAny<string>())).Returns(default(User));
            SecurityManager.Setup(s => s.CreateUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Role>())).Returns(new Result<IUser>(ResultCode.Failure));

            UserCreateData newUser = new UserCreateData() { Name = "user", DisplayName = "name", Email = "test@test.com", Password = "password", Role = Role.Reader };
            HttpResponseMessage response = Controller.UsersCreate(newUser);

            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
            Assert.Equal(ResultCode.Failure, response.GetContent<IResult>().ResultCode);

            SecurityManager.Verify(s => s.CreateUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Role>()), Times.Once);
        }

        /// <summary>
        ///     Tests the <see cref="SecurityController.UsersCreate(UserCreateData)"/> method with an existing user.
        /// </summary>
        [Fact]
        public void UsersCreateUserExists()
        {
            User user = new User("user", "user", "test@test.com", "B109F3BBBC244EB82441917ED06D618B9008DD09B3BEFD1B5E07394C706A8BB980B1D7785E5976EC049B46DF5F1326AF5A2EA6D103FD07C95385FFAB0CACBC86", Role.Reader);
            SecurityManager.Setup(s => s.FindUser(It.IsAny<string>())).Returns(user);

            HttpResponseMessage response = Controller.UsersCreate(new UserCreateData() { Name = "user", DisplayName = "name", Email = "test@test.com", Password = "password", Role = Role.Reader });

            Assert.Equal(HttpStatusCode.Conflict, response.StatusCode);
            Assert.False(string.IsNullOrEmpty(response.GetContent<string>()));
        }

        /// <summary>
        ///     Tests the <see cref="SecurityController.UsersDelete(string)"/> method.
        /// </summary>
        [Fact]
        public void UsersDelete()
        {
            User user = new User("user", "user", "test@test.com", "B109F3BBBC244EB82441917ED06D618B9008DD09B3BEFD1B5E07394C706A8BB980B1D7785E5976EC049B46DF5F1326AF5A2EA6D103FD07C95385FFAB0CACBC86", Role.Reader);
            SecurityManager.Setup(s => s.FindUser(It.IsAny<string>())).Returns(user);
            SecurityManager.Setup(s => s.DeleteUser(It.IsAny<string>())).Returns(new Result());

            HttpResponseMessage response = Controller.UsersDelete("user");

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

            SecurityManager.Verify(s => s.FindUser(It.IsAny<string>()), Times.Once);
            SecurityManager.Verify(s => s.DeleteUser(It.IsAny<string>()), Times.Once);
        }

        /// <summary>
        ///     Tests the <see cref="SecurityController.UsersDelete(string)"/> method with a known bad user name.
        /// </summary>
        [Fact]
        public void UsersDeleteBadUser()
        {
            HttpResponseMessage response = Controller.UsersDelete(string.Empty);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.False(string.IsNullOrEmpty(response.GetContent<string>()));
        }

        /// <summary>
        ///     Tests the <see cref="SecurityController.UsersDelete(string)"/> method with <see cref="ISecurityManager"/> returning
        ///     a failing result.
        /// </summary>
        [Fact]
        public void UsersDeleteFailure()
        {
            User user = new User("user", "user", "test@test.com", "B109F3BBBC244EB82441917ED06D618B9008DD09B3BEFD1B5E07394C706A8BB980B1D7785E5976EC049B46DF5F1326AF5A2EA6D103FD07C95385FFAB0CACBC86", Role.Reader);
            SecurityManager.Setup(s => s.FindUser(It.IsAny<string>())).Returns(user);
            SecurityManager.Setup(s => s.DeleteUser(It.IsAny<string>())).Returns(new Result(ResultCode.Failure));

            HttpResponseMessage response = Controller.UsersDelete("user");

            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
            Assert.Equal(ResultCode.Failure, response.GetContent<IResult>().ResultCode);

            SecurityManager.Verify(s => s.FindUser(It.IsAny<string>()), Times.Once);
            SecurityManager.Verify(s => s.DeleteUser(It.IsAny<string>()), Times.Once);
        }

        /// <summary>
        ///     Tests the <see cref="SecurityController.UsersDelete(string)"/> method with a user which is not found.
        /// </summary>
        [Fact]
        public void UsersDeleteUserNotFound()
        {
            SecurityManager.Setup(s => s.FindUser(It.IsAny<string>())).Returns(default(IUser));

            HttpResponseMessage response = Controller.UsersDelete("user");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

            SecurityManager.Verify(s => s.FindUser(It.IsAny<string>()), Times.Once);
        }

        /// <summary>
        ///     Tests the <see cref="SecurityController.UsersGet"/> method.
        /// </summary>
        [Fact]
        public void UsersGet()
        {
            SecurityManager.Setup(s => s.Users).Returns(new[] { new User("user", "user", "test@test.com", "hash", Role.Reader) }.ToList().AsReadOnly());

            HttpResponseMessage response = Controller.UsersGet();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            IReadOnlyList<UserData> users = response.GetContent<IReadOnlyList<UserData>>();

            Assert.NotEmpty(users);
            Assert.Equal("user", users[0].Name);
            Assert.Equal(Role.Reader, users[0].Role);

            SecurityManager.Verify(s => s.Users, Times.Once);
        }

        /// <summary>
        ///     Tests the <see cref="SecurityController.UsersGetName(string)"/> method.
        /// </summary>
        [Fact]
        public void UsersGetName()
        {
            SecurityManager.Setup(s => s.FindUser(It.IsAny<string>())).Returns(new User("user", "user", "test@test.com", "hash", Role.Reader));

            HttpResponseMessage response = Controller.UsersGetName("user");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("user", response.GetContent<UserData>().Name);

            SecurityManager.Verify(s => s.FindUser(It.IsAny<string>()), Times.Once);
        }

        /// <summary>
        ///     Tests the <see cref="SecurityController.UsersGetName(string)"/> method with a known bad name.
        /// </summary>
        [Fact]
        public void UsersGetNameBadName()
        {
            HttpResponseMessage response = Controller.UsersGetName(string.Empty);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            SecurityManager.Verify(s => s.Users, Times.Never);
        }

        /// <summary>
        ///     Tests the <see cref="SecurityController.UsersGetName(string)"/> method with a User which can not be found.
        /// </summary>
        [Fact]
        public void UsersGetNameNotFound()
        {
            SecurityManager.Setup(s => s.FindUser(It.IsAny<string>())).Returns(default(IUser));

            HttpResponseMessage response = Controller.UsersGetName(Guid.NewGuid().ToString());

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

            SecurityManager.Verify(s => s.FindUser(It.IsAny<string>()), Times.Once);
        }

        /// <summary>
        ///     Tests the <see cref="SecurityController.UsersUpdate(string, string, Role?)"/> method.
        /// </summary>
        [Fact]
        public void UsersUpdate()
        {
            User user = new User("user", "user", "test@test.com", "B109F3BBBC244EB82441917ED06D618B9008DD09B3BEFD1B5E07394C706A8BB980B1D7785E5976EC049B46DF5F1326AF5A2EA6D103FD07C95385FFAB0CACBC86", Role.Reader);
            SecurityManager.Setup(s => s.FindUser(It.IsAny<string>())).Returns(user);
            SecurityManager.Setup(s => s.UpdateUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Role?>())).Returns(new Result<IUser>().SetReturnValue(user));

            HttpResponseMessage response = Controller.UsersUpdate("user", new UserUpdateData() { Password = "newpassword", Role = Role.ReadWriter });

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            UserData result = response.GetContent<UserData>();

            Assert.Equal(user.Name, result.Name);
            Assert.Equal(user.Role, result.Role);

            SecurityManager.Verify(s => s.UpdateUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Role?>()), Times.Once);
        }

        /// <summary>
        ///     Tests the <see cref="SecurityController.UsersUpdate(string, string, Role?)"/> method with an
        ///     <see cref="ISecurityManager"/> returning a failing result.
        /// </summary>
        [Fact]
        public void UsersUpdateFailure()
        {
            User user = new User("user", "user", "test@test.com", "B109F3BBBC244EB82441917ED06D618B9008DD09B3BEFD1B5E07394C706A8BB980B1D7785E5976EC049B46DF5F1326AF5A2EA6D103FD07C95385FFAB0CACBC86", Role.Reader);
            SecurityManager.Setup(s => s.FindUser(It.IsAny<string>())).Returns(user);
            SecurityManager.Setup(s => s.UpdateUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Role?>())).Returns(new Result<IUser>(ResultCode.Failure));

            HttpResponseMessage response = Controller.UsersUpdate("user", new UserUpdateData() { Password = "newpassword", Role = Role.ReadWriter });

            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);

            IResult result = response.GetContent<Result>(); // failures downcast generic Results

            Assert.Equal(ResultCode.Failure, result.ResultCode);

            SecurityManager.Verify(s => s.UpdateUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Role?>()), Times.Once);
        }

        /// <summary>
        ///     Tests the <see cref="SecurityController.UsersUpdate(string, string, Role?)"/> method with neither an updated
        ///     <see cref="Role"/> nor password.
        /// </summary>
        [Fact]
        public void UsersUpdateNothingToUpdate()
        {
            HttpResponseMessage response = Controller.UsersUpdate("user", new UserUpdateData() { Password = null, Role = null });

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.NotNull(response.GetContent<ModelValidationResult>());
        }

        /// <summary>
        ///     Tests the <see cref="SecurityController.UsersUpdate(string, string, Role?)"/> method with an updated password.
        /// </summary>
        [Fact]
        public void UsersUpdatePassword()
        {
            User user = new User("user", "user", "test@test.com", "B109F3BBBC244EB82441917ED06D618B9008DD09B3BEFD1B5E07394C706A8BB980B1D7785E5976EC049B46DF5F1326AF5A2EA6D103FD07C95385FFAB0CACBC86", Role.Reader);
            SecurityManager.Setup(s => s.FindUser(It.IsAny<string>())).Returns(user);
            SecurityManager.Setup(s => s.UpdateUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Role?>())).Returns(new Result<IUser>().SetReturnValue(user));

            HttpResponseMessage response = Controller.UsersUpdate("user", new UserUpdateData() { Password = "newpassword", Role = null });

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            UserData result = response.GetContent<UserData>();

            Assert.Equal(user.Name, result.Name);
            Assert.Equal(user.Role, result.Role);

            SecurityManager.Verify(s => s.UpdateUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Role?>()), Times.Once);
        }

        /// <summary>
        ///     Tests the <see cref="SecurityController.UsersUpdate(string, string, Role?)"/> method with an updated <see cref="Role"/>.
        /// </summary>
        [Fact]
        public void UsersUpdateRole()
        {
            User user = new User("user", "user", "test@test.com", "B109F3BBBC244EB82441917ED06D618B9008DD09B3BEFD1B5E07394C706A8BB980B1D7785E5976EC049B46DF5F1326AF5A2EA6D103FD07C95385FFAB0CACBC86", Role.Reader);
            SecurityManager.Setup(s => s.FindUser(It.IsAny<string>())).Returns(user);
            SecurityManager.Setup(s => s.UpdateUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Role?>())).Returns(new Result<IUser>().SetReturnValue(user));

            HttpResponseMessage response = Controller.UsersUpdate("user", new UserUpdateData() { Password = null, Role = Role.ReadWriter });

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            UserData result = response.GetContent<UserData>();

            Assert.Equal(user.Name, result.Name);
            Assert.Equal(user.DisplayName, result.DisplayName);
            Assert.Equal(user.Email, result.Email);
            Assert.Equal(user.Role, result.Role);

            SecurityManager.Verify(s => s.UpdateUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Role?>()), Times.Once);
        }

        /// <summary>
        ///     Tests the <see cref="SecurityController.UsersUpdate(string, string, Role?)"/> method with an
        ///     <see cref="ISecurityManager"/> unable to locate the specified user..
        /// </summary>
        [Fact]
        public void UsersUpdateUserNotFound()
        {
            SecurityManager.Setup(s => s.FindUser(It.IsAny<string>())).Returns(default(User));

            HttpResponseMessage response = Controller.UsersUpdate("user", new UserUpdateData() { Password = "newpassword", Role = Role.ReadWriter });

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        #endregion Public Methods
    }
}