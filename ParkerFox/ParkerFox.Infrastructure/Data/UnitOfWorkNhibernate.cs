using NHibernate;
using System;
using System.Linq.Expressions;

namespace ParkerFox.Infrastructure.Data
{
    public class UnitOfWorkNhibernate : IUnitOfWork
    {        
        private ITransaction _transactionScope;
        private ISession _currentSession;
        private ISessionFactory _sessionFactory;

        public UnitOfWorkNhibernate(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

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

        public EntitySet<T> Query<T>(Expression<Func<T, bool>> expression) where T : class
        {
            ISession session = GetCurrentSession();
            return new EntitySet<T>(session.QueryOver<T>().Where(expression));
        }

        public void CreateQuery<T>(Expression<Func<T, bool>> expression) where T : class
        {
            ISession session = GetCurrentSession();

            session.QueryOver<T>().Where((expression)).Future<T>();
        }

        public IQueryOver<T> QueryOver<T>() where T : class
        {
            return GetCurrentSession().QueryOver<T>();
        }

        private ISession GetCurrentSession()
        {
            if (_currentSession == null)
                _currentSession = _sessionFactory.OpenSession();
            return _currentSession;
        }
    }
}
