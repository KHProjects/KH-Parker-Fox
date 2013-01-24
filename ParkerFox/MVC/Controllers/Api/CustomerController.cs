using MVC.Models;
using MVC.Representations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MVC.Controllers.Api
{
    public class CustomerController : ApiController
    {
        public CustomerRepresentation Get(int customerId)
        {
            //customerRepository.GetById(customerId)
            var customer = new Customer
                {
                    CustomerId = customerId,
                    Title = "title",
                    FirstName = "first Name",
                    Surname = "surname"
                };
            return CustomerRepresentation.FromResource(customer);
        }
    }
}