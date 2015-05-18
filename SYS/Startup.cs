using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SYS.Startup))]
namespace SYS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
