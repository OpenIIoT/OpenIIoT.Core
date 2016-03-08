using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.Plugin.Connector
{
    public interface IConnector : IPluginInstance
    {
        Item FindItem(string fqn);
        bool Browseable { get; }
        Item Browse();
        List<Item> Browse(Item root);
        object Read(string fqn);
        bool Writeable { get; }
        OperationResult Write(string fqn, object value);
        event EventHandler<ConnectorEventArgs> Changed;
    }
}
