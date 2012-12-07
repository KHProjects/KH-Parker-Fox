using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.ViewModel
{
    public class AddressViewModel
    {
        public string NameOrNumber { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string PostalZipCode { get; set; }
    }
}