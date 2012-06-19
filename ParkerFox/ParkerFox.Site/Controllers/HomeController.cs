﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ParkerFox.Core.Entities;
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

        public HomeController(IProductRepository products, IUnitOfWork unitOfWork)
        {
            _products = products;
            _unitOfWork = unitOfWork;
        }
        
        public ActionResult Index()
        {
            var products = _products.GetOnPromotion().Page(0, 1);

            return View();
        }

        public ActionResult AddProduct()
        {
            return View();
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
