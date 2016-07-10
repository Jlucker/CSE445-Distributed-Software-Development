using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Assignment3Part1.Startup))]
namespace Assignment3Part1
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
