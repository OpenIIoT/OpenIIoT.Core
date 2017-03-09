using OpenIIoT.SDK.Extensibility.Plugin;

namespace OpenIIoT.SDK.Package
{
    /// <summary>
    ///     Represents a Package file.
    /// </summary>
    public interface IPackage
    {
        /// <summary>
        ///     The fully qualified filename of the file.
        /// </summary>
        string FileName { get; }

        /// <summary>
        ///     The Plugin contained within the archive.
        /// </summary>
        IPlugin Plugin { get; }

        /// <summary>
        ///     Sets the FileName property to the provided value.
        /// </summary>
        /// <param name="fileName">The value with which to set the FileName property.</param>
        void SetFileName(string fileName);

        /// <summary>
        ///     Sets the Plugin property to the provided value.
        /// </summary>
        /// <param name="plugin">The value with which to set the Plugin property.</param>
        void SetPlugin(IPlugin plugin);
    }
}