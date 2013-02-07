using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Components
{
    public class MyValidationAttribute : ValidationAttribute, IClientValidatable
    {
        public override bool IsValid(object value)
        {
            return value != null && (DateTime) value > DateTime.Now;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRule
                {
                    ErrorMessage =  ErrorMessage,
                    ValidationType = "future" // renders out attribute data-val-future="<errormessage>"
                };
        }
    }
}