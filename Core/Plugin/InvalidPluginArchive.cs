using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.Plugin
{

    public class InvalidPluginArchive
    {
        public string FileName { get; private set; }
        public string Message { get; private set; }

        public InvalidPluginArchive(string fileName, string message)
        {
            FileName = fileName;
            Message = message;
        }

        public void SetFileName(string fileName)
        {
            FileName = fileName;
        }

        public void SetMessage(string message)
        {
            Message = message;
        }
    }
}
