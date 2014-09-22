using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.Facebook;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Puteshesetvenici.ServicesWithCustomAuth.Providers;

[assembly: OwinStartup(typeof(Puteshesetvenici.ServicesWithCustomAuth.Startup))]
namespace Puteshesetvenici.ServicesWithCustomAuth
{
    public class Startup
    {
        private const string TokenPath = "/token";
        private const int TokenExpirationDays = 3;

        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; set; }

        public static GoogleOAuth2AuthenticationOptions GoogleAuthOptions { get; set; }

        public static FacebookAuthenticationOptions FacebookAuthOptions { get; set; }

        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);

            app.UseCors(CorsOptions.AllowAll);
            ConfigureOAuth(app);
            app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            OAuthBearerOptions = new OAuthBearerAuthenticationOptions();

            GoogleAuthOptions = new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = "xxx",
                ClientSecret = "axax",
                Provider = new GoogleAuthProvider()
            };

            app.UseGoogleAuthentication(GoogleAuthOptions);

            FacebookAuthOptions = new FacebookAuthenticationOptions()
            {
                AppId = "1487705754840266",
                AppSecret = "58f0103d9d2bafb53cac09742a16cbed",
                Provider = new FacebookAuthProvider()
            };

            app.UseFacebookAuthentication(FacebookAuthOptions);

            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString(TokenPath),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(TokenExpirationDays),
                Provider = new SimpleAuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }
    }
}