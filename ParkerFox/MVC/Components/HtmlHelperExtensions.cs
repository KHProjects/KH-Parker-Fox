using System;
using System.Web.Mvc;

namespace MVC.Components
{
    /// <summary>
    /// http://www.asp.net/mvc/tutorials/older-versions/views/creating-custom-html-helpers-cs
    /// </summary>
    public static class HtmlHelperExtensions
    {
        public static string MyHelper(this HtmlHelper helper, string par)
        {
            return String.Format("<div data-woteva='minger'>{0}</div>", par);
        }
    }
}