using MagHag.Subscriptions.Core.Commands;
using MagHag.Subscriptions.Core.ViewModels;
using NServiceBus;
using System;
using System.Web.Mvc;
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
            return View(new CreateSubscriptionViewModel {PublicationId = Guid.NewGuid()});
        }

        [HttpPost]
        public ActionResult Index(CreateSubscriptionViewModel createSubscriptionViewModel)
        {
            _bus.Send(new CreateSubscriptionCommand{PublicationId = createSubscriptionViewModel.PublicationId});
            return View();
        }

    }
}
