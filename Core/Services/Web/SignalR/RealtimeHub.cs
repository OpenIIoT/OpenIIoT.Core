using System.Collections.Generic;
using Microsoft.AspNet.SignalR;
using NLog;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Symbiote.Core.Services.Web.SignalR
{
    public class RealtimeHub : Hub
    {
        /// <summary>
        /// The ProgramManager for the application.
        /// </summary>
        private ProgramManager manager = ProgramManager.Instance();

        /// <summary>
        /// The Logger for this class.
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private static HubManager hubManager;

        public RealtimeHub()
        {
            if (hubManager == default(HubManager))
                hubManager = new HubManager();
        }

        public override Task OnConnected()
        {
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            return base.OnReconnected();
        }

        public void Send(Item item)
        {
            string itemJson = item.ToJson(new ContractResolver(new List<string>(new string[] { "FQN", "Type", "Value", "Children" }), ContractResolverType.OptIn, true));
            string valueJson = JsonConvert.SerializeObject(item.Value);
            
            logger.Info("Sending data: " + itemJson + "; " + valueJson);
            Clients.Group(item.FQN).addMessage(itemJson, valueJson);
        }

        public void Subscribe(string fqn)
        {
            Item foundItem = AddressResolver.Resolve(fqn);

            if (foundItem != default(Item))
            {
                logger.Info("found guid: " + foundItem.Guid);
                foundItem.Changed += hubManager.OnChanged;
                Groups.Add(Context.ConnectionId, foundItem.FQN);
                hubManager.IncrementSubscriptions(foundItem.FQN, Context.ConnectionId);
                logger.Info("Client " + Context.ConnectionId + " subscribed to " + fqn);

                foreach (string s in hubManager.GetSubscriptions(foundItem.FQN))
                    logger.Info("Sub: " + s);

            }
            else
                logger.Info("Unable to subscribe to '" + fqn + "'; the Item can't be found.");
        }

        public void Unsubscribe(string fqn)
        {
            Item foundItem = AddressResolver.Resolve(fqn);

            if (foundItem != default(Item))
            {
                logger.Info("found guid: " + foundItem.Guid);
                foundItem.Changed -= hubManager.OnChanged;
                Groups.Remove(Context.ConnectionId, foundItem.FQN);
                hubManager.DecrementSubscriptions(foundItem.FQN, Context.ConnectionId);     
                logger.Info("Client " + " unsubscribed from " + fqn);

                foreach (string s in hubManager.GetSubscriptions(foundItem.FQN))
                    logger.Info("Sub: " + s);
            }
            else
                logger.Info("Unable to unsubscribe from '" + fqn + "'; the Item can't be found.");
        }
    }
}
