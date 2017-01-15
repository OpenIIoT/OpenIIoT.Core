using OpenIIoT.SDK.Plugin;
using Utility.OperationResult;

namespace OpenIIoT.Core.Plugin.Endpoint
{
    public interface IEndpoint : IPluginInstance
    {
        Result Send(object value);
    }
}