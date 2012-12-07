using MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class KnockoutController : Controller
    {
        public ActionResult Index()
        {
            var viewModel = new RegisterViewModel
                {
                    FirstName = "seb",
                    Titles = new List<string> {"Mr", "Mrs", "Ms", "Dr"},
                    Addresses = new List<AddressViewModel>
                        {
                            new AddressViewModel {NameOrNumber = "10"},
                            new AddressViewModel {NameOrNumber = "20"},
                            new AddressViewModel {NameOrNumber = "30"}
                        }
                };

            return View(viewModel);
        }
    }
}
