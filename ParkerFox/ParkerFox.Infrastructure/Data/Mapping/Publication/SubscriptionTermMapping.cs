using System;
using FluentNHibernate.Mapping;
using ParkerFox.Core.Entities.Publication;

namespace ParkerFox.Infrastructure.Data.Mapping.Magazine
{
    public class SubscriptionTermMapping : ClassMap<SubscriptionTerm>
    {
        public SubscriptionTermMapping()
        {
            Id(x => x.SubscriptionTermId);
            //Map(x => x.SubscriptionId);
            Map(x => x.StartDate);
           // HasOne(x => x.Subscription).ForeignKey("SubscriptionId");

            //References<Subscription>(x => x.Subscription).Column("SubscriptionId");
           // Map(x => x.Type).CustomType<SubscriptionPaymentTypes>().Column("SubscriptionTermTypeId");
            Table("[Magazine.SubscriptionTerm]");
        }
    }
}
