using MagHag.Core.Messaging;
using MagHag.Core.Messaging.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagHag.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBus _bus;

        public HomeController(IBus bus)
        {
            _bus = bus;
        }

        public ActionResult Index()
        {
            _bus.Send(new CreateAccount {Email = "sabkent@hotmail.com"});
            return View();
        }

    }
}
