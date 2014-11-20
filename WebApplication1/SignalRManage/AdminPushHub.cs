using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Owin;
using Owin;
using WebApplication1.SignalRManage;

[assembly: OwinStartup(typeof(Startup))]
namespace WebApplication1.SignalRManage
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
    [HubName("AdminHub")]
    public class AdminPushHub : Hub
    {
        //public void Notice(string msgStr)
        //{
        //    //Clients.All.addMessage(msgStr);
        //}
    }
}