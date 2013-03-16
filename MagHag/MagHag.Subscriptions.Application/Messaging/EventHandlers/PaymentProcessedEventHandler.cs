using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagHag.Billing.Messaging.Events;
using NServiceBus;
using MagHag.Application.Messaging;

namespace MagHag.Subscriptions.Application.Messaging.EventHandlers
{
    public class PaymentProcessedEventHandler : IHandleMessages<PaymentProcessedEvent>
    {
        private readonly INotifyClient _notifyClient;

        public void Handle(PaymentProcessedEvent message)
        {
            Console.Write("<Subscriptions>PaymentProcessed");
            _notifyClient.Notify(message);
        }
    }
}
