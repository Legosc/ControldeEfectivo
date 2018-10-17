using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MascoticasTienda.Startup))]
namespace MascoticasTienda
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
