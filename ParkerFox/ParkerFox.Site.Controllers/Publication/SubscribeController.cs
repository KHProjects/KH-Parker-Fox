using ParkerFox.Application.CommandResponses.Publication;
using ParkerFox.Application.Commands.Publication;
using ParkerFox.Core.Messaging;
using ParkerFox.Infrastructure.Web;
using ParkerFox.Site.ViewModels.Publication;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ParkerFox.Site.Controllers.Publication
{
    public class SubscribeController : Controller
    {
        private IBus _bus;

        public SubscribeController(IBus bus)
        {
            _bus = bus;
        }

        public async Task<ActionResult> Index()
        {
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

        public ActionResult StepOne()
        {
            return PartialView();
        }
    }
}
