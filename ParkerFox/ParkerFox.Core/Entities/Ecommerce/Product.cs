using System;

namespace ParkerFox.Core.Entities.Ecommerce
{
    public class Product
    {
        public virtual int ProductId { get; set; }
        public virtual string Name { get; set; }
        public virtual float UnitPrice { get; set; }
    }
}
