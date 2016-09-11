using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            if (instance == null)
            {
                instance = new MockManager(manager);
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
