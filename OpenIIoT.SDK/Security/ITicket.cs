namespace OpenIIoT.SDK.Security
{
    using System;
    using System.Security.Claims;

    /// <summary>
    ///     An authentication Ticket.
    /// </summary>
    public interface ITicket
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the time at which the Ticket expires.
        /// </summary>
        DateTimeOffset ExpiresUtc { get; set; }

        /// <summary>
        ///     Gets the <see cref="ClaimsIdentity"/> instance associated with the Ticket.
        /// </summary>
        ClaimsIdentity Identity { get; }

        /// <summary>
        ///     Gets the time at which the Ticket was issued.
        /// </summary>
        DateTimeOffset IssuedUtc { get; }

        #endregion Public Properties
    }
}