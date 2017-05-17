using OpenIIoT.SDK.Package;
using OpenIIoT.SDK.Plugin;

namespace OpenIIoT.Core.Package
{
    /// <summary>
    ///     Represents a Plugin Package file.
    /// </summary>
    public class Package : IPackage
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Package"/> class.
        /// </summary>
        /// <param name="fileName">The fully qualified filename of the file.</param>
        /// <param name="checksum">The checksum of the file.</param>
        /// <param name="plugin">The Plugin contained within the archive.</param>
        public Package(string fileName = "", string checksum = "", IPlugin plugin = null)
        {
            FileName = fileName;
            Plugin = plugin;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        ///     Gets the fully qualified filename of the file.
        /// </summary>
        public string FileName { get; private set; }

        /// <summary>
        ///     Gets the Plugin contained within the archive.
        /// </summary>
        public IPlugin Plugin { get; private set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///     Sets the FileName property to the provided value.
        /// </summary>
        /// <param name="fileName">The value with which to set the FileName property.</param>
        public void SetFileName(string fileName)
        {
            FileName = fileName;
        }

        /// <summary>
        ///     Sets the Plugin property to the provided value.
        /// </summary>
        /// <param name="plugin">The value with which to set the Plugin property.</param>
        public void SetPlugin(IPlugin plugin)
        {
            Plugin = plugin;
        }

        #endregion Public Methods
    }
}