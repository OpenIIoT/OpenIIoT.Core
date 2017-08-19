namespace OpenIIoT.Core.Security
{
    public class User
    {
        #region Public Constructors

        public User(string name, string passwordHash, Role role)
        {
            Name = name;
            PasswordHash = passwordHash;
            Role = role;
        }

        #endregion Public Constructors

        #region Private Properties

        public string Name { get; set; }
        public string PasswordHash { get; set; }
        public Role Role { get; set; }

        #endregion Private Properties
    }
}