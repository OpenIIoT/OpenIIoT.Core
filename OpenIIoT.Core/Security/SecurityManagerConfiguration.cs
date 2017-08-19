using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenIIoT.Core.Security
{
    public class SecurityManagerConfiguration
    {
        #region Public Constructors

        public SecurityManagerConfiguration()
        {
            Users = new List<User>();
        }

        #endregion Public Constructors

        #region Public Properties

        public IList<User> Users { get; set; }

        #endregion Public Properties
    }
}