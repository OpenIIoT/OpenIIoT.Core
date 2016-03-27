namespace Symbiote.Core.Plugin
{
    /// <summary>
    /// Enumeration of the different types of Plugin authorizations.
    /// </summary>
    public enum PluginAuthorization
    {
        /// <summary>
        /// The default value.
        /// </summary>
        Unknown,

        /// <summary>
        /// The Plugin is unauthorized.
        /// </summary>
        Unauthorized,

        /// <summary>
        /// The Plugin has been authorized.
        /// </summary>
        Authorized
    }
}
