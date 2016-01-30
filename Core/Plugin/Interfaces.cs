using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Symbiote.Core.Composite;

namespace Symbiote.Core.Plugin
{
    public interface IPlugin
    {
        string Name { get; }
        string FullName { get; }
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
        IPluginConfigurationDefinition ConfigurationDefinition { get; }
        string Configuration { get; }
        bool Configured { get; }
        void Configure(string configuration);
    }

    public interface IPluginConfigurationDefinition
    {
        string Form { get; }
        string Schema { get; }
    }

    public interface IConnector : IPluginInstance
    {
        bool Browseable { get; }
        IComposite Browse();
        List<IComposite> Browse(IComposite root);
        object Read(string fqn);
        bool Writeable { get; }
        void Write(string fqn, object value);
    }

    public interface IService : IPluginInstance
    {
        void Start();
    }

    //public interface IConnectorItem 
    //{
    //    IConnectorItem Parent { get; }
    //    string Name { get; }
    //    string Path { get; }
    //    string FQN { get; }
    //    Type Type { get; }
    //    string SourceAddress { get; }
    //    List<IConnectorItem> Children { get; }
    //    bool HasChildren();
    //    IConnectorItem AddChild(IConnectorItem child);
    //    IConnectorItem SetParent(IConnectorItem parent);
    //}
}
