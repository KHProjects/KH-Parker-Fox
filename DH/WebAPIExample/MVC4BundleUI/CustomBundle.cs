using System;
using System.Linq;
using System.Web.Optimization;

namespace Bundler.Utilities
{
 public enum contentType
 {
  javascript,
  css
 }

 public class CustomBundle : Bundle
 {
  string _contentType;

  public CustomBundle(string virtualPath, IBundleTransform transformer) : base(virtualPath,transformer)
  {

   
  }

  public CustomBundle(bool debug, contentType contentType, string virtualPath) : base(virtualPath)
  {
   resolveContentType(contentType);

   if (debug)
   {
    this.Transform = new NoTransform(_contentType);
   }
   else
   {
    this.Transform = new YUITransform(contentType);
   }
  }
 

  void resolveContentType(contentType contentType)
  {
   if (contentType == Utilities.contentType.css)
   {
    _contentType = "text/css";
   }
   else
   {
    _contentType = "text/javascript";
   }
  }
 }
}