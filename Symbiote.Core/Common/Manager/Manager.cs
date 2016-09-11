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
using NLog.xLogger;
using Symbiote.Core.Event;
using Utility.OperationResult;

namespace Symbiote.Core
{
    /// <summary>
    ///     The abstract base class from which all Managers inherit.
    /// </summary>
    public abstract class Manager : IDisposable, IStateful, IEventProvider, IManager
    {
        #region Fields

        /// <summary>
        ///     The Logger for this class.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Allows GetCurrentClassLogger() in extension classes.")]
        protected xLogger logger = (xLogger)LogManager.GetCurrentClassLogger(typeof(xLogger));

        /// <summary>
        ///     The dictionary of IManagers upon which this Manager depends, keyed on Type name.
        /// </summary>
        private Dictionary<Type, IManager> dependencies;

        /// <summary>
        ///     The restart timer, used to automatically restart the Manager following a Stop with pending restart.
        /// </summary>
        private Timer restartTimer = new Timer(1000);

        #endregion

        #region Events

        #region IStateful Events

        /// <summary>
        ///     Occurs when the State property changes.
        /// </summary>
        [Event(Description = "Occurs when the State property changes.")]
        public event EventHandler<StateChangedEventArgs> StateChanged;

        #endregion

        #endregion

        #region Properties

        #region Public Properties

        #region IStateful Properties

        /// <summary>
        ///     Gets the current State of the stateful object.
        /// </summary>
        public State State { get; private set; }

        #endregion

        #region IEventProvider Properties

        /// <summary>
        ///     Gets the name of the instance for use with the Event subsystem.
        /// </summary>
        public string EventProviderName
        {
            get
            {
                return GetType().Name;
            }
        }

        #endregion

        #region IManager Properties

        /// <summary>
        ///     Gets or sets the name of the Manager.
        /// </summary>
        public string ManagerName { get; protected set; }

        #endregion

        #endregion

        #region Private Properties

        /// <summary>
        ///     Gets or sets the dictionary of IManagers upon which this Manager depends, keyed on Type name.
        /// </summary>
        /// <remarks>
        ///     Populated in the constructor of extension classes as injected dependencies are resolved.
        /// </remarks>
        private Dictionary<Type, IManager> Dependencies
        {
            get
            {
                if (dependencies == default(Dictionary<Type, IManager>))
                {
                    dependencies = new Dictionary<Type, IManager>();
                }

                return dependencies;
            }

            set
            {
                dependencies = value;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        #region Public Instance Methods

        #region IDisposable Implementation

        /// <summary>
        ///     Disposes this <see cref="Manager"/>.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region IStateful Implementation

        /// <summary>
        ///     Determines whether any of the specified <see cref="IStateful.State"/>s match the current <see cref="State"/>.
        /// </summary>
        /// <param name="states">The list of States to check.</param>
        /// <returns>A value indicating whether the current State matches any of the specified States.</returns>
        public bool IsInState(params State[] states)
        {
            return states.Any(s => s == State);
        }

        /// <summary>
        ///     Starts the Manager.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result Start()
        {
            Guid guid = logger.EnterMethod(true);
            logger.Info("Starting the " + ManagerName + "...");
            Result retVal = new Result();

            if (!IsInState(State.Initialized, State.Stopped))
            {
                return retVal.AddError("The Manager can not be started when it is in the " + State + " state.");
            }

            if (!DependenciesAreAllInState(State.Starting, State.Running))
            {
                return retVal.AddError("One or more dependencies is not in the Starting or Running state.");
            }

            ChangeState(State.Starting);

            // invoke the manager-specific startup routine
            retVal.Incorporate(Startup());

            if (retVal.ResultCode != ResultCode.Failure)
            {
                ChangeState(State.Running);
            }
            else
            {
                ChangeState(State.Faulted, retVal.GetLastError());
            }

            retVal.LogResult(logger);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        /// <summary>
        ///     Restarts the Manager.
        /// </summary>
        /// <param name="stopType">The nature of the stoppage.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result Restart(StopType stopType = StopType.Stop)
        {
            Guid guid = logger.EnterMethod(xLogger.Params(stopType), true);
            logger.Info("Restarting the " + ManagerName + "...");
            Result retVal = new Result();

            if (!IsInState(State.Running))
            {
                return retVal.AddError("The Manager can not be restarted when it is in the " + State + " state.");
            }

            retVal.Incorporate(Start().Incorporate(Stop(stopType | StopType.Restart)));

            retVal.LogResult(logger);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        /// <summary>
        ///     Stops the Manager.
        /// </summary>
        /// <param name="stopType">The nature of the stoppage.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result Stop(StopType stopType = StopType.Stop)
        {
            Guid guid = logger.EnterMethod(xLogger.Params(stopType), true);
            logger.Info("Stopping the " + ManagerName + "...");
            Result retVal = new Result();

            if (!IsInState(State.Running))
            {
                return retVal.AddError("The Manager can not be stopped when it is in the " + State + " state.");
            }

            ChangeState(State.Stopping, stopType);

            // invoke the manager-specific shutdown routine
            retVal.Incorporate(Shutdown(stopType));

            // if the restartPending flag is set, start the restart timer
            // this timer will continuously attempt to restart the Manager until all dependencies
            // are satisfied, after which point it will start.
            if (stopType.HasFlag(StopType.Restart))
            {
                logger.Info("The " + ManagerName + " will continue to attempt to restart.");
                restartTimer.Elapsed += RestartTimerElapsed;
                restartTimer.Start();
            }

            if (retVal.ResultCode != ResultCode.Failure)
            {
                ChangeState(State.Stopped, stopType);
            }
            else
            {
                ChangeState(State.Faulted, "Error stopping Manager: " + retVal.GetLastError(), StopType.Exception);
            }

            retVal.LogResult(logger);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        #endregion

        #endregion

        #endregion

        #region Protected Methods

        #region Protected Instance Methods
        
        /// <summary>
        ///     Disposes the <see cref="restartTimer"/> property.
        /// </summary>
        /// <param name="disposing">Indicates whether the object is in the process of disposing.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Teardown();
                restartTimer.Dispose();
            }
        }

        /// <summary>
        ///     Implements the Manager-specific post-instantiation procedure.
        /// </summary>
        /// <remarks>
        /// <para>
        ///     This method is invoked by the ApplicationManager following the instantiation of all program Managers.
        /// </para>
        /// </remarks>
        /// <exception cref="ManagerSetupException">Thrown when an error is encountered during setup.</exception>
        protected virtual void Setup()
        {
        }

        /// <summary>
        ///     Implements the Manager-specific disposal procedure.
        /// </summary>
        /// <remarks>
        /// <para>
        ///     This method is invoked by the Dispose() method of the base <see cref="Manager"/> class.  Any managed resources within the Manager
        ///     should be disposed within this method.
        /// </para>
        /// </remarks>
        protected virtual void Teardown()
        {
        }

        /// <summary>
        ///     Implements the Manager-specific startup procedure.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        protected virtual Result Startup()
        {
            return new Result();
        }

        /// <summary>
        ///     Implements the Manager-specific shutdown procedure.
        /// </summary>
        /// <param name="stopType">The <see cref="StopType"/> enumeration corresponding to the nature of the stoppage.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        protected virtual Result Shutdown(StopType stopType = StopType.Stop)
        {
            return new Result();
        }

        /// <summary>
        ///     Changes the <see cref="State"/> of the Manager to the specified <see cref="Core.State"/> and fires the StateChanged event.
        /// </summary>
        /// <param name="state">The State to which the <see cref="State"/> property is to be changed.</param>
        protected void ChangeState(State state)
        {
            ChangeState(state, string.Empty, StopType.Stop);
        }

        /// <summary>
        ///     Changes the <see cref="State"/> of the Manager to the specified <see cref="Core.State"/> and fires the StateChanged event.
        /// </summary>
        /// <param name="state">The State to which the <see cref="State"/> property is to be changed.</param>
        /// <param name="stopType">The <see cref="StopType"/> enumeration corresponding to the nature of the stoppage.</param>
        protected void ChangeState(State state, StopType stopType = StopType.Stop)
        {
            ChangeState(state, string.Empty, stopType);
        }

        /// <summary>
        ///     Changes the <see cref="State"/> of the Manager to the specified <see cref="Core.State"/> and fires the StateChanged event.
        /// </summary>
        /// <param name="state">The State to which the <see cref="State"/> property is to be changed.</param>
        /// <param name="message">The optional message describing the nature or reason for the change.</param>
        /// <param name="stopType">The <see cref="StopType"/> enumeration corresponding to the nature of the stoppage.</param>
        protected void ChangeState(State state, string message = "", StopType stopType = StopType.Stop)
        {
            logger.EnterMethod(xLogger.Params(state, message, stopType));

            State previousState = State;

            State = state;

            // if the new State is State.Faulted, ensure StopType is Abnormal
            if (State == State.Faulted && !stopType.HasFlag(StopType.Exception))
            {
                // if the Restart flag was passed in, ensure it remains
                if (stopType.HasFlag(StopType.Restart))
                {
                    stopType = StopType.Exception | StopType.Restart;
                }
                else
                {
                    stopType = StopType.Exception;
                }               
            }

            if (StateChanged != null)
            {
                StateChanged(this, new StateChangedEventArgs(State, previousState, message, stopType));
            }

            logger.ExitMethod();
        }

        /// <summary>
        ///     Retrieves the <see cref="IManager"/> instance matching the specified <see cref="Type"/> from the <see cref="Dependencies"/> dictionary.
        /// </summary>
        /// <typeparam name="T">The Type of Manager to return.</typeparam>
        /// <returns>The resolved instance of the specified Manager Type.</returns>
        /// <exception cref="DependencyNotResolvedException">Thrown if the specified Type is not found in the <see cref="Dependencies"/> dictionary.</exception>
        protected virtual T Dependency<T>()
        {
            if (!Dependencies.ContainsKey(typeof(T)))
            {
                throw new DependencyNotResolvedException("The Dependency '" + typeof(T) + "' for Manager " + ManagerName + " has not been resolved (no matching key in dictionary).");
            }

            return (T)Dependencies[typeof(T)];
        }

        /// <summary>
        ///     Adds the specified <see cref="IManager"/> instance of the specified <see cref="Type"/> to the <see cref="Dependencies"/> dictionary.
        /// </summary>
        /// <typeparam name="T">The Type of Manager to add.</typeparam>
        /// <param name="manager">The resolved instance of the specified Manager Type.</param>
        /// <returns>The added IManager instance.</returns>
        protected virtual T RegisterDependency<T>(IManager manager)
        {
            Dependencies.Add(typeof(T), manager);
            manager.StateChanged += DependencyStateChanged;
            return (T)manager;
        }

        /// <summary>
        ///     Examines the <see cref="State"/> of the <see cref="IManager"/>s contained within the <see cref="Dependencies"/> property 
        ///     to ensure each is in a <see cref="Core.State"/> contained within the supplied list of <see cref="Core.State"/>s.  
        ///     If not, an error message is added to the return <see cref="Result"/>.
        /// </summary>
        /// <param name="states">The list of <see cref="Core.State"/> to which the state of each dependency will be compared.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        protected virtual Result DependenciesAreAllInState(params State[] states)
        {
            logger.EnterMethod();
            Result retVal = new Result();

            foreach (Type managerType in Dependencies.Keys)
            {
                if (!Dependencies[managerType].IsInState(states))
                {
                    retVal.AddError("The dependency '" + managerType.GetType().Name + "' has not been started (current state is " + Dependencies[managerType].State + ").");
                }
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal);
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
            logger.EnterMethod();
            logger.Debug("Checking dependencies for " + ManagerName + " to see whether a restart can be attempted...");

            // check all of the dependencies to see whether they are running
            if (DependenciesAreAllInState(State.Running))
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
                {
                    logger.Debug("Failed to restart " + ManagerName + ": " + startResult.GetLastError());
                }
            }

            logger.ExitMethod();
        }

        /// <summary>
        /// Occurs when the state of a Manager upon which this Manager is dependent changes.
        /// </summary>
        /// <param name="sender">The Manager whose state changed.</param>
        /// <param name="e">The EventArgs for the event.</param>
        private void DependencyStateChanged(object sender, StateChangedEventArgs e)
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

                    // ensure the manager is stopped with the correct flags, regardless of the flags 
                    // specified in the event args.
                    if (e.StopType.HasFlag(StopType.Restart))
                    {
                        Stop(StopType.Exception | StopType.Restart);
                    }
                    else
                    {
                        Stop(StopType.Exception);
                    }
                }
                else if (e.State == State.Stopped)
                {
                    // if the state changed to stopped, stop this manager, unless the StopType is Shutdown, in which case
                    // we don't do anything so as not to disrupt the shutdown order.
                    if (!e.StopType.HasFlag(StopType.Shutdown))
                    {
                        string msg = "The dependency '" + sender.GetType().Name + "' has stopped with StopType of " + e.StopType +
                            (e.StopType.HasFlag(StopType.Restart) ? ", and a restart is pending" : string.Empty) +
                            ".  The " + ManagerName + " must now stop" + (e.StopType.HasFlag(StopType.Restart) ? " and will start when the dependency starts again." : ".");

                        logger.Info(msg);

                        Stop(e.StopType);
                    }
                }
            }

            logger.ExitMethod();
        }

        #endregion

        #endregion

        #endregion

        #endregion
    }
}
