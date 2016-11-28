using Symbiote.Core.SDK;
using Utility.OperationResult;

namespace Symbiote.Core.Tests.Common.Mockups
{
    public class OtherManagerMock : Manager
    {
        private static OtherManagerMock instance;

        private OtherManagerMock(IApplicationManager manager)
        {
            ManagerName = "Mock Manager";
            RegisterDependency<IApplicationManager>(manager);

            ChangeState(State.Initialized);
        }

        public static OtherManagerMock Instantiate(IApplicationManager manager)
        {
            // remove the code that makes this a singleton so that test runners can get a fresh
            // instance each time.
            instance = new OtherManagerMock(manager);
            return instance;
        }

        public bool CheckDependency()
        {
            return Dependency<IApplicationManager>() != null;
        }

        public bool CheckBadDependency()
        {
            return Dependency<IManager>() != null;
        }

        public void Fault()
        {
            ChangeState(State.Faulted);
        }

        public void FaultWithRestart()
        {
            ChangeState(State.Faulted, StopType.Restart);
        }

        public void Shutdown()
        {
            ChangeState(State.Stopped, StopType.Shutdown);
        }
    }
}