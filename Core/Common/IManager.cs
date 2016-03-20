namespace Symbiote.Core
{
    public interface IManager
    {
        bool IsRunning { get; }
        OperationResult Start();
        OperationResult Restart();
        OperationResult Stop();
    }
}
