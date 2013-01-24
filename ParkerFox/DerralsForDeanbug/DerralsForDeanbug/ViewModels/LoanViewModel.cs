using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DerralsForDeanbug.ViewModels
{
    public class LoanViewModel
    {
        public int LoanId { get; set; }
        public bool IsSelected { get; set; }
        public decimal Principal { get; set; }
    }
}
