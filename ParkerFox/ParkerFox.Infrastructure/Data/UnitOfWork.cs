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
        private ISession _currentSession;

        public UnitOfWork(IActiveSessionManager activeSessionManager)
        {
            _activeSessionManager = activeSessionManager;
        }

        public void Commit()
        {
            if(_transactionScope != null)
                _transactionScope.Commit();
        }

        public void BeginTransaction()
        {
            //_transactionScope = _activeSessionManager.GetActiveSession().BeginTransaction();
            ISession currentSession = GetCurrentSession();
            _transactionScope = currentSession.BeginTransaction();
        }

        public void SaveOrUpdate(object obj)
        {
            ISession currentSession = GetCurrentSession();
            if (_transactionScope == null)
                BeginTransaction();
            currentSession.SaveOrUpdate(obj);
        }

        private ISession GetCurrentSession()
        {
            if (_currentSession == null)
                _currentSession = DataConfig.GetSession();
            return _currentSession;
        }
    }
}
