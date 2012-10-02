using System;
using System.Collections.Generic;

namespace ParkerFox.Core.Entities.Publication
{
    public class Subscription
    {
        public virtual int SubscriptionId { get; set; }
        public virtual DateTime? StartDate { get; set; }
        public virtual IList<SubscriptionTerm> Terms { get; set; }

        public virtual DateTime? GetExpirationDate()
        {
            DateTime? expirationDate = null;

            return expirationDate;
        }
    }
}
