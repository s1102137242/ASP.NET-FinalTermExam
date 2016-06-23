using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPfinal.Startup))]
namespace ASPfinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
