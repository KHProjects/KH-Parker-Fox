using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DerralsForDeanbug.ViewModels
{
    public class DeferViewModel
    {
        public int Option { get; set; }
        public decimal Total { get; set; }
        public IEnumerable<LoanViewModel> Loans { get; set; }
    }
}