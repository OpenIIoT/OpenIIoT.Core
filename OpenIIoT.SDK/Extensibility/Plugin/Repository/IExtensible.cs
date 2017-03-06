using OpenIIoT.SDK.Extensibility.Plugin;
using Utility.OperationResult;

namespace OpenIIoT.SDK.Extensibility.Plugin.Repository
{
    public interface IExtensible
    {
        Result CreateTable();

        Result DropTable();

        Result CreateView();

        Result DropView();
    }
}