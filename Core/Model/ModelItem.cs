using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symbiote.Core.Plugin;

namespace Symbiote.Core.Model
{
    internal class ModelItem
    {
        private object Value;

        internal string Name { get; private set; }
        internal string Path { get; private set; }
        internal string FQN { get; private set; }
        internal Type Type { get; private set; }
        internal IConnector Connector { get; private set; }
        internal string ConnectorAddress { get; private set; }

        internal ModelItem(string name, string path, string fqn, Type type)
        {
            Name = name;
            Path = path;
            FQN = fqn;

            ReadValue();
        }

        internal ModelItem SetValue(object value)
        {
            Value = value;
            // todo: persistence goes here
            return this;
        }

        internal object ReadValue()
        {
            return Value;
        }

        internal object ReadValueAsync()
        {
            return Value;
        }

        internal ModelItem WriteValue(object value)
        {
            Value = value;
            return this;
        }

        internal ModelItem WriteValueAsync(object value)
        {
            Value = value;
            return this;
        }
    }
}
