using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.App
{
    public interface IApp
    {
        string Name { get; }
        string FQN { get; }
        Version Version { get; }
        AppType AppType { get; }
        IAppConfigurationDefinition AppConfigurationDefinition { get; }
        string FileName { get; }
    }
    public interface IAppInstance : IApp
    {
        string URL { get; }
        string Configuration { get; }
        bool Configured { get; }
        void Configure(string configuration);
    }

    public interface IAppConfigurationDefinition : IConfigurationDefinition
    {
        string Form { get; }
        string Schema { get; }
    }
}
