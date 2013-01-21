using MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace MVC.Components
{
    /// <summary>
    /// http://www.codeproject.com/Tips/389747/Custom-strongly-typed-HtmlHelpers-in-ASP-NET-MVC
    /// </summary>
    public static class HtmlHelperExtensionsForRadioListFor
    {
        public static MvcHtmlString RadioListFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper,
                                                                 Expression<Func<TModel, TValue>> expression,
                                                                 Expression<Func<TModel, SelectList>> dataExpression,
                                                                 object htmlAttributes = null)
        {
            return RadioListFor(htmlHelper, expression, dataExpression, new RouteValueDictionary(htmlAttributes));
        }

        public static MvcHtmlString RadioListPartialFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper,
                                                                 Expression<Func<TModel, TValue>> expression,
                                                                 Expression<Func<TModel, SelectList>> dataExpression,
                                                                 object htmlAttributes = null)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            var data = ModelMetadata.FromLambdaExpression(dataExpression, htmlHelper.ViewData);

            var radioListViewModel = new RadioListViewModel()
                {
                    Name = name,
                    List = (SelectList)data.Model
                };

            htmlHelper.RenderPartial("RadioList", radioListViewModel);
            return MvcHtmlString.Empty;
        }

        private static MvcHtmlString RadioListFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper,
                                                                 Expression<Func<TModel, TValue>> expression,
                                                                 Expression<Func<TModel, SelectList>> dataExpression,
                                                                 IDictionary<string, object> htmlAttributes)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            var data = ModelMetadata.FromLambdaExpression(dataExpression, htmlHelper.ViewData);
            var selectList = (SelectList) data.Model;

            var tagBuilder = new TagBuilder("div");
            
            SetTagValue(tagBuilder, htmlAttributes, "id", name);
            SetTagValue(tagBuilder, htmlAttributes, "class", "radio-list");

            foreach (var item in selectList.Items.Cast<SelectListItem>().ToList())
            {
                tagBuilder.InnerHtml += htmlHelper.RadioButton(name, item.Value, item.Selected);
                tagBuilder.InnerHtml += String.Format("<label>{0}</label>", item.Text);
            }
            return MvcHtmlString.Create(tagBuilder.ToString());
        }

        private static void SetTagValue(TagBuilder tagBuilder, IDictionary<string, object> values, string key, string defaultValue)
        {
            if (values.ContainsKey(key))
                tagBuilder.MergeAttribute(key, values[key] as string);
            else
                tagBuilder.MergeAttribute(key, defaultValue);
        }
    }
}