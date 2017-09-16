namespace OpenIIoT.Core.Service.WebApi
{
    public static class WebApiConstants
    {
        #region Public Fields

        public const string ApiKeyHeaderName = "X-ApiKey";
        public const string ApiRoutePrefix = "api";
        public const string AssetPath = "assets";
        public const string HelpRoutePrefix = "help";
        public const string LoginRoutePrefix = "login";
        public const string ModulePath = "node_modules";
        public const string NotFoundRoutePrefix = "404";
        public const string SessionTokenCookieName = "Session-Token";
        public const string SignalRRoutePrefix = "signalr";
        public static readonly string[] AnonymousRoutes = { ApiRoutePrefix, SignalRRoutePrefix, HelpRoutePrefix, LoginRoutePrefix, HelpRoutePrefix, NotFoundRoutePrefix, AssetPath, ModulePath };
        public static readonly string[] RedirectSuppressedRoutes = { ApiRoutePrefix, SignalRRoutePrefix };

        #endregion Public Fields
    }
}