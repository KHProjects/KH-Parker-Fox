using MagHag.Core;
using System;

namespace MagHag.Subscriptions.Core.Entities
{
    public class SubscriptionTerm
    {
        public int Quantity { get; private set; }
        public DatePart Part { get; private set; }

        public SubscriptionTerm(DatePart part, int quantity)
        {
            Quantity = quantity;
            Part = part;
        }

        public DateTime EndDate()
        {
            switch (Part)
            {
                case DatePart.Day:
                    return SystemTime.Now().AddDays(Quantity);
                    break;
                case DatePart.Month:
                    return SystemTime.Now().AddMonths(Quantity);
                    break;
                case DatePart.Year:
                    return SystemTime.Now().AddYears(Quantity);
                    break;
                default:
                    return SystemTime.Now();
            }
        }
    }
}
