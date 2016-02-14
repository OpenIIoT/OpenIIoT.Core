using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core
{
    public class ActionResult<T> 
    {
        public T Result { get; set; }
        public ActionResultCode ResultCode { get; set; }
        public List<string> Messages { get; set; }

        public ActionResult()
        {
            Result = default(T);
            ResultCode = ActionResultCode.Success;
            Messages = new List<string>();
        }

        public virtual ActionResult<T> AddInfo(string message)
        {
            Messages.Add("[INFO] " + message);
            return this;
        }

        public virtual ActionResult<T> AddWarning(string message)
        {
            Messages.Add("[WARN] " + message);
            ResultCode = ActionResultCode.Warning;
            return this;
        }

        public virtual ActionResult<T> AddError(string message)
        {
            Messages.Add("[ERROR] " + message);
            ResultCode = ActionResultCode.Failure;
            return this;
        }
    }
}
