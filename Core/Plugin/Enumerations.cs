using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.Plugin
{
    /// <summary>
    /// Enumeration of the different Plugin types.
    /// </summary>
    public enum PluginType
    {
        Unknown,
        Connector,
        Endpoint
    }

    public enum PluginAuthorization
    {
        Unknown,
        Unauthorized,
        Authorized
    }
}
