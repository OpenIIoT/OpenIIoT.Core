/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀ 
      █   
      █      ▄████████                                         ▄████████                                                              
      █     ███    ███                                         ███    ███                                                             
      █     ███    █▀      ██      ▄█████      ██       ▄█████ ███    █▀    ██   █      ▄█████  ██▄▄▄▄     ▄████▄     ▄█████ ██████▄  
      █     ███        ▀███████▄   ██   ██ ▀███████▄   ██   █  ███          ██   ██     ██   ██ ██▀▀▀█▄   ██    ▀    ██   █  ██   ▀██ 
      █   ▀███████████     ██  ▀   ██   ██     ██  ▀  ▄██▄▄    ███         ▄██▄▄▄██▄▄   ██   ██ ██   ██  ▄██        ▄██▄▄    ██    ██ 
      █            ███     ██    ▀████████     ██    ▀▀██▀▀    ███    █▄  ▀▀██▀▀▀██▀  ▀████████ ██   ██ ▀▀██ ███▄  ▀▀██▀▀    ██    ██ 
      █      ▄█    ███     ██      ██   ██     ██      ██   █  ███    ███   ██   ██     ██   ██ ██   ██   ██    ██   ██   █  ██   ▄██ 
      █    ▄████████▀     ▄██▀     ██   █▀    ▄██▀     ███████ ████████▀    ██   ██     ██   █▀  █   █    ██████▀    ███████ ██████▀  
      █   
      █      ▄████████                                        ▄████████                               
      █     ███    ███                                        ███    ███                              
      █     ███    █▀   █    █     ▄█████ ██▄▄▄▄      ██      ███    ███    █████    ▄████▄    ▄█████ 
      █    ▄███▄▄▄     ██    ██   ██   █  ██▀▀▀█▄ ▀███████▄   ███    ███   ██  ██   ██    ▀    ██  ▀  
      █   ▀▀███▀▀▀     ██    ██  ▄██▄▄    ██   ██     ██  ▀ ▀███████████  ▄██▄▄█▀  ▄██         ██     
      █     ███    █▄  ██    ██ ▀▀██▀▀    ██   ██     ██      ███    ███ ▀███████ ▀▀██ ███▄  ▀███████ 
      █     ███    ███  █▄  ▄█    ██   █  ██   ██     ██      ███    ███   ██  ██   ██    ██    ▄  ██ 
      █     ██████████   ▀██▀     ███████  █   █     ▄██▀     ███    █▀    ██  ██   ██████▀   ▄████▀  
      █   
 ▄ ▄▄ █ ▄▄▄▄▄▄▄▄▄  ▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄ 
 █ ██ █ █████████  ████ ██████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █ 
      █  
      █  EventArgs for the StateChanged event.
      █  
      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██ 
                                                                                                   ██ 
                                                                                               ▀█▄ ██ ▄█▀ 
                                                                                                 ▀████▀   
                                                                                                   ▀▀                            */
using System;

namespace Symbiote.Core
{
    /// <summary>
    /// EventArgs for the StateChanged event.
    /// </summary>
    public class StateChangedEventArgs : EventArgs
    {
        /// <summary>
        /// The State to which the state changed.
        /// </summary>
        public State State { get; private set; }

        /// <summary>
        /// The State from which the state changed.
        /// </summary>
        public State PreviousState { get; private set; }

        /// <summary>
        /// The optional message associated with the event.
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// The StopType associated with a change to the Stopped or Faulted states.
        /// </summary>
        public StopType StopType { get; private set; }

        public bool RestartPending { get; private set; }

        /// <summary>
        /// Constructs a new instance with the specified state, previousState and message parameters.
        /// </summary>
        /// <param name="state">The State to which the state changed.</param>
        /// <param name="previousState">The State from which the state changed.</param>
        /// <param name="message">The optional message associated with the event.</param>
        public StateChangedEventArgs(State state, State previousState, string message = "") : this(state, previousState, message, (state == State.Faulted ? StopType.Abnormal : StopType.Normal), false) { }

        /// <summary>
        /// Constructs a new instance with the specified state, previousState and stopType parameters.
        /// </summary>
        /// <param name="state">The State to which the state changed.</param>
        /// <param name="previousState">The State from which the state changed.</param>
        /// <param name="stopType">The StopType associated with a change to the Stopped or Faulted states.</param>
        /// <param name="restartPending">An optional bool indicating that a restart of a stopped component is pending.</param>
        public StateChangedEventArgs(State state, State previousState, StopType stopType = StopType.Normal, bool restartPending = false) : this(state, previousState, "", stopType, false) { }

        /// <summary>
        /// Constructs a new instance with the specified state, previousState and restartPending parameters.
        /// </summary>
        /// <param name="state">The State to which the state changed.</param>
        /// <param name="previousState">The State from which the state changed.</param>
        /// <param name="restartPending">An optional bool indicating that a restart of a stopped component is pending.</param>
        public StateChangedEventArgs(State state, State previousState, bool restartPending) : this(state, previousState, "", (state == State.Faulted ? StopType.Abnormal : StopType.Normal), restartPending) { }

        /// <summary>
        /// Constructs a new instance with the specified state, previousState, stopType and message parameters.
        /// </summary>
        /// <param name="state">The State to which the state changed.</param>
        /// <param name="previousState">The State from which the state changed.</param>
        /// <param name="stopType">The StopType associated with a change to the Stopped or Faulted states.</param>
        /// <param name="message">The optional message associated with the event.</param>
        /// <param name="restartPending">An optional bool indicating that a restart of a stopped component is pending.</param>
        public StateChangedEventArgs(State state, State previousState, string message = "", StopType stopType = StopType.Normal, bool restartPending = false)
        {
            State = state;
            PreviousState = previousState;
            Message = message;
            RestartPending = restartPending;
        }
    }
}
