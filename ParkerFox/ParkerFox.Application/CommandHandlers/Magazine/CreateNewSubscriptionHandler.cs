using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkerFox.Application.Commands.Magazine;
using ParkerFox.Application.Events.Magazine;
using ParkerFox.Core.Messaging;
using ParkerFox.Infrastructure.Messaging;
using ParkerFox.Infrastructure.Messaging.Commands;

namespace ParkerFox.Application.CommandHandlers.Magazine
{
    public class CreateNewSubscriptionHandler : IHandleCommand<CreateNewSubscription>
    {
        private readonly IBus _bus;

        public CreateNewSubscriptionHandler(IBus bus)
        {
            _bus = bus;
        }

        public void Handle(CreateNewSubscription command)
        {
            _bus.Publish(new NewSubscriptionCreated());
        }
    }
}
