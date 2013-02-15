using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagHag.Site.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            MagHag.Core.Entities.User user = new Core.Entities.User();
            
            return View();
        }

    }
}
