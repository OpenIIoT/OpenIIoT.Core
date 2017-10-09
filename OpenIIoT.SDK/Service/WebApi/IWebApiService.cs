namespace OpenIIoT.SDK.Service.WebApi
{
    using OpenIIoT.SDK.Configuration;
    using OpenIIoT.SDK.Service;

    public interface IWebApiService : IService
    {
        #region Public Properties

        IRoutes Routes { get; }

        #endregion Public Properties
    }
}