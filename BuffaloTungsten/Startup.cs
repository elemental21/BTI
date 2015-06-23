using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BuffaloTungsten.Startup))]
namespace BuffaloTungsten
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
