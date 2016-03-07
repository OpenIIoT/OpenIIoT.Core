using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.Plugin
{
    public interface IPluginAssembly : IPlugin
    {
        Type Type { get; }
        Assembly Assembly { get; }
        void Unload();
    }
}
