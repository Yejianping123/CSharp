using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WordFilterTryIt.Startup))]
namespace WordFilterTryIt
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
