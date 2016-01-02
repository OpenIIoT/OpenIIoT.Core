using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symbiote.Core.Plugin;
using Symbiote.Core.Model;

namespace Symbiote.Core.Collector
{
    class CollectorManager
    {
        public List<IConnector> Connectors { get; private set; }
    }
}
