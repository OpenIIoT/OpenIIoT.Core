/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀ 
      █   
      █    ▄█     ▄███████▄                                                                ▄▄▄▄███▄▄▄▄                                                             
      █   ███    ███    ███                                                              ▄██▀▀▀███▀▀▀██▄                                                           
      █   ███▌   ███    ███    █████  ██████     ▄████▄     █████   ▄█████     ▄▄██▄▄▄   ███   ███   ███   ▄█████  ██▄▄▄▄    ▄█████     ▄████▄     ▄█████    █████ 
      █   ███▌   ███    ███   ██  ██ ██    ██   ██    ▀    ██  ██   ██   ██  ▄█▀▀██▀▀█▄  ███   ███   ███   ██   ██ ██▀▀▀█▄   ██   ██   ██    ▀    ██   █    ██  ██ 
      █   ███▌ ▀█████████▀   ▄██▄▄█▀ ██    ██  ▄██        ▄██▄▄█▀   ██   ██  ██  ██  ██  ███   ███   ███   ██   ██ ██   ██   ██   ██  ▄██        ▄██▄▄     ▄██▄▄█▀ 
      █   ███    ███        ▀███████ ██    ██ ▀▀██ ███▄  ▀███████ ▀████████  ██  ██  ██  ███   ███   ███ ▀████████ ██   ██ ▀████████ ▀▀██ ███▄  ▀▀██▀▀    ▀███████ 
      █   ███    ███          ██  ██ ██    ██   ██    ██   ██  ██   ██   ██  ██  ██  ██  ███   ███   ███   ██   ██ ██   ██   ██   ██   ██    ██   ██   █    ██  ██ 
      █   █▀    ▄████▀        ██  ██  ██████    ██████▀    ██  ██   ██   █▀   █  ██  █    ▀█   ███   █▀    ██   █▀  █   █    ██   █▀   ██████▀    ███████   ██  ██ 
      █   
 ▄ ▄▄ █ ▄▄▄▄▄▄▄▄▄  ▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄ 
 █ ██ █ █████████  ████ ██████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █ 
      █  
      █  Defines the interface for the Program Manager.
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
    /// Defines the interface for the Program Manager.
    /// </summary>
    public interface IProgramManager : IManager
    {
        #region Properties

        /// <summary>
        /// Gets the name of the product, retrieved from AssemblyInfo.cs.
        /// </summary>
        string ProductName { get; }

        /// <summary>
        /// Gets the version of the product, retrieved from AssemblyInfo.cs.
        /// </summary>
        Version ProductVersion { get; }

        /// <summary>
        /// Gets the name of the application instance.
        /// </summary>
        string InstanceName { get; }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Returns the Manager from the list of Managers matching the specified Type.
        /// </summary>
        /// <typeparam name="T">The Type of the Manager to return.</typeparam>
        /// <returns>The requested Manager.</returns>
        T GetManager<T>() where T : IManager;

        /// <summary>
        /// Returns true if the specified Manager Type is registered, false otherwise.
        /// </summary>
        /// <typeparam name="T">The Manager Type to check.</typeparam>
        /// <returns>True if the specified Manager Type is registered, false otherwise.</returns>
        bool IsRegistered<T>() where T : IManager;

        #endregion
    }
}
