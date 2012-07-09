﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using ParkerFox.Application.CommandHandlers.Magazine;
using ParkerFox.Application.Commands.Magazine;
using ParkerFox.Application.EventHandlers.Magazine;
using ParkerFox.Application.Events.Magazine;
using ParkerFox.Infrastructure.Messaging.Commands;
using ParkerFox.Infrastructure.Messaging.Events;

namespace ParkerFox.Application.Messaging
{
    public class MessagingNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IHandleCommand<CreateNewSubscription>>().To<CreateNewSubscriptionHandler>();

            Bind<IRespondToEvent<NewSubscriptionCreated>>().To<SendWelcomeEmailForNewSubscription>();
        }
    }
}