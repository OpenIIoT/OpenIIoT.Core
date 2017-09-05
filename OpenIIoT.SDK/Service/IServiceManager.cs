using System;
using System.Collections.Generic;
using OpenIIoT.SDK.Common;

namespace OpenIIoT.SDK.Service
{
    public interface IServiceManager : IManager
    {
        #region Public Properties

        Dictionary<string, IService> Services { get; }

        Dictionary<string, Type> ServiceTypes { get; }

        #endregion Public Properties
    }
}