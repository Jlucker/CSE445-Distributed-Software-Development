using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Assignment5WebApp.Startup))]
namespace Assignment5WebApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
