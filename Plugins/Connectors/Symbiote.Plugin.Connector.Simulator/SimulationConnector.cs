using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symbiote.Core.Plugin;
using Symbiote.Core;

namespace Symbiote.Plugin.Connector.Simulation
{
    public class SimulationConnector : IConnector
    {
        private IComposite itemRoot;
        
        public string Name { get; private set; }
        public string FullName { get; private set; }
        public Version Version { get; private set; }
        public PluginType PluginType { get; private set; }
        public IPluginConfigurationDefinition ConfigurationDefinition { get; private set; }
        public string InstanceName { get; private set; }
        public string Configuration { get; private set; }
        public bool Configured { get { return true; } }
        public bool Browseable { get { return true; } }
        public bool Writeable { get { return false; } }

        public SimulationConnector(string instanceName)
        {
            InstanceName = instanceName;

            Name = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
            FullName = System.Reflection.Assembly.GetEntryAssembly().GetTypes()[0].Namespace;
            Version = System.Reflection.Assembly.GetEntryAssembly().GetName().Version;
            PluginType = PluginType.Connector;
            ConfigurationDefinition = new PluginConfigurationDefinition();

            InitializeItems();
        }

        public void Configure(string configuration)
        {
        }

        public List<IComposite> Browse(IComposite root)
        {
            return (root == null ? itemRoot.Children : root.Children);
        }

        public object Read(string value)
        {
            double val = DateTime.Now.Second;
            switch(value.Split('.')[3])
            {
                case "Sine":
                    return Math.Sin(val);
                case "Cosine":
                    return Math.Cos(val);
                case "Tangent":
                    return Math.Tan(val);
                case "Ramp":
                    return val;
                case "Step":
                    return val % 5;
                case "Toggle":
                    return val % 2;
                default:
                    return 0;
            }
                
        }

        public void Write(string item, object value)
        {
            throw new NotImplementedException();
        }

        private void InitializeItems()
        {
            // instantiate an item root
            itemRoot = new PluginConnectorItem("Items", true, InstanceName);

            // create some simulation items
            IComposite mathRoot = itemRoot.AddChild(new PluginConnectorItem("Math"));
            mathRoot.AddChild(new PluginConnectorItem("Sine", typeof(double)));
            mathRoot.AddChild(new PluginConnectorItem("Cosine", typeof(double)));
            mathRoot.AddChild(new PluginConnectorItem("Tangent", typeof(double)));

            IComposite processRoot = itemRoot.AddChild(new PluginConnectorItem("Process"));
            processRoot.AddChild(new PluginConnectorItem("Ramp", typeof(double)));
            processRoot.AddChild(new PluginConnectorItem("Step", typeof(double)));
            processRoot.AddChild(new PluginConnectorItem("Toggle", typeof(double)));
        }
    }

    public class PluginConnectorItem : Composite
    {
        public IComposite Parent { get; private set; }
        public string Name { get; private set; }
        public string Path { get; private set; }
        public string FQN { get; private set; }
        public Type Type { get; private set; }
        public string SourceAddress { get; private set; }
        public List<IComposite> Children { get; private set; }
        public string InstanceName { get; private set; }

        public PluginConnectorItem(string name) : this(name, typeof(void), "", false, "") { }
        public PluginConnectorItem(string name, Type type) : this(name, type, "", false, "") { }
        public PluginConnectorItem(string name, bool isRoot, string instanceName) : this(name, typeof(void), "", isRoot, instanceName) { }
        public PluginConnectorItem(string name, Type type, string sourceAddress) : this(name, type, sourceAddress, false, "") { }
        public PluginConnectorItem(string name, Type type, string sourceAddress, bool isRoot, string instanceName)
        {
            Name = name;
            Path = "";
            FQN = "";
            Type = type;
            SourceAddress = sourceAddress;
            Children = new List<IComposite>();

            if (isRoot)
            {
                InstanceName = instanceName;
                this.FQN = InstanceName;
                this.SetParent(this);
            }
        }

        public bool HasChildren()
        {
            return (Children.Count > 0);
        }

        public IComposite AddChild(IComposite child)
        {
            Children.Add(child.SetParent(this));
            return child;
        }

        public IComposite SetParent(IComposite parent)
        {
            Path = parent.FQN;
            FQN = Path + "." + Name;
            return this;
        }
    }

    public class PluginConfigurationDefinition : IPluginConfigurationDefinition
    {
        public string Form { get; private set; }
        public string Schema { get; private set; }

        public PluginConfigurationDefinition()
        {
            Form = "";
            Schema = "";
        }
    }
}
