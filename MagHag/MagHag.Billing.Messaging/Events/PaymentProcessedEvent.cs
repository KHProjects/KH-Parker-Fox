namespace MagHag.Billing.Messaging.Events
{
    public class PaymentProcessedEvent
    {
        public int SubscriptionId { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
    }
}
