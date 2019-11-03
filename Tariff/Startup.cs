using Microsoft.Owin;
using Owin;
using Tariff;

[assembly: OwinStartup(typeof(Startup))]
namespace Tariff
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
