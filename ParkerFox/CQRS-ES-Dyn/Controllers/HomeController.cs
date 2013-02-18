using CQRS_ES.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CQRS_ES.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(Configuration.Instance.Accounts);
        }

        [HttpPost]
        public ActionResult Index(RegisterAccountCommand registerAccountCommand)
        {
            Configuration.Instance.Bus.Handle(new RegisterAccountCommand
            {
                AccountId = Guid.NewGuid(),
                Balance = 100,
                Name = "Sebastian Kent"
            });

            return View(Configuration.Instance.Accounts);
        }

    }
}
