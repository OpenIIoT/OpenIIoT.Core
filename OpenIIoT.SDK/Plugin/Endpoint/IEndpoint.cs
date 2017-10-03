using OpenIIoT.SDK.Common.OperationResult;
using OpenIIoT.SDK.Plugin;

using OpenIIoT.SDK.Common.OperationResult;

namespace OpenIIoT.SDK.Plugin.Endpoint
{
    public interface IEndpoint : IPluginInstance
    {
        #region Public Methods

        Result Send(object value);

        #endregion Public Methods
    }
}