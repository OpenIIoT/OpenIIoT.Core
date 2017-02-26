using OpenIIoT.SDK.Plugin.Archive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenIIoT.Core.Plugin.Archive
{
    /// <summary>
    ///     Represents an invalid Plugin Archive file.
    /// </summary>
    public class InvalidPluginArchive : PluginArchive, IInvalidPluginArchive
    {
        /// <summary>
        ///     A string containing the reason the Plugin Archive is invalid.
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        ///     Constructs a new InvalidPluginArchive and sets the Message property to the provided string.
        /// </summary>
        /// <param name="fileName">The fully qualified filename of the file.</param>
        /// <param name="message">A string containing the reason the file is invalid.</param>
        public InvalidPluginArchive(string fileName, string message) : base(fileName)
        {
            Message = message;
        }
    }
}