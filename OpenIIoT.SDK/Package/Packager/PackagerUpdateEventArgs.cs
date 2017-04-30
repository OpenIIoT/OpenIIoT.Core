using System;

namespace OpenIIoT.SDK.Package.Packager
{
    public class PackagerUpdateEventArgs : EventArgs
    {
        #region Public Constructors

        public PackagerUpdateEventArgs(PackagerTool operation, string message) : base()
        {
            Operation = operation;
            Message = message;
        }

        #endregion Public Constructors

        #region Public Properties

        public string Message { get; private set; }
        public PackagerTool Operation { get; private set; }

        #endregion Public Properties
    }
}