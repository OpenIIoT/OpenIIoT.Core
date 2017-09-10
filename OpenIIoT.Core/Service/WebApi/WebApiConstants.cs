namespace OpenIIoT.Core.Service.WebApi
{
    public static class WebApiConstants
    {
        #region Public Fields

        public const string ApiKeyHeaderName = "X-ApiKey";
        public const string ApiRoutePrefix = "api";
        public const string HelpRoutePrefix = "help";
        public const string LoginRoutePrefix = "login";
        public const string SessionTokenCookieName = "Session-Token";
        public const string SignalRRoutePrefix = "signalr";
        public static readonly string[] AnonymousRoutes = { ApiRoutePrefix, HelpRoutePrefix, LoginRoutePrefix, HelpRoutePrefix, "assets", "node_modules" };

        #endregion Public Fields
    }
}