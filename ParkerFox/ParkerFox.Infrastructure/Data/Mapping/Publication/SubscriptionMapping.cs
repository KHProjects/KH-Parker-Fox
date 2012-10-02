﻿
using FluentNHibernate.Mapping;
using ParkerFox.Core.Entities.Publication;

namespace ParkerFox.Infrastructure.Data.Mapping.Publication
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