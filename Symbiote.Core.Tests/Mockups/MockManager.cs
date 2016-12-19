using Symbiote.SDK;
using Utility.OperationResult;

namespace Symbiote.Core.Tests.Mockups
{
    /// <summary>
    ///     Mocks a Manager.
    /// </summary>
    /// <remarks>
    ///     It is not feasible to use a mocking framework for this mockup due to the Type parameter requirement of the
    ///     ApplicationManager class;
    /// </remarks>
    public class MockManager : Manager
    {
        /// <summary>
        /// </summary>
        private static MockManager instance;

        private MockManager(IApplicationManager manager)
        {
            ManagerName = "Mock Manager";
            RegisterDependency<IApplicationManager>(manager);

            ChangeState(State.Initialized);
        }

        public static MockManager Instantiate(IApplicationManager manager)
        {
            // remove the code that makes this a singleton so that test runners can get a fresh instance each time.
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