using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.Infrastructure.Data
{
    public interface IUnitOfWork
    {
        void SaveOrUpdate(object obj);

        void Commit();

        void BeginTransaction();
    }
}
