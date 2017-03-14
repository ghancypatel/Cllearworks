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
            return;
        }

        public override async Task GrantClientCredentials(OAuthGrantClientCredentialsContext context)
        {
            //var identity = new ClaimsIdentity(new GenericIdentity(context.ClientId, OAuthDefaults.AuthenticationType));
            //context.Validated(identity);

            var clientGuid = Guid.Parse(context.ClientId);
            var appManager = new ApplicationManager();
            var app = await appManager.GetApplicationByClientId(clientGuid);
            var user = new COHApplicationUser();
            if (app != null)
            {
                user.ClientId = clientGuid.ToString("N");
                user.ApplicationName = app.Name;
                user.ApplicationId = app.Id.ToString();
            }

            var userManager = new COHUserManager();
            var identity = userManager.CreateIdentityAsync(user, OAuthDefaults.AuthenticationType).Result;
            context.Validated(identity);

            return;
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

            return;
        }
    }
}
