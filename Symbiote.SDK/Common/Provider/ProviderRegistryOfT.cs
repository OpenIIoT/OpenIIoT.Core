using Symbiote.SDK;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Utility.OperationResult;

namespace Symbiote.SDK
{
    public class ProviderRegistry<T> where T : IProvider
    {
        private IApplicationManager manager;
        private IList<T> providers;

        public IReadOnlyList<T> Providers
        {
            get
            {
                return providers.ToList().AsReadOnly();
            }
        }

        public ProviderRegistry(IApplicationManager manager)
        {
            this.manager = manager;
            providers = new List<T>();
        }

        public Result Register(T provider)
        {
            Result retVal = new Result(ResultCode.Failure);

            if (!IsRegistered(provider))
            {
                providers.Add(provider);
                retVal.SetResultCode(ResultCode.Success);
            }

            return retVal;
        }

        public Result UnRegister(T provider)
        {
            Result retVal = new Result(ResultCode.Failure);

            if (IsRegistered(provider))
            {
                providers.Remove(provider);
                retVal.SetResultCode(ResultCode.Success);
            }

            return retVal;
        }

        public bool IsRegistered(T provider)
        {
            return providers.Any(r => object.ReferenceEquals(r, provider));
        }

        public IReadOnlyList<T> Discover()
        {
            providers = Discoverer.Discover<T>(manager);

            return Providers;
        }

        public IReadOnlyList<T> Discover<T>()
        {
            return Discover().OfType<T>().ToList().AsReadOnly();
        }
    }
}