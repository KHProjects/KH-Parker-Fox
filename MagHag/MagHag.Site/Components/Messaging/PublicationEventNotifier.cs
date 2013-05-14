using System.Threading.Tasks;
using MagHag.Subscriptions.Messaging.Events;
using Microsoft.AspNet.SignalR;
using NServiceBus;

namespace MagHag.Site.Components.Messaging
{
    public class PublicationEventNotifier : Hub, IHandleMessages<PublicationCreated>, IHandleMessages<PublicationActivated>
    {
        private readonly IUserConnectionRepository _userConnectionRepository;

        public PublicationEventNotifier(IUserConnectionRepository userConnectionRepository)
        {
            _userConnectionRepository = userConnectionRepository;
        }

        public override Task OnConnected()
        {
            AddConnection();

            return base.OnConnected();
        }

        public override Task OnDisconnected()
        {
            string userName = Context.User.Identity.Name;
            string connectionId = Context.ConnectionId;

            var userConnection = _userConnectionRepository.GetByUserName(userName);

            lock (userConnection.ConnectionIds)
            {
                userConnection.ConnectionIds.Remove(connectionId);
            }
            return base.OnDisconnected();
        }

        public override Task OnReconnected()
        {
            AddConnection();
            return base.OnReconnected();
        }

        public void Handle(PublicationCreated message)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<PublicationEventNotifier>();

            hubContext.Clients.All.publicationCreated(message); 
        }

        public void Handle(PublicationActivated message)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<PublicationEventNotifier>();

            hubContext.Clients.All.publicationActivated(message); 
        }

        private void AddConnection()
        {
            string userName = Context.User.Identity.Name;
            string connectionId = Context.ConnectionId;

            var userConnection = _userConnectionRepository.GetByUserName(userName);

            lock (userConnection.ConnectionIds)
            {
                userConnection.ConnectionIds.Add(connectionId);
            }
        }
    }
}