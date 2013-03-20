using MagHag.Core.Messaging.EventSourcing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagHag.Subscriptions.Core.Events
{
    //this is the internal event, we need to distinguich from the x-context event... or do we
    public class SubscriptionCreated : IEvent
    {
        public SubscriptionCreated(Guid subscriptionId)
        {
            SubscriptionId = subscriptionId;
        }
        public Guid SubscriptionId { get; private set; }
    }
}
