using OpenIIoT.SDK.Common;
using System.Collections.Generic;
using System.Security.Claims;

namespace OpenIIoT.SDK.Security
{
    public interface ISecurityManager : IManager
    {
        #region Public Properties

        IReadOnlyList<ClaimsPrincipal> Sessions { get; }

        #endregion Public Properties
    }
}