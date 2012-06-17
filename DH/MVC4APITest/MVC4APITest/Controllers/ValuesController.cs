using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using MVC4APITest.Service;
using MVC4APITest.Models;

namespace MVC4APITest.Controllers
{
  public class ValuesController : ApiController
  {
    // GET /api/values
    public IEnumerable<Customer> Get()
    {
      List<Customer> customerList = new List<Customer>();
      CustomerService customerService = new CustomerService();

      customerList = customerService.GetCustomers();
      return customerList;
    }

    // GET /api/values/5
    public Customer Get(int customerID)
    {
      Customer customer = new Customer();
      CustomerService customerService = new CustomerService();

      customer = customerService.GetCustomerByID(customerID);
      return customer;

      //return "value";
    }

    // POST /api/values
    public void Post(string value)
    {
    }

    // PUT /api/values/5
    public void Put(int id, string value)
    {
    }

    // DELETE /api/values/5
    public void Delete(int id)
    {
    }
  }
}