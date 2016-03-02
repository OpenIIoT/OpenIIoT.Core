using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.Configuration
{
    public interface IConfigurable
    {
        ObjectConfiguration Configuration { get; }
    }
}
