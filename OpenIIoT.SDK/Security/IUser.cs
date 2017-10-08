namespace OpenIIoT.SDK.Security
{
    /// <summary>
    ///     An application User.
    /// </summary>
    public interface IUser
    {
        #region Private Properties

        /// <summary>
        ///     Gets or sets the display name of the User.
        /// </summary>
        string DisplayName { get; set; }

        /// <summary>
        ///     Gets or sets the email address of the User.
        /// </summary>
        string Email { get; set; }

        /// <summary>
        ///     Gets the name of the User.
        /// </summary>
        string Name { get; }

        /// <summary>
        ///     Gets or sets the SHA512 hash of the password for the User.
        /// </summary>
        string PasswordHash { get; set; }

        /// <summary>
        ///     Gets or sets the Role of the User.
        /// </summary>
        Role Role { get; set; }

        #endregion Private Properties
    }
}