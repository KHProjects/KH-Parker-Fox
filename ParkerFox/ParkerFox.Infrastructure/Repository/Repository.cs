using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkerFox.Infrastructure.Data;

namespace ParkerFox.Infrastructure.Repository
{
    /// <summary>
    /// http://blog.bobcravens.com/2010/06/the-repository-pattern-with-linq-to-fluent-nhibernate-and-mysql/
    /// </summary>    
    public class Repository<T> : IRepository<T>
    {
        private readonly IUnitOfWork _UnitOfWork;

        public Repository(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        IUnitOfWork IRepository<T>.Add(T entity)
        {
            throw new NotImplementedException();
        }

        public IUnitOfWork Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Query()
        {
            throw new NotImplementedException();
        }
    }
}