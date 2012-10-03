using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using ParkerFox.Infrastructure.Web.Bundling;

namespace ParkerFox.Site.App_Start
{
    /// <summary>
    /// 02/10/12: To use ScriptBundle inside System.Web.Optimization I needed to run PM> Install-Package Microsoft.Web.Optimization -Pre 
    /// </summary>
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/core")
                .Include("~/Scripts/jquery-{version}.js")
                .Include("~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(
                new Bundle("~/content/less-css", new LessBundleTransform(), new CssMinify()).Include(
                    "~/Content/Site.less.css"));
        }
    }
}