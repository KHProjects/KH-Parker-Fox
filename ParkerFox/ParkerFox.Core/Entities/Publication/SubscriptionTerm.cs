using System;

namespace ParkerFox.Core.Entities.Publication
{
    public class SubscriptionTerm
    {
        public SubscriptionTerm()
        {
            
        }
        protected SubscriptionTerm(SubscriptionPaymentTypes paymentType, TimePeriod period)
        {
            _paymentType = paymentType;
            _period = period;
        }

        public virtual Subscription Subscription { get; internal protected set; }

        private int _subscriptionTermId;
        private DateTime? _startDate;
        private SubscriptionPaymentTypes _paymentType;
        private TimePeriod _period;

        public virtual DateTime? GetEndDate()
        {
            return _period.GetExtent(_startDate.Value);
        }

        public virtual void Activate()
        {
            _startDate = DateTime.Now;
        }

        public virtual bool IsActive()
        {
            if (_startDate.HasValue)
            {
                DateTime extend = _period.GetExtent(_startDate.Value);
                return extend > SystemTime.Now();
            }
            return false;
        }

        public static SubscriptionTerm CreateNew(SubscriptionPaymentTypes paymentType, TimePeriod period)
        {
            return new SubscriptionTerm(paymentType, period);
        }
    }
}
