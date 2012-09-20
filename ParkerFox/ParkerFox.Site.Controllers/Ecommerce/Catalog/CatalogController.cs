using ParkerFox.Core.Entities.Repository;
using ParkerFox.Site.ViewModels.Ecommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ParkerFox.Site.Controllers.Ecommerce.Catalog
{
    public class CatalogController : Controller
    {
        private IProductRepository _productRepository;

        public CatalogController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ActionResult Index()
        {
            var products = _productRepository.GetOnPromotion();

            var catalogViewModel = new CatalogViewModel
                {
                    Products = products.All().Select(x => new ProductViewModel
                        {
                            Name = x.Name
                        }).ToList()
                };

            return View(catalogViewModel);
        }

        public ActionResult Admin()
        {



            return View();
        }
    }
}