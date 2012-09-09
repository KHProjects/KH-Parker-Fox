using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.Site.ViewModels.Ecommerce
{
    public class BasketViewModel
    {
        public int ProductId { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
    }
}
