namespace OpenIIoT.SDK.Plugin.Endpoint
{
    using OpenIIoT.SDK.Common.OperationResult;
    using OpenIIoT.SDK.Common.OperationResult;
    using OpenIIoT.SDK.Plugin;

    public interface IEndpoint : IPluginInstance
    {
        #region Public Methods

        Result Send(object value);

        #endregion Public Methods
    }
}