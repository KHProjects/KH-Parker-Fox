using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Components;

namespace MVC.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime Created { get; set; }
        public IEnumerable<Address> Addresses { get; set; }

        public SelectList Titles = new SelectList(new[]
            {
                new SelectListItem {Text = "Mr", Value = "Mr", Selected = true},
                new SelectListItem {Text = "Mrs", Value = "Mrs"},
                new SelectListItem {Text = "Dr", Value = "Dr"}
            });

    }
}