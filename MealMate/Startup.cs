using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MealMate.Startup))]
namespace MealMate
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
