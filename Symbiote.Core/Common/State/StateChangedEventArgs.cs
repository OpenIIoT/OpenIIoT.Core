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

        /// <summary>
        /// Constructs a new instance with the specified state, previousState and message parameters.
        /// </summary>
        /// <param name="state">The State to which the state changed.</param>
        /// <param name="previousState">The State from which the state changed.</param>
        /// <param name="message">The optional message associated with the event.</param>
        public StateChangedEventArgs(State state, State previousState, string message = "") : this(state, previousState, (state == State.Faulted ? StopType.Abnormal : StopType.Normal), message) { }
        
        /// <summary>
        /// Constructs a new instance with the specified state, previousState, stopType and message parameters.
        /// </summary>
        /// <param name="state">The State to which the state changed.</param>
        /// <param name="previousState">The State from which the state changed.</param>
        /// <param name="stopType">The StopType associated with a change to the Stopped or Faulted states.</param>
        /// <param name="message">The optional message associated with the event.</param>
        public StateChangedEventArgs(State state, State previousState, StopType stopType = StopType.Normal, string message = "")
        {
            State = state;
            PreviousState = previousState;
            Message = message;
        }
    }
}
