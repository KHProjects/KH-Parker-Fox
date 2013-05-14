using MagHag.Billing.Core.Entities;
using MagHag.Billing.Messaging.Events;
using MagHag.Core.Entities;
using MagHag.Core.Messaging.Commands;
using NServiceBus;
using System;

namespace MagHag.Billing.Application.Messaging.CommandHandlers
{
    public class ProcessPaymentCommandHandler : IHandleMessages<ProcessPayment>
    {
        private readonly IBus _bus;
        private readonly IRepository _repository;

        public ProcessPaymentCommandHandler(IBus bus, IRepository repository)
        {
            _bus = bus;
            _repository = repository;
        }

        public void Handle(ProcessPayment message)
        {
            var payment = _repository.GetById<Payment>(message.PaymentId);

            try
            {
                payment.Accept();

                _bus.Publish(new PaymentProcessedEvent {SubscriptionId = Guid.NewGuid()});
            }
            catch (InvalidOperationException ex)
            {
                
            }
        }
    }
}
