using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.Communication.Endpoints
{
    class EndpointManagerConfiguration
    {
        public List<EndpointInstance> EndpointInstances { get; set; }

        public EndpointManagerConfiguration()
        {
            EndpointInstances = new List<EndpointInstance>();
        }
    }

    public class EndpointInstance
    {
        public string Name { get; set; }
        public Type EndpointType { get; set; }
        public object Configuration { get; set; }
    }
}
