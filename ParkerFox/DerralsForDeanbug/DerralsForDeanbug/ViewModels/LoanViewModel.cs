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
        public decimal Minimum { get; set; }
        
        public DateTime RepaymentDate { get; set; }  //--instead of using date and worrying about JS date the 'grouping by date' could be done c# side.. with a GroupId property of type string 'group1'
        public int Group { get; set; }               //--the group integer value can also be used to then order the loans by most recent repayment date etc

        public decimal Interest { get; set; }
        public decimal Reduction { get; set; }
    }
}
