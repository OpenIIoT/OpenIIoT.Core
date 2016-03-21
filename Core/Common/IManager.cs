namespace Symbiote.Core
{
    public interface IManager
    {
        bool Running { get; }
        OperationResult Start();
        OperationResult Restart();
        OperationResult Stop();
    }
}
