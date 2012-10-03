using ParkerFox.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ParkerFox.Infrastructure.Web
{
    public class UnitOfWorkAttribute : ActionFilterAttribute
    {
        private IUnitOfWork _unitOfWork;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _unitOfWork = DependencyResolver.Current.GetService<IUnitOfWork>();
            //_unitOfWork.BeginTransaction();
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if(filterContext.Exception==null)
                _unitOfWork.Commit();
            //TODO: uof.rollback();
            base.OnActionExecuted(filterContext);
        }
    }
}
