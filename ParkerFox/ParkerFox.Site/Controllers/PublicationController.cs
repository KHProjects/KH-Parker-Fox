using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using ParkerFox.Application.Commands.Magazine;
using ParkerFox.Infrastructure.Messaging;
using ParkerFox.Site.ViewModels.Magazine;

namespace ParkerFox.Site.Controllers
{
    public class PublicationController : Controller
    {
        private readonly IBus _bus;

        public PublicationController(IBus bus)
        {
            _bus = bus;
        }

        public ActionResult Subscription()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Subscription(Subscribe subscribe)
        {
            var command = Mapper.Map<CreateNewSubscription>(subscribe);
            _bus.Send(command);

            return View();
        }
    }
}
