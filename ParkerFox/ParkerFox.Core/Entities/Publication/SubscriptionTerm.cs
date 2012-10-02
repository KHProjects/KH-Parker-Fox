using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.Core.Entities.Publication
{
    public class SubscriptionTerm
    {
        public virtual int SubscriptionTermId { get; set; }
        public virtual int SubscriptionId { get; set; }
        public virtual DateTime? StartDate { get; set; }
        public virtual Subscription Subscription { get; set; }
        //public virtual SubscriptionPaymentTypes Type { get; set; }
        //public virtual TimePeriod Term { get; set; }

        public virtual DateTime? GetEndDate()
        {
            if (StartDate == null)
                return StartDate;

            return null;
        }
    }
}
