using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceThing.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            new PersonService("some").Process2().Process();

            var person = new PersonBuilder()
                .WithFirstName("dean")
                .WithFirstName("seb")
                .WithActiveLoans(10).Create();

            return View();
        }

    }
}
