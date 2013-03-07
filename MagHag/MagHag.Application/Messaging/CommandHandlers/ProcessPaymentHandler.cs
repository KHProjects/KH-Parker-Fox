using MagHag.Core.Messaging.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;

namespace MagHag.Application.Messaging.CommandHandlers
{
    public class ProcessPaymentHandler : IHandleMessages<ProcessPayment>
    {
        public void Handle(ProcessPayment message)
        {
            Console.WriteLine("ProcessPaymentHandler");
        }
    }
}
