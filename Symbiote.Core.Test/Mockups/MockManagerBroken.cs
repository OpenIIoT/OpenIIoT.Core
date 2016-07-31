using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.Test.Mockups
{
    public class MockManagerBroken : Manager, IStateful, IManager
    {
        private static MockManagerBroken instance;

        private MockManagerBroken(IProgramManager manager)
        {
            ManagerName = "Mock Manager";
            RegisterDependency<IProgramManager>(manager);

            ChangeState(State.Initialized);
        }

        public static MockManagerBroken Instantiate(IProgramManager manager)
        {
            if (instance == null)
            {
                instance = new MockManagerBroken(manager);
            }

            return instance;
        }

        protected override Result Setup(List<IManager> managerInstances)
        {
            return default(Result);
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
