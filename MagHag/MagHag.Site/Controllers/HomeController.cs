using MagHag.Subscriptions.Core.Commands;
using MagHag.Subscriptions.Core.Queries;
using MagHag.Subscriptions.Core.ViewModels;
using NServiceBus;
using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
namespace MagHag.Site.Controllers
{
    public class HomeController : Controller
    {
        private IBus _bus;
        private IQueryPublications _queryPublications;

        public HomeController(IBus bus, IQueryPublications queryPublications)
        {
            _bus = bus;
            _queryPublications = queryPublications;
        }

        [Authorize]
        public ActionResult Index()
        {
            string name = HttpContext.User.Identity.Name;


            return View(new CreateSubscriptionViewModel {PublicationId = Guid.NewGuid()});
        }

        [HttpPost]
        public ActionResult Index(CreateSubscriptionViewModel createSubscriptionViewModel)
        {
            //_bus.Send(new CreateSubscriptionCommand{PublicationId = createSubscriptionViewModel.PublicationId});
            return View();
        }

        [HttpPost]
        public void CreatePublication(string publicationName)
        {
            _bus.Send(new CreatePublicationCommand {Id = Guid.NewGuid(), Title = publicationName});
        }

        public ActionResult Publications()
        {
            var publications = _queryPublications.GetActive();
            return PartialView("PublicationCatalog", publications);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string userName, string returnUrl)
        {
            FormsAuthentication.SetAuthCookie(userName, false);
            return Redirect(returnUrl ?? "/");
        }
    }
}
