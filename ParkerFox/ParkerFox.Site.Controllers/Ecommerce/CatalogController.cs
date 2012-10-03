using ParkerFox.Core.Entities.Repository;
using ParkerFox.Infrastructure.Data;
using ParkerFox.Site.ViewModels.Ecommerce;
using System.Linq;
using System.Web.Mvc;

namespace ParkerFox.Site.Controllers.Ecommerce
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
                            ProductId = x.ProductId,
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