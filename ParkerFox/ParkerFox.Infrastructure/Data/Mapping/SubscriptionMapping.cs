using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate;
using FluentNHibernate.Mapping;
using ParkerFox.Core.Entities.Magazine;

namespace ParkerFox.Infrastructure.Data.Mapping
{
    public class SubscriptionMapping : ClassMap<Subscription>
    {
        public SubscriptionMapping()
        {
            Id(Reveal.Member<Subscription>("SubscriptionId")).GeneratedBy.Native();
            Map(Reveal.Member<Subscription>("Name"));
            Map(Reveal.Member<Subscription>("StartDate"));
        }
    }
}
