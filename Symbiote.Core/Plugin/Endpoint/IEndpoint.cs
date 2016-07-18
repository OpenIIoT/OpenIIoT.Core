namespace Symbiote.Core.Plugin.Endpoint
{
    public interface IEndpoint : IPluginInstance
    {
        Result Send(object value);
    }
}
