using ParkerFox.Core.Entities.Ecommerce;
using ParkerFox.Core.Entities.Repository;
using ParkerFox.Infrastructure.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ParkerFox.Site.Controllers.Ecommerce
{
    public class RegisterController : Controller
    {
        private ICustomerRepository _customerRepository;

        public RegisterController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, UnitOfWork]
        public ActionResult Index(Customer c)
        {
            _customerRepository.Add(new Customer {Email = "sabkent@hotmail.com"});
            return View();
        }
    }
}
