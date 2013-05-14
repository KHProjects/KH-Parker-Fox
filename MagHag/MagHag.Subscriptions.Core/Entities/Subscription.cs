using MagHag.Core;
using MagHag.Core.Entities;
using MagHag.Subscriptions.Core.Events;
using System;

namespace MagHag.Subscriptions.Core.Entities
{
    public class Subscription : Aggregate
    {
        private bool _isActive = false;
        private SubscriptionTerm _term;
        private DateTime _activationDate;

        public Subscription(Guid subscriptionId)
        {
            Apply(new SubscriptionCreated(subscriptionId));
        }

        public void Activate()
        {
            if(!_isActive)
                Apply(new SubscriptionActivated());
        }

        private void UpdateFrom(SubscriptionCreated subscriptionCreated)
        {
            Id = subscriptionCreated.SubscriptionId;
        }

        private void UpdateFrom(SubscriptionActivated subscriptionActivated)
        {
            _isActive = true;
            _activationDate = SystemTime.Now();
        }
    }
}
