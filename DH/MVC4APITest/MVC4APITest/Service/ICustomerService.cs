using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC4APITest.Models;

namespace MVC4APITest.Service
{
  public interface ICustomerService
  {
    List<Customer> GetCustomers();
  }
}