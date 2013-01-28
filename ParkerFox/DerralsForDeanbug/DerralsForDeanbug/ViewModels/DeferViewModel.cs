using System.Collections.Generic;

namespace DerralsForDeanbug.ViewModels
{
    public class DeferViewModel
    {
        public int Option { get; set; }
        public decimal Total { get; set; }
        public IEnumerable<LoanViewModel> Loans { get; set; }
    }
}