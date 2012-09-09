using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQRS.Models
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        T ById(Guid id);
        void Add(T entity);
    }
}