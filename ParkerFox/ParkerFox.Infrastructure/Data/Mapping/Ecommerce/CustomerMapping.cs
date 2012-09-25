using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkerFox.Core.Entities.Ecommerce;

namespace ParkerFox.Infrastructure.Data.Mapping.Ecommerce
{
    public class CustomerMapping : ClassMap<Customer>
    {
        public CustomerMapping()
        {
            Id(x => x.CustomerId);
            Map(x => x.Email);
        }
    }
}
