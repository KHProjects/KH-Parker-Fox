using MagHag.Core.Messaging.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagHag.Core.Entities
{
    public class Account : Aggregate
    {
        private string _email;

        public Account(Guid id, string email)
        {
            Apply(new AccountCreated(id, email));
        }

        public void ApplyEvent(AccountCreated accountCreated)
        {
            Id = accountCreated.Id;
            _email = accountCreated.Email;
        }
    }
}
