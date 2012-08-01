using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using ParkerFox.Core.Entities;

namespace ParkerFox.Infrastructure.Data.Mapping.Ecommerce
{
    public class ProductMapping : ClassMap<ParkerFox.Core.Entities.Ecommerce.Product>
    {
        public ProductMapping()
        {
            Not.LazyLoad();
            Table("Product");
            Id(x => x.ProductId).GeneratedBy.Native();
            Map(x => x.Name);
            Map(x => x.UnitPrice);
        }
    }
}
