using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace OpenIIoT.Core.Security
{
    public class User
    {
        #region Private Properties

        public string Name { get; set; }
        public string PasswordHash { get; set; }
        public Role Role { get; set; }

        #endregion Private Properties
    }
}