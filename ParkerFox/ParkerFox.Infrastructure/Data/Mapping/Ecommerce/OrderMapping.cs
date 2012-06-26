using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace ParkerFox.Infrastructure.Data.Mapping.Ecommerce
{
    public class OrderMapping : ClassMap<ParkerFox.Core.Entities.Ecommerce.Order>
    {
        public OrderMapping()
        {
            Id(x => x.OrderId).GeneratedBy.Native();
            Map(x => x.Created);

            //http://www.nhforge.org/doc/nh/en/index.html#collections-onetomany
            //http://stackoverflow.com/questions/4466153/nhibernate-configuration-for-uni-directional-one-to-many-relation/7601312#7601312
            HasMany(x => x.Items).KeyColumn("OrderId")
                .Not.Inverse()
                .Not.KeyNullable()
                .Cascade.All();
        }
    }
}
