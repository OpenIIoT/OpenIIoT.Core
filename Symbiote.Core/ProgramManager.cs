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
 ▄ ▄▄ █ ▄▄▄▄▄▄▄▄▄  ▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄ 
 █ ██ █ █████████  ████ ██████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █ 
      █  
      █  The ProgramManager acts as a Service Locator and Dependency Injector for the application.
      █  
      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██ 
                                                                                                   ██ 
                                                                                               ▀█▄ ██ ▄█▀ 
                                                                                                 ▀████▀   
                                                                                                   ▀▀                            */
using System;
using System.Collections.Generic;
using NLog;
using System.Linq;
using System.Reflection;

namespace Symbiote.Core
{
    /// <summary>
    /// The ProgramManager acts as a Service Locator and Dependency Injector for the application.
    /// </summary>
    /// <remarks>
    /// <para>
    ///     This class is a Singleton, however the static method which invokes the private constructor is itself private and is invoked via reflection.  This is 
    ///     by design so that Plugins and scripts are not easily capable of invoking the method; the preference is that dependencies are injected rather than 
    ///     retrieved from the Service Locator.
    /// </para>
    /// <para>
    ///     If dependency injection isn't feasible the ProgramManager instance can be retrieved using the <see cref="GetInstance()"/> method, and the individual
    ///     Managers can be retrieved using <see cref="GetManager{T}()"/>.
    /// </para>
    /// </remarks>
    public class ProgramManager : IStateful, IManager, IProgramManager
    {
        #region Variables

        /// <summary>
        /// The logger for this class.
        /// </summary>
        private static xLogger logger = (xLogger)LogManager.GetCurrentClassLogger(typeof(xLogger));

        /// <summary>
        /// The Singleton instance of ProgramManager.
        /// </summary>
        private static ProgramManager instance;

        /// <summary>
        /// The list of application Manager Types.
        /// </summary>
        /// <remarks>
        /// Types must be added in the order in which they are to be instantiated and started.
        /// </remarks>
        private List<Type> managerTypes;

        /// <summary>
        /// The list of application Managers.
        /// </summary>
        private List<IManager> managers;

        #endregion

        #region Properties

        #region IStateful Properties

        /// <summary>
        /// The state of the Manager.
        /// </summary>
        public State State { get; private set; }

        #endregion

        #region IProgramManager Properties

        /// <summary>
        /// Indicates whether the program is in Safe Mode.  Safe Mode is a sort of fault tolerant mode designed
        /// to allow the application to run under conditions that would otherwise raise fatal errors.
        /// </summary>
        public bool SafeMode { get; private set; }

        /// <summary>
        /// The name of the product, retrieved from AssemblyInfo.cs.
        /// </summary>
        public string ProductName { get { return System.Reflection.Assembly.GetExecutingAssembly().GetName().Name; } }

        /// <summary>
        /// The version of the product, retrieved from AssemblyInfo.cs.
        /// </summary>
        public Version ProductVersion { get { return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version; } }

        /// <summary>
        /// The name of the application instance.
        /// </summary>
        /// <remarks>
        ///     If the "InstanceName" setting is missing from the application settings, the value of the 
        ///     ProductName property is substituted.
        /// </remarks>
        public string InstanceName { get { return GetInstanceName(); } }

        #endregion

        #endregion

        #region Events

        #region IStateful Events

        /// <summary>
        /// Occurs when the State of the component changes.
        /// </summary>
        public event EventHandler<StateChangedEventArgs> StateChanged;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// The default constructor.
        /// </summary>
        /// <remarks>
        /// If you've forgotten, you made this code dynamic so that you coud iterate over IManagers and it was 
        /// a mess.  Even more verbose than the way it is now, plus debugging it was a nightmare.  Don't try it again.
        /// </remarks>
        private ProgramManager(Type[] managerTypes, bool safeMode = false)
        {
            Guid guid = logger.EnterMethod(xLogger.Params(managerTypes, safeMode), true);

            // configure ManagerTypes
            this.managerTypes = managerTypes.ToList();
            managers = new List<IManager>();

            //-------------------------   -  -
            // configure the SafeMode option
            SafeMode = safeMode;

            if (safeMode)
                logger.Info("Safe Mode enabled.  The program is now running in a limited fault tolerant mode.");
            //---------------- -  


            // register the ProgramManager
            RegisterManager<ProgramManager>(this);


            //---------------------- -   ----------------------- -      --------  -    -
            // create an instance of each Manager Type in the ManagerTypes list
            logger.Debug("Instantiating Managers...");

            InstantiateManagers();

            logger.Debug("Managers instantiated successfully.");
            //------------------------------- -  -               ------------ 

            ChangeState(State.Initialized);

            logger.ExitMethod(guid);
        }

        /// <summary>
        /// Returns the singleton instance of the ProgramManager.  Creates an instance if null.
        /// </summary>
        /// <param name="safeMode">True if the ProgramManager is being started in Safe Mode, false otherwise.</param>
        /// <param name="managers">The array of Manager Types for the application.</param>
        /// <returns>The singleton instance of the ProgramManager</returns>
        internal static ProgramManager Instantiate(Type[] managers, bool safeMode = false)
        {
            if (instance == null)
                instance = new ProgramManager(managers, safeMode);

            return instance;
        }

        #endregion

        #region Instance Methods

        #region IStateful Implementation

        /// <summary>
        /// Starts the Program Manager.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result Start()
        {
            Guid guid = logger.EnterMethod(true);

            logger.Info("Starting the Program Manager...");
            Result retVal = new Result();

            ChangeState(State.Starting);

            // any future startup logic goes here

            StartManagers();

            if (retVal.ResultCode != ResultCode.Failure)
                ChangeState(State.Running);
            else
                ChangeState(State.Faulted);

            retVal.LogResult(logger);

            logger.Info("The Program Manager is now in the " + State + " state.");

            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        /// <summary>
        /// Restarts the Program Manager.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result Restart(StopType stopType = StopType.Normal)
        {
            Guid guid = logger.EnterMethod(true);

            logger.Info("Restarting the Program Manager...");
            Result retVal = Start().Incorporate(Stop(stopType));

            retVal.LogResult(logger);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        /// <summary>
        /// Stops the Program Manager.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result Stop(StopType stopType = StopType.Normal)
        {
            logger.EnterMethod();

            logger.Info("Stopping the Program Manager...");
            Result retVal = new Result();

            ChangeState(State.Stopping);

            if (retVal.ResultCode != ResultCode.Failure)
                ChangeState(State.Stopped);
            else
                ChangeState(State.Faulted, retVal.LastErrorMessage());

            retVal.LogResult(logger);
            logger.ExitMethod(retVal);
            return new Result();
        }

        #endregion

        /// <summary>
        /// Iterates over the list of Manager Types and instantiates each in the order in which they are represented in the list.
        /// </summary>
        /// <exception cref="MissingMethodException">Thrown when the 'InstantiateManager()' method can not be found.</exception>
        /// <exception cref="MissingMethodException">Thrown when the 'RegisterManager()' method can not be found.</exception>
        /// <exception cref="Exception">Thrown when the Manager instantiation returns an abnormal response.</exception>
        private void InstantiateManagers()
        {
            InstantiateManagers(managerTypes);
        }

        /// <summary>
        /// Iterates over the list of Manager Types and instantiates each in the order in which they are represented in the list.
        /// </summary>
        /// <exception cref="MissingMethodException">Thrown when the 'InstantiateManager()' method can not be found.</exception>
        /// <exception cref="MissingMethodException">Thrown when the 'RegisterManager()' method can not be found.</exception>
        /// <exception cref="Exception">Thrown when the Manager instantiation returns an abnormal response.</exception>
        private void InstantiateManagers(List<Type> managerTypes)
        {
            logger.EnterMethod();
            logger.Trace("Instantiating Managers...");

            // iterate over the list
            foreach (Type managerType in managerTypes)
            {
                logger.Separator(LogLevel.Debug);
                logger.Debug("Instantiating '" + managerType.Name + "'...");

                // find the InstantiateManager() method so that we can invoke it via reflection
                MethodInfo instantiateMethod = GetType().GetMethod("InstantiateManager", BindingFlags.NonPublic | BindingFlags.Instance);
                if (instantiateMethod == default(MethodInfo))
                    throw new MissingMethodException("Failed to find the 'InstantiateManager' method within the '" + GetType().Name + "' class.");

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
                        throw new MissingMethodException("Failed to find the 'RegisterManager' method within the '" + GetType().Name + "' class.");

                    // create a generic method using the current Type and invoke it
                    MethodInfo genericRegisterMethod = registerMethod.MakeGenericMethod(managerType);
                    genericRegisterMethod.Invoke(this, new object[] { manager });

                    logger.Debug("Successfully registered '" + manager.GetType().Name + "'.");
                }
                else
                    throw new Exception("Instantiation of Manager '" + managerType.Name + "' returned an abnormal response.");
            }

            logger.ExitMethod();
        }

        /// <summary>
        /// Creates and returns an instance of the specified Manager Type.
        /// </summary>
        /// <typeparam name="T">The Type of the Manager to instantiate.</typeparam>
        /// <returns>The instantiated IManager.</returns>
        /// <exception cref="MissingMethodException">Thrown when the 'Instantiate()' method of the specified Manager Type can not be found.</exception>
        /// <exception cref="MissingMethodException">Thrown when the 'ResolveManagerDependencies()' method can not be found.</exception>
        /// <exception cref="Exception">Thrown when the application fails to resolve dependencies for the specified Manager Type.</exception>
        /// <exception cref="Exception">Thrown when the 'Instantiate()' method of the specified Manager Type returns a null value.</exception>
        /// <exception cref="Exception">Thrown when the object returned by 'Instantiate()' does not implement the IManager interface.</exception>
        /// <exception cref="Exception">Thrown if the instantiation fails.  See inner exception for details.</exception>
        private T InstantiateManager<T>() where T : IManager
        {
            logger.EnterMethod(xLogger.TypeParams(typeof(T)));
            logger.Trace("Creating new instance of '" + typeof(T).Name + "'...");

            T instance;

            try
            {
                // use reflection to locate the static Instantiate() method, then check to make sure it was found.
                MethodInfo method = typeof(T).GetMethod("Instantiate", BindingFlags.NonPublic | BindingFlags.Static);
                if (method == default(MethodInfo))
                    throw new MissingMethodException("Method 'Instantiate' not found in class '" + typeof(T).Name + "'.");

                // use reflection to locate the static ResolveManagerDependencies() method, then check to make sure it was found.
                MethodInfo resolveMethod = GetType().GetMethod("ResolveManagerDependencies", BindingFlags.NonPublic | BindingFlags.Instance);
                if (resolveMethod == default(MethodInfo))
                    throw new MissingMethodException("Method 'ResolveManagerDependencies' was not found in class '" + GetType().Name + "'.");

                // make a generic version of ResolveManagerDependencies() using the specified type, then invoke it and
                // check the result to ensure it is valid.
                MethodInfo genericResolveMethod = resolveMethod.MakeGenericMethod(typeof(T));
                List<IManager> resolvedDependencies = (List<IManager>)genericResolveMethod.Invoke(this, new object[] { });
                if (resolvedDependencies == default(List<IManager>))
                    throw new Exception("Failed to resolve Manager dependencies for '" + typeof(T) + "'.");

                // invoke the Instanctiate() method and pass the resolved dependencies from the step above.
                // store the result in instance, then check to make sure it is not null and ensure that it implements IManager.
                instance = (T)method.Invoke(null, resolvedDependencies.ToArray());
                if (instance == null)
                    throw new Exception("Instantiate() method invocation from '" + typeof(T).Name + "' returned no result.");
                else if (!(instance is IManager))
                    throw new Exception("The instance returned by Instantiate() method invocation from '" + typeof(T).Name + "' does not implement the IManager interface.");

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

            try
            {
                // retrieve the list of parameters for the Instantiate() method of the specified Manager Type and add the type of each
                // to the return value list
                ParameterInfo[] parameters = typeof(T).GetMethod("Instantiate", BindingFlags.NonPublic | BindingFlags.Static).GetParameters();

                foreach (ParameterInfo p in parameters)
                    retVal.Add(p.ParameterType);
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
                    throw new MissingMethodException("Method 'GetManager' was not found in class '" + GetType().Name + "'.");

                MethodInfo getManagerGeneric;

                // retrieve dependencies for the specified Manager
                // any instance of IManager needs to have at least one dependency (ProgramManager).  If we get a null or empty list something is wrong.
                List<Type> dependencies = GetManagerDependencies<T>();
                if ((dependencies == default(List<Type>)) || (dependencies.Count() == 0))
                    throw new Exception("Failed to retrieve dependencies for '" + typeof(T).Name + "'.  Method 'GetManagerDependencies()' returned a null or empty List.");

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
                        throw new Exception("Invocation of method 'GetManager<T>' returned a null instance of IManager.");

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
        /// Adds the specified Manager to the <see cref="managers"/> list and subscribes to its StateChanged event.
        /// </summary>
        /// <typeparam name="T">The Type of the specified Manager.</typeparam>
        /// <param name="manager">The Manager to register.</param>
        /// <returns>The registered Manager.</returns>
        /// <exception cref="Exception">Thrown if the specified Manager has already been registered.</exception>
        /// <exception cref="Exception">Thrown if the registration fails.</exception>
        private T RegisterManager<T>(IManager manager) where T : IManager
        {
            logger.EnterMethod(xLogger.TypeParams(typeof(T)), xLogger.Params(manager));

            T retVal = RegisterManager<T>(manager, managers);

            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        /// Adds the specified Manager to the Manager list and subscribes to its StateChanged event.
        /// </summary>
        /// <typeparam name="T">The Type of the specified Manager.</typeparam>
        /// <param name="manager">The Manager to register.</param>
        /// <param name="managers">The list of Managers to which the Manager is to be registered.</param>
        /// <returns>The registered Manager.</returns>
        /// <exception cref="Exception">Thrown if the specified Manager has already been registered.</exception>
        /// <exception cref="Exception">Thrown if the registration fails.</exception>
        private T RegisterManager<T>(IManager manager, List<IManager> managers) where T : IManager 
        {
            logger.EnterMethod(xLogger.TypeParams(typeof(T)), xLogger.Params(manager, managers));
            logger.Trace("Registering Manager '" + manager.GetType().Name + "'...");

            // ensure the Managers list has been initialized, and if not, initialize it.
            if (managers == default(List<IManager>))
                managers = new List<IManager>();

            // ensure the specified Manager hasn't already been registered.  There can only be one of each Type
            // in the Manager list.
            if (IsRegistered<T>())
                throw new Exception("The Manager '" + manager.GetType().Name + "' is already registered.");

            try
            {
                // add the specified Manager to the list and attach an event handler to its StateChanged event
                managers.Add(manager);
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

        /// <summary>
        /// Returns the Manager from the list of Managers matching the specified Type.
        /// </summary>
        /// <typeparam name="T">The Type of the Manager to return.</typeparam>
        /// <returns>The requested Manager.</returns>
        public T GetManager<T>() where T : IManager
        {
            return GetManager<T>(managers);
        }

        /// <summary>
        /// Returns the Manager from the list of Managers matching the specified Type.
        /// </summary>
        /// <typeparam name="T">The Type of the Manager to return.</typeparam>
        /// <param name="managers">The list of Managers from which to retrieve the specified Manager Type.</param>
        /// <returns>The requested Manager.</returns>
        private T GetManager<T>(List<IManager> managers) where T : IManager
        {
            return managers.OfType<T>().FirstOrDefault();
        }

        /// <summary>
        /// Returns true if the specified Manager Type is registered, false otherwise.
        /// </summary>
        /// <typeparam name="T">The Manager Type to check.</typeparam>
        /// <returns>True if the specified Manager Type is registered, false otherwise.</returns>
        public bool IsRegistered<T>() where T : IManager
        {
            return IsRegistered<T>(managers);
        }

        /// <summary>
        /// Returns true if the specified Manager Type is registered, false otherwise.
        /// </summary>
        /// <typeparam name="T">The Manager Type to check.</typeparam>
        /// <param name="managers">The list of Managers to check.</param>
        /// <returns>True if the specified Manager Type is registered, false otherwise.</returns>
        private bool IsRegistered<T>(List<IManager> managers) where T : IManager
        {
            if (managers.Count() > 0)
                return managers.OfType<T>().Count() > 0;

            return false;
        }

        private void StartManagers()
        {
            StartManagers(managers);
        }

        private Result StartManagers(List<IManager> managers)
        {
            Guid guid = logger.EnterMethod(xLogger.Params(managers), true);

            logger.Debug("Starting Managers...");

            Result retVal = new Result();

            foreach (IManager manager in managers)
                if (manager != this)
                    retVal.Incorporate(StartManager(manager));

            retVal.LogResult(logger);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        /// <summary>
        /// Starts the specified IManager instance
        /// </summary>
        /// <param name="manager">The IManager instance to start.</param>
        /// <returns>A Result containing the result of the operation and the specified IManager instance.</returns>
        internal Result<IManager> StartManager(IManager manager)
        {
            Guid guid = logger.EnterMethod(xLogger.Params(manager), true);

            logger.Debug("Starting " + manager.GetType().Name + "...");
            Result<IManager> retVal = new Result<IManager>();

            // invoke the Start() method on the specified manager
            Result startResult = manager.Start();

            // if the manager fails to start, throw an exception and halt the program
            if (startResult.ResultCode == ResultCode.Failure)
                retVal.AddError("Failed to start Manager '" + manager.GetType().Name + "'.");

            retVal.ReturnValue = manager;
            retVal.Incorporate(startResult);

            logger.Debug("Successfully started " + manager.GetType().Name + ".");

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        /// <summary>
        /// Stops the specified IManager instance.
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="stopType"></param>
        /// <returns></returns>
        internal Result StopManager(IManager manager, StopType stopType = StopType.Normal)
        {
            Guid guid = logger.EnterMethod(xLogger.Params(manager, stopType), true);

            logger.Debug("Stopping " + manager.GetType().Name + "...");

            Result retVal = manager.Stop(stopType);

            if (retVal.ResultCode == ResultCode.Failure)
                retVal.AddError("Failed to stop " + manager.GetType().Name + "." + retVal.LastErrorMessage());

            retVal.LogResult(logger);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        /// <summary>
        /// Changes the <see cref="State"/> of the Manager to the specified state and fires the StateChanged event.
        /// </summary>
        /// <param name="state">The State to which the State property should be changed.</param>
        /// <param name="message">The optional message describing the nature or reason for the change.</param>
        private void ChangeState(State state, string message = "")
        {
            State previousState = State;

            State = state;

            if (StateChanged != null)
                    StateChanged(this, new StateChangedEventArgs(State, previousState, message));
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Event handler for the StateChanged event of registered Managers.
        /// </summary>
        /// <param name="sender">The Manager which fired the event.</param>
        /// <param name="e">The EventArgs for the event.</param>
        private void ManagerStateChanged(object sender, StateChangedEventArgs e)
        {
            logger.Info("Manager '" + sender.GetType().Name + "' state changed from '" + e.PreviousState + "' to '" + e.State + "'." + (e.Message != "" ? "(" + e.Message + ")" : ""));
        }

        #endregion

        #region Static Methods

        /// <summary>
        /// Returns the Singleton instance of ProgramManager
        /// </summary>
        /// <remarks>
        /// Use only in situations where dependency injection is not feasible.
        /// </remarks>
        /// <returns>The Singleton instance of ProgramManager</returns>
        /// <exception cref="Exception">Thrown when the method is invoked prior to the ProgramManager having been instantiated.</exception>
        internal static ProgramManager GetInstance()
        {
            if (instance == null)
                throw new Exception("Failed to retrieve the ProgramManager instance; it has not yet been instantiated.");

            return instance;
        }

        /// <summary>
        /// Returns the "InstanceName" setting from the app.config file, or the default value if the setting is not retreived.
        /// </summary>
        /// <returns>The name of the program instance.</returns>
        public static string GetInstanceName()
        {
            return Utility.GetSetting("InstanceName", "Symbiote");
        }

        #endregion
    }
}
