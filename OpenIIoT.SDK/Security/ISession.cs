namespace OpenIIoT.SDK.Security
{
    using System;
    using System.Security.Claims;

    public interface ISession
    {
        #region Public Properties

        /// <summary>
        ///     Gets the time at which the Session was created, in Utc.
        /// </summary>
        DateTimeOffset Created { get; }

        /// <summary>
        ///     Gets or sets the time at which the Session expires, in Utc.
        /// </summary>
        DateTimeOffset Expires { get; set; }

        /// <summary>
        ///     Gets the <see cref="ClaimsIdentity"/> instance associated with the Session.
        /// </summary>
        ClaimsIdentity Identity { get; }

        /// <summary>
        ///     Gets a value indicating whether the Session is expired.
        /// </summary>
        bool IsExpired { get; }

        /// <summary>
        ///     Gets the token for the Session.
        /// </summary>
        string Token { get; }

        /// <summary>
        ///     Gets the User to which the Session belongs.
        /// </summary>
        IUser User { get; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///     Returns the specified Claim <paramref name="type"/> within the Session's <see cref="Ticket"/> .
        /// </summary>
        /// <param name="type">The type of Claim to retrieve.</param>
        /// <returns>The retrieved Claim value.</returns>
        string GetClaim(string type);

        #endregion Public Methods
    }
}