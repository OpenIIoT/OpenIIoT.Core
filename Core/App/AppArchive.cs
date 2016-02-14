using System;

namespace Symbiote.Core.App
{
    public class AppArchive
    {
        public string Name { get; private set; }
        public string FQN { get; private set; }
        public Version Version { get; private set; }
        public AppType AppType { get; private set; }
        public ConfigurationDefinition ConfigurationDefinition { get; private set; }
        public string FileName { get; private set; }

        public AppArchive(string name, string fqn, Version version, AppType appType, ConfigurationDefinition configurationDefinition)
        {
            Name = name;
            FQN = fqn;
            Version = version;
            AppType = appType;
            ConfigurationDefinition = configurationDefinition;
        }

        public virtual void SetFileName(string fileName)
        {
            FileName = fileName;
        }
    }
}
