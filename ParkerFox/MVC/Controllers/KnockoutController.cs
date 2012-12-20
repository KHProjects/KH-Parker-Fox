using MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class KnockoutController : Controller
    {
        public ActionResult Index()
        {
            var viewModel = new RegisterViewModel
                {
                    Titles = new List<string> {"Mr", "Mrs", "Ms", "Dr"},
                    Addresses = new List<AddressViewModel>(),
                    FirstName = "Dean"
                }; 

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(RegisterViewModel registerViewModel)
        {
            var address = registerViewModel.Addresses;

            return View(registerViewModel);
        }
    }
}
