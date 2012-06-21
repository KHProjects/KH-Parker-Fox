using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using ParkerFox.Core.Entities.Repository;
using ParkerFox.Infrastructure.Data;

namespace ParkerFox.Infrastructure.Repository
{
    /// <summary>
    /// http://blog.bobcravens.com/2010/06/the-repository-pattern-with-linq-to-fluent-nhibernate-and-mysql/
    /// http://www.storminajar.net/2010/08/30/letting-your-unitofwork-repositories-support-multiple-frameworks/
    /// http://codebetter.com/gregyoung/2009/01/16/ddd-the-generic-repository/
    /// </summary>    
    public class Repository<T>  where T : class
    {        
        private IUnitOfWork _unitOfWork;

        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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