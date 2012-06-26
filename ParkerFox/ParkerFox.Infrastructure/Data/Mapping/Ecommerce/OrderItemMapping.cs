using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using ParkerFox.Core.Entities.Ecommerce;

namespace ParkerFox.Infrastructure.Data.Mapping.Ecommerce
{
    public class OrderItemMapping : ClassMap<OrderItem>
    {
        public OrderItemMapping()
        {
            Id(x => x.OrderItemId).GeneratedBy.Native();            
            Map(x => x.Quantity);
            //References<Order>(x => x.Order).Column("OrderId");
        }
    }
}
