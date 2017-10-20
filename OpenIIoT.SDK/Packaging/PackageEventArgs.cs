namespace OpenIIoT.SDK.Packaging
{
    using System;

    public class PackageEventArgs : EventArgs
    {
        #region Public Constructors

        public PackageEventArgs(Package package)
        {
            Package = package;
        }

        #endregion Public Constructors

        #region Public Properties

        public Package Package { get; }

        #endregion Public Properties
    }
}