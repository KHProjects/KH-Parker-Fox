using MagHag.Core.Entities;
using MagHag.Core.Messaging;
using MagHag.Core.Messaging.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagHag.Application.Messaging.CommandHandlers
{
    public sealed class CreateAccountHandler : IHandleCommand<CreateAccount>
    {
        private readonly IBus _bus;
        private readonly IRepository _repository;

        public CreateAccountHandler(IBus bus, IRepository repository)
        {
            _bus = bus;
            _repository = repository;
        }

        public void Handle(CreateAccount command)
        {
            var account = new Account(Guid.NewGuid(), command.Email);
            var events = account.GetUncommittedChanges();
            _repository.Save(account);
            //_bus.Publish(events.First());
        }
    }
}
