using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MealMateMVC.Startup))]
namespace MealMateMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
