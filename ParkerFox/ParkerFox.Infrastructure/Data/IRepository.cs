using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.Infrastructure.Data
{
    /// <summary>
    /// http://mikehadlow.blogspot.co.uk/2009/01/should-my-repository-expose-iqueryable.html
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
        void Add(T entity);
        void Remove(T entity);
        IQueryable<T> Query(Expression<Func<T, object>> expression);
    }
}
