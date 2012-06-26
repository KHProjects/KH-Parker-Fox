using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ParkerFox.Core.Entities;
using ParkerFox.Core.Entities.Ecommerce;
using ParkerFox.Core.Entities.Magazine;
using ParkerFox.Core.Entities.Repository;
using ParkerFox.Infrastructure.Data;
using ParkerFox.Infrastructure.Data.Web;
using ParkerFox.Infrastructure.Repository;
using ParkerFox.Site.ViewModels;

namespace ParkerFox.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _products;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISubscriptionRepository subs;

        public HomeController(IProductRepository products, IUnitOfWork unitOfWork,ISubscriptionRepository subs)
        {
            _products = products;
            _unitOfWork = unitOfWork;
            this.subs = subs;
        }
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddProduct()
        {
            return View(new ProductViewModel { Name = "initial view model" });
        }

        [HttpPost]
        public ActionResult AddProduct(ProductViewModel productViewModel)
        {
            //_unitOfWork.BeginTransaction();
            Product product = Mapper.Map<Product>(productViewModel);
            _products.Add(product);

            _unitOfWork.Commit();
            return View();
        }
    }
}
