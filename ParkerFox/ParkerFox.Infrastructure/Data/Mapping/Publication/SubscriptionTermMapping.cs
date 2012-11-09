using System;
using FluentNHibernate;
using FluentNHibernate.Mapping;
using ParkerFox.Core.Entities.Publication;

namespace ParkerFox.Infrastructure.Data.Mapping.Magazine
{
    /// <summary>
    /// http://devlicio.us/blogs/krzysztof_kozmic/archive/2011/03/20/working-with-nhibernate-without-default-constructors.aspx
    /// </summary>
    public class SubscriptionTermMapping : ClassMap<SubscriptionTerm>
    {
        public SubscriptionTermMapping()
        {
            Id(Reveal.Member<SubscriptionTerm>("_subscriptionTermId"));
            //Map(x => x.StartDate);
            //Map(x => x.PaymentType).CustomType<int>().Column("SubscriptionPaymentTypeId");
            Map(Reveal.Member<SubscriptionTerm>("_startDate")).Column("StartDate");
            Map(Reveal.Member<SubscriptionTerm>("_paymentType")).CustomType<int>().Column("SubscriptionPaymentTypeId");
            Component(Reveal.Member<SubscriptionTerm, TimePeriod>("_period"), x=>
                {
                    x.Map(Reveal.Member<TimePeriod>("_quantity")).Column("TimePeriodQuantity");
                    x.Map(Reveal.Member<TimePeriod>("_interval")).CustomType<int>().Column("TimePeriodUnit");
                });
            //Component(x => x.Term, time =>
            //    {
            //        time.Map(x => x.Quantity).Column("TimePeriodQuantity");
            //        time.Map(x => x.Interval).CustomType<int>().Column("TimePeriodUnit");
            //    });

            References(x => x.Subscription).Column("SubscriptionId");
        }
    }
}
