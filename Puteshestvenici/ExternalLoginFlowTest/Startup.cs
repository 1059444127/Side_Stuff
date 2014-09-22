using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExternalLoginFlowTest.Startup))]
namespace ExternalLoginFlowTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
