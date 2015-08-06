using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IoC_MVC_Application.Startup))]
namespace IoC_MVC_Application
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
