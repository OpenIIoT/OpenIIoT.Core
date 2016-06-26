using Symbiote.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperationResult;

namespace Symbiote.Core.Plugin
{
    public interface IEndpoint : IPluginInstance
    {
        Result Send(object value);
    }
}
