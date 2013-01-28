using DerralsForDeanbug.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DerralsForDeanbug.Controllers
{
    public class DeferController : Controller
    {
        public ActionResult Index()
        {
            var deferViewModel = new DeferViewModel
                {
                    Total = 15.40m,
                    Option = 1,
                    Loans = new List<LoanViewModel>
                        {
                            new LoanViewModel {Principal = 100, Interest = 29.50m, Minimum = 20, Group = 1},
                            new LoanViewModel {Principal = 200, Interest = 59.75m, Minimum = 40, Group = 1}
                        }
                };
            return View("Index", deferViewModel);
        }
    }
}