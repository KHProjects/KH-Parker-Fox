using CQRS_ES.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQRS_ES.Models
{
    public class Configuration
    {
        private readonly MessageBus _bus;
        private AccountInfoProjection _accountInfoProjection;

        public MessageBus Bus { get { return _bus; } }
        public IEnumerable<AccountInfo> Accounts {
            get { return _accountInfoProjection.AccountInfos; }
        }

        public static Configuration Instance { get { return instance; } }


        private static readonly Configuration instance = new Configuration();
        private Configuration()
        {
            _bus = new MessageBus();
            var eventStore = new SqlEventStore(_bus);
            var repository = new DomainRepository(eventStore);

            var commandService = new AccountApplicationService(repository);
            _bus.RegisterHandler<RegisterAccountCommand>(commandService.Handle);

            _accountInfoProjection = new AccountInfoProjection();
            _bus.RegisterHandler<AccountRegisteredEvent>(_accountInfoProjection.Handle);

            var events = eventStore.GetAllEventsEver();
            _bus.Publish(events);
        } 
    }
}