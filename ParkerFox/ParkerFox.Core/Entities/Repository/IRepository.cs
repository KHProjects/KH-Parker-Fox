using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.Core.Entities.Repository
{
    public interface IRepository<T>
    {
        void Add(T entity);
    }
}
