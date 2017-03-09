namespace OpenIIoT.SDK.Package
{
    /// <summary>
    ///     Represents an invalid Package file.
    /// </summary>
    public interface IInvalidPackage : IPackage
    {
        /// <summary>
        ///     A string containing the reason the Package is invalid.
        /// </summary>
        string Message { get; }
    }
}