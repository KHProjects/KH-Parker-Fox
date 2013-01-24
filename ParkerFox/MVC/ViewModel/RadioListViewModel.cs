using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.ViewModel
{
    public class RadioListViewModel
    {
        public string Name { get; set; }
        public SelectList List { get; set; }
    }
}