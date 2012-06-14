using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ParkerFox.Infrastructure.Data.Web
{
    public class UnitOfWorkFilter : ActionFilterAttribute
    {
        private readonly IUnitOfWork _unitOfWork;

        public UnitOfWorkFilter(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _unitOfWork.BeginTransaction();
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            _unitOfWork.Commit();
        }
    }
}
