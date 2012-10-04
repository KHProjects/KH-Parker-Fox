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
            Map(x => x.StartDate);
            Map(x => x.PaymentType).CustomType<int>().Column("SubscriptionPaymentTypeId");

            Component(x => x.Term, time =>
                {
                    time.Map(x => x.Quantity).Column("TimePeriodQuantity");
                    time.Map(x => x.Interval).CustomType<int>().Column("TimePeriodUnit");
                });

            References(x => x.Subscription).Column("SubscriptionId");
            Table("[Magazine.SubscriptionTerm]");
        }
    }
}
