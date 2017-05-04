using OpenIIoT.SDK.Package;

namespace OpenIIoT.Core.Package
{
    /// <summary>
    ///     Represents an invalid Plugin Package file.
    /// </summary>
    public class InvalidPackage : Package, IInvalidPackage
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="InvalidPackage"/> class with the specified message string.
        /// </summary>
        /// <param name="fileName">The fully qualified filename of the file.</param>
        /// <param name="message">A string containing the reason the file is invalid.</param>
        public InvalidPackage(string fileName, string message)
            : base(fileName)
        {
            Message = message;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        ///     Gets a string containing the reason the Plugin Package is invalid.
        /// </summary>
        public string Message { get; private set; }

        #endregion Public Properties
    }
}