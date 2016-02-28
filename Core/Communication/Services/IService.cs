using Symbiote.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.Communication.Services
{
    public interface IService
    {
        ObjectConfiguration Configuration { get; }
        OperationResult Start();
    }
}
