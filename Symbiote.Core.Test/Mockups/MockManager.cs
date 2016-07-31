using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.Test.Mockups
{
    public class MockManager : Manager, IStateful, IManager
    {
        private static MockManager instance;

        private MockManager(IProgramManager manager)
        {
            ManagerName = "Mock Manager";
            RegisterDependency<IProgramManager>(manager);

            ChangeState(State.Initialized);
        }

        public static MockManager Instantiate(IProgramManager manager)
        {
            if (instance == null)
            {
                instance = new MockManager(manager);
            }

            return instance;
        }

        protected override Result Setup(List<IManager> managerInstances)
        {
            return new Result();
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
