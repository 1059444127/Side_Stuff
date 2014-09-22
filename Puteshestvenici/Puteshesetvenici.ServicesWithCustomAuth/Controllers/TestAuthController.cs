using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Puteshesetvenici.ServicesWithCustomAuth.Controllers
{
    [Authorize]
    public class TestAuthController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Test()
        {
            string success = "Success!";
            return Ok(success);
        }
    }
}
