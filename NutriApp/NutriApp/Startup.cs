using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NutriApp.Startup))]
namespace NutriApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
