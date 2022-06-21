using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MassCall.Startup))]
namespace MassCall
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
