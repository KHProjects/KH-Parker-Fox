using System;

namespace MagHag.Billing.Messaging.Events
{
    public sealed class PaymentAccepted
    {
        public Guid SubscriptionId{ get; set; }
    }
}
