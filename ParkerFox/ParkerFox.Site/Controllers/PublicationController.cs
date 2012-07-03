using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using ParkerFox.Application.Commands.Magazine;
using ParkerFox.Core.Entities.Magazine;
using ParkerFox.Infrastructure.Data;
using ParkerFox.Infrastructure.Messaging;
using ParkerFox.Site.ViewModels.Magazine;

namespace ParkerFox.Site.Controllers
{
    public class PublicationController : Controller
    {
        private readonly IBus _bus;
        private readonly IUnitOfWork _unitOfWork;

        public PublicationController(IBus bus, IUnitOfWork unitOfWork)
        {
            _bus = bus;
            _unitOfWork = unitOfWork;
        }

        public ActionResult Subscription()
        {
            var result = _unitOfWork.QueryOver<Subscription>().List();

            return View();
        }

        [HttpPost]
        public ActionResult Subscription(Subscribe subscribe)
        {
            var command = Mapper.Map<CreateNewSubscription>(subscribe);
            _bus.Send(command);

            return View();
        }

        public ActionResult UserProfile()
        {
            return PartialView();
        }
    }
}
