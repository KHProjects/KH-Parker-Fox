using MagHag.Subscriptions.Core.Commands;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MagHag.Site.Controllers.Api
{
    public class PublicationController : ApiController
    {
        private readonly IBus _bus;

        public PublicationController(IBus bus)
        {
            _bus = bus;
        }

        public void Post(CreatePublicationRequest createPublicationRequest)
        {
            var createPublication = new CreatePublicationCommand
                {
                    Id = createPublicationRequest.PublicationId,
                    Title = createPublicationRequest.Title
                };

            _bus.Send(createPublication);
        }
    }
}
