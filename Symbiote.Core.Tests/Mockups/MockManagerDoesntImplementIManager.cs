using Symbiote.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.OperationResult;

namespace Symbiote.Core.Tests.Mockups
{
    public class MockManagerDoesntImplementIManager
    {
        private static MockManagerDoesntImplementIManager instance;

        private MockManagerDoesntImplementIManager(IApplicationManager manager)
        {

        }

        public static MockManagerDoesntImplementIManager Instantiate(IApplicationManager manager)
        {
            if (instance == null)
            {
                instance = new MockManagerDoesntImplementIManager(manager);
            }

            return instance;
        }
    }
}
