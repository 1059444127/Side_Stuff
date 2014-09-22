using System.Data.Entity;

using Microsoft.AspNet.Identity.EntityFramework;

using Puteshestvenici.Models;

namespace Puteshestvenici.Services.Models
{
    public class UserInfo : IdentityUser
    {
        public virtual User User { get; set; }
    }

    public class UserInfoDbContext : IdentityDbContext<UserInfo>
    {
        public UserInfoDbContext()
            : base("PuteshestveniciConnection")
        {
        }

        public DbSet<User> MyUserInfo { get; set; }
    }
}