using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.Core.Entities.Ecommerce
{
    public class CartItem
    {
        public virtual string Identifier { get; set; }
        public virtual int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public virtual int Quantity { get; set; }

        private string _Test;

        public virtual void DoSomethingThatChangesTest(string input)
        {
            _Test = input;
        }
    }
}
