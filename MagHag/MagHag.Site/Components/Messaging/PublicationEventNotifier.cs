using MagHag.Subscriptions.Messaging.Events;
using Microsoft.AspNet.SignalR;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagHag.Site.Components.Messaging
{
    public class PublicationEventNotifier : Hub, IHandleMessages<PublicationCreated>, IHandleMessages<PublicationActivated>
    {
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
    }
}