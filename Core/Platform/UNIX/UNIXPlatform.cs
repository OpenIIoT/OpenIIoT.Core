using System;
using Symbiote.Core.Plugin.Connector;

namespace Symbiote.Core.Platform.UNIX
{
    /// <summary>
    /// The Windows class implements the platform interfaces necessary to run the application on the UNIX platform.
    /// </summary>
    /// <remarks>
    /// Some wierdness in the C# compiler won't allow implicitly defined interface properties if the property is less
    /// accessible than public.  For whatever reason the properties can be public but the class can be internal.
    /// The effective accessibility for these classes and all of their members is internal.
    /// </remarks>
    [System.Runtime.CompilerServices.CompilerGenerated]
    class NamespaceDoc { }

    internal class UNIXPlatform : Platform
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
