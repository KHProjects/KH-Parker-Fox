using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagHag.Core.Messaging.EventSourcing;

namespace MagHag.Core.Messaging.Events
{
    public class AccountCreated : IEvent
    {
        public AccountCreated(Guid id, string email)
        {
            Id = id;
            Email = email;
        }
        public Guid Id { get; set; }
        public string Email { get; set; }
    }
}
