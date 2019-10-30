using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ItBlog.Startup))]
namespace ItBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
