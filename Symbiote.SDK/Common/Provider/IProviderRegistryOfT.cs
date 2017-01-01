using Symbiote.SDK;
using System.Collections.Immutable;
using Utility.OperationResult;

namespace Symbiote.SDK
{
    public interface IProviderRegistry<IProvider>
    {
        IImmutableList<IProvider> Registrants { get; }

        Result Register(IProvider provider);

        Result UnRegister(IProvider provider);

        bool IsRegistered(IProvider provider);
    }
}