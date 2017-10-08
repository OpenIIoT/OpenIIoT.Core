namespace OpenIIoT.SDK.Security
{
    using System;

    public interface ISession
    {
        #region Public Properties

        /// <summary>
        ///     Gets the expiration timestamp of the Ticket, in UTC.
        /// </summary>
        DateTimeOffset Expires { get; }

        /// <summary>
        ///     Gets a value indicating whether the Session is expired.
        /// </summary>
        bool IsExpired { get; }

        /// <summary>
        ///     Gets the issued timestamp of the Ticket, in UTC.
        /// </summary>
        DateTimeOffset Issued { get; }

        /// <summary>
        ///     Gets the SDK.Security.Ticket for the Session.
        /// </summary>
        ITicket Ticket { get; }

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