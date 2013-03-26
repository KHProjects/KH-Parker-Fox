using MagHag.Subscriptions.Core.Commands;
using MagHag.Subscriptions.Messaging.Events;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagHag.Subscriptions.Application.Messaging.CommandHandlers
{
    public class CreatePublicationCommandHandler : IHandleMessages<CreatePublication>
    {
        private IBus _bus;

        public CreatePublicationCommandHandler(IBus bus)
        {
            _bus = bus;
        }

        public void Handle(CreatePublication message)
        {
            _bus.Publish(new PublicationCreated());
        }
    }
}
