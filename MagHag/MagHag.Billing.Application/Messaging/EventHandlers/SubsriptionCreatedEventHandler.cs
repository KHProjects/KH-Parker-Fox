using MagHag.Subscriptions.Messaging.Events;
using NServiceBus;
using System;

namespace MagHag.Billing.Application.Messaging.EventHandlers
{
    public class SubsriptionCreatedEventHandler : IHandleMessages<SubscriptionCreated>
    {
        public void Handle(SubscriptionCreated message)
        {
            Console.WriteLine(message.StringEncrypted);
            Console.WriteLine("<Billing>SubsriptionCreatedEventHandler");
        }
    }
}
