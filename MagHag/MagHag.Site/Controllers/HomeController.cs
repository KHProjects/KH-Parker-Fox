using MagHag.Core.Messaging;
using MagHag.Core.Messaging.Commands;
using MagHag.Subscriptions.Messaging.Commands;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NServiceBus.Unicast;
using MagHag.Subscriptions.Messaging;

namespace MagHag.Site.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IApplicationBus _bus;
        private IBus _bus;

        public HomeController(IBus bus)
        {
            _bus = bus;
        }

        public ActionResult Index()
        {
            return View();
        }


        public void RaiseSubscriptionCreatedEvent()
        {
            _bus.Send(new SubscriptionCreated());
        }
    }
}
