using OpenIIoT.SDK.Common;
using System.Collections.Generic;
using System.Security.Claims;
using Utility.OperationResult;

namespace OpenIIoT.SDK.Security
{
    public interface ISecurityManager : IManager
    {
        #region Public Properties

        IResult EndSession(ClaimsPrincipal principal);

        ClaimsPrincipal FindSession(string key);

        IResult<KeyValuePair<string, ClaimsPrincipal>> StartSession(string user, string password);

        #endregion Public Properties
    }
}