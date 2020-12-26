using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Benchmark.MVC.Web.Startup))]
namespace Benchmark.MVC.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
