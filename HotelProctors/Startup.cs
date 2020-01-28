using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HotelProctors.Startup))]
namespace HotelProctors
{
    public partial class Startup
    {
        //public void Configuration(IAppBuilder app)
        //{
        //    ConfigureAuth(app);
        //}
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
