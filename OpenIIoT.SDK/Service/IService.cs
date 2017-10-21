namespace OpenIIoT.SDK.Service
{
    using OpenIIoT.SDK.Common.OperationResult;

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