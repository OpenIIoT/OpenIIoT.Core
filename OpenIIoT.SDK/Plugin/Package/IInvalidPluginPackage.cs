namespace OpenIIoT.SDK.Plugin.Package
{
    /// <summary>
    ///     Represents an invalid Plugin Package file.
    /// </summary>
    public interface IInvalidPluginPackage : IPluginPackage
    {
        /// <summary>
        ///     A string containing the reason the Plugin Package is invalid.
        /// </summary>
        string Message { get; }
    }
}