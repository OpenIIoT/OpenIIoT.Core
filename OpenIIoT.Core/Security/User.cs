using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace OpenIIoT.Core.Security
{
    public class User
    {
        #region Public Constructors

        public User(string name, string email, string passwordHash)
            : this(name, email, passwordHash, false)
        {
        }

        [JsonConstructor]
        public User(string name, string email, string passwordHash, bool isAdministrator)
        {
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            IsAdministrator = isAdministrator;
        }

        #endregion Public Constructors

        #region Private Properties

        public string Email { get; }

        public bool IsAdministrator { get; }

        public string Name { get; }

        public string PasswordHash { get; }

        #endregion Private Properties
    }
}