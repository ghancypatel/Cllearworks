using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cllearworks.COH.Web.Utility.Auth
{
    public class COHApplicationUser : IUser
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public string Salt { get; set; }

        public string ApplicationId { get; set; }

        public string ClientId { get; set; }
    }
}
