using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core
{
    public class ActionResult : IActionResult
    {
        public ActionResultCode Result { get; private set; }
        public List<string> Messages { get; private set; }

        public ActionResult()
        {
            Result = ActionResultCode.Success;
            Messages = new List<string>();
        }

        public virtual IActionResult AddInfo(string message)
        {
            Messages.Add("[INFO] " + message);
            return this;
        }

        public virtual IActionResult AddWarning(string message)
        {
            Messages.Add("[WARN] " + message);
            Result = ActionResultCode.Warning;
            return this;
        }

        public virtual IActionResult AddError(string message)
        {
            Messages.Add("[ERROR] " + message);
            Result = ActionResultCode.Failure;
            return this;
        }
    }
}
