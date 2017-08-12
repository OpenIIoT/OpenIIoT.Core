namespace OpenIIoT.SDK.Plugin
{
    /// <summary>
    ///     Defines the interface for Plugin objects.
    /// </summary>
    public interface IPlugin
    {
        #region Properties

        /// <summary>
        ///     Gets the cryptographic fingerprint of the Plugin.
        /// </summary>
        /// <remarks>
        ///     The SHA256 checksum of the Plugin assembly hashed again using the SHA256 algorithm and salted with the FQN + Version.
        /// </remarks>
        string Fingerprint { get; }

        /// <summary>
        ///     Gets the Fully Qualified Name of the Plugin. The FQN shall use the following pattern: OpenIIoT.Plugin.[Connector|Endpoint].Name
        ///
        ///     The final tuple, Name, shall match the Name property.
        /// </summary>
        string FQN { get; }

        /// <summary>
        ///     Gets the name of the Plugin. Typically a single word but may be a phrase. Equal to the last tuple of the FQN.
        /// </summary>
        string Name { get; }

        /// <summary>
        ///     Gets the enumerated type of the Plugin. This shall match the thrid tuple of the FQN.
        /// </summary>
        PluginType PluginType { get; }

        /// <summary>
        ///     Gets the version of the Plugin. This is a free-text field allowing any format the Plugin author desires.
        /// </summary>
        string Version { get; }

        #endregion Properties

        #region Instance Methods

        /// <summary>
        ///     Sets the Fingerprint property to the supplied value.
        /// </summary>
        /// <param name="fingerprint">The value to which the property should be set.</param>
        void SetFingerprint(string fingerprint);

        #endregion Instance Methods
    }
}