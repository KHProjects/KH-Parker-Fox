using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using ParkerFox.Core.Entities.Magazine;

namespace ParkerFox.Infrastructure.Data.Mapping.Magazine
{
    public class SubscriptionTermMapping : ClassMap<SubscriptionTerm>
    {
        public SubscriptionTermMapping()
        {
            Id(x => x.SubscriptionTermId);
            //Map(x => x.SubscriptionId);
            Map(x => x.StartDate);
            Map(x => x.Type).CustomType<SubscriptionPaymentTypes>().Column("SubscriptionTermTypeId");
            Table("[Magazine.SubscriptionTerm]");
        }
    }
}
