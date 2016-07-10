using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Assignment4TryIt.Startup))]
namespace Assignment4TryIt
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
