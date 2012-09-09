using System.Linq;
using System.Web.Mvc;
using ParkerFox.Core.Entities.Ecommerce;
using ParkerFox.Site.ViewModels.Ecommerce;
using ParkerFox.Core.ApplicationServices;

namespace ParkerFox.Site.Controllers.Ecommerce.Catalog
{
    public class BasketController : Controller
    {
        private readonly ICartServices _cartServices;

        public BasketController(ICartServices cartServices)
        {
            _cartServices = cartServices;
        }

        public ActionResult Index()
        {
            string productIdQs = Request.QueryString["productId"];
            int productId = 0;
            if (int.TryParse(productIdQs, out productId))
                ViewBag.ProductId = productId;

            return View();
        }

        public ActionResult Basket()
        {
            if (ControllerContext.ParentActionViewContext != null)
                ViewBag.ProductId = ControllerContext.ParentActionViewContext.ViewBag.ProductId;
            var basketItems = _cartServices.GetCurrentItems().Select(cartItem =>
                                                                     new BasketViewModel
                                                                     {
                                                                         ProductId = cartItem.Product.ProductId,
                                                                         Description = cartItem.Product.Name,
                                                                         Quantity = cartItem.Quantity
                                                                     }).ToList();
            return PartialView(basketItems);
        }

        public JsonResult UpdateItem(BasketViewModel basketViewModel)
        {
            _cartServices.UpdateItem(new CartItem
            {
                Product = new Product { ProductId = basketViewModel.ProductId },
                Quantity = basketViewModel.Quantity
            });

            return Json("true", JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteItem(BasketViewModel basketViewModel)
        {
            _cartServices.RemoveItem(basketViewModel.ProductId);
            return Json("true", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update(BasketViewModel basketViewModel)
        {
            _cartServices.UpdateItem(new CartItem
                {
                    Product = new Product {ProductId = basketViewModel.ProductId},
                    Quantity = basketViewModel.Quantity
                });
            
            return View("Index");
        }

        public ActionResult Delete(BasketViewModel basketViewModel)
        {
            _cartServices.RemoveItem(basketViewModel.ProductId);
            return View("Index");
        }
    }
}
