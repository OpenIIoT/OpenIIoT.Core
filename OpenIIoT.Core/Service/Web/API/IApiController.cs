using OpenIIoT.SDK;
using OpenIIoT.SDK.Common;
using System.Collections.Generic;
using System.Net.Http.Formatting;

namespace OpenIIoT.Core.Service.Web.API
{
    public interface IApiController
    {
        JsonMediaTypeFormatter JsonFormatter(List<string> serializationProperties, ContractResolverType contractResolverType);
    }
}