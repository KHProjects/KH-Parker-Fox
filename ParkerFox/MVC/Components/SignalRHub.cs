using Microsoft.AspNet.SignalR.Hubs;

namespace MVC.Components
{
    public class SignalRHub : Hub
    {
        public void DoSomething()
        {
            Clients.All.messageFromServer(new {FirstName = "Seb"});
        }
    }
}