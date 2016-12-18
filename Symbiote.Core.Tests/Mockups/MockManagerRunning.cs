using Symbiote.SDK;
using Utility.OperationResult;

namespace Symbiote.Core.Tests.Mockups
{
    public class MockManagerRunning : Manager, IStateful, IManager
    {
        private static MockManagerRunning instance;

        private MockManagerRunning(IApplicationManager manager)
        {
            ManagerName = "Mock Manager";
            RegisterDependency<IApplicationManager>(manager);

            ChangeState(State.Running);
        }

        public static MockManagerRunning Instantiate(IApplicationManager manager)
        {
            if (instance == null)
            {
                instance = new MockManagerRunning(manager);
            }

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
