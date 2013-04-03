using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagHag.ReadStore.Representations;
using NServiceBus;
using MagHag.Subscriptions.Messaging.Events;

namespace MagHag.ReadStore.Messaging.EventHandlers
{
    public class PublicationCreatedEventHandler : IHandleMessages<PublicationCreated>
    {
        
        public void Handle(PublicationCreated publicationCreated)
        {
            
        }
    }
}
