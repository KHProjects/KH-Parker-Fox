using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkerFox.Site.ViewModels.Store
{
    public class CatalogViewModel
    {
        public string Title { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}