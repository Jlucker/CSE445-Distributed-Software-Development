using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TemperatureWebApp.Startup))]
namespace TemperatureWebApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
