using Symbiote.SDK;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Utility.OperationResult;

namespace Symbiote.SDK
{
    public class ProviderRegistry<IProvider> : IProviderRegistry<IProvider>
    {
        private IList<IProvider> registrants;

        public IImmutableList<IProvider> Registrants
        {
            get
            {
                return registrants.ToImmutableList<IProvider>();
            }
        }

        public ProviderRegistry()
        {
            registrants = new List<IProvider>();
        }

        public Result Register(IProvider provider)
        {
            Result retVal = new Result(ResultCode.Failure);

            if (!IsRegistered(provider))
            {
                registrants.Add(provider);
                retVal.SetResultCode(ResultCode.Success);
            }

            return retVal;
        }

        public Result UnRegister(IProvider provider)
        {
            Result retVal = new Result(ResultCode.Failure);

            if (IsRegistered(provider))
            {
                registrants.Remove(provider);
                retVal.SetResultCode(ResultCode.Success);
            }

            return retVal;
        }

        public bool IsRegistered(IProvider provider)
        {
            return registrants.Any(r => object.ReferenceEquals(r, provider));
        }
    }
}