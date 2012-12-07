
using FluentNHibernate;
using FluentNHibernate.Mapping;
using ParkerFox.Core.Entities.Publication;

namespace ParkerFox.Infrastructure.Data.Mapping.Publication
{
    public class SubscriptionMapping : ClassMap<Subscription>
    {
        public SubscriptionMapping()
        {
            Id(Reveal.Member<Subscription>("SubscriptionId"));
            Map(Reveal.Member<Subscription>("StartDate"));

            HasMany(x => x.Terms).Inverse().Cascade.All();
        }
    }
}
