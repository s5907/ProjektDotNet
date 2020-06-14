using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjektDotNet.Startup))]
namespace ProjektDotNet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
