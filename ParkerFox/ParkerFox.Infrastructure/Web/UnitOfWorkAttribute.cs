using ParkerFox.Infrastructure.Data;
using System.Web.Mvc;

namespace ParkerFox.Infrastructure.Web
{
    public class UnitOfWorkAttribute : ActionFilterAttribute
    {
        public IUnitOfWork UnitOfWork { get; set; } //--this is ninjected ref:CustomPropertyInjectionHeuristic

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception == null)
                UnitOfWork.Commit();
            else
                UnitOfWork.RollBack();

            base.OnActionExecuted(filterContext);
        }
    }
}
