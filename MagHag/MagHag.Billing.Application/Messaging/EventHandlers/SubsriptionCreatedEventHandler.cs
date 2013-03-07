using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagHag.Subscriptions.Messaging;
using MagHag.Subscriptions.Messaging.Commands;
using NServiceBus;

namespace MagHag.Billing.Application.Messaging.EventHandlers
{
    public class SubsriptionCreatedEventHandler : IHandleMessages<SubscriptionCreated>
    {
        public void Handle(SubscriptionCreated message)
        {

            Console.WriteLine(message.StringEncrypted);
            Console.WriteLine("<Billing>SubsriptionCreatedEventHandler");
        }
    }
}
