using Microsoft.Owin.Security.OAuth;
using StopwatchService.BusinessRules;
using StopwatchService.Domain.Structs;
using StopwatchService.Infrasctructure.Config;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StopwatchService.Web
{
    public class AccessTokensProvider : OAuthAuthorizationServerProvider
    {
        private const string MustRegisterNewUsersKey = "MustRegisterNewUsers";
        private UserWrapper UserWrapper;

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {            
            bool mustRegisterNewUsersKey = bool.Parse(ConfigurationProvider.GetConfiguration(MustRegisterNewUsersKey));
            var isRegisteredUser = new UserBusiness().ValidateIfUserIsRegistered(context.UserName, context.Password);

            //Canceling token creation if user is not found.
            if (!isRegisteredUser && !mustRegisterNewUsersKey)
            {
                context.SetError("invalid_grant", "User Not Found.");
                return;
            }

            //Create token with extra info if user exists.
            var userIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
            context.Validated(userIdentity);

            UserWrapper = new UserWrapper
            {
                Name = context.UserName,
                Password = context.Password,
                IsEnabled = true,
                CreationDate = DateTime.Now
            };            
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

        public override Task TokenEndpointResponse(OAuthTokenEndpointResponseContext context)
        {
            UserWrapper.Token = context.AccessToken;
            DateTime expriresDate = DateTime.ParseExact(context.Properties.Dictionary[".expires"], "R", null);
            UserWrapper.TokenExpirationDate = expriresDate;

            new UserBusiness().InsertOrReplaceStopwatch(UserWrapper);

            return base.TokenEndpointResponse(context);
        }           
    }
}
