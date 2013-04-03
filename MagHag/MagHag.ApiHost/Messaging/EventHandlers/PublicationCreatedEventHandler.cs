using System;
using MagHag.ApiHost.Representations;
using NServiceBus;
using MagHag.Subscriptions.Messaging.Events;

namespace MagHag.ApiHost.Messaging.EventHandlers
{
    public class PublicationCreatedEventHandler : IHandleMessages<PublicationCreated>
    {
        public void Handle(PublicationCreated publicationCreated)
        {
            using (var session = Program.GetDocumentStore().OpenSession())
            {
                session.Store(new Publication
                    {
                        Name = publicationCreated.Name
                    });
                session.SaveChanges();
            }
        }
    }
}
