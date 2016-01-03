using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symbiote.Core.Plugin;

namespace Symbiote.Core.Model
{
    public class ModelItem
    {
        private object Value;

        public string Name { get; private set; }
        public string Path { get; private set; }
        public string FQN { get; private set; }
        public Type Type { get; private set; }
        public IConnector Connector { get; private set; }
        public string ConnectorAddress { get; private set; }

        public ModelItem(string name, string path, string fqn, Type type)
        {
            Name = name;
            Path = path;
            FQN = fqn;

            ReadValue();
        }

        public ModelItem SetValue(object value)
        {
            Value = value;
            // todo: persistence goes here
            return this;
        }

        public object ReadValue()
        {
            return Value;
        }

        public object ReadValueAsync()
        {
            return Value;
        }

        public ModelItem WriteValue(object value)
        {
            Value = value;
            return this;
        }

        public ModelItem WriteValueAsync(object value)
        {
            Value = value;
            return this;
        }
    }
}
