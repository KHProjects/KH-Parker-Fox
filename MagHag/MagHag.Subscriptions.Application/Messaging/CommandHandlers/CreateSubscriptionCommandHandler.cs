using MagHag.Core.Entities;
using MagHag.Subscriptions.Core.Commands;
using MagHag.Subscriptions.Core.Entities;
using MagHag.Subscriptions.Messaging.Events;
using NServiceBus;
using System;

namespace MagHag.Subscriptions.Application.Messaging.CommandHandlers
{
    public class CreateSubscriptionCommandHandler : IHandleMessages<CreateSubscriptionCommand>
    {
        private readonly IBus _bus;
        private readonly IRepository _repository;

        public CreateSubscriptionCommandHandler(IBus bus, IRepository repository)
        {
            _bus = bus;
            _repository = repository;
        }

        public void Handle(CreateSubscriptionCommand message)
        {
            Console.WriteLine("<Subscriptions>CreateSubscriptionCommandHandler");

            var subscription = new Subscription(Guid.NewGuid());
            _repository.Save(subscription);

            _bus.Publish(new SubscriptionCreated());
        }
    }
}
