using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.Core.Entities.Magazine
{
    public class SubscriptionTerm
    {
        public virtual int SubscriptionTermId { get; set; }
        public virtual int SubscriptionId { get; set; }
        public virtual DateTime? StartDate { get; set; }
        public virtual SubscriptionTermTypes Type { get; set; }
    }
}
