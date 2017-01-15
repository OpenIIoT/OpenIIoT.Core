using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenIIoT.SDK.Plugin.Connector
{
    /// <summary>
    ///     Enumeration of the different <see cref="Connector"/> types.
    /// </summary>
    public enum ConnectorType
    {
        /// <summary>
        ///     The default value.
        /// </summary>
        Unknown,

        /// <summary>
        ///     Indicates that the Connector is to be hidden from Connector discovery.
        /// </summary>
        Hidden,

        /// <summary>
        ///     Indicates that the Connector originates from a Plugin.
        /// </summary>
        Plugin,

        /// <summary>
        ///     Indicates that the Connector provides system Items.
        /// </summary>
        System
    }
}