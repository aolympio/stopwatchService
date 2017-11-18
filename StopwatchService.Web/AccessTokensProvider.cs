using Microsoft.Owin.Security.OAuth;
using StopwatchService.BusinessRules;
using StopwatchService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StopwatchService.Web
{
    public class AccessTokensProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var isRegissteredUser = new UserBusiness().ValidateIfUserIsRegistered(context.UserName, context.Password);
            
            //Canceling token creation if user is not found.
            if (!isRegissteredUser)
            {
                context.SetError("invalid_grant", "User Not Found.");
                return;
            }

            //Create token with extra info if user exists.
            var userIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
            context.Validated(userIdentity);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            // Passing token properties
            foreach (var item in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(item.Key, item.Value);
            }
            return base.TokenEndpoint(context);
        }
    }
}
