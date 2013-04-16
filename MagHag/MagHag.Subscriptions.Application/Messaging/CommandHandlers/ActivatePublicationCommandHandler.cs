using MagHag.Core.Entities;
using MagHag.Subscriptions.Core.Commands;
using MagHag.Subscriptions.Core.Entities;
using MagHag.Subscriptions.Messaging.Events;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagHag.Subscriptions.Application.Messaging.CommandHandlers
{
    public class ActivatePublicationCommandHandler : IHandleMessages<ActivatePublication>
    {
        private IBus _bus;
        private IRepository _repository;

        public ActivatePublicationCommandHandler(IBus bus, IRepository repository)
        {
            _bus = bus;
            _repository = repository;
        }

        public void Handle(ActivatePublication message)
        {
            Publication publication = _repository.GetById<Publication>(message.PublicationId);

            publication.Activate();
            _bus.Publish(new PublicationActivated());
        }
    }
}
