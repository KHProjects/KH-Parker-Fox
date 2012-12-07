using ParkerFox.Core.Entities.Publication;
using ParkerFox.Core.Entities.Repository.Publication;
using ParkerFox.Infrastructure.Web;
using System.Web.Mvc;

namespace ParkerFox.Site.Controllers.Publication
{
    public class SubscriptionController : Controller
    {
        private ISubscriptionRepository _subscriptionRepository;

        public SubscriptionController(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        [UnitOfWork]
        public ActionResult Index()
        {
            //var subscriptions = _subscriptionRepository.GetActive();

            var subscription = Subscription.CreateNew();
            subscription.AddTerm(SubscriptionPaymentTypes.UpFront, new TimePeriod(TimePeriodIntervals.Months, 12));
            _subscriptionRepository.Add(subscription);

            return View();
        }
    }
}
