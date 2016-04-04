using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ViaYou.Web.Startup))]
namespace ViaYou.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
