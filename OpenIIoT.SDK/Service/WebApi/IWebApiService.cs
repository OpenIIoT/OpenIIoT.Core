using OpenIIoT.SDK.Service.WebApi;

namespace OpenIIoT.SDK.Service.WebApi
{
    public interface IWebApiService : IService
    {
        #region Public Properties

        WebApiServiceConfiguration Configuration { get; }

        #endregion Public Properties
    }
}