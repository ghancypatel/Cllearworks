using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cllearworks.COH.Web.Utility.Auth
{
    public class COHUserManager : UserManager<COHApplicationUser, string>
    {
        public COHUserManager()
			: this( new COHUserStore() )
		{
        }

        public COHUserManager(IUserStore<COHApplicationUser, string> store)
			: base( store )
		{
            if (store == null)
                throw new ArgumentNullException("store");

            UserValidator = new UserValidator<COHApplicationUser>(this);
            PasswordValidator = new MinimumLengthValidator(6);
            PasswordHasher = new PasswordHasher();
            ClaimsIdentityFactory = new COHClaimsIdentityFactory();
        }
    }
}
