using DerralsForDeanbug.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                            new LoanViewModel {LoanId = 1, Principal = 100, IsSelected = true},
                            new LoanViewModel {LoanId = 2, Principal = 200}
                        }
                };
            return View(deferViewModel);
        }

    }
}
