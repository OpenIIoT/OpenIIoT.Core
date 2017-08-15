using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenIIoT.Core.Security
{
    public class SecurityManagerConfiguration
    {
        #region Public Properties

        public List<Role> Roles { get; set; }
        public List<User> Users { get; set; }

        #endregion Public Properties
    }
}