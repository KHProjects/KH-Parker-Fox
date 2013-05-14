using MagHag.Billing.Messaging.Events;
using NServiceBus;
using MagHag.Core.Entities;
using MagHag.Subscriptions.Core.Entities;

namespace MagHag.Subscriptions.Application.Messaging.EventHandlers
{
    public class PaymentAcceptedEventHandler : IHandleMessages<PaymentAccepted>
    {
        private readonly IRepository _repository;

        public PaymentAcceptedEventHandler(IRepository repository)
        {
            _repository = repository;
        }

        public void Handle(PaymentAccepted message)
        {
            var subscription = _repository.GetById<Subscription>(message.SubscriptionId);

            subscription.Activate();
        }
    }
}
