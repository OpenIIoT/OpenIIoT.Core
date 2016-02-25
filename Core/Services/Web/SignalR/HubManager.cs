using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.Services.Web.SignalR
{
    public class HubManager
    {
        /// <summary>
        /// The ProgramManager for the application.
        /// </summary>
        private ProgramManager manager = ProgramManager.Instance();

        /// <summary>
        /// The Logger for this class.
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public Dictionary<string, List<string>> Subscriptions { get; private set; }

        public HubManager()
        {
            Subscriptions = new Dictionary<string, List<string>>();
        }

        public void IncrementSubscriptions(string fqn, string client)
        {
            IncrementSubscriptions(fqn, client, Subscriptions);
        }

        public void IncrementSubscriptions(string fqn, string client, Dictionary<string, List<string>> dictionary)
        {
            List<string> subs;
            dictionary.TryGetValue(fqn, out subs);

            if (subs == default(List<string>))
                subs = new List<string>();

            subs.Add(client);

            dictionary[fqn] = subs;
        }

        public void DecrementSubscriptions(string fqn, string client)
        {
            DecrementSubscriptions(fqn, client, Subscriptions);
        }

        public void DecrementSubscriptions(string fqn, string client, Dictionary<string, List<string>> dictionary)
        {
            List<string> subs;
            dictionary.TryGetValue(fqn, out subs);

            if (subs != default(List<string>))
                subs.Remove(client);

            if (subs.Count == 0)
            {
                logger.Info("No more subscriptions to '" + fqn + "'... removing event.");

            }
        }

        public List<string> GetSubscriptions(string fqn)
        {
            return GetSubscriptions(fqn, Subscriptions);
        }

        public List<string> GetSubscriptions(string fqn, Dictionary<string, List<string>> dictionary)
        {
            List<string> subs;
            dictionary.TryGetValue(fqn, out subs);
            return subs;
        }

        public void OnChanged(Item sender, ItemEventArgs e)
        {
            logger.Info("data fired");
            Send(sender);
        }

        public void Send(Item item)
        {
            string itemJson = item.ToJson(new ContractResolver(new List<string>(new string[] { "FQN", "Type", "Value", "Children" }), ContractResolverType.OptIn, true));
            string valueJson = JsonConvert.SerializeObject(item.Value);

            logger.Info("Sending data: " + itemJson + "; " + valueJson);

            Microsoft.AspNet.SignalR.GlobalHost.ConnectionManager.GetHubContext<Services.Web.SignalR.RealtimeHub>().Clients.Group(item.FQN).addMessage(itemJson, valueJson);
        }
    }
}
