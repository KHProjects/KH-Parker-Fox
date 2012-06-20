// Example header text. Can be configured in the options.
using System;
using System.Linq;
using System.Web.Mvc;
using Data;
using FluentValidation;

namespace MVCWebApiClient
{
 public class ValidationFilterAttribute : ActionFilterAttribute
 {
  public override void OnActionExecuting(ActionExecutingContext filterContext)
  {
   IValidator validator = null;

   try
   {
   var typeString = string.Format("Data.{0}{1}",filterContext.ActionParameters["model"].GetType().Name, "Validator");

   validator = ((StructureMapDependencyResolver)DependencyResolver.Current).GetService(typeString) as IValidator;
   }
   catch (Exception)
   {
    throw new ValidationClassNotFoundException();
   }

   if (validator == null)
    throw new ValidationClassNotFoundException();

   var results = validator.Validate(filterContext.ActionParameters["model"]);

   if (!results.IsValid)
   {
    filterContext.Result = new JsonResult() { Data = results.Errors };
    }

   base.OnActionExecuting(filterContext);
  }
 }
}