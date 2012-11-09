using ParkerFox.Core.Entities.Ecommerce;
using ParkerFox.Core.Entities.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ParkerFox.Infrastructure.Web;
using ParkerFox.Core.Entities.Repository.Publication;
using ParkerFox.Core.Entities.Publication;

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
            var subscription = _subscriptionRepository.GetByUserId(1);

            //var subscription = new Subscription();
            //var term = new SubscriptionTerm(SubscriptionPaymentTypes.UpFront, new TimePeriod(TimePeriodIntervals.Months, 12));
            //term.Activate();
            //subscription.AddTerm(term);

            //_subscriptionRepository.Add(subscription);

            return View();
        }
    }
}
