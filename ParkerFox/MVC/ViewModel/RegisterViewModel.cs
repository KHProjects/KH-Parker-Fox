using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModel
{
    public class RegisterViewModel
    {
        public string Title{ get; set; }
        [Display(Name="First Name")]
        public string FirstName { get; set; }

        public IEnumerable<AddressViewModel> Addresses { get; set; }

        public List<string> Titles { get; set; }
    }
}