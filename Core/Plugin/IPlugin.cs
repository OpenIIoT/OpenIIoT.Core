using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.Plugin
{
    public interface IPlugin
    {
        string Name { get; }
        string FQN { get; }
        Version Version { get; }
        PluginType PluginType { get; }
    }
}
