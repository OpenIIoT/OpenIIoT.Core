namespace Symbiote.Core.Plugin
{
    public interface IEndpoint : IPluginInstance
    {
        Result Send(object value);
    }
}
