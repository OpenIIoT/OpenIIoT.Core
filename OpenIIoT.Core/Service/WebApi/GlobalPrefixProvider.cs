using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Routing;

namespace OpenIIoT.Core.Service.WebApi
{
    public class GlobalPrefixProvider : DefaultDirectRouteProvider
    {
        #region Public Constructors

        public GlobalPrefixProvider(string prefix)
        {
            Prefix = prefix;
        }

        #endregion Public Constructors

        #region Private Properties

        private string Prefix { get; set; }

        #endregion Private Properties

        #region Protected Methods

        protected override string GetRoutePrefix(HttpControllerDescriptor controllerDescriptor)
        {
            string existingPrefix = base.GetRoutePrefix(controllerDescriptor);
            return string.IsNullOrEmpty(existingPrefix) ? Prefix : $"{Prefix}/{existingPrefix}";
        }

        #endregion Protected Methods
    }
}