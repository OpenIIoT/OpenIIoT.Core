using OpenIIoT.SDK.Common;
using System.Collections.Generic;
using System.Security.Claims;
using Utility.OperationResult;

namespace OpenIIoT.Core.Security
{
    public interface ISecurityManager : IManager
    {
        #region Public Properties

        IResult EndSession(Session session);

        Session FindSession(string key);

        IResult<Session> StartSession(string user, string password);

        #endregion Public Properties
    }
}