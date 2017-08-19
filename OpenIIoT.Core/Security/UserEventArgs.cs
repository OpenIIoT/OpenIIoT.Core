using System;

namespace OpenIIoT.Core.Security
{
    public class UserEventArgs : EventArgs
    {
        #region Public Constructors

        public UserEventArgs(User user)
        {
            User = user;
        }

        #endregion Public Constructors

        #region Public Properties

        public User User { get; }

        #endregion Public Properties
    }
}