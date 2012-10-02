using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using ParkerFox.Application.CommandHandlers.Publication;
using ParkerFox.Application.Commands.Publication;
using ParkerFox.Application.EventHandlers.Publication;
using ParkerFox.Application.Events.Magazine;
using ParkerFox.Infrastructure.Messaging.Commands;
using ParkerFox.Infrastructure.Messaging.Events;
using ParkerFox.Application.CommandResponses.Publication;

namespace ParkerFox.Application.Messaging
{
    public class MessagingNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IHandleCommand<CreateNewSubscription, CreateNewSubscriptionResponse>>().To<CreateNewSubscriptionHandler>();

            Bind<IRespondToEvent<NewSubscriptionCreated>>().To<SendWelcomeEmailForNewSubscription>();
        }
    }
}
