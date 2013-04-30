using MagHag.Core.Entities;
using MagHag.Subscriptions.Core.Commands;
using MagHag.Subscriptions.Core.Entities;
using MagHag.Subscriptions.Messaging.Events;
using NServiceBus;

namespace MagHag.Subscriptions.Application.Messaging.CommandHandlers
{
    public class CreatePublicationCommandHandler : IHandleMessages<CreatePublicationCommand>
    {
        private IBus _bus;
        private IRepository _repository;

        public CreatePublicationCommandHandler(IBus bus, IRepository repository)
        {
            _bus = bus;
            _repository = repository;
        }

        public void Handle(CreatePublicationCommand message)
        {
            var publication = new Publication(message.Id, message.Title);

            _repository.Save(publication);

            _bus.Publish(new PublicationCreated
                {
                    PublicationId = message.Id,
                    Name = message.Title
                });
        }
    }
}
