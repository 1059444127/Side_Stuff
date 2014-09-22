using System.Threading;
using Microsoft.AspNet.Identity;

namespace WebAPIExternalLoginTest.Infrastructure
{
    public class AspUserIDProvider : IUserIDProvider
    {
        public string GetUserID()
        {
            return Thread.CurrentPrincipal.Identity.GetUserId();
        }
    }
}