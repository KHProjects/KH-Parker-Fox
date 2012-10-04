using System;

namespace ParkerFox.Core.Entities.Publication
{
    public class SubscriptionTerm
    {
        public virtual int SubscriptionTermId { get; protected set; }
        public virtual DateTime? StartDate { get; protected set; }
        public virtual Subscription Subscription { get; internal protected set; }
        public virtual SubscriptionPaymentTypes PaymentType { get; set; }
        public virtual TimePeriod Term { get; set; }

        //public virtual DateTime? GetEndDate()
        //{
        //    if (StartDate == null)
        //        return StartDate;

        //    return null;
        //}
    }
}
