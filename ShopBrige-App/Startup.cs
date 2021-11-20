using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShopBrige_App.Startup))]
namespace ShopBrige_App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
