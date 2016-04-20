using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCDesignmonster.WebUI.Startup))]
namespace MVCDesignmonster.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
