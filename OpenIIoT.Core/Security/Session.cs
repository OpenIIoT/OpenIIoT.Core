using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenIIoT.Core.Security
{
    public class Session
    {
        #region Private Properties

        private DateTime Created { get; }
        private DateTime Expires { get; }
        private Guid Token { get; }
        private User User { get; }

        #endregion Private Properties
    }
}