using System;
namespace MagHag.Billing.Messaging.Events
{
    public class PaymentProcessedEvent
    {
        public Guid SubscriptionId { get; set; }
        public Guid PaymentId { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
    }
}
