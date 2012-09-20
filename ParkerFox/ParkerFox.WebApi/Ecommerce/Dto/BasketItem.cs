using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.WebApi.Ecommerce.Dto
{
    public class BasketItem
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
