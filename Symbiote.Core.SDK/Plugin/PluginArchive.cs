namespace Symbiote.Core.SDK.Plugin
{
    /// <summary>
    /// Represents a Plugin Archive file.
    /// </summary>
    public class PluginArchive
    {
        /// <summary>
        /// The fully qualified filename of the file.
        /// </summary>
        public string FileName { get; private set; }

        /// <summary>
        /// The Plugin contained within the archive.
        /// </summary>
        public IPlugin Plugin { get; private set; }

        /// <summary>
        /// The default constructor.
        /// </summary>
        /// <param name="fileName">The fully qualified filename of the file.</param>
        /// <param name="checksum">The checksum of the file.</param>
        /// <param name="plugin">The Plugin contained within the archive.</param>
        public PluginArchive(string fileName = "", string checksum = "", IPlugin plugin = null)
        {
            FileName = fileName;
            Plugin = plugin;
        }

        /// <summary>
        /// Sets the FileName property to the provided value.
        /// </summary>
        /// <param name="fileName">The value with which to set the FileName property.</param>
        public void SetFileName(string fileName)
        {
            FileName = fileName;
        }

        /// <summary>
        /// Sets the Plugin property to the provided value.
        /// </summary>
        /// <param name="plugin">The value with which to set the Plugin property.</param>
        public void SetPlugin(IPlugin plugin)
        {
            Plugin = plugin;
        }
    }

    /// <summary>
    /// Represents an invalid Plugin Archive file.
    /// </summary>
    public class InvalidPluginArchive : PluginArchive
    {
        /// <summary>
        /// A string containing the reason the Plugin Archive is invalid.
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Constructs a new InvalidPluginArchive and sets the Message property to the provided string.
        /// </summary>
        /// <param name="fileName">The fully qualified filename of the file.</param>
        /// <param name="message">A string containing the reason the file is invalid.</param>
        public InvalidPluginArchive(string fileName, string message) : base(fileName)
        {
            Message = message;
        }
    }
}
