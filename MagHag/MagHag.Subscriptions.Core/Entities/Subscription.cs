using MagHag.Core.Entities;
using MagHag.Subscriptions.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagHag.Subscriptions.Core.Entities
{
    public class Subscription : Aggregate
    {
        public Subscription(Guid subscriptionId)
        {
            Apply(new SubscriptionCreated(subscriptionId));
        }

        public void ApplyEvent(SubscriptionCreated subscriptionCreated)
        {
            Id = subscriptionCreated.SubscriptionId;
        }
    }
}
