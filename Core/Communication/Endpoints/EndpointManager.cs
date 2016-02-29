using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using Microsoft.Owin.Hosting;
using Microsoft.AspNet.SignalR;
using System.Web.Http;
using Newtonsoft.Json;
using Symbiote.Core.Configuration;
using Symbiote.Core.Communication.Services.Web;
using Symbiote.Core.Communication.Services.IoT.MQTT;

namespace Symbiote.Core.Communication.Endpoints
{
    public class EndpointManager : IManager
    {
        private ProgramManager manager;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static EndpointManager instance;

        internal List<IEndpoint> Endpoints { get; private set; }

        private EndpointManager(ProgramManager manager)
        {
            this.manager = manager;

            Endpoints = new List<IEndpoint>();
        }

        public static EndpointManager Instance(ProgramManager manager)
        {
            if (instance == null)
                instance = new EndpointManager(manager);

            return instance;
        }

        public OperationResult Start()
        {
            return new OperationResult();
        }
    }
}
