using System;
using System.Collections.Generic;
using Symbiote.Core.Platform;
using Symbiote.Core.Plugin;
using Symbiote.Core.Model;
using Symbiote.Core.Configuration;
using NLog;
using Symbiote.Core.Service;
using System.Linq;
using System.Reflection;

namespace Symbiote.Core
{
    /// <summary>
    /// The ProgramManager acts as a Service Locator for the application and contains references to both 
    /// the Manager for each service as well as references to the key resources contained within each namespace.
    /// </summary>
    public class ProgramManager : IManager
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

        #endregion

        #region Properties

        #region IManager Implementation

        /// <summary>
        /// The state of the Manager.
        /// </summary>
        public State State { get; private set; }

        /// <summary>
        /// The list of dependencies for the Manager.
        /// </summary>
        /// <remarks>
        /// The ProgramManager has no dependencies.
        /// </remarks>
        public List<Type> Dependencies { get { return default(List<Type>); } }

        #endregion

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
        public string InstanceName { get { return Utility.GetSetting("InstanceName", ProductName);  } }

        /// <summary>
        /// The list of application Manager Types.
        /// </summary>
        /// <remarks>
        /// The Type of each application Manager must be added in the order in which they are to be instantiated and started.
        /// </remarks>
        public List<Type> ManagerTypes {
            get
            {
                return new Type[]
                {
                    typeof(PlatformManager),
                    typeof(ConfigurationManager),
                    typeof(PluginManager),
                    typeof(ModelManager),
                    typeof(ServiceManager)
                }.ToList();
            }
        }

        /// <summary>
        /// The list of application Managers.
        /// </summary>
        public List<IManager> Managers { get; private set; }

        #endregion

        #region Events

        #region IManager Events

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
        private ProgramManager(bool safeMode = false)
        {
            Guid guid = logger.EnterMethod(xLogger.Params(safeMode), true);

            //-------------------------   -  -
            // configure the SafeMode option
            SafeMode = safeMode;

            if (safeMode)
                logger.Info("Safe Mode enabled.  The program is now running in a limited fault tolerant mode.");
            //---------------- -  


            //---------------------- -   ----------------------- -      --------  -    -
            // create an instance of each Manager Type in the ManagerTypes list
            logger.Debug("Instantiating Managers...");

            // iterate over the list
            foreach (Type managerType in ManagerTypes)
            {
                logger.Separator(LogLevel.Trace);
                logger.Debug("Instantiating '" + managerType.Name + "'...");

                // find the InstantiateManager() method so that we can invoke it via reflection
                MethodInfo instantiateMethod = GetType().GetMethod("InstantiateManager", BindingFlags.NonPublic | BindingFlags.Instance);

                // make sure the method was found
                if (instantiateMethod == default(MethodInfo))
                    throw new Exception("Failed to find the 'InstantiateManager' method within the '" + GetType().Name + "' class.");

                // create a generic method using the current Type
                MethodInfo genericInstantiateMethod = instantiateMethod.MakeGenericMethod(managerType);

                // invoke the generic method and store the resulting IManager
                IManager manager = (IManager)genericInstantiateMethod.Invoke(this, null);

                // ensure the resulting IManager is valid
                if (manager != default(IManager))
                {
                    logger.Debug("Successfully instantiated '" + manager.GetType().Name + "'.  Registering...");

                    // register the IManager
                    MethodInfo registerMethod = GetType().GetMethod("RegisterManager", BindingFlags.NonPublic | BindingFlags.Instance);

                    if (registerMethod == default(MethodInfo))
                        throw new Exception("Failed to find the 'RegisterManager' method within the '" + GetType().Name + "' class.");

                    // create a generic method using the current Type
                    MethodInfo genericRegisterMethod = registerMethod.MakeGenericMethod(managerType);

                    // invoke it
                    genericRegisterMethod.Invoke(this, new object[] { manager });

                    logger.Debug("Successfully registered '" + manager.GetType().Name + "'.");
                }
                else
                    throw new Exception("Instantiation of Manager '" + managerType.Name + "' returned an abnormal response.");
                //------------------------------- -  -               ------------ 
            }

            logger.ExitMethod(guid);
        }

        /// <summary>
        /// Returns the singleton instance of the ProgramManager.  Creates an instance if null.
        /// </summary>
        /// <returns>The singleton instance of the ProgramManager</returns>
        internal static ProgramManager Instance(bool safeMode = false)
        {
            if (instance == null)
                instance = new ProgramManager(safeMode);

            return instance;
        }

        #endregion

        #region Instance Methods

        #region IManager Implementation

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

            if (retVal.ResultCode != ResultCode.Failure)
                ChangeState(State.Running);
            else
                ChangeState(State.Faulted);

            retVal.LogResult(logger);
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
            Result retVal = new Result();
            
            retVal.Incorporate(Stop(stopType));
            retVal.Incorporate(Start());

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

            State = State.Stopping;

            if (retVal.ResultCode != ResultCode.Failure)
                State = State.Stopped;
            else
                State = State.Faulted;

            retVal.LogResult(logger);
            logger.ExitMethod(retVal);
            return new Result();
        }

        #endregion

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
                throw new Exception("Failed to start " + manager.GetType().Name + "." + startResult.LastErrorMessage());

            retVal.ReturnValue = manager;
            retVal.Incorporate(startResult);

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
                throw new Exception("Failed to stop " + manager.GetType().Name + "." + retVal.LastErrorMessage());

            retVal.LogResult(logger);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        /// <summary>
        /// Creates and returns an instance of the specified Manager Type.
        /// </summary>
        /// <typeparam name="T">The Type of the Manager to instantiate.</typeparam>
        /// <returns>The instantiated IManager.</returns>
        /// <exception cref="Exception">Thrown if the instantiation fails.</exception>
        private IManager InstantiateManager<T>() where T : IManager
        {
            logger.EnterMethod();
            logger.Debug("Creating new instance of '" + typeof(T).Name + "'...");

            T instance;

            try
            {
                // use reflection to locate the static Instance() method
                MethodInfo method = typeof(T).GetMethod("Instance", BindingFlags.Static | BindingFlags.NonPublic);

                // if the method wasn't found, bail out.
                if (method == default(MethodInfo))
                    throw new Exception("Method 'Instance' not found in class '" + typeof(T).Name + "'.");

                // invoke the method and store the result in instance
                instance = (T)method.Invoke(null, new object[] { this });

                // if the instance is null or is not assignable from IManager, bail out
                if (instance == null)
                    throw new Exception("Instance() method invocation from '" + typeof(T).Name + "' returned no result.");
                else if (!(instance is IManager))
                    throw new Exception("The instance returned by Instance() method invocation from '" + typeof(T).Name + "' does not implement IManager.");

                logger.Debug("Successfully instantiated '" + instance.GetType().Name + "'.");
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
        /// <exception cref="Exception">Thrown if the registration fails.</exception>
        private IManager RegisterManager<T>(IManager manager) where T : IManager
        {
            logger.EnterMethod(xLogger.Params(manager));
            logger.Trace("Registering manager '" + manager.GetType().Name + "'...");

            // ensure the Managers list has been initialized, and if not, initialize it.
            if (Managers == default(List<IManager>))
                Managers = new List<IManager>();

            // ensure the specified Manager hasn't already been registered.  There can only be one of each Type
            // in the Manager list.
            if (IsRegistered<T>())
                throw new Exception("The Manager '" + manager.GetType().Name + "' is already registered.");

            try
            {
                // add the specified Manager to the list and attach an event handler to its StateChanged event
                Managers.Add(manager);
                manager.StateChanged += ManagerStateChanged;
            }
            catch (Exception ex)
            {
                logger.Exception(ex);
                throw new Exception("Failed to register Manager '" + manager.GetType().Name + "': " + ex.Message, ex);
            }

            logger.ExitMethod();
            return manager;
        }

        /// <summary>
        /// Returns the Manager from the list of Managers matching the specified Type.
        /// </summary>
        /// <typeparam name="T">The Type of the Manager to return.</typeparam>
        /// <returns>The requested Manager.</returns>
        public T GetManager<T>() where T : IManager
        {
            return Managers.OfType<T>().FirstOrDefault();
        }

        /// <summary>
        /// Returns true if the specified Manager Type is registered, false otherwise.
        /// </summary>
        /// <typeparam name="T">The Manager Type to check.</typeparam>
        /// <returns>True if the specified Manager Type is registered, false otherwise.</returns>
        public bool IsRegistered<T>() where T : IManager
        {
            return Managers.OfType<T>().Count() > 0;
        }

        /// <summary>
        /// Event handler for the StateChanged event of registered Managers.
        /// </summary>
        /// <param name="sender">The Manager which fired the event.</param>
        /// <param name="e">The EventArgs for the event.</param>
        private void ManagerStateChanged(object sender, StateChangedEventArgs e)
        {
            logger.Info("Manager '" + sender.GetType().Name + "' state changed from '" + e.PreviousState + "' to '" + e.State + "'." + (e.Message != "" ? "(" + e.Message + ")" : ""));
        }

        /// <summary>
        /// Examines the list of <see cref="IManager"/> in <see cref="Managers"/> to ensure a Manager corresponding to each Type
        /// in the specified list has been instantiated and is in the <see cref="State.Running"/> state.
        /// </summary>
        /// <param name="types">The list of dependent Manager Types.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result<List<Type>> CheckDependencies(List<Type> types)
        {
            logger.EnterMethod(xLogger.Params(types));
            logger.Trace("Checking dependencies...");

            Result<List<Type>> retVal = new Result<List<Type>>();
            retVal.ReturnValue = new List<Type>();

            // iterate over the specified list of Types and check each one to ensure it has been instantiated
            // and started
            foreach (Type t in types)
            {
                if (t == GetType())
                {
                    if (State == State.Running)
                        continue;
                    else
                    {
                        retVal.AddError("The Program Manager is not in the Running state.");
                    }
                }

                // find the first (hopefully only) instance of the current Type
                IManager instance = Managers.Where(m => m.GetType() == t).FirstOrDefault();

                if (instance == default(IManager))
                {
                    retVal.AddError("The dependent Manager '" + t.Name + "' hasn't been instantiated.");
                    retVal.ReturnValue.Add(t);
                }
                else
                {
                    if (instance.State != State.Running)
                    {
                        retVal.AddError("The dependent Manager '" + t.Name + "' is not in the Running state (it is " + instance.State + ").");
                        retVal.ReturnValue.Add(t);
                    }
                }
            }

            retVal.LogResult(logger.Trace);
            logger.ExitMethod(retVal);
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

        #region Static Methods

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
