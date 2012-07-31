using System.Collections.Generic;
using System.Web.Mvc;
using ParkerFox.Core.Entities.Ecommerce;
using ParkerFox.Core.Entities.Repository;
using ParkerFox.Site.ViewModels;
using ParkerFox.Site.ViewModels.Store;

namespace ParkerFox.Site.Controllers
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
            IEntitySet<Product> products = _productRepository.GetOnPromotion();

            var catalogViewModel = new CatalogViewModel
                {
                    Products = new List<ProductViewModel>
                        {
                            new ProductViewModel{Name = "product one"},
                            new ProductViewModel{Name = "product two"}
                        }
                };

            return View(catalogViewModel);
        }

        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult ListProducts()
        {
            var products = _productRepository.GetOnPromotion();
            return PartialView("_ProductList", products.All());
        }
    }
}
