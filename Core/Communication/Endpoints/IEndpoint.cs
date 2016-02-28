using Symbiote.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.Communication.Endpoints
{
    public interface IEndpoint
    {
        ObjectConfiguration Configuration { get; }
        OperationResult Send(string route, object payload);
    }
}
