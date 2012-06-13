using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using ParkerFox.Infrastructure.Data;

namespace ParkerFox.Infrastructure.Repository
{
    /// <summary>
    /// http://blog.bobcravens.com/2010/06/the-repository-pattern-with-linq-to-fluent-nhibernate-and-mysql/
    /// http://www.storminajar.net/2010/08/30/letting-your-unitofwork-repositories-support-multiple-frameworks/
    /// </summary>    
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ISession _Session;

        public Repository(ISession session)
        {
            _Session = session;
        }

        void IRepository<T>.Add(T entity)
        {
            _Session.SaveOrUpdate(entity);            
        }

        public void Remove(T entity)
        {
            _Session.Delete(entity);
        }

        public IQueryable<T> Query(Expression<Func<T, object>> expression) 
        {
            throw new NotImplementedException();
            //return _Session.QueryOver<T>().Fetch(expression);
        }
    }
}