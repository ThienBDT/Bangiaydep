using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebBanGiayOnline.Startup))]
namespace WebBanGiayOnline
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
