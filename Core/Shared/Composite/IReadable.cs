using System.Threading.Tasks;

namespace Symbiote.Core.Composite
{
    public interface IReadable
    {
        bool IsReadable { get; }
        object Read();
        Task<object> ReadAsync();
    }
}
