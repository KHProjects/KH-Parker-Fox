using MagHag.Billing.Messaging.Events;
using MagHag.Subscriptions.Messaging.Events;
using NServiceBus;
using System;

namespace MagHag.Billing.Application.Messaging.EventHandlers
{
    public class SubsriptionCreatedEventHandler : IHandleMessages<SubscriptionCreated>
    {
        private readonly IBus _bus;

        public SubsriptionCreatedEventHandler(IBus bus)
        {
            _bus = bus;
        }

        public void Handle(SubscriptionCreated message)
        {
            Console.WriteLine("<Billing>SubsriptionCreatedEventHandler");
            _bus.Publish(new PaymentProcessedEvent { SubscriptionId = Guid.NewGuid() });
        }
    }
}
