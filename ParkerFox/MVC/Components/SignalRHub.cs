using System.Collections.Generic;

using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Hubs;
using System.Diagnostics;
using System;
using System.Timers;
using Microsoft.AspNet.SignalR;

namespace MVC.Components
{
    /// <summary>
    /// http://www.tugberkugurlu.com/archive/mapping-asp-net-signalr-connections-to-real-application-users
    /// </summary>
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

        public void SetupEcho(string echo)
        {
            EchoManager.Instance.SetMessage(Context.ConnectionId, echo);
        }

        public override Task OnConnected()
        {
            EchoManager.Instance.Register(Context.ConnectionId);
            return base.OnConnected();
        }

        public override Task OnDisconnected()
        {
            EchoManager.Instance.Remove(Context.ConnectionId);
            return base.OnDisconnected();
        }

        public override Task OnReconnected()
        {
            return base.OnReconnected();
        }
    }

    public class EchoManager
    {
        private Dictionary<string, string> _clientMessages = new Dictionary<string, string>();
        private static Timer echoTimer = new Timer();

        public static EchoManager Instance = new EchoManager();

        public EchoManager()
        {
            echoTimer.Interval = 2000;
            echoTimer.Elapsed += (sender, args) => SendOutEchos();
            echoTimer.Start();
        }

        public void Register(string connectionId)
        {
            lock (_clientMessages)
            {
                if (!_clientMessages.ContainsKey(connectionId))
                {
                    _clientMessages.Add(connectionId, "default message");
                }
            }
        }

        public void Remove(string connectionId)
        {
            lock (_clientMessages)
            {
                if (_clientMessages.ContainsKey(connectionId))
                {
                    _clientMessages.Remove(connectionId);
                }
            }
        }

        public void SetMessage(string connectionId, string message)
        {
            lock (_clientMessages)
            {
                if (_clientMessages.ContainsKey(connectionId))
                    _clientMessages[connectionId] = message;
                else
                    _clientMessages.Add(connectionId, message);
            }
        }

        private void SendOutEchos()
        {
            var hub = GlobalHost.ConnectionManager.GetHubContext<SignalRHub>();
            foreach (KeyValuePair<string, string> keyValuePair in _clientMessages)
            {
                hub.Clients.Client(keyValuePair.Key).messageFromServer(keyValuePair.Value + " (from " + keyValuePair.Key + " @ " + DateTime.Now.ToLongTimeString() + " )");
            }
        }

    }
}