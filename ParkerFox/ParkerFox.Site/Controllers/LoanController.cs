using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using ParkerFox.Core.Entities;
using ParkerFox.Core.Entities.Repository;
using ParkerFox.Infrastructure.Repository;

namespace ParkerFox.Site.Controllers
{
    public class LoanController : Controller
    {
        private readonly IVisitorRepository _visitorRepository;

        public LoanController(IVisitorRepository visitorRepository)
        {
            _visitorRepository = visitorRepository;
        }

        public ActionResult Apply()
        {
            var recentVisitors = _visitorRepository.GetRecent(10);


            return View();
        }
    }
}
