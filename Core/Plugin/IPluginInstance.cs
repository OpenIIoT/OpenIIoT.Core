using Symbiote.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.Plugin
{
    public interface IPluginInstance : IPlugin
    {
        string InstanceName { get; }
        OperationResult Start();
        OperationResult Stop();
    }
}
