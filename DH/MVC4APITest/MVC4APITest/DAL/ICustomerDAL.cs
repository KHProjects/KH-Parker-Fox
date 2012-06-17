using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC4APITest.Models;

namespace MVC4APITest.DAL
{
  public interface ICustomerDAL
  {
    List<Customer> GetCustomers();
  }
}