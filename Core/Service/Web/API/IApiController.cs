using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.Service.Web.API
{
    public interface IApiController
    {
        JsonMediaTypeFormatter JsonFormatter(List<string> serializationProperties, Symbiote.Core.ContractResolverType contractResolverType, bool includeSecondaryTypes);
    }
}
