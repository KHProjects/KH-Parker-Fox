using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.Core.Entities.Ecommerce
{
    public class Customer
    {
        public virtual int CustomerId { get; set; }
        public virtual string Email { get; set; }
    }
}
