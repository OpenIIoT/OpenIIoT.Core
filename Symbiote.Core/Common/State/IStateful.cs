/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀ 
      █   
      █    ▄█     ▄████████                                                                    
      █   ███    ███    ███                                                                    
      █   ███▌   ███    █▀      ██      ▄█████      ██       ▄█████    ▄█████ ██   █   █       
      █   ███▌   ███        ▀███████▄   ██   ██ ▀███████▄   ██   █    ██   ▀█ ██   ██ ██       
      █   ███▌ ▀███████████     ██  ▀   ██   ██     ██  ▀  ▄██▄▄     ▄██▄▄    ██   ██ ██       
      █   ███           ███     ██    ▀████████     ██    ▀▀██▀▀    ▀▀██▀▀    ██   ██ ██       
      █   ███     ▄█    ███     ██      ██   ██     ██      ██   █    ██      ██   ██ ██▌    ▄ 
      █   █▀    ▄████████▀     ▄██▀     ██   █▀    ▄██▀     ███████   ██      ██████  ████▄▄██ 
      █   
 ▄ ▄▄ █ ▄▄▄▄▄▄▄▄▄  ▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄ 
 █ ██ █ █████████  ████ ██████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █ 
      █  
      █  Defines the interface for Stateful components.
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
    /// Defines the interface for Stateful components.
    /// </summary>
    public interface IStateful
    {
        #region Properties

        /// <summary>
        /// The current State of the stateful object.
        /// </summary>
        State State { get; }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when the State property changes.
        /// </summary>
        event EventHandler<StateChangedEventArgs> StateChanged;

        #endregion

        #region Instance Methods

        /// <summary>
        /// Returns true if any of the specified <see cref="State"/>s match the current <see cref="State"/>.
        /// </summary>
        /// <param name="states">The list of States to check.</param>
        /// <returns>True if the current State matches any of the specified States, false otherwise.</returns>
        bool IsInState(params State[] states);

        /// <summary>
        /// Starts the stateful object.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        Result Start();

        /// <summary>
        /// Restarts the stateful object.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        Result Restart(StopType stopType = StopType.Normal);

        /// <summary>
        /// Stops the stateful object.
        /// </summary>
        /// <param name="stopType">The nature of the stoppage.</param>
        /// <param name="restartPending">True if the program intends to later restart the stopped component.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        Result Stop(StopType stopType = StopType.Normal, bool restartPending = false);

        #endregion
    }
}
