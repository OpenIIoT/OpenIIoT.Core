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
        /// The default constructor.
        /// </summary>
        /// <param name="state">The State to which the state changed.</param>
        /// <param name="previousState">The State from which the state changed.</param>
        /// <param name="message">The optional message associated with the event.</param>
        public StateChangedEventArgs(State state, State previousState, string message = "")
        {
            State = state;
            PreviousState = previousState;
            Message = message;
        }
    }
}
