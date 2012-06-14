using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
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
        protected IEnumerable<T> Query(Expression<Func<T, bool>> expression) 
        {            
            ISession session = DataConfig.GetSession();
            return session.QueryOver<T>().Where(expression).List();            
        }

        private ISession CurrentSession
        {
            get
            {
                return null;
            }
        }
    }
}