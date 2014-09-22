using System.Reflection;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using Puteshestvenici.Data;
using WebAPIExternalLoginTest.Infrastructure;

[assembly: OwinStartup(typeof(WebAPIExternalLoginTest.Startup))]

namespace WebAPIExternalLoginTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(GlobalConfiguration.Configuration);
        }

        private StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            RegisterMappings(kernel);
            return kernel;
        }

        private void RegisterMappings(StandardKernel kernel)
        {
            kernel.Bind<IPuteshestveniciData>()
                  .To<PuteshestveniciData>()
                  .WithConstructorArgument("dbContext", c => new PuteshestveniciDbContext());

            kernel.Bind<IUserIDProvider>().To<AspUserIDProvider>();
        }
    }
}
