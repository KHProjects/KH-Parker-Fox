using ParkerFox.Application.CommandResponses.Publication;
using ParkerFox.Application.Commands.Publication;
using ParkerFox.Core.ApplicationServices.Publication;
using ParkerFox.Core.Messaging;
using ParkerFox.Infrastructure.IoC;
using ParkerFox.Infrastructure.Web;
using ParkerFox.Site.ViewModels.Publication;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ParkerFox.Site.Controllers.Publication
{
    public class SubscribeController : Controller
    {
        private IBus _bus;
        private ISubscriptionServices _subscriptionServices;

        public SubscribeController(IBus bus, ISubscriptionServices subscriptionServices)
        {
            _bus = bus;
            _subscriptionServices = subscriptionServices;
        }

        public async Task<ActionResult> Index()
        {
            var subscription = _subscriptionServices.GetCurrent();

            return View();
        }

        [HttpPost, UnitOfWork]
        public ActionResult Index(Subscribe subscribe)
        {
            var createNewSubscription = new CreateNewSubscription();

            var createSubscriptionResponse =
                _bus.Send<CreateNewSubscription, CreateNewSubscriptionResponse>(createNewSubscription);

            return View();
        }

        public JsonResult Ajax()
        {
            return Json(new {FirstName = "seb"}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult StepOne()
        {
            return PartialView();
        }
        public void AjaxSubscribe(Subscribe subscribe)
        {
            int i = 0;
        }

    }
}
