using OpenIIoT.SDK.Common;
using System;
using System.Collections.Generic;

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