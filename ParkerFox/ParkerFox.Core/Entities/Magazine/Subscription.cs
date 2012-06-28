using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.Core.Entities.Magazine
{
    public class Subscription
    {
        public virtual int SubscriptionId { get; set; }
        public virtual DateTime? StartDate { get; set; }
        public virtual IList<SubscriptionTerm> Terms { get; set; }
    }
}
