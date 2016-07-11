using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Timers;

namespace Symbiote.Core
{
    public abstract class Manager : IStateful, IManager
    {
        #region Variables

        /// <summary>
        /// The Logger for this class.
        /// </summary>
        protected xLogger logger = (xLogger)LogManager.GetCurrentClassLogger(typeof(xLogger));

        /// <summary>
        /// The dictionary of IManagers upon which this Manager depends, keyed on Type name.
        /// </summary>
        private Dictionary<Type, IManager> dependencies;

        /// <summary>
        /// The restart timer, used to automatically restart the Manager following a Stop with pending restart.
        /// </summary>
        private Timer restartTimer = new Timer(1000);

        #endregion

        #region Properties

        #region IStateful Properties

        /// <summary>
        /// The state of the Manager.
        /// </summary>
        public State State { get; private set; }

        #endregion

        /// <summary>
        /// The name of the Manager.
        /// </summary>
        public string ManagerName { get; protected set; }

        /// <summary>
        /// The dictionary of IManagers upon which this Manager depends, keyed on Type name.
        /// </summary>
        /// <remarks>
        /// Populated in the constructor as injected dependencies are resolved.
        /// </remarks>
        private Dictionary<Type, IManager> Dependencies
        {
            get
            {
                if (dependencies == default(Dictionary<Type, IManager>))
                    dependencies = new Dictionary<Type, IManager>();

                return dependencies;
            }
            set { dependencies = value; }
        }

        #endregion

        #region Events

        #region IStateful Events

        /// <summary>
        /// Occurs when the State property changes.
        /// </summary>
        public event EventHandler<StateChangedEventArgs> StateChanged;

        #endregion

        #endregion

        #region Instance Methods

        #region IStateful Implementation

        /// <summary>
        /// Returns true if any of the specified <see cref="State"/>s match the current <see cref="State"/>.
        /// </summary>
        /// <param name="states">The list of States to check.</param>
        /// <returns>True if the current State matches any of the specified States, false otherwise.</returns>
        public virtual bool IsInState(params State[] states)
        {
            return states.Any(s => s == State);
        }

        /// <summary>
        /// Starts the Model manager.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        public virtual Result Start()
        {
            Guid guid = logger.EnterMethod(true);
            Result retVal = new Result();

            logger.Info("Starting the " + ManagerName + "...");

            if (!IsInState(State.Initialized, State.Stopped))
                return retVal.AddError("The Manager can not be started when it is in the " + State + " state.");

            if (!CheckDependencies(State.Starting, State.Running))
                return retVal.AddError("One or more dependencies is not in the Starting or Running state.");

            ChangeState(State.Starting);

            retVal.Incorporate(Startup());

            if (retVal.ResultCode != ResultCode.Failure)
                ChangeState(State.Running);
            else
                ChangeState(State.Faulted, retVal.LastErrorMessage());

            retVal.LogResult(logger);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        /// <summary>
        /// Restarts the Configuration manager.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        public virtual Result Restart(StopType stopType = StopType.Normal)
        {
            Guid guid = logger.EnterMethod(true);
            Result retVal = new Result();

            logger.Info("Restarting the " + ManagerName + "...");

            if (!IsInState(State.Running))
                return retVal.AddError("The Manager can not be restarted when it is in the " + State + " state.");

            retVal.Incorporate(Start().Incorporate(Stop(StopType.Normal, true)));

            retVal.LogResult(logger);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        /// <summary>
        /// Stops the Configuration manager.
        /// </summary>
        /// <param name="stopType"></param>
        /// <param name="restartPending"></param>
        /// <returns>A Result containing the result of the operation.</returns>
        public virtual Result Stop(StopType stopType = StopType.Normal, bool restartPending = false)
        {
            Guid guid = logger.EnterMethod(true);
            Result retVal = new Result();

            logger.Info("Stopping the " + ManagerName + "...");

            if (!IsInState(State.Running))
                return retVal.AddError("The Manager can not be stopped when it is in the " + State + " state.");

            ChangeState(State.Stopping);

            if (stopType == StopType.Normal)
                retVal.Incorporate(Shutdown(stopType, restartPending));

            if (restartPending)
            {
                logger.Info("The " + ManagerName + " will continue to attempt to restart.");
                restartTimer.Elapsed += RestartTimerElapsed;
                restartTimer.Start();
            }

            if (retVal.ResultCode != ResultCode.Failure)
                ChangeState(State.Stopped, stopType, restartPending);
            else
                ChangeState(State.Faulted, retVal.LastErrorMessage());

            retVal.LogResult(logger);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        #endregion

        /// <summary>
        /// Implements the Manager-specific startup procedure.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        protected abstract Result Startup();

        /// <summary>
        /// Implements the Manager-specific shutdown procedure.
        /// </summary>
        /// <param name="stopType">The nature of the stoppage.</param>
        /// <param name="restartPending">True if the program intends to later restart the stopped component.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        protected abstract Result Shutdown(StopType stopType = StopType.Normal, bool restartPending = false);

        /// <summary>
        /// Changes the <see cref="State"/> of the Manager to the specified state and fires the StateChanged event.
        /// </summary>
        /// <param name="state">The State to which the State property is to be changed.</param>
        protected virtual void ChangeState(State state)
        {
            ChangeState(state, "", StopType.Normal);
        }

        /// <summary>
        /// Changes the <see cref="State"/> of the Manager to the specified state and fires the StateChanged event.
        /// </summary>
        /// <param name="state">The State to which the State property is to be changed.</param>
        /// <param name="message">The optional message describing the nature or reason for the change.</param>
        protected virtual void ChangeState(State state, string message = "")
        {
            ChangeState(state, message, StopType.Normal, false);
        }

        /// <summary>
        /// Changes the <see cref="State"/> of the Manager to the specified state and fires the StateChanged event.
        /// </summary>
        /// <param name="state">The State to which the State property is to be changed.</param>
        /// <param name="stopType">The StopType associated with a change to the Stopped or Faulted states.</param>
        /// <param name="restartPending">True if the Manager is being stopped pending a restart, false otherwise.</param>
        protected virtual void ChangeState(State state, StopType stopType, bool restartPending = false)
        {
            ChangeState(state, "", stopType, restartPending);
        }

        /// <summary>
        /// Changes the <see cref="State"/> of the Manager to the specified state and fires the StateChanged event.
        /// </summary>
        /// <param name="state">The State to which the State property is to be changed.</param>
        /// <param name="message">The optional message describing the nature or reason for the change.</param>
        /// <param name="stopType">The StopType associated with a change to the Stopped or Faulted states.</param>
        /// <param name="restartPending">True if the Manager is being stopped pending a restart, false otherwise.</param>
        protected virtual void ChangeState(State state, string message = "", StopType stopType = StopType.Normal, bool restartPending = false)
        {
            logger.EnterMethod(xLogger.Params(state, message, stopType, restartPending));

            State previousState = State;

            State = state;

            // if the new State is State.Faulted, ensure StopType is Abnormal
            if (State == State.Faulted) stopType = StopType.Abnormal;

            if (StateChanged != null)
                StateChanged(this, new StateChangedEventArgs(State, previousState, message, stopType, restartPending));

            logger.ExitMethod();
        }

        /// <summary>
        /// Retrieves the <see cref="IManager"/> instance matching the specified <see cref="Type"/> from the <see cref="Dependencies"/> dictionary.
        /// </summary>
        /// <typeparam name="T">The Type of Manager to return.</typeparam>
        /// <returns>The resolved instance of the specified Manager Type.</returns>
        /// <exception cref="KeyNotFoundException">Thrown if the specified Type is not found in the <see cref="Dependencies"/> dictionary.</exception>
        protected virtual T Dependency<T>()
        {
            if (!Dependencies.ContainsKey(typeof(T)))
                throw new KeyNotFoundException("The Dependency '" + typeof(T) + "' for Manager + " + ManagerName + " has not been resolved (no matching key in dictionary).");

            return (T)Dependencies[typeof(T)];
        }

        /// <summary>
        /// Adds the specified <see cref="IManager"/> instance of the specified <see cref="Type"/> to the <see cref="Dependencies"/> dictionary.
        /// </summary>
        /// <typeparam name="T">The Type of Manager to add.</typeparam>
        /// <param name="manager">The resolved instance of the specified Manager Type.</param>
        /// <returns>The added IManager instance.</returns>
        protected virtual T RegisterDependency<T>(IManager manager)
        {
            Dependencies.Add(typeof(T), manager);
            return (T)manager;
        }

        /// <summary>
        /// Examines the <see cref="State"/> of the <see cref="IManager"/>s contained within the <see cref="Dependencies"/> property 
        /// to ensure each is in the <see cref="State.Running"/> state.  If not, an error message is added to the return <see cref="Result"/>.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        protected virtual Result CheckDependencies(params State[] states)
        {
            logger.EnterMethod();
            Result retVal = new Result();

            foreach (Type managerType in Dependencies.Keys)
                if (!Dependencies[managerType].IsInState(states))
                    retVal.AddError("The dependency '" + managerType.GetType().Name + "' has not been started (current state is " + Dependencies[managerType].State + ").");

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal);
            return retVal;
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Occurs when the restart timer's interval elapses.
        /// </summary>
        /// <remarks>
        /// The timer starts upon stop of the Manager when the restartPending flag is true and stops upon successful restart of this Manager.
        /// </remarks>
        /// <param name="sender">This Manager.</param>
        /// <param name="e">The EventArgs for the event.</param>
        private void RestartTimerElapsed(object sender, ElapsedEventArgs e)
        {
            logger.EnterMethod();
            logger.Debug("Checking dependencies for " + ManagerName + " to see whether a restart can be attempted...");

            // check all of the dependencies to see whether they are running
            if (CheckDependencies(State.Running))
            {
                logger.Debug("All dependencies for " + ManagerName + " are running.  Attempting to start...");
                // if all of the dependencies are running, start the Manager.
                Result startResult = Start();

                // if it started successfully, stop the timer and remove the event handler.
                if (startResult.ResultCode != ResultCode.Failure)
                {
                    logger.Debug("Restart of " + ManagerName + " successful.");
                    restartTimer.Stop();
                    restartTimer.Elapsed -= RestartTimerElapsed;
                }
                else
                    logger.Debug("Failed to restart " + ManagerName + ": " + startResult.LastErrorMessage());
            }

            logger.ExitMethod();
        }

        /// <summary>
        /// Occurs when the state of a Manager upon which this Manager is dependent changes.
        /// </summary>
        /// <param name="sender">The Manager whose state changed.</param>
        /// <param name="e">The EventArgs for the event.</param>
        protected virtual void DependencyStateChanged(object sender, StateChangedEventArgs e)
        {
            logger.EnterMethod(xLogger.Params(new xLogger.ExcludedParam(), e));

            // only react if the state of this manager is Running or Starting
            if (IsInState(State.Running, State.Starting))
            {
                // if the new state of the dependency is Faulted, stop with the abnormal flag
                if (e.State == State.Faulted)
                {
                    logger.Info("The dependency " + sender.GetType().Name + " has faulted with the following message:");
                    logger.Info("\t" + (e.Message.Length > 0 ? e.Message : "[no message provided]"));
                    logger.Info("The " + ManagerName + " must now stop, and will attempt to restart periodically until the dependency starts again.");

                    Stop(StopType.Abnormal, e.RestartPending);
                }
                else if (e.State == State.Stopped)
                {
                    logger.Info("The dependency '" + sender.GetType().Name + "' has stopped with StopType of " + e.StopType + 
                        (e.RestartPending ? ", and a restart is pending" : "") + 
                        ".  The " + ManagerName + " must now stop" + (e.RestartPending ? " and will start when the dependency starts again." : "."));

                    Stop(e.StopType, e.RestartPending);
                }
            }

            logger.ExitMethod();
        }

        #endregion
    }
}
