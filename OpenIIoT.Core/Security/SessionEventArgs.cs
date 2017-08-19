using System;

namespace OpenIIoT.Core.Security
{
    public class SessionEventArgs : EventArgs
    {
        #region Public Constructors

        public SessionEventArgs(Session session)
        {
            Session = Session;
        }

        #endregion Public Constructors

        #region Public Properties

        public Session Session { get; }

        #endregion Public Properties
    }
}