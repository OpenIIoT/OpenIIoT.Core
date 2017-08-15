using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenIIoT.Core.Security
{
    public class User
    {
        #region Private Properties

        private string Name { get; set; }
        private string PasswordHash { get; set; }
        private IReadOnlyList<Role> Roles { get; }

        #endregion Private Properties
    }
}