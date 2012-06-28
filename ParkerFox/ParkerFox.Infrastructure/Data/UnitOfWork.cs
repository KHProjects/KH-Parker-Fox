using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace ParkerFox.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {        
        private ITransaction _transactionScope;
        private ISession _currentSession;

        public void Commit()
        {
            if(_transactionScope != null)
                _transactionScope.Commit();
        }

        public void BeginTransaction()
        {
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

        public EntitySet<T> Query<T>(Expression<Func<T, bool>> expression) where T:class
        {
            ISession session = GetCurrentSession();
            return new EntitySet<T>(session.QueryOver<T>().Where(expression));
        }

        public void CreateQuery(string query)
        {
            ISession session = GetCurrentSession();

        
        }


        private ISession GetCurrentSession()
        {
            if (_currentSession == null)
                _currentSession = DataConfig.GetSession();
            return _currentSession;
        }
    }
}
