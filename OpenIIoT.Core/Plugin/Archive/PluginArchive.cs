using OpenIIoT.SDK.Plugin;
using OpenIIoT.SDK.Plugin.Archive;

namespace OpenIIoT.Core.Plugin.Archive
{
    /// <summary>
    ///     Represents a Plugin Archive file.
    /// </summary>
    public class PluginArchive : IPluginArchive
    {
        /// <summary>
        ///     The fully qualified filename of the file.
        /// </summary>
        public string FileName { get; private set; }

        /// <summary>
        ///     The Plugin contained within the archive.
        /// </summary>
        public IPlugin Plugin { get; private set; }

        /// <summary>
        ///     The default constructor.
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
    }
}