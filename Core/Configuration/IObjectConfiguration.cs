using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.Configuration
{
    public interface IObjectConfiguration
    {
        ConfigurationDefinition Definition { get; }
        string Configuration { get; }
        bool IsDefined { get; }
        bool IsConfigured { get; }
        ObjectConfiguration Define(ConfigurationDefinition definition);
        ObjectConfiguration Configure(string configuration);
    }
}
