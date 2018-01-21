using Owin;
using Microsoft.AspNet.SignalR;

namespace Chat.Web
{
    public partial class Startup
    {
        public void ConfigureSignalR(IAppBuilder app)
        {
            // register a function to create hub instances and use this function to perform DI
            // because SignalR expects a hub class to have a parameterless constructor
            GlobalHost.DependencyResolver.Register(
                typeof(ChatHub),
                () => new ChatHub(repository: new Controllers.MessagesController()));

            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
}