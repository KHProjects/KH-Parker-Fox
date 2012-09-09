using ParkerFox.Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParkerFox.Site.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            MyDbContext context = new MyDbContext();
            var beers = context.Beers.ToList();

            return View();
        }
    }
}
