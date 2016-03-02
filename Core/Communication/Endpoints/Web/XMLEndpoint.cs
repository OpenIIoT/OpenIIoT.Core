using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symbiote.Core.Configuration;

namespace Symbiote.Core.Communication.Endpoints.Web
{
    class XMLEndpoint : IEndpoint, IConfigurable
    {
        public ObjectConfiguration Configuration { get; private set; }

        public XMLEndpoint(string instanceName)
        {

        }

        public OperationResult Send(string route, object payload)
        {
            throw new NotImplementedException();
        }
    }
}
