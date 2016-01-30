using System.Threading.Tasks;

namespace Symbiote.Core.Composite
{
    public interface IWriteable
    {
        bool IsWriteable { get; }
        bool Write(object value);
        Task<bool> WriteAsync(object value);
    }
}
