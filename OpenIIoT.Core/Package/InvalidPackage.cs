using OpenIIoT.SDK.Package;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenIIoT.Core.Package
{
    /// <summary>
    ///     Represents an invalid Plugin Package file.
    /// </summary>
    public class InvalidPackage : Package, IInvalidPackage
    {
        /// <summary>
        ///     A string containing the reason the Plugin Package is invalid.
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        ///     Constructs a new InvalidPackage and sets the Message property to the provided string.
        /// </summary>
        /// <param name="fileName">The fully qualified filename of the file.</param>
        /// <param name="message">A string containing the reason the file is invalid.</param>
        public InvalidPackage(string fileName, string message) : base(fileName)
        {
            Message = message;
        }
    }
}