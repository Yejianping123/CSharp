using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TempConvWebsite.Startup))]
namespace TempConvWebsite
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
