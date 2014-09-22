using System;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Facebook;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Puteshestvenici.Data;
using Puteshestvenici.Services.Providers;

namespace Puteshestvenici.Services
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public static string PublicClientId { get; private set; }

        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864

        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context and user manager to use a single instance per request
            app.CreatePerOwinContext(PuteshestveniciDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Configure the application for OAuth based flow
            PublicClientId = "self";
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOAuthProvider(PublicClientId),
                AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                AllowInsecureHttp = true
            };

            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerTokens(OAuthOptions);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //    consumerKey: "",
            //    consumerSecret: "");

            var facebookOptions = new FacebookAuthenticationOptions()
            {
                AppId = "1487705754840266",
                AppSecret = "58f0103d9d2bafb53cac09742a16cbed"
            };
            facebookOptions.Scope.Add("email");

            app.UseFacebookAuthentication(facebookOptions);

            var googleOptions = new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = "70504091939-1i58b6hcs2c182antfhe4fcnosf3ijj6.apps.googleusercontent.com",
                ClientSecret = "J9-GGPU007iUAuq_rHVBIyph",
                Provider = new GoogleOAuth2AuthenticationProvider()
                {
                    OnAuthenticated = async context =>
                        {
                            context.Identity.AddClaim(new Claim("picture", context.User.GetValue("picture").ToString()));
                        }
                }
            };
            googleOptions.Scope.Add("email");

            app.UseGoogleAuthentication(googleOptions);
        }
    }
}
