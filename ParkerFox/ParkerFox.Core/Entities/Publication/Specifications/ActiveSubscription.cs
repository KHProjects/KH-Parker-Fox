using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkerFox.Core.Specifications;

namespace ParkerFox.Core.Entities.Publication.Specifications
{
    public class ActiveSubscription : Specification<Subscription>
    {
        public ActiveSubscription()
        {
            _specficiation = subscription => subscription.SubscriptionId > 0;
        }
    }
}
