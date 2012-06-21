using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.Infrastructure.Data
{
    public interface IUnitOfWork
    {
        //TODO: this would allow anyone to query and bypass the repository all together
        EntitySet<T> Query<T>(Expression<Func<T, bool>> expression) where T : class;

        void SaveOrUpdate(object obj);

        void Commit();

        void BeginTransaction();
    }
}
