using OpenIIoT.SDK.Service.WebAPI;

namespace OpenIIoT.SDK.Service.WebApi
{
    public interface IWebApiService : IService
    {
        #region Public Properties

        WebAPIServiceConfiguration Configuration { get; }

        #endregion Public Properties
    }
}