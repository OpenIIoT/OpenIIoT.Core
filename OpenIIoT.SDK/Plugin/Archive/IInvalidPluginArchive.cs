namespace OpenIIoT.SDK.Plugin.Archive
{
    /// <summary>
    ///     Represents an invalid Plugin Archive file.
    /// </summary>
    public interface IInvalidPluginArchive : IPluginArchive
    {
        /// <summary>
        ///     A string containing the reason the Plugin Archive is invalid.
        /// </summary>
        string Message { get; }
    }
}