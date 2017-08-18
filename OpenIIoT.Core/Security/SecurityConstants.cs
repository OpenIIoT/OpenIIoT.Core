using OpenIIoT.SDK.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenIIoT.Core.Security
{
    public static class SecurityConstants
    {
        #region Public Fields

        public const string DefaultEmail = "admin@localhost";
        public const string DefaultPassword = "C7AD44CBAD762A5DA0A452F9E854FDC1E0E7A52A38015F23F3EAB1D80B931DD472634DFAC71CD34EBC35D16AB7FB8A90C81F975113D6C7538DC69DD8DE9077EC";
        public const string DefaultUsername = "admin";
        public static readonly User DefaultUser = new User(DefaultUsername, DefaultEmail, DefaultPassword, true);

        #endregion Public Fields
    }
}