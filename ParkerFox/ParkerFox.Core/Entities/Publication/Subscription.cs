using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ParkerFox.Core.Entities.Publication
{
    public class Subscription
    {
        protected Subscription()
        {
            _subscriptionTerms = new List<SubscriptionTerm>();
            StartDate = DateTime.Now;
        }

        private IList<SubscriptionTerm> _subscriptionTerms;

        protected internal virtual int SubscriptionId { get; set; }

        protected internal virtual DateTime? StartDate { get; set; }

        public virtual IList<SubscriptionTerm> Terms
        {
            get { return new ReadOnlyCollection<SubscriptionTerm>(_subscriptionTerms); } //TODO: is instantiating a readonlycollection here every access wasteful?
            protected set { _subscriptionTerms = value; }
        }

        public virtual void AddTerm(SubscriptionPaymentTypes paymentType, TimePeriod period)
        {
            var subscriptionTerm = SubscriptionTerm.CreateNew(paymentType, period);
            _subscriptionTerms.Add(subscriptionTerm);
        }

        public virtual void AddTerm(SubscriptionTerm subscriptionTerm)
        {
            subscriptionTerm.Subscription = this;
            _subscriptionTerms.Add(subscriptionTerm);
        }

        //public virtual DateTime? GetExpirationDate()
        //{
        //    DateTime? expirationDate = null;

        //    return expirationDate;
        //}

        public static Subscription CreateNew()
        {
            return new Subscription();
        }
    }
}
