using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.Core.Entities.Ecommerce
{
    public class CartItem
    {
        public string Identifier { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
