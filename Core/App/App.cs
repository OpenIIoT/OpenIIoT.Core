using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.App
{
    [JsonObject]
    public class App : IApp
    {
        public string Name { get; private set; }
        public string FQN { get; private set; }
        public Version Version { get; private set; }
        public AppType AppType { get; private set; }
        public IAppConfigurationDefinition AppConfigurationDefinition { get; private set; }
        public string FileName { get; set; }

        [JsonConstructor]
        public App(string name, string fqn, Version version, AppType appType)
        {
            Name = name;
            FQN = fqn;
            Version = version;
            AppType = appType;
        }
    }
}
