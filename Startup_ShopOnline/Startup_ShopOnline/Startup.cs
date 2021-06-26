using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Startup_ShopOnline.Startup))]
namespace Startup_ShopOnline
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
