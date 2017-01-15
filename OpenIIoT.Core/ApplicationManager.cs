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
      █  The ApplicationManager class is responsible for managing the various subsystem Managers.
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
using OpenIIoT.SDK;
using Utility.OperationResult;

namespace OpenIIoT.Core
{
    /// <summary>
    ///     The ApplicationManager class is responsible for managing the various subsystem Managers.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         This class is a Singleton and is therefore restricted to one instance for the application. External classes may
    ///         invoke the <see cref="Instantiate(Type[])"/> method to retrieve the instance, however they should not. If the
    ///         instance is required in a static class or method, or anywhere else where dependency injection is not available, the
    ///         <see cref="GetInstance()"/> method should be used to retrieve the instance.
    ///     </para>
    ///     <para>
    ///         The <see cref="Instantiate(Type[])"/> method, and thusly the class constructor, accepts an array of
    ///         <see cref="Type"/> s corresponding to each <see cref="IManager"/> instance to be created. The Application Manager
    ///         maintains an internal list of these Types, the instances of the Types created (one each), and a dictionary
    ///         containing the dependencies of each Type.
    ///     </para>
    ///     <para>
    ///         Upon instantiation, the Application Manager invokes <see cref="InstantiateManagers"/> method which iterates over
    ///         the list of Types and creates an instance of each using the <see cref="InstantiateManager{T}"/> method, then
    ///         registers the new instance with <see cref="RegisterManager{T}(IManager)"/>. If all dependencies for a Manager have
    ///         not yet been instantiated when the dependent Manager is instantiated an exception will be thrown; the order in
    ///         which the Manager Types appear in the Type list provided to the <see cref="Instantiate(Type[])"/> method must
    ///         reflect the inter-Manager dependencies. The RegisterManager method adds the Manager instance to the internal list
    ///         and creates an entry in the dependency dictionary for the Type.
    ///     </para>
    ///     <para>
    ///         After all Managers have been instantiated, the list of created instances is iterated over and the
    ///         <see cref="Manager.Setup"/> method is invoked on each. This method allows Managers which are dependent upon other
    ///         Managers to initialize those dependencies. Examples include the <see cref="Configuration.ConfigurationManager"/>,
    ///         which iterates over the list of Manager instances and registers Managers which implement
    ///         <see cref="SDK.Configuration.IConfigurable{T}"/>, and the <see cref="Event.EventManager"/>, which does the same for
    ///         implementations of <see cref="SDK.IEventProvider"/>.
    ///     </para>
    ///     <para>
    ///         The method <see cref="GetManager{T}"/> and property <see cref="Managers"/> are provided to allow Managers to
    ///         retrieve other Managers contained within the application. <see cref="GetManager{T}"/> is primarily provided to
    ///         allow static methods to access a particular manager. This is the only valid usage; instance methods should use the
    ///         dependency injection system. The <see cref="Managers"/> property provides an immutable list of Manager instances
    ///         which allows for the functionality described above for <see cref="Manager.Setup"/>. This is necessary so that
    ///         Managers may access other Managers which are not explicitly defined as dependencies. Again, this is the only valid
    ///         usage of the method.
    ///     </para>
    ///     <para>
    ///         As with other instances of <see cref="IManager"/>, the <see cref="Startup"/> and <see cref="Shutdown(StopType)"/>
    ///         methods are invoked upon the invocation of <see cref="Manager.Start"/> and <see cref="Manager.Stop(StopType)"/>.
    ///         The Application Manager uses these methods to start and stop Manager instances.
    ///     </para>
    /// </remarks>
    [Discoverable]
    public class ApplicationManager : Manager, IApplicationManager
    {
        #region Private Fields

        /// <summary>
        ///     The Singleton instance of ApplicationManager.
        /// </summary>
        private static ApplicationManager instance;

        /// <summary>
        ///     The Logger for this class.
        /// </summary>
        private static new xLogger logger = (xLogger)LogManager.GetCurrentClassLogger(typeof(xLogger));

        #endregion Private Fields

        #region Private Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApplicationManager"/> class with the specified Manager Types.
        /// </summary>
        /// <param name="managerTypes">The array of Manager Types for the application.</param>
        /// <exception cref="ManagerTypeListException">
        ///     Thrown when the type list argument for the ApplicationManager constructor is malformed.
        /// </exception>
        /// <exception cref="ManagerInstantiationException">
        ///     Thrown when an error is encountered while instantiating the specified Managers.
        /// </exception>
        /// <exception cref="ManagerSetupException">
        ///     Thrown when an error is encountered while performing setup of the instantiated Managers.
        /// </exception>
        private ApplicationManager(Type[] managerTypes)
        {
            // force the parent logger to this instance due to the way GetCurrentClassLogger works
            base.logger = logger;

            Guid guid = logger.EnterMethod(xLogger.Params((object)managerTypes), true);

            ManagerName = "Application Manager";
            ManagerTypes = managerTypes.ToList();
            ManagerInstances = new List<IManager>();
            ManagerDependencies = new Dictionary<Type, List<Type>>();

            // register the ApplicationManager with itself to simplify things later
            RegisterManager<IApplicationManager>(this);

            // create an instance of each Manager Type in the ManagerTypes list
            logger.Info("Instantiating Managers...");
            InstantiateManagers(); // throws ManagerInstantiationException
            logger.Info("Managers instantiated successfully.");

            // invoke the setup method for each manager
            logger.Info("Performing Manager Setup...");
            SetupManagers(); // throws ManagerSetupException
            logger.Info("Managers set up successfully.");

            ChangeState(State.Initialized);

            logger.ExitMethod(guid);
        }

        #endregion Private Constructors

        #region Public Properties

        /// <summary>
        ///     Gets the name of the application instance, retrieved from the application's settings file.
        /// </summary>
        /// <remarks>
        ///     If the "InstanceName" setting is missing from the application settings, the value of the ProductName property is substituted.
        /// </remarks>
        public string InstanceName
        {
            get
            {
                return GetInstanceName();
            }
        }

        /// <summary>
        ///     Gets the list of <see cref="IManager"/> instances managed by the <see cref="IApplicationManager"/>.
        /// </summary>
        public IReadOnlyList<IManager> Managers
        {
            get
            {
                return ManagerInstances.ToList().AsReadOnly();
            }
        }

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

        #endregion Public Properties

        #region Private Properties

        /// <summary>
        ///     Gets or sets a dictionary containing a list of dependencies for each application Manager.
        /// </summary>
        private Dictionary<Type, List<Type>> ManagerDependencies { get; set; }

        /// <summary>
        ///     Gets or sets the list of application Manager instances.
        /// </summary>
        [Discoverable]
        private IList<IManager> ManagerInstances { get; set; }

        /// <summary>
        ///     Gets or sets the list of application Manager Types.
        /// </summary>
        private List<Type> ManagerTypes { get; set; }

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        ///     Returns the Singleton instance of ApplicationManager
        /// </summary>
        /// <remarks>Use only in situations where dependency injection is not feasible.</remarks>
        /// <returns>The Singleton instance of ApplicationManager</returns>
        /// <exception cref="ManagerNotInitializedException">
        ///     Thrown when a Manager instance is requested but the Manager has not yet been initialized.
        /// </exception>
        public static ApplicationManager GetInstance()
        {
            if (instance == null)
            {
                throw new ManagerNotInitializedException("Failed to retrieve the ApplicationManager instance; it has not yet been instantiated.");
            }

            return instance;
        }

        /// <summary>
        ///     Returns the singleton instance of the ApplicationManager. Creates an instance if null.
        /// </summary>
        /// <param name="managers">The array of Manager Types for the application.</param>
        /// <returns>The singleton instance of the ApplicationManager</returns>
        /// <exception cref="ManagerTypeListException">
        ///     Thrown when the supplied list of Manager Types is empty or if one or more supplied Types do not implement the
        ///     <see cref="IManager"/> interface.
        /// </exception>
        public static ApplicationManager Instantiate(Type[] managers)
        {
            // validate input. ensure the list of types is not empty and that all types implement IManager.
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
        ///     Terminates Singleton instance of ApplicationManager.
        /// </summary>
        public static void Terminate()
        {
            instance = null;
        }

        /// <summary>
        ///     Returns the Manager from the list of Managers matching the specified Type.
        /// </summary>
        /// <typeparam name="T">The Type of the Manager to return.</typeparam>
        /// <returns>The requested Manager.</returns>
        public T GetManager<T>() where T : IManager
        {
            return ManagerInstances.OfType<T>().FirstOrDefault();
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        ///     Executed upon shutdown of the Manager. Stops all application managers.
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

        /// <summary>
        ///     Executed upon startup of the Manager. Starts all application managers.
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

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        ///     Returns the "InstanceName" setting from the app.config file, or the default value if the setting is not retrieved.
        /// </summary>
        /// <returns>The name of the program instance.</returns>
        private static string GetInstanceName()
        {
            return Utility.GetSetting("InstanceName", Assembly.GetExecutingAssembly().GetName().Name);
        }

        /// <summary>
        ///     Retrieves the list of <see cref="Type"/> s corresponding to the <see cref="IManager"/> Types on which the specified
        ///     Manager Type depends.
        /// </summary>
        /// <remarks>
        ///     Uses reflection to retrieve the parameters for the private Instantiate() method of the specified Type.
        /// </remarks>
        /// <typeparam name="T">The Type of the Manager for which the dependencies are to be returned.</typeparam>
        /// <returns>A List of dependency Types.</returns>
        /// <exception cref="MissingMethodException">
        ///     Thrown when the Instantiate() method is not found within the specified Type.
        /// </exception>
        /// <exception cref="ManagerDependencyException">
        ///     Thrown when an exception is caught while retrieving the dependencies for the specified Type.
        /// </exception>
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
                // retrieve the list of parameters for the Instantiate() method of the specified Manager Type and add the type of
                // each to the return value list start by fetching the method. throw an exception if it is not found.
                MethodInfo method = typeof(T).GetMethod("Instantiate", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);

                if (method == default(MethodInfo))
                {
                    throw new MissingMethodException("Unable to find the Instantiate() method in Type '" + typeof(T).Name + "'.");
                }

                // fetch the parameters and add them to the return list.
                ParameterInfo[] parameters = method.GetParameters();

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
        ///     Creates and returns an instance of the specified <see cref="IManager"/> Type.
        /// </summary>
        /// <typeparam name="T">The Type of the Manager to instantiate.</typeparam>
        /// <returns>The instantiated IManager.</returns>
        /// <exception cref="MissingMethodException">Thrown when a reflected method can not be found.</exception>
        /// <exception cref="ManagerInstantiationException">
        ///     Thrown when an error is encountered while instantiating the specified Manager Type.
        /// </exception>
        private T InstantiateManager<T>() where T : IManager
        {
            logger.EnterMethod(xLogger.TypeParams(typeof(T)));
            logger.Trace("Creating new instance of '" + typeof(T).Name + "'...");

            T instance;

            try
            {
                // use reflection to locate the static Instantiate() method in the target class, then check to make sure it was found.
                MethodInfo method = typeof(T).GetMethod("Instantiate", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);

                // use reflection to locate the static ResolveManagerDependencies() method, create a generic version with the type
                // for the manager we are trying to instantiate, then invoke it.
                MethodInfo resolveMethod = GetType().GetMethod("ResolveManagerDependencies", BindingFlags.NonPublic | BindingFlags.Instance);
                MethodInfo genericResolveMethod = resolveMethod.MakeGenericMethod(typeof(T));
                List<IManager> resolvedDependencies = (List<IManager>)genericResolveMethod.Invoke(this, new object[] { });

                // invoke the Instantiate() method and pass the resolved dependencies from the step above. store the result in
                // instance, then check to make sure it is not null and ensure that it implements IManager.
                instance = (T)method.Invoke(null, resolvedDependencies.ToArray());

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
        ///     Iterates over the list of <see cref="IManager"/> Types and instantiates each in the order in which they are
        ///     represented in the list.
        /// </summary>
        /// <exception cref="ManagerInstantiationException">
        ///     Thrown when the instantiation or registration of a Manager returns an abnormal result.
        /// </exception>
        private void InstantiateManagers()
        {
            logger.EnterMethod();
            logger.Trace("Instantiating Managers...");

            // iterate over the list of Manager Types specified in the constructor and create and register an instance of each
            foreach (Type managerType in ManagerTypes)
            {
                logger.SubHeading(LogLevel.Debug, managerType.Name);

                // instantiate the manager
                logger.Debug("Instantiating '" + managerType.Name + "'...");
                IManager manager = default(IManager);

                manager = InvokeMethod<IManager>(
                    GetType().GetMethod("InstantiateManager", BindingFlags.NonPublic | BindingFlags.Instance),
                    managerType,
                    typeof(ManagerInstantiationException),
                    "Error instantiating Manager '" + managerType.Name + "'.  See inner exception for details.");

                logger.Debug("Successfully instantiated '" + manager.GetType().Name + "'.  Registering...");

                // register the manager
                logger.Debug("Registering '" + managerType.Name + "'...");

                InvokeMethod(
                    GetType().GetMethod("RegisterManager", BindingFlags.NonPublic | BindingFlags.Instance, null, CallingConventions.Any, new Type[] { typeof(IManager) }, null),
                    managerType,
                    typeof(ManagerInstantiationException),
                    "Error registering '" + manager.ManagerName + "'.  See inner exception for details.",
                    new object[] { manager });

                logger.Debug("Successfully registered '" + manager.GetType().Name + "'.");
            }

            logger.ExitMethod();
        }

        /// <summary>
        ///     Invokes the specified generic method, supplying the optionally specified array of parameters as method parameters.
        ///     Throws a new <see cref="Exception"/> of the specified Type and with the specified message upon encountering a <see cref="TargetInvocationException"/>.
        /// </summary>
        /// <param name="method">The generic method to be invoked.</param>
        /// <param name="type">The Type parameter for the generic method.</param>
        /// <param name="exceptionType">
        ///     The Type of Exception to throw if a <see cref="TargetInvocationException"/> is encountered.
        /// </param>
        /// <param name="exceptionMessage">
        ///     The message with which the Exception should be thrown if a <see cref="TargetInvocationException"/> is encountered.
        /// </param>
        /// <param name="parameters">Optional parameters to be included with the method invocation.</param>
        private void InvokeMethod(MethodInfo method, Type type, Type exceptionType, string exceptionMessage, object[] parameters = null)
        {
            logger.EnterMethod(xLogger.Params(method, type, exceptionType, exceptionMessage, parameters));

            MethodInfo generic = method.MakeGenericMethod(type);

            try
            {
                generic.Invoke(this, parameters);
            }
            catch (TargetInvocationException ex)
            {
                throw (Exception)Activator.CreateInstance(exceptionType, exceptionMessage, ex);
            }
        }

        /// <summary>
        ///     Invokes the specified generic method, supplying the specified Type as the Type parameter and the optionally
        ///     specified array of parameters as method parameters. Throws a new <see cref="Exception"/> of the specified Type and
        ///     with the specified message upon encountering a <see cref="TargetInvocationException"/>.
        /// </summary>
        /// <typeparam name="T">The Type of the return value of the method invocation.</typeparam>
        /// <param name="method">The generic method to be invoked.</param>
        /// <param name="type">The Type parameter for the generic method.</param>
        /// <param name="exceptionType">
        ///     The Type of Exception to throw if a <see cref="TargetInvocationException"/> is encountered.
        /// </param>
        /// <param name="exceptionMessage">
        ///     The message with which the Exception should be thrown if a <see cref="TargetInvocationException"/> is encountered.
        /// </param>
        /// <param name="parameters">Optional parameters to be included with the method invocation.</param>
        /// <returns>The value returned by the method invocation.</returns>
        private T InvokeMethod<T>(MethodInfo method, Type type, Type exceptionType, string exceptionMessage, object[] parameters = null) where T : IManager
        {
            logger.EnterMethod(xLogger.Params(method, type, parameters));

            MethodInfo generic = method.MakeGenericMethod(type);
            T retVal;

            try
            {
                retVal = (T)generic.Invoke(this, parameters);
            }
            catch (TargetInvocationException ex)
            {
                throw (Exception)Activator.CreateInstance(exceptionType, exceptionMessage, ex);
            }

            return retVal;
        }

        /// <summary>
        ///     Searches the list of registered <see cref="IManager"/> instances for the specified instance and returns a value
        ///     indicating whether it was found.
        /// </summary>
        /// <typeparam name="T">The Manager Type to check.</typeparam>
        /// <returns>A value indicating whether the specified Manager has been registered.</returns>
        private bool IsManagerRegistered<T>() where T : IManager
        {
            return ManagerInstances.OfType<T>().Count() > 0;
        }

        /// <summary>
        ///     Event handler for the StateChanged event of registered Managers.
        /// </summary>
        /// <param name="sender">The Manager which fired the event.</param>
        /// <param name="e">The EventArgs for the event.</param>
        private void ManagerStateChanged(object sender, StateChangedEventArgs e)
        {
            logger.Info("Manager '" + sender.GetType().Name + "' state changed from '" + e.PreviousState + "' to '" + e.State + "'." + (e.Message != string.Empty ? "(" + e.Message + ")" : string.Empty));
        }

        /// <summary>
        ///     Adds the specified <see cref="IManager"/> to the Manager list and subscribes to its
        ///     <see cref="Manager.StateChanged"/> event.
        /// </summary>
        /// <typeparam name="T">The Type of the specified Manager.</typeparam>
        /// <param name="manager">The Manager to register.</param>
        /// <returns>The registered Manager.</returns>
        /// <exception cref="ManagerRegistrationException">Thrown when an error is encountered during registration.</exception>
        private T RegisterManager<T>(IManager manager) where T : IManager
        {
            logger.EnterMethod(xLogger.TypeParams(typeof(T)), xLogger.Params(manager));
            logger.Trace("Registering Manager '" + manager.GetType().Name + "'...");

            // ensure the specified Manager hasn't already been registered. There can only be one of each Type in the Manager list.
            if (IsManagerRegistered<T>())
            {
                throw new ManagerRegistrationException("The Manager '" + manager.GetType().Name + "' is already registered.");
            }

            try
            {
                // retrieve the dependencies for the Manager
                List<Type> dependencies = GetManagerDependencies<T>();

                logger.Trace("Registering Manager with " + dependencies.Count() + " dependencies...");

                // add the specified Manager to the list and attach an event handler to its StateChanged event
                ManagerInstances.Add(manager);
                ManagerDependencies.Add(typeof(T), dependencies);
                manager.StateChanged += ManagerStateChanged;
            }
            catch (Exception ex)
            {
                logger.Exception(ex);
                throw new ManagerRegistrationException("Failed to register Manager '" + manager.GetType().Name + "'.  See the inner exception for details.", ex);
            }

            logger.Trace("Successfully registered Manager '" + manager.GetType().Name + "'.");

            logger.ExitMethod();
            return (T)manager;
        }

        /// <summary>
        ///     Returns a list of IManager instances corresponding to the Manager Types upon which the specified Manager is dependent.
        /// </summary>
        /// <typeparam name="T">The Manager Type for which the dependencies are to be resolved.</typeparam>
        /// <returns>
        ///     A list of IManager instances corresponding to the Manager Types upon which the specified Manager is dependent.
        /// </returns>
        /// <exception cref="ManagerDependencyException">
        ///     Thrown when an exception is caught while resolving the dependencies for the specified Manager Type.
        /// </exception>
        private List<IManager> ResolveManagerDependencies<T>() where T : IManager
        {
            logger.EnterMethod(xLogger.TypeParams(typeof(T)));
            logger.Trace("Resolving dependencies for '" + typeof(T).Name + "'...");
            List<IManager> retVal = new List<IManager>();

            try
            {
                // find the GetManager() method
                MethodInfo getManager = GetType().GetMethod("GetManager", BindingFlags.Public | BindingFlags.Instance);
                MethodInfo getManagerGeneric;

                // retrieve dependencies for the specified Manager any instance of IManager needs to have at least one dependency
                // (ApplicationManager). If we get a null or empty list something is wrong.
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

                    logger.Trace("Successfully resolved dependency '" + t.Name + "'.");
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

        /// <summary>
        ///     Invokes the <see cref="Manager.Setup"/> method on the specified instance of <see cref="IManager"/>.
        /// </summary>
        /// <param name="manager">The IManager instance for which to invoke Setup().</param>
        /// <exception cref="ManagerSetupException">Thrown when the 'Setup' method invocation throws an exception.</exception>
        private void SetupManager(IManager manager)
        {
            logger.EnterMethod();
            logger.Debug("Performing Setup for Manager '" + manager.GetType() + "'...");

            MethodInfo method = manager.GetType().GetMethod("Setup", BindingFlags.Instance | BindingFlags.NonPublic);

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
            retVal.Incorporate(manager.Start());

            // if the manager fails to start, throw an exception and halt the program
            if (retVal.ResultCode == ResultCode.Failure)
            {
                throw new ManagerStartException("Failed to start Manager '" + manager.ManagerName + "': " + retVal.GetLastError());
            }

            retVal.ReturnValue = manager;

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        /// <summary>
        ///     Starts each <see cref="IManager"/> contained within the specified list of Manager instances.
        /// </summary>
        /// <remarks>Does not Start the ApplicationManager instance.</remarks>
        /// <returns>A Result containing the result of the operation.</returns>
        private Result StartManagers()
        {
            Guid guid = logger.EnterMethod(true);
            logger.Debug("Starting Managers...");
            Result retVal = new Result();

            // iterate over the Manager instance list and start each manager. skip the ApplicationManager as it has already been started.
            foreach (IManager manager in ManagerInstances)
            {
                if (manager != this)
                {
                    logger.SubHeading(LogLevel.Debug, manager.GetType().Name);
                    retVal.Incorporate(StartManager(manager));
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
                throw new ManagerStopException("Failed to stop Manager '" + manager.ManagerName + "': " + retVal.GetLastError());
            }

            retVal.LogResult(logger);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        /// <summary>
        ///     Stops each of the <see cref="IManager"/> instances in the specified Manager instance list.
        /// </summary>
        /// <remarks>Does not Stop the ApplicationManager instance.</remarks>
        /// <param name="stopType">The type of stoppage.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        private Result StopManagers(StopType stopType = StopType.Stop)
        {
            Guid guid = logger.EnterMethod();
            logger.Debug("Stopping Managers...");
            Result retVal = new Result();

            // iterate over the Manager instance list in reverse order, stopping each manager. skip the ApplicationManager as it
            // will stop when this process is complete.
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

        #endregion Private Methods
    }
}