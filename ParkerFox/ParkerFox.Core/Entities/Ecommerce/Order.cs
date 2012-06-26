using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.Core.Entities.Ecommerce
{
    public class Order
    {
        public virtual int OrderId { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual IList<OrderItem> Items { get; set; }
    }
}
