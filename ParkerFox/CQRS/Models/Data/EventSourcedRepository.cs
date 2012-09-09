using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace CQRS.Models.Data
{
    public class EventSourcedRepository<T> : IRepository<T> where T : IAggregateRoot
    {
        private IEventStore _eventStore;
        private IContext _context;
        private ConstructorInfo _constructorInfo;

        public EventSourcedRepository(IEventStore eventStore, IContext context)
        {
            _eventStore = eventStore;
            _context = context;
            _constructorInfo = typeof (T).GetConstructor(new Type[] {typeof (IEventInputStream)});
        }

        public T ById(Guid id)
        {
            var events = _eventStore.Load(id);
            var resVal = (T) _constructorInfo.Invoke(new object[] {events});
            AddToContext(resVal);
            return resVal;
        }

        public void Add(T entity)
        {
            AddToContext(entity);
        }

        //--adds to in context list of aggregate roots
        private void AddToContext(T entity)
        {
            HashSet<IAggregateRoot> aggregates = _context["Aggregates"] as HashSet<IAggregateRoot>;

            if(aggregates== null)
            {
                aggregates = new HashSet<IAggregateRoot>();
                _context["Aggregates"] = aggregates;
            }

            aggregates.Add(entity);
        }
    }
}