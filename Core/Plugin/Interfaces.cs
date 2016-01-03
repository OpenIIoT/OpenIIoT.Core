using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Symbiote.Core.Plugin
{
    public interface IPlugin {
        string Name { get; }
        string Namespace { get; }
        Version Version { get; }
        PluginType PluginType { get; }
    }

    public interface IPluginAssembly : IPlugin
    {
        Type Type { get; }
        Assembly Assembly { get; }
        void Unload();
    }

    public interface IPluginInstance : IPlugin
    {
        string InstanceName { get; }
    }

    public interface IConnector : IPluginInstance
    {
        bool Browseable { get; }
        List<IConnectorItem> Browse(IConnectorItem root);
        object Read(string item);
        bool Writeable { get; }
        void Write(string item, object value);
    }

    public interface IService : IPluginInstance
    {
        void Start();
    }

    public interface IConnectorItem 
    {
        IConnectorItem Parent { get; }
        string Name { get; }
        string Path { get; }
        string FQN { get; }
        Type Type { get; }
        string SourceAddress { get; }
        List<IConnectorItem> Children { get; }
        bool HasChildren();
        IConnectorItem AddChild(IConnectorItem child);
        IConnectorItem SetParent(IConnectorItem parent);
        IConnectorItem SetItemAsRoot(string instanceName);
    }
}
