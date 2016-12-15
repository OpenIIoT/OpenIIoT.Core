/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀ 
      █   
      █   ███    █▄  ███▄▄▄▄    ▄█  ▀████    ▐████▀    ▄███████▄                                                                      
      █   ███    ███ ███▀▀▀██▄ ███    ███▌   ████▀    ███    ███                                                                      
      █   ███    ███ ███   ███ ███▌    ███  ▐███      ███    ███  █         ▄█████      ██       ▄█████  ██████     █████    ▄▄██▄▄▄  
      █   ███    ███ ███   ███ ███▌    ▀███▄███▀      ███    ███ ██         ██   ██ ▀███████▄   ██   ▀█ ██    ██   ██  ██  ▄█▀▀██▀▀█▄ 
      █   ███    ███ ███   ███ ███▌    ████▀██▄     ▀█████████▀  ██         ██   ██     ██  ▀  ▄██▄▄    ██    ██  ▄██▄▄█▀  ██  ██  ██ 
      █   ███    ███ ███   ███ ███     ▐███  ▀███     ███        ██       ▀████████     ██    ▀▀██▀▀    ██    ██ ▀███████  ██  ██  ██ 
      █   ███    ███ ███   ███ ███   ▄███     ███▄    ███        ██▌    ▄   ██   ██     ██      ██      ██    ██   ██  ██  ██  ██  ██ 
      █   ████████▀   ▀█   █▀  █▀   ████       ███▄  ▄████▀      ████▄▄██   ██   █▀    ▄██▀     ██       ██████    ██  ██   █  ██  █  
      █   
 ▄ ▄▄ █ ▄▄▄▄▄▄▄▄▄  ▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄ 
 █ ██ █ █████████  ████ ██████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █ 
      █  
      █  The UNIX namespace is responsible for providing the necessary Platform and Platform Connector for the application when run
      █  on the UNIX platform.
      █
      █  The UNIXPlatform class extends the Platform class and overloads the necessary methods to run the application on the UNIX platform.
      █  
      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██ 
                                                                                                   ██ 
                                                                                               ▀█▄ ██ ▄█▀ 
                                                                                                 ▀████▀   
                                                                                                   ▀▀                            */
using System;
using Symbiote.SDK.Plugin.Connector;
using Symbiote.SDK.Platform;

namespace Symbiote.Core.Platform.UNIX
{
    /// <summary>
    ///     The UNIX namespace is responsible for providing the necessary Platform and Platform Connector for the application when run
    ///     on the UNIX platform.
    /// </summary>
    [System.Runtime.CompilerServices.CompilerGenerated]
    class NamespaceDoc { }

    /// <summary>
    /// The UNIXPlatform class extends the Platform class and overloads the necessary methods to run the application on the UNIX platform.
    /// </summary>
    public class UNIXPlatform : Platform
    {
        #region Constructors

        /// <summary>
        /// The default constructor.
        /// </summary>
        public UNIXPlatform()
        {
            PlatformType = PlatformType.UNIX;
            Version = Environment.OSVersion.VersionString;
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Instantiates the accompanying Connector Plugin with the supplied root path.
        /// </summary>
        /// <param name="instanceName"></param>
        /// <returns>The instantiated Connector Plugin.</returns>
        public override IConnector InstantiateConnector(string instanceName)
        {
            Connector = new UNIXPlatformConnector(instanceName);
            return Connector;
        }

        #endregion
    }
}
