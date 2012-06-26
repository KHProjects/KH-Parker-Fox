using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.Core.Entities.Ecommerce
{
    public class OrderItem
    {
        public virtual int OrderItemId { get; set; }
        public virtual int OrderId { get; set; }
        public virtual int Quantity { get; set; }
        public virtual Order Order { get; set; }
    }
}
