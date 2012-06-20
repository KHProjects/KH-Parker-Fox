using System;
using System.Linq;
using System.Web.Optimization;
using Bundler.Utilities;

namespace MVC4BundleUI
{
 public class YUIBundler
 {

  public static void init()
  {
   var debug = true;

   var bundle = new CustomBundle("~/Scripts/js",new YUITransform(contentType.javascript));
   bundle.AddDirectory("~/Scripts", "*.js", true, true);

   BundleTable.Bundles.Add(bundle);

   bundle = new CustomBundle(debug, contentType.css, "~/Content/css");
   bundle.AddDirectory("~/Content", "*.css", true, true);

   BundleTable.Bundles.Add(bundle);
  }
 }
}