using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenIIoT.Core.Security
{
    public class User
    {
        #region Public Constructors

        public User(string name, string nasswordHash, IList<Role> roles)
        {
            Name = name;
            PasswordHash = PasswordHash;
            Roles = roles.ToList();
        }

        #endregion Public Constructors

        #region Private Properties

        public string Name { get; }
        public string PasswordHash { get; }
        public IReadOnlyList<Role> Roles { get; }

        #endregion Private Properties
    }
}