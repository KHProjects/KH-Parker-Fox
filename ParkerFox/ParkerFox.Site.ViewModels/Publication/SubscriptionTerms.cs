using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.Site.ViewModels.Publication
{
    public class SubscriptionTerms
    {
        public string[] Units = new[]{"Days", "Months", "Years"};

        public int Unit { get; set; }
        public int Quantity { get; set; }
    }
}
