using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.Site.ViewModels.Ecommerce
{
    public class CatalogViewModel
    {
        public string CurrentCategory { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
