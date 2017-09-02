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
            SDK.Security.User user = new User("user", "B109F3BBBC244EB82441917ED06D618B9008DD09B3BEFD1B5E07394C706A8BB980B1D7785E5976EC049B46DF5F1326AF5A2EA6D103FD07C95385FFAB0CACBC86", Role.Reader);

            SecurityManager.Setup(s => s.CreateUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Role>())).Returns(new Result<User>().SetReturnValue(user));

            HttpResponseMessage response = Controller.CreateUser("user", "password", Role.Reader);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.IsType<ObjectContent<SDK.Security.User>>(response.Content);

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
            Assert.IsType<ObjectContent<string>>(response.Content);

            string content = ((ObjectContent<string>)response.Content).Value.ToString();
            Assert.False(string.IsNullOrEmpty(content));
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
            Assert.IsType<ObjectContent<string>>(response.Content);

            string content = ((ObjectContent<string>)response.Content).Value.ToString();
            Assert.False(string.IsNullOrEmpty(content));
        }

        /// <summary>
        ///     Tests the <see cref="Core.Security.WebApi.SecurityController.CreateUser(string, string, Role)"/> method with a
        ///     <see cref="ISecurityManager"/> returning a failing result.
        /// </summary>
        [Fact]
        public void CreateUserFailure()
        {
            SecurityManager.Setup(s => s.FindUser(It.IsAny<string>())).Returns(default(SDK.Security.User));
            SecurityManager.Setup(s => s.CreateUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Role>())).Returns(new Result<User>(ResultCode.Failure));

            HttpResponseMessage response = Controller.CreateUser("user", "password", Role.Reader);

            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
            Assert.IsType<ObjectContent<IResult>>(response.Content);

            IResult content = (IResult)((ObjectContent<IResult>)response.Content).Value;

            Assert.Equal(ResultCode.Failure, content.ResultCode);

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
            Assert.IsType<ObjectContent<string>>(response.Content);

            string content = ((ObjectContent<string>)response.Content).Value.ToString();
            Assert.False(string.IsNullOrEmpty(content));
        }

        #endregion Public Methods
    }
}