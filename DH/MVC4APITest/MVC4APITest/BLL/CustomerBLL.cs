using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC4APITest.Models;
using MVC4APITest.DAL;

namespace MVC4APITest.BLL
{
  public class CustomerBLL
  {
    public List<Customer> GetCustomers()
    {
      List<Customer> customerList = new List<Customer>();
      CustomerDAL customerDAL = new CustomerDAL();
      customerList = customerDAL.GetCustomers();
      return customerList;
    }

    public Customer GetCustomerByID(int customerID)
    {
      Customer customer = new Customer();
      CustomerDAL customerDAL = new CustomerDAL();

      customer = customerDAL.GetCustomerByID(customerID);
      return customer;
    }

  }
}