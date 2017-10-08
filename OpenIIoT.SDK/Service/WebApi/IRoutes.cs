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