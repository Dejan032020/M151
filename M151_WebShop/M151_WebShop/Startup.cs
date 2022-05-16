using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(M151_WebShop.Startup))]
namespace M151_WebShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
