using System;
using System.Collections.Generic;

namespace PharmaNet.Fulfillment.Domain
{
    public class PickList
    {
        public virtual int Id { get; set; }
        public virtual Guid OrderId { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        public virtual Product Product { get; set; }
        public virtual int Quantity { get; set; }
        public virtual IList<Shipment> Shipments { get; set; }
    }
}
