/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄████████                                                              ▄▄▄▄███▄▄▄▄
      █     ███    ███                                                            ▄██▀▀▀███▀▀▀██▄
      █     ███    █▀     ▄█████  ▄██████ ██   █     █████  █      ██    ▄█   ▄   ███   ███   ███   ▄█████  ██▄▄▄▄    ▄█████     ▄████▄     ▄█████    █████
      █     ███          ██   █  ██    ██ ██   ██   ██  ██ ██  ▀███████▄ ██   █▄  ███   ███   ███   ██   ██ ██▀▀▀█▄   ██   ██   ██    ▀    ██   █    ██  ██
      █   ▀███████████  ▄██▄▄    ██    ▀  ██   ██  ▄██▄▄█▀ ██▌     ██  ▀ ▀▀▀▀▀██  ███   ███   ███   ██   ██ ██   ██   ██   ██  ▄██        ▄██▄▄     ▄██▄▄█▀
      █            ███ ▀▀██▀▀    ██    ▄  ██   ██ ▀███████ ██      ██    ▄█   ██  ███   ███   ███ ▀████████ ██   ██ ▀████████ ▀▀██ ███▄  ▀▀██▀▀    ▀███████
      █      ▄█    ███   ██   █  ██    ██ ██   ██   ██  ██ ██      ██    ██   ██  ███   ███   ███   ██   ██ ██   ██   ██   ██   ██    ██   ██   █    ██  ██
      █    ▄████████▀    ███████ ██████▀  ██████    ██  ██ █      ▄██▀    █████    ▀█   ███   █▀    ██   █▀  █   █    ██   █▀   ██████▀    ███████   ██  ██
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
      █  Unit tests for the SecurityManager class.
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

using System;
using System.Linq;
using System.Reflection;
using Moq;
using OpenIIoT.SDK;
using OpenIIoT.SDK.Common;
using OpenIIoT.SDK.Configuration;
using OpenIIoT.SDK.Security;
using Utility.OperationResult;
using Xunit;
using System.Collections.Generic;
using OpenIIoT.SDK.Common.Exceptions;

namespace OpenIIoT.Core.Tests.Security
{
    /// <summary>
    ///     Unit tests for the <see cref="Core.Security.SecurityManager"/> class.
    /// </summary>
    public class SecurityManager
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="SecurityManager"/> class.
        /// </summary>
        public SecurityManager()
        {
            SetupMocks();

            Core.Security.SecurityManager.Terminate();

            Manager = Core.Security.SecurityManager.Instantiate(ApplicationManager.Object, ConfigurationManager.Object);
        }

        #endregion Public Constructors

        #region Private Properties

        /// <summary>
        ///     Gets or sets the <see cref="IConfiguration"/> mockup for the class.
        /// </summary>
        private Mock<IConfiguration> ApplicationConfiguration { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="IApplicationManager"/> mockup for the class.
        /// </summary>
        private Mock<IApplicationManager> ApplicationManager { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="Core.Security.SecurityManagerConfiguration"/> for the Manager.
        /// </summary>
        private Core.Security.SecurityManagerConfiguration Configuration { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="IConfigurationManager"/> mockup for the class.
        /// </summary>
        private Mock<IConfigurationManager> ConfigurationManager { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="ISecurityManager"/> instance under test.
        /// </summary>
        private ISecurityManager Manager { get; set; }

        #endregion Private Properties

        #region Public Methods

        [Fact]
        public void Constructor()
        {
            Assert.IsType<Core.Security.SecurityManager>(Manager);

            Assert.Equal(State.Initialized, Manager.State);
            Assert.NotEmpty(Manager.Roles);
            Assert.NotNull(Manager.Sessions);
            Assert.Null(Manager.Users);
        }

        [Fact]
        public void CreateUser()
        {
            Manager.Start();

            string name = Guid.NewGuid().ToString();

            IResult<SDK.Security.User> result = Manager.CreateUser(name, "password", Role.Reader);

            Assert.Equal(string.Empty, result.GetLastError());
            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal(name, result.ReturnValue.Name);
            Assert.Equal(SDK.Common.Utility.ComputeSHA512Hash("password"), result.ReturnValue.PasswordHash);
            Assert.Equal(Role.Reader, result.ReturnValue.Role);

            Assert.True(((Core.Security.SecurityManager)Manager).Configuration.Users.Any(u => u.Name == name));
        }

        [Fact]
        public void CreateUserBadPassword()
        {
            Manager.Start();

            IResult<SDK.Security.User> result = Manager.CreateUser("name", string.Empty, Role.Reader);

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        [Fact]
        public void CreateUserBadUser()
        {
            Manager.Start();

            IResult<SDK.Security.User> result = Manager.CreateUser(string.Empty, "password", Role.Reader);

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        [Fact]
        public void CreateUserNotStarted()
        {
            IResult<SDK.Security.User> result = Manager.CreateUser("name", "password", Role.Reader);
            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        [Fact]
        public void CreateUserUserExists()
        {
            Manager.Start();

            IResult<SDK.Security.User> result = Manager.CreateUser("test", "password", Role.Reader); // name must match SetupMocks()

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        [Fact]
        public void DeleteUser()
        {
            string name = Guid.NewGuid().ToString();
            string hash = SDK.Common.Utility.ComputeSHA512Hash("test");

            Configuration.Users.Add(new User(name, hash, Role.Reader));

            Manager.Start();

            IResult result = Manager.DeleteUser(name);

            Assert.Equal(ResultCode.Success, result.ResultCode);
        }

        [Fact]
        public void DeleteUserNotFound()
        {
            Manager.Start();

            IResult result = Manager.DeleteUser(Guid.NewGuid().ToString());

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        [Fact]
        public void DeleteUserNotRunning()
        {
            string name = Guid.NewGuid().ToString();
            string hash = SDK.Common.Utility.ComputeSHA512Hash("test");

            Configuration.Users.Add(new User(name, hash, Role.Reader));

            IResult result = Manager.DeleteUser(name);

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        [Fact]
        public void EndSession()
        {
            Manager.Start();

            IResult<SDK.Security.Session> session = Manager.StartSession("test", "test");

            Assert.Equal(ResultCode.Success, session.ResultCode);

            IResult result = Manager.EndSession(session.ReturnValue);

            Assert.Equal(ResultCode.Success, result.ResultCode);
        }

        [Fact]
        public void EndSessionNotRunning()
        {
            IResult result = Manager.EndSession(new Session("key", null));

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        [Fact]
        public void EndSessionSessionNotFound()
        {
            Manager.Start();

            IResult result = Manager.EndSession(new Session("key", null));

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        [Fact]
        public void EndSessionSessionNull()
        {
            Manager.Start();

            IResult result = Manager.EndSession(null);

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        [Fact]
        public void ExtendSession()
        {
            Manager.Start();

            IResult<SDK.Security.Session> session = Manager.StartSession("test", "test");
            DateTimeOffset? offset = session.ReturnValue.Ticket.Properties.ExpiresUtc;

            Assert.Equal(ResultCode.Success, session.ResultCode);

            Configuration.SessionLength = Configuration.SessionLength * 2;

            IResult<SDK.Security.Session> result = Manager.ExtendSession(session.ReturnValue);

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.True(result.ReturnValue.Ticket.Properties.ExpiresUtc > offset);
        }

        [Fact]
        public void ExtendSessionExpired()
        {
            Manager.Start();

            IResult<SDK.Security.Session> session = Manager.StartSession("test", "test");

            Assert.Equal(ResultCode.Success, session.ResultCode);

            session.ReturnValue.Ticket.Properties.ExpiresUtc = session.ReturnValue.Ticket.Properties.IssuedUtc.Value.AddMinutes(-1);

            IResult<SDK.Security.Session> result = Manager.ExtendSession(session.ReturnValue);

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        [Fact]
        public void ExtendSessionNotFound()
        {
            Manager.Start();

            IResult<SDK.Security.Session> result = Manager.ExtendSession(new Session("key", null));

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        [Fact]
        public void ExtendSessionNotRunning()
        {
            IResult result = Manager.ExtendSession(new Session("key", null));

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        [Fact]
        public void ExtendSessionSessionNull()
        {
            Manager.Start();

            IResult result = Manager.ExtendSession(null);

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        [Fact]
        public void ExtendSessionSlidingSessionsNotEnabled()
        {
            Manager.Start();

            IResult<SDK.Security.Session> session = Manager.StartSession("test", "test");
            DateTimeOffset? offset = session.ReturnValue.Ticket.Properties.ExpiresUtc;

            Assert.Equal(ResultCode.Success, session.ResultCode);

            Configuration.SlidingSessions = false;

            IResult<SDK.Security.Session> result = Manager.ExtendSession(session.ReturnValue);

            Assert.Equal(ResultCode.Warning, result.ResultCode);
        }

        [Fact]
        public void FindSession()
        {
            Manager.Start();

            IResult<SDK.Security.Session> session = Manager.StartSession("test", "test");

            Assert.Equal(ResultCode.Success, session.ResultCode);

            SDK.Security.Session foundSession = Manager.FindSession(session.ReturnValue.ApiKey);

            Assert.NotEqual(default(SDK.Security.Session), foundSession);
            Assert.Equal("test", foundSession.Ticket.Identity.Name);
        }

        [Fact]
        public void FindSessionNotFound()
        {
            SDK.Security.Session foundSession = Manager.FindSession(Guid.NewGuid().ToString());

            Assert.Equal(default(SDK.Security.Session), foundSession);
        }

        [Fact]
        public void FindUser()
        {
            Manager.Start();

            string name = Guid.NewGuid().ToString();
            Configuration.Users.Add(new SDK.Security.User(name, "hash", Role.Reader));

            SDK.Security.User user = Manager.FindUser(name);

            Assert.NotEqual(default(SDK.Security.User), user);
            Assert.Equal(user.Name, name);
            Assert.Equal(user.PasswordHash, "hash");
            Assert.Equal(user.Role, Role.Reader);
        }

        [Fact]
        public void FindUserNotFound()
        {
            string name = Guid.NewGuid().ToString();

            SDK.Security.User user = Manager.FindUser(name);

            Assert.Equal(default(SDK.Security.User), user);
        }

        [Fact]
        public void FindUserSession()
        {
            Manager.Start();

            IResult<SDK.Security.Session> session = Manager.StartSession("test", "test");

            Assert.Equal(ResultCode.Success, session.ResultCode);

            SDK.Security.Session foundSession = Manager.FindUserSession("test");

            Assert.NotEqual(default(SDK.Security.Session), foundSession);
            Assert.Equal("test", foundSession.Ticket.Identity.Name);
        }

        [Fact]
        public void FindUserSessionNotFound()
        {
            SDK.Security.Session foundSession = Manager.FindUserSession(Guid.NewGuid().ToString());

            Assert.Equal(default(SDK.Security.Session), foundSession);
        }

        [Fact]
        public void GetConfigurationDefinition()
        {
            IConfigurationDefinition configdef = Core.Security.SecurityManager.GetConfigurationDefinition();

            Assert.False(string.IsNullOrEmpty(configdef.Form));
            Assert.False(string.IsNullOrEmpty(configdef.Schema));
            Assert.NotNull(configdef.Model);

            Core.Security.SecurityManagerConfiguration config = (Core.Security.SecurityManagerConfiguration)configdef.DefaultConfiguration;

            Assert.NotNull(config.SessionLength);
            Assert.NotNull(config.SessionPurgeInterval);
            Assert.NotEmpty(config.Users);
        }

        [Fact]
        public void Instantiate()
        {
            Core.Security.SecurityManager.Terminate();

            ISecurityManager manager = Core.Security.SecurityManager.Instantiate(ApplicationManager.Object, ConfigurationManager.Object);

            Assert.IsType<Core.Security.SecurityManager>(manager);
        }

        [Fact]
        public void InstantiateTwice()
        {
            Core.Security.SecurityManager.Terminate();

            ISecurityManager manager = Core.Security.SecurityManager.Instantiate(ApplicationManager.Object, ConfigurationManager.Object);

            Assert.IsType<Core.Security.SecurityManager>(manager);

            ISecurityManager manager2 = Core.Security.SecurityManager.Instantiate(ApplicationManager.Object, ConfigurationManager.Object);

            Assert.IsType<Core.Security.SecurityManager>(manager2);
            Assert.Same(manager, manager2);
        }

        [Fact]
        public void PurgeExpiredSessions()
        {
            Manager.Start();

            string name1 = Guid.NewGuid().ToString();
            string name2 = Guid.NewGuid().ToString();

            Manager.CreateUser(name1, "test", Role.Reader);
            SDK.Security.Session session1 = Manager.StartSession(name1, "test").ReturnValue;
            session1.Ticket.Properties.ExpiresUtc = session1.Ticket.Properties.IssuedUtc.Value.AddMinutes(-1);

            Assert.True(session1.IsExpired);

            Manager.CreateUser(name2, "test", Role.Reader);
            SDK.Security.Session session2 = Manager.StartSession(name2, "test").ReturnValue;

            Assert.False(session2.IsExpired);

            // invoke the purge via reflection since the timer would be tricky to set up.
            MethodInfo purge = typeof(Core.Security.SecurityManager).GetMethod("PurgeExpiredSessions", BindingFlags.NonPublic | BindingFlags.Instance);

            Exception ex = Record.Exception(() => purge.Invoke(Manager, new object[] { }));

            Assert.Null(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Security.SecurityManager.Setup"/> method using reflection.
        /// </summary>
        [Fact]
        public void Setup()
        {
            MethodInfo setup = typeof(Core.Security.SecurityManager).GetMethod("Setup", BindingFlags.NonPublic | BindingFlags.Instance);
            setup.Invoke(Manager, new object[] { });
        }

        [Fact]
        public void Start()
        {
            IResult result = Manager.Start();

            Assert.Equal(string.Empty, result.GetLastError());
            Assert.NotEqual(ResultCode.Failure, result.ResultCode);
            Assert.Equal(State.Running, Manager.State);
        }

        [Fact]
        public void StartConfigurationFailure()
        {
            ApplicationConfiguration.Setup(
                c => c.GetInstance<Core.Security.SecurityManagerConfiguration>(It.IsAny<Type>()))
                    .Returns(new Result<Core.Security.SecurityManagerConfiguration>(ResultCode.Failure));

            ApplicationConfiguration.Setup(
                c => c.AddInstance<Core.Security.SecurityManagerConfiguration>(It.IsAny<Type>(), It.IsAny<object>()))
                    .Returns(new Result<Core.Security.SecurityManagerConfiguration>(ResultCode.Failure));

            Exception ex = Record.Exception(() => Manager.Start());

            Assert.NotNull(ex);
            Assert.IsType<ManagerStartException>(ex);
        }

        [Fact]
        public void StartNotConfigured()
        {
            ApplicationConfiguration.Setup(
                c => c.GetInstance<Core.Security.SecurityManagerConfiguration>(It.IsAny<Type>()))
                    .Returns(new Result<Core.Security.SecurityManagerConfiguration>(ResultCode.Failure));

            ApplicationConfiguration.Setup(
                c => c.AddInstance<Core.Security.SecurityManagerConfiguration>(It.IsAny<Type>(), It.IsAny<object>()))
                    .Returns(new Result<Core.Security.SecurityManagerConfiguration>().SetReturnValue(Configuration));

            IResult result = Manager.Start();

            Assert.Equal(string.Empty, result.GetLastError());
            Assert.NotEqual(ResultCode.Failure, result.ResultCode);
            Assert.Equal(State.Running, Manager.State);
        }

        [Fact]
        public void StartSession()
        {
            Manager.Start();

            IResult<SDK.Security.Session> result = Manager.StartSession("test", "test");

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal("test", result.ReturnValue.Ticket.Identity.Name);
        }

        [Fact]
        public void StartSessionBadPassword()
        {
            Manager.Start();

            IResult<SDK.Security.Session> result = Manager.StartSession("test", "bad");

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        [Fact]
        public void StartSessionExistingSession()
        {
            Manager.Start();

            IResult<SDK.Security.Session> session1 = Manager.StartSession("test", "test");

            Assert.Equal(ResultCode.Success, session1.ResultCode);
            Assert.Equal("test", session1.ReturnValue.Ticket.Identity.Name);

            IResult<SDK.Security.Session> session2 = Manager.StartSession("test", "test");

            Assert.Same(session1.ReturnValue, session2.ReturnValue);
        }

        [Fact]
        public void StartSessionNotStarted()
        {
            IResult<SDK.Security.Session> result = Manager.StartSession("test", "test");

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        [Fact]
        public void StartSessionUSerNotFound()
        {
            Manager.Start();

            IResult<SDK.Security.Session> result = Manager.StartSession(Guid.NewGuid().ToString(), "test");

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        [Fact]
        public void Stop()
        {
            IResult result = Manager.Start();

            Assert.Equal(string.Empty, result.GetLastError());
            Assert.NotEqual(ResultCode.Failure, result.ResultCode);
            Assert.Equal(State.Running, Manager.State);

            result = Manager.Stop();

            Assert.Equal(string.Empty, result.GetLastError());
            Assert.NotEqual(ResultCode.Failure, result.ResultCode);
            Assert.Equal(State.Stopped, Manager.State);
        }

        [Fact]
        public void UpdateUser()
        {
            Manager.Start();

            string name = Guid.NewGuid().ToString();
            string hash = SDK.Common.Utility.ComputeSHA512Hash("test2");

            Manager.CreateUser(name, "test", Role.Reader);

            IResult<SDK.Security.User> user = Manager.UpdateUser(name, "test2", Role.ReadWriter);

            Assert.Equal(ResultCode.Success, user.ResultCode);
            Assert.Equal(name, user.ReturnValue.Name);
            Assert.Equal(hash, user.ReturnValue.PasswordHash);
            Assert.Equal(Role.ReadWriter, user.ReturnValue.Role);
        }

        [Fact]
        public void UpdateUserBadPassword()
        {
            Manager.Start();

            IResult<SDK.Security.User> user = Manager.UpdateUser("name", string.Empty, Role.ReadWriter);

            Assert.Equal(ResultCode.Failure, user.ResultCode);
        }

        [Fact]
        public void UpdateUserNothingToUpdate()
        {
            Manager.Start();

            IResult<SDK.Security.User> user = Manager.UpdateUser("name", null, null);

            Assert.Equal(ResultCode.Failure, user.ResultCode);
        }

        [Fact]
        public void UpdateUserNotRunning()
        {
            IResult<SDK.Security.User> user = Manager.UpdateUser("name", "test", Role.ReadWriter);

            Assert.Equal(ResultCode.Failure, user.ResultCode);
        }

        [Fact]
        public void UpdateUserPassword()
        {
            Manager.Start();

            string name = Guid.NewGuid().ToString();
            string hash = SDK.Common.Utility.ComputeSHA512Hash("test2");

            Manager.CreateUser(name, "test", Role.Reader);

            IResult<SDK.Security.User> user = Manager.UpdateUser(name, "test2", null);

            Assert.Equal(ResultCode.Success, user.ResultCode);
            Assert.Equal(name, user.ReturnValue.Name);
            Assert.Equal(hash, user.ReturnValue.PasswordHash);
            Assert.Equal(Role.Reader, user.ReturnValue.Role);
        }

        [Fact]
        public void UpdateUserRole()
        {
            Manager.Start();

            string name = Guid.NewGuid().ToString();
            string hash = SDK.Common.Utility.ComputeSHA512Hash("test");

            Manager.CreateUser(name, "test", Role.Reader);

            IResult<SDK.Security.User> user = Manager.UpdateUser(name, null, Role.ReadWriter);

            Assert.Equal(ResultCode.Success, user.ResultCode);
            Assert.Equal(name, user.ReturnValue.Name);
            Assert.Equal(hash, user.ReturnValue.PasswordHash);
            Assert.Equal(Role.ReadWriter, user.ReturnValue.Role);
        }

        [Fact]
        public void UpdateUserUserNotFound()
        {
            Manager.Start();

            string name = Guid.NewGuid().ToString();

            IResult<SDK.Security.User> user = Manager.UpdateUser(name, "test", Role.ReadWriter);

            Assert.Equal(ResultCode.Failure, user.ResultCode);
        }

        [Fact]
        public void Users()
        {
            Assert.Null(Manager.Users);

            Manager.Start();

            Assert.NotNull(Manager.Users);
        }

        [Fact]
        public void UsersEmpty()
        {
            Configuration.Users = new List<SDK.Security.User>();

            Manager.Start();

            Assert.Empty(Manager.Users);
        }

        #endregion Public Methods

        #region Private Methods

        private void SetupMocks()
        {
            ApplicationManager = new Mock<IApplicationManager>();
            ApplicationManager.Setup(a => a.State).Returns(State.Running);
            ApplicationManager.Setup(a => a.IsInState(State.Starting, State.Running)).Returns(true);
            ApplicationManager.Setup(a => a.Settings).Returns(new Core.ApplicationSettings());

            Configuration = new Core.Security.SecurityManagerConfiguration();
            Configuration.SessionLength = 900;
            Configuration.SessionPurgeInterval = 90000;
            Configuration.SlidingSessions = true;
            Configuration.Users = new[] { new User("test", SDK.Common.Utility.ComputeSHA512Hash("test"), Role.Reader) }.ToList();

            ApplicationConfiguration = new Mock<IConfiguration>();

            ApplicationConfiguration.Setup(
                c => c.GetInstance<Core.Security.SecurityManagerConfiguration>(It.IsAny<Type>()))
                    .Returns(new Result<Core.Security.SecurityManagerConfiguration>().SetReturnValue(Configuration));

            ApplicationConfiguration.Setup(
                c => c.UpdateInstance(It.IsAny<Type>(), It.IsAny<object>()))
                    .Returns(new Result());

            ConfigurationManager = new Mock<IConfigurationManager>();
            ConfigurationManager.Setup(c => c.Configuration).Returns(ApplicationConfiguration.Object);
            ConfigurationManager.Setup(c => c.State).Returns(State.Running);
            ConfigurationManager.Setup(c => c.IsInState(State.Starting, State.Running)).Returns(true);
        }

        #endregion Private Methods
    }
}