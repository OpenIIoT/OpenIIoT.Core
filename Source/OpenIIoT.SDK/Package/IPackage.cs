using OpenIIoT.SDK.Packaging.Manifest;

namespace OpenIIoT.SDK.Package
{
    /// <summary>
    ///     Represents a Package file.
    /// </summary>
    public interface IPackage
    {
        #region Public Properties

        /// <summary>
        ///     Gets the fully qualified filename of the file.
        /// </summary>
        string FileName { get; }

        /// <summary>
        ///     Gets the Fully Qualified Name of the package.
        /// </summary>
        string FQN { get; }

        /// <summary>
        ///     Gets a value indicating whether the Package is installed.
        /// </summary>
        bool Installed { get; }

        /// <summary>
        ///     Gets the Manifest for the package.
        /// </summary>
        PackageManifest Manifest { get; }

        #endregion Public Properties
    }
}