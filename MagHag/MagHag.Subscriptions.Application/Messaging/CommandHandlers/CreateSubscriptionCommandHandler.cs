﻿using MagHag.Subscriptions.Core.Commands;
using MagHag.Subscriptions.Messaging.Events;
using NServiceBus;
using System;

namespace MagHag.Subscriptions.Application.Messaging.CommandHandlers
{
    public class CreateSubscriptionCommandHandler : IHandleMessages<CreateSubscriptionCommand>
    {
        private readonly IBus _bus;

        public CreateSubscriptionCommandHandler(IBus bus)
        {
            _bus = bus;
        }

        public void Handle(CreateSubscriptionCommand message)
        {
            Console.WriteLine("<Subscriptions>CreateSubscriptionCommandHandler");

            _bus.Publish(new SubscriptionCreated());
        }
    }
}
