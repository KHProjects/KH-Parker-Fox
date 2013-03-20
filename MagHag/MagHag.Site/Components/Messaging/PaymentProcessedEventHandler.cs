using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MagHag.Billing.Messaging.Events;
using NServiceBus;

namespace MagHag.Site.Components.Messaging
{
    public class PaymentProcessedEventHandler : IHandleMessages<PaymentProcessedEvent>
    {
        public void Handle(PaymentProcessedEvent message)
        {
            bool pass = true;
        }
    }
}