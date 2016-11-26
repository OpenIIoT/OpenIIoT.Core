using Symbiote.Core.SDK;
using Utility.OperationResult;

namespace Symbiote.Core.Tests.Common.Mockups
{
    public class ManagerMockWithDependency : Manager
    {
        private static ManagerMockWithDependency instance;

        private ManagerMockWithDependency(IApplicationManager manager, IManager otherManager)
        {
            ManagerName = "Mock Manager";
            RegisterDependency<IApplicationManager>(manager);
            RegisterDependency<IManager>(otherManager);

            ChangeState(State.Initialized);
        }

        public static ManagerMockWithDependency Instantiate(IApplicationManager manager, IManager otherManager)
        {
            // remove the code that makes this a singleton so that test runners can get a fresh
            // instance each time.
            instance = new ManagerMockWithDependency(manager, otherManager);
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