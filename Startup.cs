using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LuckyD.Startup))]
namespace LuckyD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
