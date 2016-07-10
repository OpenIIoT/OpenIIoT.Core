using NLog;
using System;

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
        /// The ProgramManager for the application.
        /// </summary>
        protected IProgramManager manager;

        /// <summary>
        /// The name of the Manager.
        /// </summary>
        protected string managerName;

        #endregion

        #region Properties

        #region IStateful Properties

        /// <summary>
        /// The state of the Manager.
        /// </summary>
        public State State { get; private set; }

        #endregion

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
        /// Starts the Model manager.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        public virtual Result Start()
        {
            Guid guid = logger.EnterMethod(true);
            Result retVal = new Result();

            logger.Info("Starting the " + managerName + "...");

            if ((State == State.Undefined) || (State == State.Running) || (State == State.Stopping) || (State == State.Starting))
                return retVal.AddError("The Manager can not be started when it is in the " + State + " state.");
            
            ChangeState(State.Starting);

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

            logger.Info("Restarting the " + managerName + "...");

            if (State != State.Running)
                return retVal.AddError("The Manager can not be restarted when it is in the " + State + " state.");

            retVal.Incorporate(Start().Incorporate(Stop(StopType.Normal, true)));

            retVal.LogResult(logger);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        /// <summary>
        /// Stops the Configuration manager.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        public virtual Result Stop(StopType stopType = StopType.Normal, bool restartPending = false)
        {
            Guid guid = logger.EnterMethod(true);
            Result retVal = new Result();

            logger.Info("Stopping the " + managerName + "...");

            if ((State == State.Undefined) || (State == State.Faulted) || (State == State.Stopping) || (State == State.Starting))
                return retVal.AddError("The Manager can not be stopped when it is in the " + State + " state.");

            ChangeState(State.Stopping);

            if (retVal.ResultCode != ResultCode.Failure)
                ChangeState(State.Stopped);
            else
                ChangeState(State.Faulted, retVal.LastErrorMessage());

            retVal.LogResult(logger);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        #endregion

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
            ChangeState(state, message, StopType.Normal);
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
            State previousState = State;

            State = state;

            if (State == State.Faulted) stopType = StopType.Abnormal;

            if (StateChanged != null)
                StateChanged(this, new StateChangedEventArgs(State, previousState, message, stopType, restartPending));
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Examines the <see cref="State"/> of the specified <see cref="IManager"/>s to ensure each is in the
        /// <see cref="State.Running"/> state.  If not, an error message is added to the return <see cref="Result"/>.
        /// </summary>
        /// <param name="managers">The list of Managers to examine.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        protected virtual Result CheckDependencies(params IManager[] managers)
        {
            logger.EnterMethod();
            Result retVal = new Result();

            foreach (IManager manager in managers)
                if ((manager.State != State.Running) && (manager.State != State.Starting))
                    retVal.AddError("The dependency '" + manager.GetType().Name + "' has not been started.");
            
            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        /// Occurs when the state of a Manager upon which this Manager is dependent changes.
        /// </summary>
        /// <param name="sender">The Manager whose state changed.</param>
        /// <param name="e">The EventArgs for the event.</param>
        protected virtual void DependencyStateChanged(object sender, StateChangedEventArgs e)
        {
            if (State == State.Running)
            {
                if ((e.State == State.Stopped) || (e.State == State.Faulted))
                {
                    logger.Info("The dependency '" + sender.GetType().Name + "' has stopped.  Stopping...");

                    Stop((e.State == State.Faulted ? StopType.Abnormal : e.StopType));
                }
            }
        }

        #endregion
    }
}
