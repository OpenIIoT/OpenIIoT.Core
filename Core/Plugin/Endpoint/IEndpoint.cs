using Symbiote.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.Plugin.Endpoint
{
    public interface IEndpoint : IPluginInstance
    {
        OperationResult Send(object value);
    }
}
