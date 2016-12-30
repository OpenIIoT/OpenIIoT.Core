using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.OperationResult;

namespace Symbiote.SDK.Common
{
    internal class Registry<TKey, TValue>
    {
        private Dictionary<TKey, TValue> register;

        public Registry()
        {
            register = new Dictionary<TKey, TValue>();
        }

        public Result Register(TKey key, TValue value)
        {
            Result retVal = new Result();

            if (register.ContainsKey(key))
            {
                retVal.AddError("The specified key '" + key.ToString() + "' has already been registered.");
            }
            else
            {
                register.Add(key, value);
            }

            return retVal;
        }

        public Result DeRegister(TKey key)
        {
            Result retVal = new Result();

            if (!register.ContainsKey(key))
            {
                retVal.AddWarning("The specified key '" + key.ToString() + "' is not registered and therefore can not be deregsitered.");
            }
            else
            {
                register.Remove(key);
            }

            return retVal;
        }
    }
}