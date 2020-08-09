using BestUniversityEver;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace BestUniversityEver
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // SignalR
            app.MapSignalR();
        }
    }
}
