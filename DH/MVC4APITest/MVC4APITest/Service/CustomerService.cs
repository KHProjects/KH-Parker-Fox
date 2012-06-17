using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC4APITest.Models;
using MVC4APITest.BLL;

namespace MVC4APITest.Service
{
  public class CustomerService : ICustomerService
  {

    public List<Customer> GetCustomers()
    {
      List<Customer> customerList = new List<Customer>();
      CustomerBLL customerBLL = new CustomerBLL();

      customerList = customerBLL.GetCustomers();
      return customerList;
    }

    public Customer GetCustomerByID(int customerID)
    {
      Customer customer = new Customer();
      CustomerBLL customerBLL = new CustomerBLL();

      customer = customerBLL.GetCustomerByID(customerID);
      return customer;
    }


  }
}