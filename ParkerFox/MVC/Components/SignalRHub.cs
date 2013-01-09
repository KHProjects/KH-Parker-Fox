using Microsoft.AspNet.SignalR.Hubs;

namespace MVC.Components
{
    public class SignalRHub : Hub
    {
        public void DoSomething()
        {
            Clients.All.receiveData(new { FirstName = "Seb" });
        }

        public void SendAMessage(string message)
        {
            Clients.All.messageFromServer("a client sent: " + message);
        }
    }
}