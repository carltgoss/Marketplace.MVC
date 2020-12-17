using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Marketplace.MVC.Startup))]
namespace Marketplace.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
