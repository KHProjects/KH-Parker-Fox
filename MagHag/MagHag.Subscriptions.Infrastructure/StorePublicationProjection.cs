using MagHag.Subscriptions.Core;
using MagHag.Subscriptions.Core.ReadModels;
using Raven.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagHag.Subscriptions.Infrastructure
{
    public class StorePublicationProjection : IStorePublicationProjection
    {
        private IDocumentStore _documentStore;

        public StorePublicationProjection(IDocumentStore documentStore)
        {
            _documentStore = documentStore;
        }

        public void Store(ActivePublication activePublication)
        {
            using (var session = _documentStore.OpenSession())
            {
                session.Store(activePublication);
                session.SaveChanges();
            }
        }
    }
}
