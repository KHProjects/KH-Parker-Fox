using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQRS_ES.Models
{
    public class AccountRegisteredEvent
    {
        public Guid AccountId { get; set; }
        public decimal Balance { get; set; }

        public AccountRegisteredEvent(Guid accountId, decimal balance)
        {
            AccountId = accountId;
            Balance = balance;
        }

        public override string ToString()
        {
            return String.Format("Account with id {0} registered", AccountId);
        }
    }
}