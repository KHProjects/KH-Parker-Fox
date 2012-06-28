using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate;
using FluentNHibernate.Mapping;
using ParkerFox.Core.Entities.Magazine;

namespace ParkerFox.Infrastructure.Data.Mapping.Magazine
{
    public class SubscriptionMapping : ClassMap<Subscription>
    {
        public SubscriptionMapping()
        {
            Id(x => x.SubscriptionId);
            Map(x => x.StartDate);

            HasMany(x => x.Terms).KeyColumn("SubscriptionId").Not.Inverse().Not.KeyNullable().Cascade.All();

            Table("[Magazine.Subscription]");
        }
    }
}
