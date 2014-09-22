using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Puteshesetvenici.ServicesWithCustomAuth.App_Start;
using Puteshesetvenici.ServicesWithCustomAuth.Models;
using Puteshestvenici.Data;
using Puteshestvenici.Models;

namespace Puteshestvenici.ServicesWithCustomAuth.Models
{
    public class AuthRepository : IDisposable
    {
        private PuteshestveniciDbContext dbContext;
        //private UserManager<IdentityUser> userManager;
        private ApplicationUserManager appUserManager;

        public AuthRepository()
            : this(new PuteshestveniciDbContext())
        {
        }

        public AuthRepository(PuteshestveniciDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.appUserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(this.dbContext));
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            ApplicationUser user = new ApplicationUser()
            {
                UserName = userModel.Username
            };

            user.UserInfo = new User()
            {
                EMail = userModel.EMail,
                Username = userModel.Username,
                UserID = Guid.Parse(user.Id)
            };

            var result = await this.appUserManager.CreateAsync(user, userModel.Password);
            return result;
        }

        public async Task<ApplicationUser> FindUser(string username, string password)
        {
            var user = await this.appUserManager.FindAsync(username, password);

            return user;
        }

        public async Task<ApplicationUser> FindAsync(UserLoginInfo loginInfo)
        {
            var user = await this.appUserManager.FindAsync(loginInfo);
            return user;
        }

        public async Task<IdentityResult> CreateAsync(ApplicationUser user)
        {
            var result = await this.appUserManager.CreateAsync(user);

            return result;
        }

        public async Task<IdentityResult> AddLoginAsync(string userID, UserLoginInfo loginInfo)
        {
            var result = await this.appUserManager.AddLoginAsync(userID, loginInfo);
            return result;
        }

        public void Dispose()
        {
            this.appUserManager.Dispose();
            this.dbContext.Dispose();
        }
    }
}
