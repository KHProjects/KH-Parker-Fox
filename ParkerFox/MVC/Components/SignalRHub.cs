using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Hubs;

namespace MVC.Components
{
    /// <summary>
    /// http://www.tugberkugurlu.com/archive/mapping-asp-net-signalr-connections-to-real-application-users
    /// </summary>
    public class SignalRHub : Hub
    {
        private Dictionary<string, string> _clientMessages = new Dictionary<string, string>();

        public SignalRHub()
        {
            
        }

        public void DoSomething()
        {
            Clients.All.receiveData(new { FirstName = "Seb" });
        }

        public void SendAMessage(string message)
        {
            Clients.All.messageFromServer("a client sent: " + message);
        }

        public void SetupEcho(string echo)
        {
            

        }

        public override Task OnConnected()
        {
            lock (_clientMessages)
            {
                if (!_clientMessages.ContainsKey(Context.ConnectionId))
                {
                    _clientMessages.Add(Context.ConnectionId, "default message");
                }
            }
            return base.OnConnected();
        }

        public override Task OnDisconnected()
        {
            lock (_clientMessages)
            {
                if (_clientMessages.ContainsKey(Context.ConnectionId))
                {
                    _clientMessages.Remove(Context.ConnectionId);
                }
            }
            return base.OnDisconnected();
        }

        public override Task OnReconnected()
        {
            return base.OnReconnected();
        }
    }
}