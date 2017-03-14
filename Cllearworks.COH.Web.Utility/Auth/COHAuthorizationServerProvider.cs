using Cllearworks.COH.BusinessManager.Applications;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Cllearworks.COH.Web.Utility.Auth
{
    public class COHAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId;
            string clientSecret;
            if (context.TryGetBasicCredentials(out clientId, out clientSecret) ||
            context.TryGetFormCredentials(out clientId, out clientSecret))
            {
                var appManager = new ApplicationManager();                
                if (await appManager.VerifyApplicationSecretAsync(Guid.Parse(clientId), Guid.Parse(clientSecret)))
                {
                    context.Validated();
                }
                else
                {
                    context.SetError("Invalid client id and client secret");
                }
            }
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            COHUserManager _manager = new COHUserManager();

            COHApplicationUser user = await _manager.FindAsync(context.UserName, context.Password);

            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }

            //var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            //identity.AddClaim(new Claim("sub", context.UserName));
            //identity.AddClaim(new Claim("role", "user"));
            var identity = await _manager.CreateIdentityAsync(user, OAuthDefaults.AuthenticationType);

            context.Validated(identity);

        }
    }
}
