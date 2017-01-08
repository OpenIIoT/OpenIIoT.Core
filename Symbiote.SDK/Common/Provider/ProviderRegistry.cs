using Symbiote.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility.OperationResult;

namespace Symbiote.SDK
{
    public class ProviderRegistry
    {
        private IApplicationManager manager;
        private IList<IProvider> providers;

        public IReadOnlyList<T> GetProviders<T>() where T : IProvider
        {
            return providers.OfType<T>().ToList().AsReadOnly();
        }

        public IReadOnlyList<IProvider> Providers
        {
            get
            {
                return providers.ToList().AsReadOnly();
            }
        }

        public ProviderRegistry(IApplicationManager manager)
        {
            this.manager = manager;
            providers = new List<IProvider>();
        }

        public Result Register(IProvider provider)
        {
            Result retVal = new Result(ResultCode.Failure);

            if (!IsRegistered(provider))
            {
                providers.Add(provider);
                retVal.SetResultCode(ResultCode.Success);
            }

            return retVal;
        }

        public Result UnRegister(IProvider provider)
        {
            Result retVal = new Result(ResultCode.Failure);

            if (IsRegistered(provider))
            {
                providers.Remove(provider);
                retVal.SetResultCode(ResultCode.Success);
            }

            return retVal;
        }

        public bool IsRegistered(IProvider provider)
        {
            return providers.Any(r => object.ReferenceEquals(r, provider));
        }

        public IReadOnlyList<IProvider> Discover()
        {
            providers = Discoverer.Discover<IProvider>(manager);

            return Providers;
        }

        public IReadOnlyList<T> Discover<T>()
        {
            return Discover().OfType<T>().ToList().AsReadOnly();
        }

        public Item FindItem(string fqn)
        {
            return FindItem(fqn, false);
        }

        private Item FindItem(string fqn, bool refreshed = false)
        {
            IReadOnlyList<IItemProvider> itemProviders = GetProviders<IItemProvider>();
            Item foundItem = default(Item);

            foreach (IItemProvider provider in itemProviders)
            {
                foundItem = provider.Find(fqn);
                if (foundItem != default(Item))
                {
                    return foundItem;
                }
            }

            if (foundItem == default(Item) && !refreshed)
            {
                Discover();
                return FindItem(fqn, true);
            }
            else
            {
                return foundItem;
            }
        }
    }
}