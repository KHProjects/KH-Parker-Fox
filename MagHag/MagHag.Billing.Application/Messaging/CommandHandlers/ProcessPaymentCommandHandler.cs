using MagHag.Billing.Messaging.Events;
using MagHag.Core.Messaging.Commands;
using NServiceBus;
using System;

namespace MagHag.Billing.Application.Messaging.CommandHandlers
{
    public class ProcessPaymentCommandHandler : IHandleMessages<ProcessPayment>
    {
        private readonly IBus _bus;

        public ProcessPaymentCommandHandler(IBus bus)
        {
            _bus = bus;
        }

        public void Handle(ProcessPayment message)
        {
            _bus.Publish(new PaymentProcessedEvent { SubscriptionId = Guid.NewGuid() });
        }
    }
}
