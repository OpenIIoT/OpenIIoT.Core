using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OpenIIoT.Core.Tests
{
    public static class Extensions
    {
        #region Public Methods

        public static T GetContent<T>(this HttpResponseMessage response)
        {
            try
            {
                return (T)((ObjectContent<T>)response.Content).Value;
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        #endregion Public Methods
    }
}