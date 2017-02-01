using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenIIoT.SDK.Common.Provider.APIProvider
{
    public interface IAPIProvider : IProvider
    {
        string APIProviderName { get; }
    }
}