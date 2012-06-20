using System.Web.Optimization;

namespace MVCWebApiClient
{
 public class BundleConfig
 {
  public static void RegisterBundles(BundleCollection bundles)
  {
   bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
               "~/Scripts/jquery-1.*"));

   bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
               "~/Scripts/jquery.unobtrusive*",
               "~/Scripts/jquery.validate*"));

   bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
       "~/Scripts/modernizr*"));



   bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

  }
 }
}