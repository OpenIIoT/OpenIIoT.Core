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
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Manages the security subsystem.
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
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using NLog.xLogger;
using OpenIIoT.Core.Common;
using OpenIIoT.SDK;
using OpenIIoT.SDK.Common;
using OpenIIoT.SDK.Common.Discovery;
using OpenIIoT.SDK.Common.Exceptions;
using OpenIIoT.SDK.Common.Provider.EventProvider;
using OpenIIoT.SDK.Configuration;
using OpenIIoT.SDK.Security;
using Utility.OperationResult;

namespace OpenIIoT.Core.Security
{
    /// <summary>
    ///     Manages the security subsystem.
    /// </summary>
    [Discoverable]
    public class SecurityManager : Manager, ISecurityManager, IConfigurable<SecurityManagerConfiguration>
    {
        #region Private Fields

        /// <summary>
        ///     The Singleton instance of PlatformManager.
        /// </summary>
        private static ISecurityManager instance;

        /// <summary>
        ///     The Logger for this class.
        /// </summary>
        private static new xLogger logger = xLogManager.GetCurrentClassxLogger();

        /// <summary>
        ///     The lock for the <see cref="Session"/> collection.
        /// </summary>
        private ReaderWriterLockSlim sessionLock = new ReaderWriterLockSlim();

        #endregion Private Fields

        #region Private Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="SecurityManager"/> class.
        /// </summary>
        /// <param name="manager">The IApplicationManager instance for the application.</param>
        /// <param name="configurationManager">The IConfigurationManager instance for the application.</param>
        private SecurityManager(IApplicationManager manager, IConfigurationManager configurationManager)
        {
            base.logger = logger;
            Guid guid = logger.EnterMethod();

            ManagerName = "Security Manager";
            EventProviderName = GetType().Name;

            RegisterDependency<IApplicationManager>(manager);
            RegisterDependency<IConfigurationManager>(configurationManager);

            SessionFactory = new SessionFactory();
            SessionList = new List<Session>();

            ChangeState(State.Initialized);

            logger.ExitMethod(guid);
        }

        #endregion Private Constructors

        #region Public Events

        /// <summary>
        ///     Occurs when a Session is ended.
        /// </summary>
        [Event(Description = "Occurs when a Session is ended.")]
        public event EventHandler<SessionEventArgs> SessionEnded;

        /// <summary>
        ///     Occurs when a Session is started.
        /// </summary>
        [Event(Description = "Occurs when a Session is started.")]
        public event EventHandler<SessionEventArgs> SessionStarted;

        /// <summary>
        ///     Occurs when a User is created.
        /// </summary>
        [Event(Description = "Occurs when a User is created.")]
        public event EventHandler<UserEventArgs> UserCreated;

        /// <summary>
        ///     Occurs when a User is deleted.
        /// </summary>
        [Event(Description = "Occurs when a User is deleted.")]
        public event EventHandler<UserEventArgs> UserDeleted;

        /// <summary>
        ///     Occurs when a User is updated.
        /// </summary>
        [Event(Description = "Occurs when a User is updated.")]
        public event EventHandler<UserEventArgs> UserUpdated;

        #endregion Public Events

        #region Public Properties

        /// <summary>
        ///     Gets the Configuration for the Manager.
        /// </summary>
        public SecurityManagerConfiguration Configuration { get; private set; }

        /// <summary>
        ///     Gets the list of built-in User <see cref="Role"/> s.
        /// </summary>
        public IReadOnlyList<Role> Roles => new[] { Role.Reader, Role.ReadWriter, Role.Administrator }.ToList();

        /// <summary>
        ///     Gets the list of active <see cref="Session"/> s.
        /// </summary>
        public IReadOnlyList<Session> Sessions => ((List<Session>)SessionList).AsReadOnly();

        /// <summary>
        ///     Gets the list of configured <see cref="User"/> s.
        /// </summary>
        public IReadOnlyList<User> Users => ((List<User>)Configuration?.Users)?.AsReadOnly();

        #endregion Public Properties

        #region Private Properties

        /// <summary>
        ///     Gets or sets the <see cref="System.Timers.Timer"/> used to purge expired <see cref="Sessions"/>.
        /// </summary>
        private System.Timers.Timer SessionExpiryTimer { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="SessionFactory"/> used to create and extend <see cref="Session"/>.
        /// </summary>
        private SessionFactory SessionFactory { get; set; }

        /// <summary>
        ///     Gets or sets the list of active <see cref="Session"/> s.
        /// </summary>
        private IList<Session> SessionList { get; set; }

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        ///     Returns the ConfigurationDefinition for the Model Manager.
        /// </summary>
        /// <returns>The ConfigurationDefinition for the Model Manager.</returns>
        public static IConfigurationDefinition GetConfigurationDefinition()
        {
            ConfigurationDefinition retVal = new ConfigurationDefinition();
            retVal.Form = "[\"name\",\"email\",{\"key\":\"comment\",\"type\":\"textarea\",\"placeholder\":\"Make a comment\"},{\"type\":\"submit\",\"style\":\"btn-info\",\"title\":\"OK\"}]";
            retVal.Schema = "{\"type\":\"object\",\"title\":\"Comment\",\"properties\":{\"name\":{\"title\":\"Name\",\"type\":\"string\"},\"email\":{\"title\":\"Email\",\"type\":\"string\",\"pattern\":\"^\\\\S+@\\\\S+$\",\"description\":\"Email will be used for evil.\"},\"comment\":{\"title\":\"Comment\",\"type\":\"string\",\"maxLength\":20,\"validationMessage\":\"Don\'t be greedy!\"}},\"required\":[\"name\",\"email\",\"comment\"]}";
            retVal.Model = typeof(SecurityManagerConfiguration);

            SecurityManagerConfiguration config = new SecurityManagerConfiguration();
            config.SessionLength = SecurityConstants.DefaultSessionLength;
            config.SlidingSessions = SecurityConstants.DefaultSlidingSessions;
            config.SessionPurgeInterval = SecurityConstants.DefaultSessionPurgeInterval;

            config.Users.Add(new User(SecurityConstants.DefaultUserName, SecurityConstants.DefaultUserPasswordHash, Role.Administrator));

            retVal.DefaultConfiguration = config;

            return retVal;
        }

        /// <summary>
        ///     Instantiates and/or returns the SecurityManager instance.
        /// </summary>
        /// <remarks>
        ///     Invoked via reflection from ApplicationManager. The parameters are used to build an array of IManager parameters
        ///     which are then passed to this method. To specify additional dependencies simply insert them into the parameter list
        ///     for the method and they will be injected when the method is invoked.
        /// </remarks>
        /// <param name="manager">The IApplicationManager instance for the application.</param>
        /// <param name="configurationManager">The IConfigurationManager instance for the application.</param>
        /// <returns>The Singleton instance of PlatformManager.</returns>
        public static ISecurityManager Instantiate(IApplicationManager manager, IConfigurationManager configurationManager)
        {
            if (instance == null)
            {
                instance = new SecurityManager(manager, configurationManager);
            }

            return instance;
        }

        /// <summary>
        ///     Terminates Singleton instance of PlatformManager.
        /// </summary>
        public static void Terminate()
        {
            instance = null;
        }

        /// <summary>
        ///     Configures the Manager using the configuration stored in the Configuration Manager, or, failing that, using the
        ///     default configuration.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        public IResult Configure()
        {
            logger.EnterMethod();
            logger.Debug("Attempting to Configure with the configuration from the Configuration Manager...");
            Result retVal = new Result();

            IResult<SecurityManagerConfiguration> fetchResult = Dependency<IConfigurationManager>().Configuration.GetInstance<SecurityManagerConfiguration>(GetType());

            // if the fetch succeeded, configure this instance with the result.
            if (fetchResult.ResultCode != ResultCode.Failure)
            {
                logger.Debug("Successfully fetched the configuration from the Configuration Manager.");
                Configure(fetchResult.ReturnValue);
            }
            else
            {
                // if the fetch failed, add a new default instance to the configuration and try again.
                logger.Debug("Unable to fetch the configuration.  Adding the default configuration to the Configuration Manager...");
                IResult<SecurityManagerConfiguration> createResult = Dependency<IConfigurationManager>().Configuration.AddInstance<SecurityManagerConfiguration>(GetType(), GetConfigurationDefinition().DefaultConfiguration);
                if (createResult.ResultCode != ResultCode.Failure)
                {
                    logger.Debug("Successfully added the configuration.  Configuring...");
                    Configure(createResult.ReturnValue);
                }

                retVal.Incorporate(createResult);
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Configures the Manager using the supplied configuration, then saves the configuration to the Model Manager.
        /// </summary>
        /// <param name="configuration">The configuration with which the Manager should be configured.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public IResult Configure(SecurityManagerConfiguration configuration)
        {
            logger.EnterMethod(xLogger.Params(configuration));

            Result retVal = new Result();

            Configuration = configuration;

            logger.Debug("Successfully configured the Manager.");

            logger.Debug("Saving the new configuration...");
            retVal.Incorporate(SaveConfiguration());

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Creates a new <see cref="User"/>.
        /// </summary>
        /// <param name="name">The name of the new User.</param>
        /// <param name="password">The plaintext password for the new User.</param>
        /// <param name="role">The Role for the new User.</param>
        /// <returns>A Result containing the result of the operation and the newly created User.</returns>
        public IResult<User> CreateUser(string name, string password, Role role)
        {
            logger.EnterMethod(xLogger.Params(name, xLogger.Exclude(), role));
            logger.Info($"Creating new User '{name}' with Role '{role}'...");

            IResult<User> retVal = new Result<User>();
            retVal.ReturnValue = default(User);

            if (State != State.Running)
            {
                retVal.AddError($"The Manager is not in a state in which it can service requests (Currently {State}).");
            }
            else if (string.IsNullOrEmpty(name))
            {
                retVal.AddError("The specified name is null or empty.");
            }
            else if (string.IsNullOrEmpty(password))
            {
                retVal.AddError("The specified password is null or empty.");
            }
            else
            {
                if (FindUser(name) == default(User))
                {
                    retVal.ReturnValue = new User(name, SDK.Common.Utility.ComputeSHA512Hash(password), role);
                    Configuration.Users.Add(retVal.ReturnValue);
                    SaveConfiguration();
                }
                else
                {
                    retVal.AddError($"The User '{name}' already exists.");
                }
            }

            if (retVal.ResultCode == ResultCode.Failure)
            {
                retVal.AddError($"Failed to create User '{name}'.");
            }
            else
            {
                Task.Run(() => UserCreated?.Invoke(this, new UserEventArgs(retVal.ReturnValue)));
            }

            retVal.LogResult(logger);
            logger.ExitMethod();
            return retVal;
        }

        /// <summary>
        ///     Deletes the specified <see cref="User"/>.
        /// </summary>
        /// <param name="name">The name of the User to delete.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public IResult DeleteUser(string name)
        {
            logger.EnterMethod(xLogger.Params(name));
            logger.Info($"Deleting User '{name}'...");

            IResult retVal = new Result();
            User foundUser = default(User);

            if (State != State.Running)
            {
                retVal.AddError($"The Manager is not in a state in which it can service requests (Currently {State}).");
            }
            else
            {
                foundUser = FindUser(name);

                if (foundUser != default(User))
                {
                    Configuration.Users.Remove(foundUser);
                }
                else
                {
                    retVal.AddError($"The User '{name}' does not exist.");
                }
            }

            if (retVal.ResultCode == ResultCode.Failure)
            {
                retVal.AddError($"Failed to delete User '{name}'.");
            }
            else
            {
                Task.Run(() => UserDeleted?.Invoke(this, new UserEventArgs(foundUser)));
            }

            retVal.LogResult(logger);
            logger.ExitMethod();
            return retVal;
        }

        /// <summary>
        ///     Ends the specified <see cref="Session"/>.
        /// </summary>
        /// <param name="session">The Session to end.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public IResult EndSession(Session session)
        {
            logger.EnterMethod();
            logger.Debug($"Ending Session '{session?.Token}'...");

            IResult retVal = new Result();
            Session foundSession = default(Session);

            if (State != State.Running)
            {
                retVal.AddError($"The Manager is not in a state in which it can service requests (Currently {State}).");
            }
            else
            {
                foundSession = FindSession(session?.Token);

                if (foundSession != default(Session))
                {
                    sessionLock.EnterWriteLock();

                    try
                    {
                        SessionList.Remove(foundSession);
                    }
                    finally
                    {
                        sessionLock.ExitWriteLock();
                    }
                }
                else
                {
                    retVal.AddError($"The Session matching Token '{session?.Token}' does not exist.");
                }
            }

            if (retVal.ResultCode == ResultCode.Failure)
            {
                retVal.AddError($"Failed to end Session.");
            }
            else
            {
                Task.Run(() => SessionEnded?.Invoke(this, new SessionEventArgs(foundSession)));
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod();
            return retVal;
        }

        /// <summary>
        ///     Extends the specified <see cref="Session"/> to the configured session length.
        /// </summary>
        /// <param name="session">The Session to extend.</param>
        /// <returns>A Result containing the result of the operation and the extended Session.</returns>
        public IResult<Session> ExtendSession(Session session)
        {
            logger.EnterMethod();
            logger.Trace($"Extending Session '{session?.Token}'...");

            IResult<Session> retVal = new Result<Session>();
            Session foundSession = default(Session);

            if (State != State.Running)
            {
                retVal.AddError($"The Manager is not in a state in which it can service requests (Currently {State}).");
            }
            else
            {
                foundSession = FindSession(session?.Token);
                if (foundSession != default(Session))
                {
                    if (Configuration.SlidingSessions)
                    {
                        if (!foundSession.IsExpired)
                        {
                            retVal.ReturnValue = SessionFactory.ExtendSession(foundSession, Configuration.SessionLength);
                        }
                        else
                        {
                            retVal.AddError($"Session has expired and can not be extended.");
                        }
                    }
                    else
                    {
                        retVal.AddWarning($"Sliding sessions are not enabled; the Session has not been extended.");
                    }
                }
                else
                {
                    retVal.AddError($"Session matching Token '{session?.Token}' does not exist.");
                }
            }

            if (retVal.ResultCode == ResultCode.Failure)
            {
                retVal.AddError($"Failed to extend Session.");
            }

            retVal.LogResult(logger.Trace);
            logger.ExitMethod();
            return retVal;
        }

        /// <summary>
        ///     Finds the <see cref="Session"/> matching the specified <paramref name="token"/>.
        /// </summary>
        /// <param name="token">The token for the requested Session.</param>
        /// <returns>The found Session.</returns>
        public Session FindSession(string token)
        {
            return SessionList
                .Where(s => s.Ticket.Identity.Claims
                    .Where(c => c.Type == ClaimTypes.Hash).FirstOrDefault().Value == token).FirstOrDefault();
        }

        /// <summary>
        ///     Finds the <see cref="User"/> matching the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the requested User.</param>
        /// <returns>The found User.</returns>
        public User FindUser(string name)
        {
            return Configuration?.Users?.Where(u => u.Name == name).FirstOrDefault();
        }

        /// <summary>
        ///     Finds the <see cref="Session"/> belonging to the specified <see paramref="name"/>.
        /// </summary>
        /// <param name="name">The name of the <see cref="User"/> for which the Session is to be retrieved.</param>
        /// <returns>The found Session.</returns>
        public Session FindUserSession(string name)
        {
            return SessionList
                .Where(s => s.Ticket.Identity.Claims
                    .Where(c => c.Type == ClaimTypes.Name).FirstOrDefault().Value == name).FirstOrDefault();
        }

        /// <summary>
        ///     Saves the configuration to the Configuration Manager.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        public IResult SaveConfiguration()
        {
            logger.EnterMethod();
            Result retVal = new Result();

            retVal.Incorporate(Dependency<IConfigurationManager>().Configuration.UpdateInstance(this.GetType(), Configuration));

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Starts a new <see cref="Session"/> with the specified <paramref name="userName"/> and <paramref name="password"/>
        /// </summary>
        /// <param name="userName">The user for which the Session is to be started.</param>
        /// <param name="password">The password with which to authenticate the user.</param>
        /// <returns>A Result containing the result of the operation and the created Session.</returns>
        public IResult<Session> StartSession(string userName, string password)
        {
            logger.EnterMethod(xLogger.Params(userName, xLogger.Exclude()));
            logger.Info($"Starting Session for User '{userName}'...");

            IResult<Session> retVal = new Result<Session>();

            if (State != State.Running)
            {
                retVal.AddError($"The Manager is not in a state in which it can service requests (Currently {State}).");
            }
            else
            {
                User foundUser = FindUser(userName);

                if (foundUser != default(User))
                {
                    string hash = SDK.Common.Utility.ComputeSHA512Hash(password);

                    if (foundUser.PasswordHash == hash)
                    {
                        Session foundSession = FindUserSession(foundUser.Name);

                        if (foundSession == default(Session))
                        {
                            retVal.ReturnValue = SessionFactory.CreateSession(foundUser, Configuration.SessionLength);

                            sessionLock.EnterWriteLock();

                            try
                            {
                                SessionList.Add(retVal.ReturnValue);
                            }
                            finally
                            {
                                sessionLock.ExitWriteLock();
                            }
                        }
                        else
                        {
                            retVal.AddWarning($"The specified User has an existing Session.  The existing Session is being returned.");
                            retVal.ReturnValue = foundSession;
                        }
                    }
                    else
                    {
                        retVal.AddError($"Supplied password does not match.");
                    }
                }
                else
                {
                    retVal.AddError($"User '{userName}' does not exist.");
                }
            }

            if (retVal.ResultCode == ResultCode.Failure)
            {
                retVal.AddError($"Failed to start Session for User '{userName}'.");
            }
            else
            {
                if (retVal.ResultCode == ResultCode.Success)
                {
                    Task.Run(() => SessionStarted?.Invoke(this, new SessionEventArgs(retVal.ReturnValue)));
                }
            }

            retVal.LogResult(logger);
            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Updates the specified <see cref="User"/> with the optionally specified <paramref name="password"/> and/or <paramref name="role"/>.
        /// </summary>
        /// <param name="name">The name of the User to update.</param>
        /// <param name="password">The updated plaintext password for the User.</param>
        /// <param name="role">The updated Role for the user.</param>
        /// <returns>A Result containing the result of the operation and the updated User.</returns>
        public IResult<User> UpdateUser(string name, string password = null, Role? role = null)
        {
            logger.EnterMethod(xLogger.Params(name, xLogger.Exclude(), role));
            logger.Info($"Updating User '{name}'...");

            IResult<User> retVal = new Result<User>();
            User foundUser;

            if (State != State.Running)
            {
                retVal.AddError($"The Manager is not in a state in which it can service requests (Currently {State}).");
            }
            else if (password != null && password == string.Empty)
            {
                retVal.AddError("The specified password is empty.");
            }
            else if (password == null && role == null)
            {
                retVal.AddError("Neither the password nor the Role was specified; nothing to update.");
            }
            else
            {
                foundUser = FindUser(name);

                if (foundUser != default(User))
                {
                    if (password != null)
                    {
                        foundUser.PasswordHash = SDK.Common.Utility.ComputeSHA512Hash(password);
                    }

                    if (role != null)
                    {
                        foundUser.Role = (Role)role;
                    }

                    retVal.ReturnValue = foundUser;
                }
                else
                {
                    retVal.AddError($"User '{name}' does not exist.");
                }
            }

            if (retVal.ResultCode == ResultCode.Failure)
            {
                retVal.AddError($"Failed to update User '{name}'.");
            }
            else
            {
                Task.Run(() => UserUpdated?.Invoke(this, new UserEventArgs(retVal.ReturnValue)));
            }

            retVal.LogResult(logger);
            logger.ExitMethod();
            return retVal;
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        ///     Implements the post-instantiation procedure for the <see cref="SecurityManager"/> class.
        /// </summary>
        /// <remarks>This method is invoked by the ApplicationManager following the instantiation of all program Managers.</remarks>
        /// <exception cref="ManagerSetupException">Thrown when an error is encountered during setup.</exception>
        protected override void Setup()
        {
        }

        /// <summary>
        ///     Implements the shutdown procedure for the <see cref="SecurityManager"/> class.
        /// </summary>
        /// <param name="stopType">The <see cref="StopType"/> enumeration corresponding to the nature of the stoppage.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        protected override IResult Shutdown(StopType stopType = StopType.Stop)
        {
            Guid guid = logger.EnterMethod(true);
            logger.Debug("Performing Shutdown for '" + GetType().Name + "'...");

            IResult retVal = new Result();

            SessionExpiryTimer.Stop();

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        /// <summary>
        ///     Implements the startup procedure for the <see cref="SecurityManager"/> class.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        /// <exception cref="DirectoryException">Thrown when one or more application directories can not be verified.</exception>
        protected override IResult Startup()
        {
            Guid guid = logger.EnterMethod(true);
            logger.Debug("Performing Startup for '" + GetType().Name + "'...");

            IResult retVal = Configure();

            SessionExpiryTimer = new System.Timers.Timer(Configuration.SessionPurgeInterval);
            SessionExpiryTimer.Elapsed += (sender, args) => PurgeExpiredSessions();
            SessionExpiryTimer.Start();

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        ///     Ends any expired <see cref="Session"/> s in the <see cref="SessionList"/>.
        /// </summary>
        private void PurgeExpiredSessions()
        {
            logger.EnterMethod();

            IList<Session> sessions = new List<Session>();

            sessionLock.EnterReadLock();

            try
            {
                sessions = SessionList.ToList();
            }
            finally
            {
                sessionLock.ExitReadLock();
            }

            foreach (Session session in sessions)
            {
                if (session.IsExpired)
                {
                    EndSession(session);
                }
            }

            logger.ExitMethod();
        }

        #endregion Private Methods
    }
}