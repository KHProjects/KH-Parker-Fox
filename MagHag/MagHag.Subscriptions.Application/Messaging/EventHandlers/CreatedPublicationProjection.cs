using MagHag.Subscriptions.Core;
using MagHag.Subscriptions.Core.ReadModels;
using MagHag.Subscriptions.Messaging.Events;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagHag.Subscriptions.Application.Messaging.EventHandlers
{
    /// <summary>
    /// http://bliki.abdullin.com/event-sourcing/projections
    /// </summary>
    public class CreatedPublicationProjection : IHandleMessages<PublicationCreated>
    {
        private IStorePublicationProjection _storePublicationProjection;

        public CreatedPublicationProjection(IStorePublicationProjection storePublicationProjection)
        {
            _storePublicationProjection = storePublicationProjection;
        }

        public void Handle(PublicationCreated message)
        {
            var activePublication = new ActivePublication {Id = message.PublicationId, Title = ""};
            _storePublicationProjection.Store(activePublication);
        }
    }
}
