using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Puteshesetvenici.ServicesWithCustomAuth.Models
{
    public class ExternalLoginData
    {
        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }

        public string Username { get; set; }

        public string ExternalAccessToken { get; set; }

        public static ExternalLoginData FromIdentity(ClaimsIdentity identity)
        {
            if (identity == null)
            {
                return null;
            }

            var providerKeyClaim = identity.FindFirst(ClaimTypes.NameIdentifier);

            if (providerKeyClaim == null || 
                string.IsNullOrWhiteSpace(providerKeyClaim.Issuer) ||
                string.IsNullOrWhiteSpace(providerKeyClaim.Value))
            {
                return null;
            }

            if (providerKeyClaim.Issuer == ClaimsIdentity.DefaultIssuer)
            {
                return null;
            }

            var username = identity.FindFirst(ClaimTypes.Name).Value;
            var externalAccessToken = identity.FindFirst("ExternalAccessToken").Value;

            return new ExternalLoginData()
            {
                LoginProvider = providerKeyClaim.Issuer,
                ProviderKey = providerKeyClaim.Value,
                Username = identity.FindFirst(ClaimTypes.Name).Value,
                ExternalAccessToken = identity.FindFirst("ExternalAccessToken").Value
            };
        }
    }
}