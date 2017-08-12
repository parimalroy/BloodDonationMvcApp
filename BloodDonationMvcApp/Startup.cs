using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BloodDonationMvcApp.Startup))]
namespace BloodDonationMvcApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
