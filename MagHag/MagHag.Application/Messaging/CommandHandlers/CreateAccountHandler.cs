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

        public CreateAccountHandler(IBus bus)
        {
            _bus = bus;
        }

        public void Handle(CreateAccount command)
        {
            Account account = new Account(Guid.NewGuid(), command.Email);
            var events = account.GetUncommittedChanges();
            repository.save(account);

            
        }
    }
}
