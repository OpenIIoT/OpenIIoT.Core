using System.Collections.Generic;
using System.Net.Http.Formatting;

namespace Symbiote.Core.Service.Web.API
{
    public interface IApiController
    {
        JsonMediaTypeFormatter JsonFormatter(List<string> serializationProperties, ContractResolver.ContractResolverType contractResolverType, bool includeSecondaryTypes);
    }
}
