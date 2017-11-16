using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;

namespace StopwatchService.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Configuring WebApi
            var config = new HttpConfiguration();

            // Configuring Routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            // Enabling Cors
            app.UseCors(CorsOptions.AllowAll);

            // Enable Access Tokens
            EnableAccessTokens(app);

            // Enabling WebApi configs
            app.UseWebApi(config);
        }

        private void EnableAccessTokens(IAppBuilder app)
        {
            // Configuring tokens providing
            var tokenConfigurationOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(2),
                Provider = new AccessTokensProvider()
            };

            // Enabling tokens access usage            
            app.UseOAuthAuthorizationServer(tokenConfigurationOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}