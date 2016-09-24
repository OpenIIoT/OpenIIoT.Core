/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀ 
      █   
      █     ▄████████                                                                                        ▄▄▄▄███▄▄▄▄                                                             
      █     ███    ███                                                                                     ▄██▀▀▀███▀▀▀██▄                                                           
      █     ███    ███    █████▄    █████▄  █        █   ▄██████   ▄█████      ██     █   ██████  ██▄▄▄▄   ███   ███   ███   ▄█████  ██▄▄▄▄    ▄█████     ▄████▄     ▄█████    █████ 
      █     ███    ███   ██   ██   ██   ██ ██       ██  ██    ██   ██   ██ ▀███████▄ ██  ██    ██ ██▀▀▀█▄  ███   ███   ███   ██   ██ ██▀▀▀█▄   ██   ██   ██    ▀    ██   █    ██  ██ 
      █   ▀███████████   ██   ██   ██   ██ ██       ██▌ ██    ▀    ██   ██     ██  ▀ ██▌ ██    ██ ██   ██  ███   ███   ███   ██   ██ ██   ██   ██   ██  ▄██        ▄██▄▄     ▄██▄▄█▀ 
      █     ███    ███ ▀██████▀  ▀██████▀  ██       ██  ██    ▄  ▀████████     ██    ██  ██    ██ ██   ██  ███   ███   ███ ▀████████ ██   ██ ▀████████ ▀▀██ ███▄  ▀▀██▀▀    ▀███████ 
      █     ███    ███   ██        ██      ██▌    ▄ ██  ██    ██   ██   ██     ██    ██  ██    ██ ██   ██  ███   ███   ███   ██   ██ ██   ██   ██   ██   ██    ██   ██   █    ██  ██ 
      █     ███    █▀   ▄███▀     ▄███▀    ████▄▄██ █   ██████▀    ██   █▀    ▄██▀   █    ██████   █   █    ▀█   ███   █▀    ██   █▀  █   █    ██   █▀   ██████▀    ███████   ██  ██ 
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄ 
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █ 
      ▄  
      █  Represents the Application and is responsible for managing the various subsystem Managers.
      █  
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀ ▀ ▀▀▀     ▀▀               ▀   
      █  The GNU Affero General Public License (GNU AGPL)
      █  
      █  Copyright (C) 2016 JP Dillingham (jp@dillingham.ws)
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
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using NLog;
using NLog.xLogger;
using Symbiote.Core.Event;
using Utility.OperationResult;

namespace Symbiote.Core
{
    /// <summary>
    /// <para>
    ///     Represents the Application and is responsible for managing the various subsystem Managers.
    /// </para>
    /// <para>
    ///     This class is a singleton and is therefore restricted to one instance for the application.  External classes may invoke the <see cref="Instantiate(Type[])"/> 
    ///     method to retrieve the instance, however they should not.  If the instance is required in a static class or method, or anywhere else where dependency injection
    ///     is not available, the <see cref="GetInstance()"/> method should be used to retrieve the instance.
    /// </para>
    /// <para>
    ///     The <see cref="Instantiate(Type[])"/> method, and thusly the class constructor, accepts an array of <see cref="Type"/>s corresponding to each <see cref="IManager"/> 
    ///     instance to be created.  The Application Manager maintains an internal list of these Types, the instances created (one each), and a dictionary containing the dependencies
    ///     of each Type.
    /// </para>
    /// <para>
    ///     Upon instantiation, the Application Manager invokes <see cref="InstantiateManagers"/> method, which iterates over the list of Types and creates an instance of each using the
    ///     <see cref="InstantiateManager{T}"/> method, then registers the new instance with <see cref="RegisterManager{T}(IManager)"/>.  If all dependencies for a Manager have not yet been
    ///     instantiated when the dependent Manager is instantiated an exception will be thrown; the order in which the Manager Types appear in the Type list provided to the <see cref="Instantiate(Type[])"/> 
    ///     method must reflect the inter-Manager dependencies.  The RegisterManager method adds the Manager instance to the linternal list and creates an entry in the dependency dictionary for the Type.
    /// </para>
    /// <para>
    ///     After all Managers have been instantiated, the list of created instances is iterated over and the <see cref="Manager.Setup"/> method is invoked on each.  This method allows Managers which are dependent
    ///     upon other Managers to initialize those dependencies.  Examples include the <see cref="Configuration.ConfigurationManager"/>, which iterates over the list of Manager instances and registers Managers
    ///     which implement <see cref="Configuration.IConfigurable{T}"/>, and the <see cref="Event.EventManager"/>, which does the same for implementations of <see cref="Event.IEventProvider"/>.
    /// </para>
    /// <para>
    ///     The methods <see cref="GetManager{T}"/> and <see cref="GetManagers"/> are provided to allow Managers to retrieve other Managers contained within the application.  <see cref="GetManager{T}"/> is 
    ///     primarily provided to allow static methods to access a particular manager.  This is the only valid usage; instance methods should use the dependency injection system.  <see cref="GetManagers"/> 
    ///     provides an immutable list of Manager instances which allows for the functionality described above for <see cref="Manager.Setup"/>.  This is necessary so that Managers may access other Managers 
    ///     which are not explicitly defined as dependencies.  Again, this is the only valid usage of the method.
    /// </para>
    /// <para>
    ///     As with other instances of <see cref="IManager"/>, the <see cref="Startup"/> and <see cref="Shutdown(StopType)"/> methods are invoked upon the invocation of <see cref="Manager.Start"/> and
    ///     <see cref="Manager.Stop(StopType)"/>.  The Application Manager uses these methods to start and stop Manager instances.
    /// </para>
    /// </summary>
    public class ApplicationManager : Manager, IApplicationManager
    {
        #region Fields

        /// <summary>
        ///     The Logger for this class.
        /// </summary>
        private static new xLogger logger = (xLogger)LogManager.GetCurrentClassLogger(typeof(xLogger));

        /// <summary>
        ///     The Singleton instance of ApplicationManager.
        /// </summary>
        private static ApplicationManager instance;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApplicationManager"/> class with the specified Manager Types.
        /// </summary>
        /// <param name="managerTypes">The array of Manager Types for the application.</param>
        /// <exception cref="ManagerTypeListException">Thrown when the type list argument for the ApplicationManager constructor is malformed.</exception>
        /// <exception cref="ManagerInstantiationException">Thrown when an error is encountered while instantiating the specified Managers.</exception>
        /// <exception cref="ManagerSetupException">Thrown when an error is encountered while performing setup of the instantiated Managers.</exception> 
        private ApplicationManager(Type[] managerTypes)
        {
            // force the parent logger to this instance due to the way GetCurrentClassLogger works
            base.logger = logger;

            Guid guid = logger.EnterMethod(xLogger.Params((object)managerTypes), true);

            // initialize properties
            ManagerName = "Application Manager";
            ManagerTypes = managerTypes.ToList();
            ManagerInstances = new List<IManager>();
            ManagerDependencies = new Dictionary<Type, List<Type>>();

            // register the ApplicationManager with itself
            RegisterManager<IApplicationManager>(this);
            
            // create an instance of each Manager Type in the ManagerTypes list
            logger.Info("Instantiating Managers...");

            InstantiateManagers(); // throws ManagerInstantiationException

            logger.Info("Managers instantiated successfully.");

            // invoke the setup method for each manager
            logger.Info("Performing Manager Setup...");

            SetupManagers(); // throws ManagerSetupException

            logger.Info("Managers setup successfully.");

            ChangeState(State.Initialized);

            logger.ExitMethod(guid);
        }

        #endregion

        #region Properties

        #region Public Properties

        #region IApplicationManager Properties

        /// <summary>
        ///     Gets the name of the product, retrieved from AssemblyInfo.cs.
        /// </summary>
        public string ProductName
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Name;
            }
        }

        /// <summary>
        ///     Gets the version of the product, retrieved from AssemblyInfo.cs.
        /// </summary>
        public Version ProductVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version;
            }
        }

        /// <summary>
        ///     Gets the name of the application instance, retrieved from the application's settings file.
        /// </summary>
        /// <remarks>
        ///     If the "InstanceName" setting is missing from the application settings, the value of the 
        ///     ProductName property is substituted.
        /// </remarks>
        public string InstanceName
        {
            get
            {
                return GetInstanceName();
            }
        }

        #endregion

        #endregion

        #region Private Properties

        /// <summary>
        ///     Gets or sets the list of application Manager Types.
        /// </summary>
        private List<Type> ManagerTypes { get; set; }

        /// <summary>
        ///     Gets or sets the list of application Manager instances.
        /// </summary>
        private List<IManager> ManagerInstances { get; set; }

        /// <summary>
        ///     Gets or sets a dictionary containing a list of dependencies for each application Manager.
        /// </summary>
        private Dictionary<Type, List<Type>> ManagerDependencies { get; set; }

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        #region Public Static Methods

        #region Settings

        /// <summary>
        ///     Returns the "InstanceName" setting from the app.config file, or the default value if the setting is not retrieved.
        /// </summary>
        /// <returns>The name of the program instance.</returns>
        public static string GetInstanceName()
        {
            return Utility.GetSetting("InstanceName", Assembly.GetExecutingAssembly().GetName().Name);
        }

        #endregion

        /// <summary>
        ///     Returns the singleton instance of the ApplicationManager.  Creates an instance if null.
        /// </summary>
        /// <param name="managers">The array of Manager Types for the application.</param>
        /// <returns>The singleton instance of the ApplicationManager</returns>
        public static ApplicationManager Instantiate(Type[] managers)
        {
            // validate input.  ensure the list of types is not empty and that all types implement IManager.
            if (managers == default(Type[]) || managers.Count() == 0)
            {
                throw new ManagerTypeListException("The supplied list of Types must contain at least one Type.");
            }
            else
            {
                // ensure all types implement IManager.
                if (managers.Where(t => t.GetInterfaces().Contains(typeof(IManager))).Count() != managers.Count())
                {
                    throw new ManagerTypeListException("Each Type in the supplied list of Types must implement the IManager interface.");
                }
            }

            if (instance == null)
            {
                instance = new ApplicationManager(managers);
            }

            return instance;
        }

        /// <summary>
        ///     Returns the Singleton instance of ApplicationManager
        /// </summary>
        /// <remarks>
        ///     Use only in situations where dependency injection is not feasible.
        /// </remarks>
        /// <returns>The Singleton instance of ApplicationManager</returns>
        /// <exception cref="ManagerNotInitializedException">Thrown when a Manager instance is requested but the Manager has not yet been initialized.</exception>
        public static ApplicationManager GetInstance()
        {
            if (instance == null)
            {
                throw new ManagerNotInitializedException("Failed to retrieve the ApplicationManager instance; it has not yet been instantiated.");
            }

            return instance;
        }

        #endregion

        #region Public Instance Methods

        #region IStateful Implementation

        //// See the Manager class for the IStateful implementation for this class.

        #endregion

        #region IManager Implementation

        //// See the Manager class for the IManager implementation for this class.

        #endregion

        #region IApplicationManager Implementation

        /// <summary>
        ///     Returns the Manager from the list of Managers matching the specified Type.
        /// </summary>
        /// <typeparam name="T">The Type of the Manager to return.</typeparam>
        /// <returns>The requested Manager.</returns>
        public T GetManager<T>() where T : IManager
        {
            return ManagerInstances.OfType<T>().FirstOrDefault();
        }

        /// <summary>
        ///     Returns an immutable list of Managers.
        /// </summary>
        /// <returns>The immutable list of Managers.</returns>
        public ImmutableList<IManager> GetManagers()
        {
            return ManagerInstances.ToImmutableList();
        }

        #endregion

        #endregion

        #endregion

        #region Protected Methods

        #region Protected Instance Methods

        /// <summary>
        ///     Executed upon startup of the Manager.  Starts all application managers.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        protected override Result Startup()
        {
            Guid guid = logger.EnterMethod(true);
            logger.Debug("Performing Startup for '" + GetType().Name + "'...");
            Result retVal = new Result();

            // start all application managers.
            retVal.Incorporate(StartManagers());

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(guid);
            return retVal;
        }

        /// <summary>
        ///     Executed upon shutdown of the Manager.  Stops all application managers.
        /// </summary>
        /// <param name="stopType">The nature of the stoppage.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        protected override Result Shutdown(StopType stopType = StopType.Stop)
        {
            Guid guid = logger.EnterMethod(true);
            logger.Debug("Performing Shutdown for '" + GetType().Name + "'...");
            Result retVal = new Result();

            retVal.Incorporate(StopManagers());

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(guid);
            return retVal;
        }

        #endregion

        #endregion

        #region Private Methods

        #region Private Instance Methods

        #region Event Handlers

        /// <summary>
        ///     Event handler for the StateChanged event of registered Managers.
        /// </summary>
        /// <param name="sender">The Manager which fired the event.</param>
        /// <param name="e">The EventArgs for the event.</param>
        private void ManagerStateChanged(object sender, StateChangedEventArgs e)
        {
            logger.Info("Manager '" + sender.GetType().Name + "' state changed from '" + e.PreviousState + "' to '" + e.State + "'." + (e.Message != string.Empty ? "(" + e.Message + ")" : string.Empty));
        }

        #endregion

        /// <summary>
        ///     Iterates over the list of <see cref="IManager"/> Types and instantiates each in the order in which they are represented in the list.
        /// </summary>
        /// <exception cref="MissingMethodException">Thrown when a reflected method can not be found.</exception>
        /// <exception cref="ManagerInstantiationException">Thrown when the instantiation of a Manager returns an abnormal result.</exception>
        private void InstantiateManagers()
        {
            logger.EnterMethod();
            logger.Trace("Instantiating Managers...");

            // iterate over the list
            foreach (Type managerType in ManagerTypes)
            {
                logger.SubHeading(LogLevel.Debug, managerType.Name);
                logger.Debug("Instantiating '" + managerType.Name + "'...");

                // find the InstantiateManager() method so that we can invoke it via reflection
                MethodInfo instantiateMethod = GetType().GetMethod("InstantiateManager", BindingFlags.NonPublic | BindingFlags.Instance);
                if (instantiateMethod == default(MethodInfo))
                {
                    throw new MissingMethodException("Failed to find the 'InstantiateManager' method within the '" + GetType().Name + "' class.");
                }

                // create a generic method using the current Type and invoke it
                MethodInfo genericInstantiateMethod = instantiateMethod.MakeGenericMethod(managerType);
                IManager manager = (IManager)genericInstantiateMethod.Invoke(this, null);

                // ensure the resulting IManager is valid
                if (manager != default(IManager))
                {
                    logger.Debug("Successfully instantiated '" + manager.GetType().Name + "'.  Registering...");

                    // find the RegisterManager() method and make sure it was found
                    MethodInfo registerMethod = GetType().GetMethod("RegisterManager", BindingFlags.NonPublic | BindingFlags.Instance, null, CallingConventions.Any, new Type[] { typeof(IManager) }, null);
                    if (registerMethod == default(MethodInfo))
                    {
                        throw new MissingMethodException("Failed to find the 'RegisterManager' method within the '" + GetType().Name + "' class.");
                    }

                    // create a generic method using the current Type and invoke it
                    MethodInfo genericRegisterMethod = registerMethod.MakeGenericMethod(managerType);
                    genericRegisterMethod.Invoke(this, new object[] { manager });

                    logger.Debug("Successfully registered '" + manager.GetType().Name + "'.");
                }
                else
                {
                    throw new ManagerInstantiationException("Instantiation of Manager '" + managerType.Name + "' returned an abnormal response.");
                }
            }

            logger.ExitMethod();
        }

        /// <summary>
        ///     Creates and returns an instance of the specified <see cref="IManager"/> Type.
        /// </summary>
        /// <typeparam name="T">The Type of the Manager to instantiate.</typeparam>
        /// <returns>The instantiated IManager.</returns>
        /// <exception cref="MissingMethodException">Thrown when a reflected method can not be found.</exception>
        /// <exception cref="ManagerInstantiationException">Thrown when an error is encountered while instantiating the specified Manager Type.</exception>
        private T InstantiateManager<T>() where T : IManager
        {
            logger.EnterMethod(xLogger.TypeParams(typeof(T)));
            logger.Trace("Creating new instance of '" + typeof(T).Name + "'...");

            T instance;

            try
            {
                // use reflection to locate the static Instantiate() method, then check to make sure it was found.
                MethodInfo method = typeof(T).GetMethod("Instantiate", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
                if (method == default(MethodInfo))
                {
                    throw new MissingMethodException("Method 'Instantiate' not found in class '" + typeof(T).Name + "'.");
                }

                // use reflection to locate the static ResolveManagerDependencies() method, then check to make sure it was found.
                MethodInfo resolveMethod = GetType().GetMethod("ResolveManagerDependencies", BindingFlags.NonPublic | BindingFlags.Instance);
                if (resolveMethod == default(MethodInfo))
                {
                    throw new MissingMethodException("Method 'ResolveManagerDependencies' was not found in class '" + GetType().Name + "'.");
                }

                // make a generic version of ResolveManagerDependencies() using the specified type, then invoke it and
                // check the result to ensure it is valid.
                MethodInfo genericResolveMethod = resolveMethod.MakeGenericMethod(typeof(T));
                List<IManager> resolvedDependencies = (List<IManager>)genericResolveMethod.Invoke(this, new object[] { });
                if (resolvedDependencies == default(List<IManager>))
                {
                    throw new ManagerInstantiationException("Failed to resolve Manager dependencies for '" + typeof(T) + "'.");
                }

                // invoke the Instantiate() method and pass the resolved dependencies from the step above.
                // store the result in instance, then check to make sure it is not null and ensure that it implements IManager.
                instance = (T)method.Invoke(null, resolvedDependencies.ToArray());
                if (instance == null)
                {
                    throw new ManagerInstantiationException("Instantiate() method invocation from '" + typeof(T).Name + "' returned no result.");
                }
                else if (!(instance is IManager))
                {
                    throw new ManagerInstantiationException("The instance returned by Instantiate() method invocation from '" + typeof(T).Name + "' does not implement the IManager interface.");
                }

                logger.Trace("Successfully instantiated '" + instance.GetType().Name + "'.");
            }
            catch (Exception ex)
            {
                logger.Exception(ex);
                throw new ManagerInstantiationException("Error instantiating Manager '" + typeof(T).Name + "'.  See inner exception for details.", ex);
            }

            logger.ExitMethod();
            return instance;
        }

        /// <summary>
        ///     Iterates over the list of <see cref="IManager"/> instances and invokes the <see cref="Manager.Setup"/> method on each.
        /// </summary>
        /// <exception cref="ManagerSetupException">Thrown when an error is encountered during the setup operation.</exception>
        private void SetupManagers()
        {
            logger.EnterMethod();
            logger.Trace("Setting Managers up...");
            logger.Heading(LogLevel.Debug, "Setup");

            try
            {
                // iterate over the list of Manager instances
                foreach (IManager manager in ManagerInstances)
                {
                    logger.SubHeading(LogLevel.Debug, manager.ManagerName);
                    SetupManager(manager);
                }
            }
            catch (Exception ex)
            {
                throw new ManagerSetupException("Error encountered while performing Manager setup.  See inner exception for details.", ex);
            }

            logger.ExitMethod();
        }

        /// <summary>
        ///     Invokes the <see cref="Manager.Setup"/> method on the specified instance of <see cref="IManager"/>.
        /// </summary>
        /// <param name="manager">The IManager instance for which to invoke Setup().</param>
        /// <exception cref="MissingMethodException">Thrown when the 'Setup' method within the specified IManager instance can not be found.</exception>
        /// <exception cref="ManagerSetupException">Thrown when the 'Setup' method invocation throws an exception.</exception>
        private void SetupManager(IManager manager)
        {
            logger.EnterMethod();
            logger.Debug("Performing Setup for Manager '" + manager.GetType() + "'...");

            MethodInfo method = manager.GetType().GetMethod("Setup", BindingFlags.Instance | BindingFlags.NonPublic);

            if (method == default(MethodInfo))
            {
                throw new MissingMethodException("Unable to find method 'Setup()' in Type '" + manager.GetType() + "'.");
            }

            try
            {
                method.Invoke(manager, null);
            }
            catch (Exception ex)
            {
                throw new ManagerSetupException("Error setting Manager '" + manager.GetType() + "' up.  See inner exception for details.", ex);
            }

            logger.Debug("Setup performed successfully.");
            logger.ExitMethod();
        }

        /// <summary>
        ///     Starts each <see cref="IManager"/>  contained within the specified list of Manager instances.
        /// </summary>
        /// <remarks>
        ///     Does not Start the ApplicationManager instance.
        /// </remarks>
        /// <returns>A Result containing the result of the operation.</returns>
        private Result StartManagers()
        {
            Guid guid = logger.EnterMethod(true);
            logger.Debug("Starting Managers...");
            Result retVal = new Result();

            // iterate over the Manager instance list and start each manager.
            // skip the ApplicationManager as it has already been started.
            foreach (IManager manager in ManagerInstances)
            {
                if (manager != this)
                {
                    logger.SubHeading(LogLevel.Debug, manager.GetType().Name);
                    retVal.Incorporate(StartManager(manager));

                    if (retVal.ResultCode == ResultCode.Failure)
                    {
                        return retVal.AddError("Failed to start one or more Managers.");
                    }
                }
            }

            retVal.LogResult(logger);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        /// <summary>
        ///     Starts the specified <see cref="IManager"/> instance
        /// </summary>
        /// <param name="manager">The IManager instance to start.</param>
        /// <returns>A Result containing the result of the operation and the specified IManager instance.</returns>
        private Result<IManager> StartManager(IManager manager)
        {
            Guid guid = logger.EnterMethod(xLogger.Params(manager), true);
            logger.Debug("Starting " + manager.GetType().Name + "...");
            Result<IManager> retVal = new Result<IManager>();

            // invoke the Start() method on the specified manager
            Result startResult = manager.Start();

            // if the manager fails to start, throw an exception and halt the program
            if (startResult.ResultCode == ResultCode.Failure)
            {
                retVal.AddError("Failed to start Manager '" + manager.GetType().Name + "'.");
            }

            retVal.ReturnValue = manager;
            retVal.Incorporate(startResult);

            if (retVal.ResultCode != ResultCode.Failure)
            {
                logger.Debug("Successfully started " + manager.GetType().Name + ".");
            }
            else
            {
                logger.Debug("Failed to start " + manager.GetType().Name + ": " + retVal.GetLastError());
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        /// <summary>
        ///     Stops each of the <see cref="IManager"/> instances in the specified Manager instance list.
        /// </summary>
        /// <remarks>
        ///     Does not Stop the ApplicationManager instance.
        /// </remarks>
        /// <param name="stopType">The type of stoppage.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        private Result StopManagers(StopType stopType = StopType.Stop)
        {
            Guid guid = logger.EnterMethod();
            logger.Debug("Stopping Managers...");
            Result retVal = new Result();

            // iterate over the Manager instance list in reverse order, stopping each manager.
            // skip the ApplicationManager as it will stop when this process is complete.
            for (int i = ManagerInstances.Count() - 1; i >= 0; i--)
            {
                logger.SubHeading(LogLevel.Debug, ManagerInstances[i].GetType().Name);
                if (ManagerInstances[i] != this)
                {
                    retVal.Incorporate(StopManager(ManagerInstances[i], StopType.Shutdown));
                }
            }

            retVal.LogResult(logger);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        /// <summary>
        ///     Stops the specified IManager instance.
        /// </summary>
        /// <param name="manager">The IManager instance to stop.</param>
        /// <param name="stopType">The type of stoppage.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        private Result StopManager(IManager manager, StopType stopType = StopType.Stop)
        {
            Guid guid = logger.EnterMethod(xLogger.Params(manager, stopType), true);
            logger.Debug("Stopping " + manager.GetType().Name + "...");

            Result retVal = manager.Stop(stopType);

            if (retVal.ResultCode == ResultCode.Failure)
            {
                retVal.AddError("Failed to stop " + manager.GetType().Name + "." + retVal.GetLastError());
            }

            retVal.LogResult(logger);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        /// <summary>
        ///     Adds the specified <see cref="IManager"/> to the Manager list and subscribes to its <see cref="Manager.StateChanged"/> event.
        /// </summary>
        /// <typeparam name="T">The Type of the specified Manager.</typeparam>
        /// <param name="manager">The Manager to register.</param>
        /// <returns>The registered Manager.</returns>
        /// <exception cref="ManagerRegistrationException">Thrown when an error is encountered during registration.</exception>
        private T RegisterManager<T>(IManager manager) where T : IManager
        {
            logger.EnterMethod(xLogger.TypeParams(typeof(T)), xLogger.Params(manager));
            logger.Trace("Registering Manager '" + manager.GetType().Name + "'...");

            // ensure the specified Manager hasn't already been registered.  There can only be one of each Type
            // in the Manager list.
            if (IsRegistered<T>())
            {
                throw new ManagerRegistrationException("The Manager '" + manager.GetType().Name + "' is already registered.");
            }

            try
            {
                // retrieve the dependencies for the Manager
                List<Type> dependencies = GetManagerDependencies<T>();

                if (dependencies == default(List<Type>))
                {
                    throw new ManagerRegistrationException("The dependency list for the Manager '" + manager.GetType().Name + "' is empty; all Managers must have at least one dependency.");
                }

                logger.Trace("Registering Manager with " + dependencies.Count() + " dependencies...");

                // add the specified Manager to the list and attach an event handler to its StateChanged event
                ManagerInstances.Add(manager);
                ManagerDependencies.Add(typeof(T), dependencies);
                manager.StateChanged += ManagerStateChanged;
            }
            catch (Exception ex)
            {
                logger.Exception(ex);
                throw new ManagerRegistrationException("Failed to register Manager '" + manager.GetType().Name + "': " + ex.Message, ex);
            }

            logger.Trace("Successfully registered Manager '" + manager.GetType().Name + "'.");

            logger.ExitMethod();
            return (T)manager;
        }
        
        /// <summary>
        ///     Searches the list of registered <see cref="IManager"/> instances for the specified instance and returns a value indicating
        ///     whether it was found.
        /// </summary>
        /// <typeparam name="T">The Manager Type to check.</typeparam>
        /// <returns>A value indicating whether the specified Manager has been registered.</returns>
        private bool IsRegistered<T>() where T : IManager
        {
            return ManagerInstances.OfType<T>().Count() > 0;
        }

        /// <summary>
        ///     Retrieves the list of <see cref="Type"/>s corresponding to the <see cref="IManager"/> Types on which the specified Manager Type depends.
        /// </summary>
        /// <remarks>
        ///     Uses reflection to retrieve the parameters for the private Instantiate() method of the specified Type.
        /// </remarks>
        /// <typeparam name="T">The Type of the Manager for which the dependencies are to be returned.</typeparam>
        /// <returns>A List of dependency Types.</returns>
        /// <exception cref="MissingMethodException">Thrown when the Instantiate() method is not found within the specified Type.</exception>
        /// <exception cref="ManagerDependencyException">Thrown when an exception is caught while retrieving the dependencies for the specified Type.</exception>
        private List<Type> GetManagerDependencies<T>() where T : IManager
        {
            logger.EnterMethod(xLogger.TypeParams(typeof(T)));
            logger.Trace("Retrieving dependencies for '" + typeof(T).Name + "'...");
            List<Type> retVal = new List<Type>();

            // the ApplicationManager has no dependencies (that we need to track).
            if (typeof(T) == typeof(IApplicationManager))
            {
                return retVal;
            }

            try
            {
                // retrieve the list of parameters for the Instantiate() method of the specified Manager Type and add the type of each to the return value list
                // start by fetching the method.  throw an exception if it is not found.
                MethodInfo method = typeof(T).GetMethod("Instantiate", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);

                if (method == default(MethodInfo))
                {
                    throw new MissingMethodException("Unable to find the Instantiate() method in Type '" + typeof(T).Name + "'.");
                }

                // fetch the parameters. throw an exception if there isn't at least one (each Manager depends on ApplicationManager at a minimum.)
                ParameterInfo[] parameters = method.GetParameters();

                if (parameters.Length == 0)
                {
                    throw new ManagerDependencyException("The Instantiate method of the '" + typeof(T).Name + "' manager contains no dependencies.");
                }

                foreach (ParameterInfo p in parameters)
                {
                    retVal.Add(p.ParameterType);
                }
            }
            catch (Exception ex)
            {
                logger.Exception(ex);
                throw new ManagerDependencyException("Error retrieving dependencies for '" + typeof(T).Name + "'.  See inner exception for details.", ex);
            }

            logger.Trace("Retrieved " + retVal.Count() + " dependenc" + (retVal.Count() == 1 ? "y" : "ies") + ".");

            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Returns a list of IManager instances corresponding to the Manager Types upon which the specified Manager is dependent.
        /// </summary>
        /// <typeparam name="T">The Manager Type for which the dependencies are to be resolved.</typeparam>
        /// <returns>A list of IManager instances corresponding to the Manager Types upon which the specified Manager is dependent.</returns>
        /// <exception cref="MissingMethodException">Thrown when the 'GetManager()' method can not be found.</exception>
        /// <exception cref="ManagerDependencyException">Thrown when an exception is caught while resolving the dependencies for the specified Manager Type.</exception>
        private List<IManager> ResolveManagerDependencies<T>() where T : IManager
        {
            logger.EnterMethod(xLogger.TypeParams(typeof(T)));
            logger.Trace("Resolving dependencies for '" + typeof(T).Name + "'...");
            List<IManager> retVal = new List<IManager>();

            try
            {
                // find the GetManager() method and check to ensure it was found
                MethodInfo getManager = GetType().GetMethod("GetManager", BindingFlags.Public | BindingFlags.Instance);
                if (getManager == default(MethodInfo))
                {
                    throw new MissingMethodException("Method 'GetManager' was not found in class '" + GetType().Name + "'.");
                }

                MethodInfo getManagerGeneric;

                // retrieve dependencies for the specified Manager
                // any instance of IManager needs to have at least one dependency (ApplicationManager).  If we get a null or empty list something is wrong.
                List<Type> dependencies = GetManagerDependencies<T>();
                if ((dependencies == default(List<Type>)) || (dependencies.Count() == 0))
                {
                    throw new ManagerDependencyException("Failed to retrieve dependencies for '" + typeof(T).Name + "'.  Method 'GetManagerDependencies()' returned a null or empty List.");
                }

                // iterate over the dependencies
                foreach (Type t in dependencies)
                {
                    logger.Trace("Attempting to resolve dependency '" + t.Name + "'...");

                    IManager manager;

                    getManagerGeneric = getManager.MakeGenericMethod(t);

                    manager = (IManager)getManagerGeneric.Invoke(this, new object[] { });

                    if ((IManager)manager == default(IManager))
                    {
                        throw new ManagerDependencyException("Invocation of method 'GetManager<T>' returned a null instance of IManager.");
                    }

                    logger.Trace("Successfully resolved depencency '" + t.Name + "'.");
                    retVal.Add(manager);
                }
            }
            catch (Exception ex)
            {
                logger.Exception(ex);
                throw new ManagerDependencyException("Error resolving dependencies for '" + typeof(T).Name + "'.  See inner exception for details.", ex);
            }

            logger.Trace("Resolved " + retVal.Count() + " dependenc" + (retVal.Count() == 1 ? "y" : "ies" + "."));

            logger.ExitMethod(retVal.Select(d => d.GetType()));
            return retVal;
        }

        #endregion

        #endregion

        #endregion
    }
}
