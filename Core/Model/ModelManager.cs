using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.Model
{
    public class ModelManager
    {
        private ProgramManager manager;
        private static ModelManager instance;

        internal Model Model { get; private set; }

        private ModelManager(ProgramManager manager)
        {
            this.manager = manager;
            Model = new Model();
        }

        internal static ModelManager Instance(ProgramManager manager)
        {
            if (instance == null)
                instance = new ModelManager(manager);

            return instance;
        }
    }
}
