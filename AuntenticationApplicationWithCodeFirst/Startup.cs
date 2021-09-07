using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AuntenticationApplicationWithCodeFirst.Startup))]
namespace AuntenticationApplicationWithCodeFirst
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
