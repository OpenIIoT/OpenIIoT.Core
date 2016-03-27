using System;
using System.Reflection;

namespace Symbiote.Core.Plugin
{
    public interface IPluginAssembly : IPlugin
    {
        Type Type { get; }
        Assembly Assembly { get; }
        void Unload();
    }
}
