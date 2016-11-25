using Symbiote.Core.SDK;
using Utility.OperationResult;

namespace Symbiote.Core.Tests.Mockups
{
    public class ManagerMock : Manager
    {
        private static ManagerMock instance;

        private ManagerMock(IApplicationManager manager)
        {
            ManagerName = "Mock Manager";
            RegisterDependency<IApplicationManager>(manager);

            ChangeState(State.Initialized);
        }

        public static ManagerMock Instantiate(IApplicationManager manager)
        {
            // remove the code that makes this a singleton so that test runners can get a fresh
            // instance each time.
            instance = new ManagerMock(manager);
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
    }
}