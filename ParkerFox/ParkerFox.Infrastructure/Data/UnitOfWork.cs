using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace ParkerFox.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IActiveSessionManager _activeSessionManager;
        private ITransaction _transactionScope;

        public UnitOfWork(IActiveSessionManager activeSessionManager)
        {
            _activeSessionManager = activeSessionManager;
        }

        public void Commit()
        {
            _transactionScope.Commit();
        }

        public void BeginTransaction()
        {
            _transactionScope = _activeSessionManager.GetActiveSession().BeginTransaction();
        }
    }
}
