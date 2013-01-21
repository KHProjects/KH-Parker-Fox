using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Representations
{
    public class CustomerRepresentation : Representation
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }

        public static CustomerRepresentation FromResource(Customer customer)
        {
            return new CustomerRepresentation
                {
                   Title =  customer.Title,
                   FirstName =  customer.FirstName,
                   Surname = customer.Surname,
                   Links =  new List<Link>
                       {
                           new Link("Edit", "PUT", new Uri(String.Format("/customer/{0}", customer.CustomerId))),
                           new Link("Delete", "DELETE", new Uri(String.Format("/customer/{0}", customer.CustomerId)))
                       }
                };
        }
    }
}