/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀ 
      █   
      █      ▄▄▄▄███▄▄▄▄                                                             
      █    ▄██▀▀▀███▀▀▀██▄                                                           
      █    ███   ███   ███   ▄█████  ██▄▄▄▄    ▄█████     ▄████▄     ▄█████    █████ 
      █    ███   ███   ███   ██   ██ ██▀▀▀█▄   ██   ██   ██    ▀    ██   █    ██  ██ 
      █    ███   ███   ███   ██   ██ ██   ██   ██   ██  ▄██        ▄██▄▄     ▄██▄▄█▀ 
      █    ███   ███   ███ ▀████████ ██   ██ ▀████████ ▀▀██ ███▄  ▀▀██▀▀    ▀███████ 
      █    ███   ███   ███   ██   ██ ██   ██   ██   ██   ██    ██   ██   █    ██  ██ 
      █     ▀█   ███   █▀    ██   █▀  █   █    ██   █▀   ██████▀    ███████   ██  ██ 
      █   
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄ 
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █ 
      ▄  
      █  The abstract base class from which all Managers inherit.
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
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Timers;
using NLog;

namespace Symbiote.Core
{
    /// <summary>
    /// The abstract base class from which all Managers inherit.
    /// </summary>
    public abstract class Manager : IStateful, IManager
    {
        #region Variables

        /// <summary>
        /// The Logger for this class.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Reviewed.")]
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

        #region Events

        #region IStateful Events

        /// <summary>
        /// Occurs when the State property changes.
        /// </summary>
        public event EventHandler<StateChangedEventArgs> StateChanged;

        #endregion

        #endregion

        #region Properties

        #region IStateful Properties

        /// <summary>
        /// Gets the current State of the stateful object.
        /// </summary>
        public State State { get; private set; }

        #endregion

        #region IManager Properties

        /// <summary>
        /// Gets or sets the name of the Manager.
        /// </summary>
        public string ManagerName { get; protected set; }

        #endregion

        /// <summary>
        /// Gets or sets the dictionary of IManagers upon which this Manager depends, keyed on Type name.
        /// </summary>
        /// <remarks>
        /// Populated in the constructor of extension classes as injected dependencies are resolved.
        /// </remarks>
        private Dictionary<Type, IManager> Dependencies
        {
            get
            {
                if (this.dependencies == default(Dictionary<Type, IManager>))
                {
                    this.dependencies = new Dictionary<Type, IManager>();
                }

                return this.dependencies;
            }

            set
            {
                this.dependencies = value;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        #region Public Instance Methods

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
            Guid guid = this.logger.EnterMethod(true);
            this.logger.Info("Starting the " + this.ManagerName + "...");
            Result retVal = new Result();

            if (!this.IsInState(State.Initialized, State.Stopped))
            {
                return retVal.AddError("The Manager can not be started when it is in the " + State + " state.");
            }

            if (!this.DependenciesAreAllInState(State.Starting, State.Running))
            {
                return retVal.AddError("One or more dependencies is not in the Starting or Running state.");
            }

            this.ChangeState(State.Starting);

            // invoke the manager-specific startup routine
            retVal.Incorporate(this.Startup());

            if (retVal.ResultCode != ResultCode.Failure)
            {
                this.ChangeState(State.Running);
            }
            else
            {
                this.ChangeState(State.Faulted, retVal.LastErrorMessage());
            }

            retVal.LogResult(this.logger);
            this.logger.ExitMethod(retVal, guid);
            return retVal;
        }

        /// <summary>
        /// Restarts the Configuration manager.
        /// </summary>
        /// <param name="stopType">The nature of the stoppage.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public virtual Result Restart(StopType stopType = StopType.Normal)
        {
            Guid guid = this.logger.EnterMethod(true);
            this.logger.Info("Restarting the " + this.ManagerName + "...");
            Result retVal = new Result();

            if (!this.IsInState(State.Running))
            {
                return retVal.AddError("The Manager can not be restarted when it is in the " + State + " state.");
            }

            retVal.Incorporate(this.Start().Incorporate(this.Stop(StopType.Normal, true)));

            retVal.LogResult(this.logger);
            this.logger.ExitMethod(retVal, guid);
            return retVal;
        }

        /// <summary>
        /// Stops the Configuration manager.
        /// </summary>
        /// <param name="stopType">The nature of the stoppage.</param>
        /// <param name="restartPending">True if the program intends to later restart the stopped component.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public virtual Result Stop(StopType stopType = StopType.Normal, bool restartPending = false)
        {
            Guid guid = this.logger.EnterMethod(true);
            this.logger.Info("Stopping the " + this.ManagerName + "...");
            Result retVal = new Result();

            if (!this.IsInState(State.Running))
            {
                return retVal.AddError("The Manager can not be stopped when it is in the " + State + " state.");
            }

            this.ChangeState(State.Stopping);

            // invoke the manager-specific shutdown routine
            retVal.Incorporate(this.Shutdown(stopType, restartPending));

            // if the restartPending flag is set, start the restart timer
            // this timer will continuously attempt to restart the Manager until all dependencies
            // are satisfied, after which point it will start.
            if (restartPending)
            {
                this.logger.Info("The " + this.ManagerName + " will continue to attempt to restart.");
                this.restartTimer.Elapsed += this.RestartTimerElapsed;
                this.restartTimer.Start();
            }

            if (retVal.ResultCode != ResultCode.Failure)
            {
                this.ChangeState(State.Stopped, stopType, restartPending);
            }
            else
            {
                this.ChangeState(State.Faulted, retVal.LastErrorMessage());
            }

            retVal.LogResult(this.logger);
            this.logger.ExitMethod(retVal, guid);
            return retVal;
        }

        #endregion

        #endregion

        #endregion

        #region Protected Methods

        #region Protected Instance Methods

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
            this.ChangeState(state, string.Empty, StopType.Normal);
        }

        /// <summary>
        /// Changes the <see cref="State"/> of the Manager to the specified state and fires the StateChanged event.
        /// </summary>
        /// <param name="state">The State to which the State property is to be changed.</param>
        /// <param name="message">The optional message describing the nature or reason for the change.</param>
        protected virtual void ChangeState(State state, string message = "")
        {
            this.ChangeState(state, message, StopType.Normal, false);
        }

        /// <summary>
        /// Changes the <see cref="State"/> of the Manager to the specified state and fires the StateChanged event.
        /// </summary>
        /// <param name="state">The State to which the State property is to be changed.</param>
        /// <param name="stopType">The StopType associated with a change to the Stopped or Faulted states.</param>
        /// <param name="restartPending">True if the Manager is being stopped pending a restart, false otherwise.</param>
        protected virtual void ChangeState(State state, StopType stopType, bool restartPending = false)
        {
            this.ChangeState(state, string.Empty, stopType, restartPending);
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
            this.logger.EnterMethod(xLogger.Params(state, message, stopType, restartPending));

            State previousState = State;

            State = state;

            // if the new State is State.Faulted, ensure StopType is Abnormal
            if (State == State.Faulted)
            {
                stopType = StopType.Abnormal;
            }

            if (this.StateChanged != null)
            {
                this.StateChanged(this, new StateChangedEventArgs(State, previousState, message, stopType, restartPending));
            }

            this.logger.ExitMethod();
        }

        /// <summary>
        /// Retrieves the <see cref="IManager"/> instance matching the specified <see cref="Type"/> from the <see cref="Dependencies"/> dictionary.
        /// </summary>
        /// <typeparam name="T">The Type of Manager to return.</typeparam>
        /// <returns>The resolved instance of the specified Manager Type.</returns>
        /// <exception cref="KeyNotFoundException">Thrown if the specified Type is not found in the <see cref="Dependencies"/> dictionary.</exception>
        protected virtual T Dependency<T>()
        {
            if (!this.Dependencies.ContainsKey(typeof(T)))
            {
                throw new KeyNotFoundException("The Dependency '" + typeof(T) + "' for Manager + " + this.ManagerName + " has not been resolved (no matching key in dictionary).");
            }

            return (T)this.Dependencies[typeof(T)];
        }

        /// <summary>
        /// Adds the specified <see cref="IManager"/> instance of the specified <see cref="Type"/> to the <see cref="Dependencies"/> dictionary.
        /// </summary>
        /// <typeparam name="T">The Type of Manager to add.</typeparam>
        /// <param name="manager">The resolved instance of the specified Manager Type.</param>
        /// <returns>The added IManager instance.</returns>
        protected virtual T RegisterDependency<T>(IManager manager)
        {
            this.Dependencies.Add(typeof(T), manager);
            manager.StateChanged += this.DependencyStateChanged;
            return (T)manager;
        }

        /// <summary>
        /// Examines the <see cref="State"/> of the <see cref="IManager"/>s contained within the <see cref="Dependencies"/> property 
        /// to ensure each is in the <see cref="State.Running"/> state.  If not, an error message is added to the return <see cref="Result"/>.
        /// </summary>
        /// <param name="states">The list of States to which the state of each dependency will be compared.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        protected virtual Result DependenciesAreAllInState(params State[] states)
        {
            this.logger.EnterMethod();
            Result retVal = new Result();

            foreach (Type managerType in this.Dependencies.Keys)
            {
                if (!this.Dependencies[managerType].IsInState(states))
                {
                    retVal.AddError("The dependency '" + managerType.GetType().Name + "' has not been started (current state is " + this.Dependencies[managerType].State + ").");
                }
            }

            retVal.LogResult(this.logger.Debug);
            this.logger.ExitMethod(retVal);
            return retVal;
        }

        #endregion

        #endregion

        #region Private Methods

        #region Private Instance Methods

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
            this.logger.EnterMethod();
            this.logger.Debug("Checking dependencies for " + this.ManagerName + " to see whether a restart can be attempted...");

            // check all of the dependencies to see whether they are running
            if (this.DependenciesAreAllInState(State.Running))
            {
                this.logger.Debug("All dependencies for " + this.ManagerName + " are running.  Attempting to start...");

                // if all of the dependencies are running, start the Manager.
                Result startResult = this.Start();

                // if it started successfully, stop the timer and remove the event handler.
                if (startResult.ResultCode != ResultCode.Failure)
                {
                    this.logger.Debug("Restart of " + this.ManagerName + " successful.");
                    this.restartTimer.Stop();
                    this.restartTimer.Elapsed -= this.RestartTimerElapsed;
                }
                else
                {
                    this.logger.Debug("Failed to restart " + this.ManagerName + ": " + startResult.LastErrorMessage());
                }
            }

            this.logger.ExitMethod();
        }

        /// <summary>
        /// Occurs when the state of a Manager upon which this Manager is dependent changes.
        /// </summary>
        /// <param name="sender">The Manager whose state changed.</param>
        /// <param name="e">The EventArgs for the event.</param>
        private void DependencyStateChanged(object sender, StateChangedEventArgs e)
        {
            this.logger.EnterMethod(xLogger.Params(new xLogger.ExcludedParam(), e));

            // only react if the state of this manager is Running or Starting
            if (this.IsInState(State.Running, State.Starting))
            {
                // if the new state of the dependency is Faulted, stop with the abnormal flag
                if (e.State == State.Faulted)
                {
                    this.logger.Info("The dependency " + sender.GetType().Name + " has faulted with the following message:");
                    this.logger.Info("\t" + (e.Message.Length > 0 ? e.Message : "[no message provided]"));
                    this.logger.Info("The " + this.ManagerName + " must now stop, and will attempt to restart periodically until the dependency starts again.");

                    this.Stop(StopType.Abnormal, e.RestartPending);
                }
                else if (e.State == State.Stopped)
                {
                    string msg = "The dependency '" + sender.GetType().Name + "' has stopped with StopType of " + e.StopType +
                        (e.RestartPending ? ", and a restart is pending" : string.Empty) +
                        ".  The " + this.ManagerName + " must now stop" + (e.RestartPending ? " and will start when the dependency starts again." : ".");

                    this.logger.Info(msg);

                    this.Stop(e.StopType, e.RestartPending);
                }
            }

            this.logger.ExitMethod();
        }

        #endregion

        #endregion

        #endregion

        #endregion
    }
}
