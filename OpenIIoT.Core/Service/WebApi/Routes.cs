using OpenIIoT.SDK.Service.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenIIoT.Core.Service.WebApi
{
    public class Routes : IRoutes
    {
        #region Public Constructors

        public Routes(WebApiServiceConfiguration configuration)
        {
            Root = configuration.Root.TrimStart('/').TrimEnd('/');

            Api = $"{Root}/{WebApiConstants.ApiRoutePrefix}".TrimStart('/');
            SignalR = $"/{Root}/{WebApiConstants.SignalRRoutePrefix}".Replace("//", "/");
            HelpRoot = $"{Root}/{WebApiConstants.HelpRoutePrefix}".TrimStart('/');
            Swagger = $"{HelpRoot}/docs/{{apiVersion}}";
            SwaggerUi = $"{HelpRoot}/ui/{{*assetPath}}";
            Help = $"{HelpRoot}/ui/index";
        }

        #endregion Public Constructors

        #region Private Properties

        public string HelpRoot { get; set; }

        #endregion Private Properties

        #region Public Properties

        public string Api { get; private set; }

        public string Help { get; private set; }

        public string Root { get; private set; }

        public string SignalR { get; private set; }

        public string Swagger { get; private set; }

        public string SwaggerUi { get; private set; }

        #endregion Public Properties
    }
}