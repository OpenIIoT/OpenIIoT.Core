using Symbiote.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.OperationResult;

namespace Symbiote.Core.Service
{
    public interface IService
    {
        bool IsRunning { get; }
        Result Start();
        Result Stop();
    }
}
