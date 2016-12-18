using Symbiote.SDK;
using Utility.OperationResult;

namespace Symbiote.Core.Tests.Mockups
{
    public class MockManagerNoInstantiate : Manager, IStateful, IManager
    {
        private static MockManagerNoInstantiate instance;

        private MockManagerNoInstantiate()
        {
            ManagerName = "Mock Manager";

            ChangeState(State.Initialized);
        }

        protected override void Setup()
        {
            return;
        }

        protected override Result Startup()
        {
            return new Result();
        }

        protected override Result Shutdown(StopType stopType = StopType.Stop)
        {
            return new Result();
        }
    }
}
