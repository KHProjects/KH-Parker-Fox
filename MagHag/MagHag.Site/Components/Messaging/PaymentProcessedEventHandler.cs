using MagHag.Billing.Messaging.Events;
using Microsoft.AspNet.SignalR;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagHag.Site.Components.Messaging
{
    //should we seperate the hub and the handler?
    public class PaymentProcessedEventHandler : Hub, IHandleMessages<PaymentProcessedEvent>
    {
        public void Handle(PaymentProcessedEvent @event)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<PaymentProcessedEventHandler>();
            hubContext.Clients.All.paymentProcessed(@event); 
        }
    }
}