using System;
using System.Collections.Generic;
using System.Linq;
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
        IUnitOfWork Add(T entity);
        IUnitOfWork Remove(T entity);        
        IQueryable<T> Query();
    }
}
