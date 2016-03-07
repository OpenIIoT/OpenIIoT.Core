using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.Configuration
{
    public interface IConfigurable<T>
    {
        ConfigurationDefinition ConfigurationDefinition { get; }
        T Configuration { get; }
        OperationResult Configure();
        OperationResult Configure(T configuration);
        OperationResult SaveConfiguration();
    }
}
