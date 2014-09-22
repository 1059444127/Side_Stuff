using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIExternalLoginTest.Infrastructure
{
    public interface IUserIDProvider
    {
        string GetUserID();
    }
}