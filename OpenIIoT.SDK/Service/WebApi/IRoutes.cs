using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenIIoT.SDK.Service.WebApi
{
    public interface IRoutes
    {
        #region Public Properties

        string Api { get; }
        string Help { get; }
        string HelpRoot { get; }
        string Root { get; }

        string SignalR { get; }

        string Swagger { get; }

        string SwaggerUi { get; }

        #endregion Public Properties
    }
}