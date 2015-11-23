using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SGU_C2CStore.Services.Startup))]
namespace SGU_C2CStore.Services
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
