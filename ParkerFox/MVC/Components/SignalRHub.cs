using SignalR.Hubs;

namespace MVC.Components
{
    public class SignalRHub : Hub
    {
        public void DoSomething()
        {
            Clients.messageFromServer(new {FirstName = "Seb"});
        }
    }
}