using System;
using Symbiote.Core.Plugin.Connector;

namespace Symbiote.Core.Platform.Windows
{
    /// <summary>
    /// The Windows class implements the platform interfaces necessary to run the application on the Windows platform.
    /// </summary>
    /// <remarks>
    /// Some wierdness in the C# compiler won't allow implicitly defined interface properties if the property is less
    /// accessible than public.  For whatever reason the properties can be public but the class can be internal.
    /// The effective accessibility for these classes and all of their members is internal.
    /// </remarks>
    [System.Runtime.CompilerServices.CompilerGenerated]
    class NamespaceDoc { }

    internal class WindowsPlatform : Platform
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
