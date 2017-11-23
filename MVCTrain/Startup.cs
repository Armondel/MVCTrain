using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCTrain.Startup))]
namespace MVCTrain
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
