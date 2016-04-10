using System;

namespace Symbiote.Core.Plugin
{
    public interface IPlugin
    {
        string Name { get; }
        string FQN { get; }
        string Version { get; }
        PluginType PluginType { get; }
    }
}
