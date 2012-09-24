using FluentNHibernate.Mapping;
using ParkerFox.Core.Entities.Ecommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.Infrastructure.Data.Mapping.Ecommerce
{
    public class CartItemMapping : ClassMap<CartItem>
    {
        public CartItemMapping()
        {
            Id(x => x.Identifier);
            Map(x => x.ProductId);
            Map(x => x.Quantity);
        }
    }
}
