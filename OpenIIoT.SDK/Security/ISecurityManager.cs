using OpenIIoT.SDK.Common;
using System.Collections.Generic;
using System.Security.Claims;
using Utility.OperationResult;

namespace OpenIIoT.SDK.Security
{
    public interface ISecurityManager : IManager
    {
        #region Public Properties

        IReadOnlyList<ClaimsPrincipal> Sessions { get; }

        IResult EndSession(ClaimsPrincipal principal);

        ClaimsPrincipal FindSession(string key);

        IResult StartSession(ClaimsPrincipal principal);

        #endregion Public Properties
    }
}