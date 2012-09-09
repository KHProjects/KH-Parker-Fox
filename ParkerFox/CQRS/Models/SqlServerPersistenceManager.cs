using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlServerCe;
using System.Linq;
using System.Web;

namespace CQRS.Models
{
    public class SqlServerPersistenceManager
    {
        private IContext _context;
        private IEventBus _eventBus;
        private SqlCeConnection _connection;

        public SqlServerPersistenceManager(IContext context, IEventStore eventStore)
        {
            _context = context;
            EventStore = eventStore;
        }

        public void Open()
        {
            _connection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["main"].ConnectionString);
            _connection.Open();
        }

        public void Commit()
        {
            Open();
            var aggregates = _context["Aggregates"] as HashSet<IAggregateRoot>;

            if (aggregates != null && aggregates.Count > 0)
            {
                using (var transaction = _connection.BeginTransaction())
                {
                    foreach (var aggregate in aggregates)
                        EventStore.Persist(aggregate);

                    //--could throw concurrency exception
                    foreach (var aggregate in aggregates)
                        foreach (var @event in aggregate.UncommitedEvents)
                            _eventBus.Publish(@event);

                    transaction.Commit();
                    _context["Aggregates"] = null;
                }
            }

        }

        public IEventStore EventStore { get; set; }
    }
}