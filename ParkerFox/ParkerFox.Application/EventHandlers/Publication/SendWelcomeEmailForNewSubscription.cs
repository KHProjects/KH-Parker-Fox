
using ParkerFox.Application.Events.Magazine;
using ParkerFox.Infrastructure.Messaging.Events;

namespace ParkerFox.Application.EventHandlers.Publication
{
    public class SendWelcomeEmailForNewSubscription : IRespondToEvent<NewSubscriptionCreated>
    {
        public void Raise(NewSubscriptionCreated @event)
        {
            
        }
    }
}
