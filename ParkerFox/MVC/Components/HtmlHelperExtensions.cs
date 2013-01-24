using System;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html; //for HtmlHelper extension methods
namespace MVC.Components
{
    /// <summary>
    /// http://www.asp.net/mvc/tutorials/older-versions/views/creating-custom-html-helpers-cs
    /// http://www.codeproject.com/Tips/389747/Custom-strongly-typed-HtmlHelpers-in-ASP-NET-MVC
    /// </summary>
    public static class HtmlHelperExtensions
    {
        public static string MyHelper(this HtmlHelper helper, string par)
        {
            return String.Format("<div data-woteva='minger'>{0}</div>", par);
        }

        public static MvcHtmlString RadioListFor<TModel, TProperty>(this HtmlHelper htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            var model = htmlHelper.ViewData.Model;

            //var metaData = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            
            //var sb = new StringBuilder();
            //foreach (var name in names)
            //{
            //    var id = string.Format(
            //        "{0}_{1}_{2}",
            //        htmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix,
            //        metaData.PropertyName,
            //        name
            //    );

            //    //---------------------------------------ERROR HERE!-----------------------------
            //    var radio = htmlHelper.RadioButtonFor(expression, name, new { id = id }).ToHtmlString();
            //    sb.AppendFormat(
            //        "<label for=\"{0}\">{1}</label> {2}",
            //        id,
            //        HttpUtility.HtmlEncode(name),
            //        radio
            //    );
            //}
            return MvcHtmlString.Create("radio button for");
        }

        /// <summary>
        /// http://zahidadeel.blogspot.co.uk/2011/05/master-detail-form-in-aspnet-mvc-3-ii.html
        /// </summary>
        //public static IDisposable BeginCollectionItem(this HtmlHelper htmlHelper, string name, bool isTemplate = false)
        //{
        //    if (isTemplate)
        //    {
        //        var randomNumber = "${randomNumber}";
        //        html.ViewContext.Writer.WriteLine(string.Format("<input type=\"hidden\" name=\"{0}.index\" autocomplete=\"off\" value=\"{1}\" />", collectionName, randomNumber));
        //        return BeginHtmlFieldPrefixScope(html, string.Format("{0}[{1}]", collectionName, randomNumber));
        //    }
        //    else
        //    {
        //        var idsToReuse = GetIdsToReuse(html.ViewContext.HttpContext, collectionName);
        //        string itemIndex = idsToReuse.Count > 0 ? idsToReuse.Dequeue() : Guid.NewGuid().ToString();

        //        // autocomplete="off" is needed to work around a very annoying Chrome behaviour whereby it reuses old values after the user clicks "Back", which causes the xyz.index and xyz[...] values to get out of sync.
        //        html.ViewContext.Writer.WriteLine(string.Format("<input type=\"hidden\" name=\"{0}.index\" autocomplete=\"off\" value=\"{1}\" />", collectionName, html.Encode(itemIndex)));

        //        return BeginHtmlFieldPrefixScope(html, string.Format("{0}[{1}]", collectionName, itemIndex));
        //    }
        //}
    }
}