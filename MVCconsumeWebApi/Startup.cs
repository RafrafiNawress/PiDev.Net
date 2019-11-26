using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCconsumeWebApi.Startup))]
namespace MVCconsumeWebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
