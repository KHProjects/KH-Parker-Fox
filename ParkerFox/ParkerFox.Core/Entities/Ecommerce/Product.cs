using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.Core.Entities.Ecommerce
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public float UnitPrice { get; set; }
    }
}
