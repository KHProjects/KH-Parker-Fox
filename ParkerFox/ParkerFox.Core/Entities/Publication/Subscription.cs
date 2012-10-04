using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ParkerFox.Core.Entities.Publication
{
    public class Subscription
    {
        private IList<SubscriptionTerm> _subscriptionTerms;

        public virtual int SubscriptionId { get; protected set; }
        public virtual DateTime? StartDate { get; protected set; }

        //public virtual IList<SubscriptionTerm> Terms { get; protected set; }
        public virtual IList<SubscriptionTerm> Terms
        {
            get { return new ReadOnlyCollection<SubscriptionTerm>(_subscriptionTerms); } //TODO: is instantiated a readonlycollection here every access wasteful?
            protected set { _subscriptionTerms = value; }
        }

        public Subscription()
        {
            _subscriptionTerms = new List<SubscriptionTerm>();
            StartDate = DateTime.Now;
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
    }
}
