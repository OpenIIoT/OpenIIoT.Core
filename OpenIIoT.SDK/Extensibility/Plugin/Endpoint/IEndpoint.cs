using OpenIIoT.SDK.Extensibility.Plugin;
using Utility.OperationResult;

namespace OpenIIoT.SDK.Extensibility.Plugin.Endpoint
{
    public interface IEndpoint : IPluginInstance
    {
        Result Send(object value);
    }
}