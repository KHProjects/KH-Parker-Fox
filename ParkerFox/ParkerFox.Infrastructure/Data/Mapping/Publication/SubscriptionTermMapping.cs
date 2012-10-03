using System;
using FluentNHibernate.Mapping;
using ParkerFox.Core.Entities.Publication;

namespace ParkerFox.Infrastructure.Data.Mapping.Magazine
{
    public class SubscriptionTermMapping : ClassMap<SubscriptionTerm>
    {
        public SubscriptionTermMapping()
        {
            Id(x => x.SubscriptionTermId).GeneratedBy.Identity();
            //Map(x => x.SubscriptionId);
            Map(x => x.StartDate);
           // HasOne(x => x.Subscription).ForeignKey("SubscriptionId");

            References(x => x.Subscription).Column("SubscriptionId");//.Cascade.All();
           // Map(x => x.Type).CustomType<SubscriptionPaymentTypes>().Column("SubscriptionTermTypeId");
            Table("[Magazine.SubscriptionTerm]");
        }
    }
}
