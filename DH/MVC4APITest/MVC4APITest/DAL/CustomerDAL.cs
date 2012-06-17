using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC4APITest.Models;

namespace MVC4APITest.DAL
{
  public class CustomerDAL
  {
    public List<Customer> GetCustomers()
    {
      List<Customer> customerList = new List<Customer>();

      //test data.. access database here..
      customerList.Add(new Customer { CustomerID = 0, FirstName = "Dean", LastName = "Havelock" });
      customerList.Add(new Customer { CustomerID = 1, FirstName = "FName1", LastName = "LName1" });
      customerList.Add(new Customer { CustomerID = 2, FirstName = "FName2", LastName = "LName2" });

      return customerList;
    }

    public Customer GetCustomerByID(int customerID)
    {
      List<Customer> customerList = new List<Customer>();
      Customer customer = new Customer();

      //test data.. access database here..
      customerList.Add(new Customer { CustomerID = 0, FirstName = "Dean", LastName = "Havelock" });
      customerList.Add(new Customer { CustomerID = 1, FirstName = "FName1", LastName = "LName1" });
      customerList.Add(new Customer { CustomerID = 2, FirstName = "FName2", LastName = "LName2" });

      foreach( Customer cust in customerList)
      {
        if( cust.CustomerID == customerID)
          return cust;
      }
      return null;
    }





  }
}