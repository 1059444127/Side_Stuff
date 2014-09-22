using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Puteshesetvenici.ServicesWithCustomAuth.Models;
using Puteshesetvenici.ServicesWithCustomAuth.Results;
using Puteshestvenici.Models;
using Puteshestvenici.ServicesWithCustomAuth.Models;

namespace Puteshesetvenici.ServicesWithCustomAuth.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private const int TokenExpirationDays = 3;

        private AuthRepository repository;

        public AccountController()
            : this(new AuthRepository())
        {
        }

        public AccountController(AuthRepository repository)
        {
            this.repository = repository;
        }

        private IAuthenticationManager Authentication
        {
            get
            {
                return Request.GetOwinContext().Authentication;
            }
        }

        [AllowAnonymous]
        [Route("Register")]
        [HttpPost]
        public async Task<IHttpActionResult> Register(UserModel registerModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await this.repository.RegisterUser(registerModel);
            var errorResult = this.GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }

        //TODO: External login
        [OverrideAuthentication]
        [HostAuthentication(DefaultAuthenticationTypes.ExternalCookie)]
        [AllowAnonymous]
        [Route("ExternalLogin", Name = "ExternalLogin")]
        public async Task<IHttpActionResult> GetExternalLogin(string provider, string error = null)
        {
            string redirectUri = string.Empty;

            if (error != null)
            {
                return BadRequest(Uri.EscapeDataString(error));
            }

            if (!User.Identity.IsAuthenticated)
            {
                return new ChallengeResult(provider, this);
            }

            var redirectUriValidationResult = ValidateRedirectUri(this.Request, ref redirectUri);

            if (!string.IsNullOrWhiteSpace(redirectUriValidationResult))
            {
                return BadRequest(redirectUriValidationResult);
            }

            var externalLogin = ExternalLoginData.FromIdentity(User.Identity as ClaimsIdentity);

            if (externalLogin == null)
            {
                return InternalServerError();
            }

            if (externalLogin.LoginProvider != provider)
            {
                this.Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);
                return new ChallengeResult(provider, this);
            }

            var user = await this.repository.FindAsync(new UserLoginInfo(externalLogin.LoginProvider, externalLogin.ProviderKey));

            bool isRegistered = user != null;

            redirectUri = string.Format("{0}#external_access_token={1}&provider={2}&haslocalaccount={3}&external_user_name={4}",
                redirectUri,
                externalLogin.ExternalAccessToken,
                externalLogin.LoginProvider,
                isRegistered.ToString(),
                externalLogin.Username);

            return Redirect(redirectUri);
        }

        [AllowAnonymous]
        [Route("RegisterExternal")]
        public async Task<IHttpActionResult> RegisterExternal(RegisterExternalBindingModel registerModel)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var verifiecAccessToken = await this.VerifyExternalAccessToken(registerModel.Provider, registerModel.ExternalAccessToken);
            if (verifiecAccessToken == null)
            {
                return BadRequest("Invalid provider or external access token");
            }

            var user = await this.repository.FindAsync(new UserLoginInfo(
                registerModel.Provider,
                verifiecAccessToken.user_id));

            bool isRegistered = user != null;

            if (isRegistered)
            {
                return BadRequest("External user is already registered");
            }

            user = new ApplicationUser()
            {
                UserName = registerModel.Username
            };

            var result = await this.repository.CreateAsync(user);
            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            var info = new ExternalLoginInfo()
            {
                DefaultUserName = registerModel.Username,
                Login = new UserLoginInfo(registerModel.Provider, verifiecAccessToken.user_id)
            };

            result = await this.repository.AddLoginAsync(user.Id, info.Login);
            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            var accessTokenResult = GenerateLocalAccessTokenResponse(registerModel.Username);

            return Ok(accessTokenResult);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("ObtainLocalAccessToken")]
        public async Task<IHttpActionResult> ObtainLocalAccessToken(string provider, string externalAccessToken)
        {
            if (string.IsNullOrWhiteSpace(provider) || string.IsNullOrWhiteSpace(externalAccessToken))
            {
                return BadRequest("Provider or external access token is not sent");
            }

            var verifyAccessToken = await VerifyExternalAccessToken(provider, externalAccessToken);
            if (verifyAccessToken == null)
            {
                return BadRequest("Invalid provider or external access token");
            }

            var userLoginInfo = new UserLoginInfo(provider, verifyAccessToken.user_id);

            var user = await this.repository.FindAsync(userLoginInfo);
            bool isRegistered = user != null;

            if (!isRegistered)
            {
                return BadRequest("External user is not registered.");
            }

            var accessTokenResponse = GenerateLocalAccessTokenResponse(user.UserName);
            return Ok(accessTokenResponse);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.repository.Dispose();
            }

            base.Dispose(disposing);
        }

        private async Task<ParsedExternalAccessToken> VerifyExternalAccessToken(string provider, string accessToken)
        {
            ParsedExternalAccessToken parsedToken = null;

            var verifyTokenEndPoint = "";

            if (provider == "Facebook")
            {
                var appToken = "1487705754840266|DazWSPoZxsEWAPiHNhnWN0kyS_g";
                verifyTokenEndPoint = string.Format("https://graph.facebook.com/debug_token?input_token={0}&access_token={1}", accessToken, appToken);
            }
            else if (provider == "Google")
            {
                verifyTokenEndPoint = string.Format("https://www.googleapis.com/oauth2/v1/tokeninfo?access_token={0}", accessToken);
            }
            else
            {
                return null;
            }

            var client = new HttpClient();
            var uri = new Uri(verifyTokenEndPoint);
            var response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var jsonContent = (JObject)JsonConvert.DeserializeObject(content);
                parsedToken = new ParsedExternalAccessToken();

                if (provider == "Facebook")
                {
                    parsedToken.user_id = jsonContent["data"]["user_id"].ToString();
                    parsedToken.app_id = jsonContent["data"]["app_id"].ToString();
                }

                if (!string.Equals(Startup.FacebookAuthOptions.AppId, parsedToken.app_id, StringComparison.OrdinalIgnoreCase))
                {
                    return null;
                }
                else if (provider == "Google")
                {
                    parsedToken.user_id = jsonContent["user_id"].ToString();
                    parsedToken.app_id = jsonContent["audience"].ToString();

                    if (!string.Equals(Startup.GoogleAuthOptions.ClientId, parsedToken.app_id, StringComparison.OrdinalIgnoreCase))
                    {
                        return null;
                    }
                }
            }

            return parsedToken;
        }

        private JObject GenerateLocalAccessTokenResponse(string username)
        {
            var tokenExpiration = TimeSpan.FromDays(TokenExpirationDays);
            var identity = new ClaimsIdentity(OAuthDefaults.AuthenticationType);

            identity.AddClaim(new Claim(ClaimTypes.Name, username));
            identity.AddClaim(new Claim("role", "user"));

            var authenticationProperties = new AuthenticationProperties()
            {
                IssuedUtc = DateTime.UtcNow,
                ExpiresUtc = DateTime.UtcNow.Add(tokenExpiration)
            };

            var ticket = new AuthenticationTicket(identity, authenticationProperties);

            var accessToken = Startup.OAuthBearerOptions.AccessTokenFormat.Protect(ticket);

            var tokenResponse = new JObject(
                new JProperty("userName", username),
                new JProperty("access_token", accessToken),
                new JProperty("token_type", "bearer"),
                new JProperty("expires_in", tokenExpiration.TotalSeconds.ToString()),
                new JProperty(".issued", ticket.Properties.IssuedUtc.ToString()),
                new JProperty(".expires", ticket.Properties.ExpiresUtc.ToString()));
            
            return tokenResponse;
        }

        private string ValidateRedirectUri(HttpRequestMessage request, ref string redirectUriOutput)
        {
            Uri redirectUri;
            var redirectUriString = this.GetQueryString(request, "redirect_uri");

            bool validUri = Uri.TryCreate(redirectUriString, UriKind.Absolute, out redirectUri);

            if (!validUri)
            {
                return "redirect_uri is invalid";
            }

            redirectUriOutput = redirectUri.AbsolutePath;
            return string.Empty;
        }

        private string GetQueryString(HttpRequestMessage request, string key)
        {
            var queryString = request.GetQueryNameValuePairs();
            if (queryString == null)
            {
                return null;
            }

            var match = queryString.FirstOrDefault(keyValue => string.Compare(keyValue.Key, key, true) == 0);

            if (string.IsNullOrWhiteSpace(match.Value))
            {
                return null;
            }

            return match.Value;
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
