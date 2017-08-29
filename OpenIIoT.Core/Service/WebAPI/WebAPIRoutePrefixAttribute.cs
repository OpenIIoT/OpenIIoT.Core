using OpenIIoT.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace OpenIIoT.Core.Service.WebAPI
{
    public class WebAPIRoutePrefixAttribute : RoutePrefixAttribute
    {
        #region Public Constructors

        public WebAPIRoutePrefixAttribute(string prefix) : base(prefix)
        {
        }

        #endregion Public Constructors

        #region Public Properties

        public override string Prefix
        {
            get
            {
                IApplicationSettings settings = ApplicationManager.GetInstance().Settings;
                string prefix = $"{settings.WebRoot}/{WebAPIConstants.APIRoutePrefix}/{base.Prefix}";
                prefix = prefix.TrimStart('/').TrimEnd('/');
                return prefix;
            }
        }

        #endregion Public Properties
    }
}