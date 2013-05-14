using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagHag.Core.Messaging.Commands
{
    public class ProcessPayment //: ICommand
    {
        public Guid PaymentId { get; set; }
    }
}
