using CQRS_ES.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQRS_ES.Models
{
    public class Account : Aggregate
    {
        private decimal _balance;

        public Account(Guid id, string name, decimal balance) : base(id)
        {
            Apply(new AccountRegisteredEvent(id, balance));
        }

        private Account()
        {
        }

        private void UpdateFrom(AccountRegisteredEvent @event)
        {
            Id = @event.AccountId;
        }

    }
}