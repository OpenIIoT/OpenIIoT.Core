using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Symbiote.Core.Plugin
{
    public interface IPlugin
    {
        string Name { get; }
        string FullName { get; }
        PluginManager.PluginType PluginType { get; }
        Type Type { get; }
        Assembly Assembly { get; }
    }
    public interface IConnector
    {
        string Name { get; }
        string Namespace { get; }
        double Version { get; }
        List<IConnectorItem> Browse(IConnectorItem root);
    }

    public interface IConnectorItem
    {
        IConnectorItem Parent { get; }
        string Name { get; }
        string Address { get; }
    }
}
