using System;
using MagHag.Core.Messaging.EventSourcing;

namespace MagHag.Billing.Core.Events
{
    public sealed class PaymentCreated : IEvent
    {
        public PaymentCreated(Guid paymentId)
        {
            PaymentId = paymentId;
        }
        public Guid PaymentId { get; private set; }
    }
}
