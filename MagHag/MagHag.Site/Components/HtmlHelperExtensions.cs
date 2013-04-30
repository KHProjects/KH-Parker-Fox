using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace System.Web.Mvc
{
    public static class HtmlHelperExtensions
    {
        //public static MvcHtmlString AddScript(this HtmlHelper htmlHelper, string className, params object[] args)
        //{
        //    string variableName = className[0] + className.Substring(1);
        //
        //    string argument = null;
        //    if (args != null && args.Length > 0)
        //    {
        //        var serializer = new JavaScriptSerializer();
        //        argument = string.Join(",", args.Select(serializer.Serialize));
        //    }
        //
        //    StringBuilder scriptBuilder = new StringBuilder();
        //    scriptBuilder.Append("<script>");
        //    scriptBuilder.AppendFormat("var {0} = new {1}({2});", variableName, className, argument);
        //    scriptBuilder.Append("</script>");
        //
        //    return MvcHtmlString.Create(scriptBuilder.ToString());
        //}

        public static MvcHtmlString AddStartupScript(this HtmlHelper htmlHelper, string className, params object[] args)
        {
            var name = className.Substring(0, className.LastIndexOf(".", StringComparison.InvariantCulture));
            string variableName = name[0].ToString().ToLower() + name.Substring(1);

            string argument = null;
            if (args != null && args.Length > 0)
            {
                var serializer = new JavaScriptSerializer();
                argument = string.Join(",", args.Select(serializer.Serialize));
            }

            StringBuilder scriptBuilder = new StringBuilder();
            scriptBuilder.Append("<script>");
            scriptBuilder.Append("$(document).ready(function(){");
            scriptBuilder.AppendFormat("var {0} = new {1}({2});", variableName, className, argument);            
            scriptBuilder.Append("});");
            scriptBuilder.Append("</script>");

            return MvcHtmlString.Create(scriptBuilder.ToString());
        }
    }
}