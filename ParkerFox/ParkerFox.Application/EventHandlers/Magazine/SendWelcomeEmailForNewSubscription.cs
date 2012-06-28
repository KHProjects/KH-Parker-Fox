using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkerFox.Application.Events.Magazine;
using ParkerFox.Infrastructure.Messaging.Events;

namespace ParkerFox.Application.EventHandlers.Magazine
{
    public class SendWelcomeEmailForNewSubscription : IRespondToEvent<NewSubscriptionCreated>
    {
        public void Raise(NewSubscriptionCreated @event)
        {
            
        }
    }
}
