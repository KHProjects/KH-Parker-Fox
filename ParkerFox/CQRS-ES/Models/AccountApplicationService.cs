using CQRS_ES.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQRS_ES.Models
{
    public class AccountApplicationService
    {
        private readonly IRepository _repository;

        public AccountApplicationService(IRepository repository)
        {
            _repository = repository;
        }

        public void Handle(RegisterAccountCommand registerAccountCommand)
        {
            var account = new Account(registerAccountCommand.AccountId, registerAccountCommand.Name,
                                      registerAccountCommand.Balance);
            _repository.Save(account);
        }
    }
}