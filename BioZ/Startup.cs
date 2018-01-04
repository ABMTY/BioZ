using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BioZ.Startup))]
namespace BioZ
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
