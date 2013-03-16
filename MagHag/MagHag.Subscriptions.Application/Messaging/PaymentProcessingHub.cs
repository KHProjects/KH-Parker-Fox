using MagHag.Application.Messaging;
using MagHag.Billing.Messaging.Events;
using Microsoft.AspNet.SignalR;


namespace MagHag.Subscriptions.Application.Messaging
{
    public class PaymentProcessingHub : Hub, INotifyClientEvent<PaymentProcessedEvent>
    {
        public void Notify(PaymentProcessedEvent @event)
        {
            Clients.Caller.paymentProcessed(@event);
        }
    }
}
