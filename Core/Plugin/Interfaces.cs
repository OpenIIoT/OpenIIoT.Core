using System;
using System.Collections.Generic;
using System.Reflection;

namespace Symbiote.Core.Plugin
{
    public interface IPlugin
    {
        string Name { get; }
        string FQN { get; }
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

    public interface IPluginConfigurationDefinition : IConfigurationDefinition
    {
        string Form { get; }
        string Schema { get; }
    }

    public interface IConnector : IPluginInstance
    {
        Item FindItem(string fqn);
        bool Browseable { get; }
        Item Browse();
        List<Item> Browse(Item root);
        object Read(string fqn);
        bool Writeable { get; }
        bool Write(string fqn, object value);
    }

    public interface IService : IPluginInstance
    {
        void Start();
    }
}
