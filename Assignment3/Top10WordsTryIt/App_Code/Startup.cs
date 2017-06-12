using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Top10WordsTryIt.Startup))]
namespace Top10WordsTryIt
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
