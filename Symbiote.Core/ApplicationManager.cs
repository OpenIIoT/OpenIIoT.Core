/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀ 
      █   
      █      ▄███████▄                                                                ▄▄▄▄███▄▄▄▄                                                             
      █     ███    ███                                                              ▄██▀▀▀███▀▀▀██▄                                                           
      █     ███    ███    █████  ██████     ▄████▄     █████   ▄█████     ▄▄██▄▄▄   ███   ███   ███   ▄█████  ██▄▄▄▄    ▄█████     ▄████▄     ▄█████    █████ 
      █     ███    ███   ██  ██ ██    ██   ██    ▀    ██  ██   ██   ██  ▄█▀▀██▀▀█▄  ███   ███   ███   ██   ██ ██▀▀▀█▄   ██   ██   ██    ▀    ██   █    ██  ██ 
      █   ▀█████████▀   ▄██▄▄█▀ ██    ██  ▄██        ▄██▄▄█▀   ██   ██  ██  ██  ██  ███   ███   ███   ██   ██ ██   ██   ██   ██  ▄██        ▄██▄▄     ▄██▄▄█▀ 
      █     ███        ▀███████ ██    ██ ▀▀██ ███▄  ▀███████ ▀████████  ██  ██  ██  ███   ███   ███ ▀████████ ██   ██ ▀████████ ▀▀██ ███▄  ▀▀██▀▀    ▀███████ 
      █     ███          ██  ██ ██    ██   ██    ██   ██  ██   ██   ██  ██  ██  ██  ███   ███   ███   ██   ██ ██   ██   ██   ██   ██    ██   ██   █    ██  ██ 
      █    ▄████▀        ██  ██  ██████    ██████▀    ██  ██   ██   █▀   █  ██  █    ▀█   ███   █▀    ██   █▀  █   █    ██   █▀   ██████▀    ███████   ██  ██ 
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
using System.Linq;
using System.Reflection;
using NLog;

namespace Symbiote.Core
{
    /// <summary>
    /// Represents the Application and is responsible for managing the various subsystem Managers.
    /// </summary>
    /// <remarks>
    /// <para>
    ///     This class is a Singleton, however the static method which invokes the private constructor is itself private and is invoked via reflection.  This is 
    ///     by design so that Plugins and scripts are not easily capable of invoking the method; the preference is that dependencies are injected rather than 
    ///     retrieved from the Service Locator.
    /// </para>
    /// <para>
    ///     If dependency injection isn't feasible the ApplicationManager instance can be retrieved using the <see cref="GetInstance()"/> method, and the individual
    ///     Managers can be retrieved using <see cref="GetManager{T}()"/>.
    /// </para>
    /// </remarks>
    public class ApplicationManager : Manager, IStateful, IManager, IApplicationManager
    {
        #region Fields

        /// <summary>
        /// The Logger for this class.
        /// </summary>
        private static new xLogger logger = (xLogger)LogManager.GetCurrentClassLogger(typeof(xLogger));

        /// <summary>
        /// The Singleton instance of ApplicationManager.
        /// </summary>
        private static ApplicationManager instance;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationManager"/> class with the specified Manager Types.
        /// </summary>
        /// <param name="managerTypes">The array of Manager Types for the application.</param>
        /// <exception cref="ManagerTypeListException">Thrown when the type list argument for the ApplicationManager constructor is malformed.</exception>
        private ApplicationManager(Type[] managerTypes)
        {
            // force the parent logger to this instance due to the way GetCurrentClassLogger works
            base.logger = logger;

            Guid guid = logger.EnterMethod(xLogger.Params((object)managerTypes), true);

            // validate input.  ensure the list of types is not empty and that all types implement IManager.
            if (managerTypes == default(Type[]) || managerTypes.Count() == 0)
            {
                throw new ManagerTypeListException("The supplied list of Types must contain at least one Type.");
            }
            else
            {
                if (managerTypes.Where(t => t.GetInterfaces().Contains(typeof(IManager))).Count() != managerTypes.Count())
                {
                    throw new ManagerTypeListException("Each Type in the supplied list of Types must implement the IManager interface.");
                }
            }

            // initialize properties
            ManagerName = "Application Manager";
            ManagerTypes = managerTypes.ToList();
            ManagerInstances = new List<IManager>();
            ManagerDependencies = new Dictionary<Type, List<Type>>();

            // register the ApplicationManager
            RegisterManager<IApplicationManager>(this);
            
            // create an instance of each Manager Type in the ManagerTypes list
            logger.Info("Instantiating Managers...");
            InstantiateManagers();
            logger.Info("Managers instantiated successfully.");
            logger.Info("Performing Manager Setup...");

            foreach (IManager manager in ManagerInstances)
            {
                Result setupResult = SetupManager(manager);

                if (setupResult.ResultCode == ResultCode.Failure)
                {
                    throw new ManagerSetupException("Error setting up one or more Managers: " + setupResult.GetLastError());
                }
            }

            ChangeState(State.Initialized);

            logger.ExitMethod(guid);
        }

        #endregion

        #region Properties

        #region Public Properties

        #region IStateful Properties

        //// See the Manager class for the IStateful properties for this class.

        #endregion

        #region IManager Properties

        //// See the Manager class for the IManager properties for this class.

        #endregion

        #region IApplicationManager Properties

        /// <summary>
        /// Gets the name of the product, retrieved from AssemblyInfo.cs.
        /// </summary>
        public string ProductName
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Name;
            }
        }

        /// <summary>
        /// Gets the version of the product, retrieved from AssemblyInfo.cs.
        /// </summary>
        public Version ProductVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version;
            }
        }

        /// <summary>
        /// Gets the name of the application instance.
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
        /// Gets or sets the list of application Manager Types.
        /// </summary>
        private List<Type> ManagerTypes { get; set; }

        /// <summary>
        /// Gets or sets the list of application Manager instances.
        /// </summary>
        private List<IManager> ManagerInstances { get; set; }

        /// <summary>
        /// Gets or sets a dictionary containing a list of dependencies for each application Manager.
        /// </summary>
        private Dictionary<Type, List<Type>> ManagerDependencies { get; set; }

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        #region Public Static Methods

        #region Settings

        /// <summary>
        /// Returns the "InstanceName" setting from the app.config file, or the default value if the setting is not retrieved.
        /// </summary>
        /// <returns>The name of the program instance.</returns>
        public static string GetInstanceName()
        {
            return Utility.GetSetting("InstanceName", "Symbiote");
        }

        #endregion

        /// <summary>
        /// Returns the singleton instance of the ApplicationManager.  Creates an instance if null.
        /// </summary>
        /// <param name="managers">The array of Manager Types for the application.</param>
        /// <returns>The singleton instance of the ApplicationManager</returns>
        public static ApplicationManager Instantiate(Type[] managers)
        {
            if (instance == null)
            {
                instance = new ApplicationManager(managers);
            }

            return instance;
        }

        /// <summary>
        /// Returns the Singleton instance of ApplicationManager
        /// </summary>
        /// <remarks>
        /// Use only in situations where dependency injection is not feasible.
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
        /// Returns the Manager from the list of Managers matching the specified Type.
        /// </summary>
        /// <typeparam name="T">The Type of the Manager to return.</typeparam>
        /// <returns>The requested Manager.</returns>
        public T GetManager<T>() where T : IManager
        {
            return ManagerInstances.OfType<T>().FirstOrDefault();
        }

        #endregion

        #endregion

        #endregion

        #region Protected Methods

        #region Protected Instance Methods

        /// <summary>
        /// Executed upon instantiation of all program Managers.  Not implemented.
        /// </summary>
        /// <param name="managerInstances"></param>
        /// <returns>A Result containing the result of the operation.</returns>
        protected override Result Setup(List<IManager> managerInstances)
        {
            return new Result();
        }

        /// <summary>
        /// Executed upon startup of the Manager.  Starts all application managers.
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
        /// Executed upon shutdown of the Manager.  Stops all application managers.
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
        /// Event handler for the StateChanged event of registered Managers.
        /// </summary>
        /// <param name="sender">The Manager which fired the event.</param>
        /// <param name="e">The EventArgs for the event.</param>
        private void ManagerStateChanged(object sender, StateChangedEventArgs e)
        {
            logger.Info("Manager '" + sender.GetType().Name + "' state changed from '" + e.PreviousState + "' to '" + e.State + "'." + (e.Message != string.Empty ? "(" + e.Message + ")" : string.Empty));
        }

        #endregion

        /// <summary>
        /// Starts the specified IManager instance
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
        /// Stops the specified IManager instance.
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
        /// Invokes the Setup method on the specified instance of IManager.
        /// </summary>
        /// <param name="manager">The IManager instance for which to invoke Setup().</param>
        /// <returns>A Result containing the result of the operation.</returns>
        /// <exception cref="MissingMethodException">Thrown when the 'Setup' method within the specified IManager instance can not be found.</exception>
        /// <exception cref="ManagerSetupException">Thrown when the 'Setup' method within the specified IManager returns an empty Result.</exception>
        private Result SetupManager(IManager manager)
        {
            logger.EnterMethod();
            logger.Debug("Performing Setup on Manager '" + manager.GetType() + "'...");

            MethodInfo method = manager.GetType().GetMethod("Setup", BindingFlags.Instance | BindingFlags.NonPublic);

            if (method == default(MethodInfo))
            {
                throw new MissingMethodException("Unable to find method 'Setup()' in Type '" + manager.GetType() + "'.");
            }

            Result retVal = (Result)method.Invoke(manager, new[] { ManagerInstances });

            if (retVal == default(Result))
            {
                throw new ManagerSetupException("The 'Setup()' method invocation for '" + manager.GetType() + "' returned no result.");
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        /// Returns true if the specified Manager Type is registered, false otherwise.
        /// </summary>
        /// <typeparam name="T">The Manager Type to check.</typeparam>
        /// <returns>True if the specified Manager Type is registered, false otherwise.</returns>
        private bool IsRegistered<T>() where T : IManager
        {
            return ManagerInstances.OfType<T>().Count() > 0;
        }

        /// <summary>
        /// Retrieves the list of <see cref="Type"/>s corresponding to the Managers on which the specified Manager Type depends.
        /// </summary>
        /// <remarks>
        ///     Uses reflection to retrieve the parameters for the constructor of the specified Type.  To dictate dependencies for a 
        ///     Manager, simply declare the dependent Types as parameters on the 
        /// </remarks>
        /// <typeparam name="T">The Type of the Manager for which the dependencies are to be returned.</typeparam>
        /// <returns>A List of dependency Types.</returns>
        /// <exception cref="Exception">Thrown when an exception is caught while retrieving the Instantiate() parameters for the specified Type.</exception>
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
                // retrieve the list of parameters for the Instantiate() method of the specified Manager Type and add the type of each
                // to the return value list
                ParameterInfo[] parameters = typeof(T).GetMethod("Instantiate", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static).GetParameters();

                foreach (ParameterInfo p in parameters)
                {
                    retVal.Add(p.ParameterType);
                }
            }
            catch (Exception ex)
            {
                logger.Exception(ex);
                throw new Exception("Failed to retrieve dependencies for '" + typeof(T).Name + "': " + ex.Message, ex);
            }

            logger.Trace("Retrieved " + retVal.Count() + " dependenc" + (retVal.Count() == 1 ? "y" : "ies") + ".");

            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        /// Returns a list of IManager instances corresponding to the Manager Types upon which the specified Manager is dependent.
        /// </summary>
        /// <typeparam name="T">The Manager Type for which the dependencies are to be resolved.</typeparam>
        /// <returns>A list of IManager instances corresponding to the Manager Types upon which the specified Manager is dependent.</returns>
        /// <exception cref="MissingMethodException">Thrown when the 'GetManager()' method can not be found.</exception>
        /// <exception cref="Exception">Thrown when the 'GetManagerDependencies()' method returns a null or empty list.</exception>
        /// <exception cref="Exception">Thrown when the invocation of the 'GetManager{T}()' method fails.  See inner exception for details.</exception>
        /// <exception cref="Exception">Thrown when the invocation of the 'GetManager{T}()' method returns a null instance of IManager.</exception>
        /// <exception cref="Exception">Thrown when an exception is caught while resolving the dependencies for the specified Manager Type.</exception>
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
                    throw new Exception("Failed to retrieve dependencies for '" + typeof(T).Name + "'.  Method 'GetManagerDependencies()' returned a null or empty List.");
                }

                // iterate over the dependencies
                foreach (Type t in dependencies)
                {
                    logger.Trace("Attempting to resolve dependency '" + t.Name + "'...");

                    IManager manager;

                    getManagerGeneric = getManager.MakeGenericMethod(t);

                    try
                    {
                        manager = (IManager)getManagerGeneric.Invoke(this, new object[] { });
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Invocation of method 'GetManager<T>' failed: " + ex.Message, ex);
                    }

                    if ((IManager)manager == default(IManager))
                    {
                        throw new Exception("Invocation of method 'GetManager<T>' returned a null instance of IManager.");
                    }

                    logger.Trace("Successfully resolved depencency '" + t.Name + "'.");
                    retVal.Add(manager);
                }
            }
            catch (Exception ex)
            {
                logger.Exception(ex);
                throw new Exception("Failed to resolve dependencies for '" + typeof(T).Name + "': " + ex.Message, ex);
            }

            logger.Trace("Resolved " + retVal.Count() + " dependenc" + (retVal.Count() == 1 ? "y" : "ies" + "."));

            logger.ExitMethod(retVal.Select(d => d.GetType()));
            return retVal;
        }

        /// <summary>
        /// Iterates over the list of Manager Types and instantiates each in the order in which they are represented in the list.
        /// </summary>
        /// <exception cref="MissingMethodException">Thrown when the 'InstantiateManager()' or 'RegisterManager()' methods can not be found.</exception>
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
        /// Creates and returns an instance of the specified Manager Type.
        /// </summary>
        /// <typeparam name="T">The Type of the Manager to instantiate.</typeparam>
        /// <returns>The instantiated IManager.</returns>
        /// <exception cref="MissingMethodException">Thrown when the 'Instantiate()' or 'ResolveManagerDependencies()' methods of the specified Manager Type can not be found.</exception>
        /// <exception cref="Exception">Thrown when the application fails to resolve dependencies for the specified Manager Type.</exception>
        /// <exception cref="Exception">Thrown when the 'Instantiate()' method of the specified Manager Type returns a null value.</exception>
        /// <exception cref="Exception">Thrown when the object returned by 'Instantiate()' does not implement the IManager interface.</exception>
        /// <exception cref="Exception">Thrown when the instantiation fails.  See inner exception for details.</exception>
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
                    throw new Exception("Failed to resolve Manager dependencies for '" + typeof(T) + "'.");
                }

                // invoke the Instantiate() method and pass the resolved dependencies from the step above.
                // store the result in instance, then check to make sure it is not null and ensure that it implements IManager.
                instance = (T)method.Invoke(null, resolvedDependencies.ToArray());
                if (instance == null)
                {
                    throw new Exception("Instantiate() method invocation from '" + typeof(T).Name + "' returned no result.");
                }
                else if (!(instance is IManager))
                {
                    throw new Exception("The instance returned by Instantiate() method invocation from '" + typeof(T).Name + "' does not implement the IManager interface.");
                }

                logger.Trace("Successfully instantiated '" + instance.GetType().Name + "'.");
            }
            catch (Exception ex)
            {
                logger.Exception(ex);
                throw new Exception("Failed to instantiate Manager '" + typeof(T).Name + "': " + ex.Message, ex);
            }

            logger.ExitMethod();
            return instance;
        }

        /// <summary>
        /// Adds the specified Manager to the Manager list and subscribes to its StateChanged event.
        /// </summary>
        /// <typeparam name="T">The Type of the specified Manager.</typeparam>
        /// <param name="manager">The Manager to register.</param>
        /// <returns>The registered Manager.</returns>
        /// <exception cref="Exception">Thrown if the specified Manager has already been registered.</exception>
        /// <exception cref="Exception">Thrown if the dependency list retrieved for the Manager is empty.</exception>
        /// <exception cref="Exception">Thrown if the registration fails.</exception>
        private T RegisterManager<T>(IManager manager) where T : IManager
        {
            logger.EnterMethod(xLogger.TypeParams(typeof(T)), xLogger.Params(manager));
            logger.Trace("Registering Manager '" + manager.GetType().Name + "'...");

            // ensure the specified Manager hasn't already been registered.  There can only be one of each Type
            // in the Manager list.
            if (IsRegistered<T>())
            {
                throw new Exception("The Manager '" + manager.GetType().Name + "' is already registered.");
            }

            try
            {
                // retrieve the dependencies for the Manager
                List<Type> dependencies = GetManagerDependencies<T>();

                if (dependencies == default(List<Type>))
                {
                    throw new Exception("The dependency list for the Manager '" + manager.GetType().Name + "' is empty; all Managers must have at least one dependency.");
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
                throw new Exception("Failed to register Manager '" + manager.GetType().Name + "': " + ex.Message, ex);
            }

            logger.Trace("Successfully registered Manager '" + manager.GetType().Name + "'.");

            logger.ExitMethod();
            return (T)manager;
        }

        ///// <summary>
        ///// Returns a list of Manager Types for which the specified dependency dictionary contains an entry for the specified Manager Type.
        ///// </summary>
        ///// <typeparam name="T">The Manager Type for which the dependent Types are to be returned.</typeparam>
        ///// <returns>The list of Manager Types for which the ManagerDependencies dictionary contains an entry for the specified Manager Type.</returns>
        //private List<Type> GetManagerDependentTypes<T>() where T : IManager
        //{
        //    List<Type> retVal = new List<Type>();

        //    foreach (Type key in ManagerDependencies.Keys)
        //    {
        //        if (ManagerDependencies[key].Where(t => t.IsAssignableFrom(typeof(T))).Count() > 0)
        //        {
        //            retVal.Add(key);
        //        }
        //    }

        //    return retVal;
        //}

        /// <summary>
        /// Starts each Manager contained within the specified list of Manager instances.
        /// </summary>
        /// <remarks>
        /// Does not Start the ApplicationManager instance.
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
        /// Stops each of the <see cref="IManager"/> instances in the specified Manager instance list.
        /// </summary>
        /// <remarks>
        /// Does not Stop the ApplicationManager instance.
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

        #endregion

        #endregion

        #endregion
    }
}
