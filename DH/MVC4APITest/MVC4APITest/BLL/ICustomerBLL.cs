using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC4APITest.Models;

namespace MVC4APITest.BLL
{
  public interface ICustomerBLL
  {
    List<Customer> GetCustomers();
  }
}