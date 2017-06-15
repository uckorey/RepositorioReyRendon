using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MushroomgamesOrd.Startup))]
namespace MushroomgamesOrd
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
