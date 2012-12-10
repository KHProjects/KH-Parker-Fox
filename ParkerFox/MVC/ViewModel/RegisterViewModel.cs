using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace MVC.ViewModel
{
    public class RegisterViewModel
    {
        public List<string> Titles { get; set; }

        public string Title{ get; set; }
        [Display(Name="First Name")]
        public string FirstName { get; set; }

        public IEnumerable<AddressViewModel> Addresses { get; set; }
    }
}