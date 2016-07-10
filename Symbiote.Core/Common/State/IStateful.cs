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
        /// <returns>A Result containing the result of the operation.</returns>
        Result Stop(StopType stopType = StopType.Normal, bool restartPending = false);

        #endregion
    }
}
