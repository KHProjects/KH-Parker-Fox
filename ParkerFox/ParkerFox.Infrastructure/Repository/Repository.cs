using ParkerFox.Infrastructure.Data;
using System;
using System.Linq.Expressions;

namespace ParkerFox.Infrastructure.Repository
{
    /// <summary>
    /// http://blog.bobcravens.com/2010/06/the-repository-pattern-with-linq-to-fluent-nhibernate-and-mysql/
    /// http://www.storminajar.net/2010/08/30/letting-your-unitofwork-repositories-support-multiple-frameworks/
    /// http://codebetter.com/gregyoung/2009/01/16/ddd-the-generic-repository/
    /// </summary>    
    public class Repository<T> where T : class
    {        
        private IUnitOfWork _unitOfWork;

        protected Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(T entity)
        {
            _unitOfWork.SaveOrUpdate(entity);
        }

        protected EntitySet<T> Query(Expression<Func<T, bool>> expression)
        {
            return _unitOfWork.Query<T>(expression);
        }

        protected IUnitOfWork CurrentUnitOfWork
        {
            get { return _unitOfWork; }
        }
    }    
}