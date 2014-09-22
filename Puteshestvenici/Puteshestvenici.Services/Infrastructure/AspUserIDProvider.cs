using System.Threading;
using Microsoft.AspNet.Identity;

namespace Puteshestvenici.Services.Infrastructure
{
    public class AspUserIDProvider : IUserIDProvider
    {
        public string GetUserID()
        {
            return Thread.CurrentPrincipal.Identity.GetUserId();
        }
    }
}