using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebTruyen.Startup))]
namespace WebTruyen
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
