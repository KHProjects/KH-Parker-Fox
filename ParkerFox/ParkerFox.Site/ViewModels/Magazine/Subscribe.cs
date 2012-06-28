using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParkerFox.Site.ViewModels.Magazine
{
    public class Subscribe
    {
        [Required]
        public string Email { get; set; }
    }
}
