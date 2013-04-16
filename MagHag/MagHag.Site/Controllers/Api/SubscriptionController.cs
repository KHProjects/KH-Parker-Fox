using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MagHag.Subscriptions.Core.Commands;
using NServiceBus;

namespace MagHag.Site.Controllers.Api
{
    public class SubscriptionController : ApiController
    {
        private IBus _bus;

        public SubscriptionController(IBus bus)
        {
            _bus = bus;
        }

        public void Post(CreateSubscriptionCommand createSubscriptionCommand)
        {
            _bus.Send(createSubscriptionCommand);
        }
    }
}
