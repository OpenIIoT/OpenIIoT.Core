using System;
using System.Security.Claims;
using Microsoft.Owin.Security;

namespace OpenIIoT.Core.Security
{
    public static class SessionFactory
    {
        #region Public Methods

        /// <summary>
        ///     Creates a new <see cref="Session"/> from the specified <see cref="User"/>.
        /// </summary>
        /// <param name="user">The User for which the Session is to be created.</param>
        /// <returns>The created Session.</returns>
        public static Session CreateSession(User user)
        {
            ClaimsIdentity identity = new ClaimsIdentity("ApiKey");
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Name));
            identity.AddClaim(new Claim(ClaimTypes.Role, user.Role.ToString()));

            string hash = SDK.Common.Utility.ComputeSHA512Hash(Guid.NewGuid().ToString());

            identity.AddClaim(new Claim(ClaimTypes.Hash, hash));

            AuthenticationProperties ticketProperties = new AuthenticationProperties();
            ticketProperties.IssuedUtc = DateTime.UtcNow;
            ticketProperties.ExpiresUtc = DateTime.UtcNow.AddMinutes(SecuritySettings.SessionLength);

            AuthenticationTicket ticket = new AuthenticationTicket(identity, ticketProperties);

            return new Session(hash, ticket);
        }

        /// <summary>
        ///     Extends the exipration time of the specified <see cref="Session"/> to the configured session length.
        /// </summary>
        /// <param name="session">The Session to extend.</param>
        /// <returns>The extended Session.</returns>
        public static Session ExtendSession(Session session)
        {
            session.Ticket.Properties.ExpiresUtc = DateTime.UtcNow.AddMinutes(SecuritySettings.SessionLength);
            return session;
        }

        #endregion Public Methods
    }
}