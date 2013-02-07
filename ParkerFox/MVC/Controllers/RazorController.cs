using MVC.Components;
using MVC.Models;
using MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class RazorController : Controller
    {
        public ActionResult Index()
        {
            return View(new Customer{Created = DateTime.Now});
        }

        [HttpPost]
        public ActionResult Index(Customer customer)
        {
            return View(customer);
        }

        public ActionResult ModelBinding()
        {
            var customer = new Customer()
                {
                    Addresses = new List<Address>
                        {
                            new Address {AddressId = 1, Number = "1", Street = "one"},
                            new Address {AddressId = 2, Number = "2", Street = "two"}
                        }
                };
            return View(customer);
        }

        [HttpPost]
        public ActionResult ModelBinding(Customer customer)
        {
            var test = customer.FirstName;

            return View(customer);
        }

        public ActionResult Validation()
        {
            return View(new RegisterViewModel());
        }
    }
}
