using ParkerFox.Infrastructure.Data;
using System.Web.Mvc;

namespace ParkerFox.Infrastructure.Web
{
    public class UnitOfWorkAttribute : ActionFilterAttribute
    {
        public IUnitOfWork UnitOfWork { get; set; }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception == null)
                UnitOfWork.Commit();
            //TODO: uof.rollback();
            base.OnActionExecuted(filterContext);
        }
    }
}
