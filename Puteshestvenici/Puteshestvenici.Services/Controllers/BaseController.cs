using System.Web.Http;

using Puteshestvenici.Data;
using Puteshestvenici.Services.Infrastructure;

namespace Puteshestvenici.Services.Controllers
{
    public class BaseController : ApiController
    {
        protected IPuteshestveniciData data;
        protected IUserIDProvider idProvider;

        public BaseController(IPuteshestveniciData data, IUserIDProvider idProvider)
        {
            this.data = data;
            this.idProvider = idProvider;
        }
    }
}
