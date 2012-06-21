using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.Core.Entities.Magazine
{
    public class Subscription
    {
        private int SubscriptionId { get; set; }
        private string Name { get; set; }
        private DateTime StartDate;

        public Subscription() { }

        public Subscription(string name, DateTime startDate)
        {
            Name = name;
            StartDate = startDate;
        }
    }
}
