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

        private Core.Security.WebApi.SecurityController Controller { get; set; }
        private Mock<IApplicationManager> Manager { get; set; }
        private Mock<ISecurityManager> SecurityManager { get; set; }

        #endregion Private Properties

        #region Public Methods

        [Fact]
        public void Constructor()
        {
            Core.Security.WebApi.SecurityController test = new Core.Security.WebApi.SecurityController(Manager.Object);

            Assert.IsType<Core.Security.WebApi.SecurityController>(test);
        }

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

        [Fact]
        public void CreateUserBadPassword()
        {
            HttpResponseMessage response = Controller.CreateUser("user", "", Role.Reader);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.IsType<ObjectContent<string>>(response.Content);

            string content = ((ObjectContent<string>)response.Content).Value.ToString();
            Assert.False(string.IsNullOrEmpty(content));
        }

        [Fact]
        public void CreateUserBadUser()
        {
            HttpResponseMessage response = Controller.CreateUser(string.Empty, "password", Role.Reader);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.IsType<ObjectContent<string>>(response.Content);

            string content = ((ObjectContent<string>)response.Content).Value.ToString();
            Assert.False(string.IsNullOrEmpty(content));
        }

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