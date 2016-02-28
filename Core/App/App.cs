using System;
using Symbiote.Core.Configuration;

namespace Symbiote.Core.App
{
    public class App : AppArchive
    {
        public string URL { get { return "/" + (AppType == AppType.Console ? "console" : Name.ToLower()) + "/"; } }
        public string Configuration { get; private set; }
        public bool IsConfigured { get; private set; }

        public App(AppArchive archive) : this(archive.Name, archive.FQN, archive.Version, archive.AppType, archive.ConfigurationDefinition, archive.FileName) { }

        public App(string name, string fqn, Version version, AppType appType, ConfigurationDefinition configurationDefinition, string fileName = "") : base(name, fqn, version, appType, configurationDefinition, fileName)
        {
            Configuration = "";
        }

        public void Configure(string configuration)
        {
            Configuration = configuration;
            IsConfigured = true;
        }
    }
}
