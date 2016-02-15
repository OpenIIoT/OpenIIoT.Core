using System;

namespace Symbiote.Core.App
{
    public class App : AppArchive
    {
        public string URL { get { return "/" + Name.ToLower() + "/"; } }
        public string Configuration { get; private set; }
        public bool IsConfigured { get; private set; }

        public App(AppArchive archive) : this(archive.Name, archive.FQN, archive.Version, archive.AppType, archive.ConfigurationDefinition) { }

        public App(string name, string fqn, Version version, AppType appType, ConfigurationDefinition configurationDefinition) : base(name, fqn, version, appType, configurationDefinition)
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
