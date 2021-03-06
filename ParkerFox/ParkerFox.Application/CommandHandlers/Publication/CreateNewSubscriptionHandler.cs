﻿using System;
using System.Collections.Generic;
using ParkerFox.Application.CommandResponses.Publication;
using ParkerFox.Application.Commands.Publication;
using ParkerFox.Core.Entities.Publication;
using ParkerFox.Core.Entities.Repository.Publication;
using ParkerFox.Core.Messaging;
using ParkerFox.Infrastructure.Messaging.Commands;

namespace ParkerFox.Application.CommandHandlers.Publication
{
    public sealed class CreateNewSubscriptionHandler : IHandleCommand<CreateNewSubscription, CreateNewSubscriptionResponse>
    {
        private readonly IBus _bus;
        private readonly ISubscriptionRepository _subscriptionRepository;

        public CreateNewSubscriptionHandler(IBus bus, ISubscriptionRepository subscriptionRepository)
        {
            _bus = bus;
            _subscriptionRepository = subscriptionRepository;
        }

        public CreateNewSubscriptionResponse Handle(CreateNewSubscription command)
        {
            var subscription = Subscription.CreateNew();

            //subscription.AddTerm(new SubscriptionTerm
            //{
            //   PaymentType = SubscriptionPaymentTypes.UpFront,
            //   Term =  new TimePeriod
            //   {
            //       Quantity = 12,
            //       Interval = TimePeriodIntervals.Months
            //   }
            //});

            _subscriptionRepository.Add(subscription);

            return new CreateNewSubscriptionResponse();
        }
    }
}
