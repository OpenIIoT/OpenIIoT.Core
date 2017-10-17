namespace OpenIIoT.Core.Model.WebApi
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Web.Http;
    using Newtonsoft.Json;
    using NLog;
    using OpenIIoT.Core.Service.WebApi;
    using OpenIIoT.SDK;
    using OpenIIoT.SDK.Common;
    using OpenIIoT.SDK.Model;

    [Service.WebApi.ControllerRoutePrefixAttribute("v1/item")]
    public class ReadController : ApiBaseController
    {
        #region Private Fields

        /// <summary>
        ///     The Logger for this class.
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        ///     The ApplicationManager for the application.
        /// </summary>
        private static IApplicationManager manager = ApplicationManager.GetInstance();

        private static Item model = manager.GetManager<ModelManager>().Model;

        #endregion Private Fields

        #region Public Methods

        [Route("read")]
        [HttpGet]
        public HttpResponseMessage Read()
        {
            IList<Item> result = model.Children;
            return Request.CreateResponse(HttpStatusCode.OK, result, JsonFormatter(ContractResolverType.OptIn, "FQN", "Timestamp", "Quality", "Value", "Children", "AccessMode"));
        }

        [Route("read/{fqn}")]
        [HttpGet]
        public HttpResponseMessage Read(string fqn)
        {
            return Read(fqn, false);
        }

        [Route("read/{fqn}/{fromSource}")]
        [HttpGet]
        public HttpResponseMessage Read(string fqn, bool fromSource)
        {
            // TODO: Fix this so all url encodings are translated
            fqn = fqn.Replace("%25", "%");
            string[] fqns = fqn.Split(',');
            IList<Item> foundItems = new List<Item>();
            HttpResponseMessage retVal;

            foreach (string item in fqns)
            {
                Item foundItem = FetchItem(item, fromSource);
                if (foundItem != default(Item))
                {
                    foundItems.Add(foundItem);
                }
            }

            HttpStatusCode statusCode = foundItems.Count == fqns.Length ? HttpStatusCode.OK : HttpStatusCode.PartialContent;
            JsonMediaTypeFormatter formatter = JsonFormatter(ContractResolverType.OptIn, "FQN", "Timestamp", "Quality", "Value", "Children", "AccessMode");

            if (foundItems.Count > 1)
            {
                retVal = Request.CreateResponse(statusCode, foundItems, formatter);
            }
            else if (foundItems.Count == 1)
            {
                retVal = Request.CreateResponse(statusCode, foundItems[0], formatter);
            }
            else
            {
                retVal = Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return retVal;
        }

        private Item FetchItem(string fqn, bool fromSource)
        {
            Item foundItem = manager.GetManager<IModelManager>().FindItem(fqn);

            if (foundItem != default(Item) && fromSource)
            {
                foundItem.ReadFromSource();
            }

            return foundItem;
        }

        public class ItemData
        {
            #region Public Constructors

            public ItemData(Item item)
            {
            }

            #endregion Public Constructors

            #region Public Properties

            public IList<Item> Children { get; set; }
            public string FQN { get; set; }
            public ItemQuality Quality { get; set; }
            public DateTime Timestamp { get; set; }
            public object Value { get; set; }

            #endregion Public Properties
        }

        #endregion Public Methods
    }
}