/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀ 
      █   
      █    ▄█     █▄                                                      ▄███████▄                                                                      
      █   ███     ███                                                    ███    ███                                                                      
      █   ███     ███  █  ██▄▄▄▄  ██████▄   ██████   █     █    ▄█████   ███    ███  █         ▄█████      ██       ▄█████  ██████     █████    ▄▄██▄▄▄  
      █   ███     ███ ██  ██▀▀▀█▄ ██   ▀██ ██    ██ ██     ██   ██  ▀    ███    ███ ██         ██   ██ ▀███████▄   ██   ▀█ ██    ██   ██  ██  ▄█▀▀██▀▀█▄ 
      █   ███     ███ ██▌ ██   ██ ██    ██ ██    ██ ██     ██   ██     ▀█████████▀  ██         ██   ██     ██  ▀  ▄██▄▄    ██    ██  ▄██▄▄█▀  ██  ██  ██ 
      █   ███     ███ ██  ██   ██ ██    ██ ██    ██ ██     ██ ▀███████   ███        ██       ▀████████     ██    ▀▀██▀▀    ██    ██ ▀███████  ██  ██  ██ 
      █   ███ ▄█▄ ███ ██  ██   ██ ██   ▄██ ██    ██ ██ ▄█▄ ██    ▄  ██   ███        ██▌    ▄   ██   ██     ██      ██      ██    ██   ██  ██  ██  ██  ██ 
      █    ▀███▀███▀  █    █   █  ██████▀   ██████   ███▀███   ▄████▀   ▄████▀      ████▄▄██   ██   █▀    ▄██▀     ██       ██████    ██  ██   █  ██  █  
      █   
 ▄ ▄▄ █ ▄▄▄▄▄▄▄▄▄  ▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄ 
 █ ██ █ █████████  ████ ██████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █ 
      █  
      █  The Windows namespace is responsible for providing the necessary Platform and Platform Connector for the application when run
      █  on the Windows platform.
      █  
      █  The WindowsPlatform class extends the Platform class and overloads the necessary methods to run the application on the Windows platform.
      █  
      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██ 
                                                                                                   ██ 
                                                                                               ▀█▄ ██ ▄█▀ 
                                                                                                 ▀████▀   
                                                                                                   ▀▀                            */
using System;
using Symbiote.Core.SDK.Plugin.Connector;
using Symbiote.Core.SDK.Platform;

namespace Symbiote.Core.Platform.Windows
{
    /// <summary>
    ///     The Windows namespace is responsible for providing the necessary Platform and Platform Connector for the application when run
    ///     on the Windows platform.
    /// </summary>
    [System.Runtime.CompilerServices.CompilerGenerated]
    class NamespaceDoc { }

    /// <summary>
    /// The WindowsPlatform class extends the Platform class and overloads the necessary methods to run the application on the Windows platform.
    /// </summary>
    public class WindowsPlatform : Platform
    {
        #region Constructors

        /// <summary>
        /// The default constructor.
        /// </summary>
        public WindowsPlatform()
        {
            PlatformType = PlatformType.Windows;
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
            Connector = new WindowsPlatformConnector(instanceName);
            return Connector;
        }

        #endregion
    }
}
