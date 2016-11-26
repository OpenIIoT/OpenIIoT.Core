using Symbiote.Core.SDK;
using Utility.OperationResult;

namespace Symbiote.Core.Tests.Mockups
{
    public class MockManager : Manager, IStateful, IManager
    {
        private static MockManager instance;

        private MockManager(IApplicationManager manager)
        {
            ManagerName = "Mock Manager";
            RegisterDependency<IApplicationManager>(manager);

            ChangeState(State.Initialized);
        }

        public static MockManager Instantiate(IApplicationManager manager)
        {
            // remove the code that makes this a singleton so that test runners can get a fresh
            // instance each time.
            instance = new MockManager(manager);
            return instance;
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