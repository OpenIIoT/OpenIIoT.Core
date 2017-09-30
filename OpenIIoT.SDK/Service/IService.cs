using Utility.OperationResult;

namespace OpenIIoT.SDK.Service
{
    public interface IService
    {
        #region Public Properties

        bool IsRunning { get; }

        #endregion Public Properties

        #region Public Methods

        Result Start();

        Result Stop();

        #endregion Public Methods
    }
}